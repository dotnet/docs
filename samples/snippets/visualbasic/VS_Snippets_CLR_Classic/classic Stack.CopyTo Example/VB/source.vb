' <Snippet1>
Imports System
Imports System.Collections

Public Class SamplesStack    
    
    Public Shared Sub Main()
        
        ' Creates and initializes the source Stack.
        Dim mySourceQ As New Stack()
        mySourceQ.Push("barn")
        mySourceQ.Push("the")
        mySourceQ.Push("in")
        mySourceQ.Push("cats")
        mySourceQ.Push("napping")
        mySourceQ.Push("three")
        
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
        
        ' Copies the entire source Stack to the target Array, starting
        ' at index 6.
        mySourceQ.CopyTo(myTargetArray, 6)
        
        ' Displays the values of the target Array.
        PrintValues(myTargetArray, " "c)
        
        ' Copies the entire source Stack to a new standard array.
        Dim myStandardArray As Object() = mySourceQ.ToArray()
        
        ' Displays the values of the new standard array.
        Console.WriteLine("The new standard array contains the following:")
        PrintValues(myStandardArray, " "c)
    End Sub    
    
    Overloads Public Shared Sub PrintValues(myArr As Array, _
       mySeparator As Char)
       
        Dim myObj As Object
        For Each myObj In  myArr
            Console.Write("{0}{1}", mySeparator, myObj)
        Next myObj
        Console.WriteLine()
    End Sub

End Class


' This code produces the following output.
'
' The target Array contains the following (before and after copying):
'  The quick brown fox jumped over the lazy dog
'  The quick brown fox jumped over three napping cats in the barn
' The new standard array contains the following:
'  three napping cats in the barn 

' </Snippet1>
