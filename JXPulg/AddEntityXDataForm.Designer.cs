namespace JXPulg
{
    partial class AddEntityXDataForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LayerNameTextBox = new System.Windows.Forms.TextBox();
            this.DataStringTextBox = new System.Windows.Forms.TextBox();
            this.DataInt16TextBox = new System.Windows.Forms.TextBox();
            this.DataInt32TextBox = new System.Windows.Forms.TextBox();
            this.DataScaleTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.WorldXCoordinateXTextBox = new System.Windows.Forms.TextBox();
            this.WorldXCoordinateYTextBox = new System.Windows.Forms.TextBox();
            this.WorldXCoordinateZTextBox = new System.Windows.Forms.TextBox();
            this.SubmitDataBtn = new System.Windows.Forms.Button();
            this.CancelDataBtn = new System.Windows.Forms.Button();
            this.SelEntBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "扩展数据图层名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "扩展数据 16 位符号整数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "扩展数据 32 位符号整数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "扩展数据比例尺";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "扩展数据中的三维世界空间位置 DXF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "扩展数据中的 ASCII 字符串";
            // 
            // LayerNameTextBox
            // 
            this.LayerNameTextBox.Location = new System.Drawing.Point(214, 12);
            this.LayerNameTextBox.Name = "LayerNameTextBox";
            this.LayerNameTextBox.Size = new System.Drawing.Size(100, 21);
            this.LayerNameTextBox.TabIndex = 7;
            this.LayerNameTextBox.TextChanged += new System.EventHandler(this.LayerNameTextBox_TextChanged);
            // 
            // DataStringTextBox
            // 
            this.DataStringTextBox.Location = new System.Drawing.Point(214, 50);
            this.DataStringTextBox.Name = "DataStringTextBox";
            this.DataStringTextBox.Size = new System.Drawing.Size(100, 21);
            this.DataStringTextBox.TabIndex = 8;
            this.DataStringTextBox.TextChanged += new System.EventHandler(this.DataStringTextBox_TextChanged);
            // 
            // DataInt16TextBox
            // 
            this.DataInt16TextBox.Location = new System.Drawing.Point(214, 86);
            this.DataInt16TextBox.Name = "DataInt16TextBox";
            this.DataInt16TextBox.Size = new System.Drawing.Size(100, 21);
            this.DataInt16TextBox.TabIndex = 10;
            this.DataInt16TextBox.TextChanged += new System.EventHandler(this.DataInt16TextBox_TextChanged);
            // 
            // DataInt32TextBox
            // 
            this.DataInt32TextBox.Location = new System.Drawing.Point(214, 119);
            this.DataInt32TextBox.Name = "DataInt32TextBox";
            this.DataInt32TextBox.Size = new System.Drawing.Size(100, 21);
            this.DataInt32TextBox.TabIndex = 11;
            this.DataInt32TextBox.TextChanged += new System.EventHandler(this.DataInt32TextBox_TextChanged);
            // 
            // DataScaleTextBox
            // 
            this.DataScaleTextBox.Location = new System.Drawing.Point(214, 146);
            this.DataScaleTextBox.Name = "DataScaleTextBox";
            this.DataScaleTextBox.Size = new System.Drawing.Size(100, 21);
            this.DataScaleTextBox.TabIndex = 12;
            this.DataScaleTextBox.TextChanged += new System.EventHandler(this.DataScaleTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "X坐标";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 213);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "Y坐标";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 213);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "Z坐标";
            // 
            // WorldXCoordinateXTextBox
            // 
            this.WorldXCoordinateXTextBox.Location = new System.Drawing.Point(73, 210);
            this.WorldXCoordinateXTextBox.Name = "WorldXCoordinateXTextBox";
            this.WorldXCoordinateXTextBox.Size = new System.Drawing.Size(73, 21);
            this.WorldXCoordinateXTextBox.TabIndex = 16;
            this.WorldXCoordinateXTextBox.TextChanged += new System.EventHandler(this.WorldXCoordinateXTextBox_TextChanged);
            // 
            // WorldXCoordinateYTextBox
            // 
            this.WorldXCoordinateYTextBox.Location = new System.Drawing.Point(200, 210);
            this.WorldXCoordinateYTextBox.Name = "WorldXCoordinateYTextBox";
            this.WorldXCoordinateYTextBox.Size = new System.Drawing.Size(77, 21);
            this.WorldXCoordinateYTextBox.TabIndex = 17;
            this.WorldXCoordinateYTextBox.TextChanged += new System.EventHandler(this.WorldXCoordinateYTextBox_TextChanged);
            // 
            // WorldXCoordinateZTextBox
            // 
            this.WorldXCoordinateZTextBox.Location = new System.Drawing.Point(324, 210);
            this.WorldXCoordinateZTextBox.Name = "WorldXCoordinateZTextBox";
            this.WorldXCoordinateZTextBox.Size = new System.Drawing.Size(79, 21);
            this.WorldXCoordinateZTextBox.TabIndex = 18;
            this.WorldXCoordinateZTextBox.TextChanged += new System.EventHandler(this.WorldXCoordinateZTextBox_TextChanged);
            // 
            // SubmitDataBtn
            // 
            this.SubmitDataBtn.Location = new System.Drawing.Point(170, 247);
            this.SubmitDataBtn.Name = "SubmitDataBtn";
            this.SubmitDataBtn.Size = new System.Drawing.Size(75, 23);
            this.SubmitDataBtn.TabIndex = 19;
            this.SubmitDataBtn.Text = "提交";
            this.SubmitDataBtn.UseVisualStyleBackColor = true;
            this.SubmitDataBtn.Click += new System.EventHandler(this.SubmitDataBtn_Click);
            // 
            // CancelDataBtn
            // 
            this.CancelDataBtn.Location = new System.Drawing.Point(285, 247);
            this.CancelDataBtn.Name = "CancelDataBtn";
            this.CancelDataBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelDataBtn.TabIndex = 20;
            this.CancelDataBtn.Text = "取消";
            this.CancelDataBtn.UseVisualStyleBackColor = true;
            this.CancelDataBtn.Click += new System.EventHandler(this.CancelDataBtn_Click);
            // 
            // SelEntBtn
            // 
            this.SelEntBtn.Location = new System.Drawing.Point(48, 247);
            this.SelEntBtn.Name = "SelEntBtn";
            this.SelEntBtn.Size = new System.Drawing.Size(75, 23);
            this.SelEntBtn.TabIndex = 21;
            this.SelEntBtn.Text = "请选择对象";
            this.SelEntBtn.UseVisualStyleBackColor = true;
            this.SelEntBtn.Click += new System.EventHandler(this.SelEntBtn_Click);
            // 
            // AddEntityXDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 291);
            this.Controls.Add(this.SelEntBtn);
            this.Controls.Add(this.CancelDataBtn);
            this.Controls.Add(this.SubmitDataBtn);
            this.Controls.Add(this.WorldXCoordinateZTextBox);
            this.Controls.Add(this.WorldXCoordinateYTextBox);
            this.Controls.Add(this.WorldXCoordinateXTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DataScaleTextBox);
            this.Controls.Add(this.DataInt32TextBox);
            this.Controls.Add(this.DataInt16TextBox);
            this.Controls.Add(this.DataStringTextBox);
            this.Controls.Add(this.LayerNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEntityXDataForm";
            this.Text = "添加对象扩展数据";
            this.Load += new System.EventHandler(this.AddEntityXDataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LayerNameTextBox;
        private System.Windows.Forms.TextBox DataStringTextBox;
        private System.Windows.Forms.TextBox DataInt16TextBox;
        private System.Windows.Forms.TextBox DataInt32TextBox;
        private System.Windows.Forms.TextBox DataScaleTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox WorldXCoordinateXTextBox;
        private System.Windows.Forms.TextBox WorldXCoordinateYTextBox;
        private System.Windows.Forms.TextBox WorldXCoordinateZTextBox;
        private System.Windows.Forms.Button SubmitDataBtn;
        private System.Windows.Forms.Button CancelDataBtn;
        private System.Windows.Forms.Button SelEntBtn;
    }
}