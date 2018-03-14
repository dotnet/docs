' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesHashtable    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new Hashtable.
        Dim myHT As New Hashtable()
        myHT.Add(0, "zero")
        myHT.Add(1, "one")
        myHT.Add(2, "two")
        myHT.Add(3, "three")
        myHT.Add(4, "four")
        
        ' Creates a synchronized wrapper around the Hashtable.
        Dim mySyncdHT As Hashtable = Hashtable.Synchronized(myHT)
        
        ' Displays the sychronization status of both Hashtables.
        Dim msg As String
        If myHT.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If
        Console.WriteLine("myHT is {0}.", msg)
        If mySyncdHT.IsSynchronized Then
            msg = "synchronized"
        Else
            msg = "not synchronized"
        End If        
        Console.WriteLine("mySyncdHT is {0}.", msg)
    End Sub
End Class

' This code produces the following output.
' 
' myHT is not synchronized.
' mySyncdHT is synchronized. 
' </Snippet1>
