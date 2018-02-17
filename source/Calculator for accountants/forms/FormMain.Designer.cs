namespace Calculator_for_accountants.forms
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tDirty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tDirtyEsv = new System.Windows.Forms.TextBox();
            this.tNdfl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tVz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tEsv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tClear = new System.Windows.Forms.TextBox();
            this.fRate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(30, 187);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Топ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Location = new System.Drawing.Point(9, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "?";
            this.label10.Click += new System.EventHandler(this.Label10_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(74, 187);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(131, 17);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "Округлять гр. сумму";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // tDirty
            // 
            this.tDirty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tDirty.Location = new System.Drawing.Point(74, 12);
            this.tDirty.Name = "tDirty";
            this.tDirty.Size = new System.Drawing.Size(153, 23);
            this.tDirty.TabIndex = 23;
            this.tDirty.Leave += new System.EventHandler(this.TDirty_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(6, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = "Гр. + ЕСВ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Грязная";
            // 
            // tDirtyEsv
            // 
            this.tDirtyEsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tDirtyEsv.Location = new System.Drawing.Point(73, 157);
            this.tDirtyEsv.Name = "tDirtyEsv";
            this.tDirtyEsv.ReadOnly = true;
            this.tDirtyEsv.Size = new System.Drawing.Size(153, 23);
            this.tDirtyEsv.TabIndex = 33;
            this.tDirtyEsv.TabStop = false;
            // 
            // tNdfl
            // 
            this.tNdfl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tNdfl.Location = new System.Drawing.Point(74, 41);
            this.tNdfl.Name = "tNdfl";
            this.tNdfl.Size = new System.Drawing.Size(153, 23);
            this.tNdfl.TabIndex = 25;
            this.tNdfl.Leave += new System.EventHandler(this.TNdfl_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "НДФЛ";
            // 
            // tVz
            // 
            this.tVz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tVz.Location = new System.Drawing.Point(73, 70);
            this.tVz.Name = "tVz";
            this.tVz.Size = new System.Drawing.Size(153, 23);
            this.tVz.TabIndex = 27;
            this.tVz.Leave += new System.EventHandler(this.TVz_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(44, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "ВЗ";
            // 
            // tEsv
            // 
            this.tEsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tEsv.Location = new System.Drawing.Point(73, 99);
            this.tEsv.Name = "tEsv";
            this.tEsv.Size = new System.Drawing.Size(153, 23);
            this.tEsv.TabIndex = 29;
            this.tEsv.Leave += new System.EventHandler(this.TEsv_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(18, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "Чистая";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(36, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "ЕСВ";
            // 
            // tClear
            // 
            this.tClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tClear.Location = new System.Drawing.Point(73, 128);
            this.tClear.Name = "tClear";
            this.tClear.Size = new System.Drawing.Size(153, 23);
            this.tClear.TabIndex = 31;
            this.tClear.Leave += new System.EventHandler(this.TClear_Leave);
            // 
            // fRate
            // 
            this.fRate.Location = new System.Drawing.Point(206, 186);
            this.fRate.Name = "fRate";
            this.fRate.Size = new System.Drawing.Size(20, 20);
            this.fRate.TabIndex = 35;
            this.fRate.TextChanged += new System.EventHandler(this.FRate_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(239, 211);
            this.Controls.Add(this.fRate);
            this.Controls.Add(this.tDirty);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tDirtyEsv);
            this.Controls.Add(this.tNdfl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tVz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tEsv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tClear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tDirty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tDirtyEsv;
        private System.Windows.Forms.TextBox tNdfl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tVz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tEsv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tClear;
        private System.Windows.Forms.TextBox fRate;
    }
}

