using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Data.SqlTypes;

class Class1
{
    static void Main()
    {
        string c = "Data Source=(local);Integrated Security=true;" +
        "Initial Catalog=AdventureWorks; ";
        GetXmlData(c);
        Console.ReadLine();
    }
    // <Snippet1>
    // Example assumes the following directives:
    //     using System.Data.SqlClient;
    //     using System.Xml;
    //     using System.Data.SqlTypes;

    static void GetXmlData(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // The query includes two specific customers for simplicity's
            // sake. A more realistic approach would use a parameter
            // for the CustomerID criteria. The example selects two rows
            // in order to demonstrate reading first from one row to
            // another, then from one node to another within the xml column.
            string commandText =
                "SELECT Demographics from Sales.Store WHERE " +
                "CustomerID = 3 OR CustomerID = 4";

            SqlCommand commandSales = new SqlCommand(commandText, connection);

            SqlDataReader salesReaderData = commandSales.ExecuteReader();

            //  Multiple rows are returned by the SELECT, so each row
            //  is read and an XmlReader (an xml data type) is set to the
            //  value of its first (and only) column.
            int countRow = 1;
            while (salesReaderData.Read())
            //  Must use GetSqlXml here to get a SqlXml type.
            //  GetValue returns a string instead of SqlXml.
            {
                SqlXml salesXML =
                    salesReaderData.GetSqlXml(0);
                XmlReader salesReaderXml = salesXML.CreateReader();
                Console.WriteLine("-----Row " + countRow + "-----");

                //  Move to the root.
                salesReaderXml.MoveToContent();

                //  We know each node type is either Element or Text.
                //  All elements within the root are string values.
                //  For this simple example, no elements are empty.
                while (salesReaderXml.Read())
                {
                    if (salesReaderXml.NodeType == XmlNodeType.Element)
                    {
                        string elementLocalName =
                            salesReaderXml.LocalName;
                        salesReaderXml.Read();
                        Console.WriteLine(elementLocalName + ": " +
                            salesReaderXml.Value);
                    }
                }
                countRow = countRow + 1;
            }
        }
    }
    // </Snippet1>
}
