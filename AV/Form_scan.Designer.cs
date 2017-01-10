namespace AV
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
            this.progressBar1.Location = new System.Drawing.Point(81, 88);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(670, 28);
            this.progressBar1.TabIndex = 1;
            // 
            // but_view
            // 
            this.but_view.Location = new System.Drawing.Point(133, 267);
            this.but_view.Margin = new System.Windows.Forms.Padding(4);
            this.but_view.Name = "but_view";
            this.but_view.Size = new System.Drawing.Size(100, 28);
            this.but_view.TabIndex = 2;
            this.but_view.Text = "VIEW";
            this.but_view.UseVisualStyleBackColor = true;
            this.but_view.Click += new System.EventHandler(this.but_view_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(632, 267);
            this.but_cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(100, 28);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "CANCEL";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // txt_SoBiNhiem
            // 
            this.txt_SoBiNhiem.Enabled = false;
            this.txt_SoBiNhiem.Location = new System.Drawing.Point(235, 191);
            this.txt_SoBiNhiem.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SoBiNhiem.Name = "txt_SoBiNhiem";
            this.txt_SoBiNhiem.Size = new System.Drawing.Size(57, 22);
            this.txt_SoBiNhiem.TabIndex = 4;
            this.txt_SoBiNhiem.Text = "0";
            this.txt_SoBiNhiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_tongso
            // 
            this.txt_tongso.Enabled = false;
            this.txt_tongso.Location = new System.Drawing.Point(320, 191);
            this.txt_tongso.Margin = new System.Windows.Forms.Padding(4);
            this.txt_tongso.Name = "txt_tongso";
            this.txt_tongso.Size = new System.Drawing.Size(56, 22);
            this.txt_tongso.TabIndex = 5;
            this.txt_tongso.Text = "0";
            this.txt_tongso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 196);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "/";
            // 
            // lab_CurFile
            // 
            this.lab_CurFile.AutoSize = true;
            this.lab_CurFile.Location = new System.Drawing.Point(78, 147);
            this.lab_CurFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_CurFile.Name = "lab_CurFile";
            this.lab_CurFile.Size = new System.Drawing.Size(0, 16);
            this.lab_CurFile.TabIndex = 7;
            // 
            // lab_percent
            // 
            this.lab_percent.AutoSize = true;
            this.lab_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_percent.Location = new System.Drawing.Point(779, 100);
            this.lab_percent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_percent.Name = "lab_percent";
            this.lab_percent.Size = new System.Drawing.Size(44, 16);
            this.lab_percent.TabIndex = 8;
            this.lab_percent.Text = "0.00%";
            // 
            // but_scan
            // 
            this.but_scan.Location = new System.Drawing.Point(13, 88);
            this.but_scan.Margin = new System.Windows.Forms.Padding(4);
            this.but_scan.Name = "but_scan";
            this.but_scan.Size = new System.Drawing.Size(60, 28);
            this.but_scan.TabIndex = 9;
            this.but_scan.Text = "SCAN";
            this.but_scan.UseVisualStyleBackColor = true;
            this.but_scan.Click += new System.EventHandler(this.but_scan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Số file bị nhiễm";
            // 
            // Form_scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(886, 322);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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