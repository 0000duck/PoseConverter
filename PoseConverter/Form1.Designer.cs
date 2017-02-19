using System;

namespace PoseConverter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonZyzRad = new System.Windows.Forms.RadioButton();
            this.radioButtonZyzDeg = new System.Windows.Forms.RadioButton();
            this.radioButtonZyxRad = new System.Windows.Forms.RadioButton();
            this.radioButtonZyxDeg = new System.Windows.Forms.RadioButton();
            this.textBoxZyzRad = new System.Windows.Forms.TextBox();
            this.textBoxZyzDeg = new System.Windows.Forms.TextBox();
            this.textBoxZyxRad = new System.Windows.Forms.TextBox();
            this.textBox4ZyxDeg = new System.Windows.Forms.TextBox();
            this.labelRotationMatrix = new System.Windows.Forms.Label();
            this.richTextBoxRotationMatrix = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonZyzRad
            // 
            this.radioButtonZyzRad.AutoSize = true;
            this.radioButtonZyzRad.Location = new System.Drawing.Point(6, 19);
            this.radioButtonZyzRad.Name = "radioButtonZyzRad";
            this.radioButtonZyzRad.Size = new System.Drawing.Size(135, 16);
            this.radioButtonZyzRad.TabIndex = 0;
            this.radioButtonZyzRad.TabStop = true;
            this.radioButtonZyzRad.Text = "ZYZ Euler Angle [rad]";
            this.radioButtonZyzRad.UseVisualStyleBackColor = true;
            this.radioButtonZyzRad.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonZyzDeg
            // 
            this.radioButtonZyzDeg.AutoSize = true;
            this.radioButtonZyzDeg.Location = new System.Drawing.Point(6, 41);
            this.radioButtonZyzDeg.Name = "radioButtonZyzDeg";
            this.radioButtonZyzDeg.Size = new System.Drawing.Size(137, 16);
            this.radioButtonZyzDeg.TabIndex = 1;
            this.radioButtonZyzDeg.TabStop = true;
            this.radioButtonZyzDeg.Text = "ZYZ Euler Angle [deg]";
            this.radioButtonZyzDeg.UseVisualStyleBackColor = true;
            this.radioButtonZyzDeg.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonZyxRad
            // 
            this.radioButtonZyxRad.AutoSize = true;
            this.radioButtonZyxRad.Location = new System.Drawing.Point(6, 63);
            this.radioButtonZyxRad.Name = "radioButtonZyxRad";
            this.radioButtonZyxRad.Size = new System.Drawing.Size(135, 16);
            this.radioButtonZyxRad.TabIndex = 2;
            this.radioButtonZyxRad.TabStop = true;
            this.radioButtonZyxRad.Text = "ZYX Euler Angle [rad]";
            this.radioButtonZyxRad.UseVisualStyleBackColor = true;
            this.radioButtonZyxRad.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButtonZyxDeg
            // 
            this.radioButtonZyxDeg.AutoSize = true;
            this.radioButtonZyxDeg.Location = new System.Drawing.Point(6, 84);
            this.radioButtonZyxDeg.Name = "radioButtonZyxDeg";
            this.radioButtonZyxDeg.Size = new System.Drawing.Size(137, 16);
            this.radioButtonZyxDeg.TabIndex = 3;
            this.radioButtonZyxDeg.TabStop = true;
            this.radioButtonZyxDeg.Text = "ZYX Euler Angle [deg]";
            this.radioButtonZyxDeg.UseVisualStyleBackColor = true;
            this.radioButtonZyxDeg.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // textBoxZyzRad
            // 
            this.textBoxZyzRad.Location = new System.Drawing.Point(155, 42);
            this.textBoxZyzRad.Name = "textBoxZyzRad";
            this.textBoxZyzRad.Size = new System.Drawing.Size(310, 19);
            this.textBoxZyzRad.TabIndex = 4;
            // 
            // textBoxZyzDeg
            // 
            this.textBoxZyzDeg.Location = new System.Drawing.Point(155, 64);
            this.textBoxZyzDeg.Name = "textBoxZyzDeg";
            this.textBoxZyzDeg.Size = new System.Drawing.Size(310, 19);
            this.textBoxZyzDeg.TabIndex = 5;
            this.textBoxZyzDeg.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxZyxRad
            // 
            this.textBoxZyxRad.Location = new System.Drawing.Point(155, 86);
            this.textBoxZyxRad.Name = "textBoxZyxRad";
            this.textBoxZyxRad.Size = new System.Drawing.Size(310, 19);
            this.textBoxZyxRad.TabIndex = 6;
            this.textBoxZyxRad.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4ZyxDeg
            // 
            this.textBox4ZyxDeg.Location = new System.Drawing.Point(155, 109);
            this.textBox4ZyxDeg.Name = "textBox4ZyxDeg";
            this.textBox4ZyxDeg.Size = new System.Drawing.Size(310, 19);
            this.textBox4ZyxDeg.TabIndex = 7;
            // 
            // labelRotationMatrix
            // 
            this.labelRotationMatrix.AutoSize = true;
            this.labelRotationMatrix.Location = new System.Drawing.Point(56, 137);
            this.labelRotationMatrix.Name = "labelRotationMatrix";
            this.labelRotationMatrix.Size = new System.Drawing.Size(84, 12);
            this.labelRotationMatrix.TabIndex = 8;
            this.labelRotationMatrix.Text = "Rotation Matrix";
            // 
            // richTextBoxRotationMatrix
            // 
            this.richTextBoxRotationMatrix.Location = new System.Drawing.Point(155, 134);
            this.richTextBoxRotationMatrix.Name = "richTextBoxRotationMatrix";
            this.richTextBoxRotationMatrix.Size = new System.Drawing.Size(310, 125);
            this.richTextBoxRotationMatrix.TabIndex = 9;
            this.richTextBoxRotationMatrix.Text = "";
            this.richTextBoxRotationMatrix.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonZyzRad);
            this.groupBox1.Controls.Add(this.radioButtonZyzDeg);
            this.groupBox1.Controls.Add(this.radioButtonZyxRad);
            this.groupBox1.Controls.Add(this.radioButtonZyxDeg);
            this.groupBox1.Location = new System.Drawing.Point(1, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 108);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Convert from ...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 273);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBoxRotationMatrix);
            this.Controls.Add(this.labelRotationMatrix);
            this.Controls.Add(this.textBox4ZyxDeg);
            this.Controls.Add(this.textBoxZyxRad);
            this.Controls.Add(this.textBoxZyzDeg);
            this.Controls.Add(this.textBoxZyzRad);
            this.Name = "Form1";
            this.Text = "PoseConverter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonZyzRad;
        private System.Windows.Forms.RadioButton radioButtonZyzDeg;
        private System.Windows.Forms.RadioButton radioButtonZyxRad;
        private System.Windows.Forms.RadioButton radioButtonZyxDeg;
        private System.Windows.Forms.TextBox textBoxZyzRad;
        private System.Windows.Forms.TextBox textBoxZyzDeg;
        private System.Windows.Forms.TextBox textBoxZyxRad;
        private System.Windows.Forms.TextBox textBox4ZyxDeg;
        private System.Windows.Forms.Label labelRotationMatrix;
        private System.Windows.Forms.RichTextBox richTextBoxRotationMatrix;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

