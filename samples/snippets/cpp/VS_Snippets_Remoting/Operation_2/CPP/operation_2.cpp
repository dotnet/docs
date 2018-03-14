// System.Web.Services.Description Operation.ParameterOrderString
// System.Web.Services.Description Operation.ParameterOrder

/* The following program demonstrates the 'ParameterOrderString' and
   'ParameterOrder' properties of 'Operation' class. It collects the
   message part names from the input WSDL file and sets to the
   'ParameterOrderString'. It then displays the same using 'ParameterOrder'
   property.
*/

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
      ServiceDescription^ myDescription = ServiceDescription::Read( "Operation_2_Input_CS.wsdl" );
      Binding^ myBinding = gcnew Binding;
      myBinding->Name = "Operation_2_ServiceHttpPost";
      XmlQualifiedName^ myQualifiedName = gcnew XmlQualifiedName( "s0:Operation_2_ServiceHttpPost" );
      myBinding->Type = myQualifiedName;
      HttpBinding^ myHttpBinding = gcnew HttpBinding;
      myHttpBinding->Verb = "POST";
      
      // Add the 'HttpBinding' to the 'Binding'.
      myBinding->Extensions->Add( myHttpBinding );
      OperationBinding^ myOperationBinding = gcnew OperationBinding;
      myOperationBinding->Name = "AddNumbers";
      HttpOperationBinding^ myHttpOperationBinding = gcnew HttpOperationBinding;
      myHttpOperationBinding->Location = "/AddNumbers";
      
      // Add the 'HttpOperationBinding' to 'OperationBinding'.
      myOperationBinding->Extensions->Add( myHttpOperationBinding );
      InputBinding^ myInputBinding = gcnew InputBinding;
      MimeContentBinding^ myPostMimeContentbinding = gcnew MimeContentBinding;
      myPostMimeContentbinding->Type = "application/x-www-form-urlencoded";
      myInputBinding->Extensions->Add( myPostMimeContentbinding );
      
      // Add the 'InputBinding' to 'OperationBinding'.
      myOperationBinding->Input = myInputBinding;
      OutputBinding^ myOutputBinding = gcnew OutputBinding;
      MimeXmlBinding^ myPostMimeXmlbinding = gcnew MimeXmlBinding;
      myPostMimeXmlbinding->Part = "Body";
      myOutputBinding->Extensions->Add( myPostMimeXmlbinding );
      
      // Add the 'OutPutBinding' to 'OperationBinding'.
      myOperationBinding->Output = myOutputBinding;
      
      // Add the 'OperationBinding' to 'Binding'.
      myBinding->Operations->Add( myOperationBinding );
      
      // Add the 'Binding' to 'BindingCollection' of 'ServiceDescription'.
      myDescription->Bindings->Add( myBinding );
      Port^ myPostPort = gcnew Port;
      myPostPort->Name = "Operation_2_ServiceHttpPost";
      myPostPort->Binding = gcnew XmlQualifiedName( "s0:Operation_2_ServiceHttpPost" );
      HttpAddressBinding^ myPostAddressBinding = gcnew HttpAddressBinding;
      myPostAddressBinding->Location = "http://localhost/Operation_2/Operation_2_Service.cs.asmx";
      
      // Add the 'HttpAddressBinding' to the 'Port'.
      myPostPort->Extensions->Add( myPostAddressBinding );
      
      // Add the 'Port' to 'PortCollection' of 'ServiceDescription'.
      myDescription->Services[ 0 ]->Ports->Add( myPostPort );
      PortType^ myPostPortType = gcnew PortType;
      myPostPortType->Name = "Operation_2_ServiceHttpPost";
      Operation^ myPostOperation = gcnew Operation;
      myPostOperation->Name = "AddNumbers";
      OperationMessage^ myPostOperationInput = dynamic_cast<OperationMessage^>(gcnew OperationInput);
      myPostOperationInput->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostIn" );
      OperationMessage^ myPostOperationOutput = dynamic_cast<OperationMessage^>(gcnew OperationOutput);
      myPostOperationOutput->Message = gcnew XmlQualifiedName( "s0:AddNumbersHttpPostout" );
      myPostOperation->Messages->Add( myPostOperationInput );
      myPostOperation->Messages->Add( myPostOperationOutput );
      
      // Add the 'Operation' to 'PortType'.
      myPostPortType->Operations->Add( myPostOperation );
      
      // Adds the 'PortType' to 'PortTypeCollection' of 'ServiceDescription'.
      myDescription->PortTypes->Add( myPostPortType );
      Message^ myPostMessage1 = gcnew Message;
      myPostMessage1->Name = "AddNumbersHttpPostIn";
      MessagePart^ myPostMessagePart1 = gcnew MessagePart;
      myPostMessagePart1->Name = "firstnumber";
      myPostMessagePart1->Type = gcnew XmlQualifiedName( "s:string" );
      MessagePart^ myPostMessagePart2 = gcnew MessagePart;
      myPostMessagePart2->Name = "secondnumber";
      myPostMessagePart2->Type = gcnew XmlQualifiedName( "s:string" );
      
      // Add the 'MessagePart' objects to 'Messages'.
      myPostMessage1->Parts->Add( myPostMessagePart1 );
      myPostMessage1->Parts->Add( myPostMessagePart2 );
      Message^ myPostMessage2 = gcnew Message;
      myPostMessage2->Name = "AddNumbersHttpPostout";
      MessagePart^ myPostMessagePart3 = gcnew MessagePart;
      myPostMessagePart3->Name = "Body";
      myPostMessagePart3->Element = gcnew XmlQualifiedName( "s0:int" );
      
      // Add the 'MessagePart' to 'Message'.
      myPostMessage2->Parts->Add( myPostMessagePart3 );
      
      // Add the 'Message' objects to 'ServiceDescription'.
      myDescription->Messages->Add( myPostMessage1 );
      myDescription->Messages->Add( myPostMessage2 );
      
      // Write the 'ServiceDescription' as a WSDL file.
      myDescription->Write( "Operation_2_Output_CS.wsdl" );
      Console::WriteLine( " 'Operation_2_Output_CS.wsdl' file created Successfully" );

      // <Snippet1>
      // <Snippet2>
      String^ myString = nullptr;
      Operation^ myOperation = gcnew Operation;
      myDescription = ServiceDescription::Read( "Operation_2_Input_CS.wsdl" );
      array<Message^>^myMessage = gcnew array<Message^>(myDescription->Messages->Count);

      // Copy the messages from the service description.
      myDescription->Messages->CopyTo( myMessage, 0 );
      for ( int i = 0; i < myDescription->Messages->Count; i++ )
      {
         array<MessagePart^>^myMessagePart = gcnew array<MessagePart^>(myMessage[ i ]->Parts->Count);

         // Copy the message parts into a MessagePart.
         myMessage[ i ]->Parts->CopyTo( myMessagePart, 0 );
         for ( int j = 0; j < myMessage[ i ]->Parts->Count; j++ )
         {
            myString = String::Concat( myString, myMessagePart[ j ]->Name, " " );
         }
      }

      // message part names.
      myOperation->ParameterOrderString = myString;
      array<String^>^myString1 = myOperation->ParameterOrder;
      int k = 0;
      Console::WriteLine( "The list of message part names is as follows:" );
      while ( k < 5 )
      {
         Console::WriteLine( myString1[ k ] );
         k++;
      }
      // </Snippet2>
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following Exception is raised : {0}", e->Message );
   }
}
