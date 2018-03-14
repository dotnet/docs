' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a multidimensional Array of type String.
        Dim myLengthsArray() As Integer = {3, 5}
        Dim myBoundsArray() As Integer = {2, 3}
        Dim myArray As Array = Array.CreateInstance(GetType(String), _
           myLengthsArray, myBoundsArray)
        Dim i, j As Integer
        Dim myIndicesArray() As Integer
        For i = myArray.GetLowerBound(0) To myArray.GetUpperBound(0)
            For j = myArray.GetLowerBound(1) To myArray.GetUpperBound(1)
                myIndicesArray = New Integer() {i, j}
                myArray.SetValue(i.ToString() + j.ToString(), myIndicesArray)
            Next j
        Next i
        
        ' Displays the lower bounds and the upper bounds of each dimension.
        Console.WriteLine("Bounds:" + ControlChars.Tab + "Lower" _
           + ControlChars.Tab + "Upper")
        For i = 0 To myArray.Rank - 1
            Console.WriteLine("{0}:" + ControlChars.Tab + "{1}" _
               + ControlChars.Tab + "{2}", i, myArray.GetLowerBound(i), _
               myArray.GetUpperBound(i))
        Next i
        
        ' Displays the values of the Array.
        Console.WriteLine("The Array contains the following values:")
        PrintValues(myArray)
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
' Bounds:    Lower    Upper
' 0:    2    4
' 1:    3    7
' The Array contains the following values:
'     23    24    25    26    27
'     33    34    35    36    37
'     43    44    45    46    47 
' </Snippet1>
