// System.Web.Services.Description.ServiceDescription.Namespace
/* 
   The following example demonstrates 'Namespace' property of 'ServiceDescription' class.The input to the program is a 
   WSDL file 'MyWsdl.wsdl'.This program displays the Namespace of 'ServiceDescription' class.
*/
using System;
using System.Web.Services;
using System.Web.Services.Description;


namespace ServiceDescription1
{
   class MyService
   {
      static void Main()
      {
      try
      {
         // <Snippet1>
         ServiceDescription myDescription = 
            ServiceDescription.Read("MyWsdl_CS.wsdl");
         Console.WriteLine("Namespace: " + ServiceDescription.Namespace);
         // </Snippet1>
       }
       catch(Exception e)
       {
         Console.WriteLine("Exception: " + e.Message);
       }
       
      }
   }
}
