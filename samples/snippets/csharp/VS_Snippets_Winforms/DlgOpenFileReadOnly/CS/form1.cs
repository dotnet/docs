using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Security;

namespace DlgOpenFileReadOnly_CS
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
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            OpenFile();
        
        }

    //<snippet1>
    private FileStream OpenFile()
    {
        // Displays an OpenFileDialog and shows the read/only files.

        OpenFileDialog dlgOpenFile = new OpenFileDialog();
        dlgOpenFile.ShowReadOnly = true;


        if(dlgOpenFile.ShowDialog() == DialogResult.OK)
        {

            // If ReadOnlyChecked is true, uses the OpenFile method to
            // open the file with read/only access.
            string path = null;

            try {
                if(dlgOpenFile.ReadOnlyChecked == true)
                {
                    return (FileStream)dlgOpenFile.OpenFile();
                }

                // Otherwise, opens the file with read/write access.
                else
                {
                    path = dlgOpenFile.FileName;
                    return new FileStream(path, System.IO.FileMode.Open,
                                System.IO.FileAccess.ReadWrite);
                }
            } catch (SecurityException ex)
                {
                    // The user lacks appropriate permissions to read files, discover paths, etc.
                    MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                        "Error message: " + ex.Message + "\n\n" +
                        "Details (send to Support):\n\n" + ex.StackTrace
                    );
                }
                catch (Exception ex)
                {
                    // Could not load the image - probably related to Windows file system permissions.
                    MessageBox.Show("Cannot display the image: " + path.Substring(path.LastIndexOf('\\'))
                        + ". You may not have permission to read the file, or " +
                        "it may be corrupt.\n\nReported error: " + ex.Message);
                }
        }

        return null;
    }

    //</snippet1>
    }
}
