using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace DataViewWinFormsSample
{
    public partial class Form1 : Form
    {
        private DataSet dataSet;
        private SqlDataAdapter contactsDataAdapter;
        private DataView contactView;

        public Form1()
        {
            InitializeComponent();
        }

        // <SnippetLDVSample1FormLoad>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Connect to the database and fill the DataSet.
            GetData();

            contactDataGridView.DataSource = contactBindingSource;

            // Create a LinqDataView from a LINQ to DataSet query and bind it
            // to the Windows forms control.
            EnumerableRowCollection<DataRow> contactQuery = from row in dataSet.Tables["Contact"].AsEnumerable()
                                                            where row.Field<string>("EmailAddress") != null
                                                            orderby row.Field<string>("LastName")
                                                            select row;

            contactView = contactQuery.AsDataView();

            // Bind the DataGridView to the BindingSource.
            contactBindingSource.DataSource = contactView;
            contactDataGridView.AutoResizeColumns();
        }
        // </SnippetLDVSample1FormLoad>

        // <SnippetLDVSample1GetData>
        private void GetData()
        {
            try
            {
                // Initialize the DataSet.
                dataSet = new DataSet();
                dataSet.Locale = CultureInfo.InvariantCulture;

                // Create the connection string for the AdventureWorks sample database.
                string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;"
                    + "Integrated Security=true;";

                // Create the command strings for querying the Contact table.
                string contactSelectCommand = "SELECT ContactID, Title, FirstName, LastName, EmailAddress, Phone FROM Person.Contact";

                // Create the contacts data adapter.
                contactsDataAdapter = new SqlDataAdapter(
                    contactSelectCommand,
                    connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on the contacts select command. These are used to
                // update the database.
                SqlCommandBuilder contactsCommandBuilder = new SqlCommandBuilder(contactsDataAdapter);

                // Fill the data set with the contact information.
                contactsDataAdapter.Fill(dataSet, "Contact");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // </SnippetLDVSample1GetData>
    }
}
