using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.IO;

namespace NDDigital.eForms.Installer.Connector.Controls.Informix
{
    public partial class ConnectionInformixInf : UserControl
    {

        public ConnectionInformixInf()
        {
            InitializeComponent();
        }

        private void btnAvanc_Click(object sender, EventArgs e)
        {
            if (ValidateInformations())
            {
                UserControl _panControl;
                this.Controls.Clear();
                _panControl = new ConnectionInformixCold();
                this.Controls.Add(_panControl);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControlStart;
            this.Controls.Clear();
            _panControlStart = new StartPageControl();
            this.Controls.Add(_panControlStart);
        }

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
                    if (txtInstance.Text != "")
                    {
                        if (txtPort.Text != "")
                        {
                            if (txtProtocol.Text != "")
                            {
                                if (txtUser.Text != "")
                                {
                                    if (txtPassword.Text != "")
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
                            { MessageBox.Show("Protocolo não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                        }
                        else
                        { MessageBox.Show("Porta não informada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                    }
                    else
                    { MessageBox.Show("Instância não informada", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
                else
                { MessageBox.Show("Nome do Banco de Dados não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
            else
            { MessageBox.Show("Servidor não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            return retorn;
        }
        
    }
}
