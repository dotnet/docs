
// <Snippet1>
using namespace System;
using namespace System::Reflection;
static void InstantiateINT32( bool ignoreCase )
{
   try
   {
      AppDomain^ currentDomain = AppDomain::CurrentDomain;
      Object^ instance = currentDomain->CreateInstanceAndUnwrap( 
         "mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", 
         "SYSTEM.INT32", 
         ignoreCase, 
         BindingFlags::Default, 
         nullptr, 
         nullptr, 
         nullptr, 
         nullptr, 
         nullptr );
      Console::WriteLine( instance->GetType() );
   }
   catch ( TypeLoadException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

int main()
{
   InstantiateINT32( false ); // Failed!
   InstantiateINT32( true ); // OK!
}

// </Snippet1>
