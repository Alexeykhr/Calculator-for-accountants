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

        private double dirty;
        private double ndfl;
        private double vz;
        private double esv;
        private double clear;
        private double sumDirtyEsv;

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

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e) { }

        private void textBox5_TextChanged(object sender, EventArgs e) { }

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

        private void changeText(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char) e.KeyCode) || e.KeyCode >= Keys.NumPad0 || e.KeyCode <= Keys.NumPad9
                || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal
            ) {
                bool isNumeric = double.TryParse(((TextBox) sender).Text.Replace('.', ','), out double val);

                if (isNumeric)
                {
                    calculations(sender, val);
                }
                else
                {
                    clearText(((TextBox) sender).Name);
                }
            }
            else
            {
                clearText(((TextBox) sender).Name);
            }
        }

        private void calculations(object sender, double value)
        {
            switch (((TextBox) sender).Name)
            {
                case "textBox2":
                    this.dirty = value / koefNDFL;
                    break;
                case "textBox3":
                    this.dirty = value / koefVZ;
                    break;
                case "textBox4":
                    this.dirty = value / koefESV;
                    break;
                case "textBox5":
                    this.dirty = value / (1 - (koefNDFL + koefVZ));
                    break;
                default:
                    this.dirty = value;
                    break;
            }
            
            this.ndfl = dirty * koefNDFL;
            this.vz = dirty * koefVZ;
            this.esv = dirty * koefESV;
            this.clear = dirty - (dirty * koefNDFL) - (dirty * koefVZ);
            this.sumDirtyEsv = dirty + (dirty * koefESV);

            textBox1.Text = string.Format("{0:#,##0.##}", this.dirty);
            textBox2.Text = string.Format("{0:#,##0.##}", this.ndfl);
            textBox3.Text = string.Format("{0:#,##0.##}", this.vz);
            textBox4.Text = string.Format("{0:#,##0.##}", this.esv);
            textBox5.Text = string.Format("{0:#,##0.##}", this.clear);
            textBox6.Text = string.Format("{0:#,##0.##}", this.sumDirtyEsv);
        }
    }
}
