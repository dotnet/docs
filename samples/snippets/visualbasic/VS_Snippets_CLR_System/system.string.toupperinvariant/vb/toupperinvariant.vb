' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO

Module Example
   Public Sub Main()
      Dim words() As String = { "Tuesday", "Salı", "Вторник", "Mardi", _
                                "Τρίτη", "Martes", "יום שלישי", _
                                "الثلاثاء", "วันอังคาร" }
      Dim sw As New StreamWriter(".\output.txt")
      
      ' Display array in unsorted order.
      For Each word As String In words
         sw.WriteLine(word)
      Next
      sw.WriteLine()

      ' Create parallel array of words by calling ToUpperInvariant.
      Dim upperWords(words.Length - 1) As String
      For ctr As Integer = words.GetLowerBound(0) To words.GetUpperBound(0)
         upperWords(ctr) = words(ctr).ToUpperInvariant()
      Next
      
      ' Sort the words array based on the order of upperWords.
      Array.Sort(upperWords, words, StringComparer.InvariantCulture)
      
      ' Display the sorted array.
      For Each word As String In words
         sw.WriteLine(word)
      Next
      
      sw.Close()
   End Sub
End Module
' The example produces the following output:
'       Tuesday
'       Salı
'       Вторник
'       Mardi
'       Τρίτη
'       Martes
'       יום שלישי
'       الثلاثاء
'       วันอังคาร
'       
'       Mardi
'       Martes
'       Salı
'       Tuesday
'       Τρίτη
'       Вторник
'       יום שלישי
'       الثلاثاء
'       วันอังคาร
' </Snippet1>
