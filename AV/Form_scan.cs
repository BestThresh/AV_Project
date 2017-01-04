using libyaraNET;
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
using System.Threading;
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
        private List<String> List_FileInfec;
        public Form_scan(List<String> __Scan_ListString_FileDir)
        {
            Scanf_list_FileDir = __Scan_ListString_FileDir;
            InitializeComponent();
            //using (var compiler = new Compiler())
            //{
            //    String[] Scan_RuleFile = Directory.GetFiles(".//Rules");
            //    foreach (String rulefile in Scan_RuleFile)
            //       compiler.AddRuleFile(".//Rules//Rule1.yara");

            //    Scan_rule = compiler.GetRules();
            //}
        }
        
        private bool DoScanf(String Scan_String_FileDir)
        {
           
            return true; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_scan_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn hủy kết quả quét?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.Close();
            }
        }

        private void but_view_Click(object sender, EventArgs e)
        {
            Form_Result fm = new Form_Result(List_FileInfec);
        }

        private void progressBar1_RegionChanged(object sender, EventArgs e)
        {
           
        }

        private void but_scan_Click(object sender, EventArgs e)
        {
            txt_tongso.Text = Scanf_list_FileDir.Count.ToString();
            but_view.Hide();
            int SoFileDaQuet = 0 ;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Scanf_list_FileDir.Count;
            progressBar1.Step = 1;
            List_FileInfec = new List<string>();
            progressBar1.Value = 0;
            while (progressBar1.Value < progressBar1.Maximum)
            {
                if (DoScanf(Scanf_list_FileDir[SoFileDaQuet]))
                    List_FileInfec.Add(Scanf_list_FileDir[SoFileDaQuet]);
                SoFileDaQuet++;
                lab_percent.Text = ((double)(SoFileDaQuet) / progressBar1.Maximum).ToString("0.##%");
                txt_daquet.Text = SoFileDaQuet.ToString();
                lab_CurFile.Text = Scanf_list_FileDir[progressBar1.Value];
                progressBar1.PerformStep();
            }
            lab_CurFile.Text = "Hoàn thành!";
            but_view.Show();
        }
    }
}
