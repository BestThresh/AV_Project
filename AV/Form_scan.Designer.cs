﻿namespace AV
{
    partial class Form_scan
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.but_view = new System.Windows.Forms.Button();
            this.but_cancel = new System.Windows.Forms.Button();
            this.txt_SoBiNhiem = new System.Windows.Forms.TextBox();
            this.txt_tongso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_CurFile = new System.Windows.Forms.Label();
            this.lab_percent = new System.Windows.Forms.Label();
            this.but_scan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(61, 72);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(502, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // but_view
            // 
            this.but_view.Enabled = false;
            this.but_view.Location = new System.Drawing.Point(100, 217);
            this.but_view.Name = "but_view";
            this.but_view.Size = new System.Drawing.Size(75, 23);
            this.but_view.TabIndex = 2;
            this.but_view.Text = "VIEW";
            this.but_view.UseVisualStyleBackColor = true;
            this.but_view.Click += new System.EventHandler(this.but_view_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(474, 217);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 23);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "CANCEL";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // txt_SoBiNhiem
            // 
            this.txt_SoBiNhiem.Enabled = false;
            this.txt_SoBiNhiem.Location = new System.Drawing.Point(176, 155);
            this.txt_SoBiNhiem.Name = "txt_SoBiNhiem";
            this.txt_SoBiNhiem.Size = new System.Drawing.Size(44, 20);
            this.txt_SoBiNhiem.TabIndex = 4;
            this.txt_SoBiNhiem.Text = "0";
            this.txt_SoBiNhiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_tongso
            // 
            this.txt_tongso.Enabled = false;
            this.txt_tongso.Location = new System.Drawing.Point(240, 155);
            this.txt_tongso.Name = "txt_tongso";
            this.txt_tongso.Size = new System.Drawing.Size(43, 20);
            this.txt_tongso.TabIndex = 5;
            this.txt_tongso.Text = "0";
            this.txt_tongso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "/";
            // 
            // lab_CurFile
            // 
            this.lab_CurFile.AutoSize = true;
            this.lab_CurFile.Location = new System.Drawing.Point(58, 119);
            this.lab_CurFile.Name = "lab_CurFile";
            this.lab_CurFile.Size = new System.Drawing.Size(0, 13);
            this.lab_CurFile.TabIndex = 7;
            // 
            // lab_percent
            // 
            this.lab_percent.AutoSize = true;
            this.lab_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_percent.Location = new System.Drawing.Point(584, 81);
            this.lab_percent.Name = "lab_percent";
            this.lab_percent.Size = new System.Drawing.Size(44, 16);
            this.lab_percent.TabIndex = 8;
            this.lab_percent.Text = "0.00%";
            // 
            // but_scan
            // 
            this.but_scan.Location = new System.Drawing.Point(10, 72);
            this.but_scan.Name = "but_scan";
            this.but_scan.Size = new System.Drawing.Size(45, 23);
            this.but_scan.TabIndex = 9;
            this.but_scan.Text = "SCAN";
            this.but_scan.UseVisualStyleBackColor = true;
            this.but_scan.Click += new System.EventHandler(this.but_scan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Số file bị nhiễm";
            // 
            // Form_scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(664, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_scan);
            this.Controls.Add(this.lab_percent);
            this.Controls.Add(this.lab_CurFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_tongso);
            this.Controls.Add(this.txt_SoBiNhiem);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_view);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form_scan";
            this.Text = "MSECAV";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_scan_FormClosed);
            this.Load += new System.EventHandler(this.Form_scan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button but_view;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.TextBox txt_SoBiNhiem;
        private System.Windows.Forms.TextBox txt_tongso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_CurFile;
        private System.Windows.Forms.Label lab_percent;
        private System.Windows.Forms.Button but_scan;
        private System.Windows.Forms.Label label2;
    }
}