'<snippet1>
Imports System

Public Class JoinTest
    
    Public Shared Sub Main()
        
        Console.WriteLine(MakeLine(0, 5, ", "))
        Console.WriteLine(MakeLine(1, 6, "  "))
        Console.WriteLine(MakeLine(9, 9, ": "))
        Console.WriteLine(MakeLine(4, 7, "< "))
    End Sub 'Main
    
    
    Private Shared Function MakeLine(initVal As Integer, multVal As Integer, sep As String) As String
        Dim sArr(10) As String
        Dim i As Integer
        
        
        For i = initVal To (initVal + 10) - 1
            sArr((i - initVal)) = [String].Format("{0,-3}", i * multVal)
        
        Next i
        Return [String].Join(sep, sArr)
    End Function 'MakeLine
End Class 'JoinTest
' The example displays the following output:
'       0  , 5  , 10 , 15 , 20 , 25 , 30 , 35 , 40 , 45
'       6    12   18   24   30   36   42   48   54   60
'       81 : 90 : 99 : 108: 117: 126: 135: 144: 153: 162
'       28 < 35 < 42 < 49 < 56 < 63 < 70 < 77 < 84 < 91
'</snippet1>