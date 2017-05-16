// System.Web.Services.Description.Read(StreamReader)
/* 
   The following example demonstrates the 'Read(StreamReader)' method  of 
   'ServiceDescription' class.A ServiceDescription instance is 
   obtained from existing Wsdl. Name property of Bindings in the 
   ServiceDescription is displayed to console.
*/

using System;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml;
using System.IO;


class MyService
{
   static void Main()
   {
    try
    {
// <Snippet1>
      // Create a StreamReader to read a WSDL file.
      StreamReader myStreamReader = new StreamReader("MyWsdl.wsdl");
      ServiceDescription myDescription = 
         ServiceDescription.Read(myStreamReader);
      Console.WriteLine("Bindings are:");

      // Display the Bindings present in the WSDL file.
      foreach(Binding myBinding in myDescription.Bindings)
      {
         Console.WriteLine(myBinding.Name);
      }
// </Snippet1>
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
    }
   }
}

