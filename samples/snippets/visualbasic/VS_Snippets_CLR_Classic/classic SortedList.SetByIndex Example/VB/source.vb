' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add(2, "two")
        mySL.Add(3, "three")
        mySL.Add(1, "one")
        mySL.Add(0, "zero")
        mySL.Add(4, "four")
        
        ' Displays the values of the SortedList.
        Console.WriteLine("The SortedList contains the following" & _
           "values:")
        PrintIndexAndKeysAndValues(mySL)
        
        ' Replaces the values at index 3 and index 4.
        mySL.SetByIndex(3, "III")
        mySL.SetByIndex(4, "IV")
        
        ' Displays the updated values of the SortedList.
        Console.WriteLine("After replacing the value at index 3 and index 4,")
        PrintIndexAndKeysAndValues(mySL)
    End Sub 'Main
    
    
    
    Public Shared Sub PrintIndexAndKeysAndValues(myList As SortedList)
        Console.WriteLine(ControlChars.Tab & "-INDEX-" & ControlChars.Tab & _
           "-KEY-" & ControlChars.Tab & "-VALUE-")
        Dim i As Integer
        For i = 0 To myList.Count - 1
            Console.WriteLine(ControlChars.Tab & "[{0}]:" & ControlChars.Tab & _
               "{1}" & ControlChars.Tab & "{2}", i, myList.GetKey(i), _
               myList.GetByIndex(i))
        Next i
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' The SortedList contains the following values:
'     -INDEX-    -KEY-    -VALUE-
'     [0]:    0    zero
'     [1]:    1    one
'     [2]:    2    two
'     [3]:    3    three
'     [4]:    4    four
' 
' After replacing the value at index 3 and index 4,
'     -INDEX-    -KEY-    -VALUE-
'     [0]:    0    zero
'     [1]:    1    one
'     [2]:    2    two
'     [3]:    3    III
'     [4]:    4    IV
' </Snippet1>
