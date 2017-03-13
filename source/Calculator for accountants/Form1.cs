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
            bool isNumeric = double.TryParse(textBox1.Text.Replace('.', ','), out val);

            if (isNumeric)
            {
                calculations("", val);
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
            
            if (char.IsLetter((char) e.KeyCode) &&
                (e.KeyCode <= Keys.NumPad0 && e.KeyCode >= Keys.NumPad9 &&
                e.KeyCode != Keys.Oemcomma && e.KeyCode != Keys.OemPeriod && e.KeyCode != Keys.Decimal)
            ) {
                clearText(str);
            }
            else
            {
                bool isNumeric = double.TryParse(((TextBox)sender).Text.Replace('.', ','), out double val);

                if (isNumeric)
                {
                    calculations(str, val);
                }
                else
                {
                    clearText(str);
                }
            }
        }

        private void calculations(string field, double value)
        {
            double dirty, ndfl, vz, esv, clear, sumDirtyEsv;

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

            if (checkBox2.Checked)
            {
                dirty = roundNum(dirty);
                ndfl = roundNum(dirty * koefNDFL);
                vz = roundNum(dirty * koefVZ);
                esv = roundNum(dirty * koefESV);
                clear = roundNum(dirty - (dirty * koefNDFL) - (dirty * koefVZ));
                sumDirtyEsv = roundNum(dirty + (dirty * koefESV));
            }
            else
            {
                ndfl = dirty * koefNDFL;
                vz = dirty * koefVZ;
                esv = dirty * koefESV;
                clear = dirty - ndfl - vz;
                sumDirtyEsv = dirty + esv;
            }
            
            if ( ! field.Equals("textBox1") )
            {
                textBox1.Text = string.Format("{0:#,##0.##}", dirty);
            }

            if ( ! field.Equals("textBox2") )
            {
                textBox2.Text = string.Format("{0:#,##0.##}", ndfl);
            }

            if ( ! field.Equals("textBox3") )
            {
                textBox3.Text = string.Format("{0:#,##0.##}", vz);
            }

            if ( ! field.Equals("textBox4") )
            {
                textBox4.Text = string.Format("{0:#,##0.##}", esv);
            }

            if ( ! field.Equals("textBox5") )
            {
                textBox5.Text = string.Format("{0:#,##0.##}", clear);
            }
            
            textBox6.Text = string.Format("{0:#,##0.##}", sumDirtyEsv);
        }

        private double roundNum(double num)
        {
            return Math.Ceiling(num * 100) / 100;
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
