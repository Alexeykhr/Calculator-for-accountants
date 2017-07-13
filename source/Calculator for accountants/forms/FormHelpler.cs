using System.Diagnostics;
using System.Windows.Forms;

namespace Calculator_for_accountants.forms
{
    public partial class FormHelpler : Form
    {
        public FormHelpler()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Alexeykhr");
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
