' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesHashtable

    Public Shared Sub Main()

        ' Creates and initializes the source Hashtable.
        Dim mySourceHT As New Hashtable()
        mySourceHT.Add("A", "valueA")
        mySourceHT.Add("B", "valueB")

        ' Creates and initializes the one-dimensional target Array.
        Dim myTargetArray(14) As String
        myTargetArray(0) = "The"
        myTargetArray(1) = "quick"
        myTargetArray(2) = "brown"
        myTargetArray(3) = "fox"
        myTargetArray(4) = "jumped"
        myTargetArray(5) = "over"
        myTargetArray(6) = "the"
        myTargetArray(7) = "lazy"
        myTargetArray(8) = "dog"

        ' Displays the values of the target Array.
        Console.WriteLine("The target Array contains the following before:")
        PrintValues(myTargetArray, " "c)

        ' Copies the keys in the source Hashtable to the target Hashtable, starting at index 6.
        Console.WriteLine("After copying the keys, starting at index 6:")
        mySourceHT.Keys.CopyTo(myTargetArray, 6)

        ' Displays the values of the target Array.
        PrintValues(myTargetArray, " "c)

        ' Copies the values in the source Hashtable to the target Hashtable, starting at index 6.
        Console.WriteLine("After copying the values, starting at index 6:")
        mySourceHT.Values.CopyTo(myTargetArray, 6)

        ' Displays the values of the target Array.
        PrintValues(myTargetArray, " "c)

    End Sub 'Main

    Public Shared Sub PrintValues(myArr() As String, mySeparator As Char)
        Dim i As Integer
        For i = 0 To myArr.Length - 1
            Console.Write("{0}{1}", mySeparator, myArr(i))
        Next i
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesHashtable


' This code produces the following output.
' 
' The target Array contains the following before:
'  The quick brown fox jumped over the lazy dog
' After copying the keys, starting at index 6:
'  The quick brown fox jumped over B A dog
' After copying the values, starting at index 6:
'  The quick brown fox jumped over valueB valueA dog

' </Snippet1>