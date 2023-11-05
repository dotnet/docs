using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Globalization;

namespace DP_Custom_CopyToDataTable_Examples
{
    static class Program
    {
        static void Main()
        {
            //ItemsQueries();

            // JoinQuery();
            // LoadScalarSequence();
            // LoadItemsIntoTable();
            // LoadItemsIntoExistingTable();
            LoadItemsExpandSchema();

            Console.WriteLine("Hit enter...");
            Console.Read();
        } // Main

        static void JoinQuery()
        {
            //<SnippetJoin>
            // Fill the DataSet.
            var ds = new DataSet
            {
                Locale = CultureInfo.InvariantCulture
            };
            FillDataSet(ds);

            DataTable orders = ds.Tables["SalesOrderHeader"];
            DataTable details = ds.Tables["SalesOrderDetail"];

            var query =
                from order in orders.AsEnumerable()
                join detail in details.AsEnumerable()
                on order.Field<int>("SalesOrderID") equals
                    detail.Field<int>("SalesOrderID")
                where order.Field<bool>("OnlineOrderFlag")
                    && order.Field<DateTime>("OrderDate").Month == 8
                select new
                {
                    SalesOrderID =
                        order.Field<int>("SalesOrderID"),
                    SalesOrderDetailID =
                        detail.Field<int>("SalesOrderDetailID"),
                    OrderDate =
                        order.Field<DateTime>("OrderDate"),
                    ProductID =
                        detail.Field<int>("ProductID")
                };

            DataTable orderTable = query.CopyToDataTable();
            //</SnippetJoin>

            DisplayTable(orderTable);
        }

        static void LoadItemsIntoTable()
        {
            //<SnippetLoadItemsIntoTable>
            // Create a sequence.
            var items = new Item[]
            { new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"},
              new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
              new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
              new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};

            // Query for items with price greater than 9.99.
            IOrderedEnumerable<Item> query = from i in items
                        where i.Price > 9.99
                        orderby i.Price
                        select i;

            // Load the query results into new DataTable.
            DataTable table = query.CopyToDataTable();
            //</SnippetLoadItemsIntoTable>
            DisplayTable(table);
        }

        static void LoadItemsIntoExistingTable()
        {
            //<SnippetLoadItemsIntoExistingTable>
            // Create a sequence.
            var items = new Item[]
            { new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"},
              new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
              new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
              new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};

            // Create a table with a schema that matches that of the query results.
            var table = new DataTable();
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("Genre", typeof(string));

            var query = from i in items
                        where i.Price > 9.99
                        orderby i.Price
                        select new { i.Price, i.Genre };

            query.CopyToDataTable(table, LoadOption.PreserveChanges);
            //</SnippetLoadItemsIntoExistingTable>
            DisplayTable(table);
        }

        static void LoadItemsExpandSchema()
        {
            //<SnippetLoadItemsExpandSchema>
            // Create a sequence.
            var items = new Item[]
            { new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"},
              new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
              new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
              new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};

            // Load into an existing DataTable, expand the schema and
            // autogenerate a new Id.
            var table = new DataTable();
            DataColumn dc = table.Columns.Add("NewId", typeof(int));
            dc.AutoIncrement = true;
            table.Columns.Add("ExtraColumn", typeof(string));

            var query = from i in items
                        where i.Price > 9.99
                        orderby i.Price
                        select new { i.Price, i.Genre };

            query.CopyToDataTable(table, LoadOption.PreserveChanges);
            //</SnippetLoadItemsExpandSchema>
            DisplayTable(table);
        }

        static void LoadScalarSequence()
        {
            //<SnippetLoadScalarSequence>
            // Create a sequence.
            var items = new Item[]
            { new Book{Id = 1, Price = 13.50, Genre = "Comedy", Author = "Gustavo Achong"},
              new Book{Id = 2, Price = 8.50, Genre = "Drama", Author = "Jessie Zeng"},
              new Movie{Id = 1, Price = 22.99, Genre = "Comedy", Director = "Marissa Barnes"},
              new Movie{Id = 1, Price = 13.40, Genre = "Action", Director = "Emmanuel Fernandez"}};

            // load sequence of scalars.
            IEnumerable<double> query = from i in items
                                        where i.Price > 9.99
                                        orderby i.Price
                                        select i.Price;

            DataTable table = query.CopyToDataTable();
            //</SnippetLoadScalarSequence>
            DisplayTable(table);
        }

        static void DisplayTable(DataTable table)
        {
            for (var i = 0; i < table.Rows.Count; i++)
            {
                for (var j = 0; j < table.Columns.Count; j++)
                {
                    Console.WriteLine(table.Columns[j].ColumnName + ": " + table.Rows[i][j]);
                }
                Console.WriteLine("");
            }
        }

