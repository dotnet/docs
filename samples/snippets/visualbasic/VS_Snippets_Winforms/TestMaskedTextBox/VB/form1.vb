Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class Form1
    Dim WithEvents B As Binding

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.MaskedTextBox1.Mask = "00/00/0000"
        'Me.MaskedTextBox1.InputText = "12312003"
        Me.MaskedTextBox1.Text = "12312003"
    End Sub

    Private Sub DoMaskedBinding()
        Dim sc As SqlConnection
        Dim OrdersTable As New DataSet()

        Try
            sc = New SqlConnection("Data Source=localhost;Initial Catalog=NORTHWIND;Integrated Security=SSPI")
            sc.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try

        Dim DataConnect As New SqlDataAdapter("SELECT * FROM ORDERS", sc)
        DataConnect.Fill(OrdersTable, "Orders")

        ' Now bind MaskedTextBox to appropriate field. Note that we must create the Binding objects
        ' before adding them to the control - otherwise, we won't get a Format event on the 
        ' initial load. 
        Try
            B = New Binding("Text", OrdersTable, "Orders.OrderDate")
            MaskedTextBox1.DataBindings.Add(B)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Application.Exit()
        End Try
    End Sub

    Private Sub B_Format(ByVal sender As Object, ByVal e As ConvertEventArgs) Handles B.Format
        Dim CurrentDate As Date

        ' Get the value.
        Try
            CurrentDate = CDate(e.Value)
        Catch ex As Exception
            ' Error message.
            Exit Sub
        End Try

        ' Format to a value that the mask will accept. 
        e.Value = CurrentDate.ToString("MMddyyyy")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoMaskedBinding()
    End Sub

    '<SNIPPET1>
    Private Sub InitializeMask()
        SetMaskCulture(MaskedTextBox1, "ja-JP")
    End Sub

    Private Sub SetMaskCulture(ByVal MaskControl As MaskedTextBox, ByVal Culture As String)
        If (MaskControl Is Nothing) Then
            Throw New ArgumentException("The MaskControl parameter to SetMaskCulture must be non-null.")
        End If

        MaskControl.FormatProvider = New CultureInfo(Culture)
    End Sub
    '</SNIPPET1>

    '<SNIPPET2>
    Private Sub WriteMaskOutput()
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.Text = "12/21"

        Debug.WriteLine("MaskedTextBox Value, IncludePrompt=True: " & Me.MaskedTextBox1.Text) ' Displays: 12/21/____
        Me.MaskedTextBox1.TextMaskFormat = Not MaskFormat.IncludePrompt
        Debug.WriteLine("MaskedTextBox Value, IncludePrompt=False: " & Me.MaskedTextBox1.Text) ' Displays: 12/21
    End Sub
    '</SNIPPET2>

    '<SNIPPET3>
    Private Sub DisplayText()
        Me.MaskedTextBox1.PasswordChar = CChar("*")

        Me.MaskedTextBox1.Mask = "000-00-0000" ' United States Social Security Number
        Me.MaskedTextBox1.Text = "999999999"

        Debug.WriteLine("MaskedControl.Text: " & Me.MaskedTextBox1.Text) ' Displays: 999-99-9
        Me.MaskedTextBox1.Text = ""

        ' Assigning text.
        Me.MaskedTextBox1.AllowPromptAsInput = True
        Me.MaskedTextBox1.Text = "999-99-9999" ' Works
        Me.MaskedTextBox1.Text = "999999999" ' Works
        Me.MaskedTextBox1.AllowPromptAsInput = False
        'Me.MaskedTextBox1.Text = "999-99-9999" ' Does not work
    End Sub
    '</SNIPPET3>

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DisplayText()
    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As Object, ByVal e As MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected
        MessageBox.Show("Failed assignment")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub
End Class
