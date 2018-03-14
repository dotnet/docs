' <Snippet1>
Imports System.Text
Imports System.Globalization

Public Module Example
   Public Sub Main()
      ' The string below contains combining characters.
      Dim s As String = "a" + ChrW(&h0304) + ChrW(&h0308) + "bc" + ChrW(&h0327)

      ' Show each 'character' in the string.
      EnumTextElements(s)

      ' Show the index in the string where each 'character' starts.
      EnumTextElementIndexes(s)
   End Sub

   ' Show how to enumerate each real character (honoring surrogates) in a string.
   Sub EnumTextElements(s As String)
      ' This StringBuilder holds the output results.
      Dim sb As New StringBuilder()

      ' Use the enumerator returned from GetTextElementEnumerator 
      ' method to examine each real character.
      Dim charEnum As TextElementEnumerator = StringInfo.GetTextElementEnumerator(s)
      Do While charEnum.MoveNext()
         sb.AppendFormat("Character at index {0} is '{1}'{2}",
                         charEnum.ElementIndex, 
                         charEnum.GetTextElement(),
                         Environment.NewLine)
      Loop

      ' Show the results.
      Console.WriteLine("Result of GetTextElementEnumerator:")
      Console.WriteLine(sb)
   End Sub

   ' Show how to discover the index of each real character (honoring surrogates) in a string.
   Sub EnumTextElementIndexes(s As String)
      ' This StringBuilder holds the output results.
      Dim sb As New StringBuilder()

      ' Use the ParseCombiningCharacters method to 
      ' get the index of each real character in the string.
      Dim textElemIndex() As Integer = StringInfo.ParseCombiningCharacters(s)

      ' Iterate through each real character showing the character and the index where it was found.
      For i As Int32 = 0 To textElemIndex.Length - 1
         sb.AppendFormat("Character {0} starts at index {1}{2}",
                         i, textElemIndex(i), Environment.NewLine)
      Next

      ' Show the results.
      Console.WriteLine("Result of ParseCombiningCharacters:")
      Console.WriteLine(sb)
   End Sub
End Module
' The example displays the following output:
'       Result of GetTextElementEnumerator:
'       Character at index 0 is 'a-"'
'       Character at index 3 is 'b'
'       Character at index 4 is 'c,'
'       
'       Result of ParseCombiningCharacters:
'       Character 0 starts at index 0
'       Character 1 starts at index 3
'       Character 2 starts at index 4
' </Snippet1>