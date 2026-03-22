namespace Rascunho_Injetor_Dll
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelecionarDll = new Button();
            txtDllSelecionada = new TextBox();
            comboBoxProcessos = new ComboBox();
            btnSelecionarProcesso = new Button();
            lbDll = new Label();
            lbProc = new Label();
            btnInjetar = new Button();
            lbAvisoRestricao = new Label();
            checkBoxLoadA = new CheckBox();
            checkBoxLoadW = new CheckBox();
            btnOpenCloseAssaultCube = new Button();
            lbArchiteDll = new Label();
            lbArchiteProc = new Label();
            rTxBLogs = new RichTextBox();
            btnAutoInjetar = new Button();
            checkBoxLDR = new CheckBox();
            SuspendLayout();
            // 
            // btnSelecionarDll
            // 
            btnSelecionarDll.Location = new Point(25, 25);
            btnSelecionarDll.Margin = new Padding(3, 1, 3, 1);
            btnSelecionarDll.Name = "btnSelecionarDll";
            btnSelecionarDll.Size = new Size(108, 23);
            btnSelecionarDll.TabIndex = 0;
            btnSelecionarDll.Text = "Selecionar Dll";
            btnSelecionarDll.UseVisualStyleBackColor = true;
            btnSelecionarDll.Click += btnSelecionarDll_Click;
            // 
            // txtDllSelecionada
            // 
            txtDllSelecionada.Enabled = false;
            txtDllSelecionada.Location = new Point(155, 29);
            txtDllSelecionada.Margin = new Padding(3, 1, 3, 1);
            txtDllSelecionada.Name = "txtDllSelecionada";
            txtDllSelecionada.Size = new Size(306, 23);
            txtDllSelecionada.TabIndex = 1;
            // 
            // comboBoxProcessos
            // 
            comboBoxProcessos.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProcessos.FormattingEnabled = true;
            comboBoxProcessos.Location = new Point(153, 79);
            comboBoxProcessos.Margin = new Padding(1);
            comboBoxProcessos.Name = "comboBoxProcessos";
            comboBoxProcessos.Size = new Size(309, 23);
            comboBoxProcessos.TabIndex = 2;
            comboBoxProcessos.DropDown += comboBoxProcessos_DropDown;
            // 
            // btnSelecionarProcesso
            // 
            btnSelecionarProcesso.Location = new Point(18, 79);
            btnSelecionarProcesso.Margin = new Padding(1);
            btnSelecionarProcesso.Name = "btnSelecionarProcesso";
            btnSelecionarProcesso.Size = new Size(125, 23);
            btnSelecionarProcesso.TabIndex = 3;
            btnSelecionarProcesso.Text = "Selecionar Processo";
            btnSelecionarProcesso.UseVisualStyleBackColor = true;
            btnSelecionarProcesso.Click += btnSelecionarProcesso_Click;
            // 
            // lbDll
            // 
            lbDll.AutoSize = true;
            lbDll.BackColor = Color.White;
            lbDll.ForeColor = Color.Green;
            lbDll.Location = new Point(251, 11);
            lbDll.Margin = new Padding(1, 0, 1, 0);
            lbDll.Name = "lbDll";
            lbDll.Size = new Size(0, 15);
            lbDll.TabIndex = 4;
            // 
            // lbProc
            // 
            lbProc.AutoSize = true;
            lbProc.BackColor = Color.White;
            lbProc.ForeColor = Color.Green;
            lbProc.Location = new Point(206, 63);
            lbProc.Margin = new Padding(1, 0, 1, 0);
            lbProc.Name = "lbProc";
            lbProc.Size = new Size(0, 15);
            lbProc.TabIndex = 5;
            // 
            // btnInjetar
            // 
            btnInjetar.Location = new Point(173, 167);
            btnInjetar.Margin = new Padding(1);
            btnInjetar.Name = "btnInjetar";
            btnInjetar.Size = new Size(78, 26);
            btnInjetar.TabIndex = 6;
            btnInjetar.Text = "Injetar";
            btnInjetar.UseVisualStyleBackColor = true;
            btnInjetar.Click += btnInjetar_Click;
            // 
            // lbAvisoRestricao
            // 
            lbAvisoRestricao.AutoSize = true;
            lbAvisoRestricao.Location = new Point(188, 215);
            lbAvisoRestricao.Margin = new Padding(1, 0, 1, 0);
            lbAvisoRestricao.Name = "lbAvisoRestricao";
            lbAvisoRestricao.Size = new Size(170, 15);
            lbAvisoRestricao.TabIndex = 7;
            lbAvisoRestricao.Text = "Só Funciona para Assault Cube";
            // 
            // checkBoxLoadA
            // 
            checkBoxLoadA.AutoSize = true;
            checkBoxLoadA.Location = new Point(25, 127);
            checkBoxLoadA.Margin = new Padding(1);
            checkBoxLoadA.Name = "checkBoxLoadA";
            checkBoxLoadA.Size = new Size(96, 19);
            checkBoxLoadA.TabIndex = 8;
            checkBoxLoadA.Text = "LoadLibraryA";
            checkBoxLoadA.TextAlign = ContentAlignment.TopLeft;
            checkBoxLoadA.UseVisualStyleBackColor = true;
            checkBoxLoadA.CheckedChanged += checkBoxs_CheckedChanged;
            // 
            // checkBoxLoadW
            //
            checkBoxLoadW.AutoSize = true;
            checkBoxLoadW.Location = new Point(25, 166);
            checkBoxLoadW.Margin = new Padding(1);
            checkBoxLoadW.Name = "checkBoxLoadW";
            checkBoxLoadW.Size = new Size(99, 19);
            checkBoxLoadW.TabIndex = 9;
            checkBoxLoadW.Text = "LoadLibraryW";
            checkBoxLoadW.UseVisualStyleBackColor = true;
            checkBoxLoadW.CheckedChanged += checkBoxs_CheckedChanged;
            // 
            // checkBoxLDR
            // 
            checkBoxLDR.AutoSize = true;
            checkBoxLDR.Location = new Point(25, 202);
            checkBoxLDR.Name = "checkBoxLDR";
            checkBoxLDR.Size = new Size(89, 19);
            checkBoxLDR.TabIndex = 15;
            checkBoxLDR.Text = "LdrLoadDLL";
            checkBoxLDR.UseVisualStyleBackColor = true;
            checkBoxLDR.CheckedChanged += checkBoxs_CheckedChanged;
            // 
            // btnOpenCloseAssaultCube
            // 
            btnOpenCloseAssaultCube.Location = new Point(188, 259);
            btnOpenCloseAssaultCube.Name = "btnOpenCloseAssaultCube";
            btnOpenCloseAssaultCube.Size = new Size(186, 23);
            btnOpenCloseAssaultCube.TabIndex = 10;
            btnOpenCloseAssaultCube.UseVisualStyleBackColor = true;
            btnOpenCloseAssaultCube.Click += btnOpenCloseAssaultCube_Click;
            // 
            // lbArchiteDll
            // 
            lbArchiteDll.AutoSize = true;
            lbArchiteDll.Location = new Point(481, 33);
            lbArchiteDll.Name = "lbArchiteDll";
            lbArchiteDll.Size = new Size(0, 15);
            lbArchiteDll.TabIndex = 11;
            // 
            // lbArchiteProc
            // 
            lbArchiteProc.AutoSize = true;
            lbArchiteProc.Location = new Point(479, 86);
            lbArchiteProc.Name = "lbArchiteProc";
            lbArchiteProc.Size = new Size(0, 15);
            lbArchiteProc.TabIndex = 12;
            // 
            // rTxBLogs
            // 
            rTxBLogs.Location = new Point(10, 288);
            rTxBLogs.Name = "rTxBLogs";
            rTxBLogs.ReadOnly = true;
            rTxBLogs.Size = new Size(532, 170);
            rTxBLogs.TabIndex = 13;
            rTxBLogs.Text = "";
            // 
            // btnAutoInjetar
            // 
            btnAutoInjetar.Location = new Point(305, 166);
            btnAutoInjetar.Name = "btnAutoInjetar";
            btnAutoInjetar.Size = new Size(91, 27);
            btnAutoInjetar.TabIndex = 14;
            btnAutoInjetar.Text = "Auto Injetar";
            btnAutoInjetar.UseVisualStyleBackColor = true;
            btnAutoInjetar.Click += btnAutoInjetar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = SystemColors.ButtonFace;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(564, 470);
            Controls.Add(checkBoxLDR);
            Controls.Add(btnAutoInjetar);
            Controls.Add(rTxBLogs);
            Controls.Add(lbArchiteProc);
            Controls.Add(lbArchiteDll);
            Controls.Add(btnOpenCloseAssaultCube);
            Controls.Add(checkBoxLoadW);
            Controls.Add(checkBoxLoadA);
            Controls.Add(lbAvisoRestricao);
            Controls.Add(btnInjetar);
            Controls.Add(lbProc);
            Controls.Add(lbDll);
            Controls.Add(btnSelecionarProcesso);
            Controls.Add(comboBoxProcessos);
            Controls.Add(txtDllSelecionada);
            Controls.Add(btnSelecionarDll);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 1, 3, 1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSelecionarDll;
        private TextBox txtDllSelecionada;
        private ComboBox comboBoxProcessos;
        private Button btnSelecionarProcesso;
        private Label lbDll;
        private Label lbProc;
        private Button btnInjetar;
        private Label lbAvisoRestricao;
        private CheckBox checkBoxLoadA;
        private CheckBox checkBoxLoadW;
        private Button btnOpenCloseAssaultCube;
        private Label lbArchiteDll;
        private Label lbArchiteProc;
        private RichTextBox rTxBLogs;
        private Button btnAutoInjetar;
        private CheckBox checkBoxLDR;
    }
}
