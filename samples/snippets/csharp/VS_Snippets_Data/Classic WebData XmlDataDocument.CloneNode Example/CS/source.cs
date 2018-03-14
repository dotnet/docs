// <Snippet1>

using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;

public class Sample
{
  public static void Main()
  {
     DataSet dsNorthwind = new DataSet();

     //Create the connection string.           
     String sConnect;
     sConnect="Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind";     
         
     //Create a connection object to connect to the northwind db.
     SqlConnection nwconnect = new SqlConnection(sConnect);

     //Create a command string to select all the customers in the WA region.
     String sCommand = "Select * from Customers where Region='WA'";

     //Create an adapter to load the DataSet.
     SqlDataAdapter myDataAdapter = new SqlDataAdapter(sCommand, nwconnect);

     //Fill the DataSet with the selected records.
     myDataAdapter.Fill(dsNorthwind,"Customers");

     //Load the document with the DataSet.
     XmlDataDocument doc = new XmlDataDocument(dsNorthwind);   

     //Create a shallow clone of the XmlDataDocument. Note that although
     //none of the child nodes were copied over, the cloned node does
     //have the schema information.
     XmlDataDocument clone = (XmlDataDocument) doc.CloneNode(false);
     Console.WriteLine("Child count: {0}", clone.ChildNodes.Count);
     Console.WriteLine(clone.DataSet.GetXmlSchema());   
  }
}
// </Snippet1>

