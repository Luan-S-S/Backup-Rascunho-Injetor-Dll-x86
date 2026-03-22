using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace Rascunho_Injetor_Dll
{
    class ControlProcess
    {
        public ControlProcess(string procName, Button btn, string msgOpen, string msgClose, Color colorOpen, Color colorCloser)
        {
            this.ProcName = procName;
            this.Btn = btn;
            this.MsgOpen = msgOpen;
            this.MsgClose = msgClose;
            this.ColorOpen = colorOpen;
            this.ColorClose = colorCloser;
        }

        public Process Proc { get; private set; }
        public string ProcName { get; set; }
        public Button Btn { get; set; }
        public string MsgOpen { get; set; }
        public string MsgClose { get; set; }
        public Color ColorOpen { get; set; }
        public Color ColorClose { get; set; }

        private Timer _timer = new Timer() { Interval = 300 };

        public void StartMonitor()
        {
            _timer.Tick += MonitorProcess;
            _timer.Start();
        }

        public void StopMonitor()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        private void MonitorProcess(object sender, EventArgs e)
        {
            Proc = Process.GetProcessesByName(ProcName).FirstOrDefault();
            if(Proc == null)
            {
                Btn.Text = MsgOpen;
                Btn.BackColor = ColorOpen;
                return;
            }
            Btn.Text = MsgClose;
            Btn.BackColor = ColorClose;
        }
        
    }
}
