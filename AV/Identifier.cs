using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AV
{
    class Identifier
    {
        public enum ReconResult
            {
                PeFile=1,
                Infected=2,
                System=3,
                Another=0
            }
        private bool isInfectPE(string file_path)
        {
            return true;
        }
        private bool isSystemFile(string file_path)
        {
            if (File.GetAttributes(file_path).HasFlag(FileAttributes.System) &&
                (file_path.Contains("System32") || file_path.Contains("SysWOW64")) &&
                (file_path.Contains("Windows"))
                )
                return true;
                
            return false;
        }
        private bool isPE(string file_path)
        {
            FileStream reader = File.OpenRead(file_path);
            byte[] header = new byte[2];
            reader.Read(header, 0, 2);
            if (header[0] == 0x4d && header[1]== 0x5a )
                return true;
            return false;
        }

        public static ReconResult ReconFile(string file_path)
        {
            return ReconResult.Another;
        }
    }
}
