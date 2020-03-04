
//<snippet1>
using namespace System;
public enum class Colors
{
   Red, Green, Blue, Yellow
};

int main()
{
   Colors myColor = Colors::Blue;
   Console::WriteLine(  "My favorite color is {0}.", myColor );
   Console::WriteLine(  "The value of my favorite color is {0}.", Enum::Format( Colors::typeid, myColor,  "d" ) );
   Console::WriteLine(  "The hex value of my favorite color is {0}.", Enum::Format( Colors::typeid, myColor,  "x" ) );
}
// The example displays the folowing output:
//    My favorite color is Blue.
//    The value of my favorite color is 2.
//    The hex value of my favorite color is 00000002.
//</snippet1>
