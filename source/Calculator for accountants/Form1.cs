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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = (checkBox1.Checked) ? true : false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.KeyUp += TextBox1_KeyUp;
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            changeText(sender, e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.KeyUp += TextBox2_KeyUp;
        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            changeText(sender, e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.KeyUp += TextBox3_KeyUp;
        }

        private void TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            changeText(sender, e);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.KeyUp += TextBox4_KeyUp;
        }

        private void TextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            changeText(sender, e);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.KeyUp += TextBox5_KeyUp;
        }

        private void TextBox5_KeyUp(object sender, KeyEventArgs e)
        {
            changeText(sender, e);
        }

        private void changeText(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                return;
            }

            double val;
            string str = ((TextBox)sender).Name;
            bool isNumeric = double.TryParse( ((TextBox)sender).Text, out val );

            if (isNumeric)
            {
                calculations(str, val);
            }
            else
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

            label10.Text = Convert.ToString(dirty);

            if ( ! field.Equals("textBox1") )
            {
                dirty = Math.Ceiling(dirty);
            }

            ndfl = Convert.ToDouble(dirty * koefNDFL);
            vz = Convert.ToDouble(dirty * koefVZ);
            esv = Convert.ToDouble(dirty * koefESV);

            if ( ! field.Equals("textBox1") )
            {
                textBox1.Text = Convert.ToString( Math.Ceiling(dirty) );
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
