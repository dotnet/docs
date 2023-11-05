using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace DataViewWinFormsSample
{
    public partial class Form1 : Form
    {
        DataSet _dataSet;
        SqlDataAdapter _contactsDataAdapter;
        DataView _contactView;

        public Form1()
        {
            InitializeComponent();
        }

        // <SnippetLDVSample1FormLoad>
        void Form1_Load(object sender, EventArgs e)
        {
            // Connect to the database and fill the DataSet.
            GetData();

            contactDataGridView.DataSource = contactBindingSource;

            // Create a LinqDataView from a LINQ to DataSet query and bind it
            // to the Windows forms control.
            EnumerableRowCollection<DataRow> contactQuery = from row in _dataSet.Tables["Contact"].AsEnumerable()
                                                            where row.Field<string>("EmailAddress") != null
                                                            orderby row.Field<string>("LastName")
                                                            select row;

            _contactView = contactQuery.AsDataView();

            // Bind the DataGridView to the BindingSource.
            contactBindingSource.DataSource = _contactView;
            contactDataGridView.AutoResizeColumns();
        }
        // </SnippetLDVSample1FormLoad>

        // <SnippetLDVSample1GetData>
        void GetData()
        {
            try
            {
                // Initialize the DataSet.
                _dataSet = new DataSet
                {
                    Locale = CultureInfo.InvariantCulture
                };

                // Create the connection string for the AdventureWorks sample database.
                const string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;"
                    + "Integrated Security=true;";

                // Create the command strings for querying the Contact table.
                const string contactSelectCommand = "SELECT ContactID, Title, FirstName, LastName, EmailAddress, Phone FROM Person.Contact";

                // Create the contacts data adapter.
                _contactsDataAdapter = new SqlDataAdapter(
                    contactSelectCommand,
                    connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on the contacts select command. These are used to
                // update the database.
                var contactsCommandBuilder = new SqlCommandBuilder(_contactsDataAdapter);

                // Fill the data set with the contact information.
                _contactsDataAdapter.Fill(_dataSet, "Contact");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // </SnippetLDVSample1GetData>
    }
}
