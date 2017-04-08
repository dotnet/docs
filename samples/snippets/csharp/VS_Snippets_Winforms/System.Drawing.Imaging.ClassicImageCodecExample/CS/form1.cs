using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.Imaging.ClassicImageCodecInfoCS
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
		}
		#endregion


        // Snippet for: M:System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders
        // <snippet1>
        private void GetImageEncodersExample(PaintEventArgs e)
        {
                     
            // Get an array of available codecs.
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageEncoders();
            int numCodecs = myCodecs.GetLength(0);
                     
            //numCodecs = 1;
                     
            // Set up display variables.
            Color foreColor = Color.Black;
            Font font = new Font("Arial", 8);
            int i = 0;
                     
            // Check to determine whether any codecs were found.
            if(numCodecs > 0)
            {
                     
                // Set up an array to hold codec information. There are 9
                     
                // information elements plus 1 space for each codec, so 10 times
                     
                // the number of codecs found is allocated.
                string[] myCodecInfo = new string[numCodecs*10];
                     
                // Write all the codec information to the array.
                for(i=0;i<numCodecs;i++)
                {
                    myCodecInfo[i*10] = "Codec Name = " + myCodecs[i].CodecName;
                    myCodecInfo[(i*10)+1] = "Class ID = " +
                        myCodecs[i].Clsid.ToString();
                    myCodecInfo[(i*10)+2] = "DLL Name = " + myCodecs[i].DllName;
                    myCodecInfo[(i*10)+3] = "Filename Ext. = " +
                        myCodecs[i].FilenameExtension;
                    myCodecInfo[(i*10)+4] = "Flags = " +
                        myCodecs[i].Flags.ToString();
                    myCodecInfo[(i*10)+5] = "Format Descrip. = " +
                        myCodecs[i].FormatDescription;
                    myCodecInfo[(i*10)+6] = "Format ID = " +
                        myCodecs[i].FormatID.ToString();
                    myCodecInfo[(i*10)+7] = "MimeType = " + myCodecs[i].MimeType;
                    myCodecInfo[(i*10)+8] = "Version = " +
                        myCodecs[i].Version.ToString();
                    myCodecInfo[(i*10)+9] = " ";
                }
                int numMyCodecInfo = myCodecInfo.GetLength(0);
                     
                // Render all of the information to the screen.
                int j=20;
                for(i=0;i<numMyCodecInfo;i++)
                {
                    e.Graphics.DrawString(myCodecInfo[i],
                        font,
                        new SolidBrush(foreColor),
                        20,
                        j);
                    j+=12;
                }
            }
            else
                e.Graphics.DrawString("No Codecs Found",
                    font,
                    new SolidBrush(foreColor),
                    20,
                    20);
        }
        // </snippet1>

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
