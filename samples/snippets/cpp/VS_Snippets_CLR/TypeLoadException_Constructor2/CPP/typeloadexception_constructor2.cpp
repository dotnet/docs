// <Snippet1>
using namespace System;

class TypeLoadExceptionDemoClass
{
   public:
      static bool GenerateException()
      {
         // Throw a TypeLoadException with a custom message.
         throw gcnew TypeLoadException("This is a custom TypeLoadException error message.");
      }
};

int main()
{
   try {
      // Call a method that throws an exception.  
      TypeLoadExceptionDemoClass::GenerateException();
   }
   catch ( TypeLoadException^ e ) {
      Console::WriteLine("TypeLoadException:\n   {0}", e->Message);
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: \n\tError Message = {0}", e->Message );
   }

}
// The example displays the following output:
//       TypeLoadException:
//          This is a custom TypeLoadException error message.
// </Snippet1>
