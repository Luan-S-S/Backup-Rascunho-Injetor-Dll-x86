using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Rascunho_Injetor_Dll.ErrosInject;

namespace Rascunho_Injetor_Dll
{
    internal class ErrosInject
    {
        public enum ErrorCode : uint
        {
            ERROR_INVALID_HANDLE = 0x6, //Erro handle do processo invalida
            ERROR_INVALID_PARAMETER = 0x57, //Path da dll null ou invalida
            ERROR_REMOTE_PROCESS_WRITE_PATHDLL_FAILED = 0xA, //Erro ao escrever pathDll  no processo
            ERROR_REMOTE_PROCESS_WRITE_UNICODE_STRING_FAILED = 0xB, //Erro ao escrever UNICODE_STRING no processo
            ERROR_REMOTE_PROCESS_WRITE_LDRSTRUCT_FAILED = 0xC, //Erro ao escrever estrutura LDR no processo
            ERROR_REMOTE_PROCESS_WRITE_REMOTE_LDRLOADDLL_FAILED = 0xD, //Erro ao escrever Função remote_LDR no processo
            ERROR_FUNCTION_ADDRESS_NOT_FOUND = 0xE, // Erro ao encontrar endereço da função LDR nativa no processo
            ERROR_REMOTE_THREAD_CREATE_FAILED = 0xF, // Erro ao criar Thread remota de injeção
            ERROR_MEMORY_RELEASE_FAILED = 0x10, // Erro ao liberar Memorias usadas
            ERROR_GET_EXIT_CODE_FAILED = 0x11, // Erro ao obter exitCode da injeção
            ERROR_LOADLIBRARY_FAILED = 0x12 // A API de injeção falhou 
        }
        public struct ErrorCodeStruct
        {
            public ErrorCode errorCode;
            public string Description;
            public string MsgSucess;
        }

        static ErrosInject()
        {
            InicializarEstruturas();
            InitializeLists();
        }
        public ErrosInject(string typeLoadLibrary)
        {
            this.ListErrors = typeLoadLibrary == LoadDll.LDR_LOAD_DLL ? LoadLdr : LoadAW;
        }
        public List<ErrorCodeStruct> ListErrors { get; private set; }

        private static List<ErrorCodeStruct> LoadAW, LoadLdr;
        private static ErrorCodeStruct handle, pathDll, writePathDll, writeUnicodeString, writeLDRstruct, writeRemoteLDRloadDll,
            functionAddress, threadCreate, memoryRelease, getExitCode, loadAPI;
        private static void InicializarEstruturas()
        {
            handle = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_INVALID_HANDLE,
                Description = "Falha ao obter handle do processo",
            };

            pathDll = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_INVALID_PARAMETER,
                Description = "Dll Selecionada Invalida"
            };

            writePathDll = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_REMOTE_PROCESS_WRITE_PATHDLL_FAILED,
                Description = "Falha ao escrever o caminho da Dll no processo",
                MsgSucess = "Caminho da Dll escrito no processo!"
            };

            writeUnicodeString = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_REMOTE_PROCESS_WRITE_UNICODE_STRING_FAILED,
                Description = "Falha ao escrever UNICODE_STRING no processo",
                MsgSucess = "UNICODE_STRING escrita no processo!"
            };

            writeLDRstruct = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_REMOTE_PROCESS_WRITE_LDRSTRUCT_FAILED,
                Description = "Falha ao escrever estrutura LDR no processo",
                MsgSucess = "Estrutura LDR escrita no processo!"
            };

            writeRemoteLDRloadDll = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_REMOTE_PROCESS_WRITE_REMOTE_LDRLOADDLL_FAILED,
                Description = "Falha ao escrever Função 'remote_LDR' no processo",
                MsgSucess = "Função 'remote_LDR' escrita no processo!"
            };

            functionAddress = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_FUNCTION_ADDRESS_NOT_FOUND,
                Description = "Falha ao localizar endereço da função de injeção nativa do processo",
                MsgSucess = "Função de injeção nativa encontrada com sucesso!"
            };

            threadCreate = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_REMOTE_THREAD_CREATE_FAILED,
                Description = "Falha ao criar Thread remota de injeção",
                MsgSucess = "Thread remota de injeção criada com sucesso!"
            };

            memoryRelease = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_MEMORY_RELEASE_FAILED,
                Description = "Falha ao liberar Endereços usados para injeção",
                MsgSucess = "Endereços liberados com sucesso!"
            };

            getExitCode = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_GET_EXIT_CODE_FAILED,
                Description = "Falha ao obter 'exitCode' da injeção",
                MsgSucess = "'exitCode' obtido com sucesso!"
            };

            loadAPI = new ErrorCodeStruct
            {
                errorCode = ErrorCode.ERROR_LOADLIBRARY_FAILED,
                Description = "A API de injeção falhou",
                MsgSucess = "A API de injeção executou com sucesso!"
            };
        }
        private static void InitializeLists()
        {
            LoadAW = new List<ErrorCodeStruct>(){/*handle,pathDll,*/writePathDll,functionAddress,threadCreate, loadAPI, getExitCode, memoryRelease};

            LoadLdr = new List<ErrorCodeStruct>(){/*handle,pathDll,*/writePathDll, writeUnicodeString, writeLDRstruct, functionAddress, writeRemoteLDRloadDll,
            threadCreate, loadAPI, getExitCode, memoryRelease};
        }
    }
}
