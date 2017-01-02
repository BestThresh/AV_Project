using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
           
            
        }

        private void InitFunction()
        {
            InitFunc.StartMonitor();
        }
        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Main_butExit_Click(object sender, EventArgs e)
        {
            InitFunc.StopMonitor();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
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

        private void btn_chonfile_Click(object sender, EventArgs e)
        {
            dialog_folder.ShowDialog();
            btn_OK.Enabled = true;
            if (dialog_folder.ShowDialog() == DialogResult.OK)
            {
                txt_chonfolder.Text = dialog_folder.SelectedPath.ToString();
            }
        }
    }
}
