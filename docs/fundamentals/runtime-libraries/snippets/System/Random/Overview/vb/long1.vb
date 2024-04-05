' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Module Example8
    Public Sub Main()
        Const ONE_TENTH As Long = 922337203685477581

        Dim rnd As New Random()
        Dim number As Long
        Dim count(9) As Integer

        ' Generate 20 million long integers.
        For ctr As Integer = 1 To 20000000
            number = CLng(rnd.NextDouble() * Int64.MaxValue)
            ' Categorize random numbers.
            count(CInt(number \ ONE_TENTH)) += 1
        Next
        ' Display breakdown by range.
        Console.WriteLine("{0,28} {1,32}   {2,7}", "Range", "Count", "Pct.")
        Console.WriteLine()
        For ctr As Integer = 0 To 9
            Console.WriteLine("{0,25:N0}-{1,25:N0}  {2,8:N0}   {3,7:P2}", ctr * ONE_TENTH,
                            If(ctr < 9, ctr * ONE_TENTH + ONE_TENTH - 1, Int64.MaxValue),
                            count(ctr), count(ctr) / 20000000)
        Next
    End Sub
End Module
' The example displays output like the following:
'                           Range                            Count      Pct.
'    
'                            0-  922,337,203,685,477,580  1,996,148    9.98 %
'      922,337,203,685,477,581-1,844,674,407,370,955,161  2,000,293   10.00 %
'    1,844,674,407,370,955,162-2,767,011,611,056,432,742  2,000,094   10.00 %
'    2,767,011,611,056,432,743-3,689,348,814,741,910,323  2,000,159   10.00 %
'    3,689,348,814,741,910,324-4,611,686,018,427,387,904  1,999,552   10.00 %
'    4,611,686,018,427,387,905-5,534,023,222,112,865,485  1,998,248    9.99 %
'    5,534,023,222,112,865,486-6,456,360,425,798,343,066  2,000,696   10.00 %
'    6,456,360,425,798,343,067-7,378,697,629,483,820,647  2,001,637   10.01 %
'    7,378,697,629,483,820,648-8,301,034,833,169,298,228  2,002,870   10.01 %
'    8,301,034,833,169,298,229-9,223,372,036,854,775,807  2,000,303   10.00 %
' </Snippet14>
