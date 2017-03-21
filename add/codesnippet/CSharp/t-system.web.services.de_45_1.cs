using System;
using System.Web.Services.Description;

namespace MimeContentBinding_work
{
   class MyMimeContentClass
   {
      static void Main()
      {
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
         Console.WriteLine("Namespace: " + MimeContentBinding.Namespace);
      }
   }
}