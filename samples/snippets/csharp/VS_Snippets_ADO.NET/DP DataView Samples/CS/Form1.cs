using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewSamples
{
    public partial class Form1 : Form
    {
        DataSet _dataSet;

        public Form1() => InitializeComponent();

        void Form1_Load(object sender, EventArgs e)
        {
            // Fill the DataSet.
            _dataSet = new DataSet
            {
                Locale = CultureInfo.InvariantCulture
            };
            FillDataSet(_dataSet);

            dataGridView1.DataSource = bindingSource1;
        }

        static void FillDataSet(DataSet ds)
        {
            // Create a new adapter and give it a query to fetch sales order, contact,
            // address, and product information for sales in the year 2002.
            const string connectionString = "some secure connection string";

            var da = new SqlDataAdapter(
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
            var order = new DataRelation("SalesOrderHeaderDetail",
                                     orderHeader.Columns["SalesOrderID"],
                                     orderDetail.Columns["SalesOrderID"], true);
            ds.Relations.Add(order);

            DataTable contact = ds.Tables["Contact"];
            DataTable orderHeader2 = ds.Tables["SalesOrderHeader"];
            var orderContact = new DataRelation("SalesOrderContact",
                                            contact.Columns["ContactID"],
                                            orderHeader2.Columns["ContactID"], true);
            ds.Relations.Add(orderContact);
        }

        // <SnippetSoundEx>
        static string SoundEx(string word)
        {
            // The length of the returned code.
            const int length = 4;

            // Value to return.
            var value = "";

            // The size of the word to process.
            var size = word.Length;

            // The word must be at least two characters in length.
            if (size > 1)
            {
                // Convert the word to uppercase characters.
                word = word.ToUpper(CultureInfo.InvariantCulture);

                // Convert the word to a character array.
                var chars = word.ToCharArray();

                // Buffer to hold the character codes.
                var buffer = new StringBuilder
                {
                    Length = 0
                };

                // The current and previous character codes.
                var prevCode = 0;
                var currCode = 0;

                // Add the first character to the buffer.
                buffer.Append(chars[0]);

                // Loop through all the characters and convert them to the proper character code.
                for (var i = 1; i < size; i++)
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
                        {
                            buffer.Append(currCode);
                        }
                    }
                    // Set the previous character code.
                    prevCode = currCode;

                    // If the buffer size meets the length limit, exit the loop.
                    if (buffer.Length == length)
                    {
                        break;
                    }
                }
                // Pad the buffer, if required.
                size = buffer.Length;
                if (size < length)
                {
                    buffer.Append('0', length - size);
                }

                // Set the value to return.
                value = buffer.ToString();
            }
            // Return the value.
            return value;
        }
        // </SnippetSoundEx>

        void Button1_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery1>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<bool>("OnlineOrderFlag")
                orderby order.Field<decimal>("TotalDue")
                select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQuery1>
        }

        void Button2_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery2>
            DataTable orders = _dataSet.Tables["SalesOrderDetail"];

            EnumerableRowCollection<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<short>("OrderQty") > 2 &&
                    order.Field<short>("OrderQty") < 6
                select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            dataGridView1.AutoResizeColumns();
            // </SnippetCreateLDVFromQuery2>
        }

        void Button3_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery3>
            DataTable contacts = _dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName").StartsWith("S")
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQuery3>
        }

        void Button4_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQuery4>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 9, 15)
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQuery4>
        }

        void Button5_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromTable>
            DataTable orders = _dataSet.Tables["SalesOrderDetail"];

            DataView view = orders.AsDataView();
            bindingSource1.DataSource = view;

            dataGridView1.AutoResizeColumns();
            // </SnippetCreateLDVFromTable>
        }

        void Button6_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderBy>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<DateTime>("OrderDate")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQueryOrderBy>
        }

        void Button7_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryStringSort>
            DataTable contacts = _dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName").StartsWith("S")
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            view.Sort = "LastName desc, FirstName asc";
            // </SnippetCreateLDVFromQueryStringSort>
        }

        void Button8_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderByThenBy>
            DataTable orders = _dataSet.Tables["SalesOrderDetail"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<short>("OrderQty"), order.Field<int>("SalesOrderID")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            // </SnippetCreateLDVFromQueryOrderByThenBy>
        }

        void Button9_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderBy2>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query =
                from order in orders.AsEnumerable()
                orderby order.Field<decimal>("TotalDue")
                select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            // </SnippetCreateLDVFromQueryOrderBy2>
        }

        void Button10_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderByDescending>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<DateTime>("OrderDate") descending
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetCreateLDVFromQueryOrderByDescending>
        }

        void Button11_Click(object sender, EventArgs e)
        {
            // <SnippetLDVStringSort>
            DataTable contacts = _dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.Sort = "LastName desc, FirstName asc";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetLDVStringSort>
        }

        void Button12_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearSort>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<decimal>("TotalDue")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            view.Sort = "";
            // </SnippetLDVClearSort>
        }

        void Button13_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearRowFilter>
            DataTable contacts = _dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.RowFilter = "LastName='Zhu'";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // Clear the row filter.
            view.RowFilter = "";
            // </SnippetLDVClearRowFilter>
        }

        void Button14_Click(object sender, EventArgs e)
        {
            // <SnippetLDVRowFilter>
            DataTable contacts = _dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.RowFilter = "LastName='Zhu'";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetLDVRowFilter>
        }

        void Button15_Click(object sender, EventArgs e)
        {
            // <SnippetLDVSoundExFilter>
            DataTable contacts = _dataSet.Tables["Contact"];

            var soundExCode = SoundEx("Zhu");

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where SoundEx(contact.Field<string>("LastName")) == soundExCode
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetLDVSoundExFilter>
        }

        void Button16_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhere>
            DataTable orders = _dataSet.Tables["SalesOrderDetail"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<short>("OrderQty") > 2 && order.Field<short>("OrderQty") < 6
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetLDVFromQueryWhere>
        }

        void Button17_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhere2>
            DataTable contacts = _dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName") == "Hernandez"
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // </SnippetLDVFromQueryWhere2>
        }

        void Button18_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhere3>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 6, 1)
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetLDVFromQueryWhere3>
        }

        void Button19_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhereOrderByThenBy>
            DataTable contacts = _dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName").StartsWith("S")
                                                     orderby contact.Field<string>("LastName"), contact.Field<string>("FirstName")
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // </SnippetLDVFromQueryWhereOrderByThenBy>
        }

        void Button20_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhereOrderByThenBy2>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 9, 15)
                                                     orderby order.Field<DateTime>("OrderDate"), order.Field<decimal>("TotalDue")
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            // </SnippetLDVFromQueryWhereOrderByThenBy2>
        }

        void Button21_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryOrderByFind>
            DataTable contacts = _dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     orderby contact.Field<string>("LastName")
                                                     select contact;

            DataView view = query.AsDataView();

            // Find a contact with the last name of Zhu.
            var found = view.Find("Zhu");
            // </SnippetLDVFromQueryOrderByFind>
        }

        void Button22_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryFindRows>
            DataTable products = _dataSet.Tables["Product"];

            EnumerableRowCollection<DataRow> query = from product in products.AsEnumerable()
                                                     orderby product.Field<decimal>("ListPrice"), product.Field<string>("Color")
                                                     select product;

            DataView view = query.AsDataView();

            view.Sort = "Color";

            var criteria = new object[] { "Red" };

            DataRowView[] foundRowsView = view.FindRows(criteria);
            // </SnippetLDVFromQueryFindRows>
        }

        void Button23_Click(object sender, EventArgs e)
        {
            // <SnippetLDVFromQueryWhereSetRowFilter>
            DataTable contacts = _dataSet.Tables["Contact"];

            EnumerableRowCollection<DataRow> query = from contact in contacts.AsEnumerable()
                                                     where contact.Field<string>("LastName") == "Hernandez"
                                                     select contact;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            view.RowFilter = "LastName='Zhu'";
            // </SnippetLDVFromQueryWhereSetRowFilter>
        }

        void Button24_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearRowFilter2>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     where order.Field<DateTime>("OrderDate") > new DateTime(2002, 11, 20)
                                                        && order.Field<decimal>("TotalDue") < new decimal(60.00)
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;

            view.RowFilter = null;
            // </SnippetLDVClearRowFilter2>
        }

        void Button26_Click(object sender, EventArgs e)
        {
            // <SnippetLDVClearSort2>
            DataTable contacts = _dataSet.Tables["Contact"];

            DataView view = contacts.AsDataView();

            view.Sort = "LastName desc";

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();

            // Clear the sort.
            view.Sort = null;
            // </SnippetLDVClearSort2>
        }

        void Button25_Click(object sender, EventArgs e)
        {
            // <SnippetCreateLDVFromQueryOrderByYear>
            DataTable orders = _dataSet.Tables["SalesOrderHeader"];

            EnumerableRowCollection<DataRow> query = from order in orders.AsEnumerable()
                                                     orderby order.Field<DateTime>("OrderDate").Year
                                                     select order;

            DataView view = query.AsDataView();

            bindingSource1.DataSource = view;
            dataGridView1.AutoResizeColumns();
            // </SnippetCreateLDVFromQueryOrderByYear>
        }

        void Button27_Click(object sender, EventArgs e)
        {
            DataTable products = _dataSet.Tables["Product"];

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
            var view = (DataView)bindingSource1.DataSource;
            DataTable productsTable = view.Table;

            // Set RowStateFilter to display the current rows.
            view.RowStateFilter = DataViewRowState.CurrentRows;

            // Query the DataView for red colored products ordered by list price.
            var productQuery = from DataRowView rowView in view
                               where rowView.Row.Field<string>("Color") == "Red"
                               orderby rowView.Row.Field<decimal>("ListPrice")
                               select new
                               {
                                   Name = rowView.Row.Field<string>("Name"),
                                   Color = rowView.Row.Field<string>("Color"),
                                   Price = rowView.Row.Field<decimal>("ListPrice")
                               };

            // Bind the query results to another DataGridView.
            dataGridView2.DataSource = productQuery.ToList();
            // </SnippetQueryDataView1>
        }

        void Button28_Click(object sender, EventArgs e)
        {
            // <SnippetQueryDataView2>
            DataTable products = _dataSet.Tables["Product"];

            // Query for red colored products.
            EnumerableRowCollection<DataRow> redProductsQuery =
                from product in products.AsEnumerable()
                where product.Field<string>("Color") == "Red"
                orderby product.Field<decimal>("ListPrice")
                select product;

            // Create a table and view from the query.
            DataTable redProducts = redProductsQuery.CopyToDataTable();
            var view = new DataView(redProducts);

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
