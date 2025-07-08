' Visual Basic .NET Document
Option Strict On

' <Snippet16>
Module Example13
    Public Sub Main()
        Dim rnd As New Random()
        For ctr As Integer = 1 To 50
            Console.Write("{0,3}    ", rnd.Next(1000, 10000))
            If ctr Mod 10 = 0 Then Console.WriteLine()
        Next
    End Sub
End Module
' The example displays output like the following:
'    9570    8979    5770    1606    3818    4735    8495    7196    7070    2313
'    5279    6577    5104    5734    4227    3373    7376    6007    8193    5540
'    7558    3934    3819    7392    1113    7191    6947    4963    9179    7907
'    3391    6667    7269    1838    7317    1981    5154    7377    3297    5320
'    9869    8694    2684    4949    2999    3019    2357    5211    9604    2593
' </Snippet16>
