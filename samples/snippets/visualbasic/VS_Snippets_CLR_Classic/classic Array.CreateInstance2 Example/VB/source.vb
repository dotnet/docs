' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a three-dimensional Array of type Object.
        Dim my3DArray As Array = Array.CreateInstance(GetType(Object), 2, 3, 4)
        Dim i As Integer
        For i = my3DArray.GetLowerBound(0) To my3DArray.GetUpperBound(0)
            Dim j As Integer
            For j = my3DArray.GetLowerBound(1) To my3DArray.GetUpperBound(1)
                Dim k As Integer
                For k = my3DArray.GetLowerBound(2) To my3DArray.GetUpperBound(2)
                    my3DArray.SetValue("abc" + i.ToString() _
                       + j.ToString() + k.ToString(), i, j, k)
                Next k 
            Next j
        Next i

        ' Displays the values of the Array.
        Console.WriteLine("The three-dimensional Array contains the " _
           + "following values:")
        PrintValues(my3DArray)
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
' The three-dimensional Array contains the following values:
'     abc000    abc001    abc002    abc003
'     abc010    abc011    abc012    abc013
'     abc020    abc021    abc022    abc023
'     abc100    abc101    abc102    abc103
'     abc110    abc111    abc112    abc113
'     abc120    abc121    abc122    abc123 
' </Snippet1>
