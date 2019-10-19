namespace JXPulg
{
    partial class XDataForm
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
            this.AddXData_Button = new System.Windows.Forms.Button();
            this.DelXData_Button = new System.Windows.Forms.Button();
            this.UpdateXData_Button = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddXData_Button
            // 
            this.AddXData_Button.Location = new System.Drawing.Point(30, 12);
            this.AddXData_Button.Name = "AddXData_Button";
            this.AddXData_Button.Size = new System.Drawing.Size(149, 23);
            this.AddXData_Button.TabIndex = 1;
            this.AddXData_Button.Text = "添加扩展数据";
            this.AddXData_Button.UseVisualStyleBackColor = true;
            this.AddXData_Button.Click += new System.EventHandler(this.AddXData_Button_Click);
            // 
            // DelXData_Button
            // 
            this.DelXData_Button.Location = new System.Drawing.Point(30, 41);
            this.DelXData_Button.Name = "DelXData_Button";
            this.DelXData_Button.Size = new System.Drawing.Size(149, 23);
            this.DelXData_Button.TabIndex = 2;
            this.DelXData_Button.Text = "删除扩展数据";
            this.DelXData_Button.UseVisualStyleBackColor = true;
            this.DelXData_Button.Click += new System.EventHandler(this.DelXData_Button_Click);
            // 
            // UpdateXData_Button
            // 
            this.UpdateXData_Button.Location = new System.Drawing.Point(30, 70);
            this.UpdateXData_Button.Name = "UpdateXData_Button";
            this.UpdateXData_Button.Size = new System.Drawing.Size(149, 23);
            this.UpdateXData_Button.TabIndex = 3;
            this.UpdateXData_Button.Text = "修改扩展数据";
            this.UpdateXData_Button.UseVisualStyleBackColor = true;
            this.UpdateXData_Button.Click += new System.EventHandler(this.UpdateXData_Button_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(72, 99);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(75, 23);
            this.QuitBtn.TabIndex = 4;
            this.QuitBtn.Text = "取消操作";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // XDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 126);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.UpdateXData_Button);
            this.Controls.Add(this.DelXData_Button);
            this.Controls.Add(this.AddXData_Button);
            this.Name = "XDataForm";
            this.Text = "对象扩展数据面板";
            this.Load += new System.EventHandler(this.XDataForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddXData_Button;
        private System.Windows.Forms.Button DelXData_Button;
        private System.Windows.Forms.Button UpdateXData_Button;
        private System.Windows.Forms.Button QuitBtn;
    }
}