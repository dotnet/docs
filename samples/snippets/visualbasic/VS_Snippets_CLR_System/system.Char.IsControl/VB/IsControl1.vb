' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Module ControlChars
   Public Sub Main()
      Dim charsWritten As Integer = 0

      For ctr As Integer = &H0 To &HFFFF
         Dim ch As Char = Convert.ToChar(ctr)
         
         If Char.IsControl(ch) Then
            Console.Write("\U{0:X4}    ", ctr)
            charsWritten += 1 
            If (charsWritten Mod 6) = 0 Then 
               Console.WriteLine()
            End If    
         End If
      Next
   End Sub
End Module
' The example displays the following output to the console:
'       \U0000    \U0001    \U0002    \U0003    \U0004    \U0005
'       \U0006    \U0007    \U0008    \U0009    \U000A    \U000B
'       \U000C    \U000D    \U000E    \U000F    \U0010    \U0011
'       \U0012    \U0013    \U0014    \U0015    \U0016    \U0017
'       \U0018    \U0019    \U001A    \U001B    \U001C    \U001D
'       \U001E    \U001F    \U007F    \U0080    \U0081    \U0082
'       \U0083    \U0084    \U0085    \U0086    \U0087    \U0088
'       \U0089    \U008A    \U008B    \U008C    \U008D    \U008E
'       \U008F    \U0090    \U0091    \U0092    \U0093    \U0094
'       \U0095    \U0096    \U0097    \U0098    \U0099    \U009A
'       \U009B    \U009C    \U009D    \U009E    \U009F
' </Snippet1>
