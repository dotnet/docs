' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesSortedList

   Public Shared Sub Main()

      ' Creates and initializes the source SortedList.
      Dim mySourceList As New SortedList()
      mySourceList.Add(2, "cats")
      mySourceList.Add(3, "in")
      mySourceList.Add(1, "napping")
      mySourceList.Add(4, "the")
      mySourceList.Add(0, "three")
      mySourceList.Add(5, "barn")

      ' Creates and initializes the one-dimensional target Array.
      Dim tempArray() As String = {"The", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"}
      Dim myTargetArray(14) As DictionaryEntry
      Dim i As Integer = 0
      Dim s As String
      For Each s In  tempArray
         myTargetArray(i).Key = i
         myTargetArray(i).Value = s
         i += 1
      Next s

      ' Displays the values of the target Array.
      Console.WriteLine("The target Array contains the following (before and after copying):")
      PrintValues(myTargetArray, " "c)

      ' Copies the entire source SortedList to the target SortedList, starting at index 6.
      mySourceList.CopyTo(myTargetArray, 6)

      ' Displays the values of the target Array.
      PrintValues(myTargetArray, " "c)

   End Sub 'Main


   Public Shared Sub PrintValues(myArr() As DictionaryEntry, mySeparator As Char)
      Dim i As Integer
      For i = 0 To myArr.Length - 1
         Console.Write("{0}{1}", mySeparator, myArr(i).Value)
      Next i
      Console.WriteLine()
  End Sub 'PrintValues

End Class 'SamplesSortedList 


'This code produces the following output.
' 
'The target Array contains the following (before and after copying):
' The quick brown fox jumped over the lazy dog      
' The quick brown fox jumped over three napping cats in the barn

' </Snippet1>