using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// <Snippet1>
using System.Data.SqlClient;

namespace Microsoft.AdoDotNet.CodeSamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Hook up the form's Load event handler (you can double-click on 
        // the form's design surface in Visual Studio), and then add 
        // this code to the form's class:

        // You need this delegate in order to fill the grid from
        // a thread other than the form's thread. See the HandleCallback
        // procedure for more information.
        private delegate void FillGridDelegate(SqlDataReader reader);

        // You need this delegate to update the status bar.
        private delegate void DisplayStatusDelegate(string Text);

        // This flag ensures that the user does not attempt
        // to restart the command or close the form while the 
        // asynchronous command is executing.
        private bool isExecuting = false;

        // Because the overloaded version of BeginExecuteReader
        // demonstrated here does not allow you to have the connection
        // closed automatically, this example maintains the 
        // connection object externally, so that it is available for closing.
        private SqlConnection connection = null;

        private void DisplayStatus(string Text)
        {
            this.label1.Text = Text;
        }

        private void FillGrid(SqlDataReader reader)
        {
            try
            {
                DataTable table = new DataTable();
                table.Load(reader);
                this.dataGridView1.DataSource = table;
                DisplayStatus("Ready");
            }
            catch (Exception ex)
            {
                // Because you are guaranteed this procedure
                // is running from within the form's thread,
                // it can directly interact with members of the form.
                DisplayStatus(string.Format("Ready (last attempt failed: {0})",
                    ex.Message));
            }
            finally
            {
                // Do not forget to close the connection, as well.
                if (reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void HandleCallback(IAsyncResult result)
        {
            try
            {
                // Retrieve the original command object, passed
                // to this procedure in the AsyncState property
                // of the IAsyncResult parameter.
                SqlCommand command = (SqlCommand)result.AsyncState;
                SqlDataReader reader = command.EndExecuteReader(result);
                // You may not interact with the form and its contents
                // from a different thread, and this callback procedure
                // is all but guaranteed to be running from a different thread
                // than the form. Therefore you cannot simply call code that 
                // fills the grid, like this:
                // FillGrid(reader);
                // Instead, you must call the procedure from the form's thread.
                // One simple way to accomplish this is to call the Invoke
                // method of the form, which calls the delegate you supply
                // from the form's thread. 
                FillGridDelegate del = new FillGridDelegate(FillGrid);
                this.Invoke(del, reader);
                // Do not close the reader here, because it is being used in 
                // a separate thread. Instead, have the procedure you have
                // called close the reader once it is done with it.
            }
            catch (Exception ex)
            {
                // Because you are now running code in a separate thread, 
                // if you do not handle the exception here, none of your other
                // code catches the exception. Because there is none of 
                // your code on the call stack in this thread, there is nothing
                // higher up the stack to catch the exception if you do not 
                // handle it here. You can either log the exception or 
                // invoke a delegate (as in the non-error case in this 
                // example) to display the error on the form. In no case
                // can you simply display the error without executing a delegate
                // as in the try block here. 
                // You can create the delegate instance as you 
                // invoke it, like this:
                this.Invoke(new DisplayStatusDelegate(DisplayStatus),
                    "Error: " + ex.Message);
            }
            finally
            {
                isExecuting = false;
            }
        }

        private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file. 

            // If you do not include the Asynchronous Processing=true name/value pair,
            // you wo not be able to execute the command asynchronously.
            return "Data Source=(local);Integrated Security=true;" +
                "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (isExecuting)
            {
                MessageBox.Show(this,
                    "Already executing. Please wait until the current query " +
                    "has completed.");
            }
            else
            {
                SqlCommand command = null;
                try
                {
                    DisplayStatus("Connecting...");
                    connection = new SqlConnection(GetConnectionString());
                    // To emulate a long-running query, wait for 
                    // a few seconds before retrieving the real data.
                    command = new SqlCommand("WAITFOR DELAY '0:0:5';" +
                        "SELECT ProductID, Name, ListPrice, Weight FROM Production.Product",
                        connection);
                    connection.Open();

                    DisplayStatus("Executing...");
                    isExecuting = true;
                    // Although it is not required that you pass the 
                    // SqlCommand object as the second parameter in the 
                    // BeginExecuteReader call, doing so makes it easier
                    // to call EndExecuteReader in the callback procedure.
                    AsyncCallback callback = new AsyncCallback(HandleCallback);
                    command.BeginExecuteReader(callback, command);
                }
                catch (Exception ex)
                {
                    DisplayStatus("Error: " + ex.Message);
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExecuting)
            {
                MessageBox.Show(this, "Cannot close the form until " +
                    "the pending asynchronous command has completed. Please wait...");
                e.Cancel = true;
            }
        }
    }
}
// </Snippet1>
