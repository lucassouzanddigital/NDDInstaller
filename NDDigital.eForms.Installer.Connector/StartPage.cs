using NDDigital.eForms.Installer.Connector.Controls;
using NDDigital.eForms.Installer.Connector.Controls.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDDigital.eForms.Installer.Connector
{
    public partial class StartPage : Form
    {
        public UserControl _control = new PresentationFolder.Presentation();

        public StartPage()
        {
            InitializeComponent();
            string CurrentUserName = Environment.UserName;
            lblUser.Text = "Usuário: " + CurrentUserName;
            lblVersion.Text = ControllerClass.VersionControl.ToString();
            panControl.Controls.Add(_control);

        }
    }
}
