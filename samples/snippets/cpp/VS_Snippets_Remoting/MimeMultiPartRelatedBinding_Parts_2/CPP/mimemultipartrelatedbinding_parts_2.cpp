// System::Web::Services::Description.MimeMultipartRelatedBinding
// System::Web::Services::Description.MimeMultipartRelatedBinding::Parts;

/* The following program demonstrates the property 'Parts' of class 'MimeMultipartRelatedBinding'.
It reads 'MimeMultiPartRelatedSample_cpp.wsdl'file and instantiates a ServiceDescription Object*.
'MimeMultipartRelatedBinding' Object* is retrieved from Extension
points of OutputBinding for one of the Binding Object* and its property'Parts' has been demonstrated.
*/

// <Snippet1>
#using <System.dll>
#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;

int main()
{
   // <Snippet2>
   ServiceDescription^ myServicDescription = ServiceDescription::Read( "MimeMultiPartRelatedSample_cpp.wsdl" );

   // Get the binding collection.
   BindingCollection^ myBindingCollection = myServicDescription->Bindings;
   int index = 0;
   for ( int i = 0; i < myBindingCollection->Count; i++ )
      // Get the collection for MimeServiceHttpPost.
      if ( String::Compare( myBindingCollection[ i ]->Name, "MimeServiceHttpPost" ) == 0 )
      {
         OperationBindingCollection^ myOperationBindingCollection = myBindingCollection[ i ]->Operations;
         OutputBinding^ myOutputBinding = myOperationBindingCollection[ 0 ]->Output;
         ServiceDescriptionFormatExtensionCollection ^ myServiceDescriptionFormatExtensionCollection = myOutputBinding->Extensions;
         MimeMultipartRelatedBinding^ myMimeMultipartRelatedBinding = dynamic_cast<MimeMultipartRelatedBinding^>(myServiceDescriptionFormatExtensionCollection->Find( MimeMultipartRelatedBinding::typeid ));
         MimePartCollection^ myMimePartCollection = myMimeMultipartRelatedBinding->Parts;
         IEnumerator^ myEnum = myMimePartCollection->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            MimePart^ myMimePart = dynamic_cast<MimePart^>(myEnum->Current);
            Console::WriteLine( "Extension Types added to MimePart: {0}", index++ );
            Console::WriteLine( "----------------------------" );
            IEnumerator^ myEnum2 = myMimePart->Extensions->GetEnumerator();
            while ( myEnum2->MoveNext() )
            {
               Console::WriteLine( myEnum2->Current->GetType() );
            }

            Console::WriteLine( "" );
         }

         break;
      }
   // </Snippet2>
}
// </Snippet1>
