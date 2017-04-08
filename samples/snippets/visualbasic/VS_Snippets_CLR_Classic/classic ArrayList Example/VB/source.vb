' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("Hello")
        myAL.Add("World")
        myAL.Add("!")
        
        ' Displays the properties and values of the ArrayList.
        Console.WriteLine("myAL")
        Console.WriteLine("    Count:    {0}", myAL.Count)
        Console.WriteLine("    Capacity: {0}", myAL.Capacity)
        Console.Write("    Values:")
        PrintValues(myAL)
    End Sub

    Public Shared Sub PrintValues(myList As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myList
            Console.Write("   {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class


' This code produces output similar to the following:
' 
' myAL
'     Count:    3
'     Capacity: 4
'     Values:   Hello   World   !

' </Snippet1>
