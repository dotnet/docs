using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BalloonTip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetBalloonTip();
            this.Click += new EventHandler(Form1_Click);
            this.DoubleClick += new EventHandler(Form1_DoubleClick);
            this.notifyIcon1.BalloonTipClosed += new EventHandler(notifyIcon1_BalloonTipClosed);
        }
     //<snippet1>
        void Form1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(20000, "Information", "This is the text",
                ToolTipIcon.Info );
        }
        //</snippet1>
        //<snippet2>
        private void SetBalloonTip()
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = "Balloon Tip Text.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            this.Click += new EventHandler(Form1_Click);
        }
        
        void Form1_Click(object sender, EventArgs e) 
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);

        }
        //</snippet2>

        //<snippet4>
        void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            MessageBox.Show("The balloon tip is now closed.");
        }
        //</snippet4>

      

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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
          
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Visible = true;
            // 
           
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        } 
    }
}