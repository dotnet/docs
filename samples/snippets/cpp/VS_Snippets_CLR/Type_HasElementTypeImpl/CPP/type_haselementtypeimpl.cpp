
// <Snippet1>
using namespace System;
using namespace System::Reflection;
public ref class MyTypeDelegator: public TypeDelegator
{
public:
   String^ myElementType;

private:
   Type^ myType;

public:
   MyTypeDelegator( Type^ myType )
      : TypeDelegator( myType )
   {
      this->myType = myType;
   }


protected:

   // Override Type::HasElementTypeImpl().
   virtual bool HasElementTypeImpl() override
   {
      
      // Determine whether the type is an array.
      if ( myType->IsArray )
      {
         myElementType = "array";
         return true;
      }

      
      // Determine whether the type is a reference.
      if ( myType->IsByRef )
      {
         myElementType = "reference";
         return true;
      }

      
      // Determine whether the type is a pointer.
      if ( myType->IsPointer )
      {
         myElementType = "pointer";
         return true;
      }

      
      // Return false if the type is not a reference, array, or pointer type.
      return false;
   }

};

int main()
{
   try
   {
      int myInt = 0;
      array<Int32>^myArray = gcnew array<Int32>(5);
      MyTypeDelegator^ myType = gcnew MyTypeDelegator( myArray->GetType() );
      
      // Determine whether myType is an array, pointer, reference type.
      Console::WriteLine( "\nDetermine whether a variable is an array, pointer, or reference type.\n" );
      if ( myType->HasElementType )
            Console::WriteLine( "The type of myArray is {0}.", myType->myElementType );
      else
            Console::WriteLine( "myArray is not an array, pointer, or reference type." );
      myType = gcnew MyTypeDelegator( myInt.GetType() );
      
      // Determine whether myType is an array, pointer, reference type.
      if ( myType->HasElementType )
            Console::WriteLine( "The type of myInt is {0}.", myType->myElementType );
      else
            Console::WriteLine( "myInt is not an array, pointer, or reference type." );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}

// </Snippet1>
