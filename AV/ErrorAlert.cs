using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AV
{
    class ErrorAlert
    {
        public static DialogResult ShowMessageOK(string mess)
        {
            return MessageBox.Show(mess, "Lỗi!", MessageBoxButtons.OK);
        }
        public static DialogResult ShowMessageConfirm(string mess)
        {
            return MessageBox.Show(mess,"Xác nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
            
    }
}
