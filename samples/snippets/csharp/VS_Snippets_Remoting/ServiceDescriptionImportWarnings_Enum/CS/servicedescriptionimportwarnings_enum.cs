// System.Web.Services.Description.ServiceDescriptionImportWarnings.NoCodeGenerated
// System.Web.Services.Description.ServiceDescriptionImportWarnings.NoMethodsGenerated
// System.Web.Services.Description.ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored
// System.Web.Services.Description.ServiceDescriptionImportWarnings.OptionalExtensionsIgnored
// System.Web.Services.Description.ServiceDescriptionImportWarnings.RequiredExtensionsIgnored
// System.Web.Services.Description.ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored

/*
   The following program demonstrates the enum values of 'ServiceDescriptionImportWarnings'.
   'Import' method of 'ServiceDescriptionImporter' will give the enumaration. The user selected
   option will help in taking the related wsdl file and returns the corresponding warning which
   is displayed on the console.
*/

using System;
using System.Security.Permissions;
using System.Web.Services.Description;
using System.CodeDom;

public class ServiceDescriptionImportWarnings_Enum
{
   public static void Main()
   {
      DisplayWarning("ServiceDescriptionImportWarnings_NoCodeGenerated.wsdl");
      DisplayWarning("ServiceDescriptionImportWarnings_NoMethodsGenerated.wsdl");
      DisplayWarning("ServiceDescriptionImportWarnings_UnsupportedOperationsIgnored.wsdl");
      DisplayWarning("ServiceDescriptionImportWarnings_OptionalExtensionsIgnored.wsdl");
   }



   [SecurityPermissionAttribute(SecurityAction.Demand, Unrestricted=true)]
   public static void DisplayWarning(string myWSDLFileName) 
   {
// <Snippet1>
      String myDisplay;
      // Read wsdl file.
      ServiceDescription myServiceDescription = ServiceDescription.Read
         (myWSDLFileName);

      ServiceDescriptionImporter myServiceDescriptionImporter = new
         ServiceDescriptionImporter();

      // Add 'myServiceDescription' to 'myServiceDescriptionImporter'.
      myServiceDescriptionImporter.AddServiceDescription
         (myServiceDescription, "", "");

      myServiceDescriptionImporter.ProtocolName = "HttpGet";
      CodeNamespace myCodeNamespace = new CodeNamespace();
      CodeCompileUnit myCodeCompileUnit = new CodeCompileUnit();

      // Invoke 'Import' method.
      ServiceDescriptionImportWarnings myWarning = 
         myServiceDescriptionImporter.Import(myCodeNamespace,
         myCodeCompileUnit);

      switch(myWarning)
      {
         case ServiceDescriptionImportWarnings.NoCodeGenerated :
            myDisplay="NoCodeGenerated";
            break;
         case ServiceDescriptionImportWarnings.NoMethodsGenerated :
            myDisplay="NoMethodsGenerated";
            break;
         case ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored :
            myDisplay="UnsupportedOperationsIgnored";
            break;
         case ServiceDescriptionImportWarnings.OptionalExtensionsIgnored :
            myDisplay="OptionalExtensionsIgnored";
            break;
         case ServiceDescriptionImportWarnings.RequiredExtensionsIgnored :
            myDisplay="RequiredExtensionsIgnored";
            break;
         case ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored :
            myDisplay="UnsupportedBindingsIgnored";
            break;
         default :
            myDisplay="General Warning";
            break;
      }
      Console.WriteLine ("Warning : " + myDisplay);
// </Snippet1>
   }
}