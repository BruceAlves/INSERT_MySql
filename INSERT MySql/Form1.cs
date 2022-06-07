using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INSERT_MySql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butInserir_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string telefone = txtTelefone.Text;
            Guid codigo = Guid.NewGuid();

            string conexao_MySql = "Server=127.0.0.1;Database=comfirmarLogin;Uid=root;Pwd=bruce@#2022;";

            string comandoInsert = $@"insert into usuario (nome, email, senha, telefone, code, dataCadastro)
            values ('{nome}', '{email}', '{senha}','{telefone}', '{codigo}', sysdate());";

            MySqlConnection conexaoMySql = new MySqlConnection(conexao_MySql);

            try
            {
                conexaoMySql.Open();

                MySqlCommand executorComando = new MySqlCommand(comandoInsert, conexaoMySql);
                executorComando.ExecuteNonQuery();

                MessageBox.Show($"Usuario {nome} foi Inserido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Banco de dados", $"Erro:\n{ex.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoMySql.Close();
            }
        }
    }
}
