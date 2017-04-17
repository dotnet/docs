' The following code example copies a StringCollection to an array.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesStringCollection   

   Public Shared Sub Main()

      ' Creates and initializes a new StringCollection.
      Dim myCol As New StringCollection()
      Dim myArr() As [String] = {"RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED"}
      myCol.AddRange(myArr)

      Console.WriteLine("Initial contents of the StringCollection:")
      PrintValues(myCol)

      ' Copies the collection to a new array starting at index 0.
      Dim myArr2(myCol.Count) As [String]
      myCol.CopyTo(myArr2, 0)

      Console.WriteLine("The new array contains:")
      Dim i As Integer
      For i = 0 To myArr2.Length - 1
         Console.WriteLine("   [{0}] {1}", i, myArr2(i))
      Next i
      Console.WriteLine()

   End Sub 'Main

   Public Shared Sub PrintValues(myCol As IEnumerable)
      Dim obj As [Object]
      For Each obj In  myCol
         Console.WriteLine("   {0}", obj)
      Next obj
      Console.WriteLine()
   End Sub 'PrintValues

End Class 'SamplesStringCollection 


'This code produces the following output.
'
'Initial contents of the StringCollection:
'   RED
'   orange
'   yellow
'   RED
'   green
'   blue
'   RED
'   indigo
'   violet
'   RED
'
'The new array contains:
'   [0] RED
'   [1] orange
'   [2] yellow
'   [3] RED
'   [4] green
'   [5] blue
'   [6] RED
'   [7] indigo
'   [8] violet
'   [9] RED
'

' </snippet1>
