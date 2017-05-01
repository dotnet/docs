//<snippet1>
using namespace System;

[FlagsAttribute]
enum class Colors
{
   Red = 1,
   Green = 2,
   Blue = 4,
   Yellow = 8
};

int main()
{
   Console::WriteLine(  "The entries of the Colors enumeration are:" );
   Array^ a = Enum::GetNames( Colors::typeid );
   Int32 i = 0;
   while ( i < a->Length )
   {
      Object^ o = a->GetValue( i );
      Console::WriteLine( o->ToString() );
      i++;
   }

   Console::WriteLine();
   Object^ orange = Enum::Parse( Colors::typeid,  "Red, Yellow" );
   Console::WriteLine("The orange value has the combined entries of {0}", orange );
}

/*
This code example produces the following results:

The entries of the Colors Enum are:
Red
Green
Blue
Yellow

The orange value has the combined entries of Red, Yellow

*/
//</snippet1>
