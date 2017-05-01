// String.Char1.cpp : Defines the entry point for the console application.
//


// <Snippet2>
using namespace System;
using namespace System::Globalization;
using namespace System::IO;

void main()
{
   StreamWriter^ sw = gcnew StreamWriter(".\\graphemes.txt");
   String^ grapheme = L"a" + L"\u0308";
   sw->WriteLine(grapheme);

   String^ singleChar = "\u00e4";
   sw->WriteLine(singleChar);

   sw->WriteLine("{0} = {1} (Culture-sensitive): {2}", grapheme, singleChar, 
                  String::Equals(grapheme, singleChar, 
                              StringComparison::CurrentCulture));
   sw->WriteLine("{0} = {1} (Ordinal): {2}", grapheme, singleChar, 
                  String::Equals(grapheme, singleChar, 
                              StringComparison::Ordinal));
   sw->WriteLine("{0} = {1} (Normalized Ordinal): {2}", grapheme, singleChar, 
                  String::Equals(grapheme->Normalize(), 
                              singleChar->Normalize(), 
                              StringComparison::Ordinal));
   sw->Close(); 
}
// The example produces the following output: 
//       ä 
//       ä 
//       ä = ä (Culture-sensitive): True 
//       ä = ä (Ordinal): False 
//       ä = ä (Normalized Ordinal): True
// </Snippet2>
