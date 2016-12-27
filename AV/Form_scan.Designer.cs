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
            this.txt_daquet = new System.Windows.Forms.TextBox();
            this.txt_tongso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(48, 34);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(390, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // but_view
            // 
            this.but_view.Location = new System.Drawing.Point(105, 164);
            this.but_view.Name = "but_view";
            this.but_view.Size = new System.Drawing.Size(75, 23);
            this.but_view.TabIndex = 2;
            this.but_view.Text = "VIEW";
            this.but_view.UseVisualStyleBackColor = true;
            this.but_view.Click += new System.EventHandler(this.but_view_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.Location = new System.Drawing.Point(297, 164);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(75, 23);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "CANCEL";
            this.but_cancel.UseVisualStyleBackColor = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // txt_daquet
            // 
            this.txt_daquet.Location = new System.Drawing.Point(149, 101);
            this.txt_daquet.Name = "txt_daquet";
            this.txt_daquet.Size = new System.Drawing.Size(68, 20);
            this.txt_daquet.TabIndex = 4;
            this.txt_daquet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_daquet.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_tongso
            // 
            this.txt_tongso.Location = new System.Drawing.Point(270, 101);
            this.txt_tongso.Name = "txt_tongso";
            this.txt_tongso.Size = new System.Drawing.Size(66, 20);
            this.txt_tongso.TabIndex = 5;
            this.txt_tongso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "/";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form_scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(490, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_tongso);
            this.Controls.Add(this.txt_daquet);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_view);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form_scan";
            this.Text = "MSECAV";
            this.Load += new System.EventHandler(this.Form_scan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button but_view;
        private System.Windows.Forms.Button but_cancel;
        private System.Windows.Forms.TextBox txt_daquet;
        private System.Windows.Forms.TextBox txt_tongso;
        private System.Windows.Forms.Label label1;
    }
}