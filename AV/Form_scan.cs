<<<<<<< HEAD
﻿using AV;
=======
﻿using libyaraNET;
>>>>>>> refs/remotes/origin/master
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AV
{
    public partial class Form_scan : Form
    {
        public Form_scan()
        {
            InitializeComponent();
        }
        private Rules Scan_rule = null;
        private List<String> Scanf_list_FileDir;
        private List<String> _list_FileInfec;
        public Form_scan(List<String> __Scan_ListString_FileDir)
        {
            Scanf_list_FileDir = __Scan_ListString_FileDir;
            InitializeComponent();
            using (var compiler = new Compiler())
            {
                String[] Scan_RuleFile = Directory.GetFiles(".//Rules");
                foreach (String rulefile in Scan_RuleFile)
                   compiler.AddRuleFile(".//Rules//Rule1.yara");

                Scan_rule = compiler.GetRules();
            }
        }
<<<<<<< HEAD

=======
        
>>>>>>> refs/remotes/origin/master
        private bool DoScanf(String Scan_String_FileDir)
        {
            return true; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_scan_Load(object sender, EventArgs e)
        {
            int TongSo = Scanf_list_FileDir.Count;
            int SoFileDaQuet = 0;
            txt_tongso.Text = TongSo.ToString();
            but_view.Hide();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            for (progressBar1.Value=0; progressBar1.Value < 100; progressBar1.PerformStep())
            {
                while (SoFileDaQuet % (TongSo / 100 )==0) {
                    if (DoScanf(Scanf_list_FileDir[SoFileDaQuet]))
                    {
                        SoFileDaQuet++;
                        if (progressBar1.Value == 99 && SoFileDaQuet % (TongSo / 100) == TongSo % 100)
                            break;
                    }
                    else { }
                }
                txt_daquet.Text = SoFileDaQuet.ToString();
            }
            but_view.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void but_view_Click(object sender, EventArgs e)
        {
            Form_Result fm = new Form_Result(_list_FileInfec);
        }
    }
}
