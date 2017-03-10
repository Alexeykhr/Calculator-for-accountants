using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calculator_for_accountants
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NumberFormatInfo nfi = new CultureInfo("ru-RU", false).NumberFormat;

        const double koefNDFL = 0.18;
        const double koefVZ = 0.015;
        const double koefESV = 0.22;

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            textBox1.KeyUp += new KeyEventHandler(changeText);
            textBox2.KeyUp += new KeyEventHandler(changeText);
            textBox3.KeyUp += new KeyEventHandler(changeText);
            textBox4.KeyUp += new KeyEventHandler(changeText);
            textBox5.KeyUp += new KeyEventHandler(changeText);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = (checkBox1.Checked) ? true : false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            double val;
            bool isNumeric = double.TryParse(textBox2.Text.Replace('.', ','), out val);

            if (isNumeric)
            {
                calculations("textBox2", val);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

        private void changeText(object sender, KeyEventArgs e)
        {
            string str = ((TextBox)sender).Name;
            
            if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                (e.KeyCode == Keys.Space || e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod ||
                e.KeyCode == Keys.Decimal))
            {
                double val;
                bool isNumeric = double.TryParse(((TextBox)sender).Text.Replace('.',','), out val);

                if (isNumeric)
                {
                    calculations(str, val);
                }
                else
                {
                    clearText(str);
                }
            }
            else if (e.KeyCode != Keys.Tab && e.KeyCode != Keys.Alt && e.KeyCode != Keys.Control)
            {
                clearText(str);
            }
        }

        private void calculations(string field, double value)
        {
            double dirty, ndfl, vz, esv;

            switch (field)
            {
                case "textBox2":
                    dirty = value / koefNDFL;
                    break;
                case "textBox3":
                    dirty = value / koefVZ;
                    break;
                case "textBox4":
                    dirty = value / koefESV;
                    break;
                case "textBox5":
                    dirty = value / (1 - (koefNDFL + koefVZ));
                    break;
                default:
                    dirty = value;
                    break;
            }

            ndfl = Convert.ToDouble(dirty * koefNDFL);
            vz = Convert.ToDouble(dirty * koefVZ);
            esv = Convert.ToDouble(dirty * koefESV);
            
            if (!field.Equals("textBox1"))
            {
                if (checkBox2.Checked)
                {
                    dirty = Math.Ceiling(dirty);
                }

                textBox1.Text = dirty.ToString("N4", nfi);
            }

            if ( ! field.Equals("textBox2") )
            {
                textBox2.Text = ndfl.ToString("N4", nfi);
            }

            if ( ! field.Equals("textBox3") )
            {
                textBox3.Text = vz.ToString("N4", nfi);
            }

            if ( ! field.Equals("textBox4") )
            {
                textBox4.Text = esv.ToString("N4", nfi);
            }

            if ( ! field.Equals("textBox5") )
            {
                textBox5.Text = (dirty - ndfl - vz).ToString("N4", nfi);
            }
            
            textBox6.Text = (dirty + esv).ToString("N4", nfi);
        }

        private void clearText(string field)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox && c.Name != field)
                {
                    ((TextBox)c).Text = "0";
                }
            }
        }
    }
}
