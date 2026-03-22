using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rascunho_Injetor_Dll
{
    class Injetor
    {
        public Injetor(int pid, string pathDll, RichTextBox rTxBLogs)
        {
            this.RTxBLogs = rTxBLogs; // Esta atribuição é necessario primeira do que a do PID e do PathDll por causa co CheckSucess
            Proc = Process.GetProcessById(pid);
            PID = (uint)pid;
            PathDll = pathDll;

            ArchCurr = GetPeArchitecture(Process.GetCurrentProcess().MainModule.FileName); //Pegando a arquitetura do meu proprio processo
            ArchDll = GetPeArchitecture(PathDll); //Pegando arquitetura da dll
            ArchProc = GetPeArchitecture(Proc.MainModule.FileName); //Pegando arquitetura do processo alvo

            CheckArchitetures(ArchCurr, ArchDll, ArchProc); //Verificando se as arquiteturas são compativeis
        }     

        public string PathDll {
            get {
                return _pathDll;
            }private set {
                CheckSucess(!string.IsNullOrEmpty(value), $"[*] -> Caminho da Dll     :      {value}\n", "Dll Selecionada Invalida!");
                _pathDll = value;
            } }
        public uint PID { 
            get {
                return _pid;
            }private set {
                CheckSucess(value != 0, $"[*] -> Processo Alvo        :      {Proc.ProcessName}  (PID: {Proc.Id})", "Processo não Selecionado");
                _pid = value;
            } }
        public IntPtr ModuleProc { 
            get {
                return _moduleProc;
            } private set {
                CheckSucess(value != IntPtr.Zero, "[+] -> Handle do processo obtida com sucesso: 0x" + value.ToString("X"), "Falha ao obter Handle de: " + Proc.ProcessName);
                _moduleProc = value;
            } }
        public Process Proc { get; private set; }
        public IntPtr ModuleDLL { get; private set; }
        public RichTextBox RTxBLogs { get; set; }
        public string ArchCurr { get; private set; }
        public string ArchDll { get; private set; }
        public string ArchProc { get; private set; }

        private string _pathDll;
        private uint  _pid;
        private IntPtr _moduleProc;

        public static string GetPeArchitecture(string path) //Manter esta função
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // 1. Offset para o cabeçalho PE (está no offset 0x3C do DOS header)
                fs.Seek(0x3C, SeekOrigin.Begin);
                int peOffset = br.ReadInt32();

                // 2. Ir até o cabeçalho PE
                fs.Seek(peOffset, SeekOrigin.Begin);
                uint peHead = br.ReadUInt32();

                if (peHead != 0x4550)// "PE\0\0"
                {
                    return "Arquivo não é um PE válido.";
                }

                // 3. Ler Machine (2 bytes)
                ushort arch = br.ReadUInt16();

                switch(arch)
                {
                    case 0x014c:
                        return "x86";
                    case 0x8664:
                        return "x64";
                    case 0xAA64:
                        return "ARM64";
                }

                return "Arquitetura Desconhecida";

            }
        } 
        public void CheckArchitetures(string archCurr, string archDll, string archProc)
        {
            Form1.AppendTextRichBox(RTxBLogs, $"[*] -> Arquitetura Proc.  :       {archProc}", archProc == archCurr ? Color.Green : Color.Red);
            Form1.AppendTextRichBox(RTxBLogs, $"[*] -> Arquitetura DLL.   :       {archDll}", archDll == archCurr ? Color.Green : Color.Red);

            CheckSucess(archDll == archCurr && archProc == archCurr, "[*] -> Arquiteturas Compativeis com a injeção\n", "Arquitetura da dll Não Permitida para este injetor");
        }
        public void CheckSucess(bool result, string msgSucess, string msgFailed)
        {
            if (!result) throw new InvalidOperationException(msgFailed);
            Form1.AppendTextRichBox(RTxBLogs, msgSucess, Color.Green);
        }
        private bool IsModuleLoaded_ProcessModules(string dllName)// Função para verificar se a dll esta nos modulos do processo
        {
            // Tentar verificar se da para usar o modulo da dll direto ao invez do nome 
            dllName = dllName.ToLowerInvariant();

            foreach (ProcessModule mod in Proc.Modules)
            {
                if (mod.ModuleName.ToLowerInvariant() == dllName) return true;
            }
            return false;
        }
        public bool Inject(string typeLoadLibrary)
        {
            CheckSucess(LoadDll.LoadMethods.TryGetValue(typeLoadLibrary, out LoadMethod loadMethod), $"[*] -> Type Load API       :       {typeLoadLibrary}\n", "Nome da API de injeção Incorreto!");

            ModuleProc = Kernel32.OpenProcess(Kernel32.PROCESS_CREATE_THREAD |
            Kernel32.PROCESS_QUERY_INFORMATION |
            Kernel32.PROCESS_VM_OPERATION |
            Kernel32.PROCESS_VM_READ |
            Kernel32.PROCESS_VM_WRITE, false, PID);

            ModuleDLL =  loadMethod(ModuleProc, PathDll, out uint errorCode);

            ErrosInject errors = new ErrosInject(typeLoadLibrary);

            errors.ListErrors.ForEach(err => CheckSucess((uint)err.errorCode != errorCode, "[+] -> " + err.MsgSucess, err.Description));

            Kernel32.CloseHandle(ModuleProc);

            return IsModuleLoaded_ProcessModules(Path.GetFileName(PathDll)) && ModuleDLL != IntPtr.Zero && errorCode == 0;
        }
    }
}


