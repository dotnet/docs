#using <System.Web.Services.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Web::Services::Description;
using namespace System::Collections;

ref class MyFormatExtension: public ServiceDescriptionFormatExtension
{
public:
   MyFormatExtension()
   {
      // Set the properties.
      this->Handled = true;
      this->Required = true;
   }
};

int main()
{
   try
   {
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Sample_cpp.wsdl" );
      ServiceDescriptionFormatExtensionCollection^ myCollection = gcnew ServiceDescriptionFormatExtensionCollection( myServiceDescription );

      SoapBinding^ mySoapBinding1 = gcnew SoapBinding;
      SoapBinding^ mySoapBinding2 = gcnew SoapBinding;
      SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
      MyFormatExtension^ myFormatExtensionObject = gcnew MyFormatExtension;

      // Add elements to collection.
      myCollection->Add( mySoapBinding1 );
      myCollection->Add( mySoapAddressBinding );
      myCollection->Add( mySoapBinding2 );
      myCollection->Add( myFormatExtensionObject );

      Console::WriteLine( "Collection contains following types of elements: " );
      
      // Display the 'Type' of the elements in collection.
      for ( int i = 0; i < myCollection->Count; i++ )
         Console::WriteLine( myCollection[ i ]->GetType() );

      // Check element of type 'SoapAddressBinding' in collection.
      Object^ myObj = myCollection->Find( mySoapAddressBinding->GetType() );
      if ( myObj == nullptr )
            Console::WriteLine( "Element of type ' {0}' not found in collection.", mySoapAddressBinding->GetType() );
      else
            Console::WriteLine( "Element of type ' {0}' found in collection.", mySoapAddressBinding->GetType() );

      // Check all elements of type 'SoapBinding' in collection.
      array<Object^>^myObjectArray1 = gcnew array<Object^>(myCollection->Count);
      myObjectArray1 = myCollection->FindAll( mySoapBinding1->GetType() );
      int myNumberOfElements = 0;
      IEnumerator^ myIEnumerator = myObjectArray1->GetEnumerator();

      // Calculate number of elements of type 'SoapBinding'.
      while ( myIEnumerator->MoveNext() )
            if ( mySoapBinding1->GetType() == myIEnumerator->Current->GetType() )
            myNumberOfElements++;
      Console::WriteLine( "Collection contains {0} objects of type ' {1}'.", myNumberOfElements, mySoapBinding1->GetType() );

      // Check 'IsHandled' status for 'myFormatExtensionObject' object in collection.
      Console::WriteLine( "'IsHandled' status for {0} object is {1}.", myFormatExtensionObject, myCollection->IsHandled( myFormatExtensionObject ) );

      // Check 'IsRequired' status for 'myFormatExtensionObject' object in collection.
      Console::WriteLine( "'IsRequired' status for {0} object is {1}.", myFormatExtensionObject, myCollection->IsRequired( myFormatExtensionObject ) );

      // Copy elements of collection to an Object array.
      array<Object^>^myObjectArray2 = gcnew array<Object^>(myCollection->Count);
      myCollection->CopyTo( myObjectArray2, 0 );
      Console::WriteLine( "Collection elements are copied to an object array." );

      // Check for 'myFormatExtension' object in collection.
      if ( myCollection->Contains( myFormatExtensionObject ) )
      {
         // Get index of a 'myFormatExtension' object in collection.
         Console::WriteLine( "Index of 'myFormatExtensionObject' is {0} in collection.", myCollection->IndexOf( myFormatExtensionObject ) );

         // Remove 'myFormatExtensionObject' element from collection.
         myCollection->Remove( myFormatExtensionObject );
         Console::WriteLine( "'myFormatExtensionObject' is removed  from collection." );
      }

      // Insert 'MyFormatExtension' object.
      myCollection->Insert( 0, myFormatExtensionObject );
      Console::WriteLine( "'myFormatExtensionObject' is inserted to collection." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}