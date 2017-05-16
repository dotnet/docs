
//<snippet1>
using namespace System;
using namespace System::Collections;

String^ StripEndTags( String^ item )
{
   bool found = false;
   
   // try to find a tag at the end of the line using EndsWith
   if ( item->Trim()->EndsWith( ">" ) )
   {
      
      // now search for the opening tag...
      int lastLocation = item->LastIndexOf( "</" );
      
      // remove the identified section, if it is a valid region
      if ( lastLocation >= 0 ) {
            item = item->Substring( 0, lastLocation );
            found = true;
      }
   }

   if (found) item = StripEndTags(item);
   
   return item;
}

int main()
{
   
   // process an input file that contains html tags.
   // this sample checks for multiple tags at the end of the line, rather than simply
   // removing the last one.
   // note: HTML markup tags always end in a greater than symbol (>).
   array<String^>^strSource = {"<b>This is bold text</b>","<H1>This is large Text</H1>","<b><i><font color=green>This has multiple tags</font></i></b>","<b>This has <i>embedded</i> tags.</b>","This line simply ends with a greater than symbol, it should not be modified>"};
   Console::WriteLine( "The following lists the items before the ends have been stripped:" );
   Console::WriteLine( "-----------------------------------------------------------------" );
   
   // print out the initial array of strings
   IEnumerator^ myEnum1 = strSource->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum1->Current);
      Console::WriteLine( s );
   }

   Console::WriteLine();
   Console::WriteLine( "The following lists the items after the ends have been stripped:" );
   Console::WriteLine( "----------------------------------------------------------------" );
   
   // Display the array of strings.
   IEnumerator^ myEnum2 = strSource->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      String^ s = safe_cast<String^>(myEnum2->Current);
      Console::WriteLine( StripEndTags( s ) );
   }
}
// The example displays the following output:
//    The following lists the items before the ends have been stripped:
//    -----------------------------------------------------------------
//    <b>This is bold text</b>
//    <H1>This is large Text</H1>
//    <b><i><font color=green>This has multiple tags</font></i></b>
//    <b>This has <i>embedded</i> tags.</b>
//    This line simply ends with a greater than symbol, it should not be modified>
//    
//    The following lists the items after the ends have been stripped:
//    ----------------------------------------------------------------
//    <b>This is bold text
//    <H1>This is large Text
//    <b><i><font color=green>This has multiple tags
//    <b>This has <i>embedded</i> tags.
//    This line simply ends with a greater than symbol, it should not be modified>
//</snippet1>
