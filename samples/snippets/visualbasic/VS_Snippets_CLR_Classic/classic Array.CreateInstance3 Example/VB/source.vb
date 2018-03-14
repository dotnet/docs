' <Snippet1>
Imports System
Imports Microsoft.VisualBasic

Public Class SamplesArray    
    
    Public Shared Sub Main()
        
        ' Creates and initializes a multidimensional Array of type String.
        Dim myLengthsArray() As Integer = {2, 3, 4, 5}
        Dim my4DArray As Array = Array.CreateInstance(GetType(String), myLengthsArray)
        Dim i, j, k, l As Integer
        Dim myIndicesArray() As Integer
        For i = my4DArray.GetLowerBound(0) To my4DArray.GetUpperBound(0)
            For j = my4DArray.GetLowerBound(1) To my4DArray.GetUpperBound(1)
                For k = my4DArray.GetLowerBound(2) To my4DArray.GetUpperBound(2)
                    For l = my4DArray.GetLowerBound(3) To my4DArray.GetUpperBound(3)
                        myIndicesArray = New Integer() {i, j, k, l}
                        my4DArray.SetValue(Convert.ToString(i) + j.ToString() _
                           + k.ToString() + l.ToString(), myIndicesArray)
                    Next l
                Next k 
            Next j
        Next i

        ' Displays the values of the Array.
        Console.WriteLine("The four-dimensional Array contains the following values:")
        PrintValues(my4DArray)
    End Sub
    
    
    Public Shared Sub PrintValues(myArr As Array)
        Dim myEnumerator As System.Collections.IEnumerator = myArr.GetEnumerator()
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
' The four-dimensional Array contains the following values:
'     0000    0001    0002    0003    0004
'     0010    0011    0012    0013    0014
'     0020    0021    0022    0023    0024
'     0030    0031    0032    0033    0034
'     0100    0101    0102    0103    0104
'     0110    0111    0112    0113    0114
'     0120    0121    0122    0123    0124
'     0130    0131    0132    0133    0134
'     0200    0201    0202    0203    0204
'     0210    0211    0212    0213    0214
'     0220    0221    0222    0223    0224
'     0230    0231    0232    0233    0234
'     1000    1001    1002    1003    1004
'     1010    1011    1012    1013    1014
'     1020    1021    1022    1023    1024
'     1030    1031    1032    1033    1034
'     1100    1101    1102    1103    1104
 '    1110    1111    1112    1113    1114
'     1120    1121    1122    1123    1124
'     1130    1131    1132    1133    1134
'     1200    1201    1202    1203    1204
'     1210    1211    1212    1213    1214
'     1220    1221    1222    1223    1224
'     1230    1231    1232    1233    1234
' </Snippet1>
