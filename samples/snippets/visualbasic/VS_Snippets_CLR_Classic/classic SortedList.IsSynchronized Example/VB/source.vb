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
        
        ' Creates a synchronized wrapper around the SortedList.
        Dim mySyncdSL As SortedList = SortedList.Synchronized(mySL)
        
        ' Displays the sychronization status of both SortedLists.
        Dim msg As String
        If mySL.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If
        Console.WriteLine("mySL is {0}.", msg)
        If mySyncdSL.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If
        Console.WriteLine("mySyncdSL is {0}.", msg)        
    End Sub
End Class

' This code produces the following output.
'
' mySL is not synchronized.
' mySyncdSL is synchronized.
' </Snippet1>
