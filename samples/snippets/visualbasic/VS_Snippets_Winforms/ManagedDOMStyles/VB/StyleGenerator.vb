'<SNIPPET1>
Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class StyleGenerator
    Dim styleDB As Dictionary(Of String, String)

    Public Sub New()
        styleDB = New Dictionary(Of String, String)()
    End Sub


    Public Function ContainsStyle(ByVal name As String) As Boolean
        Return styleDB.ContainsKey(name)
    End Function


    Public Function SetStyle(ByVal name As String, ByVal value As String) As String
        Dim oldValue As String = ""

        If (Not name.Length > 0) Then
            Throw New ArgumentException("Parameter name cannot be zero-length.")
        End If
        If (Not value.Length > 0) Then
            Throw New ArgumentException("Parameter value cannot be zero-length.")
        End If

        If (styleDB.ContainsKey(name)) Then
            oldValue = styleDB(name)
        End If

        styleDB(name) = value

        Return oldValue
    End Function

    Public Function GetStyle(ByVal name As String) As String
        If (Not name.Length > 0) Then
            Throw New ArgumentException("Parameter name cannot be zero-length.")
        End If

        If (styleDB.ContainsKey(name)) Then
            Return styleDB(name)
        Else
            Return ""
        End If
    End Function

    Public Sub RemoveStyle(ByVal name As String)
        If (styleDB.ContainsKey(name)) Then
            styleDB.Remove(name)
        End If
    End Sub

    Public Function GetStyleString() As String
        If (styleDB.Count > 0) Then
            Dim styleString As New StringBuilder("")
            Dim key As String
            For Each key In styleDB.Keys
                styleString.Append(String.Format("{0}:{1};", CType(key, Object), CType(styleDB(key), Object)))
            Next key

            Return styleString.ToString()
        Else
            Return ""
        End If
    End Function

    Public Sub ParseStyleString(ByVal styles As String)
        If (styles.Length) > 0 Then
            Dim stylePairs As String() = styles.Split(New Char() {";"c})
            Dim stylePair As String
            For Each stylePair In stylePairs
                If (stylePairs.Length > 0) Then
                    Dim styleNameValue As String() = stylePair.Split(New Char() {":"c})
                    If (styleNameValue.Length = 2) Then
                        styleDB(styleNameValue(0)) = styleNameValue(1)
                    End If
                End If
            Next stylePair
        End If
    End Sub


    Public Sub Clear()
        styleDB.Clear()
    End Sub
End Class
'</SNIPPET1>

