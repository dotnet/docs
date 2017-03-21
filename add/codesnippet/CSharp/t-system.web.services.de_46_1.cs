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
            ServiceDescriptionImportStyle myStyle = myImporter.Style;
            Console.WriteLine("Import style: " + myStyle.ToString());
         }
         catch (Exception e)
         {
            Console.WriteLine("Following exception was thrown: " 
               + e.ToString());
         }
      }
   }
}