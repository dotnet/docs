using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GetData2
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
            GetData2();

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
        private void GetData2() 
        {
            // Creates a component.
            Component myComponent = new Component();
 
            // Creates a data object, and assigns it the component.
            DataObject myDataObject = new DataObject(myComponent);
 
            // Creates a type, myType, to store the type of data.
            Type myType = myComponent.GetType();
 
            // Retrieves the data using myType to represent its type.
            Object myObject = myDataObject.GetData(myType);
            if(myObject != null)
                MessageBox.Show("The data type stored in the data object is " +
                    myObject.GetType().Name + ".");
            else
                MessageBox.Show("Data of the specified type was not stored " +
                    "in the data object.");
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
