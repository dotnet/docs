// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace SoundPlayerPlayLoopingExample
{
    public class Form1 : Form
    {
        private SoundPlayer Player = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void playLoopingButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Note: You may need to change the location specified based on
                // the sounds loaded on your computer.
                this.Player.SoundLocation = @"C:\Windows\Media\chimes.wav";
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }
        }

        private void stopPlayingButton_Click(object sender, EventArgs e)
        {
            this.Player.Stop();
        }

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
            this.playLoopingButton = new System.Windows.Forms.Button();
            this.stopPlayingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playLoopingButton
            // 
            this.playLoopingButton.Location = new System.Drawing.Point(12, 12);
            this.playLoopingButton.Name = "playLoopingButton";
            this.playLoopingButton.Size = new System.Drawing.Size(87, 23);
            this.playLoopingButton.TabIndex = 0;
            this.playLoopingButton.Text = "Play Looping";
            this.playLoopingButton.UseVisualStyleBackColor = true;
            this.playLoopingButton.Click += new System.EventHandler(this.playLoopingButton_Click);
            // 
            // stopPlayingButton
            // 
            this.stopPlayingButton.Location = new System.Drawing.Point(105, 12);
            this.stopPlayingButton.Name = "stopPlayingButton";
            this.stopPlayingButton.Size = new System.Drawing.Size(75, 23);
            this.stopPlayingButton.TabIndex = 1;
            this.stopPlayingButton.Text = "Stop";
            this.stopPlayingButton.UseVisualStyleBackColor = true;
            this.stopPlayingButton.Click += new System.EventHandler(this.stopPlayingButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 51);
            this.Controls.Add(this.stopPlayingButton);
            this.Controls.Add(this.playLoopingButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playLoopingButton;
        private System.Windows.Forms.Button stopPlayingButton;
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
// </snippet1>