// System.Web.Services.Description.DocumentableItem.Documentation;

/* 
   The following program demonstrates the property 'Documentation' of abstract class 'DocumentableItem'
   The program reads a wsdl document "MathService.wsdl" and instantiates a ServiceDescription instance
   from the WSDL document.
   This program demonstrates a generic utility function which can accept any of Types,PortType and Binding 
   classes as parameters.
 */
// <Snippet1>
using System;
using System.Web.Services.Description;

class DocumentableItemSample
{
   public static void Main()
   {
      ServiceDescription myServiceDescription = ServiceDescription.Read("MathService_cs.wsdl");
      Console.WriteLine("Documentation Element for type is ");
      PrintDocumentation(myServiceDescription.Types);
      foreach(PortType myPortType in myServiceDescription.PortTypes)
      {
         Console.WriteLine("Documentation Element for Port Type {0} is ",myPortType.Name);
         PrintDocumentation(myPortType);
      }
      foreach(Binding myBinding in myServiceDescription.Bindings)
      {
         Console.WriteLine("Documentation Element for Port Type {0} is ",myBinding.Name);
         PrintDocumentation(myBinding);
      }
   }
   // Prints documentation associated with a wsdl element.
   public static void PrintDocumentation(DocumentableItem myItem)
   {
      Console.WriteLine("\t" + myItem.Documentation);
   }
}
// </Snippet1>