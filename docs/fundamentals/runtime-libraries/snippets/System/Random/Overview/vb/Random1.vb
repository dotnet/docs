' Visual Basic .NET Document
Option Strict On

'Imports System.Threading

' <Snippet1>
Module modMain

   Public Sub Main()
      Dim bytes1(99), bytes2(99) As Byte
      Dim rnd1 As New Random()
      Dim rnd2 As New Random()
      
      rnd1.NextBytes(bytes1)
      rnd2.NextBytes(bytes2)
      
      Console.WriteLine("First Series:")
      For ctr As Integer = bytes1.GetLowerBound(0) to bytes1.GetUpperBound(0)
         Console.Write("{0, 5}", bytes1(ctr))
         If (ctr + 1) Mod 10 = 0 Then Console.WriteLine()
      Next 
      Console.WriteLine()
      Console.WriteLine("Second Series:")        
      For ctr As Integer = bytes2.GetLowerBound(0) to bytes2.GetUpperBound(0)
         Console.Write("{0, 5}", bytes2(ctr))
         If (ctr + 1) Mod 10 = 0 Then Console.WriteLine()
      Next   
   End Sub
End Module
' The example displays output like the following:
'       First Series:
'          97  129  149   54   22  208  120  105   68  177
'         113  214   30  172   74  218  116  230   89   18
'          12  112  130  105  116  180  190  200  187  120
'           7  198  233  158   58   51   50  170   98   23
'          21    1  113   74  146  245   34  255   96   24
'         232  255   23    9  167  240  255   44  194   98
'          18  175  173  204  169  171  236  127  114   23
'         167  202  132   65  253   11  254   56  214  127
'         145  191  104  163  143    7  174  224  247   73
'          52    6  231  255    5  101   83  165  160  231
'       
'       Second Series:
'          97  129  149   54   22  208  120  105   68  177
'         113  214   30  172   74  218  116  230   89   18
'          12  112  130  105  116  180  190  200  187  120
'           7  198  233  158   58   51   50  170   98   23
'          21    1  113   74  146  245   34  255   96   24
'         232  255   23    9  167  240  255   44  194   98
'          18  175  173  204  169  171  236  127  114   23
'         167  202  132   65  253   11  254   56  214  127
'         145  191  104  163  143    7  174  224  247   73
'          52    6  231  255    5  101   83  165  160  231      
' </Snippet1>

