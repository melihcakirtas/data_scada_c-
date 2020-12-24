namespace Al_Ba
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dmon = new System.Windows.Forms.Button();
            this.set = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dmon_pnl = new System.Windows.Forms.Panel();
            this.help1 = new Al_Ba.help();
            this.dmon1 = new Al_Ba.dmon();
            this.set1 = new Al_Ba.set();
            this.log1 = new Al_Ba.log();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dmon_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(236, 554);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // dmon
            // 
            this.dmon.BackColor = System.Drawing.Color.Maroon;
            this.dmon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dmon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dmon.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.dmon.Location = new System.Drawing.Point(0, 147);
            this.dmon.Name = "dmon";
            this.dmon.Size = new System.Drawing.Size(236, 70);
            this.dmon.TabIndex = 1;
            this.dmon.Text = "Data Monitor";
            this.dmon.UseVisualStyleBackColor = false;
            this.dmon.Click += new System.EventHandler(this.Dmon_Click);
            // 
            // set
            // 
            this.set.BackColor = System.Drawing.Color.Maroon;
            this.set.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.set.Location = new System.Drawing.Point(0, 223);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(236, 70);
            this.set.TabIndex = 1;
            this.set.Text = "Settings";
            this.set.UseVisualStyleBackColor = false;
            this.set.Click += new System.EventHandler(this.Set_Click);
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.Maroon;
            this.log.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.log.Location = new System.Drawing.Point(0, 299);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(236, 70);
            this.log.TabIndex = 1;
            this.log.Text = "Log";
            this.log.UseVisualStyleBackColor = false;
            this.log.Click += new System.EventHandler(this.Log_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Maroon;
            this.help.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.help.ForeColor = System.Drawing.SystemColors.ControlText;
            this.help.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.help.Location = new System.Drawing.Point(0, 375);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(236, 70);
            this.help.TabIndex = 1;
            this.help.Text = "Help";
            this.help.UseVisualStyleBackColor = false;
            this.help.Click += new System.EventHandler(this.Help_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(236, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 45);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel2_MouseMove);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Al_Ba.Properties.Resources.minus;
            this.pictureBox3.Location = new System.Drawing.Point(549, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Al_Ba.Properties.Resources.cancel;
            this.pictureBox1.Location = new System.Drawing.Point(586, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // dmon_pnl
            // 
            this.dmon_pnl.Controls.Add(this.help1);
            this.dmon_pnl.Controls.Add(this.dmon1);
            this.dmon_pnl.Controls.Add(this.set1);
            this.dmon_pnl.Controls.Add(this.log1);
            this.dmon_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dmon_pnl.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dmon_pnl.Location = new System.Drawing.Point(236, 40);
            this.dmon_pnl.Name = "dmon_pnl";
            this.dmon_pnl.Size = new System.Drawing.Size(617, 514);
            this.dmon_pnl.TabIndex = 4;
            // 
            // help1
            // 
            this.help1.BackColor = System.Drawing.Color.White;
            this.help1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.help1.Location = new System.Drawing.Point(0, 0);
            this.help1.Margin = new System.Windows.Forms.Padding(4);
            this.help1.Name = "help1";
            this.help1.Size = new System.Drawing.Size(617, 514);
            this.help1.TabIndex = 3;
            // 
            // dmon1
            // 
            this.dmon1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dmon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dmon1.Location = new System.Drawing.Point(0, 0);
            this.dmon1.Margin = new System.Windows.Forms.Padding(4);
            this.dmon1.Name = "dmon1";
            this.dmon1.Size = new System.Drawing.Size(617, 514);
            this.dmon1.TabIndex = 0;
            // 
            // set1
            // 
            this.set1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.set1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.set1.Location = new System.Drawing.Point(0, 0);
            this.set1.Margin = new System.Windows.Forms.Padding(4);
            this.set1.Name = "set1";
            this.set1.Size = new System.Drawing.Size(617, 514);
            this.set1.TabIndex = 1;
            // 
            // log1
            // 
            this.log1.AutoScroll = true;
            this.log1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.log1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold);
            this.log1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.log1.Location = new System.Drawing.Point(0, 0);
            this.log1.Margin = new System.Windows.Forms.Padding(4);
            this.log1.Name = "log1";
            this.log1.Size = new System.Drawing.Size(617, 514);
            this.log1.TabIndex = 4;
            this.log1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(48, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start System";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(59, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(111, 97);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.PictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.PictureBox2_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(853, 554);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.dmon_pnl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.help);
            this.Controls.Add(this.log);
            this.Controls.Add(this.set);
            this.Controls.Add(this.dmon);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dmon_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button dmon;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.Button log;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel dmon_pnl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private dmon dmon1;
        private set set1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private help help1;
        public log log1;
        private System.Windows.Forms.Timer timer1;
    }
}

