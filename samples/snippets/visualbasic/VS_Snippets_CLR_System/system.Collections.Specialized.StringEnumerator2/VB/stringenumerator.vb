' The following code example demonstrates several of the properties and methods of StringEnumerator.

' <snippet1>
Imports System
Imports System.Collections.Specialized

Public Class SamplesStringEnumerator

   Public Shared Sub Main()

      ' Creates and initializes a StringCollection.
      Dim myCol As New StringCollection()
      Dim myArr() As [String] = {"red", "orange", "yellow", "green", "blue", "indigo", "violet"}
      myCol.AddRange(myArr)

      ' Enumerates the elements in the StringCollection.
      Dim myEnumerator As StringEnumerator = myCol.GetEnumerator()
      While myEnumerator.MoveNext()
         Console.WriteLine("{0}", myEnumerator.Current)
      End While
      Console.WriteLine()

      ' Resets the enumerator and displays the first element again.
      myEnumerator.Reset()
      If myEnumerator.MoveNext() Then
         Console.WriteLine("The first element is {0}.", myEnumerator.Current)
      End If 

   End Sub 'Main

End Class 'SamplesStringEnumerator 


'This code produces the following output.
'
'red
'orange
'yellow
'green
'blue
'indigo
'violet
'
'The first element is red.

' </snippet1>