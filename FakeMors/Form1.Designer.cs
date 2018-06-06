namespace FakeMors
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonPlayBeep = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dźwiękToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wykresikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Image = global::FakeMors.Properties.Resources.right;
            this.button1.Location = new System.Drawing.Point(310, 64);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(103, 46);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 220);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(209, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(444, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Morse";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox2.Location = new System.Drawing.Point(450, 64);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(260, 220);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Image = global::FakeMors.Properties.Resources.left;
            this.button2.Location = new System.Drawing.Point(310, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 56);
            this.button2.TabIndex = 6;
            this.button2.Text = "<<";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button2_MouseUp);
            // 
            // ButtonPlayBeep
            // 
            this.ButtonPlayBeep.BackColor = System.Drawing.Color.White;
            this.ButtonPlayBeep.BackgroundImage = global::FakeMors.Properties.Resources.maleplays3x;
            this.ButtonPlayBeep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonPlayBeep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ButtonPlayBeep.ImageKey = "(none)";
            this.ButtonPlayBeep.Location = new System.Drawing.Point(310, 116);
            this.ButtonPlayBeep.Name = "ButtonPlayBeep";
            this.ButtonPlayBeep.Size = new System.Drawing.Size(103, 106);
            this.ButtonPlayBeep.TabIndex = 7;
            this.ButtonPlayBeep.UseVisualStyleBackColor = false;
            this.ButtonPlayBeep.BackgroundImageChanged += new System.EventHandler(this.ButtonPlayBeep_Click);
            this.ButtonPlayBeep.Click += new System.EventHandler(this.ButtonPlayBeep_Click);
            this.ButtonPlayBeep.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonPlayBeep_MouseDown);
            this.ButtonPlayBeep.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonPlayBeep_Mouseup);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.opcjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // opcjeToolStripMenuItem
            // 
            this.opcjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dźwiękToolStripMenuItem,
            this.wykresikToolStripMenuItem});
            this.opcjeToolStripMenuItem.Name = "opcjeToolStripMenuItem";
            this.opcjeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.opcjeToolStripMenuItem.Text = "Opcje";
            // 
            // dźwiękToolStripMenuItem
            // 
            this.dźwiękToolStripMenuItem.Name = "dźwiękToolStripMenuItem";
            this.dźwiękToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.dźwiękToolStripMenuItem.Text = "Dźwięk";
            this.dźwiękToolStripMenuItem.Click += new System.EventHandler(this.dźwiękToolStripMenuItem_Click);
            // 
            // wykresikToolStripMenuItem
            // 
            this.wykresikToolStripMenuItem.Name = "wykresikToolStripMenuItem";
            this.wykresikToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.wykresikToolStripMenuItem.Text = "Wykresik";
            this.wykresikToolStripMenuItem.Click += new System.EventHandler(this.wykresikToolStripMenuItem_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRecord.BackgroundImage = global::FakeMors.Properties.Resources.tło;
            this.buttonRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRecord.Image = global::FakeMors.Properties.Resources.recordb;
            this.buttonRecord.Location = new System.Drawing.Point(16, 31);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(37, 30);
            this.buttonRecord.TabIndex = 9;
<<<<<<< HEAD
=======
            this.buttonRecord.TabStop = false;
>>>>>>> 818ee702af26240af9675d03a5395d23a6ca73d1
            this.buttonRecord.UseVisualStyleBackColor = false;
            this.buttonRecord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRecord_MouseDown);
            this.buttonRecord.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRecord_MouseUp);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonStop.BackgroundImage = global::FakeMors.Properties.Resources.background;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonStop.Image = global::FakeMors.Properties.Resources.stop;
<<<<<<< HEAD
            this.buttonStop.Location = new System.Drawing.Point(59, 29);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(32, 34);
=======
            this.buttonStop.Location = new System.Drawing.Point(24, 48);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(56, 46);
>>>>>>> 818ee702af26240af9675d03a5395d23a6ca73d1
            this.buttonStop.TabIndex = 10;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Visible = false;
            this.buttonStop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonStop_MouseDown);
            this.buttonStop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonStop_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(728, 328);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.ButtonPlayBeep);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FakeMORS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ButtonPlayBeep;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dźwiękToolStripMenuItem;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ToolStripMenuItem wykresikToolStripMenuItem;
    }
}

