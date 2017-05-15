' <Snippet1>
Imports System
Imports System.Collections
Imports Microsoft.VisualBasic

Public Class SamplesQueue    

    Public Shared Sub Main()

        ' Creates and initializes the source Queue.
        Dim mySourceQ As New Queue()
        mySourceQ.Enqueue("three")
        mySourceQ.Enqueue("napping")
        mySourceQ.Enqueue("cats")
        mySourceQ.Enqueue("in")
        mySourceQ.Enqueue("the")
        mySourceQ.Enqueue("barn")

        ' Creates and initializes the one-dimensional target Array.
        Dim myTargetArray As Array = Array.CreateInstance(GetType(String), 15)
        myTargetArray.SetValue("The", 0)
        myTargetArray.SetValue("quick", 1)
        myTargetArray.SetValue("brown", 2)
        myTargetArray.SetValue("fox", 3)
        myTargetArray.SetValue("jumped", 4)
        myTargetArray.SetValue("over", 5)
        myTargetArray.SetValue("the", 6)
        myTargetArray.SetValue("lazy", 7)
        myTargetArray.SetValue("dog", 8)

        ' Displays the values of the target Array.
        Console.WriteLine("The target Array contains the " & _
           "following (before and after copying):")
        PrintValues(myTargetArray, " "c)

        ' Copies the entire source Queue to the target Array, starting
        ' at index 6.
        mySourceQ.CopyTo(myTargetArray, 6)

        ' Displays the values of the target Array.
        PrintValues(myTargetArray, " "c)

        ' Copies the entire source Queue to a new standard array.
        Dim myStandardArray As Object() = mySourceQ.ToArray()

        ' Displays the values of the new standard array.
        Console.WriteLine("The new standard array contains the following:")
        PrintValues(myStandardArray, " "c)

    End Sub

    Public Shared Sub PrintValues(myArr As Array, mySeparator As Char)
        Dim myObj As [Object]
        For Each myObj In  myArr
            Console.Write("{0}{1}", mySeparator, myObj)
        Next myObj
        Console.WriteLine()
    End Sub 'PrintValues

End Class 'SamplesQueue


' This code produces the following output.
' 
' The target Array contains the following (before and after copying):
'  The quick brown fox jumped over the lazy dog
'  The quick brown fox jumped over three napping cats in the barn
' The new standard array contains the following:
'  three napping cats in the barn

' </Snippet1>
