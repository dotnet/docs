' <Snippet1>

Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
 
 
public class Sample
 
  public shared sub Main()
   
    Dim dsNorthwind as DataSet = new DataSet()
 
    'Create the connection string.
    Dim sConnect as String           
    sConnect="Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind"     
          
    'Create a connection object to connect to the northwind db.
    Dim nwconnect as SqlConnection
    nwconnect = new SqlConnection(sConnect)
 
    'Create a command string to select all the customers in the WA region.
    Dim sCommand as String = "Select * from Customers where Region='WA'"
 
    'Create an Adapter to load the DataSet.
    Dim myDataAdapter as SqlDataAdapter
    myDataAdapter = new SqlDataAdapter(sCommand, nwconnect)
 
    'Fill the DataSet with the selected records.
    myDataAdapter.Fill(dsNorthwind, "Customers")
 
    'Load the document with the DataSet.
    Dim doc as XmlDataDocument = new XmlDataDocument(dsNorthwind)  
 
    'Create a shallow clone of the XmlDataDocument. Note that although
    'none of the child nodes were copied over, the cloned node does
    'have the schema information.
    Dim clone as XmlDataDocument
    clone = CType (doc.CloneNode(false), XmlDataDocument) 
    Console.WriteLine("Child count: {0}", clone.ChildNodes.Count)
    Console.WriteLine(clone.DataSet.GetXmlSchema())
 
  end sub
end class
' </Snippet1>

