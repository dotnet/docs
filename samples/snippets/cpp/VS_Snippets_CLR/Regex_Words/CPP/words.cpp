// <snippet0>
#using <System.dll>

using namespace System;
using namespace System::Text::RegularExpressions;
int main()
{
   // <snippet1>
   // Define a regular expression for repeated words.
   Regex^ rx = gcnew Regex( "\\b(?<word>\\w+)\\s+(\\k<word>)\\b",static_cast<RegexOptions>(RegexOptions::Compiled | RegexOptions::IgnoreCase) );
   // </snippet1>

   // Define a test string.        
   String^ text = "The the quick brown fox  fox jumped over the lazy dog dog.";

   // <snippet2>
   // Find matches.
   MatchCollection^ matches = rx->Matches( text );
   // </snippet2>

   // <snippet3>
   // Report the number of matches found.
   Console::WriteLine( "{0} matches found.", matches->Count );
   // </snippet3>

   // <snippet4>
   // Report on each match.
   for each (Match^ match in matches)
   {
      String^ word = match->Groups["word"]->Value;
      int index = match->Index;
      Console::WriteLine("{0} repeated at position {1}", word, index);   
   }
   // </snippet4>
}
// </snippet0>
