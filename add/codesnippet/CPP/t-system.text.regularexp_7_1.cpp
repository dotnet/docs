#using <System.dll>

using namespace System;
using namespace System::Text::RegularExpressions;
int main()
{
   // Define a regular expression for repeated words.
   Regex^ rx = gcnew Regex( "\\b(?<word>\\w+)\\s+(\\k<word>)\\b",static_cast<RegexOptions>(RegexOptions::Compiled | RegexOptions::IgnoreCase) );

   // Define a test string.        
   String^ text = "The the quick brown fox  fox jumped over the lazy dog dog.";

   // Find matches.
   MatchCollection^ matches = rx->Matches( text );

   // Report the number of matches found.
   Console::WriteLine( "{0} matches found.", matches->Count );

   // Report on each match.
   for each (Match^ match in matches)
   {
      String^ word = match->Groups["word"]->Value;
      int index = match->Index;
      Console::WriteLine("{0} repeated at position {1}", word, index);   
   }
}