
// <Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class MyTypeDelegatorClass: public TypeDelegator
{
public:
   String^ myElementType;

private:
   Type^ myType;

public:
   MyTypeDelegatorClass( Type^ myType )
      : TypeDelegator( myType )
   {
      this->myType = myType;
   }

protected:

   // Override the IsPrimitiveImpl.
   virtual bool IsPrimitiveImpl() override
   {
      
      // Determine whether the type is a primitive type.
      if ( myType->IsPrimitive )
      {
         myElementType = "primitive";
         return true;
      }

      return false;
   }
};

int main()
{
   try
   {
      Console::WriteLine( "Determine whether int is a primitive type." );
      MyTypeDelegatorClass^ myType;
      myType = gcnew MyTypeDelegatorClass( int::typeid );
      
      // Determine whether int is a primitive type.
      if ( myType->IsPrimitive )
      {
         Console::WriteLine( "{0} is a primitive type.", int::typeid );
      }
      else
      {
         Console::WriteLine( "{0} is not a primitive type.", int::typeid );
      }
      Console::WriteLine( "\nDetermine whether String is a primitive type." );
      myType = gcnew MyTypeDelegatorClass( String::typeid );
      
      // Determine if String is a primitive type.
      if ( myType->IsPrimitive )
      {
         Console::WriteLine( "{0} is a primitive type.", String::typeid );
      }
      else
      {
         Console::WriteLine( "{0} is not a primitive type.", String::typeid );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
