// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AsyncPattern
{
    public class Form1 : Form
    {
        private Button loadButton;
        private Button cancelLoadButton;
        private PictureBox pictureBox1;

        // <snippet2>
        public Form1()
        {
            InitializeComponent();

            this.pictureBox1.LoadCompleted +=
                new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
        }
        // </snippet2>

        // <snippet3>
        private void loadButton_Click(object sender, EventArgs e)
        {
            // Replace with a real url.
            pictureBox1.LoadAsync("https://unsplash.com/photos/qhixfmpqN8s/download?force=true&w=1920");
        }
        // </snippet3>

        // <snippet4>
        private void cancelLoadButton_Click(object sender, EventArgs e)
        {
            pictureBox1.CancelAsync();
        }
        // </snippet4>

        // <snippet5>
        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Load Error");
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Load canceled", "Canceled");
            }
            else
            {
                MessageBox.Show("Load completed", "Completed");
            }
        }
        // </snippet5>

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.cancelLoadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            //
            // pictureBox1
            //
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            //
            // loadButton
            //
            this.loadButton.Location = new System.Drawing.Point(88, 323);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 1;
            this.loadButton.Text = "Load";
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            //
            // cancelLoadButton
            //
            this.cancelLoadButton.Location = new System.Drawing.Point(170, 323);
            this.cancelLoadButton.Name = "cancelLoadButton";
            this.cancelLoadButton.Size = new System.Drawing.Size(75, 23);
            this.cancelLoadButton.TabIndex = 2;
            this.cancelLoadButton.Text = "Cancel";
            this.cancelLoadButton.Click += new System.EventHandler(this.cancelLoadButton_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 364);
            this.Controls.Add(this.cancelLoadButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

    }
}
// </snippet1>