        static void FillDataSet(DataSet ds)
        {
            // <SnippetFillDataSet>
            try
            {
                // Create a new adapter and give it a query to fetch sales order, contact,
                // address, and product information for sales in the year 2002. Point connection
                // information to the configuration setting "AdventureWorks".
                const string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;"
                    + "Integrated Security=true;";

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
            catch (SqlException ex)
            {
                Console.WriteLine("SQL exception occurred: " + ex.Message);
            }
            // </SnippetFillDataSet>
        }

        //<SnippetItemClass>
        public class Item
        {
            public int Id { get; set; }
            public double Price { get; set; }
            public string Genre { get; set; }
        }

        public class Book : Item
        {
            public string Author { get; set; }
        }

        public class Movie : Item
        {
            public string Director { get; set; }
        }
        //</SnippetItemClass>
    } // Program
    // <SnippetCustomCopyToDataTableMethods>
    public static class CustomLINQtoDataSetMethods
    {
        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable CopyToDataTable<T>(this IEnumerable<T> source,
                                                    DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }
    }
    // </SnippetCustomCopyToDataTableMethods>

    // <SnippetObjectShredderClass>
    public class ObjectShredder<T>
    {
        readonly FieldInfo[] _fi;
        readonly PropertyInfo[] _pi;
        readonly Dictionary<string, int> _ordinalMap;
        readonly Type _type;

        // ObjectShredder constructor.
        public ObjectShredder()
        {
            _type = typeof(T);
            _fi = _type.GetFields();
            _pi = _type.GetProperties();
            _ordinalMap = new Dictionary<string, int>();
        }

        /// <summary>
        /// Loads a DataTable from a sequence of objects.
        /// </summary>
        /// <param name="source">The sequence of objects to load into the DataTable.</param>
        /// <param name="table">The input table. The schema of the table must match that
        /// the type T.  If the table is null, a new table is created with a schema
        /// created from the public properties and fields of the type T.</param>
        /// <param name="options">Specifies how values from the source sequence will be applied to
        /// existing rows in the table.</param>
        /// <returns>A DataTable created from the source sequence.</returns>
        public DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            // Load the table from the scalar sequence if T is a primitive type.
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, table, options);
            }

            // Create a new table if the input table is null.
            table ??= new DataTable(typeof(T).Name);

            // Initialize the ordinal map and extend the table schema based on type T.
            table = ExtendTable(table, typeof(T));

            // Enumerate the source sequence and load the object values into rows.
            table.BeginLoadData();
            foreach (T item in source)
            {
                if (options != null)
                {
                    table.LoadDataRow(ShredObject(table, item), (LoadOption)options);
                }
                else
                {
                    table.LoadDataRow(ShredObject(table, item), true);
                }
            }
            table.EndLoadData();

            // Return the table.
            return table;
        }

        public DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            // Create a new table if the input table is null.
            table ??= new DataTable(typeof(T).Name);

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            // Enumerate the source sequence and load the scalar values into rows.
            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                var values = new object[table.Columns.Count];
                while (e.MoveNext())
                {
                    values[table.Columns["Value"].Ordinal] = e.Current;

                    if (options != null)
                    {
                        table.LoadDataRow(values, (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(values, true);
                    }
                }
            }
            table.EndLoadData();

            // Return the table.
            return table;
        }

        public object[] ShredObject(DataTable table, T instance)
        {
            FieldInfo[] fi = _fi;
            PropertyInfo[] pi = _pi;

            if (instance.GetType() != typeof(T))
            {
                // If the instance is derived from T, extend the table schema
                // and get the properties and fields.
                ExtendTable(table, instance.GetType());
                fi = instance.GetType().GetFields();
                pi = instance.GetType().GetProperties();
            }

            // Add the property and field values of the instance to an array.
            var values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                values[_ordinalMap[f.Name]] = f.GetValue(instance);
            }

            foreach (PropertyInfo p in pi)
            {
                values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
            }

            // Return the property and field values of the instance.
            return values;
        }

        public DataTable ExtendTable(DataTable table, Type type)
        {
            // Extend the table schema if the input table was null or if the value
            // in the sequence is derived from type T.
            foreach (FieldInfo f in type.GetFields())
            {
                if (!_ordinalMap.ContainsKey(f.Name))
                {
                    // Add the field as a column in the table if it doesn't exist
                    // already.
                    DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                        : table.Columns.Add(f.Name, f.FieldType);

                    // Add the field to the ordinal map.
                    _ordinalMap.Add(f.Name, dc.Ordinal);
                }
            }
            foreach (PropertyInfo p in type.GetProperties())
            {
                if (!_ordinalMap.ContainsKey(p.Name))
                {
                    // Add the property as a column in the table if it doesn't exist
                    // already.
                    DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                        : table.Columns.Add(p.Name, p.PropertyType);

                    // Add the property to the ordinal map.
                    _ordinalMap.Add(p.Name, dc.Ordinal);
                }
            }

            // Return the table.
            return table;
        }
    }
    // </SnippetObjectShredderClass>
}
