' The following code example removes elements from the StringCollection.

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

      ' Removes one element from the StringCollection.
      myCol.Remove("yellow")

      Console.WriteLine("After removing ""yellow"":")
      PrintValues(myCol)

      ' Removes all occurrences of a value from the StringCollection.
      Dim i As Integer = myCol.IndexOf("RED")
      While i > - 1
         myCol.RemoveAt(i)
         i = myCol.IndexOf("RED")
      End While

      Console.WriteLine("After removing all occurrences of ""RED"":")
      PrintValues(myCol)

      ' Clears the entire collection.
      myCol.Clear()

      Console.WriteLine("After clearing the collection:")
      PrintValues(myCol)

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
'After removing "yellow":
'   RED
'   orange
'   RED
'   green
'   blue
'   RED
'   indigo
'   violet
'   RED
'
'After removing all occurrences of "RED":
'   orange
'   green
'   blue
'   indigo
'   violet
'
'After clearing the collection:
'

' </snippet1>
