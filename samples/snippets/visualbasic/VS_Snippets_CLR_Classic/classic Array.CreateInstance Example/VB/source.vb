' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a one-dimensional Array of type Int32.
        Dim my1DArray As Array = Array.CreateInstance(GetType(Int32), 5)
        Dim i As Integer
        For i = my1DArray.GetLowerBound(0) To my1DArray.GetUpperBound(0)
            my1DArray.SetValue(i + 1, i)
        Next i 
        ' Displays the values of the Array.
        Console.WriteLine("The one-dimensional Array contains the " _
           + "following values:")
        PrintValues(my1DArray)
        
    End Sub
    
    Public Shared Sub PrintValues(myArr As Array)
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
            Console.Write(ControlChars.Tab + "{0}", myEnumerator.Current)
        End While
        Console.WriteLine()
    End Sub
End Class

' This code produces the following output.
' 
' The one-dimensional Array contains the following values:
'     1    2    3    4    5 
' </Snippet1>
