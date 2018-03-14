' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim words() As String = { "Tuesday", "Salı", "Вторник", "Mardi", _
                                "Τρίτη", "Martes", "יום שלישי", _
                                "الثلاثاء", "วันอังคาร" }
      ' Display array in unsorted order.
      For Each word As String In words
         Console.WriteLine(word)
      Next
      Console.WriteLine()

      ' Create parallel array of words by calling ToLowerInvariant.
      Dim lowerWords(words.Length - 1) As String
      For ctr As Integer = words.GetLowerBound(0) To words.GetUpperBound(0)
         lowerWords(ctr) = words(ctr).ToLowerInvariant()
      Next
      
      ' Sort the words array based on the order of lowerWords.
      Array.Sort(lowerWords, words, StringComparer.InvariantCulture)
      
      ' Display the sorted array.
      For Each word As String In words
         Console.WriteLine(word)
      Next
   End Sub
End Module
' The example displays the following output:
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
