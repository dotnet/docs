//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomCursor
{
    public class Form1 : System.Windows.Forms.Form
    {
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Text = "Cursor Example";
            
            // The following generates a cursor from an embedded resource.
            
            // To add a custom cursor, create a bitmap
            //        1. Add a new cursor file to your project: 
            //                Project->Add New Item->General->Cursor File

            // --- To make the custom cursor an embedded resource  ---
            
            // In Visual Studio:
            //        1. Select the cursor file in the Solution Explorer
            //        2. Choose View->Properties.
            //        3. In the properties window switch "Build Action" to "Embedded Resources"

            // On the command line:
            //        Add the following flag:
            //            /res:CursorFileName.cur,Namespace.CursorFileName.cur
            //        
            //        Where "Namespace" is the namespace in which you want to use the cursor
            //        and   "CursorFileName.cur" is the cursor filename.

            // The following line uses the namespace from the passed-in type
            // and looks for CustomCursor.MyCursor.Cur in the assemblies manifest.
	    // NOTE: The cursor name is acase sensitive.
            this.Cursor = new Cursor(GetType(), "MyCursor.cur");  
           
        }
    }
}
//</Snippet1>