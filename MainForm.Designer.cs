
namespace ProductionSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textOutput = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.checkListFeatures = new System.Windows.Forms.CheckedListBox();
            this.rbForward = new System.Windows.Forms.RadioButton();
            this.rbBackward = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkListPrice = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkListLocation = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkListDrinks = new System.Windows.Forms.CheckedListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkListCompany = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.textOutput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 546);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(995, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вывод";
            // 
            // textOutput
            // 
            this.textOutput.BackColor = System.Drawing.Color.White;
            this.textOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textOutput.Location = new System.Drawing.Point(3, 27);
            this.textOutput.Margin = new System.Windows.Forms.Padding(5);
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.ShortcutsEnabled = false;
            this.textOutput.Size = new System.Drawing.Size(989, 368);
            this.textOutput.TabIndex = 0;
            this.textOutput.TabStop = false;
            this.textOutput.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(741, 497);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(242, 43);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Запустить вывод";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // checkListFeatures
            // 
            this.checkListFeatures.ColumnWidth = 350;
            this.checkListFeatures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkListFeatures.FormattingEnabled = true;
            this.checkListFeatures.Location = new System.Drawing.Point(3, 27);
            this.checkListFeatures.MultiColumn = true;
            this.checkListFeatures.Name = "checkListFeatures";
            this.checkListFeatures.Size = new System.Drawing.Size(965, 137);
            this.checkListFeatures.TabIndex = 2;
            this.checkListFeatures.ThreeDCheckBoxes = true;
            // 
            // rbForward
            // 
            this.rbForward.AutoSize = true;
            this.rbForward.Checked = true;
            this.rbForward.Location = new System.Drawing.Point(505, 504);
            this.rbForward.Name = "rbForward";
            this.rbForward.Size = new System.Drawing.Size(104, 29);
            this.rbForward.TabIndex = 4;
            this.rbForward.TabStop = true;
            this.rbForward.Text = "Прямой";
            this.rbForward.UseVisualStyleBackColor = true;
            // 
            // rbBackward
            // 
            this.rbBackward.AutoSize = true;
            this.rbBackward.Location = new System.Drawing.Point(615, 504);
            this.rbBackward.Name = "rbBackward";
            this.rbBackward.Size = new System.Drawing.Size(121, 29);
            this.rbBackward.TabIndex = 4;
            this.rbBackward.Text = "Обратный";
            this.rbBackward.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkListFeatures);
            this.groupBox2.Location = new System.Drawing.Point(12, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(971, 167);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фишечки";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkListPrice);
            this.groupBox3.Location = new System.Drawing.Point(502, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 150);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Бюджет*";
            // 
            // checkListPrice
            // 
            this.checkListPrice.CheckOnClick = true;
            this.checkListPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkListPrice.FormattingEnabled = true;
            this.checkListPrice.Location = new System.Drawing.Point(3, 27);
            this.checkListPrice.Name = "checkListPrice";
            this.checkListPrice.Size = new System.Drawing.Size(475, 120);
            this.checkListPrice.TabIndex = 2;
            this.checkListPrice.ThreeDCheckBoxes = true;
            this.checkListPrice.SelectedIndexChanged += new System.EventHandler(this.checkListPrice_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkListLocation);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(481, 150);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Место*";
            // 
            // checkListLocation
            // 
            this.checkListLocation.CheckOnClick = true;
            this.checkListLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkListLocation.FormattingEnabled = true;
            this.checkListLocation.Location = new System.Drawing.Point(3, 27);
            this.checkListLocation.Name = "checkListLocation";
            this.checkListLocation.Size = new System.Drawing.Size(475, 120);
            this.checkListLocation.TabIndex = 2;
            this.checkListLocation.ThreeDCheckBoxes = true;
            this.checkListLocation.SelectedIndexChanged += new System.EventHandler(this.checkListLocation_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkListDrinks);
            this.groupBox5.Location = new System.Drawing.Point(12, 168);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(481, 150);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Вид напитков*";
            // 
            // checkListDrinks
            // 
            this.checkListDrinks.CheckOnClick = true;
            this.checkListDrinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkListDrinks.FormattingEnabled = true;
            this.checkListDrinks.Location = new System.Drawing.Point(3, 27);
            this.checkListDrinks.Name = "checkListDrinks";
            this.checkListDrinks.Size = new System.Drawing.Size(475, 120);
            this.checkListDrinks.TabIndex = 2;
            this.checkListDrinks.ThreeDCheckBoxes = true;
            this.checkListDrinks.SelectedIndexChanged += new System.EventHandler(this.checkListDrinks_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkListCompany);
            this.groupBox6.Location = new System.Drawing.Point(502, 168);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(481, 150);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Размер компании*";
            // 
            // checkListCompany
            // 
            this.checkListCompany.CheckOnClick = true;
            this.checkListCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkListCompany.FormattingEnabled = true;
            this.checkListCompany.Location = new System.Drawing.Point(3, 27);
            this.checkListCompany.Name = "checkListCompany";
            this.checkListCompany.Size = new System.Drawing.Size(475, 120);
            this.checkListCompany.TabIndex = 2;
            this.checkListCompany.ThreeDCheckBoxes = true;
            this.checkListCompany.SelectedIndexChanged += new System.EventHandler(this.checkListCompany_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 944);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rbBackward);
            this.Controls.Add(this.rbForward);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Продукционная система";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox textOutput;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckedListBox checkListFeatures;
        private System.Windows.Forms.RadioButton rbForward;
        private System.Windows.Forms.RadioButton rbBackward;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox checkListPrice;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox checkListLocation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox checkListDrinks;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox checkListCompany;
    }
}

