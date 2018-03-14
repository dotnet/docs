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
        myAL.Add("jumped")
        myAL.Add("over")
        myAL.Add("the")
        myAL.Add("lazy")
        myAL.Add("dog")

        ' Creates and initializes the source ICollection.
        Dim mySourceList As New Queue()
        mySourceList.Enqueue("big")
        mySourceList.Enqueue("gray")
        mySourceList.Enqueue("wolf")

        ' Displays the values of five elements starting at index 0.
        Dim mySubAL As ArrayList = myAL.GetRange(0, 5)
        Console.WriteLine("Index 0 through 4 contains:")
        PrintValues(mySubAL, vbTab)

        ' Replaces the values of five elements starting at index 1 with the values in the ICollection.
        myAL.SetRange(1, mySourceList)

        ' Displays the values of five elements starting at index 0.
        mySubAL = myAL.GetRange(0, 5)
        Console.WriteLine("Index 0 through 4 now contains:")
        PrintValues(mySubAL, vbTab)

    End Sub 'Main

    Public Shared Sub PrintValues(myList As IEnumerable, mySeparator As Char)
        Dim obj As [Object]
        For Each obj In  myList
            Console.Write("{0}{1}", mySeparator, obj)
        Next obj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesArrayList 


' This code produces the following output.
' 
' Index 0 through 4 contains:
'         The     quick   brown   fox     jumped
' Index 0 through 4 now contains:
'         The     big     gray    wolf    jumped

' </Snippet1>