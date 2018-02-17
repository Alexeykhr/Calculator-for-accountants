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

        /// <summary>
        /// Opening a link in a browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Alexeykhr");
        }

        /// <summary>
        /// Close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
