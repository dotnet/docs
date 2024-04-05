' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Imports System.Text
Imports System.Text.RegularExpressions

Module Example12
    Public Sub Main()
        ' Create a StringBuilder object with 4 successive occurrences 
        ' of each character in the English alphabet. 
        Dim sb As New StringBuilder()
        For ctr As UShort = AscW("a") To AscW("z")
            sb.Append(ChrW(ctr), 4)
        Next
        ' Convert it to a string.
        Dim sbString As String = sb.ToString()

        ' Use a regex to uppercase the first occurrence of the sequence, 
        ' and separate it from the previous sequence by an underscore.
        Dim pattern As String = "(\w)(\1+)"
        sbString = Regex.Replace(sbString, pattern,
                               Function(m) If(m.Index > 0, "_", "") +
                                           m.Groups(1).Value.ToUpper +
                                           m.Groups(2).Value)

        ' Display the resulting string.
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
' </Snippet15>
