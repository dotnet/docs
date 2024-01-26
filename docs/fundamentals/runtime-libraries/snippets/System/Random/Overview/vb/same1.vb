' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.IO

Module Example14
    Public Sub Main()
        Dim seed As Integer = 100100
        ShowRandomNumbers(seed)
        Console.WriteLine()

        PersistSeed(seed)

        DisplayNewRandomNumbers()
    End Sub

    Private Sub ShowRandomNumbers(seed As Integer)
        Dim rnd As New Random(seed)
        For ctr As Integer = 0 To 20
            Console.WriteLine(rnd.NextDouble())
        Next
    End Sub

    Private Sub PersistSeed(seed As Integer)
        Dim fs As New FileStream(".\seed.dat", FileMode.Create)
        Dim bin As New BinaryWriter(fs)
        bin.Write(seed)
        bin.Close()
    End Sub

    Private Sub DisplayNewRandomNumbers()
        Dim fs As New FileStream(".\seed.dat", FileMode.Open)
        Dim bin As New BinaryReader(fs)
        Dim seed As Integer = bin.ReadInt32()
        bin.Close()

        Dim rnd As New Random(seed)
        For ctr As Integer = 0 To 20
            Console.WriteLine(rnd.NextDouble())
        Next
    End Sub
End Module
' The example displays output like the following:
'       0.500193602172748
'       0.0209461245783354
'       0.465869495396442
'       0.195512794514891
'       0.928583675496552
'       0.729333720509584
'       0.381455668891527
'       0.0508996467343064
'       0.019261200921266
'       0.258578445417145
'       0.0177532266908107
'       0.983277184415272
'       0.483650274334313
'       0.0219647376900375
'       0.165910115077118
'       0.572085966622497
'       0.805291457942357
'       0.927985211335116
'       0.4228545699375
'       0.523320379910674
'       0.157783938645285
'       
'       0.500193602172748
'       0.0209461245783354
'       0.465869495396442
'       0.195512794514891
'       0.928583675496552
'       0.729333720509584
'       0.381455668891527
'       0.0508996467343064
'       0.019261200921266
'       0.258578445417145
'       0.0177532266908107
'       0.983277184415272
'       0.483650274334313
'       0.0219647376900375
'       0.165910115077118
'       0.572085966622497
'       0.805291457942357
'       0.927985211335116
'       0.4228545699375
'       0.523320379910674
'       0.157783938645285
' </Snippet12>
