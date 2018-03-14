

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

enum class Option
{
   First, Second, Last
};

ref class Test
{
public:
   void SomeMethod()
   {
       int option = (int)Option::Last + 1;
       double result;
       //<Snippet2>
       switch ( option )
       {
          case Option::First:
             result = 1.0;
             break;
    
          // Insert additional cases.
          
          default:
             #if defined(DEBUG)
             Debug::Fail( "Unknown Option" + option, "Result set to 1.0" );
             #endif
             result = 1.0;
             break;
       }
       //</Snippet2>
   }
};

int main( void )
{
   try
   {
      Object^ b;
      b->ToString();
   }
   //<Snippet1>
   catch ( Exception^ e ) 
   {
      #if defined(DEBUG)
      Debug::Fail( "Cannot find SpecialController, proceeding with StandardController", "Setting Controller to default value" );
      #endif
   }
   //</Snippet1>
   
   Test^ test = gcnew Test();
   test->SomeMethod();
}
