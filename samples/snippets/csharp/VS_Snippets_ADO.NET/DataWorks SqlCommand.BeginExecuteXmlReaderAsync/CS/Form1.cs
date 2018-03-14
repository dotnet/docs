using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// <Snippet1>
using System.Data.SqlClient;
using System.Xml;

namespace Microsoft.AdoDotNet.CodeSamples
{
    public partial class Form1 : Form
    {
        // Hook up the form's Load event handler and then add 
        // this code to the form's class:
        // You need these delegates in order to display text from a thread
        // other than the form's thread. See the HandleCallback
        // procedure for more information.
        private delegate void DisplayInfoDelegate(string Text);
        private delegate void DisplayReaderDelegate(XmlReader reader);

        private bool isExecuting;

        // This example maintains the connection object 
        // externally, so that it is available for closing.
        private SqlConnection connection;

        public Form1()
        {
            InitializeComponent();
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

        private void DisplayStatus(string Text)
        {
            this.label1.Text = Text;
        }

        private void ClearProductInfo()
        {
            // Clear the list box.
            this.listBox1.Items.Clear();
        }

        private void DisplayProductInfo(XmlReader reader)
        {
            // Display the data within the reader.
            while (reader.Read())
            {
                // Skip past items that are not from the correct table.
                if (reader.LocalName.ToString() == "Production.Product")
                {
                    this.listBox1.Items.Add(String.Format("{0}: {1:C}",
                        reader["Name"], Convert.ToDecimal(reader["ListPrice"])));
                }
            }
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
                    ClearProductInfo();
                    DisplayStatus("Connecting...");
                    connection = new SqlConnection(GetConnectionString());

                    // To emulate a long-running query, wait for 
                    // a few seconds before working with the data.
                    string commandText =
                        "WAITFOR DELAY '00:00:03';" +
                        "SELECT Name, ListPrice FROM Production.Product " +
                        "WHERE ListPrice < 100 " +
                        "FOR XML AUTO, XMLDATA";

                    command = new SqlCommand(commandText, connection);
                    connection.Open();

                    DisplayStatus("Executing...");
                    isExecuting = true;
                    // Although it is not required that you pass the 
                    // SqlCommand object as the second parameter in the 
                    // BeginExecuteXmlReader call, doing so makes it easier
                    // to call EndExecuteXmlReader in the callback procedure.
                    AsyncCallback callback = new AsyncCallback(HandleCallback);
                    command.BeginExecuteXmlReader(callback, command);

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
                XmlReader reader = command.EndExecuteXmlReader(result);

                // You may not interact with the form and its contents
                // from a different thread, and this callback procedure
                // is all but guaranteed to be running from a different thread
                // than the form. 

                // Instead, you must call the procedure from the form's thread.
                // One simple way to accomplish this is to call the Invoke
                // method of the form, which calls the delegate you supply
                // from the form's thread. 
                DisplayReaderDelegate del = new DisplayReaderDelegate(DisplayProductInfo);
                this.Invoke(del, reader);

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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.FormClosing += new System.Windows.Forms.
                FormClosingEventHandler(this.Form1_FormClosing);
        }
    }
}
// </Snippet1>
