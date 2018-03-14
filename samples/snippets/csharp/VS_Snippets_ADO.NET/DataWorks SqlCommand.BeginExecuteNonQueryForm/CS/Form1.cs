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
        private void Form1_Load(object sender, EventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.FormClosing += new System.Windows.Forms.
                FormClosingEventHandler(this.Form1_FormClosing);

        }

        // You need this delegate in order to display text from a thread
        // other than the form's thread. See the HandleCallback
        // procedure for more information.
        // This same delegate matches both the DisplayStatus 
        // and DisplayResults methods.
        private delegate void DisplayInfoDelegate(string Text);

        // This flag ensures that the user does not attempt
        // to restart the command or close the form while the 
        // asynchronous command is executing.
        private bool isExecuting;

        // This example maintains the connection object 
        // externally, so that it is available for closing.
        private SqlConnection connection;

        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,            
            // you can retrieve it from a configuration file. 

            // If you have not included "Asynchronous Processing=true" in the
            // connection string, the command is not able
            // to execute asynchronously.
            return "Data Source=(local);Integrated Security=true;" +
                "Initial Catalog=AdventureWorks; Asynchronous Processing=true";
        }

        private void DisplayStatus(string Text)
        {
            this.label1.Text = Text;
        }

        private void DisplayResults(string Text)
        {
            this.label1.Text = Text;
            DisplayStatus("Ready");
        }

        private void Form1_FormClosing(object sender,
            System.Windows.Forms.FormClosingEventArgs e)
        {
            if (isExecuting)
            {
                MessageBox.Show(this, "Cannot close the form until " +
                    "the pending asynchronous command has completed. Please wait...");
                e.Cancel = true;
            }
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
                    DisplayResults("");
                    DisplayStatus("Connecting...");
                    connection = new SqlConnection(GetConnectionString());
                    // To emulate a long-running query, wait for 
                    // a few seconds before working with the data.
                    // This command does not do much, but that's the point--
                    // it does not change your data, in the long run.
                    string commandText =
                        "WAITFOR DELAY '0:0:05';" +
                        "UPDATE Production.Product SET ReorderPoint = ReorderPoint + 1 " +
                        "WHERE ReorderPoint Is Not Null;" +
                        "UPDATE Production.Product SET ReorderPoint = ReorderPoint - 1 " +
                        "WHERE ReorderPoint Is Not Null";

                    command = new SqlCommand(commandText, connection);
                    connection.Open();

                    DisplayStatus("Executing...");
                    isExecuting = true;
                    // Although it is not required that you pass the 
                    // SqlCommand object as the second parameter in the 
                    // BeginExecuteNonQuery call, doing so makes it easier
                    // to call EndExecuteNonQuery in the callback procedure.
                    AsyncCallback callback = new AsyncCallback(HandleCallback);
                    command.BeginExecuteNonQuery(callback, command);

                }
                catch (Exception ex)
                {
                    isExecuting = false;
                    DisplayStatus(string.Format("Ready (last error: {0})", ex.Message));
                    if (connection != null)
                    {
                        connection.Close();
                    }
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
                int rowCount = command.EndExecuteNonQuery(result);
                string rowText = " rows affected.";
                if (rowCount == 1)
                {
                    rowText = " row affected.";
                }
                rowText = rowCount + rowText;

                // You may not interact with the form and its contents
                // from a different thread, and this callback procedure
                // is all but guaranteed to be running from a different thread
                // than the form. Therefore you cannot simply call code that 
                // displays the results, like this:
                // DisplayResults(rowText)

                // Instead, you must call the procedure from the form's thread.
                // One simple way to accomplish this is to call the Invoke
                // method of the form, which calls the delegate you supply
                // from the form's thread. 
                DisplayInfoDelegate del = new DisplayInfoDelegate(DisplayResults);
                this.Invoke(del, rowText);

            }
            catch (Exception ex)
            {
                // Because you are now running code in a separate thread, 
                // if you do not handle the exception here, none of your other
                // code catches the exception. Because none of 
                // your code is on the call stack in this thread, there is nothing
                // higher up the stack to catch the exception if you do not 
                // handle it here. You can either log the exception or 
                // invoke a delegate (as in the non-error case in this 
                // example) to display the error on the form. In no case
                // can you simply display the error without executing a delegate
                // as in the try block here. 

                // You can create the delegate instance as you 
                // invoke it, like this:
                this.Invoke(new DisplayInfoDelegate(DisplayStatus),
                    String.Format("Ready(last error: {0}", ex.Message));
            }
            finally
            {
                isExecuting = false;
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
// </Snippet1>
