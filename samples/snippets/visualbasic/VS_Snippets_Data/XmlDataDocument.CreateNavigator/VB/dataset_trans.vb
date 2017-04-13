'<snippet1>
Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl

public class Sample

  public shared sub Main()

     ' Create a DataSet and load it with customer data.
     Dim dsNorthwind as DataSet = new DataSet()        
     Dim sConnect as String           
     sConnect="Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind"     
     Dim nwconnect as SqlConnection
     nwconnect = new SqlConnection(sConnect)
     Dim sCommand as String = "Select * from Customers where Region='WA'"
     Dim myDataAdapter as SqlDataAdapter
     myDataAdapter = new SqlDataAdapter(sCommand, nwconnect)
     myDataAdapter.Fill(dsNorthwind,"Customers")

     ' Load the DataSet into an XmlDataDocument.
     Dim doc as XmlDataDocument = new XmlDataDocument(dsNorthwind)   

     ' Create the XslTransform object and load the stylesheet.
     Dim xsl as XslTransform = new XslTransform()     
     xsl.Load("customers.xsl")

     ' Create an XPathNavigator to use in the transform.
     Dim nav as XPathNavigator = doc.CreateNavigator()

     ' Create a FileStream object.
     Dim fs as FileStream = new FileStream("cust.html", FileMode.Create)
 
     ' Transform the data.
     xsl.Transform(nav, nothing, fs, nothing)
	
  end sub
end class
'</snippet1>