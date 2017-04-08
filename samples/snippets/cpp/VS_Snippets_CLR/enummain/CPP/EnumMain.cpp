
//<snippet1>
using namespace System;
enum class Days
{
   Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday
};

enum class BoilingPoints
{
   Celsius = 100,
   Fahrenheit = 212
};

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
   Type^ weekdays = Days::typeid;
   Type^ boiling = BoilingPoints::typeid;
   Console::WriteLine(  "The days of the week, and their corresponding values in the Days Enum are:" );
   Array^ a = Enum::GetNames( weekdays );
   Int32 i = 0;
   do
   {
      Object^ o = a->GetValue( i );
      Console::WriteLine(  "{0,-11}= {1}", o->ToString(), Enum::Format( weekdays, Enum::Parse( weekdays, o->ToString() ),  "d" ) );
   }
   while ( ++i < a->Length );

   Console::WriteLine();
   Console::WriteLine(  "Enums can also be created which have values that represent some meaningful amount." );
   Console::WriteLine(  "The BoilingPoints Enum defines the following items, and corresponding values:" );
   i = 0;
   Array^ b = Enum::GetNames( boiling );
   do
   {
      Object^ o = b->GetValue( i );
      Console::WriteLine(  "{0,-11}= {1}", o->ToString(), Enum::Format( boiling, Enum::Parse( boiling, o->ToString() ),  "d" ) );
   }
   while ( ++i < b->Length );

   Array^ c = Enum::GetNames( Colors::typeid );
   Colors myColors = Colors::Red | Colors::Blue | Colors::Yellow;
   Console::WriteLine();
   Console::Write(  "myColors holds a combination of colors. Namely:" );
   for ( i = 0; i < 3; i++ )
      Console::Write(  " {0}", c->GetValue( i ) );
}
//</snippet1>
