
//<snippet1>
using namespace System;
enum class Colors
{
   Red, Green, Blue, Yellow
};

enum class Styles
{
   Plaid, Striped, Tartan, Corduroy
};

int main()
{
   Console::WriteLine( "The members of the Colors enum are:" );
   Array^ a = Enum::GetNames( Colors::typeid );
   Int32 i = 0;
   do
   {
      Object^ o = a->GetValue( i );
      Console::WriteLine( o->ToString() );
   }
   while ( ++i < a->Length );

   Console::WriteLine();
   Console::WriteLine( "The members of the Styles enum are:" );
   Array^ b = Enum::GetNames( Styles::typeid );
   i = 0;
   do
   {
      Object^ o = b->GetValue( i );
      Console::WriteLine( o->ToString() );
   }
   while ( ++i < b->Length );
}
// The example displays the following output:
//       The members of the Colors enum are:
//       Red
//       Green
//       Blue
//       Yellow
//       
//       The members of the Styles enum are:
//       Plaid
//       Striped
//       Tartan
//       Corduroy
//</snippet1>
