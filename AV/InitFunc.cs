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
        [DllImport("Initation.dll", EntryPoint = "StartMonitor",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void StartMonitor();
        [DllImport("Initation.dll", EntryPoint = "StopMonitor",
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void StopMonitor();

    }
}
