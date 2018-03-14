
//<snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Binary;
using namespace System::Reflection;
using namespace System::Security::Permissions;
ref class Version1ToVersion2DeserializationBinder;

[Serializable]
ref class Version1Type
{
public:
   Int32 x;
};


[Serializable]
ref class Version2Type: public ISerializable
{
public:
   Int32 x;
   String^ name;

   // The security attribute demands that code that calls  
   // this method have permission to perform serialization.

   [SecurityPermissionAttribute(SecurityAction::Demand,SerializationFormatter=true)]
   virtual void GetObjectData( SerializationInfo^ info, StreamingContext context )
   {
      info->AddValue( "x", x );
      info->AddValue( "name", name );
   }


private:

   // The security attribute demands that code that calls  
   // this method have permission to perform serialization.

   [SecurityPermissionAttribute(SecurityAction::Demand,SerializationFormatter=true)]
   Version2Type( SerializationInfo^ info, StreamingContext context )
   {
      x = info->GetInt32( "x" );
      try
      {
         name = info->GetString( "name" );
      }
      catch ( SerializationException^ ) 
      {
         // The 'name' field was not serialized because Version1Type 
         // did not contain this field.
         // We will set this field to a reasonable default value.
         name =  "Reasonable default value";
      }
   }
};

ref class Version1ToVersion2DeserializationBinder sealed: public SerializationBinder
{
public:
   virtual Type^ BindToType( String^ assemblyName, String^ typeName ) override
   {
      Type^ typeToDeserialize = nullptr;

      // For each assemblyName/typeName that you want to deserialize to
      // a different type, set typeToDeserialize to the desired type.
      String^ assemVer1 = Assembly::GetExecutingAssembly()->FullName;
      String^ typeVer1 =  "Version1Type";
      if ( assemblyName->Equals( assemVer1 ) && typeName->Equals( typeVer1 ) )
      {
         // To use a type from a different assembly version, 
         // change the version number using the following line of code.
         // assemblyName = assemblyName.Replace("1.0.0.0", "2.0.0.0");
         // To use a different type from the same assembly, 
         // change the type name.
         typeName =  "Version2Type";
      }

      // The following line of code returns the type.
      typeToDeserialize = Type::GetType( String::Format(  "{0}, {1}", typeName, assemblyName ) );
      return typeToDeserialize;
   }
};

ref class App
{
public:
   static void Serialize()
   {
      // To serialize the objects, you must first open a stream for writing. 
      // We will use a file stream here.
      FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Create );
      try
      {
         // Construct a BinaryFormatter and use it 
         // to serialize the data to the stream.
         BinaryFormatter^ formatter = gcnew BinaryFormatter;

         // Construct a Version1Type Object and serialize it.
         Version1Type^ obj = gcnew Version1Type;
         obj->x = 123;
         formatter->Serialize( fs, obj );
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
      // Declare the Version2Type reference.
      Version2Type^ obj = nullptr;

      // Open the file containing the data that we want to deserialize.
      FileStream^ fs = gcnew FileStream( "DataFile.dat",FileMode::Open );
      try
      {
         // Construct a BinaryFormatter and use it 
         // to deserialize the data from the stream.
         BinaryFormatter^ formatter = gcnew BinaryFormatter;

         // Construct an instance of our 
         // Version1ToVersion2TypeSerialiationBinder type.
         // This Binder type knows how to deserialize a Version1Type  
         // Object* to a Version2Type Object.
         formatter->Binder = gcnew Version1ToVersion2DeserializationBinder;
         obj = dynamic_cast<Version2Type^>(formatter->Deserialize( fs ));
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

      // To prove that a Version2Type Object* was deserialized, 
      // display the Object's type and fields to the console.
      Console::WriteLine( "Type of Object deserialized: {0}", obj->GetType() );
      Console::WriteLine( "x = {0}, name = {1}", obj->x, obj->name );
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
