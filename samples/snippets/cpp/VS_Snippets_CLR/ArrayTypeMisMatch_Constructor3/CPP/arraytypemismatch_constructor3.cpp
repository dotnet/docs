
// System::ArrayTypeMismatchException::ArrayTypeMismatchException
/*
   The following example demonstrates the 'ArrayTypeMismatchException(String*, innerException)'
   constructor of class ArrayTypeMismatchException class. It creates a 
   function which takes two arrays as arguments. It copies elements of 
   one array to another array. If two arrays are of not same type then
   an exception has been thrown. In the 'Catch' block a new 'WebException'
   object is created and thrown to the caller. That exception is caught 
   in the calling method and the error message is displayed to the console.
 */
// <Snippet1>
using namespace System;
public ref class ArrayTypeMisMatchConst
{
public:
   void CopyArray( Array^ myArray, Array^ myArray1 )
   {
      try
      {
         
         // Copies the value of one array into another array.
         myArray->SetValue( myArray1->GetValue( 0 ), 0 );
         myArray->SetValue( myArray1->GetValue( 1 ), 1 );
      }
      catch ( Exception^ e ) 
      {
         
         // Throw an exception of with a message and innerexception.
         throw gcnew ArrayTypeMismatchException( "The Source and destination arrays are of not same type.",e );
      }

   }

};

int main()
{
   try
   {
      array<String^>^myStringArray = gcnew array<String^>(2);
      myStringArray->SetValue( "Jones", 0 );
      myStringArray->SetValue( "John", 1 );
      array<Int32>^myIntArray = gcnew array<Int32>(2);
      ArrayTypeMisMatchConst^ myArrayType = gcnew ArrayTypeMisMatchConst;
      myArrayType->CopyArray( myStringArray, myIntArray );
   }
   catch ( ArrayTypeMismatchException^ e ) 
   {
      Console::WriteLine( "The Exception Message is : {0}", e->Message );
      Console::WriteLine( "The Inner exception is : {0}", e->InnerException );
   }

}

// </Snippet1>
