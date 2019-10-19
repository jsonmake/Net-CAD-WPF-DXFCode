using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Colors;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXPulg
{
    public class Command
    {

        [CommandMethod("OperXData")]
        public void ShowModalDialog()
        {
            using (XDataForm form = new XDataForm())
            {

                Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(form);
               
            }
        }

       

        [CommandMethod("SelectFile")]
        public void SelectFile()
        {
            Main dwgDialog = new Main();
            dwgDialog.ShowDialog();
        }

     

        [CommandMethod("ListXData")]
        public void ListXData()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //下面的操作用来选择实体来显示它的扩展数据
                PromptEntityOptions opt = new PromptEntityOptions("请选择实体来显示它的扩展数据");
                PromptEntityResult res = ed.GetEntity(opt);
                if (res.Status != PromptStatus.OK)
                {
                    return;
                }
                Entity ent = (Entity)trans.GetObject(res.ObjectId, OpenMode.ForRead);
                //获取所选择实体中名为“实体扩展数据”的扩展数据
                ResultBuffer rb = ent.GetXDataForApplication("实体扩展数据");
                //如果没有，就返回
                if (rb == null)
                {
                    return;
                }
                //循环遍历扩展数据
                foreach (TypedValue entXData in rb)
                {
                    ed.WriteMessage(string.Format("\nTypeCode={0},Value={1}", entXData.TypeCode, entXData.Value));
                }
            }
        }




        //用户选中对象 标注对象基本信息
        [CommandMethod("GetInformation")]
        public void GetInformation()
        {
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            Database db = HostApplicationServices.WorkingDatabase;
            //获得标注样式
            ObjectId curDimstyle = db.Dimstyle;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //下面的操作用来选择实体来显示它的扩展数据
                PromptEntityOptions opt = new PromptEntityOptions("请选择实体来显示它的扩展数据");
                PromptEntityResult res = ed.GetEntity(opt);
                if (res.Status != PromptStatus.OK)
                {
                    return;
                }
                Entity ent = (Entity)trans.GetObject(res.ObjectId, OpenMode.ForRead);
                //判断实体的类型 点 线 面
                //点
                if (ent.GetType().Name.ToString() == "DBPoint")
                {
                    DBPoint Selectent = (DBPoint)trans.GetObject(res.ObjectId, OpenMode.ForWrite);
                    //位置
                    Point3d position = Selectent.Position;
                    double x = position.X;
                    double y = position.Y;
                    double z = position.Z;
                    //厚度
                    double thickness = Selectent.Thickness;
                    //扩展数据
                    ResultBuffer xdata = Selectent.XData;
                    if (xdata != null)
                    {
                        foreach (TypedValue entXData in xdata)
                        {
                            ed.WriteMessage(string.Format("\n扩展数据  类型代码={0},数据值={1}", entXData.TypeCode, entXData.Value));
                        }
                    }
                    ed.WriteMessage(string.Format("\n 点的X坐标={0}", x.ToString()));
                    ed.WriteMessage(string.Format("\n 点的Y坐标={0}", y.ToString()));
                    ed.WriteMessage(string.Format("\n 点的Z坐标={0}", z.ToString()));
                }

                //直线
                if (ent.GetType().Name.ToString() == "Line")
                {
                    Line Selectent = (Line)trans.GetObject(res.ObjectId, OpenMode.ForWrite);
                    //起点
                    Point3d start = Selectent.StartPoint;
                    //终点
                    Point3d end = Selectent.EndPoint;

                    //线段的中点位置
                    Point3d midpoint = new Point3d((start.X + end.X) / 2, (start.Y + end.Y) / 2, 0);

                    double sx = start.X;
                    double sy = start.Y;
                    double ex = end.X;
                    double ey = end.Y;
                    //扩展数据
                    ResultBuffer xdata = Selectent.XData;
                    if (xdata != null)
                    {
                        foreach (TypedValue entXData in xdata)
                        {
                            ed.WriteMessage(string.Format("\n扩展数据  类型代码={0},数据值={1}", entXData.TypeCode, entXData.Value));
                        }
                    }
                    ed.WriteMessage(string.Format("\n 直线起点X坐标={0}", sx.ToString()));
                    ed.WriteMessage(string.Format("\n 直线起点Y坐标={0}", sy.ToString()));
                    ed.WriteMessage(string.Format("\n 直线终点X坐标={0}", ex.ToString()));
                    ed.WriteMessage(string.Format("\n 直线终点Y坐标={0}", ey.ToString()));

                    PromptPointOptions optPointB = new PromptPointOptions("\n请输入标注终点位置:");
                    optPointB.AllowNone = true;
                    PromptPointResult resPointB = ed.GetPoint(optPointB);
                    Point3d ptEnd = resPointB.Value;

                    Point3d pt1 = new Point3d(midpoint[0], midpoint[1], 0);
                    Point3d pt2 = new Point3d(ptEnd[0], ptEnd[1], 0);

                    //标注
                    Point3dCollection ptss = new Point3dCollection();
                    ptss.Add(pt1);
                    ptss.Add(pt2);
                    ModelSpace.AddLeader(ptss, false);
                    //标注内容
                    ModelSpace.AddMtext(pt1, "{\\L引线标注示例\\l}", curDimstyle, AttachmentPoint.BottomLeft, 2.5, 0);
                }

                //多段线
                if (ent.GetType().Name.ToString() == "Polyline")
                {
                    Polyline Selectent = (Polyline)trans.GetObject(res.ObjectId, OpenMode.ForWrite);
                    //面积
                    double area = Selectent.Area;
                    //长度
                    double length = Selectent.Length;
                    Point3d startpoint = Selectent.StartPoint;
                    double startpointx = startpoint.X;
                    double startpointy = startpoint.Y;
                    bool closed = Selectent.Closed;
                    //多段线闭合 围成了面积
                    if (closed == true)
                    {
                        ed.WriteMessage(string.Format("多段线闭合: YES"));
                        ed.WriteMessage(string.Format("\n  顶点X坐标={0}", startpointx.ToString()));
                        ed.WriteMessage(string.Format("\n 顶点Y坐标={0}", startpointy.ToString()));
                        ed.WriteMessage(string.Format("\n 多段线面积={0}", area.ToString()));
                        ed.WriteMessage(string.Format("\n 多段线长度={0}", length.ToString()));

                        //扩展数据
                        ResultBuffer xdata = Selectent.XData;
                        if (xdata != null)
                        {
                            foreach (TypedValue entXData in xdata)
                            {
                                ed.WriteMessage(string.Format("\n扩展数据  类型代码={0},数据值={1}", entXData.TypeCode, entXData.Value));
                            }
                        }
                    }
                    else
                    {
                        ed.WriteMessage(string.Format("多段线闭合: NO 无法围成面"));
                        return;
                    }
                }
            }
        }

       
        //用户选择标注位置
        [CommandMethod("SelectNotePosition")]
        public void SelectNotePosition()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            //获得标注样式
            ObjectId curDimstyle = db.Dimstyle;

            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;

            PromptPointOptions optPointA = new PromptPointOptions("\n请输入标注对象的点");
            optPointA.AllowNone = true;
            PromptPointResult resPointA = ed.GetPoint(optPointA);
            Point3d ptStart = resPointA.Value;

            PromptPointOptions optPointB = new PromptPointOptions("\n请输入下一个点");
            optPointB.AllowNone = true;
            PromptPointResult resPointB = ed.GetPoint(optPointB);
            Point3d ptEnd = resPointB.Value;

            Point3d pt1 = new Point3d(ptStart[0], ptStart[1], 0);
            Point3d pt2 = new Point3d(ptEnd[0], ptEnd[1], 0);

            //直线
            //Line NoteLine = new Line(pt1, pt2);
            //Helper.AddToModelSpace(NoteLine, db);

            //标注
            Point3dCollection ptss = new Point3dCollection();
            ptss.Add(pt1);
            ptss.Add(pt2);
            ModelSpace.AddLeader(ptss, false);
            //标注内容
            ModelSpace.AddMtext(pt2, "{\\L引线标注示例\\l}", curDimstyle, AttachmentPoint.BottomLeft, 2.5, 0);
        }

        /// &lt;summary&gt;
        /// 添加实体到模型空间
        /// &lt;/summary&gt;
        /// &lt;param name="ent"&gt;要添加的对象&lt;/param&gt;
        /// &lt;returns&gt;实体ObjectId&lt;/returns&gt;
        public static ObjectId ToModelSpace(Entity ent)
        {
            Database db = HostApplicationServices.WorkingDatabase;
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



        [CommandMethod("netDim")]
        public void CreateDimension()
        {
            // 创建要标注的图形---------------------------------------------
            ModelSpace.AddLine(new Point3d(30, 20, 0), new Point3d(120, 20, 0));
            ModelSpace.AddLine(new Point3d(120, 20, 0), new Point3d(120, 40, 0));
            ModelSpace.AddLine(new Point3d(120, 40, 0), new Point3d(90, 80, 0));
            ModelSpace.AddLine(new Point3d(90, 80, 0), new Point3d(30, 80, 0));
            ModelSpace.AddArc(new Point3d(30, 50, 0), 30, ModelSpace.Rad2Ang(90), ModelSpace.Rad2Ang(270));
            ModelSpace.AddCircle(new Point3d(30, 50, 0), 15);
            ModelSpace.AddCircle(new Point3d(70, 50, 0), 10);

            // 得到当前标注样式---------------------------------------------
            Database db = HostApplicationServices.WorkingDatabase;
            ObjectId curDimstyle = db.Dimstyle;


            Point3dCollection pts = new Point3dCollection();
            pts.Add(new Point3d(90, 70, 0));
            pts.Add(new Point3d(110, 80, 0));
            pts.Add(new Point3d(120, 80, 0));
            ModelSpace.AddLeader(pts, false);
            // 添加引线标注的文字.
            ModelSpace.AddMtext(new Point3d(120, 80, 0), "{\\L引线标注示例\\l}", curDimstyle, AttachmentPoint.BottomLeft, 2.5, 0);


            Point3dCollection ptss = new Point3dCollection();
            ptss.Add(new Point3d(70, 80, 0));
            ptss.Add(new Point3d(70, 100, 0));
            ptss.Add(new Point3d(80, 100, 0));
            ModelSpace.AddLeader(ptss, false);
        }

        [CommandMethod("AutoScale")]
        public void Scale()
        {
            Database db = HostApplicationServices.WorkingDatabase;
            DBText txt = DBText(Point3d.Origin, "深居浅出", 100);
            txt.Annotative = AnnotativeStates.True;
            ObjectContextManager cm = db.ObjectContextManager;
            ObjectContextCollection occ = cm.GetContextCollection("ACDB_ANNOTATIONSCALES");
            foreach (ObjectContext oc in occ)
            {
                txt.AddContext(oc);
            }
            Circle cir = new Circle(new Point3d(265, 50, 0), Vector3d.ZAxis, 300);
            ToModelSpace(txt);
            ToModelSpace(cir);
        }

        public static DBText DBText(Point3d position, string textString, double height)
        {
            DBText ent = new DBText();
            ent.Position = position;
            ent.TextString = textString;
            ent.Height = height;
            return ent;
        }




    }
}



    




  
 

    

