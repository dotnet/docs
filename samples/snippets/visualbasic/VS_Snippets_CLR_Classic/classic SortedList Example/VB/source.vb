' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add("Third", "!")
        mySL.Add("Second", "World")
        mySL.Add("First", "Hello")
        
        ' Displays the properties and values of the SortedList.
        Console.WriteLine("mySL")
        Console.WriteLine("  Count:    {0}", mySL.Count)
        Console.WriteLine("  Capacity: {0}", mySL.Capacity)
        Console.WriteLine("  Keys and Values:")
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
' mySL
'   Count:    3
'   Capacity: 16
'   Keys and Values:
'     -KEY-     -VALUE-
'     First:    Hello
'     Second:   World
'     Third:    !
 
' </Snippet1>
