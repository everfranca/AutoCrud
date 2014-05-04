namespace AutoCrud
{
    partial class FrmOpçõesAvancadas
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
            this.rdbStoredProcedure = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbCommandText = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRedefinir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.rdbTabelaSolution = new System.Windows.Forms.RadioButton();
            this.rdbSeparaProjetos = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbApenasArquivo = new System.Windows.Forms.RadioButton();
            this.rdbNenhumFrontEnd = new System.Windows.Forms.RadioButton();
            this.rdbGerarPages = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbGerarForms = new System.Windows.Forms.RadioButton();
            this.rdbNenhumTransacao = new System.Windows.Forms.RadioButton();
            this.rdbDbTransaction = new System.Windows.Forms.RadioButton();
            this.rdbScopeTransaction = new System.Windows.Forms.RadioButton();
            this.GpbTransacao = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbNaoUtilizarNucleo = new System.Windows.Forms.RadioButton();
            this.rdbUtilizarNucleo = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdbNaoCriarCollection = new System.Windows.Forms.RadioButton();
            this.rdbCriarCollection = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GpbTransacao.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbStoredProcedure
            // 
            this.rdbStoredProcedure.AutoSize = true;
            this.rdbStoredProcedure.Checked = true;
            this.rdbStoredProcedure.Location = new System.Drawing.Point(6, 30);
            this.rdbStoredProcedure.Name = "rdbStoredProcedure";
            this.rdbStoredProcedure.Size = new System.Drawing.Size(142, 17);
            this.rdbStoredProcedure.TabIndex = 3;
            this.rdbStoredProcedure.TabStop = true;
            this.rdbStoredProcedure.Text = "Utilizar Stored Procedure";
            this.rdbStoredProcedure.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbCommandText);
            this.groupBox3.Controls.Add(this.rdbStoredProcedure);
            this.groupBox3.Location = new System.Drawing.Point(171, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 100);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acesso a Dados - Dal";
            // 
            // rdbCommandText
            // 
            this.rdbCommandText.AutoSize = true;
            this.rdbCommandText.Location = new System.Drawing.Point(6, 53);
            this.rdbCommandText.Name = "rdbCommandText";
            this.rdbCommandText.Size = new System.Drawing.Size(121, 17);
            this.rdbCommandText.TabIndex = 4;
            this.rdbCommandText.Text = "Utilizar CommadText";
            this.rdbCommandText.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(180, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRedefinir
            // 
            this.btnRedefinir.Location = new System.Drawing.Point(93, 234);
            this.btnRedefinir.Name = "btnRedefinir";
            this.btnRedefinir.Size = new System.Drawing.Size(75, 23);
            this.btnRedefinir.TabIndex = 12;
            this.btnRedefinir.Text = "Redefinir";
            this.btnRedefinir.UseVisualStyleBackColor = true;
            this.btnRedefinir.Click += new System.EventHandler(this.btnRedefinir_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(12, 234);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // rdbTabelaSolution
            // 
            this.rdbTabelaSolution.AutoSize = true;
            this.rdbTabelaSolution.Location = new System.Drawing.Point(6, 53);
            this.rdbTabelaSolution.Name = "rdbTabelaSolution";
            this.rdbTabelaSolution.Size = new System.Drawing.Size(146, 17);
            this.rdbTabelaSolution.TabIndex = 4;
            this.rdbTabelaSolution.Text = "Cada tabela uma Sotulion";
            this.rdbTabelaSolution.UseVisualStyleBackColor = true;
            // 
            // rdbSeparaProjetos
            // 
            this.rdbSeparaProjetos.AutoSize = true;
            this.rdbSeparaProjetos.Checked = true;
            this.rdbSeparaProjetos.Location = new System.Drawing.Point(6, 30);
            this.rdbSeparaProjetos.Name = "rdbSeparaProjetos";
            this.rdbSeparaProjetos.Size = new System.Drawing.Size(103, 17);
            this.rdbSeparaProjetos.TabIndex = 3;
            this.rdbSeparaProjetos.TabStop = true;
            this.rdbSeparaProjetos.Text = "Separar Projetos";
            this.rdbSeparaProjetos.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbApenasArquivo);
            this.groupBox2.Controls.Add(this.rdbTabelaSolution);
            this.groupBox2.Controls.Add(this.rdbSeparaProjetos);
            this.groupBox2.Location = new System.Drawing.Point(171, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 100);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solution - Projeto";
            // 
            // rdbApenasArquivo
            // 
            this.rdbApenasArquivo.AutoSize = true;
            this.rdbApenasArquivo.Location = new System.Drawing.Point(6, 76);
            this.rdbApenasArquivo.Name = "rdbApenasArquivo";
            this.rdbApenasArquivo.Size = new System.Drawing.Size(162, 17);
            this.rdbApenasArquivo.TabIndex = 5;
            this.rdbApenasArquivo.Text = "Criar apenas os Arquivos .CS";
            this.rdbApenasArquivo.UseVisualStyleBackColor = true;
            // 
            // rdbNenhumFrontEnd
            // 
            this.rdbNenhumFrontEnd.AutoSize = true;
            this.rdbNenhumFrontEnd.Location = new System.Drawing.Point(6, 65);
            this.rdbNenhumFrontEnd.Name = "rdbNenhumFrontEnd";
            this.rdbNenhumFrontEnd.Size = new System.Drawing.Size(65, 17);
            this.rdbNenhumFrontEnd.TabIndex = 5;
            this.rdbNenhumFrontEnd.Text = "Nenhum";
            this.rdbNenhumFrontEnd.UseVisualStyleBackColor = true;
            // 
            // rdbGerarPages
            // 
            this.rdbGerarPages.AutoSize = true;
            this.rdbGerarPages.Location = new System.Drawing.Point(6, 42);
            this.rdbGerarPages.Name = "rdbGerarPages";
            this.rdbGerarPages.Size = new System.Drawing.Size(84, 17);
            this.rdbGerarPages.TabIndex = 4;
            this.rdbGerarPages.Text = "Gerar Pages";
            this.rdbGerarPages.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNenhumFrontEnd);
            this.groupBox1.Controls.Add(this.rdbGerarPages);
            this.groupBox1.Controls.Add(this.rdbGerarForms);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FrontEnd";
            // 
            // rdbGerarForms
            // 
            this.rdbGerarForms.AutoSize = true;
            this.rdbGerarForms.Checked = true;
            this.rdbGerarForms.Location = new System.Drawing.Point(6, 19);
            this.rdbGerarForms.Name = "rdbGerarForms";
            this.rdbGerarForms.Size = new System.Drawing.Size(82, 17);
            this.rdbGerarForms.TabIndex = 3;
            this.rdbGerarForms.TabStop = true;
            this.rdbGerarForms.Text = "Gerar Forms";
            this.rdbGerarForms.UseVisualStyleBackColor = true;
            // 
            // rdbNenhumTransacao
            // 
            this.rdbNenhumTransacao.AutoSize = true;
            this.rdbNenhumTransacao.Location = new System.Drawing.Point(6, 76);
            this.rdbNenhumTransacao.Name = "rdbNenhumTransacao";
            this.rdbNenhumTransacao.Size = new System.Drawing.Size(65, 17);
            this.rdbNenhumTransacao.TabIndex = 2;
            this.rdbNenhumTransacao.Text = "Nenhum";
            this.rdbNenhumTransacao.UseVisualStyleBackColor = true;
            // 
            // rdbDbTransaction
            // 
            this.rdbDbTransaction.AutoSize = true;
            this.rdbDbTransaction.Location = new System.Drawing.Point(6, 53);
            this.rdbDbTransaction.Name = "rdbDbTransaction";
            this.rdbDbTransaction.Size = new System.Drawing.Size(95, 17);
            this.rdbDbTransaction.TabIndex = 1;
            this.rdbDbTransaction.Text = "DbTransaction";
            this.rdbDbTransaction.UseVisualStyleBackColor = true;
            // 
            // rdbScopeTransaction
            // 
            this.rdbScopeTransaction.AutoSize = true;
            this.rdbScopeTransaction.Checked = true;
            this.rdbScopeTransaction.Location = new System.Drawing.Point(6, 30);
            this.rdbScopeTransaction.Name = "rdbScopeTransaction";
            this.rdbScopeTransaction.Size = new System.Drawing.Size(112, 17);
            this.rdbScopeTransaction.TabIndex = 0;
            this.rdbScopeTransaction.TabStop = true;
            this.rdbScopeTransaction.Text = "ScopeTransaction";
            this.rdbScopeTransaction.UseVisualStyleBackColor = true;
            // 
            // GpbTransacao
            // 
            this.GpbTransacao.Controls.Add(this.rdbNenhumTransacao);
            this.GpbTransacao.Controls.Add(this.rdbDbTransaction);
            this.GpbTransacao.Controls.Add(this.rdbScopeTransaction);
            this.GpbTransacao.Location = new System.Drawing.Point(12, 12);
            this.GpbTransacao.Name = "GpbTransacao";
            this.GpbTransacao.Size = new System.Drawing.Size(153, 100);
            this.GpbTransacao.TabIndex = 8;
            this.GpbTransacao.TabStop = false;
            this.GpbTransacao.Text = "Transação - Dal";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdbNaoUtilizarNucleo);
            this.groupBox4.Controls.Add(this.rdbUtilizarNucleo);
            this.groupBox4.Location = new System.Drawing.Point(357, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 100);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Núcleo - Info/Dal/Bll";
            // 
            // rdbNaoUtilizarNucleo
            // 
            this.rdbNaoUtilizarNucleo.AutoSize = true;
            this.rdbNaoUtilizarNucleo.Location = new System.Drawing.Point(6, 53);
            this.rdbNaoUtilizarNucleo.Name = "rdbNaoUtilizarNucleo";
            this.rdbNaoUtilizarNucleo.Size = new System.Drawing.Size(114, 17);
            this.rdbNaoUtilizarNucleo.TabIndex = 4;
            this.rdbNaoUtilizarNucleo.Text = "Não utilizar Núcelo";
            this.rdbNaoUtilizarNucleo.UseVisualStyleBackColor = true;
            // 
            // rdbUtilizarNucleo
            // 
            this.rdbUtilizarNucleo.AutoSize = true;
            this.rdbUtilizarNucleo.Checked = true;
            this.rdbUtilizarNucleo.Location = new System.Drawing.Point(6, 30);
            this.rdbUtilizarNucleo.Name = "rdbUtilizarNucleo";
            this.rdbUtilizarNucleo.Size = new System.Drawing.Size(93, 17);
            this.rdbUtilizarNucleo.TabIndex = 3;
            this.rdbUtilizarNucleo.TabStop = true;
            this.rdbUtilizarNucleo.Text = "Utilizar Núcleo";
            this.rdbUtilizarNucleo.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdbNaoCriarCollection);
            this.groupBox5.Controls.Add(this.rdbCriarCollection);
            this.groupBox5.Location = new System.Drawing.Point(357, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(165, 100);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Info";
            // 
            // rdbNaoCriarCollection
            // 
            this.rdbNaoCriarCollection.AutoSize = true;
            this.rdbNaoCriarCollection.Location = new System.Drawing.Point(6, 53);
            this.rdbNaoCriarCollection.Name = "rdbNaoCriarCollection";
            this.rdbNaoCriarCollection.Size = new System.Drawing.Size(151, 17);
            this.rdbNaoCriarCollection.TabIndex = 4;
            this.rdbNaoCriarCollection.Text = "Não criar Collection por FK";
            this.rdbNaoCriarCollection.UseVisualStyleBackColor = true;
            // 
            // rdbCriarCollection
            // 
            this.rdbCriarCollection.AutoSize = true;
            this.rdbCriarCollection.Checked = true;
            this.rdbCriarCollection.Location = new System.Drawing.Point(6, 30);
            this.rdbCriarCollection.Name = "rdbCriarCollection";
            this.rdbCriarCollection.Size = new System.Drawing.Size(129, 17);
            this.rdbCriarCollection.TabIndex = 3;
            this.rdbCriarCollection.TabStop = true;
            this.rdbCriarCollection.Text = "Criar Collection por FK";
            this.rdbCriarCollection.UseVisualStyleBackColor = true;
            // 
            // FrmOpçõesAvancadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(564, 284);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRedefinir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GpbTransacao);
            this.Name = "FrmOpçõesAvancadas";
            this.Text = "FrmOpçõesAvancadas";
            this.Load += new System.EventHandler(this.FrmOpcoesAvancadas_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GpbTransacao.ResumeLayout(false);
            this.GpbTransacao.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbStoredProcedure;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbCommandText;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnRedefinir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.RadioButton rdbTabelaSolution;
        private System.Windows.Forms.RadioButton rdbSeparaProjetos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbNenhumFrontEnd;
        private System.Windows.Forms.RadioButton rdbGerarPages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbGerarForms;
        private System.Windows.Forms.RadioButton rdbNenhumTransacao;
        private System.Windows.Forms.RadioButton rdbDbTransaction;
        private System.Windows.Forms.RadioButton rdbScopeTransaction;
        private System.Windows.Forms.GroupBox GpbTransacao;
        private System.Windows.Forms.RadioButton rdbApenasArquivo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdbNaoUtilizarNucleo;
        private System.Windows.Forms.RadioButton rdbUtilizarNucleo;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdbNaoCriarCollection;
        private System.Windows.Forms.RadioButton rdbCriarCollection;
    }
}