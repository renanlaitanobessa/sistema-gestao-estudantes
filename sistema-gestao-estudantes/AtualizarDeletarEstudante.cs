using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistema_gestao_estudantes
{
    public partial class AtualizarDeletarEstudante : Form
    {
        Estudante estudante = new Estudante();
        public AtualizarDeletarEstudante()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnviarFoto_Click(object sender, EventArgs e)
        {
            // Pesquisa pela imagem no computador.
            OpenFileDialog abrirArquivo = new OpenFileDialog();
            abrirArquivo.Filter =
                "Seleciona a Foto(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (abrirArquivo.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(abrirArquivo.FileName);
            }
        }

        private void AtualizarDeletarEstudante_Load(object sender, EventArgs e)
        {

        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            {
                // Atualiza as informaçoes do estudante.

                Estudante estudante = new Estudante();
                int id = Convert.ToInt32(textBoxID.Text);
                string nome = textBoxNome.Text;
                string sobrenome = textBoxSobrenome.Text;
                DateTime nascimento = dateTimePickerNascimento.Value;
                string telefone = textBoxTelefone.Text;
                string endereco = textBoxEndereco.Text;
                string genero = "Feminino";

                if (radioButtonMasculino.Checked)
                {
                    genero = "Masculino";
                }

                // A foto do estudante em formato binário.
                MemoryStream foto = new MemoryStream();

                // Verifica se o estudante é maior de 10 anos.
                int anoDeNascimento = dateTimePickerNascimento.Value.Year;
                // Pega o ano no qual estamos.
                int anoAtual = DateTime.Now.Year;
                if (
                    (anoAtual - anoDeNascimento) < 10 ||
                    (anoAtual - anoDeNascimento) > 100
                    )
                {
                    MessageBox.Show("A idade precisa ser entre 10 e 100 anos.",
                        "Idade Inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Verificar())
                {
                    pictureBoxFoto.Image.Save(foto, pictureBoxFoto.Image.RawFormat);
                    if (estudante.inserirEstudante(nome, sobrenome, nascimento,
                        telefone, genero, endereco, foto))
                    {
                        MessageBox.Show("Novo Estudante Cadastrado", "Sucesso!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro", "Inserir Estudante",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Campos não preenchidos",
                        "Inserir Estudante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        // Verificar se todos os campos de cadastro foram
        // preenchidos.
        bool Verificar()
        {
            if ((textBoxNome.Text.Trim() == "") ||
                (textBoxSobrenome.Text.Trim() == "") ||
                (textBoxTelefone.Text.Trim() == "") ||
                (textBoxEndereco.Text.Trim() == "") ||
                (pictureBoxFoto.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxID.Text);

            if (MessageBox.Show("Tem certeza quee quer remover o estudante?",
                "Remover Estudante", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (estudante.deletarEstudante(id))
                {
                    MessageBox.Show("Estudante Removido", "Remover Estudante",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBoxID.Text = "";
                    textBoxNome.Text = "";
                    textBoxSobrenome.Text = "";
                    textBoxTelefone.Text = "";
                    textBoxEndereco.Text = "";
                    dateTimePickerNascimento.Value = DateTime.Now;
                    pictureBoxFoto.Image = null;
                }
                else
                {

                    MessageBox.Show("Estudante Nao Removido",
                        "Remover Estudante", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }

            }
        }

        private void buttonProcurar(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxID.Text);
            MySqlCommand comando = new MySqlCommand("SELECT `id`,`nome`,`sobrenome`,`data de nascimento`,`genero`,`telefone`,`endereço`,`foto`, FROM `estudante` WHERE `id` =" + id);

            DataTable tabela = estudante.pegarEstudantes(comando);

            if (tabela.Rows.Count > 0)
            {
                textBoxNome.Text = tabela.Rows[0]["nome"].ToString();
                textBoxSobrenome.Text = tabela.Rows[0]["sobrenome"].ToString();
                textBoxTelefone.Text = tabela.Rows[0]["telefone"].ToString();
                textBoxEndereco.Text = tabela.Rows[0]["endereco"].ToString();

                dateTimePickerNascimento.Value = (DateTime)tabela.Rows[0]["nascimento"];

                if (tabela.Rows[0]["genero"].ToString() == "feminino")
                {
                    radioButtonFeminino.Checked = true;
                }
                else
                {
                    radioButtonMasculino.Checked = true; 
                }

                byte[] fotoDaTabela = (byte[]) tabela.Rows[0]["foto"];
                MemoryStream fotodaInterface = new MemoryStream(fotoDaTabela);
                pictureBoxFoto.Image = Image.FromStream(fotodaInterface); 
            }
        }

        private void dateTimePickerNascimento_ValueChanged(object sender, EventArgs e)
        {

        }
    }

} 

