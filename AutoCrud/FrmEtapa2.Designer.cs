namespace AutoCrud
{
    partial class FrmEtapa2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgTabelas = new System.Windows.Forms.DataGridView();
            this.Tabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selecionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.btnOpcoesAvancadas = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBll = new System.Windows.Forms.CheckBox();
            this.chkDal = new System.Windows.Forms.CheckBox();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.btnGerar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTabelas)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgTabelas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 270);
            this.panel1.TabIndex = 0;
            // 
            // dgTabelas
            // 
            this.dgTabelas.AllowUserToAddRows = false;
            this.dgTabelas.AllowUserToDeleteRows = false;
            this.dgTabelas.AllowUserToResizeColumns = false;
            this.dgTabelas.AllowUserToResizeRows = false;
            this.dgTabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTabelas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tabela,
            this.Selecionar});
            this.dgTabelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTabelas.Location = new System.Drawing.Point(0, 0);
            this.dgTabelas.Name = "dgTabelas";
            this.dgTabelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTabelas.Size = new System.Drawing.Size(592, 270);
            this.dgTabelas.TabIndex = 1;
            // 
            // Tabela
            // 
            this.Tabela.HeaderText = "Tabela";
            this.Tabela.Name = "Tabela";
            this.Tabela.ReadOnly = true;
            this.Tabela.Width = 450;
            // 
            // Selecionar
            // 
            this.Selecionar.HeaderText = "Selecionar";
            this.Selecionar.Name = "Selecionar";
            this.Selecionar.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtNameSpace);
            this.panel2.Controls.Add(this.btnOpcoesAvancadas);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnGerar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 113);
            this.panel2.TabIndex = 1;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameSpace.Location = new System.Drawing.Point(12, 6);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(347, 26);
            this.txtNameSpace.TabIndex = 5;
            // 
            // btnOpcoesAvancadas
            // 
            this.btnOpcoesAvancadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcoesAvancadas.Location = new System.Drawing.Point(350, 38);
            this.btnOpcoesAvancadas.Name = "btnOpcoesAvancadas";
            this.btnOpcoesAvancadas.Size = new System.Drawing.Size(121, 50);
            this.btnOpcoesAvancadas.TabIndex = 3;
            this.btnOpcoesAvancadas.Text = "Opções Avançadas";
            this.btnOpcoesAvancadas.UseVisualStyleBackColor = true;
            this.btnOpcoesAvancadas.Click += new System.EventHandler(this.btnOpcoesAvancadas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBll);
            this.groupBox1.Controls.Add(this.chkDal);
            this.groupBox1.Controls.Add(this.chkInfo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 56);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções de Geração";
            // 
            // chkBll
            // 
            this.chkBll.AutoSize = true;
            this.chkBll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBll.Location = new System.Drawing.Point(137, 25);
            this.chkBll.Name = "chkBll";
            this.chkBll.Size = new System.Drawing.Size(45, 24);
            this.chkBll.TabIndex = 2;
            this.chkBll.Text = "Bll";
            this.chkBll.UseVisualStyleBackColor = true;
            // 
            // chkDal
            // 
            this.chkDal.AutoSize = true;
            this.chkDal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDal.Location = new System.Drawing.Point(73, 26);
            this.chkDal.Name = "chkDal";
            this.chkDal.Size = new System.Drawing.Size(52, 24);
            this.chkDal.TabIndex = 1;
            this.chkDal.Text = "Dal";
            this.chkDal.UseVisualStyleBackColor = true;
            // 
            // chkInfo
            // 
            this.chkInfo.AutoSize = true;
            this.chkInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInfo.Location = new System.Drawing.Point(6, 25);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Size = new System.Drawing.Size(56, 24);
            this.chkInfo.TabIndex = 0;
            this.chkInfo.Text = "Info";
            this.chkInfo.UseVisualStyleBackColor = true;
            // 
            // btnGerar
            // 
            this.btnGerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.Location = new System.Drawing.Point(223, 38);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(121, 50);
            this.btnGerar.TabIndex = 3;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // FrmEtapa2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(592, 383);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(608, 503);
            this.MinimizeBox = false;
            this.Name = "FrmEtapa2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEtapa2";
            this.Load += new System.EventHandler(this.FrmEtapa2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTabelas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgTabelas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBll;
        private System.Windows.Forms.CheckBox chkDal;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tabela;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selecionar;
        private System.Windows.Forms.Button btnOpcoesAvancadas;
        private System.Windows.Forms.TextBox txtNameSpace;
    }
}