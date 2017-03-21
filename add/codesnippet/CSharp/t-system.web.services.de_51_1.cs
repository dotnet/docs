using System;
using System.Web.Services.Description;

namespace MimeContentBinding_work
{
   class MyMimeContentClass
   {
      static void Main()
      {
         ServiceDescription  myServicDescription = 
            ServiceDescription.Read("MimeMultiPartRelatedSample_cs.wsdl");

         // Get the binding collection.
         BindingCollection myBindingCollection = myServicDescription.Bindings;
         int index =0;
         for (int i= 0; i < myBindingCollection.Count;i++)
         {
            // Get the collection for MimeServiceHttpPost.
            if( myBindingCollection[i].Name == "MimeServiceHttpPost")
            {
               OperationBindingCollection myOperationBindingCollection = 
                  myBindingCollection[i].Operations;
               OutputBinding myOutputBinding = 
                  myOperationBindingCollection[0].Output;
               ServiceDescriptionFormatExtensionCollection 
                  myServiceDescriptionFormatExtensionCollection = 
                  myOutputBinding.Extensions;
               MimeMultipartRelatedBinding myMimeMultipartRelatedBinding  = 
                  (MimeMultipartRelatedBinding)
                  myServiceDescriptionFormatExtensionCollection.Find(
                  typeof(MimeMultipartRelatedBinding));
               MimePartCollection myMimePartCollection = 
                  myMimeMultipartRelatedBinding.Parts;
               foreach( MimePart myMimePart in myMimePartCollection)
               {
                  Console.WriteLine("Extension types added to MimePart: " + 
                     index ++);
                  Console.WriteLine ("----------------------------");
                  foreach(object myExtension in myMimePart.Extensions)
                     Console.WriteLine(myExtension.GetType()); 
                  Console.WriteLine();
               }
               break;
            }
         }
      }
   }
}