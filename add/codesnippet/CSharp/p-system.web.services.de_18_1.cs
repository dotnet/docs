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