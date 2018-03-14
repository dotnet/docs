using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace WindowsApplication42
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
			
			// sound1
			this.Player.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.Player_LoadCompleted);
			
		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		
		
		//<Snippet1>
		private SoundPlayer Player = new SoundPlayer();
		private void loadSoundAsync()
		{
			// Note: You may need to change the location specified based on
			// the location of the sound to be played.
			this.Player.SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav";
			this.Player.LoadAsync();
		}
		
		private void Player_LoadCompleted (
            object sender, 
            System.ComponentModel.AsyncCompletedEventArgs e)
		{
		    if (this.Player.IsLoadCompleted)
		    {
		        this.Player.PlaySync();
		    }
		}
		//</Snippet1>

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
