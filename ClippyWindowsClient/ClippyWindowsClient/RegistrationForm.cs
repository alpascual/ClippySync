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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            if (this.textBox_Username.Text.Length > 1)
            {
                //Login
                if (this.textBox_Password.Text == this.textBox_Password_repeat.Text)
                {
                    this.labelIncorrectPassword.Visible = false;
                    ServerProtocol protocol = new ServerProtocol();
                    if (protocol.ServerRegistration(this.textBox_Username.Text, this.textBox_Password.Text) == true)
                    {
                        this.label_error.Visible = false;
                        protocol.ServerLogin(this.textBox_Username.Text, this.textBox_Password.Text);
                        CredentialsStorage.Username = this.textBox_Username.Text;
                        CredentialsStorage.Password = this.textBox_Password.Text;
                        this.Hide();
                    }
                    else
                    {
                        this.label_error.Visible = true;
                    }
                }
                else
                {
                    this.labelIncorrectPassword.Visible = true;
                }
            }
        }
    }
}
