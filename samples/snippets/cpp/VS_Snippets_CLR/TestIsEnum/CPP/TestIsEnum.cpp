
// <Snippet1>
using namespace System;
enum class Color
{ Red, Blue, Green };

int main()
{
   Type^ colorType = Color::typeid;
   Type^ enumType = Enum::typeid;
   Console::WriteLine( "Is Color an enum? {0}.", colorType->IsEnum );
   Console::WriteLine( "Is Color a value type? {0}.", colorType->IsValueType );
   Console::WriteLine( "Is Enum an enum Type? {0}.", enumType->IsEnum );
   Console::WriteLine( "Is Enum a value type? {0}.", enumType->IsValueType );
}
// The example displays the following output:
//     Is Color an enum? True.
//     Is Color a value type? True.
//     Is Enum an enum type? False.
//     Is Enum a value type? False.
// </Snippet1>
