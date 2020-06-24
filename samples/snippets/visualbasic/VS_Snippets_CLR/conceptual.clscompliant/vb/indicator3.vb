' Visual Basic .NET Document
Option Strict On

' <Snippet35>
Imports System.Text

<Assembly: CLSCompliant(True)>

Public Class CharacterUtilities
    <CLSCompliant(False)> Public Shared Function ToUTF16(s As String) As UShort
        s = s.Normalize(NormalizationForm.FormC)
        Return Convert.ToUInt16(s(0))
    End Function

    <CLSCompliant(False)> Public Shared Function ToUTF16(ch As Char) As UShort
        Return Convert.ToUInt16(ch)
    End Function

    ' CLS-compliant alternative for ToUTF16(String).
    Public Shared Function ToUTF16CodeUnit(s As String) As Integer
        s = s.Normalize(NormalizationForm.FormC)
        Return CInt(Convert.ToInt16(s(0)))
    End Function

    ' CLS-compliant alternative for ToUTF16(Char).
    Public Shared Function ToUTF16CodeUnit(ch As Char) As Integer
        Return Convert.ToInt32(ch)
    End Function

    Public Function HasMultipleRepresentations(s As String) As Boolean
        Dim s1 As String = s.Normalize(NormalizationForm.FormC)
        Return s.Equals(s1)
    End Function

    Public Function GetUnicodeCodePoint(ch As Char) As Integer
        If Char.IsSurrogate(ch) Then
            Throw New ArgumentException("ch cannot be a high or low surrogate.")
        End If
        Return Char.ConvertToUtf32(ch.ToString(), 0)
    End Function

    Public Function GetUnicodeCodePoint(chars() As Char) As Integer
        If chars.Length > 2 Then
            Throw New ArgumentException("The array has too many characters.")
        End If
        If chars.Length = 2 Then
            If Not Char.IsSurrogatePair(chars(0), chars(1)) Then
                Throw New ArgumentException("The array must contain a low and a high surrogate.")
            Else
                Return Char.ConvertToUtf32(chars(0), chars(1))
            End If
        Else
            Return Char.ConvertToUtf32(chars.ToString(), 0)
        End If
    End Function
End Class
' </Snippet35>
