//<snippet1>
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;


public class Sample
{
  public static void Main()
  {

     // Create a DataSet and load it with customer data.
     DataSet dsNorthwind = new DataSet();        
     String sConnect;
     sConnect="Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind";  
     SqlConnection nwconnect = new SqlConnection(sConnect);
     String sCommand = "Select * from Customers where Region='WA'";
     SqlDataAdapter myDataAdapter = new SqlDataAdapter(sCommand, nwconnect);
     myDataAdapter.Fill(dsNorthwind,"Customers"); 

     // Load the DataSet into an XmlDataDocument.
     XmlDataDocument doc = new XmlDataDocument(dsNorthwind);   

     // Create the XslTransform object and load the stylesheet.
     XslTransform xsl = new XslTransform();     
     xsl.Load("customers.xsl");

     // Create an XPathNavigator to use in the transform.
     XPathNavigator nav = doc.CreateNavigator();

     // Create a FileStream object.
     FileStream fs = new FileStream("cust.html", FileMode.Create);
 
     // Transform the data.
     xsl.Transform(nav, null, fs, null);
	
  }
}
//</snippet1>