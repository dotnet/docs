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
        myAL.Add("jumped")
        
        ' Displays the count, capacity and values of the ArrayList.
        Console.WriteLine("Initially,")
        Console.WriteLine("   Count    : {0}", myAL.Count)
        Console.WriteLine("   Capacity : {0}", myAL.Capacity)
        Console.Write("   Values:")
        PrintValues(myAL)
        
        ' Trim the ArrayList.
        myAL.TrimToSize()
        
        ' Displays the count, capacity and values of the ArrayList.
        Console.WriteLine("After TrimToSize,")
        Console.WriteLine("   Count    : {0}", myAL.Count)
        Console.WriteLine("   Capacity : {0}", myAL.Capacity)
        Console.Write("   Values:")
        PrintValues(myAL)
        
        ' Clear the ArrayList.
        myAL.Clear()
        
        ' Displays the count, capacity and values of the ArrayList.
        Console.WriteLine("After Clear,")
        Console.WriteLine("   Count    : {0}", myAL.Count)
        Console.WriteLine("   Capacity : {0}", myAL.Capacity)
        Console.Write("   Values:")
        PrintValues(myAL)
        
        ' Trim the ArrayList again.
        myAL.TrimToSize()
        
        ' Displays the count, capacity and values of the ArrayList.
        Console.WriteLine("After the second TrimToSize,")
        Console.WriteLine("   Count    : {0}", myAL.Count)
        Console.WriteLine("   Capacity : {0}", myAL.Capacity)
        Console.Write("   Values:")
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

' This code produces the following output.
' 
' Initially,
'    Count    : 5
'    Capacity : 16
'    Values:    The    quick    brown    fox    jumped
' After TrimToSize,
'    Count    : 5
'    Capacity : 5
'    Values:    The    quick    brown    fox    jumped
' After Clear,
'    Count    : 0
'    Capacity : 5
'    Values:
' After the second TrimToSize,
'    Count    : 0
'    Capacity : 16
'    Values:
' </Snippet1>
