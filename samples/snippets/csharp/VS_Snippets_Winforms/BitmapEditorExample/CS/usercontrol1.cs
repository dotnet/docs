using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Windows.Forms;

namespace BitmapEditorExample
{
	public class UserControl1 : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.Container components = null;

        //<Snippet1>
        [EditorAttribute(typeof(System.Drawing.Design.BitmapEditor), 
            typeof(System.Drawing.Design.UITypeEditor))]
        public Bitmap testBitmap
        {
            get
            {
                return testBmp;
            }
            set
            {
                testBmp = value;
            }
        }
        private Bitmap testBmp;
        //</Snippet1>

		public UserControl1()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
