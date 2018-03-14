// This sample demonstrates how to use each member of the
// CryptographicException class.
//<Snippet2>
using namespace System;
using namespace System::Text;
using namespace System::Security::Cryptography;
using namespace System::Runtime::Serialization;

ref class CryptographicExceptionMembers
{
public:

   static void Run()
   {
      CryptographicExceptionMembers^ testRun = gcnew CryptographicExceptionMembers;
      testRun->TestConstructors();
      testRun->ShowProperties();
      Console::WriteLine( L"This sample ended successfully; "
      L" press Enter to exit." );
      Console::ReadLine();
   }

private:
   // Test each public implementation of the CryptographicException
   // constructors.
   void TestConstructors()
   {
      EmptyConstructor();
      IntConstructor();
      StringConstructor();
      StringExceptionConstructor();
      StringStringConstructor();
   }

   void EmptyConstructor()
   {
      // Construct a CryptographicException with no parameters.
      //<Snippet1>
      CryptographicException^ cryptographicException = gcnew CryptographicException;
      
      //</Snippet1>
      Console::WriteLine( L"Created an empty CryptographicException." );
   }

   void IntConstructor()
   {
      // Construct a CryptographicException using the error code for an
      // unexpected operation exception.
      //<Snippet3>
      int exceptionNumber = (int)0x80131431;
      CryptographicException^ cryptographicException = gcnew CryptographicException( exceptionNumber );
      //</Snippet3>

      Console::WriteLine( L"Created a CryptographicException with the "
      L"following error code: {0}", exceptionNumber );
   }

   void StringConstructor()
   {
      // Construct a CryptographicException using a custom error message.
      //<Snippet4>
      String^ errorMessage = (L"Unexpected Operation exception.");
      CryptographicException^ cryptographicException = gcnew CryptographicException( errorMessage );
      //</Snippet4>

      Console::WriteLine( L"Created a CryptographicException with the "
      L"following error message: {0}", errorMessage );
   }

   void StringExceptionConstructor()
   {
      // Construct a CryptographicException using a custom error message
      // and an inner exception.
      //<Snippet5>
      String^ errorMessage = (L"The current operation is not supported.");
      NullReferenceException^ nullException = gcnew NullReferenceException;
      CryptographicException^ cryptographicException = gcnew CryptographicException( errorMessage,nullException );
      //</Snippet5>

      Console::WriteLine( L"Created a CryptographicException with the "
      L"following error message: {0} and the inner exception of {1}", errorMessage, nullException );
   }

   void StringStringConstructor()
   {
      // Create a CryptographicException using a time format and a the
      // current date.
      //<Snippet6>
      String^ dateFormat = L"{0:t}";
      String^ timeStamp = (DateTime::Now.ToString());
      CryptographicException^ cryptographicException = gcnew CryptographicException( dateFormat,timeStamp );
      //</Snippet6>

      Console::WriteLine( L"Created a CryptographicException with ({0}) as the format and ({1}) as the message.", dateFormat, timeStamp );
   }

   // Construct an invalid DSACryptoServiceProvider to throw a
   // CryptographicException for introspection.
   void ShowProperties()
   {
      try
      {
         // Create a DSACryptoServiceProvider with invalid provider type
         // code to throw a CryptographicException exception.
         CspParameters^ cspParams = gcnew CspParameters( 44 );
         DSACryptoServiceProvider^ DSAalg = gcnew DSACryptoServiceProvider( cspParams );
      }
      catch ( CryptographicException^ ex ) 
      {
         // Retrieve the link to the help file for the exception.
         //<Snippet7>
         String^ helpLink = ex->HelpLink;
         //</Snippet7>

         // Retrieve the exception that caused the current
         // CryptographicException exception.
         //<Snippet8>
         System::Exception^ innerException = ex->InnerException;
         //</Snippet8>

         String^ innerExceptionMessage = L"";
         if ( innerException != nullptr )
         {
            innerExceptionMessage = innerException->ToString();
         }
         
         // Retrieve the message that describes the exception.
         //<Snippet9>
         String^ message = ex->Message;
         //</Snippet9>

         // Retrieve the name of the application that caused the exception.
         //<Snippet10>
         String^ exceptionSource = ex->Source;
         //</Snippet10>

         // Retrieve the call stack at the time the exception occured.
         //<Snippet11>
         String^ stackTrace = ex->StackTrace;
         //</Snippet11>

         // Retrieve the method that threw the exception.
         //<Snippet12>
         System::Reflection::MethodBase^ targetSite = ex->TargetSite;
         //</Snippet12>

         String^ siteName = targetSite->Name;
         
         // Retrieve the entire exception as a single string.
         //<Snippet13>
         String^ entireException = ex->ToString();
         //</Snippet13>

         // GetObjectData
         setSerializationInfo(  &ex );
         
         // Get the root exception that caused the current
         // CryptographicException exception.
         //<Snippet14>
         System::Exception^ baseException = ex->GetBaseException();
         //</Snippet14>

         String^ baseExceptionMessage = L"";
         if ( baseException != nullptr )
         {
            baseExceptionMessage = baseException->Message;
         }
         Console::WriteLine( L"Caught an expected exception:" );
         Console::WriteLine( entireException );
         Console::WriteLine( L"\n" );
         Console::WriteLine( L"Properties of the exception are as follows:" );
         Console::WriteLine( L"Message: {0}", message );
         Console::WriteLine( L"Source: {0}", exceptionSource );
         Console::WriteLine( L"Stack trace: {0}", stackTrace );
         Console::WriteLine( L"Help link: {0}", helpLink );
         Console::WriteLine( L"Target site's name: {0}", siteName );
         Console::WriteLine( L"Base exception message: {0}", baseExceptionMessage );
         Console::WriteLine( L"Inner exception message: {0}", innerExceptionMessage );
      }

   }

   void setSerializationInfo( interior_ptr<CryptographicException^> ex )
   {
      // Insert information about the exception into a serialized object.
      //<Snippet15>
      FormatterConverter^ formatConverter = gcnew FormatterConverter;
      SerializationInfo^ serializationInfo = gcnew SerializationInfo( ( *ex)->GetType(),formatConverter );
      StreamingContext streamingContext = StreamingContext(StreamingContextStates::All);
      ( *ex)->GetObjectData( serializationInfo, streamingContext );
      //</Snippet15>
   }

};

