' <Snippet4>
Imports System.Globalization
Imports System.Text

Public Module Example
   Public Sub Main()
      Dim rnd As New Random()
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("fr-FR")
      Dim sb As New StringBuilder()
      Dim formatString As String = "    {0,12:N0} ({0,8:X8})" + vbCrLf +
                                   "And {1,12:N0} ({1,8:X8})" + vbCrLf +
                                   "  = {2,12:N0} ({2,8:X8})" + vbCrLf
      For ctr As Integer = 0 To 2
         Dim value1 As Integer = rnd.Next()
         Dim value2 As Integer = rnd.Next()
         sb.AppendFormat(culture, formatString,
                         value1, value2, value1 And value2).AppendLine()
      Next
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays the following output:
'           1 984 112 195 (76432643)
'       And 1 179 778 511 (4651FDCF)
'         = 1 178 674 243 (46412443)
'
'           2 034 813 710 (7948CB0E)
'       And  569 333 976 (21EF58D8)
'         =  558 385 160 (21484808)
'
'            126 717 735 (078D8F27)
'       And 1 830 715 973 (6D1E8245)
'         =   84 705 797 (050C8205)
' </Snippet4>
