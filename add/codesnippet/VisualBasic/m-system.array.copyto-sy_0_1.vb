Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes two new Arrays.
        Dim mySourceArray As Array = Array.CreateInstance(GetType(String), 6)
        mySourceArray.SetValue("three", 0)
        mySourceArray.SetValue("napping", 1)
        mySourceArray.SetValue("cats", 2)
        mySourceArray.SetValue("in", 3)
        mySourceArray.SetValue("the", 4)
        mySourceArray.SetValue("barn", 5)
        Dim myTargetArray As Array = Array.CreateInstance(GetType(String), 15)
        myTargetArray.SetValue("The", 0)
        myTargetArray.SetValue("quick", 1)
        myTargetArray.SetValue("brown", 2)
        myTargetArray.SetValue("fox", 3)
        myTargetArray.SetValue("jumps", 4)
        myTargetArray.SetValue("over", 5)
        myTargetArray.SetValue("the", 6)
        myTargetArray.SetValue("lazy", 7)
        myTargetArray.SetValue("dog", 8)
        
        ' Displays the values of the Array.
        Console.WriteLine("The target Array contains the following" _
           & "(before and after copying):")
        PrintValues(myTargetArray, " "c)
        
        ' Copies the source Array to the target Array, starting at index 6.
        mySourceArray.CopyTo(myTargetArray, 6)
        
        ' Displays the values of the Array.
        PrintValues(myTargetArray, " "c)
    End Sub    
    
    Public Shared Sub PrintValues(myArr As Array, mySeparator As Char)
        Dim myEnumerator As System.Collections.IEnumerator = _
           myArr.GetEnumerator()
        Dim i As Integer = 0
        Dim cols As Integer = myArr.GetLength((myArr.Rank - 1))
        While myEnumerator.MoveNext()
            If i < cols Then
                i += 1
            Else
                Console.WriteLine()
                i = 1
            End If
            Console.Write("{0}{1}", mySeparator, myEnumerator.Current)
        End While
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
'  The target Array contains the following (before and after copying):
'  The quick brown fox jumps over the lazy dog      
'  The quick brown fox jumps over three napping cats in the barn