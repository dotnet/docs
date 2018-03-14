' The following code example shows the values returned by TextElementEnumerator.

' <snippet1>
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesTextElementEnumerator

   Public Shared Sub Main()

      ' Creates and initializes a String containing the following:
      '   - a surrogate pair (high surrogate U+D800 and low surrogate U+DC00)
      '   - a combining character sequence (the Latin small letter "a" followed by the combining grave accent)
      '   - a base character (the ligature "")
      Dim myString As String = ChrW(&HD800) & ChrW(&HDC00) & ChrW(&H0061) & ChrW(&H0300) & ChrW(&H00C6)

      ' Creates and initializes a TextElementEnumerator for myString.
      Dim myTEE As TextElementEnumerator = StringInfo.GetTextElementEnumerator( myString )

      ' Displays the values returned by ElementIndex, Current and GetTextElement.
      ' Current and GetTextElement return a string containing the entire text element. 
      Console.WriteLine("Index" + ControlChars.Tab + "Current" + ControlChars.Tab + "GetTextElement")
      myTEE.Reset()
      While myTEE.MoveNext()
         Console.WriteLine("[{0}]:" + ControlChars.Tab + "{1}" + ControlChars.Tab + "{2}", myTEE.ElementIndex, myTEE.Current, myTEE.GetTextElement())
      End While

   End Sub 'Main 

End Class 'SamplesTextElementEnumerator

'This code produces the following output.  The question marks take the place of high and low surrogates.
'
'Index   Current GetTextElement
'[0]:    ??      ??
'[2]:    a`      a`
'[4]:    Æ       Æ

' </snippet1>