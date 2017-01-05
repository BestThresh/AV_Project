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
        private List<String> List_FileInfec = new List<string>();
        BackgroundWorker bw;
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

        

        private void Form_scan_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true; // ho tro bao cao tien do
            bw.WorkerSupportsCancellation = true; // cho phep dung tien trinh
            //su kien
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        

        private void but_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn hủy kết quả quét?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void but_view_Click(object sender, EventArgs e)
        {
            Form_Result fm = new Form_Result(List_FileInfec);
        }

        

        private void but_scan_Click(object sender, EventArgs e)
        {
            but_view.Hide();
            txt_tongso.Text = Scanf_list_FileDir.Count.ToString();
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = Scanf_list_FileDir.Count;
            bw.RunWorkerAsync();
            but_view.Show();
        }
        

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            for (int i = 0; i < progressBar1.Maximum; i++)
            {
                if (DoScanf(Scanf_list_FileDir[i]))
                     List_FileInfec.Add(Scanf_list_FileDir[i]);
                bw.ReportProgress(i);
                Thread.Sleep(1);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lab_CurFile.Text = Scanf_list_FileDir[e.ProgressPercentage];
            progressBar1.Value = e.ProgressPercentage + 1;
            txt_daquet.Text = (e.ProgressPercentage + 1).ToString();
            lab_percent.Text = ((double)(e.ProgressPercentage+1) / progressBar1.Maximum).ToString("0.##%");
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lab_CurFile.Text = "Hoàn thành!";
        }
    }
}
