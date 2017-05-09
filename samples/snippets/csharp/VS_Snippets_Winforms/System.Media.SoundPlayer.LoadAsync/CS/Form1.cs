// <snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace SoundPlayerLoadAsyncExample
{
    public class Form1 : Form
    {
        private SoundPlayer Player = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();

            this.Player.LoadCompleted += new AsyncCompletedEventHandler(Player_LoadCompleted);
        }

        private void playSoundButton_Click(object sender, EventArgs e)
        {
            this.LoadAsyncSound();
        }

        public void LoadAsyncSound()
        {
            try
            {
                // Replace this file name with a valid file name.
                this.Player.SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav";
                this.Player.LoadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading sound");
            }
        }

        // This is the event handler for the LoadCompleted event.
        void Player_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (Player.IsLoadCompleted)
            {
                try
                {
                    this.Player.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error playing sound");
                }
            }
        }

        private Button playSoundButton;

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
            this.playSoundButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playSoundButton
            // 
            this.playSoundButton.Location = new System.Drawing.Point(106, 112);
            this.playSoundButton.Name = "playSoundButton";
            this.playSoundButton.Size = new System.Drawing.Size(75, 23);
            this.playSoundButton.TabIndex = 0;
            this.playSoundButton.Text = "Play Sound";
            this.playSoundButton.Click += new System.EventHandler(this.playSoundButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.playSoundButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

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