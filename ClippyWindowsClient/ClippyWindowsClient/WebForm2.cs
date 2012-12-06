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
    public partial class WebForm2 : Form
    {
        public WebForm2()
        {
            InitializeComponent();
        }

        public void OpenWebBrowser(string sUrl)
        {
            webBrowser1.Navigate(sUrl);
        }
    }
}
