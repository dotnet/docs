' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a two-dimensional Array of type String.
        Dim my2DArray As Array = Array.CreateInstance(GetType(String), 2, 3)
        Dim i, j As Integer        
        For i = my2DArray.GetLowerBound(0) To my2DArray.GetUpperBound(0)
            For j = my2DArray.GetLowerBound(1) To my2DArray.GetUpperBound(1)
                my2DArray.SetValue("abc" + i.ToString() + j.ToString(), i, j)
            Next j 
        Next i

        ' Displays the values of the Array.
        Console.WriteLine("The two-dimensional Array contains the " _
           + "following values:")
        PrintValues(my2DArray)
    End Sub   
    
    Public Shared Sub PrintValues(myArr As Array)
        Dim myEnumerator As System.Collections.IEnumerator = _
           myArr.GetEnumerator()
        Dim i As Integer = 0
        Dim cols As Integer = myArr.GetLength(myArr.Rank - 1)
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
' The two-dimensional Array contains the following values:
'     abc00    abc01    abc02
'     abc10    abc11    abc12 
' </Snippet1>
