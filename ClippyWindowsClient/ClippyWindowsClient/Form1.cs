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
        
        private System.ComponentModel.IContainer components1;


        public Form1()
        {
            InitializeComponent();

            this.components1 = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemPause = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu1 
            this.contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.menuItemPause, this.menuItem1 });

            
            this.menuItemPause.Index = 0;
            this.menuItemPause.Text = "P&ause";
            this.menuItemPause.Click += new System.EventHandler(this.menuItemPause_Click);

            // Initialize menuItem1 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "E&xit";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            // Set up how the form should be displayed. 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Clippy Sync";

            // Create the NotifyIcon. 
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

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
            this.Close();
        }

        private void menuItemPause_Click(object Sender, EventArgs e)
        {
            // Pause the app TODO
        }

    }
}
