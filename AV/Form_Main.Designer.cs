namespace AV
{
    partial class Form_Main
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
            this.btn_chonfile = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chk_boot = new System.Windows.Forms.CheckBox();
            this.chk_Realtime = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Main_butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_chonfile
            // 
            this.btn_chonfile.Location = new System.Drawing.Point(339, 19);
            this.btn_chonfile.Name = "btn_chonfile";
            this.btn_chonfile.Size = new System.Drawing.Size(75, 23);
            this.btn_chonfile.TabIndex = 0;
            this.btn_chonfile.Text = "Chọn File";
            this.btn_chonfile.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(339, 58);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 20);
            this.textBox1.TabIndex = 3;
            // 
            // chk_boot
            // 
            this.chk_boot.AutoSize = true;
            this.chk_boot.Location = new System.Drawing.Point(12, 110);
            this.chk_boot.Name = "chk_boot";
            this.chk_boot.Size = new System.Drawing.Size(48, 17);
            this.chk_boot.TabIndex = 6;
            this.chk_boot.Text = "Boot";
            this.chk_boot.UseVisualStyleBackColor = true;
            // 
            // chk_Realtime
            // 
            this.chk_Realtime.AutoSize = true;
            this.chk_Realtime.Location = new System.Drawing.Point(12, 134);
            this.chk_Realtime.Name = "chk_Realtime";
            this.chk_Realtime.Size = new System.Drawing.Size(70, 17);
            this.chk_Realtime.TabIndex = 7;
            this.chk_Realtime.Text = "Real time";
            this.chk_Realtime.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Cập nhật dữ liệu virus";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Main_butExit
            // 
            this.Main_butExit.Location = new System.Drawing.Point(349, 261);
            this.Main_butExit.Name = "Main_butExit";
            this.Main_butExit.Size = new System.Drawing.Size(75, 23);
            this.Main_butExit.TabIndex = 9;
            this.Main_butExit.Text = "Thoát";
            this.Main_butExit.UseVisualStyleBackColor = true;
            this.Main_butExit.Click += new System.EventHandler(this.Main_butExit_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 296);
            this.ControlBox = false;
            this.Controls.Add(this.Main_butExit);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chk_Realtime);
            this.Controls.Add(this.chk_boot);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_chonfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSECAV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_chonfile;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chk_boot;
        private System.Windows.Forms.CheckBox chk_Realtime;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Main_butExit;
    }
}

