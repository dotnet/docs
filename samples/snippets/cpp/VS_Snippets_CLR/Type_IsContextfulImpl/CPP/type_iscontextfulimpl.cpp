
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

   // Override IsContextfulImpl.
   virtual bool IsContextfulImpl() override
   {
      
      // Check whether the type is contextful.
      if ( myType->IsContextful )
      {
         myElementType = " is contextful ";
         return true;
      }

      return false;
   }

};

public ref class MyTypeDemoClass{};


// This class demonstrates IsContextfulImpl.
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
      Console::WriteLine( "Check whether MyContextBoundClass can be hosted in a context." );
      
      // Check whether MyContextBoundClass is contextful.
      myType = gcnew MyTypeDelegatorClass( MyContextBoundClass::typeid );
      if ( myType->IsContextful )
      {
         Console::WriteLine( "{0} can be hosted in a context.", MyContextBoundClass::typeid );
      }
      else
      {
         Console::WriteLine( "{0} cannot be hosted in a context.", MyContextBoundClass::typeid );
      }
      myType = gcnew MyTypeDelegatorClass( MyTypeDemoClass::typeid );
      Console::WriteLine( "\nCheck whether MyTypeDemoClass can be hosted in a context." );
      if ( myType->IsContextful )
      {
         Console::WriteLine( "{0} can be hosted in a context.", MyTypeDemoClass::typeid );
      }
      else
      {
         Console::WriteLine( "{0} cannot be hosted in a context.", MyTypeDemoClass::typeid );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }
}
// </Snippet1>
