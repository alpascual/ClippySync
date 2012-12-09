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
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();

            this.textBox1.Text = Program._lastText;
        }
    }
}
