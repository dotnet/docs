Imports System.Globalization

Module JaggedArray
   Public Sub Main()
      ' Declare the jagged array of 12 elements. Each element is an array of Double.
      Dim sales(11)() As Double
      ' Set each element of the sales array to a Double array of the appropriate size.
      For month As Integer = 0 To 11
         ' The number of days in the month determines the appropriate size.
         Dim daysInMonth As Integer =
            DateTime.DaysInMonth(Year(Now), month + 1)
         sales(month) = New Double(daysInMonth - 1) {}
      Next 

      ' Store values in each element.
      For month As Integer = 0 To 11
         For dayOfMonth = 0 To sales(month).GetUpperBound(0)
            sales(month)(dayOfMonth) = (month * 100) + dayOfMonth
         Next
      Next

      ' Retrieve and display the array values.
      Dim monthNames = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames
      ' Display the month names.
      Console.Write("    ")
      For ctr = 0 To sales.GetUpperBound(0)
         Console.Write($" {monthNames(ctr)}   ")
      Next   
      Console.WriteLine()
      ' Display data for each day in each month.
      For dayInMonth = 0 To 30
         Console.Write($"{dayInMonth + 1,2}.  ")
         For monthNumber = 0 To sales.GetUpperBound(0)
            If dayInMonth > sales(monthNumber).GetUpperBound(0) Then 
               Console.Write("       ")
            Else
               Console.Write($"{sales(monthNumber)(dayInMonth),-5}  ")
            End If
         Next   
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'      Jan    Feb    Mar    Apr    May    Jun    Jul    Aug    Sep    Oct    Nov    Dec
'  1.  0      100    200    300    400    500    600    700    800    900    1000   1100
'  2.  1      101    201    301    401    501    601    701    801    901    1001   1101
'  3.  2      102    202    302    402    502    602    702    802    902    1002   1102
'  4.  3      103    203    303    403    503    603    703    803    903    1003   1103
'  5.  4      104    204    304    404    504    604    704    804    904    1004   1104
'  6.  5      105    205    305    405    505    605    705    805    905    1005   1105
'  7.  6      106    206    306    406    506    606    706    806    906    1006   1106
'  8.  7      107    207    307    407    507    607    707    807    907    1007   1107
'  9.  8      108    208    308    408    508    608    708    808    908    1008   1108
' 10.  9      109    209    309    409    509    609    709    809    909    1009   1109
' 11.  10     110    210    310    410    510    610    710    810    910    1010   1110
' 12.  11     111    211    311    411    511    611    711    811    911    1011   1111
' 13.  12     112    212    312    412    512    612    712    812    912    1012   1112
' 14.  13     113    213    313    413    513    613    713    813    913    1013   1113
' 15.  14     114    214    314    414    514    614    714    814    914    1014   1114
' 16.  15     115    215    315    415    515    615    715    815    915    1015   1115
' 17.  16     116    216    316    416    516    616    716    816    916    1016   1116
' 18.  17     117    217    317    417    517    617    717    817    917    1017   1117
' 19.  18     118    218    318    418    518    618    718    818    918    1018   1118
' 20.  19     119    219    319    419    519    619    719    819    919    1019   1119
' 21.  20     120    220    320    420    520    620    720    820    920    1020   1120
' 22.  21     121    221    321    421    521    621    721    821    921    1021   1121
' 23.  22     122    222    322    422    522    622    722    822    922    1022   1122
' 24.  23     123    223    323    423    523    623    723    823    923    1023   1123
' 25.  24     124    224    324    424    524    624    724    824    924    1024   1124
' 26.  25     125    225    325    425    525    625    725    825    925    1025   1125
' 27.  26     126    226    326    426    526    626    726    826    926    1026   1126
' 28.  27     127    227    327    427    527    627    727    827    927    1027   1127
' 29.  28            228    328    428    528    628    728    828    928    1028   1128
' 30.  29            229    329    429    529    629    729    829    929    1029   1129
' 31.  30            230           430           630    730           930           1130
