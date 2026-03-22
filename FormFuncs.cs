using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rascunho_Injetor_Dll
{
    public partial class Form1
    {
        private string GenerateRandomName()
        {
            string numers = "0123456789";
            string low = "abcdefghijklmnopkrstuvwxyz";
            string upp = low.ToUpper();

            string fullString = String.Concat(numers, low, upp);

            Random random = new Random();

            int tamName = random.Next(6, fullString.Length);

            char[] result = new char[tamName];

            for (int i = 0; i < tamName; i++)
            {
                result[i] = fullString[random.Next(fullString.Length)];
            }

            return new string(result);
        } // Não vou mexer
        private void CarregarListaProcessos()
        {
            var processos = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();

            comboBoxProcessos.DisplayMember = "ProcessName";
            comboBoxProcessos.ValueMember = "Id";
            comboBoxProcessos.DataSource = processos;
        } // Não vou mexer
        public static void AppendTextRichBox(RichTextBox rtb, string text, Color color)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            string timestamp = $"[{DateTime.Now:HH:mm:ss}] ";
            rtb.AppendText(timestamp);

            rtb.SelectionColor = color;

            rtb.AppendText(text + "\n");

            rtb.SelectionColor = rtb.ForeColor;

            rtb.ScrollToCaret();
        }//Não vou mexer
        private void ResetItens()
        {
            comboBoxProcessos.SelectedIndex = -1;
            lbProc.Text = "";
            PID = 0;
            lbArchiteProc.Text = "";

            txtDllSelecionada.Text = "";
            lbDll.Text = "";
            pathDll = "";
            lbArchiteDll.Text = "";

        } //Não vou mexer
        private void InvalidateCheckBox(CheckBox checkbox)
        {
            checkbox.Checked = false;
            checkbox.AutoCheck = true;
        }
        private void InvalidateChecksBoxs(CheckBox checkBox1, CheckBox checkBox2)
        {
            InvalidateCheckBox(checkBox1);
            InvalidateCheckBox(checkBox2);
        }
    }
}
