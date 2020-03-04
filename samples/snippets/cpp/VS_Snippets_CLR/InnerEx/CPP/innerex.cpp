
//<Snippet1>
using namespace System;

public ref class AppException: public Exception
{
public:
   AppException(String^ message ) : Exception(message)
   {}

   AppException(String^ message, Exception^ inner) : Exception(message, inner)
   {}
};

public ref class Example
{
public:
   void ThrowInner()
   {
      throw gcnew AppException("Exception in ThrowInner method.");
   }

   void CatchInner()
   {
      try {
         this->ThrowInner();
      }
      catch (AppException^ e) {
         throw gcnew AppException("Error in CatchInner caused by calling the ThrowInner method.", e);
      }
   }
};

int main()
{
   Example^ ex = gcnew Example();
   try {
      ex->CatchInner();
   }
   catch (AppException^ e) {
      Console::WriteLine("In catch block of Main method.");
      Console::WriteLine("Caught: {0}", e->Message);
      if (e->InnerException != nullptr)
         Console::WriteLine("Inner exception: {0}", e->InnerException);
   }
}
// The example displays the following output:
//    In catch block of Main method.
//    Caught: Error in CatchInner caused by calling the ThrowInner method.
//    Inner exception: AppException: Exception in ThrowInner method.
//       at Example.CatchInner()
//</Snippet1>
