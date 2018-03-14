' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add("one", "The")
        mySL.Add("two", "quick")
        mySL.Add("three", "brown")
        mySL.Add("four", "fox")
        
        ' Displays the SortedList.
        Console.WriteLine("The SortedList contains the following:")
        PrintKeysAndValues(mySL)
    End Sub    
    
    Public Shared Sub PrintKeysAndValues(myList As SortedList)
        Console.WriteLine(ControlChars.Tab & "-KEY-" & ControlChars.Tab & _
           "-VALUE-")
        Dim i As Integer
        For i = 0 To myList.Count - 1
            Console.WriteLine(ControlChars.Tab & "{0}:" & ControlChars.Tab & _
               "{1}", myList.GetKey(i), myList.GetByIndex(i))
        Next i
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' The SortedList contains the following:
'     -KEY-    -VALUE-
'     four:    fox
'     one:    The
'     three:    brown
'     two:    quick
 
' </Snippet1>
