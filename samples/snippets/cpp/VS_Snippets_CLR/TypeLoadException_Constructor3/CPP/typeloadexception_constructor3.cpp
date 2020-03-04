
// System::TypeLoadException::TypeLoadException
/* This program demonstrates the 'TypeLoadException(String*, Exception)'
   constructor of 'TypeLoadException' class. It attempts to call a 
   non-existent method located in NonExistentDLL.dll, which will 
   throw an exception. A new exception is thrown with this exception
   as an inner exception.
*/
// <Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;
ref class TypeLoadExceptionDemoClass
{
public:

   // A call to this method will raise a TypeLoadException.

   [DllImport("NonExistentDLL.DLL",EntryPoint="MethodNotExists")]
   static void NonExistentMethod();
   static void GenerateException()
   {
      try
      {
         NonExistentMethod();
      }
      catch ( TypeLoadException^ e ) 
      {
         
         // Rethrow exception with the exception as inner exception
         throw gcnew TypeLoadException( "This exception was raised due to a call to an invalid method.",e );
      }

   }

};

int main()
{
   Console::WriteLine( "Calling a method in a non-existent DLL which triggers a TypeLoadException." );
   try
   {
      TypeLoadExceptionDemoClass::GenerateException();
   }
   catch ( TypeLoadException^ e ) 
   {
      Console::WriteLine( "TypeLoadException: \n\tError Message = {0}", e->Message );
      Console::WriteLine( "TypeLoadException: \n\tInnerException Message = {0}", e->InnerException->Message );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: \n\tError Message = {0}", e->Message );
   }

}

// </Snippet1>
