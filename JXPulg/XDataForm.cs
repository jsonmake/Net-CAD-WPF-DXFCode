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
    public partial class XDataForm : Form
    {
        public static PromptEntityResult entRes;
        public XDataForm()
        {
            InitializeComponent();
         
        }

        private void XDataForm_Load(object sender, EventArgs e)
        {

        }

        //添加扩展数据
        private void AddXData_Button_Click(object sender, EventArgs e)
        {
            using (AddEntityXDataForm addentityxdataform = new AddEntityXDataForm())
            {               
                Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(addentityxdataform);          
            }

        }
        

        //删除扩展数据
        private void DelXData_Button_Click(object sender, EventArgs e)
        {
            List<string> XDataAppNameList = new List<string>();
            Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("删除扩充数据 XDATA\n");
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
                Entity ent = trans.GetObject(objId, OpenMode.ForWrite) as Entity;
                if (ent.XData != null)
                {
                    foreach (TypedValue entXData in ent.XData)
                        {
                        //将扩展名称记录到扩展名称容器中
                         if(entXData.TypeCode.ToString().Equals("1001")){
                                XDataAppNameList.Add(entXData.Value.ToString());
                            }
                        }
                }else{
                    ed.WriteMessage("该对象不存在扩展数据，退出");
                return;
                }
                /*
                 * 将扩展数据重新赋值清空 约等于 删除 
                 * */
                  foreach (string ItemAppName in XDataAppNameList){
                        if (appTbl.Has(ItemAppName))
                {
                   ent.XData = new ResultBuffer(new TypedValue[]{new TypedValue((int)DxfCode.ExtendedDataRegAppName,ItemAppName)});
                }
                  }
                trans.Commit();
            }
        }

        //修改扩展数据
        private void UpdateXData_Button_Click(object sender, EventArgs e)
        {

        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
