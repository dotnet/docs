using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GedDataPresent1
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            InitializeComponent();
            TestDataObject();
        }
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

        [STAThread]
        // <snippet1>
        private void TestDataObject() 
        {
            // Creates a new data object using a string and the Text format.
            string myString = "Hello World!";
            DataObject myDataObject = new DataObject(DataFormats.Text, myString);
 
            // Checks whether the data is present in the Text format and displays the result.
            if (myDataObject.GetDataPresent(DataFormats.Text))
                MessageBox.Show("The stored data is in the Text format." , "Test Result");
            else
                MessageBox.Show("The stored data is not in the Text format.", "Test Result");
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
