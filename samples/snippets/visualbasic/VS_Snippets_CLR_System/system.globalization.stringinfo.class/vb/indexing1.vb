' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      ' The Unicode code points specify Arabic base characters and 
      ' combining character sequences.
      Dim strCombining As String = ChrW(&H627) & ChrW(&h0655) + ChrW(&H650) & 
              ChrW(&H64A) & ChrW(&H647) & ChrW(&H64E) & ChrW(&H627) & 
              ChrW(&H628) & ChrW(&H64C)

      ' The Unicode code points specify private surrogate pairs.
      Dim strSurrogates As String = Char.ConvertFromUtf32(&h10148) +
                                    Char.ConvertFromUtf32(&h20026) + "a" +
                                    Char.ConvertFromUtf32(&hF1001)
      
      EnumerateTextElements(strCombining)
      EnumerateTextElements(strSurrogates)
   End Sub

   Public Sub EnumerateTextElements(str As String)
      ' Get the Enumerator.
      Dim teEnum As TextElementEnumerator = Nothing      

      ' Parse the string using the ParseCombiningCharacters method.
      Console.WriteLine()
      Console.WriteLine("Parsing with ParseCombiningCharacters:")
      Dim teIndices As Integer() = StringInfo.ParseCombiningCharacters(str)
      
      For i As Integer = 0 To teIndices.Length - 1
         If i < teIndices.Length - 1 Then
            Console.WriteLine("Text Element {0} ({1}..{2})= {3}", i, 
               TEIndices(i), TEIndices((i + 1)) - 1, 
               ShowHexValues(str.Substring(TEIndices(i), TEIndices((i + 1)) - 
                             teIndices(i))))
         Else
            Console.WriteLine("Text Element {0} ({1}..{2})= {3}", i, 
               teIndices(i), str.Length - 1, 
               ShowHexValues(str.Substring(teIndices(i))))
         End If
      Next
      Console.WriteLine()

      ' Parse the string with the GetTextElementEnumerator method.
      Console.WriteLine("Parsing with TextElementEnumerator:")
      teEnum = StringInfo.GetTextElementEnumerator(str)

      Dim TECount As Integer = - 1

      While teEnum.MoveNext()
         ' Prints the current element.
         ' Both GetTextElement() and Current retrieve the current
         ' text element. The latter returns it as an Object.
         TECount += 1
         Console.WriteLine("Text Element {0} ({1}..{2})= {3}", teCount, 
            teEnum.ElementIndex, teEnum.ElementIndex + 
            teEnum.GetTextElement().Length - 1, ShowHexValues(CStr(teEnum.Current)))
      End While
   End Sub
   
   Private Function ShowHexValues(s As String) As String
      Dim hexString As String = ""
      For Each ch In s
         hexString += String.Format("{0:X4} ", Convert.ToUInt16(ch))
      Next
      Return hexString
   End Function
End Module
' The example displays the following output:
'       Parsing with ParseCombiningCharacters:
'       Text Element 0 (0..2)= 0627 0655 0650
'       Text Element 1 (3..3)= 064A
'       Text Element 2 (4..5)= 0647 064E
'       Text Element 3 (6..6)= 0627
'       Text Element 4 (7..8)= 0628 064C
'       
'       Parsing with TextElementEnumerator:
'       Text Element 0 (0..2)= 0627 0655 0650
'       Text Element 1 (3..3)= 064A
'       Text Element 2 (4..5)= 0647 064E
'       Text Element 3 (6..6)= 0627
'       Text Element 4 (7..8)= 0628 064C
'       
'       Parsing with ParseCombiningCharacters:
'       Text Element 0 (0..1)= D800 DD48
'       Text Element 1 (2..3)= D840 DC26
'       Text Element 2 (4..4)= 0061
'       Text Element 3 (5..6)= DB84 DC01
'       
'       Parsing with TextElementEnumerator:
'       Text Element 0 (0..1)= D800 DD48
'       Text Element 1 (2..3)= D840 DC26
'       Text Element 2 (4..4)= 0061
'       Text Element 3 (5..6)= DB84 DC01
' </Snippet1>