﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDDigital.eForms.Installer.Connector.Controls.Oracle
{
    public partial class ConnectionOracleInf : UserControl
    {
        public ConnectionOracleInf()
        {
            InitializeComponent();
        }

        private void btnAvanc_Click(object sender, EventArgs e)
        {
            if (ValidateInformations())
            {
                UserControl _panControl;
                this.Controls.Clear();
                _panControl = new ConnectionOracleCold();
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
            
            if (txtService.Text != "")
            {
                if (txtSGBD.Text != "")
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
                { MessageBox.Show("Nome do banco de Dados não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
            else
            { MessageBox.Show("Serviço não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            return retorn;
        }
    }
}