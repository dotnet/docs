' The following code example shows how a StringDictionary can be copied to an array.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports Microsoft.VisualBasic

Public Class SamplesStringDictionary

   Public Shared Sub Main()

      ' Creates and initializes a new StringDictionary.
      Dim myCol As New StringDictionary()
      myCol.Add("red", "rojo")
      myCol.Add("green", "verde")
      myCol.Add("blue", "azul")

      ' Displays the values in the StringDictionary.
      Console.WriteLine("KEYS" + ControlChars.Tab + "VALUES in the StringDictionary")
      Dim myDE As DictionaryEntry
      For Each myDE In  myCol
         Console.WriteLine("{0}" + ControlChars.Tab + "{1}", myDE.Key, myDE.Value)
      Next myDE
      Console.WriteLine()

      ' Creates an array with DictionaryEntry elements.
      Dim myArr As DictionaryEntry() =  {New DictionaryEntry(), New DictionaryEntry(), New DictionaryEntry()}

      ' Copies the StringDictionary to the array.
      myCol.CopyTo(myArr, 0)

      ' Displays the values in the array.
      Console.WriteLine("KEYS" + ControlChars.Tab + "VALUES in the array")
      Dim i As Integer
      For i = 0 To myArr.Length - 1
         Console.WriteLine("{0}" + ControlChars.Tab + "{1}", myArr(i).Key, myArr(i).Value)
      Next i
      Console.WriteLine()

   End Sub 'Main 

End Class 'SamplesStringDictionary


'This code produces the following output.
'
'KEYS    VALUES in the StringDictionary
'green   verde
'red     rojo
'blue    azul
'
'KEYS    VALUES in the array
'green   verde
'red     rojo
'blue    azul

' </snippet1>