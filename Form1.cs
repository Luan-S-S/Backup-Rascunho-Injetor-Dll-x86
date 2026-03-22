using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace Rascunho_Injetor_Dll
{

    public partial class Form1 : Form
    {

        int PID;
        string pathDll;
        string typeLoad;
        ControlProcess ac;
        Injetor injetor;

        public Form1()
        {

            InitializeComponent();
            this.Text = GenerateRandomName();
            checkBoxLoadA.Checked = true;
            typeLoad = LoadDll.LOAD_LIBRARY_A;
            ac = new ControlProcess("ac_client", this.btnOpenCloseAssaultCube, "Abrir AssaultCube", "Fechar AssaultCube", Color.Green, Color.Red);
            ac.StartMonitor();

        }
        private void btnInjetar_Click(object sender, EventArgs e)
        {
            rTxBLogs.Clear();
            bool injectSucess = false;
            try
            {
                injetor = new Injetor(PID, pathDll, this.rTxBLogs);
                injectSucess = injetor.Inject(typeLoad);
 
            }
            catch (InvalidOperationException ex)
            {
                AppendTextRichBox(this.rTxBLogs, "[-] -> " + ex.Message, Color.Red);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Color colorMsg = injectSucess ? Color.Blue : Color.Red;
                string msgResult = injectSucess ?
                    $" ================ > Dll Injetada com Sucesso! -> (Modulo: 0x{injetor.ModuleDLL.ToString("X")})" :
                    " ----------------> Falha ao injetar Dll <-------------------";
                AppendTextRichBox(this.rTxBLogs, msgResult, colorMsg);
                ResetItens();
            }

        }

        private void btnSelecionarDll_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione uma DLL";
                openFileDialog.Filter = "Bibliotecas DLL (*.dll)|*.dll";
                openFileDialog.Multiselect = false; // permite só uma dll


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathDll = openFileDialog.FileName;


                    string dllSelecionada = Path.GetFileName(pathDll);

                    txtDllSelecionada.Text = dllSelecionada;

                    lbDll.Text = "Dll Selecionada";
                    lbArchiteDll.Text = "Arch: " + Injetor.GetPeArchitecture(pathDll);
                }
            }
        }  //Não vou mexer

        private void btnSelecionarProcesso_Click(object sender, EventArgs e)
        {
            if (comboBoxProcessos.SelectedItem is Process processoSelecionado)
            {

                if (processoSelecionado.ProcessName != "ac_client")
                {
                    lbProc.ForeColor = Color.Red;
                    lbProc.Text = "Processo Invalido";
                    PID = 0;
                    return;
                }

                PID = processoSelecionado.Id;
                lbProc.ForeColor = Color.Green;
                lbProc.Text = "Processo Selecionado";
                lbArchiteProc.Text = "Arch: " + Injetor.GetPeArchitecture(processoSelecionado.MainModule.FileName);

            }
        } //Não vou mexer

        private void comboBoxProcessos_DropDown(object sender, EventArgs e)
        {
            CarregarListaProcessos();
            PID = 0;
            lbProc.Text = "";
        } //Não vou mexer

        private void btnOpenCloseAssaultCube_Click(object sender, EventArgs e)
        {
            if (ac.Proc != null)
            {
                ac.Proc.CloseMainWindow();
                return;
            }
            Process.Start(@"C:\Projetos Cheats\Rascunho Injetor Dll\Open AssaultCube.bat");
        } //Não vou mexer

        private void checkBoxs_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if (!check.Checked) return;

            check.AutoCheck = false;

            if (check == checkBoxLoadA)
            {
                typeLoad = LoadDll.LOAD_LIBRARY_A;
                InvalidateChecksBoxs(checkBoxLoadW, checkBoxLDR);
                return;
            }
            if (check == checkBoxLoadW)
            {
                typeLoad = LoadDll.LOAD_LIBRARY_W;
                InvalidateChecksBoxs(checkBoxLoadA, checkBoxLDR);
                return;
            }

            typeLoad = LoadDll.LDR_LOAD_DLL;
            InvalidateChecksBoxs(checkBoxLoadA, checkBoxLoadW);
        }

        private void btnAutoInjetar_Click(object sender, EventArgs e)
        {

        }

    }
}

