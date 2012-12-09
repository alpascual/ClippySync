using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClippyWindowsClient
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemPause;
        private System.Windows.Forms.MenuItem menuItemOptions;
        private System.Windows.Forms.MenuItem menuItemLogin;

        
        private System.ComponentModel.IContainer components1;

        private bool _closeForm = false;
        private ClipboardProcess _clipboardProcess = new ClipboardProcess();


        public Form1()
        {
            InitializeComponent();

            this.FormClosing += Form1_FormClosing;

            this.components1 = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemPause = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItemLogin = new System.Windows.Forms.MenuItem();
            
            // Initialize contextMenu1 
            this.contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.menuItemLogin, this.menuItemOptions, this.menuItemPause, this.menuItem1 });

            this.menuItemLogin.Index = 0;
            this.menuItemLogin.Text = "L&ogin";
            this.menuItemLogin.Click += new System.EventHandler(this.menuItemLogin_Click);

            this.menuItemPause.Index = 1;
            this.menuItemPause.Text = "P&ause";
            this.menuItemPause.Click += new System.EventHandler(this.menuItemPause_Click);

            this.menuItemOptions.Index = 2;
            this.menuItemOptions.Text = "O&ptions";
            this.menuItemOptions.Click += new System.EventHandler(this.menuItemOptions_Click);

            // Initialize menuItem1 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            // Set up how the form should be displayed. 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Clippy Sync";

            // Create the NotifyIcon. 
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components1);

            // The Icon property sets the icon that will appear 
            // in the systray for this application.
            notifyIcon1.Icon = new Icon("sync-image.ico");

            // The ContextMenu property sets the menu that will 
            // appear when the systray icon is right clicked.
            notifyIcon1.ContextMenu = this.contextMenu1;

            // The Text property sets the text that will be displayed, 
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon1.Text = "Keeps in Sync your clipboard between devices";
            notifyIcon1.Visible = true;

            // Handle the DoubleClick event to activate the form.
            notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);

        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_closeForm;
            if (_closeForm == false)
                this.Hide();
        }

        
        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon. 

            // Set the WindowState to normal if the form is minimized. 
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form. 
            this.Activate();
        }

        private void menuItem1_Click(object Sender, EventArgs e)
        {
            // Close the form, which closes the application. 
            _closeForm = true;
            this.Close();
        }

        private void menuItemPause_Click(object Sender, EventArgs e)
        {
            // Pause the app TODO
            if (this.menuItemPause.Text == "Play")
            {
                this.menuItemPause.Text = "P&ause";
                _clipboardProcess.Start();
            }
            else
            {
                this.menuItemPause.Text = "Play";
                _clipboardProcess.Stop();
            }
        }

        void menuItemLogin_Click(object sender, EventArgs e)
        {
            // Show login dialog box
            this.Show();
        }

        void menuItemOptions_Click(object sender, EventArgs e)
        {
            // TODO menu options
            OptionForm option = new OptionForm();
            option.Show();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            this.button_login.Enabled = false;

            if (this.menuItemLogin.Text == "Logout")
            {
                this.menuItemLogin.Text = "Login";
                CredentialsStorage.Username = "";
                CredentialsStorage.Password = "";

                _clipboardProcess.Stop();

                this.button_login.Enabled = true;
                return;
            }
            CredentialsStorage.Username = textBox_Username.Text;
            CredentialsStorage.Password = textBox_Password.Text;

            ServerProtocol server = new ServerProtocol();
            bool bReturn = server.ServerLogin(CredentialsStorage.Username, CredentialsStorage.Password);

            if (bReturn == true)
            {
                this.labelIncorrectPassword.Visible = false;
                this.Hide();

                this.menuItemLogin.Text = "Logout";

                _clipboardProcess.Start();
            }

            else
            {
                this.labelIncorrectPassword.Visible = true;
                _clipboardProcess.Stop();
            }

            this.button_login.Enabled = true;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.Show();
        }


    }
}
