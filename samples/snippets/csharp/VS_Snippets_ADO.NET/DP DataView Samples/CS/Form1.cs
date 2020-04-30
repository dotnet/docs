using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace DataViewSamples
{
    public partial class Form1 : Form
    {
        DataSet dataSet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fill the DataSet.
            dataSet = new DataSet();
            dataSet.Locale = CultureInfo.InvariantCulture;
            FillDataSet(dataSet);

            dataGridView1.DataSource = bindingSource1;
        }

        private void FillDataSet(DataSet ds)
        {
            // Create a new adapter and give it a query to fetch sales order, contact,
            // address, and product information for sales in the year 2002. Point connection
            // information to the configuration setting "AdventureWorks".
            string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;"
                + "Integrated Security=true;";

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT SalesOrderID, ContactID, OrderDate, OnlineOrderFlag, " +
                "TotalDue, SalesOrderNumber, Status, ShipToAddressID, BillToAddressID " +
                "FROM Sales.SalesOrderHeader " +
                "WHERE DATEPART(YEAR, OrderDate) = @year; " +

                "SELECT d.SalesOrderID, d.SalesOrderDetailID, d.OrderQty, " +
                "d.ProductID, d.UnitPrice " +
                "FROM Sales.SalesOrderDetail d " +
                "INNER JOIN Sales.SalesOrderHeader h " +
                "ON d.SalesOrderID = h.SalesOrderID  " +
                "WHERE DATEPART(YEAR, OrderDate) = @year; " +

                "SELECT p.ProductID, p.Name, p.ProductNumber, p.MakeFlag, " +
                "p.Color, p.ListPrice, p.Size, p.Class, p.Style, p.Weight  " +
                "FROM Production.Product p; " +

                "SELECT DISTINCT a.AddressID, a.AddressLine1, a.AddressLine2, " +
                "a.City, a.StateProvinceID, a.PostalCode " +
                "FROM Person.Address a " +
                "INNER JOIN Sales.SalesOrderHeader h " +
                "ON  a.AddressID = h.ShipToAddressID OR a.AddressID = h.BillToAddressID " +
                "WHERE DATEPART(YEAR, OrderDate) = @year; " +

                "SELECT DISTINCT c.ContactID, c.Title, c.FirstName, " +
                "c.LastName, c.EmailAddress, c.Phone " +
                "FROM Person.Contact c " +
                "INNER JOIN Sales.SalesOrderHeader h " +
                "ON c.ContactID = h.ContactID " +
                "WHERE DATEPART(YEAR, OrderDate) = @year;",
            connectionString);

            // Add table mappings.
            da.SelectCommand.Parameters.AddWithValue("@year", 2002);
            da.TableMappings.Add("Table", "SalesOrderHeader");
            da.TableMappings.Add("Table1", "SalesOrderDetail");
            da.TableMappings.Add("Table2", "Product");
            da.TableMappings.Add("Table3", "Address");
            da.TableMappings.Add("Table4", "Contact");

            // Fill the DataSet.
            da.Fill(ds);

            // Add data relations.
            DataTable orderHeader = ds.Tables["SalesOrderHeader"];
            DataTable orderDetail = ds.Tables["SalesOrderDetail"];
            DataRelation order = new DataRelation("SalesOrderHeaderDetail",
                                     orderHeader.Columns["SalesOrderID"],
                                     orderDetail.Columns["SalesOrderID"], true);
            ds.Relations.Add(order);

            DataTable contact = ds.Tables["Contact"];
            DataTable orderHeader2 = ds.Tables["SalesOrderHeader"];
            DataRelation orderContact = new DataRelation("SalesOrderContact",
                                            contact.Columns["ContactID"],
                                            orderHeader2.Columns["ContactID"], true);
            ds.Relations.Add(orderContact);
        }

        // <SnippetSoundEx>
        static private string SoundEx(string word)
        {
            // The length of the returned code.
            int length = 4;

            // Value to return.
            string value = "";

            // The size of the word to process.
            int size = word.Length;

            // The word must be at least two characters in length.
            if (size > 1)
            {
                // Convert the word to uppercase characters.
                word = word.ToUpper(System.Globalization.CultureInfo.InvariantCulture);

                // Convert the word to a character array.
                char[] chars = word.ToCharArray();

                // Buffer to hold the character codes.
                StringBuilder buffer = new StringBuilder();
                buffer.Length = 0;

                // The current and previous character codes.
                int prevCode = 0;
                int currCode = 0;

                // Add the first character to the buffer.
                buffer.Append(chars[0]);

                // Loop through all the characters and convert them to the proper character code.
                for (int i = 1; i < size; i++)
                {
                    switch (chars[i])
                    {
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':
                        case 'H':
                        case 'W':
                        case 'Y':
                            currCode = 0;
                            break;
                        case 'B':
                        case 'F':
                        case 'P':
                        case 'V':
                            currCode = 1;
                            break;
                        case 'C':
                        case 'G':
                        case 'J':
                        case 'K':
                        case 'Q':
                        case 'S':
                        case 'X':
                        case 'Z':
                            currCode = 2;
                            break;
                        case 'D':
                        case 'T':
                            currCode = 3;
                            break;
                        case 'L':
                            currCode = 4;
                            break;
                        case 'M':
                        case 'N':
                            currCode = 5;
                            break;
                        case 'R':
                            currCode = 6;
                            break;
                    }

                    // Check if the current code is the same as the previous code.
                    if (currCode != prevCode)
                    {
                        // Check to see if the current code is 0 (a vowel); do not process vowels.
                        if (currCode != 0)
                            buffer.Append(currCode);
                    }
                    // Set the previous character code.
                    prevCode = currCode;

                    // If the buffer size meets the length limit, exit the loop.
                    if (buffer.Length == length)
                        break;
                }
                // Pad the buffer, if required.
                size = buffer.Length;
                if (size < length)
                    buffer.Append('0', (length - size));

                // Set the value to return.
                value = buffer.ToString();
            }
            // Return the value.
            return value;
        }
        // </SnippetSoundEx>

        private void button1_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery1>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<bool>("OnlineOrderFlag") == true
                orderby order.Field<decimal>("TotalDue")
                select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQuery1>
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery2>
            DataTable orders = dataSet.Tables["SalesOrderDetail"];

            EnumerableRowCollection<DataRow> query =
                from order in orders.AsEnumerable()
                where (order.Field<Int16>("OrderQty") > 2 &&
                    order.Field<Int16>("OrderQty") < 6)
                select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            dataGridView1.AutoResizeColumns();
            // </SnippetCreateLDVFromQuery2>
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery3>
            DataTable contacts = dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName").StartsWith("S")
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQuery3>
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery4>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 9, 15)
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQuery4>
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // <SnippetCreateLDVFromTable>
            DataTable orders = dataSet.Tables["SalesOrderDetail"];

            DataView view = orders.AsDataView();
            bindingSource1.DataSource = view;

            dataGridView1.AutoResizeColumns();
            // </SnippetCreateLDVFromTable>
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderBy>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<DateTime>("OrderDate")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQueryOrderBy>
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryStringSort>
            DataTable contacts = dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName").StartsWith("S")
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            view.Sort = "LastName desc, FirstName asc";
            // </SnippetCreateLDVFromQueryStringSort>
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderByThenBy>
            DataTable orders = dataSet.Tables["SalesOrderDetail"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<Int16>("OrderQty"), order.Field<int>("SalesOrderID")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            // </SnippetCreateLDVFromQueryOrderByThenBy>
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderBy2>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query =
                from order in orders.AsEnumerable()
                orderby order.Field<decimal>("TotalDue")
                select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            // </SnippetCreateLDVFromQueryOrderBy2>
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderByDescending>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<DateTime>("OrderDate") descending
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQueryOrderByDescending>
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // <SnippetLDVStringSort>
            DataTable contacts = dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.Sort = "LastName desc, FirstName asc";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetLDVStringSort>
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearSort>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<decimal>("TotalDue")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            view.Sort = "";
            // </SnippetLDVClearSort>
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearRowFilter>
            DataTable contacts = dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.RowFilter = "LastName='Zhu'";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // Clear the row filter.
            view.RowFilter = "";
            // </SnippetLDVClearRowFilter>
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // <SnippetLDVRowFilter>
            DataTable contacts = dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.RowFilter = "LastName='Zhu'";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetLDVRowFilter>
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // <SnippetLDVSoundExFilter>
            DataTable contacts = dataSet.Tables["Contact"];

            string soundExCode = SoundEx("Zhu");

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where SoundEx(contact.Field<string>("LastName")) == soundExCode
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetLDVSoundExFilter>
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhere>
            DataTable orders = dataSet.Tables["SalesOrderDetail"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<Int16>("OrderQty") > 2 && order.Field<Int16>("OrderQty") < 6
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetLDVFromQueryWhere>
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhere2>
            DataTable contacts = dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName") == "Hernandez"
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

           // </SnippetLDVFromQueryWhere2>
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhere3>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 6, 1)
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetLDVFromQueryWhere3>
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhereOrderByThenBy>
            DataTable contacts = dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName").StartsWith("S")
                                                     orderby contact.Field<string>("LastName"), contact.Field<string>("FirstName")
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // </SnippetLDVFromQueryWhereOrderByThenBy>
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhereOrderByThenBy2>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 9, 15)
                                                     orderby order.Field<DateTime>("OrderDate"), order.Field<decimal>("TotalDue")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetLDVFromQueryWhereOrderByThenBy2>
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryOrderByFind>
            DataTable contacts = dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     orderby contact.Field<string>("LastName")
                                                     select contact;

            DataView view = query.AsDataView();

            // Find a contact with the last name of Zhu.
            int found = view.Find("Zhu");
            // </SnippetLDVFromQueryOrderByFind>
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryFindRows>
            DataTable products = dataSet.Tables["Product"];

            EnumerableRowCollection<DataRow> query = from product in products.AsEnumerable()
                                                     orderby product.Field<Decimal>("ListPrice"), product.Field<string>("Color")
                                                     select product;

            DataView view = query.AsDataView();

            view.Sort = "Color";

            object[] criteria = new object[] { "Red"};

            DataRowView[] foundRowsView = view.FindRows(criteria);
            // </SnippetLDVFromQueryFindRows>
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhereSetRowFilter>
            DataTable contacts = dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName") == "Hernandez"
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            view.RowFilter = "LastName='Zhu'";
            // </SnippetLDVFromQueryWhereSetRowFilter>
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearRowFilter2>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 11, 20)
                                                        && order.Field<Decimal>("TotalDue") < new Decimal(60.00)
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            view.RowFilter = null;
            // </SnippetLDVClearRowFilter2>
        }

        private void button26_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearSort2>
            DataTable contacts = dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.Sort = "LastName desc";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // Clear the sort.
            view.Sort = null;
            // </SnippetLDVClearSort2>
        }

        private void button25_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderByYear>
            DataTable orders = dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<DateTime>("OrderDate").Year
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetCreateLDVFromQueryOrderByYear>
        }

        private void button27_Click(object sender, EventArgs e)
        {

            DataTable products = dataSet.Tables["Product"];

            // Query for red colored products.
            EnumerableRowCollection<DataRow> redProductsQuery =
                from product in products.AsEnumerable()
                orderby product.Field<decimal>("ListPrice")
                select product;

            DataView boundView = redProductsQuery.AsDataView();

            bindingSource1.DataSource = boundView;
            // <SnippetQueryDataView1>
            // Create a table from the bound view representing a query of
            // available products.
            DataView view = (DataView)bindingSource1.DataSource;
            DataTable productsTable = (DataTable)view.Table;

            // Set RowStateFilter to display the current rows.
            view.RowStateFilter = DataViewRowState.CurrentRows ;

            // Query the DataView for red colored products ordered by list price.
            var productQuery = from DataRowView rowView in view
                               where rowView.Row.Field<string>("Color") == "Red"
                               orderby rowView.Row.Field<decimal>("ListPrice")
                               select new { Name = rowView.Row.Field<string>("Name"),
                                            Color = rowView.Row.Field<string>("Color"),
                                            Price = rowView.Row.Field<decimal>("ListPrice")};

            // Bind the query results to another DataGridView.
            dataGridView2.DataSource = productQuery.ToList();
            // </SnippetQueryDataView1>
        }

        private void button28_Click(object sender, EventArgs e)
        {
            // <SnippetQueryDataView2>
            DataTable products = dataSet.Tables["Product"];

            // Query for red colored products.
            EnumerableRowCollection<DataRow> redProductsQuery =
                from product in products.AsEnumerable()
                where product.Field<string>("Color") == "Red"
                orderby product.Field<decimal>("ListPrice")
                select product;

            // Create a table and view from the query.
            DataTable redProducts = redProductsQuery.CopyToDataTable<DataRow>();
            DataView view = new DataView(redProducts);

            // Mark a row as deleted.
            redProducts.Rows[0].Delete();

            // Modify product price.
            redProducts.Rows[1]["ListPrice"] = 20.00;
            redProducts.Rows[2]["ListPrice"] = 30.00;

            view.RowStateFilter = DataViewRowState.ModifiedCurrent | DataViewRowState.Deleted;

            // Query for the modified and deleted rows.
            IEnumerable<DataRowView> modifiedDeletedQuery = from DataRowView rowView in view
                                                            select rowView;

            dataGridView2.DataSource = modifiedDeletedQuery.ToList();
            // </SnippetQueryDataView2>
        }
    }
}
