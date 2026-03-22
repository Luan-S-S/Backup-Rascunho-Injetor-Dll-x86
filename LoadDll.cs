using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Rascunho_Injetor_Dll
{

    public delegate IntPtr LoadMethod(IntPtr hProcess, string pathDll, out uint errorCode);

    internal static class LoadDll
    {

        public const string LOAD_LIBRARY_A = "LoadLibraryA";
        public const string LOAD_LIBRARY_W = "LoadLibraryW";
        public const string LDR_LOAD_DLL = "LdrLoadDll";


        [DllImport("DllLdrLoadDll.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr LdrLoadDll(IntPtr hProcess, string pathDll, out uint errorCode);

        [DllImport("DllLoadA.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr LoadDllA(IntPtr hProcess, string pathDll, out uint errorCode);

        [DllImport("DllLoadW.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr LoadDllW(IntPtr hProcess, string pathDll, out uint errorCode);

        public static Dictionary<string, LoadMethod> LoadMethods = new Dictionary<string, LoadMethod>() 
        {
            {LOAD_LIBRARY_A, LoadDllA }, 
            {LOAD_LIBRARY_W, LoadDllW},
            {LDR_LOAD_DLL, LdrLoadDll }
        };
    }

}
