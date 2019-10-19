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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void SelectDWG_Click(object sender, EventArgs e)
        {
            //清空进度条
            this.DwgPro.Value = 0;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                List<string> dwgnamelist = new List<string>();
                //进度最小值
                this.DwgPro.Minimum = 0;
                //步进值
                this.DwgPro.Step = 1;
                int AllPro = 0;
                //允许选中多个
             ofd.Multiselect = true;
                //文件后缀
             ofd.Filter = "DWG格式文件|*.dwg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    
                    foreach (string dwgfile in ofd.FileNames)
                    {
                        AllPro++;
                        dwgnamelist.Add(dwgfile);
                    }
                    //进度最大值
                    this.DwgPro.Maximum = AllPro; 
                    
                    //循环调用
                    foreach (string filename in dwgnamelist)
                    {
                        this.TxtDwgName.Text += "\r\n" + filename;
                        Helper.InsertBlock(filename);
                        this.DwgPro.PerformStep();
                    }
                   
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtDwgName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
