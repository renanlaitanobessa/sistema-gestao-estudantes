namespace sistema_gestao_estudantes
{
    partial class FormListaDeEstudantes
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
            this.dataGridViewLista = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLista
            // 
            this.dataGridViewLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLista.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewLista.Name = "dataGridViewLista";
            this.dataGridViewLista.Size = new System.Drawing.Size(775, 350);
            this.dataGridViewLista.TabIndex = 0;
            this.dataGridViewLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridViewLista.DoubleClick += new System.EventHandler(this.dataGridViewLista_DoubleClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(13, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(775, 68);
            this.button1.TabIndex = 1;
            this.button1.Text = "Atualizar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonAtualizar_Click);
            // 
            // FormListaDeEstudantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewLista);
            this.Name = "FormListaDeEstudantes";
            this.Text = "FormListaDeEstudantes";
            this.Load += new System.EventHandler(this.FormListaDeEstudantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLista;
        private System.Windows.Forms.Button button1;
    }
}