

//<SNIPPET1>
#using <system.dll>

using namespace System;
using namespace System::Security::Cryptography;
int main()
{
   
   // Assign values to strings.
   String^ Value1 = "1.2.840.113549.1.1.1";
   String^ Name1 = "3DES";
   String^ Value2 = "1.3.6.1.4.1.311.20.2";
   String^ InvalidName = "This name is not a valid name";
   String^ InvalidValue = "1.1.1.1.1.1.1.1";
   
   // Create new Oid objects using the specified values.
   // Note that the corresponding Value or Friendly Name property is automatically added to the object.
   Oid ^ o1 = gcnew Oid( Value1 );
   Oid ^ o2 = gcnew Oid( Name1 );
   
   // Create a new Oid object using the specified Value and Friendly Name properties.
   // Note that the two are not compared to determine if the Value is associated 
   //  with the Friendly Name.
   Oid ^ o3 = gcnew Oid( Value2,InvalidName );
   
   //Create a new Oid object using the specified Value. Note that if the value
   //  is invalid or not known, no value is assigned to the Friendly Name property.
   Oid ^ o4 = gcnew Oid( InvalidValue );
   
   //Write out the property information of the Oid objects.
   Console::WriteLine( "Oid1: Automatically assigned Friendly Name: {0}, {1}", o1->FriendlyName, o1->Value );
   Console::WriteLine( "Oid2: Automatically assigned Value: {0}, {1}", o2->FriendlyName, o2->Value );
   Console::WriteLine( "Oid3: Name and Value not compared: {0}, {1}", o3->FriendlyName, o3->Value );
   Console::WriteLine( "Oid4: Invalid Value used: {0}, {1} {2}", o4->FriendlyName, o4->Value, Environment::NewLine );
   
   //Create an Oid collection and add several Oid objects.
   OidCollection ^ oc = gcnew OidCollection;
   oc->Add( o1 );
   oc->Add( o2 );
   oc->Add( o3 );
   Console::WriteLine( "Number of Oids in the collection: {0}", oc->Count );
   Console::WriteLine( "Is synchronized: {0} {1}", oc->IsSynchronized, Environment::NewLine );
   
   //Create an enumerator for moving through the collection.
   OidEnumerator ^ oe = oc->GetEnumerator();
   
   //You must execute a MoveNext() to get to the first item in the collection.
   oe->MoveNext();
   
   // Write out Oids in the collection.
   Console::WriteLine( "First Oid in collection: {0},{1}", oe->Current->FriendlyName, oe->Current->Value );
   oe->MoveNext();
   Console::WriteLine( "Second Oid in collection: {0},{1}", oe->Current->FriendlyName, oe->Current->Value );
   
   //Return index in the collection to the beginning.
   oe->Reset();
}

//</SNIPPET1>
