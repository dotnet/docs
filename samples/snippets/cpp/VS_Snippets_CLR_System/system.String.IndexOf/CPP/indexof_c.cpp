// <Snippet5>
using namespace System;

void main()
{
   // Create a Unicode String with 5 Greek Alpha characters.
   String^ szGreekAlpha = gcnew String(L'\x0391',5);

   // Create a Unicode String with a 3 Greek Omega characters.
   String^ szGreekOmega = L"\x03A9\x03A9\x03A9";

   String^ szGreekLetters = String::Concat(szGreekOmega, szGreekAlpha, 
                                           szGreekOmega->Clone());

   // Display the entire string.
   Console::WriteLine(szGreekLetters);

   // The first index of Alpha.
   int ialpha = szGreekLetters->IndexOf( L'\x0391');
   // The first index of Omega.
   int iomega = szGreekLetters->IndexOf(L'\x03A9');

   Console::WriteLine("First occurrence of the Greek letter Alpha: Index {0}", 
                      ialpha);
   Console::WriteLine("First occurrence of the Greek letter Omega: Index {0}", 
                      iomega);
}
// The example displays the following output:
//       The string: OOO?????OOO
//       First occurrence of the Greek letter Alpha: Index 3
//       First occurrence of the Greek letter Omega: Index 0
// </Snippet5>