void main()
{
   CryptographicExceptionMembers::Run();
}

//
// This sample produces the following output:
//
// Created an empty CryptographicException.
// Created a CryptographicException with the following error code: -2146233295
// Created a CryptographicException with the following error message:
// Unexpected Operation exception.
// Created a CryptographicException with the following error message: The
// current operation is not supported. and the inner exception of
// System.NullReferenceException: Object reference not set to an instance of
// an object.
// Created a CryptographicException with ({0:t}) as the format and (2/24/2004
// 2:13:15 PM) as the message.
// Caught an expected exception:
// System.Security.Cryptography.CryptographicException: CryptoAPI
// cryptographic service provider (CSP) for this implementation could not be
// acquired.
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(Int32
// dwKeySize, CspParameters parameters)
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(
// CspParametersparameters)
//  at CryptographicExceptionMembers.ShowProperties() in c:\inetpub\
// vssolutions\test\testbuild\consoleapplication1\class1.cs:line 109
//
//
// Properties of the exception are as follows:
// Message: CryptoAPI cryptographic service provider (CSP) for this
// implementation could not be acquired.
// Source: mscorlib
// Stack trace:
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(
// Int32 dwKeySize, CspParameters parameters)
//  at System.Security.Cryptography.DSACryptoServiceProvider..ctor(
// CspParameters parameters)
//  at CryptographicExceptionMembers.ShowProperties() in c:\inetpub\
// vssolutions\test\testbuild\consoleapplication1\class1.cs:line 109
// Help link:
// Target site's name: .ctor
// Base exception message: CryptoAPI cryptographic service provider (CSP) for
// this implementation could not be acquired.
// Inner exception message:
// This sample ended successfully;  press Enter to exit.
//</Snippet2>
