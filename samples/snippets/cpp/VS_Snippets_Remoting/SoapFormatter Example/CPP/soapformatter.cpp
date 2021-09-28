

//<snippet1>
#using <system.dll>
#using <system.runtime.serialization.formatters.soap.dll>

using namespace System;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Soap;
void Serialize()
{
   
   // Create a hashtable of values that will eventually be serialized.
   Hashtable^ addresses = gcnew Hashtable;
   addresses->Add( "Jeff", "123 Main Street, Redmond, WA 98052" );
   addresses->Add( "Fred", "987 Pine Road, Phila., PA 19116" );
   addresses->Add( "Mary", "PO Box 112233, Palo Alto, CA 94301" );
   
   // To serialize the hashtable (and its keys/values), 
   // you must first open a stream for writing.
   // We will use a file stream here.
   FileStream^ fs = gcnew FileStream( "DataFile.soap",FileMode::Create );
   
   // Construct a SoapFormatter and use it 
   // to serialize the data to the stream.
   SoapFormatter^ formatter = gcnew SoapFormatter;
   try
   {
      formatter->Serialize( fs, addresses );
   }
   catch ( SerializationException^ e ) 
   {
      Console::WriteLine( "Failed to serialize. Reason: {0}", e->Message );
      throw;
   }
   finally
   {
      fs->Close();
   }

}

void Deserialize()
{
   
   // Declare the hashtable reference.
   Hashtable^ addresses = nullptr;
   
   // Open the file containing the data that we want to deserialize.
   FileStream^ fs = gcnew FileStream( "DataFile.soap",FileMode::Open );
   try
   {
      SoapFormatter^ formatter = gcnew SoapFormatter;
      
      // Deserialize the hashtable from the file and 
      // assign the reference to our local variable.
      addresses = dynamic_cast<Hashtable^>(formatter->Deserialize( fs ));
   }
   catch ( SerializationException^ e ) 
   {
      Console::WriteLine( "Failed to deserialize. Reason: {0}", e->Message );
      throw;
   }
   finally
   {
      fs->Close();
   }

   
   // To prove that the table deserialized correctly, 
   // display the keys/values to the console.
   IEnumerator^ myEnum = addresses->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      DictionaryEntry^ de = safe_cast<DictionaryEntry^>(myEnum->Current);
      Console::WriteLine( " {0} lives at {1}.", de->Key, de->Value );
   }
}


[STAThread]
int main()
{
   Serialize();
   Deserialize();
}

//</snippet1>
