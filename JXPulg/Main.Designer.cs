namespace JXPulg
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectDWG = new System.Windows.Forms.Button();
            this.TxtDwgName = new System.Windows.Forms.TextBox();
            this.DwgPro = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectDWG
            // 
            this.SelectDWG.Location = new System.Drawing.Point(24, 166);
            this.SelectDWG.Name = "SelectDWG";
            this.SelectDWG.Size = new System.Drawing.Size(158, 23);
            this.SelectDWG.TabIndex = 0;
            this.SelectDWG.Text = "点击选择DWG文件";
            this.SelectDWG.UseVisualStyleBackColor = true;
            this.SelectDWG.Click += new System.EventHandler(this.SelectDWG_Click);
            // 
            // TxtDwgName
            // 
            this.TxtDwgName.Location = new System.Drawing.Point(24, 77);
            this.TxtDwgName.Multiline = true;
            this.TxtDwgName.Name = "TxtDwgName";
            this.TxtDwgName.Size = new System.Drawing.Size(168, 83);
            this.TxtDwgName.TabIndex = 1;
            this.TxtDwgName.Text = "被选中的文件";
            this.TxtDwgName.TextChanged += new System.EventHandler(this.TxtDwgName_TextChanged);
            // 
            // DwgPro
            // 
            this.DwgPro.Location = new System.Drawing.Point(24, 39);
            this.DwgPro.Name = "DwgPro";
            this.DwgPro.Size = new System.Drawing.Size(168, 23);
            this.DwgPro.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "在进度条没走完之前不要关闭对话框";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DwgPro);
            this.Controls.Add(this.TxtDwgName);
            this.Controls.Add(this.SelectDWG);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectDWG;
        private System.Windows.Forms.TextBox TxtDwgName;
        private System.Windows.Forms.ProgressBar DwgPro;
        private System.Windows.Forms.Label label1;
    }
}