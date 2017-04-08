// System.Web.Services.Description.ServiceDescriptionImportStyle
// System.Web.Services.Description.ServiceDescriptionImportStyle.Client

/* The following program demonstrates the 'ServiceDescriptionImportStyle'
   enumeration and 'Client' member of 'ServiceDescriptionImportStyle' in 
   'System.Web.Services.Description' namespace. It creates a 
   ServiceDescriptionImporter object from a .wsdl file and demonstrates
   the usage of Client. */

// <Snippet1>
using System;
using System.Web.Services.Description;

namespace MyServiceDescription
{
   class MyImporter
   {
      public static void Main()
      {
         try
         {
            ServiceDescription myServiceDescription = 
               ServiceDescription.Read("Sample_CS.wsdl");

            ServiceDescriptionImporter myImporter = 
               new ServiceDescriptionImporter();
            
            myImporter.ProtocolName = "Soap";
            myImporter.AddServiceDescription(myServiceDescription, "", "");
// <Snippet2>
            ServiceDescriptionImportStyle myStyle = myImporter.Style;
            Console.WriteLine("Import style: " + myStyle.ToString());
// </Snippet2>
         }
         catch (Exception e)
         {
            Console.WriteLine("Following exception was thrown: " 
               + e.ToString());
         }
      }
   }
}
// </Snippet1>
