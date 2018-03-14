// System.Web.Services.Description.ServiceDescription.Imports

/* The following program demonstrates the property 'Imports' of 'ServiceDescription' class.
   The input to the program is a WSDL file 'ServiceDescription_Imports_Input_CS.wsdl' which 
   is not having the import element. A new 'Import' is defined and added to the new modified 
   'ServiceDescription_Imports_Output_CS.wsdl' file.
*/

using System;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml;

class MyServiceDescription
{
   public static void Main( )
   {
// <Snippet1>
      ServiceDescription myServiceDescription = new ServiceDescription();
      myServiceDescription = 
         ServiceDescription.Read("ServiceDescription_Imports_Input_CS.wsdl");
      ImportCollection myImportCollection = myServiceDescription.Imports;

      // Create an Import.
      Import myImport = new Import();
      myImport.Namespace = myServiceDescription.TargetNamespace;

      // Set the location for the Import.
      myImport.Location = "http://www.contoso.com/";
      myImportCollection.Add(myImport);
      myServiceDescription.Write("ServiceDescription_Imports_Output_CS.wsdl");
      myImportCollection.Clear();
      myServiceDescription = 
         ServiceDescription.Read("ServiceDescription_Imports_Output_CS.wsdl");
      myImportCollection = myServiceDescription.Imports;
      Console.WriteLine(
         "The Import elements added to the ImportCollection are: ");
      for(int i = 0; i < myImportCollection.Count; i++)
      {
         Console.WriteLine((i+1) + ". " + myImportCollection[i].Location);
      }
// </Snippet1>
   }
}
