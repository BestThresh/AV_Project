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

        private void Form_Result_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD

=======
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btn_xoa_all_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[2].Value = true;
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn restart","Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                ///

                ///
                this.Close();
            }
>>>>>>> refs/remotes/origin/master
        }
    }
}
