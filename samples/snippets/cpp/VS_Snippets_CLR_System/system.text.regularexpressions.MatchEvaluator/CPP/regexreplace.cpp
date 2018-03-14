

// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text::RegularExpressions;
ref class MyClass
{
public:
   static int i = 0;
   static String^ ReplaceCC( Match^ m )
   {
      
      // Replace each Regex cc match with the number of the occurrence.
      i++;
      return i.ToString();
   }

};

int main()
{
   String^ sInput;
   String^ sRegex;
   
   // The string to search.
   sInput = "aabbccddeeffcccgghhcccciijjcccckkcc";
   
   // A very simple regular expression.
   sRegex = "cc";
   Regex^ r = gcnew Regex( sRegex );
   
   // Assign the replace method to the MatchEvaluator delegate.
   MatchEvaluator^ myEvaluator = gcnew MatchEvaluator( &MyClass::ReplaceCC );
   
   // Write out the original string.
   Console::WriteLine( sInput );
   
   // Replace matched characters using the delegate method.
   sInput = r->Replace( sInput, myEvaluator );
   
   // Write out the modified string.
   Console::WriteLine( sInput );
}
// The example displays the following output:
//       aabbccddeeffcccgghhcccciijjcccckkcc
//       aabb11ddeeff22cgghh3344iijj5566kk77
// </Snippet1>
