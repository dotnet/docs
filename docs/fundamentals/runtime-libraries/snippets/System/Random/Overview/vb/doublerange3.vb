' Visual Basic .NET Document
Option Strict On

' <Snippet19>
Module Example7
    Public Sub Main()
        Dim rnd As New Random()
        Dim lowerBound As Integer = 10
        Dim upperBound As Integer = 11
        Dim range(9) As Integer
        For ctr As Integer = 1 To 1000000
            Dim value As Double = rnd.NextDouble() * (upperBound - lowerBound) + lowerBound
            range(CInt(Math.Truncate((value - lowerBound) * 10))) += 1
        Next

        For ctr As Integer = 0 To 9
            Dim lowerRange As Double = 10 + ctr * 0.1
            Console.WriteLine("{0:N1} to {1:N1}: {2,8:N0}  ({3,7:P2})",
                           lowerRange, lowerRange + 0.1, range(ctr),
                           range(ctr) / 1000000.0)
        Next
    End Sub
End Module
' The example displays output like the following:
'       10.0 to 10.1:   99,929  ( 9.99 %)
'       10.1 to 10.2:  100,189  (10.02 %)
'       10.2 to 10.3:   99,384  ( 9.94 %)
'       10.3 to 10.4:  100,240  (10.02 %)
'       10.4 to 10.5:   99,397  ( 9.94 %)
'       10.5 to 10.6:  100,580  (10.06 %)
'       10.6 to 10.7:  100,293  (10.03 %)
'       10.7 to 10.8:  100,135  (10.01 %)
'       10.8 to 10.9:   99,905  ( 9.99 %)
'       10.9 to 11.0:   99,948  ( 9.99 %)
' </Snippet19>

