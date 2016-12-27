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
    public partial class Form_Result : Form
    {
        public Form_Result()
        {
            InitializeComponent();
        }
        private List<String> Result_List_File;
        public Form_Result(List<String> __Result_List_File)
        {
            Result_List_File = __Result_List_File;
            InitializeComponent();
        }
        public void Add_To_Log()
        {
            File.WriteAllLines("./log.txt", Result_List_File);

        }
    }
}
