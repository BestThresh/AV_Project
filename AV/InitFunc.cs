using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace AV
{
    static class InitFunc
    {
        [DllImport("Initation.dll", EntryPoint = "StartMonitoring",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void StartMonitoring();
        [DllImport("Initation.dll", EntryPoint = "StopMonitoring",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void StopMonitoring();

    }
}
