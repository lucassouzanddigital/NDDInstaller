using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
using NDDigital.eForms.Installer.Connector;
using NDDigital.eForms.Installer.Connector.Controls.Manager;


namespace NDDigital.eForms.Installer.Connector.Controls.SQL
{
    public partial class ConnetionSQL : UserControl
    {
        public static string UserConnectorSQL { get; set; }
        public static string SGBDConnectorSQL = "NDD_CONNECTOR";
        public static string ServidorConnectorSQL { get; set; }
        public static string SenhaConnectorSQL { get; set; }

        public ConnetionSQL()
        {

            InitializeComponent();
            txtServ.Text = ServidorConnectorSQL;
            txtSGBD.Text = SGBDConnectorSQL;
            txtUser.Text = UserConnectorSQL;

        }

        //Ação botão avançar
        private void btnAvanc_Click(object sender, EventArgs e)
        {

            if (ValidateInformations())
            {
                ServidorConnectorSQL = txtServ.Text;
                SGBDConnectorSQL = txtSGBD.Text;
                UserConnectorSQL = txtUser.Text;
                SenhaConnectorSQL = txtSenha.Text;
                ValidateCheckSGBD();

                if (checkSGBD.Checked)
                {
                    if (ValidateConnection())
                    {
                        UserControl _panControl;
                        this.Controls.Clear();
                        _panControl = new ConnectionSQLCold();
                        this.Controls.Add(_panControl);
                    }
                }
                else
                {
                    UserControl _panControl;
                    this.Controls.Clear();
                    _panControl = new ConnectionSQLCold();
                    this.Controls.Add(_panControl);
                }

            }
        }

        //Ação botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControlStart;
            this.Controls.Clear();
            _panControlStart = new StartPageControl();
            this.Controls.Add(_panControlStart);
        }

        //Ação botão cancelar
        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }
        }

        //Valida se todos os campos obrigatorios foram preenchidos
        private bool ValidateInformations()
        {
            bool retorn = false;

            if (txtServ.Text != "")
            {
                if (txtSGBD.Text != "")
                {
                    if (txtUser.Text != "")
                    {
                        if (txtSenha.Text != "")
                        {
                            retorn = true;
                        }
                        else
                        { MessageBox.Show("Senha não informada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                    }
                    else
                    { MessageBox.Show("Usuário não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
                else
                { MessageBox.Show("Nome do Banco de Dados não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
            else
            { MessageBox.Show("Servidor não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            return retorn;
        }

        //Valida se CheckBox Banco ja criado está marcada
        private void ValidateCheckSGBD()
        {
            if (checkSGBD.Checked)
            {
                ControllerClass.SGBDCreated = true;
            }
            else
            {
                ControllerClass.SGBDCreated = false;
            }
        }

        //Valida se as informações de conexão com o banco são validas
        private bool ValidateConnection()
        {
            bool exists = false;
            string strcon = "user id=" + txtUser.Text + ";password=" + txtSenha.Text + ";server=" + txtServ.Text + ";database=" + txtSGBD.Text + ";connection timeout=30";

            SqlConnection conexao = new SqlConnection(strcon);

            try
            {
                conexao.Open();
                conexao.Close();
                exists = true;
            }
            catch (Exception)
            {
                exists = false;
                MessageBox.Show("Não foi possível realizar a conexão com o banco de dados, por favor, verifique suas configurações e tente novamente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return exists;

        }
    }
}