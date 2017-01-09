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

        }
        
        private bool DoScanf(String Scan_String_FileDir)
        {
           Scanner __scanner = new Scanner() ;
           List<ScanResult> list_SR= __scanner.ScanFile(Scan_String_FileDir, Scan_rule);
            return true;
        }

        
        private void Load_Rules()
        {
            using (var ctx = new YaraContext())
            {
                using (var compiler = new Compiler())
                {
                    String[] Scan_RuleFile = Directory.GetFiles(Application.StartupPath+ "\\Rules");
                    if (Scan_RuleFile == null)
                    {
                        ErrorAlert.ShowMessageOK("Chưa có dữ liệu mã độc, ấn cập nhật để download dữ liệu mã độc");
                        this.Close();
                        return;
                    }
                    bool Have_rule = false;
                    foreach (String rulefile in Scan_RuleFile)
                        try
                        {
                            if (Path.GetExtension(rulefile) == ".yar" || Path.GetExtension(rulefile) == ".yara")
                            {
                                Have_rule = true;
                                compiler.AddRuleFile(rulefile);
                            }
                        }
                        catch
                        {

                        }
                    if (!Have_rule)
                    {
                        ErrorAlert.ShowMessageOK("Chưa có dữ liệu mã độc, ấn cập nhật để download dữ liệu mã độc");
                        this.Close();
                        return;
                    }
                    try
                    {
                        Scan_rule = compiler.GetRules();
                        MessageBox.Show("Compile Rule ok");
                    }
                    catch (Exception e)
                    {
                        ErrorAlert.ShowMessageOK(
                            String.Format("Nạp dữ liệu mã độc lỗi :{0}!", e.Message));
                        this.Close();
                        return;
                    }


                }

            }
        }
        private void Form_scan_Load(object sender, EventArgs e)
        {
            Load_Rules();
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
            
            if (ErrorAlert.ShowMessageConfirm("Bạn muốn hủy kết quả quét?") == DialogResult.Yes)
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
