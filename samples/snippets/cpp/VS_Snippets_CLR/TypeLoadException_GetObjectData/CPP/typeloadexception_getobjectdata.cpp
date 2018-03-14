

// System::TypeLoadException::GetObjectData
// System::TypeLoadException
/* This program demonstrates the 'GetObjectData' method and the
   protected constructor TypeLoadException(SerializationInfo, StreamingContext)
   of 'TypeLoadException' class. It generates an exception and 
   serializes the exception data to a file and then reconstitutes the 
   exception.
*/
// <Snippet1>
// <Snippet2>
#using <System.Runtime.Serialization.Formatters.Soap.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Soap;
using namespace System::IO;

// This class overrides the GetObjectData method and initializes
// its data with current time. 

[Serializable]
public ref class MyTypeLoadExceptionChild: public TypeLoadException
{
public:
   System::DateTime ErrorDateTime;
   MyTypeLoadExceptionChild()
   {
      ErrorDateTime = DateTime::Now;
   }

   MyTypeLoadExceptionChild( DateTime myDateTime )
   {
      ErrorDateTime = myDateTime;
   }


protected:
   MyTypeLoadExceptionChild( SerializationInfo^ sInfo, StreamingContext * sContext )
   {
      
      // Reconstitute the deserialized information into the instance.
      ErrorDateTime = sInfo->GetDateTime( "ErrorDate" );
   }


public:
   void GetObjectData( SerializationInfo^ sInfo, StreamingContext * sContext )
   {
      
      // Add a value to the Serialization information.
      sInfo->AddValue( "ErrorDate", ErrorDateTime );
   }

};

int main()
{
   
   // Load the mscorlib assembly and get a reference to it.
   // You must supply the fully qualified assembly name for mscorlib.dll here.
   Assembly^ myAssembly = Assembly::Load( "Assembly text name, Version, Culture, PublicKeyToken" );
   try
   {
      Console::WriteLine( "Attempting to load a type not present in the assembly 'mscorlib'" );
      
      // This loading of invalid type raises a TypeLoadException
      Type^ myType = myAssembly->GetType( "System::NonExistentType", true );
   }
   catch ( TypeLoadException^ ) 
   {
      
      // Serialize the exception to disk and reconstitute it back again.
      try
      {
         System::DateTime ErrorDatetime = DateTime::Now;
         Console::WriteLine( "A TypeLoadException has been raised." );
         
         // Create MyTypeLoadException instance with current time.
         MyTypeLoadExceptionChild^ myTypeLoadExceptionChild = gcnew MyTypeLoadExceptionChild( ErrorDatetime );
         IFormatter^ myFormatter = gcnew SoapFormatter;
         Stream^ myFileStream = gcnew FileStream( "typeload.xml",FileMode::Create,FileAccess::Write,FileShare::None );
         Console::WriteLine( "Serializing the TypeLoadException with DateTime as {0}", ErrorDatetime );
         
         // Serialize the MyTypeLoadException instance to a file.
         myFormatter->Serialize( myFileStream, myTypeLoadExceptionChild );
         myFileStream->Close();
         Console::WriteLine( "Deserializing the Exception." );
         myFileStream = gcnew FileStream( "typeload.xml",FileMode::Open,FileAccess::Read,FileShare::None );
         
         // Deserialize and reconstitute the instance from file.
         myTypeLoadExceptionChild = safe_cast<MyTypeLoadExceptionChild^>(myFormatter->Deserialize( myFileStream ));
         myFileStream->Close();
         Console::WriteLine( "Deserialized exception has ErrorDateTime = {0}", myTypeLoadExceptionChild->ErrorDateTime );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception : {0}", e->Message );
      }

   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }

}

// </Snippet2>
// </Snippet1>
