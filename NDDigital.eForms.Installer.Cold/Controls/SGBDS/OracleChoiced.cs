﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDDigital.eForms.Installer.Cold.Controls.ProgressControls;

namespace NDDigital.eForms.Installer.Cold.Controls.SGBDS
{
    public partial class OracleChoiced : UserControl
    {
        public OracleChoiced()
        {
            InitializeComponent();
        }

        private void btnAvanc_Click(object sender, EventArgs e)
        {
            if (ValidateInformations())
            {
                UserControl _panControl;
                this.Controls.Clear();
                _panControl = new Progress();
                this.Controls.Add(_panControl);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControlStart;
            this.Controls.Clear();
            _panControlStart = new SGBDChoice();
            this.Controls.Add(_panControlStart);
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }
        }

        private bool ValidateInformations()
        {
            //Valida se todos os campos obrigatorios foram preenchidos

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
                { MessageBox.Show("Nome do Banco da Dados não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
            else
            { MessageBox.Show("Serviço não informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            return retorn;
        }
    }
}
