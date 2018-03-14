
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace CancelEdit
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        private DataView myDataView;
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBox1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            SetBinding();
            CancelEdit();
            EndEdit();
        }
        //<snippet1>
        private void CancelEdit()
        {
            // Gets the CurrencyManager which is returned when the 
            // data source is a DataView.
            BindingManagerBase myMgr = 
                (CurrencyManager) BindingContext[myDataView]; 

            // Gets the current row and changes a value. Then cancels the 
            // edit and thereby discards the changes.
            DataRowView tempRowView = (DataRowView) myMgr.Current;
            Console.WriteLine("Original: {0}", tempRowView["myCol"]);
            tempRowView["myCol"] = "These changes will be discarded";
            Console.WriteLine("Edit: {0}", tempRowView["myCol"]);
            myMgr.CancelCurrentEdit();
            Console.WriteLine("After CanceCurrentlEdit: {0}", 
                tempRowView["myCol"]);
        }

        private void EndEdit()
        {
            // Gets the CurrencyManager which is returned when the 
            // data source is a DataView.
            BindingManagerBase myMgr = 
                (CurrencyManager) BindingContext[myDataView];

            // Gets the current row and changes a value. Then ends the 
            // edit and thereby keeps the changes.
            DataRowView tempRowView = (DataRowView) myMgr.Current;
            Console.WriteLine("Original: {0}", tempRowView["myCol"]);
            tempRowView["myCol"] = "These changes will be kept";
            Console.WriteLine("Edit: {0}", tempRowView["myCol"]);
            myMgr.EndCurrentEdit();
            Console.WriteLine("After EndCurrentEdit: {0}", 
                tempRowView["myCol"]);
        }

        // </snippet1>
        private void SetBinding()
        {
            // Creates a DataView to be used as a data source. Sets the 
            // myDataView variable, defined in the form, to the DataView. 
            // Then binds the TextBox control to the DataView.
            DataTable myTable = new DataTable("myTable");
            DataColumn myCol = new DataColumn("myCol");
            myTable.Columns.Add(myCol);
            DataRow tempRow;

            tempRow = myTable.NewRow();
            tempRow["myCol"] = "Original Data";
            myTable.Rows.Add(tempRow);

            myDataView = myTable.DefaultView;
            textBox1.DataBindings.Add(
                new Binding("Text", myDataView, "myCol"));
        }


    }
}
