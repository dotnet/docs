' The following code example demonstrates several of the properties and methods of StringCollection.

' <snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Public Class SamplesStringCollection

   Public Shared Sub Main()

      ' Create and initializes a new StringCollection.
      Dim myCol As New StringCollection()

      ' Add a range of elements from an array to the end of the StringCollection.
      Dim myArr() As String = {"RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED"}
      myCol.AddRange(myArr)

      ' Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine("Displays the elements using foreach:")
      PrintValues1(myCol)

      ' Display the contents of the collection using the enumerator.
      Console.WriteLine("Displays the elements using the IEnumerator:")
      PrintValues2(myCol)

      ' Display the contents of the collection using the Count and Item properties.
      Console.WriteLine("Displays the elements using the Count and Item properties:")
      PrintValues3(myCol)

      ' Add one element to the end of the StringCollection and insert another at index 3.
      myCol.Add("* white")
      myCol.Insert(3, "* gray")

      Console.WriteLine("After adding ""* white"" to the end and inserting ""* gray"" at index 3:")
      PrintValues1(myCol)

      ' Remove one element from the StringCollection.
      myCol.Remove("yellow")

      Console.WriteLine("After removing ""yellow"":")
      PrintValues1(myCol)

      ' Remove all occurrences of a value from the StringCollection.
      Dim i As Integer = myCol.IndexOf("RED")
      While i > - 1
         myCol.RemoveAt(i)
         i = myCol.IndexOf("RED")
      End While

      ' Verify that all occurrences of "RED" are gone.
      If myCol.Contains("RED") Then
         Console.WriteLine("*** The collection still contains ""RED"".")
      End If 
      Console.WriteLine("After removing all occurrences of ""RED"":")
      PrintValues1(myCol)

      ' Copy the collection to a new array starting at index 0.
      Dim myArr2(myCol.Count) As String
      myCol.CopyTo(myArr2, 0)

      Console.WriteLine("The new array contains:")
      For i = 0 To myArr2.Length - 1
         Console.WriteLine("   [{0}] {1}", i, myArr2(i))
      Next i
      Console.WriteLine()

      ' Clears the entire collection.
      myCol.Clear()

      Console.WriteLine("After clearing the collection:")
      PrintValues1(myCol)
   End Sub 'Main


   ' Uses the foreach statement which hides the complexity of the enumerator.
   ' NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintValues1(myCol As StringCollection)
      Dim obj As [Object]
      For Each obj In  myCol
         Console.WriteLine("   {0}", obj)
      Next obj
      Console.WriteLine()
   End Sub 'PrintValues1


   ' Uses the enumerator. 
   ' NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   Public Shared Sub PrintValues2(myCol As StringCollection)
      Dim myEnumerator As StringEnumerator = myCol.GetEnumerator()
      While myEnumerator.MoveNext()
         Console.WriteLine("   {0}", myEnumerator.Current)
      End While
      Console.WriteLine()
   End Sub 'PrintValues2


   ' Uses the Count and Item properties.
   Public Shared Sub PrintValues3(myCol As StringCollection)
      Dim i As Integer
      For i = 0 To myCol.Count - 1
         Console.WriteLine("   {0}", myCol(i))
      Next i
      Console.WriteLine()
   End Sub 'PrintValues3

End Class 'SamplesStringCollection 


'This code produces the following output.
'
'Displays the elements using foreach:
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
'Displays the elements using the IEnumerator:
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
'Displays the elements using the Count and Item properties:
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
'After adding "* white" to the end and inserting "* gray" at index 3:
'   RED
'   orange
'   yellow
'   * gray
'   RED
'   green
'   blue
'   RED
'   indigo
'   violet
'   RED
'   * white
'
'After removing "yellow":
'   RED
'   orange
'   * gray
'   RED
'   green
'   blue
'   RED
'   indigo
'   violet
'   RED
'   * white
'
'After removing all occurrences of "RED":
'   orange
'   * gray
'   green
'   blue
'   indigo
'   violet
'   * white
'
'The new array contains:
'   [0] orange
'   [1] * gray
'   [2] green
'   [3] blue
'   [4] indigo
'   [5] violet
'   [6] * white
'
'After clearing the collection:
'

' </snippet1>