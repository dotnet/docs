'<snippet0>
'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
'</snippet1>
'<snippet2>
Public Class Form1
    Inherits Form

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub

    Public Sub New()

    End Sub

    Private textBox1 As TextBox
    Private WithEvents button1 As Button
    Private listBox1 As ListBox
    Private components As IContainer
    Private binding1 As BindingSource

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        listBox1 = New ListBox()
        textBox1 = New TextBox()
        binding1 = New BindingSource()
        button1 = New Button()
        listBox1.Location = New Point(140, 25)
        listBox1.Size = New Size(123, 160)
        textBox1.Location = New Point(23, 70)
        textBox1.Size = New Size(100, 20)
        textBox1.Text = "Wingdings"
        button1.Location = New Point(23, 25)
        button1.Size = New Size(75, 23)
        button1.Text = "Search"
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.listBox1)

        Dim fonts As New MyFontList()
        Dim i As Integer
        For i = 0 To FontFamily.Families.Length - 1
            If FontFamily.Families(i).IsStyleAvailable(FontStyle.Regular) Then
                fonts.Add(New Font(FontFamily.Families(i), 11.0F, FontStyle.Regular))
            End If
        Next i
        binding1.DataSource = fonts
        listBox1.DataSource = binding1
        listBox1.DisplayMember = "Name"

    End Sub
    '<snippet4>
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        If binding1.SupportsSearching <> True Then
            MessageBox.Show("Cannot search the list.")
        Else
            Dim foundIndex As Integer = binding1.Find("Name", textBox1.Text)
            If foundIndex > -1 Then
                listBox1.SelectedIndex = foundIndex
            Else
                MessageBox.Show("Font was not found.")
            End If
        End If

    End Sub
End Class
'</snippet4>
'</snippet2>

'<snippet3>
Public Class MyFontList
    Inherits BindingList(Of Font)

    Protected Overrides ReadOnly Property SupportsSearchingCore() As Boolean
        Get
            Return True
        End Get
    End Property
    
    Protected Overrides Function FindCore(ByVal prop As PropertyDescriptor, _
        ByVal key As Object) As Integer
        ' Ignore the prop value and search by family name.
        Dim i As Integer
        While i < Count
            If Items(i).FontFamily.Name.ToLower() = CStr(key).ToLower() Then
                Return i
            End If
            i += 1
        End While

        Return -1
    End Function
End Class
'</snippet3>
'</snippet0>