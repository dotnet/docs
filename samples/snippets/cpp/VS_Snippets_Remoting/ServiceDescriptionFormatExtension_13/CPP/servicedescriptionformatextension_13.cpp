

// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::ctor
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection->Add()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::Item
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::Find(System::Type type)
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::FindAll(System::Type type)
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::IsHandled()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::IsRequired()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::CopyTo()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::Contains()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::IndexOf()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::Remove()
// System::Web::Services::Description.ServiceDescriptionFormatExtensionCollection::Insert()
/* The following program demonstrates the class, properties and methods of
'ServiceDescriptionFormatExtensionCollection'
class. It creates a ServiceDescription object, uses it to create
'ServiceDescriptionFormatExtensionCollection' object. Collection
object is used for demonstration of class properties and methods.

Note: This program requires 'Sample_cpp.wsdl' file to be placed in
the same directory as that of .exe for running.
*/
// <Snippet1>
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
      // <Snippet2>
      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "Sample_cpp.wsdl" );
      ServiceDescriptionFormatExtensionCollection^ myCollection = gcnew ServiceDescriptionFormatExtensionCollection( myServiceDescription );
      // </Snippet2>

      // <Snippet3>
      SoapBinding^ mySoapBinding1 = gcnew SoapBinding;
      SoapBinding^ mySoapBinding2 = gcnew SoapBinding;
      SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
      MyFormatExtension^ myFormatExtensionObject = gcnew MyFormatExtension;

      // Add elements to collection.
      myCollection->Add( mySoapBinding1 );
      myCollection->Add( mySoapAddressBinding );
      myCollection->Add( mySoapBinding2 );
      myCollection->Add( myFormatExtensionObject );
      // </Snippet3>

      // <Snippet4>
      Console::WriteLine( "Collection contains following types of elements: " );
      
      // Display the 'Type' of the elements in collection.
      for ( int i = 0; i < myCollection->Count; i++ )
         Console::WriteLine( myCollection[ i ]->GetType() );
      // </Snippet4>

      // <Snippet5>
      // Check element of type 'SoapAddressBinding' in collection.
      Object^ myObj = myCollection->Find( mySoapAddressBinding->GetType() );
      if ( myObj == nullptr )
            Console::WriteLine( "Element of type ' {0}' not found in collection.", mySoapAddressBinding->GetType() );
      else
            Console::WriteLine( "Element of type ' {0}' found in collection.", mySoapAddressBinding->GetType() );
      // </Snippet5>

      // <Snippet6>
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
      // </Snippet6>

      // <Snippet7>
      // Check 'IsHandled' status for 'myFormatExtensionObject' object in collection.
      Console::WriteLine( "'IsHandled' status for {0} object is {1}.", myFormatExtensionObject, myCollection->IsHandled( myFormatExtensionObject ) );
      // </Snippet7>

      // <Snippet8>
      // Check 'IsRequired' status for 'myFormatExtensionObject' object in collection.
      Console::WriteLine( "'IsRequired' status for {0} object is {1}.", myFormatExtensionObject, myCollection->IsRequired( myFormatExtensionObject ) );
      // </Snippet8>

      // <Snippet9>
      // Copy elements of collection to an Object array.
      array<Object^>^myObjectArray2 = gcnew array<Object^>(myCollection->Count);
      myCollection->CopyTo( myObjectArray2, 0 );
      Console::WriteLine( "Collection elements are copied to an object array." );
      // </Snippet9>

      // <Snippet10>
      // Check for 'myFormatExtension' object in collection.
      if ( myCollection->Contains( myFormatExtensionObject ) )
      {
         // <Snippet11>
         // Get index of a 'myFormatExtension' object in collection.
         Console::WriteLine( "Index of 'myFormatExtensionObject' is {0} in collection.", myCollection->IndexOf( myFormatExtensionObject ) );
         // </Snippet11>

         // <Snippet12>
         // Remove 'myFormatExtensionObject' element from collection.
         myCollection->Remove( myFormatExtensionObject );
         Console::WriteLine( "'myFormatExtensionObject' is removed  from collection." );
         // </Snippet12>
      }
      // </Snippet10>

      // <Snippet13>
      // Insert 'MyFormatExtension' object.
      myCollection->Insert( 0, myFormatExtensionObject );
      Console::WriteLine( "'myFormatExtensionObject' is inserted to collection." );
      // </Snippet13>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "The following exception was raised: {0}", e->Message );
   }
}
// </Snippet1>
