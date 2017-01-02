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
            InitFunc.StopMonitoring();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
