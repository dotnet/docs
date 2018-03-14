using System;
using System.Drawing;
using System.ComponentModel;
using System.Media;
using System.Windows.Forms;

namespace SystemSoundExamples
{
    public class Form1 : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            InitializeComponent();
        }

        public void PlayAsterisk()
        {
            //<Snippet1>
            // Plays the sound associated with the Asterisk system event.
            SystemSounds.Asterisk.Play();
            //</Snippet1>                        
        }

        public void PlayBeep()
        {
            //<Snippet2>
            // Plays the sound associated with the Beep system event.
            SystemSounds.Beep.Play();
            //</Snippet2>                        
        }
        
        public void PlayExclamation()
        {
            //<Snippet3>
            // Plays the sound associated with the Exclamation system event.
            SystemSounds.Exclamation.Play();
            //</Snippet3>                        
        }
        
        public void PlayHand()
        {
            //<Snippet4>
            // Plays the sound associated with the Hand system event.
            SystemSounds.Hand.Play();
            //</Snippet4>                        
        }
        
        public void PlayQuestion()
        {
            //<Snippet5>
            // Plays the sound associated with the Question system event.
            SystemSounds.Question.Play();
            //</Snippet5>                        
        }
        
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(300,300);
            this.Text = "Form1";
        }
        #endregion

        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }
    }
}
