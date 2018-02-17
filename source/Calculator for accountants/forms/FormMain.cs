using System;
using System.Drawing;
using System.Windows.Forms;

using Calculator_for_accountants.classes;

namespace Calculator_for_accountants.forms
{
    public partial class FormMain : Form
    {
        private const string basicFormat = "{0:#,##0.##}";

        private static int rate;

        private Economic eco = new Economic();

        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hanging events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            tDirty.KeyPress += EventKeyPress;
            tNdfl.KeyPress += EventKeyPress;
            tVz.KeyPress += EventKeyPress;
            tEsv.KeyPress += EventKeyPress;
            tClear.KeyPress += EventKeyPress;

            tDirty.KeyUp += EventKeyUp;
            tNdfl.KeyUp += EventKeyUp;
            tVz.KeyUp += EventKeyUp;
            tEsv.KeyUp += EventKeyUp;
            tClear.KeyUp += EventKeyUp;
        }

        /// <summary>
        /// We calculate the numbers based on the input field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventKeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char) e.KeyCode) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                var t = sender as TextBox;
                
                if (!decimal.TryParse(t.Text, out decimal res))
                    return;

                switch (t.Name)
                {
                    case "tDirty": eco.Dirty = res; break;
                    case "tNdfl": eco.Ndfl = res; break;
                    case "tVz": eco.Vz = res; break;
                    case "tEsv": eco.Esv = res; break;
                    case "tClear": eco.Clear = res; break;
                    case "tDirtyEsv": eco.DirtyEsv = res; break;
                }

                eco.Calculate();
                FillTextBoxex(t.Name);
            }
        }

        /// <summary>
        /// Change "." on ",".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventKeyPress(object sender, KeyPressEventArgs e)
        {
            var t = (sender as TextBox);

            e.KeyChar = e.KeyChar == '.' ? ',' : e.KeyChar;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',')
                || ((e.KeyChar == ',' && t.Text.IndexOf(',') > -1)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Fill in the fields.
        /// </summary>
        /// <param name="name"></param>
        private void FillTextBoxex(string name = "")
        {
            if (!name.Equals(tDirty.Name))
                WriteTextToTextBox(tDirty, eco.Dirty);

            if (!name.Equals(tNdfl.Name))
                WriteTextToTextBox(tNdfl, eco.Ndfl);

            if (!name.Equals(tVz.Name))
                WriteTextToTextBox(tVz, eco.Vz);

            if (!name.Equals(tEsv.Name))
                WriteTextToTextBox(tEsv, eco.Esv);

            if (!name.Equals(tClear.Name))
                WriteTextToTextBox(tClear, eco.Clear);

            if (!name.Equals(tDirtyEsv.Name))
                WriteTextToTextBox(tDirtyEsv, eco.DirtyEsv);
        }

        /// <summary>
        /// Window on top of other windows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }

        /// <summary>
        /// Open the help window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label10_Click(object sender, EventArgs e)
        {
            FormHelpler f = new FormHelpler();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(Location.X + (Width - f.Width) / 2, Location.Y + (Height - f.Height) / 2);
            f.Show(this);
        }

        /// <summary>
        /// Change event rounding off a dirty salary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            eco.SetRound(checkBox2.Checked);
            eco.Calculate();
            FillTextBoxex();
        }

        /// <summary>
        /// Display new value in TextBox.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="val"></param>
        private static void WriteTextToTextBox(TextBox t, decimal val)
        {
            var format = rate > 0 ? MakeFormat(GetLengthIntegerPart(val), rate) : basicFormat;

            t.Text = string.Format(format, val);
        }

        /// <summary>
        /// Change digits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRate_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(fRate.Text, out int val) && val > 0 && val < 11)
                rate = val;
            else
                rate = 0;

            FillTextBoxex();
        }

        /// <summary>
        /// Get a valid format for string.Format.
        /// </summary>
        /// <param name="len"></param>
        /// <param name="rate"></param>
        /// <returns></returns>
        private static string MakeFormat(int len, int rate)
        {
            string str = string.Empty;

            for (int i = 0; i < len; i += rate)
                str += new String('#', i > len ? rate - i - len : rate) + " ";

            return "{0:" + str.TrimEnd() + ".##}";
        }

        /// <summary>
        /// Get the length of the integer part.
        /// </summary>
        /// <returns></returns>
        private static int GetLengthIntegerPart(decimal num)
        {
            return Math.Truncate(num).ToString().Length;
        }

        /**
         * |-------------------------------------------------------------
         * | Events of focus removal.
         * |-------------------------------------------------------------
         * |
         */

        private void TDirty_Leave(object sender, EventArgs e)
        {
            WriteTextToTextBox(tDirty, eco.Dirty);
        }

        private void TNdfl_Leave(object sender, EventArgs e)
        {
            WriteTextToTextBox(tNdfl, eco.Ndfl);
        }

        private void TVz_Leave(object sender, EventArgs e)
        {
            WriteTextToTextBox(tVz, eco.Vz);
        }

        private void TEsv_Leave(object sender, EventArgs e)
        {
            WriteTextToTextBox(tEsv, eco.Esv);
        }

        private void TClear_Leave(object sender, EventArgs e)
        {
            WriteTextToTextBox(tClear, eco.Clear);
        }
    }
}
