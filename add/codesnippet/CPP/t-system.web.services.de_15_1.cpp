#using <System.dll>
#using <System.Xml.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Web::Services::Description;
MessageBinding^ CreateInputOutputBinding( String^ myBindName, bool isInputBinding )
{
   
   // Value isInputBinding = true ---> return type = InputBinding.
   // Value isInputBinding = false --> return type = OutputBinding.
   MessageBinding^ myMessageBinding = nullptr;
   switch ( isInputBinding )
   {
      case true:
         myMessageBinding = gcnew InputBinding;
         Console::WriteLine( "Added an InputBinding" );
         break;

      case false:
         myMessageBinding = gcnew OutputBinding;
         Console::WriteLine( "Added an OutputBinding" );
         break;
   }
   myMessageBinding->Name = myBindName;
   SoapBodyBinding^ mySoapBodyBinding = gcnew SoapBodyBinding;
   mySoapBodyBinding->Use = SoapBindingUse::Literal;
   myMessageBinding->Extensions->Add( mySoapBodyBinding );
   Console::WriteLine( "Added extensibility element of type : {0}", mySoapBodyBinding->GetType() );

   return myMessageBinding;
}


// Used to create OperationBinding instances within Binding.
OperationBinding^ CreateOperationBinding( String^ myOperation, String^ targetNamespace )
{
   // Create OperationBinding for Operation.
   OperationBinding^ myOperationBinding = gcnew OperationBinding;
   myOperationBinding->Name = myOperation;

   // Create InputBinding for operation.
   InputBinding^ myInputBinding = dynamic_cast<InputBinding^>(CreateInputOutputBinding( nullptr, true ));

   // Create OutputBinding for operation.
   OutputBinding^ myOutputBinding = dynamic_cast<OutputBinding^>(CreateInputOutputBinding( nullptr, false ));

   // Add InputBinding and OutputBinding to OperationBinding.
   myOperationBinding->Input = myInputBinding;
   myOperationBinding->Output = myOutputBinding;

   // Create an extensibility element for SoapOperationBinding.
   SoapOperationBinding^ mySoapOperationBinding = gcnew SoapOperationBinding;
   mySoapOperationBinding->Style = SoapBindingStyle::Document;
   mySoapOperationBinding->SoapAction = String::Concat( targetNamespace, myOperation );

   // Add the extensibility element SoapOperationBinding to OperationBinding.
   myOperationBinding->Extensions->Add( mySoapOperationBinding );
   return myOperationBinding;
}

int main()
{
   /* OperationBinding* addOperationBinding = */
   CreateOperationBinding( "Add", "http://tempuri.org/" );
}