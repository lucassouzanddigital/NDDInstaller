using NDDigital.eForms.Installer.Cold.Controls;
using NDDigital.eForms.Installer.Cold.Manager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace NDDigital.eForms.Installer.Cold
{
    public partial class StartPage : Form
    {        
        
        public UserControl _control = new PresentationFolder.Presentation();
       
        public StartPage()
        {
            InitializeComponent();        
            string CurrentUserName = Environment.UserName;
            label1.Text = "Usuário: " + CurrentUserName;
            lblVersion.Text = ControllerClass.VersionControl.ToString();
            panControl.Controls.Add(_control);
            
            
        }

    }

}
