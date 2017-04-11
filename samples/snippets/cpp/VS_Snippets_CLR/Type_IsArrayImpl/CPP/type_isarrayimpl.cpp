
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class MyTypeDelegator: public TypeDelegator
{
public:
   String^ myElementType;
   Type^ myType;
   MyTypeDelegator( Type^ myType )
      : TypeDelegator( myType )
   {
      this->myType = myType;
   }


protected:

   // Override IsArrayImpl().
   virtual bool IsArrayImpl() override
   {
      
      // Determine whether the type is an array.
      if ( myType->IsArray )
      {
         myElementType = "array";
         return true;
      }

      
      // Return false if the type is not an array.
      return false;
   }

};

int main()
{
   try
   {
      int myInt = 0;
      
      // Create an instance of an array element.
      array<Int32>^myArray = gcnew array<Int32>(5);
      MyTypeDelegator^ myType = gcnew MyTypeDelegator( myArray->GetType() );
      Console::WriteLine( "\nDetermine whether the variable is an array.\n" );
      
      // Determine whether myType is an array type.
      if ( myType->IsArray )
            Console::WriteLine( "The type of myArray is {0}.", myType->myElementType );
      else
            Console::WriteLine( "myArray is not an array." );
      myType = gcnew MyTypeDelegator( myInt.GetType() );
      
      // Determine whether myType is an array type.
      if ( myType->IsArray )
            Console::WriteLine( "The type of myInt is {0}.", myType->myElementType );
      else
            Console::WriteLine( "myInt is not an array." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}

// </Snippet1>
