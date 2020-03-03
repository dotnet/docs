// <Snippet8>
#using <System.dll>

using namespace System;
using namespace System::Text::RegularExpressions;
void main()
{
   
   String^ text = "One car red car blue car";
   String^ pat = "(\\w+)\\s+(car)";
   
   // Compile the regular expression.
   Regex^ r = gcnew Regex( pat,RegexOptions::IgnoreCase );
   
   // Match the regular expression pattern against a text string.
   Match^ m = r->Match(text);
   int matchCount = 0;
   while ( m->Success )
   {
      Console::WriteLine( "Match{0}", ++matchCount );
      for ( int i = 1; i <= 2; i++ )
      {
         Group^ g = m->Groups[ i ];
         Console::WriteLine( "Group{0}='{1}'", i, g );
         CaptureCollection^ cc = g->Captures;
         for ( int j = 0; j < cc->Count; j++ )
         {
            Capture^ c = cc[ j ];
            System::Console::WriteLine( "Capture{0}='{1}', Position={2}", j, c, c->Index );
         }
      }
      m = m->NextMatch();
   }
}  
// This example displays the following output:
//       Match1
//       Group1='One'
//       Capture0='One', Position=0
//       Group2='car'
//       Capture0='car', Position=4
//       Match2
//       Group1='red'
//       Capture0='red', Position=8
//       Group2='car'
//       Capture0='car', Position=12
//       Match3
//       Group1='blue'
//       Capture0='blue', Position=16
//       Group2='car'
//       Capture0='car', Position=21
// </Snippet8>

