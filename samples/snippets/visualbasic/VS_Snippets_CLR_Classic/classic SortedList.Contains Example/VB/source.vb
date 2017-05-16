' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesSortedList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new SortedList.
        Dim mySL As New SortedList()
        mySL.Add(2, "two")
        mySL.Add(4, "four")
        mySL.Add(1, "one")
        mySL.Add(3, "three")
        mySL.Add(0, "zero")
        
        ' Displays the values of the SortedList.
        Console.WriteLine("The SortedList contains the following values:")
        PrintIndexAndKeysAndValues(mySL)
        
        ' Searches for a specific key.
        Dim myKey As Integer = 2
        Dim msg As String
        If mySL.ContainsKey(myKey) Then
            msg = "in the SortedList"
        Else
            msg = "NOT in the SortedList"
        End If
        Console.WriteLine("The key ""{0}"" is {1}.", myKey, msg)
        myKey = 6
        If mySL.ContainsKey(myKey) Then
            msg = "in the SortedList"
        Else
            msg = "NOT in the SortedList"
        End If
        Console.WriteLine("The key ""{0}"" is {1}.", myKey, msg)        
        ' Searches for a specific value.
        Dim myValue As String = "three"
        If mySL.ContainsValue(myValue) Then
            msg = "in the SortedList"
        Else
            msg = "NOT in the SortedList"
        End If
        Console.WriteLine("The value ""{0}"" is {1}.", myValue, msg)
        myValue = "nine"
        If mySL.ContainsValue(myValue) Then
            msg = "in the SortedList"
        Else
            msg = "NOT in the SortedList"
        End If
        Console.WriteLine("The value ""{0}"" is {1}.", myValue, msg)
    End Sub   
    
    
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
' The key "2" is in the SortedList.
' The key "6" is NOT in the SortedList.
' The value "three" is in the SortedList.
' The value "nine" is NOT in the SortedList. 
' </Snippet1>
