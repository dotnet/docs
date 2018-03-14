' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesArrayList

    Public Shared Sub Main()

        ' Creates and initializes the source ArrayList.
        Dim mySourceList As New ArrayList()
        mySourceList.Add("three")
        mySourceList.Add("napping")
        mySourceList.Add("cats")
        mySourceList.Add("in")
        mySourceList.Add("the")
        mySourceList.Add("barn")

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
        Console.WriteLine("The target Array contains the following (before and after copying):")
        PrintValues(myTargetArray, " "c)

        ' Copies the second element from the source ArrayList to the target Array, starting at index 7.
        mySourceList.CopyTo(1, myTargetArray, 7, 1)

        ' Displays the values of the target Array.
        PrintValues(myTargetArray, " "c)

        ' Copies the entire source ArrayList to the target Array, starting at index 6.
        mySourceList.CopyTo(myTargetArray, 6)

        ' Displays the values of the target Array.
        PrintValues(myTargetArray, " "c)

        ' Copies the entire source ArrayList to the target Array, starting at index 0.
        mySourceList.CopyTo(myTargetArray)

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

End Class 'SamplesArrayList 


' This code produces the following output.
' 
' The target Array contains the following (before and after copying):
'  The quick brown fox jumped over the lazy dog
'  The quick brown fox jumped over the napping dog
'  The quick brown fox jumped over three napping cats in the barn
'  three napping cats in the barn three napping cats in the barn

' </Snippet1>
