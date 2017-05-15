// Concat.cpp : main project file.
// <Snippet5>
using namespace System;

void main()
{
   int houseNumber = 172;
   String^ street = "Elm Street";
   String^ city = "Anywhere";
   String^ state = "NY";
   String^ zip = "60101";
   String^ sp = " ";
   String^ address = String::Concat(houseNumber, sp, street, "\n", city, ", " ,state, sp, zip);
   Console::WriteLine(address);
   Console::ReadLine();
}
// The example displays the following output:
//      172 Elm Street
//      Anywhere, NY 60101
// </Snippet5>
