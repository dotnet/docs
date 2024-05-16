Imports System.IO
Imports System.Text.RegularExpressions

Public Class WordCount
    Private filename As String
    Private nWords As Integer
    Private pattern As String = "\b\w+\b"

    Public Sub New(filename As String)
        If Not File.Exists(filename) Then
            Throw New FileNotFoundException("The file does not exist.")
        End If

        Me.filename = filename
        Dim txt As String = String.Empty
        Using sr As New StreamReader(filename)
            txt = sr.ReadToEnd()
        End Using
        nWords = Regex.Matches(txt, pattern).Count
    End Sub

    Public ReadOnly Property FullName As String
        Get
            Return filename
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return Path.GetFileName(filename)
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return nWords
        End Get
    End Property
End Class
