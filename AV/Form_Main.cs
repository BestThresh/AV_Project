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
    public partial class Form_Main : Form
    {
        bool isSet = false;
        public Form_Main()
        {
            InitializeComponent();
             if (!isSet)
            {
                isSet = true;
                try
                {
                    InitFunction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }

        private void InitFunction()
        {
            InitFunc.StartMonitoring();
            
        }
        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Main_butExit_Click(object sender, EventArgs e)
        {
            isSet = false;
            InitFunc.StopMonitoring();
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (dialog_folder.SelectedPath == null)
                return;
            string select_folder = dialog_folder.SelectedPath;
            List<string> file_list = new List<string>();
            Stack<string> ScanStack = new Stack<string>();
            ScanStack.Clear();
            ScanStack.Push(select_folder);
            while (ScanStack.Count > 0)
            {
                select_folder = ScanStack.Pop();
                string[] FileInSelectFolder = Directory.GetFiles(select_folder);
                string[] FolderInSelectFolder = Directory.GetDirectories(select_folder);
                foreach (string s in FileInSelectFolder)
                {
                   // byte[] _tmp = Encoding.ASCII.GetBytes(s);
                    file_list.Add(s);
                }
                    
                foreach (string s in FolderInSelectFolder)
                    ScanStack.Push(s);
                                    
            }
            
            Form_scan form_scan = new Form_scan(file_list);
            form_scan.StartPosition = FormStartPosition.CenterParent;
            form_scan.ShowDialog();

        }

        private void btn_chonfile_Click(object sender, EventArgs e)
        {
            
            btn_OK.Enabled = true;
            if (dialog_folder.ShowDialog() == DialogResult.OK)
            {
                txt_chonfolder.Text = dialog_folder.SelectedPath.ToString();
            }
        }
    }
}
