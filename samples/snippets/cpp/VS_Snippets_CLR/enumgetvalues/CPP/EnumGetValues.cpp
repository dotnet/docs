
//<snippet1>
using namespace System;
enum class Colors
{
   Red, Green, Blue, Yellow
};

enum class Styles
{
   Plaid = 0,
   Striped = 23,
   Tartan = 65,
   Corduroy = 78
};

int main()
{
   Console::WriteLine(  "The values of the Colors Enum are:" );
   Array^ a = Enum::GetValues( Colors::typeid );
   for ( Int32 i = 0; i < a->Length; i++ )
   {
      Object^ o = a->GetValue( i );
      Console::WriteLine(  "{0}", Enum::Format( Colors::typeid, o,  "D" ) );
   }
   Console::WriteLine();
   Console::WriteLine(  "The values of the Styles Enum are:" );
   Array^ b = Enum::GetValues( Styles::typeid );
   for ( Int32 i = 0; i < b->Length; i++ )
   {
      Object^ o = b->GetValue( i );
      Console::WriteLine(  "{0}", Enum::Format( Styles::typeid, o,  "D" ) );

   }
}
// The example produces the following output:
//       The values of the Colors Enum are:
//       0
//       1
//       2
//       3
//       
//       The values of the Styles Enum are:
//       0
//       23
//       65
//       78
//</snippet1>
