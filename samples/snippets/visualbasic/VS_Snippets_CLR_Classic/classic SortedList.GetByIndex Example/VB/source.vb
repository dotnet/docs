' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList
        
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add(1.3, "fox")
        mySL.Add(1.4, "jumped")
        mySL.Add(1.5, "over")
        mySL.Add(1.2, "brown")
        mySL.Add(1.1, "quick")
        mySL.Add(1.0, "The")
        mySL.Add(1.6, "the")
        mySL.Add(1.8, "dog")
        mySL.Add(1.7, "lazy")
        
        ' Gets the key and the value based on the index.
        Dim myIndex As Integer = 3
        Console.WriteLine("The key   at index {0} is {1}.", myIndex, _
           mySL.GetKey(myIndex))
        Console.WriteLine("The value at index {0} is {1}.", myIndex, _
           mySL.GetByIndex(myIndex))
        
        ' Gets the list of keys and the list of values.
        Dim myKeyList As IList = mySL.GetKeyList()
        Dim myValueList As IList = mySL.GetValueList()
        
        ' Prints the keys in the first column and the values in the second column.
        Console.WriteLine(ControlChars.Tab & "-KEY-" & ControlChars.Tab & _
           "-VALUE-")
        Dim i As Integer
        For i = 0 To mySL.Count - 1
            Console.WriteLine(ControlChars.Tab & "{0}" & ControlChars.Tab & _
               "{1}", myKeyList(i), myValueList(i))
        Next i
    End Sub
End Class

' This code produces the following output.
' 
' The key   at index 3 is 1.3.
' The value at index 3 is fox.
'     -KEY-    -VALUE-
'     1    The
'     1.1    quick
'     1.2    brown
'     1.3    fox
'     1.4    jumped
'     1.5    over
'     1.6    the
'     1.7    lazy
'     1.8    dog
' </Snippet1>
