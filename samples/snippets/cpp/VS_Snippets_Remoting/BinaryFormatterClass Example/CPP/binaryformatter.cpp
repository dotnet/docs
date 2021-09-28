
//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Runtime::Serialization;
ref class App
{
public:
   static void Serialize()
   {
      
      // Create a hashtable of values that will eventually be serialized.
      Hashtable^ addresses = gcnew Hashtable;
      addresses->Add( "Jeff", "123 Main Street, Redmond, WA 98052" );
      addresses->Add( "Fred", "987 Pine Road, Phila., PA 19116" );
      addresses->Add( "Mary", "PO Box 112233, Palo Alto, CA 94301" );
      
      // To serialize the hashtable (and its keys/values),  
      // you must first open a stream for writing. 
      // In this case we will use a file stream.
      FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Create );
      
      // Construct a BinaryFormatter and use it to serialize the data to the stream.
      BinaryFormatter^ formatter = gcnew BinaryFormatter;
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

   static void Deserialize()
   {
      
      // Declare the hashtable reference.
      Hashtable^ addresses = nullptr;
      
      // Open the file containing the data that we want to deserialize.
      FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Open );
      try
      {
         BinaryFormatter^ formatter = gcnew BinaryFormatter;
         
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

      
      // To prove that the table deserialized correctly, display the keys/values.
      IEnumerator^ myEnum = addresses->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DictionaryEntry ^ de = safe_cast<DictionaryEntry ^>(myEnum->Current);
         Console::WriteLine( " {0} lives at {1}.", de->Key, de->Value );
      }
   }

};


[STAThread]
int main()
{
   App::Serialize();
   App::Deserialize();
   return 0;
}

//</snippet1>
