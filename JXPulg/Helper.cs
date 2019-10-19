using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXPulg
{

    class Helper
    {
        public static void InsertBlock(string fileName)
        {
            //块ID
            ObjectId blockId;
            //图形数据库读取外部图块
            Database blockDatabase = new Database(false, true);
            blockDatabase.ReadDwgFile(fileName, System.IO.FileShare.Read, false, string.Empty);
            // blockDatabase.CloseInput(true);

            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForWrite);
                string blockName = SymbolUtilityServices.GetBlockNameFromInsertPathName(fileName);
                //将外部图块插入到当前模型空间
                blockId = db.Insert(blockName, blockDatabase, true);
                trans.Commit();
            }

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord btr = tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                //通过块定义创建块参照
                BlockReference br = new BlockReference(new Point3d(0, 0, 0), blockId);
                //把块参照添加到块表记录
                btr.AppendEntity(br);
                tr.AddNewlyCreatedDBObject(br, true);
                tr.Commit();
            }
        }


        // 添加实体到图形数据库中
        public static ObjectId AddToModelSpace(Entity ent, Database db)
        {
            ObjectId entId;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                entId = btr.AppendEntity(ent);
                trans.AddNewlyCreatedDBObject(ent, true);
                trans.Commit();
            }
            return entId;
        }

        //返回选中对象的扩展数据
        public static List<string> ObjectXData()
        {
            //扩展数据容器
            List<string> XDataList = new List<string>();

            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //下面的操作用来选择实体来显示它的扩展数据
                PromptEntityOptions opt = new PromptEntityOptions("请选择实体来显示它的扩展数据");
                PromptEntityResult res = ed.GetEntity(opt);
                if (res.Status != PromptStatus.OK)
                {
                    return XDataList;
                }
                Entity ent = (Entity)trans.GetObject(res.ObjectId, OpenMode.ForRead);
                //判断实体的类型 点 线 面   

                //点
                if (ent.GetType().Name.ToString() == "DBPoint")
                {
                    DBPoint Selectent = (DBPoint)trans.GetObject(res.ObjectId, OpenMode.ForWrite);
                    //扩展数据
                    ResultBuffer xdata = Selectent.XData;
                    if (xdata != null)
                    {
                        foreach (TypedValue entXData in xdata)
                        {
                            string DataItem = entXData.TypeCode + "- - - - - -" + entXData.Value;
                            XDataList.Add(DataItem);
                        }
                    }
                }

                //直线
                if (ent.GetType().Name.ToString() == "Line")
                {
                    Line Selectent = (Line)trans.GetObject(res.ObjectId, OpenMode.ForWrite);
                    //扩展数据
                    ResultBuffer xdata = Selectent.XData;
                    if (xdata != null)
                    {
                        foreach (TypedValue entXData in xdata)
                        {
                            string DataItem = entXData.TypeCode + "- - - - - -" + entXData.Value;
                            XDataList.Add(DataItem);
                        }
                    }
                }

                //多段线
                if (ent.GetType().Name.ToString() == "Polyline")
                {
                    Polyline Selectent = (Polyline)trans.GetObject(res.ObjectId, OpenMode.ForWrite);
                    bool closed = Selectent.Closed;
                    //多段线闭合 围成了面积
                    if (closed == true)
                    {
                        //扩展数据
                        ResultBuffer xdata = Selectent.XData;
                        if (xdata != null)
                        {
                            foreach (TypedValue entXData in xdata)
                            {
                                string DataItem = entXData.TypeCode + "- - - - - -" + entXData.Value;
                                XDataList.Add(DataItem);
                            }
                        }
                    }
                    else
                    {
                        //不能围成面
                        return XDataList;
                    }
                }

            }
            return XDataList;
        }

        //用户添加扩展记录
        public static void UserAddXData()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("添加扩充数据 XDATA\n");
            PromptEntityOptions entOps = new PromptEntityOptions("选择实体对象");
            PromptEntityResult entRes;
            entRes = ed.GetEntity(entOps);
            if (entRes.Status != PromptStatus.OK)
            {
                ed.WriteMessage("选择对象失败，退出");
                return;
            }
            //出现添加扩展数据面板
            AddEntityXDataForm addentityxdataform = new AddEntityXDataForm();
            addentityxdataform.Show();

            ObjectId objId = entRes.ObjectId;
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                RegAppTable appTbl = trans.GetObject(db.RegAppTableId, OpenMode.ForWrite) as RegAppTable;
                string DateStr = DateTime.Now.ToString("yyyyMMddHHmmssms");//日期
                Random rd = new Random();//用于生成随机数
                string AppNamestr = DateStr + rd.Next(10, 99);//带日期的随机数
                Entity ent = trans.GetObject(objId, OpenMode.ForWrite) as Entity;

                if (!appTbl.Has(AppNamestr))
                {
                    RegAppTableRecord appTblRcd = new RegAppTableRecord();
                    appTblRcd.Name = AppNamestr;
                    appTbl.Add(appTblRcd);
                    trans.AddNewlyCreatedDBObject(appTblRcd, true);
                }
             
                ResultBuffer resBuf = new ResultBuffer(
                 new TypedValue((int)DxfCode.ExtendedDataRegAppName, AppNamestr),
                 new TypedValue((int)DxfCode.ExtendedDataLayerName, "0"),
                 new TypedValue((int)DxfCode.ExtendedDataReal, 1.23479137438413E+40),
                 new TypedValue((int)DxfCode.ExtendedDataInteger16, 32767),
                 new TypedValue((int)DxfCode.ExtendedDataInteger32, 32767),
                 new TypedValue((int)DxfCode.ExtendedDataScale, 10),
                 new TypedValue((int)DxfCode.ExtendedDataWorldXCoordinate, new Point3d(10, 10, 0)));
                resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataAsciiString, "这是追加的数据"));
                resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataAsciiString, "我又一次追加了数据"));
                resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataInteger16, 32767));

                if (ent.XData != null)
                {
                    ed.WriteMessage("该对象已有扩展记录,不需要再次添加,只需在原有记录进行修改");
                    return;
                }
                ent.XData = resBuf;
                trans.Commit();
            }
        }

    }
}



