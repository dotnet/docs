// System.Web.Services.Description.ImportCollection.Add;
// System.Web.Services.Description.ImportCollection.Insert;
// System.Web.Services.Description.Import.Import();
// System.Web.Services.Description.Import.Location;
// System.Web.Services.Description.Import.Namespace;
// System.Web.Services.Description.Import.ServiceDescription;
// System.Web.Services.Description.Import;

/* The following example demonstrates the constructor 'Import()' and properties 'Namespace','Location','Namespace',
   'ServiceDescription' of Import Class. Methods 'Add' and 'Insert' of Class 'ImportCollection' are also demonstrated.
   This example uses a sample provided in WSDL specification to explain Import and ImportCollection.
   It adds import instances to ImportCollection as suggested in the specification sample and enumerates the same to the console.
   Note: This is an illustrative sample using an example from WSDL specification. The real world web service has been assumed.
*/

// <Snippet7>
using System;
using System.Web.Services.Description;
using System.Collections;
using System.Xml;

class MySample
{
   public static void Main()
   {
      Console.WriteLine("Import Sample");
// <Snippet1>
      ServiceDescription myServiceDescription = 
         ServiceDescription.Read("StockQuote_cs.wsdl");
      myServiceDescription.Imports.Add(
         CreateImport("http://localhost/stockquote/schemas",
         "http://localhost/stockquote/stockquote_cs.xsd"));
// </Snippet1>
      // Save the ServiceDescripition to an external file.
      myServiceDescription.Write("StockQuote_cs.wsdl");
      Console.WriteLine(
         "Successfully added import to WSDL document 'StockQuote_cs.wsdl'");

      // Print the import collection to the console.
      PrintImportCollection("StockQuote_cs.wsdl");
// <Snippet2>
      myServiceDescription = 
         ServiceDescription.Read("StockQuoteService_cs.wsdl");
      myServiceDescription.Imports.Insert(
         0,CreateImport("http://localhost/stockquote/definitions",
         "http://localhost/stockquote/stockquote_cs.wsdl"));
// </Snippet2>
      // Save the ServiceDescripition to an external file.
      myServiceDescription.Write("StockQuoteService_cs.wsdl");
      Console.WriteLine("");
      Console.WriteLine("Successfully added import to WSDL " +
         "document 'StockQuoteService_cs.wsdl'");

      //Print the import collection to the console.
      PrintImportCollection("StockQuoteService_cs.wsdl");
   }
// <Snippet3>
// <Snippet4>
// <Snippet5>
   // Creates an Import object with namespace and location.
   public static Import CreateImport(string targetNamespace, 
      string targetlocation)
   {
      Import myImport = new Import();
      myImport.Location = targetlocation;
      myImport.Namespace = targetNamespace;
      return myImport;
   }
// </Snippet5>
// </Snippet4>
// </Snippet3>

// <Snippet6>
   public static void PrintImportCollection(string fileName_wsdl)
   {
      // Read import collection properties from generated WSDL file.
      ServiceDescription myServiceDescription1 = 
         ServiceDescription.Read(fileName_wsdl);
      ImportCollection myImportCollection = myServiceDescription1.Imports;
      Console.WriteLine("Enumerating Import Collection for file '" + 
         fileName_wsdl +"'...");

      // Print Import properties to console.
      for(int i =0; i < myImportCollection.Count; ++i)
      {
         Console.WriteLine("Namespace : " + myImportCollection[i].Namespace);
         Console.WriteLine("Location  : " + myImportCollection[i].Location);
         Console.WriteLine("ServiceDescription  : " + 
            myImportCollection[i].ServiceDescription.Name);
      }
   }
// </Snippet6>
}
// </Snippet7>
