

// System.Web.Services.Description.MimeTextMatch
// System.Web.Services.Description.MimeTextMatch.Capture
// System.Web.Services.Description.MimeTextMatch.Group
// System.Web.Services.Description.MimeTextMatch.Repeats
// System.Web.Services.Description.MimeTextMatch.RepeatsString
/* The following program demostrates constructor, 'Capture', 'Group',
   'Repeats' and 'RepeatsString' properties of 'MimeTextMatch'class.
   It takes 'MimeTextMatch_5_Input_CPP.wsdl' as input which does not
   contain 'Binding' object supporting 'HttpPost'. A text pattern
   ''TITLE&gt;(.*?)&lt;' with text name as 'Title' and type
   name set which is to be searched in a HTTP transmission is added to the ServiceDescription.
   The modified ServiceDescription is written into 'MimeTextMatch_5_Output_CPP.wsdl'.
*/
// <Snippet1>
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;
using namespace System::Xml;

int main()
{
   try
   {
      int myInt = 0;
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MimeTextMatch_5_Input_CPP.wsdl" );

      // Create the 'Binding' object.
      Binding^ myBinding = gcnew Binding;

      // Initialize 'Name' property of 'Binding' class.
      myBinding->Name = "MimeTextMatchServiceHttpPost";
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:MimeTextMatchServiceHttpPost" );
      myBinding->Type = myXmlQualifiedName;

      // Create the 'HttpBinding' object.
      HttpBinding^ myHttpBinding = gcnew HttpBinding;
      myHttpBinding->Verb = "POST";

      // Add the 'HttpBinding' to the 'Binding'.
      myBinding->Extensions->Add( myHttpBinding );

      // Create the 'OperationBinding' object.
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = "AddNumbers";
      HttpOperationBinding^ myHttpOperationBinding = gcnew HttpOperationBinding;
      myHttpOperationBinding->Location = "/AddNumbers";

      // Add the 'HttpOperationBinding' object to 'OperationBinding'.
      myOperationBinding->Extensions->Add( myHttpOperationBinding );

      // <Snippet5>
      // <Snippet4>
      // <Snippet3>
      // <Snippet2>
      // Create an InputBinding.
      InputBinding^ myInputBinding = gcnew InputBinding;
      MimeTextBinding^ myMimeTextBinding = gcnew MimeTextBinding;
      MimeTextMatchCollection^ myMimeTextMatchCollection1 = gcnew MimeTextMatchCollection;
      array<MimeTextMatch^>^myMimeTextMatch = gcnew array<MimeTextMatch^>(3);
      myMimeTextMatchCollection1 = myMimeTextBinding->Matches;

      // Intialize the MimeTextMatch.
      for ( myInt = 0; myInt < 3; myInt++ )
      {
         // Get a new MimeTextMatch.
         myMimeTextMatch[ myInt ] = gcnew MimeTextMatch;

         // Assign values to properties of the MimeTextMatch.
         myMimeTextMatch[ myInt ]->Name = String::Format( "Title{0}", Convert::ToString( myInt ) );
         myMimeTextMatch[ myInt ]->Type = "*/*";
         myMimeTextMatch[ myInt ]->Pattern = "TITLE&gt;(.*?)&lt;";
         myMimeTextMatch[ myInt ]->IgnoreCase = true;
         myMimeTextMatch[ myInt ]->Capture = 2;
         myMimeTextMatch[ myInt ]->Group = 2;
         if ( myInt != 0 )
         {
            
            // Assign the Repeats property if the index is not 0.
            myMimeTextMatch[ myInt ]->Repeats = 2;
         }
         else
         {
            
            // Assign the RepeatsString property if the index is 0.
            myMimeTextMatch[ myInt ]->RepeatsString = "4";
         }
         myMimeTextMatchCollection1->Add( myMimeTextMatch[ myInt ] );

      }
      // </Snippet2>
      // </Snippet3>
      // </Snippet4>
      // </Snippet5>

      myInputBinding->Extensions->Add( myMimeTextBinding );

      // Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding->Input = myInputBinding;

      // Create the 'OutputBinding' instance.
      OutputBinding^ myOutput = gcnew OutputBinding;
      MimeXmlBinding^ postMimeXmlbinding = gcnew MimeXmlBinding;

      // Initialize 'Part' property of 'MimeXmlBinding' class.
      postMimeXmlbinding->Part = "Body";

      // Add 'MimeXmlBinding' instance to 'OutputBinding' instance.
      myOutput->Extensions->Add( postMimeXmlbinding );

      // Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding->Output = myOutput;

      // Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding->Output = myOutput;

      // Add the 'OperationBinding' to 'Binding'.
      myBinding->Operations->Add( myOperationBinding );

      // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myServiceDescription->Bindings->Add( myBinding );

      // Write the 'ServiceDescription' as a WSDL file.
      myServiceDescription->Write( "MimeTextMatch_5_Output_CPP.wsdl" );
      Console::WriteLine( "WSDL file with name 'MimeTextMatch_5_Output_CPP.wsdl' is"
      " created successfully." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
