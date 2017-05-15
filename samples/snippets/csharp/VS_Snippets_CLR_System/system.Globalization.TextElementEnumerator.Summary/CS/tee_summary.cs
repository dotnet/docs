// The following code example shows the values returned by TextElementEnumerator.


// <snippet1>
using System;
using System.Globalization;


public class SamplesTextElementEnumerator  {

   public static void Main()  {

      // Creates and initializes a String containing the following:
      //   - a surrogate pair (high surrogate U+D800 and low surrogate U+DC00)
      //   - a combining character sequence (the Latin small letter "a" followed by the combining grave accent)
      //   - a base character (the ligature "")
      String myString = "\uD800\uDC00\u0061\u0300\u00C6";

      // Creates and initializes a TextElementEnumerator for myString.
      TextElementEnumerator myTEE = StringInfo.GetTextElementEnumerator( myString );

      // Displays the values returned by ElementIndex, Current and GetTextElement.
      // Current and GetTextElement return a string containing the entire text element. 
      Console.WriteLine( "Index\tCurrent\tGetTextElement" );
      myTEE.Reset();
      while (myTEE.MoveNext())  {
         Console.WriteLine( "[{0}]:\t{1}\t{2}", myTEE.ElementIndex, myTEE.Current, myTEE.GetTextElement() );
      }

   }

}

/*
This code produces the following output.  The question marks take the place of high and low surrogates.

Index   Current GetTextElement
[0]:    ??      ??
[2]:    a`      a`
[4]:    Æ       Æ

*/
// </snippet1>
