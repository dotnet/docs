' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Text

Module Example11
    Public Sub Main()
        ' Create a StringBuilder object with 4 successive occurrences 
        ' of each character in the English alphabet. 
        Dim sb As New StringBuilder()
        For ctr As UShort = AscW("a") To AscW("z")
            sb.Append(ChrW(ctr), 4)
        Next
        ' Iterate the text to determine when a new character sequence occurs.
        Dim position As Integer = 0
        Dim current As Char = ChrW(0)
        Do
            If sb(position) <> current Then
                current = sb(position)
                sb(position) = Char.ToUpper(sb(position))
                If position > 0 Then sb.Insert(position, "_")
                position += 2
            Else
                position += 1
            End If
        Loop While position <= sb.Length - 1
        ' Display the resulting string.
        Dim sbString As String = sb.ToString()
        Dim line As Integer = 0
        Do
            Dim nChars As Integer = If(line * 80 + 79 <= sbString.Length,
                                    80, sbString.Length - line * 80)
            Console.WriteLine(sbString.Substring(line * 80, nChars))
            line += 1
        Loop While line * 80 < sbString.Length
    End Sub
End Module
' The example displays the following output:
'    Aaaa_Bbbb_Cccc_Dddd_Eeee_Ffff_Gggg_Hhhh_Iiii_Jjjj_Kkkk_Llll_Mmmm_Nnnn_Oooo_Pppp_
'    Qqqq_Rrrr_Ssss_Tttt_Uuuu_Vvvv_Wwww_Xxxx_Yyyy_Zzzz
' </Snippet14>
