using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Control.DoubleClick
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // listBox1
            //
            this.listBox1.Items.AddRange(new object[] {
                                                          "C:\\Windows\\Windows Update.log"});
            this.listBox1.Location = new System.Drawing.Point(32, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 108);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(32, 144);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(448, 240);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "textBox1";
            //
            // Form1
            //
            this.ClientSize = new System.Drawing.Size(520, 446);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBox1,
                                                                          this.listBox1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

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


        //<Snippet1>
        // This example uses the DoubleClick event of a ListBox to load text files
        // listed in the ListBox into a TextBox control. This example
        // assumes that the ListBox, named listBox1, contains a list of valid file
        // names with path and that this event handler method
        // is connected to the DoublClick event of a ListBox control named listBox1.
        // This example requires code access permission to access files.
        private void listBox1_DoubleClick(object sender, System.EventArgs e)
        {
            // Get the name of the file to open from the ListBox.
            String file = listBox1.SelectedItem.ToString();

            try
            {
                // Determine if the file exists before loading.
                if (System.IO.File.Exists(file))
                {
                    // Open the file and use a TextReader to read the contents into the TextBox.
                    System.IO.FileInfo myFile = new System.IO.FileInfo(listBox1.SelectedItem.ToString());
                    System.IO.TextReader myData = myFile.OpenText();;

                    textBox1.Text = myData.ReadToEnd();
                    myData.Close();
                }
            }
                // Exception is thrown by the OpenText method of the FileInfo class.
            catch(System.IO.FileNotFoundException)
            {
                MessageBox.Show("The file you specified does not exist.");
            }
                // Exception is thrown by the ReadToEnd method of the TextReader class.
            catch(System.IO.IOException)
            {
                MessageBox.Show("There was a problem loading the file into the TextBox. Ensure that the file is a valid text file.");
            }
        }
        //</Snippet1>
    }
}
