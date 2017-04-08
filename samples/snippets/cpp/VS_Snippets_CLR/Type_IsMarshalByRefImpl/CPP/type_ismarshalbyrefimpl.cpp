
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

   // Override IsMarshalByRefImpl.
   virtual bool IsMarshalByRefImpl() override
   {
      // Determine whether the type is marshalled by reference.
      if ( myType->IsMarshalByRef )
      {
         myElementType = " marshalled by reference";
         return true;
      }

      return false;
   }
};

public ref class MyTypeDemoClass{};


// This class is used to demonstrate the IsMarshalByRefImpl method.
public ref class MyContextBoundClass: public ContextBoundObject
{
public:
   String^ myString;
};

int main()
{
   try
   {
      MyTypeDelegatorClass^ myType;
      Console::WriteLine( "Determine whether MyContextBoundClass is marshalled by reference." );
      
      // Determine whether MyContextBoundClass type is marshalled by reference.
      myType = gcnew MyTypeDelegatorClass( MyContextBoundClass::typeid );
      if ( myType->IsMarshalByRef )
      {
         Console::WriteLine( "{0} is marshalled by reference.", MyContextBoundClass::typeid );
      }
      else
      {
         Console::WriteLine( "{0} is not marshalled by reference.", MyContextBoundClass::typeid );
      }
      
      // Determine whether int type is marshalled by reference.
      myType = gcnew MyTypeDelegatorClass( int::typeid );
      Console::WriteLine( "\nDetermine whether int is marshalled by reference." );
      if ( myType->IsMarshalByRef )
      {
         Console::WriteLine( "{0} is marshalled by reference.", int::typeid );
      }
      else
      {
         Console::WriteLine( "{0} is not marshalled by reference.", int::typeid );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
