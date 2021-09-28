Imports System.IO
Imports System.Text.RegularExpressions

Public Class WordCountCleanup
    Private filename As String
    Private nWords As Integer
    Private pattern As String = "\b\w+\b"

    Public Sub New(filename As String)
        If Not File.Exists(filename) Then
            Throw New FileNotFoundException("The file does not exist.")
        End If

        Me.filename = filename
        Dim txt As String = String.Empty
        Dim sr As StreamReader = Nothing
        Try
            sr = New StreamReader(filename)
            txt = sr.ReadToEnd()
        Finally
            If sr IsNot Nothing Then sr.Dispose()
        End Try
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
