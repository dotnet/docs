using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GetData3
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
            GetData3();

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
        private void GetData3() 
        {
            // Creates a new data object using a text string.
            string myString = "Hello World!";
            DataObject myDataObject = new DataObject(DataFormats.Text, myString);
 
            // Displays the string with autoConvert equal to false.
            if (myDataObject.GetData("System.String", false) != null) 
            {
                // Displays the string in a message box.
                MessageBox.Show(myDataObject.GetData("System.String", false).ToString() + ".", "Message #1");
            } 
            else
                // Displays a not found message in a message box.
                MessageBox.Show("Could not find data of the specified format.", "Message #1");
 
            // Displays the string in a text box with autoConvert equal to true.
            string myData = "The data is " + myDataObject.GetData("System.String", true).ToString() +".";
            MessageBox.Show(myData,"Message #2");
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
