namespace WinFormsConsumoWepApi
{
    partial class Form1
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
            this.btnMostrarMusicas = new System.Windows.Forms.Button();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.lblCidade = new System.Windows.Forms.Label();
            this.dgMusicas = new System.Windows.Forms.DataGridView();
            this.MusicName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sStripForm = new System.Windows.Forms.StatusStrip();
            this.tStripStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lstboxEstatisticas = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMusicas)).BeginInit();
            this.sStripForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMostrarMusicas
            // 
            this.btnMostrarMusicas.Location = new System.Drawing.Point(419, 17);
            this.btnMostrarMusicas.Name = "btnMostrarMusicas";
            this.btnMostrarMusicas.Size = new System.Drawing.Size(123, 31);
            this.btnMostrarMusicas.TabIndex = 0;
            this.btnMostrarMusicas.Text = "Mostrar Músicas";
            this.btnMostrarMusicas.UseVisualStyleBackColor = true;
            this.btnMostrarMusicas.Click += new System.EventHandler(this.btnMostrarMusicas_Click);
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(138, 21);
            this.txtCidade.MaxLength = 40;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(259, 22);
            this.txtCidade.TabIndex = 1;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(13, 24);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(119, 17);
            this.lblCidade.TabIndex = 2;
            this.lblCidade.Text = "Informe a Cidade:";
            // 
            // dgMusicas
            // 
            this.dgMusicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMusicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MusicName});
            this.dgMusicas.Location = new System.Drawing.Point(16, 58);
            this.dgMusicas.Name = "dgMusicas";
            this.dgMusicas.RowHeadersWidth = 20;
            this.dgMusicas.RowTemplate.Height = 24;
            this.dgMusicas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgMusicas.Size = new System.Drawing.Size(526, 193);
            this.dgMusicas.TabIndex = 3;
            // 
            // MusicName
            // 
            this.MusicName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MusicName.DataPropertyName = "MusicName";
            this.MusicName.HeaderText = "Músicas";
            this.MusicName.MinimumWidth = 6;
            this.MusicName.Name = "MusicName";
            this.MusicName.ReadOnly = true;
            // 
            // sStripForm
            // 
            this.sStripForm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sStripForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripStatusInfo});
            this.sStripForm.Location = new System.Drawing.Point(0, 411);
            this.sStripForm.Name = "sStripForm";
            this.sStripForm.Size = new System.Drawing.Size(562, 26);
            this.sStripForm.TabIndex = 4;
            this.sStripForm.Text = "statusStrip1";
            // 
            // tStripStatusInfo
            // 
            this.tStripStatusInfo.Name = "tStripStatusInfo";
            this.tStripStatusInfo.Size = new System.Drawing.Size(151, 20);
            this.tStripStatusInfo.Text = "toolStripStatusLabel1";
            // 
            // lstboxEstatisticas
            // 
            this.lstboxEstatisticas.FormattingEnabled = true;
            this.lstboxEstatisticas.ItemHeight = 16;
            this.lstboxEstatisticas.Location = new System.Drawing.Point(16, 270);
            this.lstboxEstatisticas.Name = "lstboxEstatisticas";
            this.lstboxEstatisticas.Size = new System.Drawing.Size(526, 116);
            this.lstboxEstatisticas.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 437);
            this.Controls.Add(this.lstboxEstatisticas);
            this.Controls.Add(this.sStripForm);
            this.Controls.Add(this.dgMusicas);
            this.Controls.Add(this.lblCidade);
            this.Controls.Add(this.txtCidade);
            this.Controls.Add(this.btnMostrarMusicas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Desafio inGaia (Consumo de WebApi)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMusicas)).EndInit();
            this.sStripForm.ResumeLayout(false);
            this.sStripForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarMusicas;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.DataGridView dgMusicas;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusicName;
        private System.Windows.Forms.StatusStrip sStripForm;
        private System.Windows.Forms.ToolStripStatusLabel tStripStatusInfo;
        private System.Windows.Forms.ListBox lstboxEstatisticas;
    }
}

