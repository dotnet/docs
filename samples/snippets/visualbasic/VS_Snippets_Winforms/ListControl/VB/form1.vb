' <Snippet1>
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections

Public Class ListBoxSample3
    Inherits Form

    Private ListBox1 As New ListBox()
    Private label1 As New Label()
    Private textBox1 As New TextBox()

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New ListBoxSample3())
    End Sub 'Main

    Public Sub New()
        Me.ClientSize = New Size(307, 206)
        Me.Text = "ListBox Sample3"

        ListBox1.Location = New Point(54, 16)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(240, 130)

        label1.Location = New Point(14, 150)
        label1.Name = "label1"
        label1.Size = New Size(40, 24)
        label1.Text = "Value"

        textBox1.Location = New Point(54, 150)
        textBox1.Name = "textBox1"
        textBox1.Size = New Size(240, 24)

        Me.Controls.AddRange(New Control() {ListBox1, label1, textBox1})

        ' <Snippet2>
        ' Populate the list box using an array as DataSource. 
        Dim USStates As New ArrayList()
        USStates.Add(New USState("Alabama", "AL"))
        USStates.Add(New USState("Washington", "WA"))
        USStates.Add(New USState("West Virginia", "WV"))
        USStates.Add(New USState("Wisconsin", "WI"))
        USStates.Add(New USState("Wyoming", "WY"))
        ListBox1.DataSource = USStates

        ' Set the long name as the property to be displayed and the short
        ' name as the value to be returned when a row is selected.  Here
        ' these are properties; if we were binding to a database table or
        ' query these could be column names.
        ListBox1.DisplayMember = "LongName"
        ListBox1.ValueMember = "ShortName"
        ' </Snippet2>

        ' Bind the SelectedValueChanged event to our handler for it.
        AddHandler ListBox1.SelectedValueChanged, AddressOf ListBox1_SelectedValueChanged

        ' Ensure the form opens with no rows selected.
        ListBox1.ClearSelected()
    End Sub 'New

    Private Sub InitializeComponent()
    End Sub 'InitializeComponent

    ' <Snippet3>
    Private Sub ListBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ListBox1.SelectedIndex <> -1 Then
            textBox1.Text = ListBox1.SelectedValue.ToString()
            ' If we also wanted to get the displayed text we could use
            ' the SelectedItem item property:
            ' Dim s = CType(ListBox1.SelectedItem, USState).LongName
        End If
    End Sub 'ListBox1_SelectedValueChanged
End Class 'ListBoxSample3
' </Snippet3>

Public Class USState
    Private myShortName As String
    Private myLongName As String

    Public Sub New(ByVal strLongName As String, ByVal strShortName As String)
        Me.myShortName = strShortName
        Me.myLongName = strLongName
    End Sub 'New

    Public ReadOnly Property ShortName() As String
        Get
            Return myShortName
        End Get
    End Property

    Public ReadOnly Property LongName() As String
        Get
            Return myLongName
        End Get
    End Property

End Class 'USState
' </Snippet1>
