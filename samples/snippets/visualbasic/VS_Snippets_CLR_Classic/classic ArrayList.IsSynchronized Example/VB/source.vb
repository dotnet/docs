' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesArrayList
    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("The")
        myAL.Add("quick")
        myAL.Add("brown")
        myAL.Add("fox")
        
        ' Creates a synchronized wrapper around the ArrayList.
        Dim mySyncdAL As ArrayList = ArrayList.Synchronized(myAL)
        
        ' Displays the sychronization status of both ArrayLists.
        Dim str As String
        If myAL.IsSynchronized Then
            str = "synchronized"
        Else
            str = "not synchronized"
        End If
        Console.WriteLine("myAL is {0}.", str)
        If mySyncdAL.IsSynchronized Then
            str = "synchronized"
        Else
            str = "not synchronized"
        End If
        Console.WriteLine("mySyncdAL is {0}.", str)
    End Sub
End Class

' This code produces the following output.
' 
' myAL is not synchronized.
' mySyncdAL is synchronized. 
' </Snippet1>
