//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Collections;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Runtime::Serialization;

ref class SingletonSerializationHelper;

// There should be only one instance of this type per AppDomain.

[Serializable]
public ref class Singleton sealed: public ISerializable
{
private:

   // This is the one instance of this type.
   static Singleton^ theOneObject = gcnew Singleton;

public:

   // Here are the instance fields.
   String^ someString;
   Int32 someNumber;

private:

   // Private constructor allowing this type to construct the singleton.
   Singleton()
   {
      
      // Do whatever is necessary to initialize the singleton.
      someString = "This is a String* field";
      someNumber = 123;
   }

public:

   // A method returning a reference to the singleton.
   static Singleton^ GetSingleton()
   {
      return theOneObject;
   }

   // A method called when serializing a Singleton.
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::SerializationFormatter)]
   virtual void GetObjectData( SerializationInfo^ info, StreamingContext context )
   {
      // Instead of serializing this Object*, we will  
      // serialize a SingletonSerializationHelp instead.
      info->SetType( SingletonSerializationHelper::typeid );

      // No other values need to be added.
   }

   // NOTE: ISerializable*'s special constructor is NOT necessary 
   // because it's never called
};

[Serializable]
private ref class SingletonSerializationHelper sealed: public IObjectReference
{
public:

   // This Object* has no fields (although it could).
   // GetRealObject is called after this Object* is deserialized
   virtual Object^ GetRealObject( StreamingContext context )
   {
      // When deserialiing this Object*, return a reference to 
      // the singleton Object* instead.
      return Singleton::GetSingleton();
   }
};

[STAThread]
int main()
{
   FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Create );
   try
   {
      // Construct a BinaryFormatter and use it 
      // to serialize the data to the stream.
      BinaryFormatter^ formatter = gcnew BinaryFormatter;

      // Create an array with multiple elements refering to 
      // the one Singleton Object*.
      array<Singleton^>^a1 = {Singleton::GetSingleton(),Singleton::GetSingleton()};

      // This displays S"True".
      Console::WriteLine( "Do both array elements refer to the same Object? {0}", (a1[ 0 ] == a1[ 1 ]) );

      // Serialize the array elements.
      formatter->Serialize( fs, a1 );

      // Deserialize the array elements.
      fs->Position = 0;
      array<Singleton^>^a2 = (array<Singleton^>^)formatter->Deserialize( fs );

      // This displays S"True".
      Console::WriteLine( "Do both array elements refer to the same Object? {0}", (a2[ 0 ] == a2[ 1 ]) );

      // This displays S"True".
      Console::WriteLine( "Do all  array elements refer to the same Object? {0}", (a1[ 0 ] == a2[ 0 ]) );
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

   return 0;
}
//</snippet1>
