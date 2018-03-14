// System.Web.Services.Description.MimeContentBinding.Type
// System.Web.Services.Description.MimeContentBinding.Part
// System.Web.Services.Description.MimeContentBinding.NameSpace
// System.Web.Services.Description.MimeContentBinding

/* The following program demonstrates properties 'Type','Part'
   and field 'NameSpace'of class 'MimeContentBinding'.It reads 'MimeContentSample_cs.wsdl'file
   and instantiates a ServiceDescription object.'MimeContentBinding' objects  are retrieved from Extension
   points of OutputBinding for one of the Binding object and its properties 'Type','Part'are displayed.It also        displays 'NameSpace' of the 'MimeContentBinding' object.
*/
// <Snippet4>
using System;
using System.Web.Services.Description;

namespace MimeContentBinding_work
{
   class MyMimeContentClass
   {
      static void Main()
      {
// <Snippet1>
// <Snippet2>
// <Snippet3>
         ServiceDescription  myServiceDescription =  
            ServiceDescription.Read("MimeContentSample_cs.wsdl");

         // Get the Binding.
         Binding myBinding = myServiceDescription.Bindings["b1"];

         // Get the first OperationBinding.
         OperationBinding myOperationBinding = myBinding.Operations[0];
         OutputBinding myOutputBinding = myOperationBinding.Output;
         ServiceDescriptionFormatExtensionCollection  
            myServiceDescriptionFormatExtensionCollection = 
            myOutputBinding.Extensions;

         // Find all MimeContentBinding objects in extensions.
         MimeContentBinding[] myMimeContentBindings = (MimeContentBinding[])
            myServiceDescriptionFormatExtensionCollection.FindAll(
            typeof(MimeContentBinding));

         // Enumerate the array and display MimeContentBinding properties.
         foreach(MimeContentBinding myMimeContentBinding in 
            myMimeContentBindings)
         {
            Console.WriteLine("Type: " + myMimeContentBinding.Type);
            Console.WriteLine("Part: " + myMimeContentBinding.Part);
         }
// </Snippet1>
// </Snippet2>
         Console.WriteLine("Namespace: " + MimeContentBinding.Namespace);
// </Snippet3>
      }
   }
}
// </Snippet4>
