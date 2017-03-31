

//<Snippet1>
#using <System.Runtime.Serialization.Formatters.Soap.dll>

using namespace System;
using namespace System::IO;
using namespace System::Runtime::Serialization;
using namespace System::Runtime::Serialization::Formatters::Soap;

// Define a serializable derived exception class.

[Serializable]
ref class SecondLevelException: public Exception, public ISerializable
{
public:

   // This public constructor is used by class instantiators.
   SecondLevelException( String^ message, Exception^ inner )
      : Exception( message, inner )
   {
      HelpLink = "http://MSDN.Microsoft.com";
      Source = "Exception_Class_Samples";
   }


protected:

   // This protected constructor is used for deserialization.
   SecondLevelException( SerializationInfo^ info, StreamingContext context )
      : Exception( info, context )
   {}


public:

   // GetObjectData performs a custom serialization.
   [System::Security::Permissions::SecurityPermissionAttribute
   (System::Security::Permissions::SecurityAction::LinkDemand, 
   Flags=System::Security::Permissions::SecurityPermissionFlag::SerializationFormatter)]
   virtual void GetObjectData( SerializationInfo^ info, StreamingContext context ) override
   {
      
      // Change the case of two properties, and then use the 
      // method of the base class.
      HelpLink = HelpLink->ToLower();
      Source = Source->ToUpperInvariant();
      Exception::GetObjectData( info, context );
   }

};

int main()
{
   Console::WriteLine( "This example of the Exception constructor "
   "and Exception.GetObjectData\nwith Serialization"
   "Info and StreamingContext parameters "
   "generates \nthe following output.\n" );
   try
   {
      
      // This code forces a division by 0 and catches the 
      // resulting exception.
      try
      {
         int zero = 0;
         int ecks = 1 / zero;
      }
      catch ( Exception^ ex ) 
      {
         
         // Create a new exception to throw again.
         SecondLevelException^ newExcept = gcnew SecondLevelException( "Forced a division by 0 and threw "
         "another exception.",ex );
         Console::WriteLine( "Forced a division by 0, caught the "
         "resulting exception, \n"
         "and created a derived exception:\n" );
         Console::WriteLine( "HelpLink: {0}", newExcept->HelpLink );
         Console::WriteLine( "Source:   {0}", newExcept->Source );
         
         // This FileStream is used for the serialization.
         FileStream^ stream = gcnew FileStream( "NewException.dat",FileMode::Create );
         try
         {
            
            // Serialize the derived exception.
            SoapFormatter^ formatter = gcnew SoapFormatter( nullptr,StreamingContext(StreamingContextStates::File) );
            formatter->Serialize( stream, newExcept );
            
            // Rewind the stream and deserialize the 
            // exception.
            stream->Position = 0;
            SecondLevelException^ deserExcept = dynamic_cast<SecondLevelException^>(formatter->Deserialize( stream ));
            Console::WriteLine( "\nSerialized the exception, and then "
            "deserialized the resulting stream "
            "into a \nnew exception. "
            "The deserialization changed the case "
            "of certain properties:\n" );
            
            // Throw the deserialized exception again.
            throw deserExcept;
         }
         catch ( SerializationException^ se ) 
         {
            Console::WriteLine( "Failed to serialize: {0}", se->ToString() );
         }
         finally
         {
            stream->Close();
         }

      }

   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "HelpLink: {0}", ex->HelpLink );
      Console::WriteLine( "Source:   {0}", ex->Source );
      Console::WriteLine();
      Console::WriteLine( ex->ToString() );
   }

}

/*
This example of the Exception constructor and Exception.GetObjectData
with SerializationInfo and StreamingContext parameters generates
the following output.

Forced a division by 0, caught the resulting exception,
and created a derived exception:

HelpLink: http://MSDN.Microsoft.com
Source:   Exception_Class_Samples

Serialized the exception, and then deserialized the resulting stream into a
new exception. The deserialization changed the case of certain properties:

HelpLink: http://msdn.microsoft.com
Source:   EXCEPTION_CLASS_SAMPLES

SecondLevelException: Forced a division by 0 and threw another exception. ---> S
ystem.DivideByZeroException: Attempted to divide by zero.
   at main()
   --- End of inner exception stack trace ---
   at main()

*/
//</Snippet1>
