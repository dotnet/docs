using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SetData4
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
            SetData4();

            //
            // TODO: Adds any constructor code after InitializeComponent call
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
            this.ClientSize = new System.Drawing.Size(292, 276);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        // <snippet1>
        private void SetData4() 
        {
            // Creates a new data object.
            DataObject myDataObject = new DataObject();
 
            // Adds UnicodeText string to the object, and set the autoConvert 
            // parameter to false.
            myDataObject.SetData(DataFormats.UnicodeText, false, "My text string");
 
            // Gets the data format(s) in the data object.
            String[] arrayOfFormats = myDataObject.GetFormats();
 
            // Stores the results in a string.
            string theResult = "The format(s) associated with the data are:" + '\n';
            for(int i=0; i<arrayOfFormats.Length; i++)
                theResult += arrayOfFormats[i] + '\n';
            
            // Show the results in a message box. 
            MessageBox.Show(theResult);

        }
        // </snippet1>

        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        
        }
    }
}
