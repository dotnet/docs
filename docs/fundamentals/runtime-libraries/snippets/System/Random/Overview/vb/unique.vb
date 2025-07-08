' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Threading

Module Example17
    Public Sub Main()
        Console.WriteLine("Instantiating two random number generators...")
        Dim rnd1 As New Random()
        Thread.Sleep(2000)
        Dim rnd2 As New Random()
        Console.WriteLine()

        Console.WriteLine("The first random number generator:")
        For ctr As Integer = 1 To 10
            Console.WriteLine("   {0}", rnd1.Next())
        Next
        Console.WriteLine()

        Console.WriteLine("The second random number generator:")
        For ctr As Integer = 1 To 10
            Console.WriteLine("   {0}", rnd2.Next())
        Next
    End Sub
End Module
' The example displays output like the following:
'       Instantiating two random number generators...
'       
'       The first random number generator:
'          643164361
'          1606571630
'          1725607587
'          2138048432
'          496874898
'          1969147632
'          2034533749
'          1840964542
'          412380298
'          47518930
'       
'       The second random number generator:
'          1251659083
'          1514185439
'          1465798544
'          517841554
'          1821920222
'          195154223
'          1538948391
'          1548375095
'          546062716
'          897797880
' </Snippet13>

