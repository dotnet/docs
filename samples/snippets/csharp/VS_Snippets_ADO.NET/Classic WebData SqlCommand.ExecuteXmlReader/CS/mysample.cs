

using System;
using System.Data;
using System.Data.SqlClient;



class Program
{
    static void Main()
    {
        string str = "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=SSPI";
        string qs = "SELECT OrderID, CustomerID FROM dbo.Orders;";
        string q = "SELECT * FROM dbo.Customers FOR XML AUTO, XMLDATA";
        CreateXMLReader(q, str);

    }
    // <Snippet1>
    private static void CreateXMLReader(string queryString,
        string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(queryString, connection);
            System.Xml.XmlReader reader = command.ExecuteXmlReader();
        }
    }
    // </Snippet1>
}

