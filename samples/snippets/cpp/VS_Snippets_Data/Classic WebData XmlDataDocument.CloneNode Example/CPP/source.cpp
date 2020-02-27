

// <Snippet1>
#using <System.Xml.dll>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Xml;
using namespace System::Data::SqlClient;
int main()
{
   DataSet^ dsNorthwind = gcnew DataSet;
   
   //Create the connection string.           
   String^ sConnect;
   sConnect = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind";
   
   //Create a connection object to connect to the northwind db.
   SqlConnection^ nwconnect = gcnew SqlConnection( sConnect );
   
   //Create a command string to select all the customers in the WA region.
   String^ sCommand = "Select * from Customers where Region='WA'";
   
   //Create an adapter to load the DataSet.
   SqlDataAdapter^ myDataAdapter = gcnew SqlDataAdapter( sCommand,nwconnect );
   
   //Fill the DataSet with the selected records.
   myDataAdapter->Fill( dsNorthwind, "Customers" );
   
   //Load the document with the DataSet.
   XmlDataDocument^ doc = gcnew XmlDataDocument( dsNorthwind );
   
   //Create a shallow clone of the XmlDataDocument. Note that although
   //none of the child nodes were copied over, the cloned node does
   //have the schema information.
   XmlDataDocument^ clone = dynamic_cast<XmlDataDocument^>(doc->CloneNode( false ));
   Console::WriteLine( "Child count: {0}", clone->ChildNodes->Count );
   Console::WriteLine( clone->DataSet->GetXmlSchema() );
}

// </Snippet1>
