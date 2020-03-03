
// System::ArrayTypeMismatchException::ArrayTypeMismatchException
/*
 * The following example demonstrates the 'ArrayTypeMismatchException()' constructor of class
 * ArrayTypeMismatchException class. It creates a function which takes two arrays as arguments.
 * It checks whether the two arrays are of same type or not. If two arrays are not of same type
 * then a new  'ArrayTypeMismatchException' object is created and thrown. That exception is caught
 * in the calling method.
 */
// <Snippet1>
using namespace System;
public ref class ArrayTypeMisMatchConst
{
public:
   void CopyArray( Array^ myArray, Array^ myArray1 )
   {
      String^ typeArray1 = myArray->GetType()->ToString();
      String^ typeArray2 = myArray1->GetType()->ToString();
      
      // Check whether the two arrays are of same type or not.
      if ( typeArray1 == typeArray2 )
      {
         
         // Copy the values from one array to another.
         myArray->SetValue( String::Concat(  "Name: ", myArray1->GetValue( 0 )->ToString() ), 0 );
         myArray->SetValue( String::Concat(  "Name: ", myArray1->GetValue( 1 )->ToString() ), 1 );
      }
      else
      {
         
         // Throw an exception of type 'ArrayTypeMismatchException'.
         throw gcnew ArrayTypeMismatchException;
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
      Console::WriteLine( "The Exception is : {0}", e );
   }

}

// </Snippet1>
