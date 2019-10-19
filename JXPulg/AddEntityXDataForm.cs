using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXPulg
{


    public partial class AddEntityXDataForm : Form
    {
      
        //初始化
        public AddEntityXDataForm()
        {
            InitializeComponent();
        }

        private void AddEntityXDataForm_Load(object sender, EventArgs e)
        {
          
        }

        private void CancelDataBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LayerNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataStringTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataFloatTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataInt16TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataInt32TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataScaleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorldXCoordinateXTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorldXCoordinateYTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorldXCoordinateZTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
        }

        private void SubmitDataBtn_Click(object sender, EventArgs e)
        {

        }

        private void SelEntBtn_Click(object sender, EventArgs e)
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

                ResultBuffer resBuf = new ResultBuffer(new TypedValue((int)DxfCode.ExtendedDataRegAppName, AppNamestr));
               
                if (this.DataInt16TextBox.Text != null)
                {
                    int addint16data = int.Parse(this.DataInt16TextBox.Text);
                    resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataInteger16, addint16data));
                }
                if (this.DataInt32TextBox.Text != null)
                {
                    int addint32data = int.Parse(this.DataInt32TextBox.Text);
                    resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataInteger32, addint32data));
                }
               
                //比例
                if (this.DataScaleTextBox.Text != null)
                {
                    int addscaledata = int.Parse(this.DataScaleTextBox.Text);
                    resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataScale, addscaledata));
                }
                //ASCII字符串
                if (this.DataStringTextBox.Text != null)
                {
                    resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataAsciiString, this.DataStringTextBox.Text));
                }
                //图层名称
                if (this.LayerNameTextBox.Text != null)
                {
                    resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataLayerName, this.LayerNameTextBox.Text));
                }
                //坐标
                if (this.WorldXCoordinateXTextBox.Text != null && this.WorldXCoordinateYTextBox.Text != null && this.WorldXCoordinateZTextBox.Text != null)
                {
                    double pointx = double.Parse(this.WorldXCoordinateXTextBox.Text);
                    double pointy = double.Parse(this.WorldXCoordinateYTextBox.Text);
                    double pointz = double.Parse(this.WorldXCoordinateZTextBox.Text);
                    Point3d PointLoaction = new Point3d(pointx, pointy, pointz);
                    resBuf.Add(new TypedValue((int)DxfCode.ExtendedDataWorldXCoordinate, PointLoaction));
                }
             
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
