using Installer.Controls;
using Installer.Manager;
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


namespace Installer
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
