' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesArrayList    

    Public Shared Sub Main()

        ' Creates a new ArrayList with five elements and initialize each
        ' element with a null value.
        Dim myAL As ArrayList = ArrayList.Repeat(Nothing, 5)

        ' Displays the count, capacity and values of the ArrayList.
        Console.WriteLine("ArrayList with five elements with a null value")
        Console.WriteLine("   Count    : {0}", myAL.Count)
        Console.WriteLine("   Capacity : {0}", myAL.Capacity)
        Console.Write("   Values:")
        PrintValues(myAL)

        ' Creates a new ArrayList with seven elements and initialize each
        ' element with the string "abc".
        myAL = ArrayList.Repeat("abc", 7)

        ' Displays the count, capacity and values of the ArrayList.
        Console.WriteLine("ArrayList with seven elements with a string value")
        Console.WriteLine("   Count    : {0}", myAL.Count)
        Console.WriteLine("   Capacity : {0}", myAL.Capacity)
        Console.Write("   Values:")
        PrintValues(myAL)

    End Sub 'Main

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
' ArrayList with five elements with a null value
'    Count    : 5
'    Capacity : 16
'    Values:					
' ArrayList with seven elements with a string value
'    Count    : 7
'    Capacity : 16
'    Values:	abc	abc	abc	abc	abc	abc	abc
' </Snippet1>
