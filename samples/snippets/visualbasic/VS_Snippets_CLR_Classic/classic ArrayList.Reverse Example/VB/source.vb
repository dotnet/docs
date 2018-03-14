' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a new ArrayList.
        Dim myAL As New ArrayList()
        myAL.Add("The")
        myAL.Add("quick")
        myAL.Add("brown")
        myAL.Add("fox")
        myAL.Add("jumps")
        myAL.Add("over")
        myAL.Add("the")
        myAL.Add("lazy")
        myAL.Add("dog")
        
        ' Displays the values of the ArrayList.
        Console.WriteLine("The ArrayList initially contains the " _
           + "following values:")
        PrintValues(myAL)
        
        ' Reverses the sort order of the values of the ArrayList.
        myAL.Reverse()
        
        ' Displays the values of the ArrayList.
        Console.WriteLine("After reversing:")
        PrintValues(myAL)
    End Sub
    
    Public Shared Sub PrintValues(myList As IEnumerable)
        Dim obj As [Object]
        For Each obj In  myList
            Console.WriteLine("   {0}", obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class


' This code produces the following output.
' 
' The ArrayList initially contains the following values:
'    The
'    quick
'    brown
'    fox
'    jumps
'    over
'    the
'    lazy
'    dog
'
' After reversing:
'    dog
'    lazy
'    the
'    over
'    jumps
'    fox
'    brown
'    quick
'    The

' </Snippet1>
