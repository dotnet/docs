' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Globalization
Imports System.IO
Imports System.Text

Module Example16
    Private sw As StreamWriter

    Public Sub Main()
        sw = New StreamWriter(".\TestNorm1.txt")

        ' Define three versions of the same word. 
        Dim s1 As String = "sống"        ' create word with U+1ED1
        Dim s2 As String = "s" + ChrW(&HF4) + ChrW(&H301) + "ng"
        Dim s3 As String = "so" + ChrW(&H302) + ChrW(&H301) + "ng"

        TestForEquality(s1, s2, s3)
        sw.WriteLine()

        ' Normalize and compare strings using each normalization form.
        For Each formName In [Enum].GetNames(GetType(NormalizationForm))
            sw.WriteLine("Normalization {0}:", formName)
            Dim nf As NormalizationForm = CType([Enum].Parse(GetType(NormalizationForm), formName),
                                             NormalizationForm)
            Dim sn() As String = NormalizeStrings(nf, s1, s2, s3)
            TestForEquality(sn)
            sw.WriteLine(vbCrLf)
        Next

        sw.Close()
    End Sub

    Private Sub TestForEquality(ParamArray words As String())
        For ctr As Integer = 0 To words.Length - 2
            For ctr2 As Integer = ctr + 1 To words.Length - 1
                sw.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                         words(ctr), ShowBytes(words(ctr)),
                         words(ctr2), ShowBytes(words(ctr2)),
                         words(ctr).Equals(words(ctr2), StringComparison.Ordinal))
            Next
        Next
    End Sub

    Private Function ShowBytes(str As String) As String
        Dim result As String = Nothing
        For Each ch In str
            result += String.Format("{0} ", Convert.ToUInt16(ch).ToString("X4"))
        Next
        Return result.Trim()
    End Function

    Private Function NormalizeStrings(nf As NormalizationForm, ParamArray words() As String) As String()
        For ctr As Integer = 0 To words.Length - 1
            If Not words(ctr).IsNormalized(nf) Then
                words(ctr) = words(ctr).Normalize(nf)
            End If
        Next
        Return words
    End Function
End Module
' The example displays the following output:
'       sống (0073 1ED1 006E 0067) = sống (0073 00F4 0301 006E 0067): False
'       sống (0073 1ED1 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False
'       sống (0073 00F4 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False
'       
'       Normalization FormC:
'       
'       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
'       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
'       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
'       
'       
'       Normalization FormD:
'       
'       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
'       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
'       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
'       
'       
'       Normalization FormKC:
'       
'       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
'       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
'       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
'       
'       
'       Normalization FormKD:
'       
'       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
'       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
'       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
' </Snippet14>

