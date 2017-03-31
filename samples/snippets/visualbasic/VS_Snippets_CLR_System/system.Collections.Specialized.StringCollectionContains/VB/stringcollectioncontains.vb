' The following code example searches the StringCollection for an element.

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

      ' Checks whether the collection contains "orange" and, if so, displays its index.
      If myCol.Contains("orange") Then
         Console.WriteLine("The collection contains ""orange"" at index {0}.", myCol.IndexOf("orange"))
      Else
         Console.WriteLine("The collection does not contain ""orange"".")
      End If 

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
'The collection contains "orange" at index 1.
'

' </snippet1>
