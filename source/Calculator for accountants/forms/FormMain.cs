using System;
using System.Drawing;
using System.Windows.Forms;

using Calculator_for_accountants.classes;

namespace Calculator_for_accountants.forms
{
    public partial class FormMain : Form
    {
        Economic eco = new Economic();

        public FormMain()
        {
            InitializeComponent();
        }

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

        private void EventKeyUp(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char) e.KeyCode) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                var t = sender as TextBox;

                if (!double.TryParse(t.Text, out double res))
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
                Fill(t.Name);
            }
        }

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

        private void Fill(string name = "")
        {
            if (!name.Equals(tDirty.Name))
                SetFormat(tDirty, eco.Dirty);

            if (!name.Equals(tNdfl.Name))
                SetFormat(tNdfl, eco.Ndfl);

            if (!name.Equals(tVz.Name))
                SetFormat(tVz, eco.Vz);

            if (!name.Equals(tEsv.Name))
                SetFormat(tEsv, eco.Esv);

            if (!name.Equals(tClear.Name))
                SetFormat(tClear, eco.Clear);

            if (!name.Equals(tDirtyEsv.Name))
                SetFormat(tDirtyEsv, eco.DirtyEsv);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkBox1.Checked;
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            FormHelpler f = new FormHelpler();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(Location.X + (Width - f.Width) / 2, Location.Y + (Height - f.Height) / 2);
            f.Show(this);
        }

        private void TDirty_Leave(object sender, EventArgs e)
        {
            SetFormat(tDirty, eco.Dirty);
        }

        private void TNdfl_Leave(object sender, EventArgs e)
        {
            SetFormat(tNdfl, eco.Ndfl);
        }

        private void TVz_Leave(object sender, EventArgs e)
        {
            SetFormat(tVz, eco.Vz);
        }

        private void TEsv_Leave(object sender, EventArgs e)
        {
            SetFormat(tEsv, eco.Esv);
        }

        private void TClear_Leave(object sender, EventArgs e)
        {
            SetFormat(tClear, eco.Clear);
        }

        private static void SetFormat(TextBox t, double val)
        {
            t.Text = string.Format("{0:#,##0.##}", val);
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            eco.SetRound(checkBox2.Checked);
            
            eco.Calculate();
            Fill();
        }
    }
}
