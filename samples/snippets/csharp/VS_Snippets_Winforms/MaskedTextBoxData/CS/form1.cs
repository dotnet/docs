//<SNIPPET1>
#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

#endregion

namespace MaskedTextBoxDataCSharp
{
    partial class Form1 : Form
    {
        Binding currentBinding, phoneBinding;
        DataSet employeesTable = new DataSet();
        SqlConnection sc;
        SqlDataAdapter dataConnect;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoMaskBinding();
        }

        private void DoMaskBinding()
        {
            try
            {
                sc = new SqlConnection("Data Source=localhost;Initial Catalog=NORTHWIND;Integrated Security=SSPI");
                sc.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            dataConnect = new SqlDataAdapter("SELECT * FROM Employees", sc);
            dataConnect.Fill(employeesTable, "Employees");

            
            // Now bind MaskedTextBox to appropriate field. Note that we must create the Binding objects
            // before adding them to the control - otherwise, we won't get a Format event on the 
            // initial load. 
            try
            {
                currentBinding = new Binding("Text", employeesTable, "Employees.FirstName");
                firstName.DataBindings.Add(currentBinding);
                
                currentBinding = new Binding("Text", employeesTable, "Employees.LastName");
                lastName.DataBindings.Add(currentBinding);

                phoneBinding =new Binding("Text", employeesTable, "Employees.HomePhone");
                // We must add the event handlers before we bind, or the Format event will not get called
                // for the first record.
                phoneBinding.Format += new ConvertEventHandler(phoneBinding_Format);
                phoneBinding.Parse += new ConvertEventHandler(phoneBinding_Parse);
                phoneMask.DataBindings.Add(phoneBinding);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void phoneBinding_Format(Object sender, ConvertEventArgs e)
        {
            String ext;

            DataRowView currentRow = (DataRowView)BindingContext[employeesTable, "Employees"].Current;
            if (currentRow["Extension"] == null) 
            {
                ext = "";
            } else 
            {
                ext = currentRow["Extension"].ToString();
            }

            e.Value = e.Value.ToString().Trim() + " x" + ext;
        }

        private void phoneBinding_Parse(Object sender, ConvertEventArgs e)
        {
            String phoneNumberAndExt = e.Value.ToString();

            int extIndex = phoneNumberAndExt.IndexOf("x");
            String ext = phoneNumberAndExt.Substring(extIndex).Trim();
            String phoneNumber = phoneNumberAndExt.Substring(0, extIndex).Trim();

            //Get the current binding object, and set the new extension manually. 
            DataRowView currentRow = (DataRowView)BindingContext[employeesTable, "Employees"].Current;
            // Remove the "x" from the extension.
            currentRow["Extension"] = ext.Substring(1);

            //Return the phone number.
            e.Value = phoneNumber;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            BindingContext[employeesTable, "Employees"].Position = BindingContext[employeesTable, "Employees"].Position - 1;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            BindingContext[employeesTable, "Employees"].Position = BindingContext[employeesTable, "Employees"].Position + 1;
        }
    }
}
//</SNIPPET1>