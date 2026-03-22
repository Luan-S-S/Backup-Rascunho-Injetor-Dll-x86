using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rascunho_Injetor_Dll
{
    static internal class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hModule);

        public const uint PROCESS_CREATE_THREAD = 0x0002,
                          PROCESS_QUERY_INFORMATION = 0x0400,
                          PROCESS_VM_OPERATION = 0x0008,
                          PROCESS_VM_WRITE = 0x0020,
                          PROCESS_VM_READ = 0x0010;

    }
}
