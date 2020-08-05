' Visual Basic .NET Document
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing
' <Snippet3>
Imports System.Text.RegularExpressions

Public Module RegexLib
    Public Function IsValidCurrency(currencyValue As String) As Boolean
        Dim pattern As String = "\p{Sc}+\s*\d+"
        Dim currencyRegex As New Regex(pattern)
        Return currencyRegex.IsMatch(currencyValue)
    End Function
End Module
' </Snippet3>


Public Class CurrencyForm : Inherits Form
    Dim WithEvents OKButton As Button
    Dim WithEvents sourceCurrency As TextBox
    Dim status As Label

    Public Sub New()
        sourceCurrency = New TextBox()
        With sourceCurrency
            .Location = New Point(25, 50)
            .Size = New Size(100, 25)
            .Text = String.Empty
        End With
        Me.Controls.Add(sourceCurrency)

        OKButton = New Button()
        With OKButton
            .Location = New Point(100, 150)
            .Size = New Size(75, 25)
            .Text = "OK"
        End With
        Me.Controls.Add(OKButton)
        Me.AcceptButton = OKButton

        status = New Label()
        With status
            .Location = New Point(0, Me.Height - 55)
            .Size = New Size(Me.Width, 25)
            .BorderStyle = BorderStyle.Fixed3D
            .Anchor = AnchorStyles.Bottom
        End With
        Me.Controls.Add(status)
    End Sub

    Public Shared Sub Main()
        Dim frm As New CurrencyForm()
        Application.Run(frm)
    End Sub

    Private Sub PerformConversion()
    End Sub

    Public Sub sourceCurrency_TextChanged(sender As Object, e As EventArgs) _
               Handles sourceCurrency.TextChanged
        status.Text = ""
    End Sub

    ' <Snippet2>         
    Public Sub OKButton_Click(sender As Object, e As EventArgs) _
               Handles OKButton.Click

        If Not String.IsNullOrEmpty(sourceCurrency.Text) Then
            If RegexLib.IsValidCurrency(sourceCurrency.Text) Then
                PerformConversion()
            Else
                status.Text = "The source currency value is invalid."
            End If
        End If
    End Sub
    ' </Snippet2>
End Class

