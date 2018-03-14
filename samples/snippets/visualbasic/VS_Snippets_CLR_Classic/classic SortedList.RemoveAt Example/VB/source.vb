' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add("3c", "dog")
        mySL.Add("2c", "over")
        mySL.Add("1c", "brown")
        mySL.Add("1a", "The")
        mySL.Add("1b", "quick")
        mySL.Add("3a", "the")
        mySL.Add("3b", "lazy")
        mySL.Add("2a", "fox")
        mySL.Add("2b", "jumped")
        
        ' Displays the SortedList.
        Console.WriteLine("The SortedList initially contains the following:")
        PrintKeysAndValues(mySL)
        
        ' Removes the element with the key "3b".
        mySL.Remove("3b")
        
        ' Displays the current state of the SortedList.
        Console.WriteLine("After removing ""lazy"":")
        PrintKeysAndValues(mySL)
        
        ' Removes the element at index 5.
        mySL.RemoveAt(5)
        
        ' Displays the current state of the SortedList.
        Console.WriteLine("After removing the element at index 5:")
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
' The SortedList initially contains the following:
'     -KEY-    -VALUE-
'     1a:    The
'     1b:    quick
'     1c:    brown
'     2a:    fox
'     2b:    jumped
'     2c:    over
'     3a:    the
'     3b:    lazy
'     3c:    dog
' 
' After removing "lazy":
'     -KEY-    -VALUE-
'     1a:    The
'     1b:    quick
'     1c:    brown
'     2a:    fox
'     2b:    jumped
'     2c:    over
'     3a:    the
'     3c:    dog
' 
' After removing the element at index 5:
'     -KEY-    -VALUE-
'     1a:    The
'     1b:    quick
'     1c:    brown
'     2a:    fox
'     2b:    jumped
'     3a:    the
'     3c:    dog 
' </Snippet1>
