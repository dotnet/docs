 '<snippet1>

Option Explicit On
Option Strict On
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Class Form1
    Inherits Form

    Private textBox2 As TextBox
    Private listBox1 As ListBox
    Private WithEvents button1 As Button
    Private textBox1 As TextBox
    Private randomNumber As New Random()

    Public Sub New()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.listBox1 = New System.Windows.Forms.ListBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.textBox1.Location = New System.Drawing.Point(169, 26)
        Me.textBox1.Size = New System.Drawing.Size(100, 20)
        Me.textBox1.Text = "Bracket"
        Me.textBox2.Location = New System.Drawing.Point(169, 57)
        Me.textBox2.ReadOnly = True
        Me.textBox2.Size = New System.Drawing.Size(100, 20)
        Me.textBox2.Text = "4343"
        Me.listBox1.FormattingEnabled = True
        Me.listBox1.Location = New System.Drawing.Point(12, 12)
        Me.listBox1.Size = New System.Drawing.Size(120, 95)
        Me.button1.Location = New System.Drawing.Point(180, 83)
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.Text = "Add New Item"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.listBox1)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox1)
        Me.Text = "Parts Form"
        AddHandler Me.Load, AddressOf Form1_Load

    End Sub 'New

    Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        InitializeListOfParts()
        listBox1.DataSource = listOfParts
        listBox1.DisplayMember = "PartName"
    End Sub

    '<snippet2>
    ' Declare a new BindingListOfT with the Part business object.
    Private WithEvents listOfParts As BindingList(Of Part)

    Private Sub InitializeListOfParts()

        ' Create the new BindingList of Part type.
        listOfParts = New BindingList(Of Part)

        ' Allow new parts to be added, but not removed once committed.        
        listOfParts.AllowNew = True
        listOfParts.AllowRemove = False

        ' Raise ListChanged events when new parts are added.
        listOfParts.RaiseListChangedEvents = True

        ' Do not allow parts to be edited.
        listOfParts.AllowEdit = False

        ' Add a couple of parts to the list.
        listOfParts.Add(New Part("Widget", 1234))
        listOfParts.Add(New Part("Gadget", 5647))

    End Sub
    '</snippet2>

    '<snippet3>
    ' Create a new part from the text in the two text boxes.
    Private Sub listOfParts_AddingNew(ByVal sender As Object, _
        ByVal e As AddingNewEventArgs) Handles listOfParts.AddingNew
        e.NewObject = New Part(textBox1.Text, Integer.Parse(textBox2.Text))

    End Sub

    '</snippet3>

    '<snippet4>
    ' Add the new part unless the part number contains
    ' spaces. In that case cancel the add.
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles button1.Click

        Dim newPart As Part = listOfParts.AddNew()

        If newPart.PartName.Contains(" ") Then
            MessageBox.Show("Part names cannot contain spaces.")
            listOfParts.CancelNew(listOfParts.IndexOf(newPart))
        Else
            textBox2.Text = randomNumber.Next(9999).ToString()
            textBox1.Text = "Enter part name"
        End If

    End Sub
    '</snippet4>

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class

' A simple business object for example purposes.
Public Class Part
    Private name As String
    Private number As Integer

    Public Sub New()
    End Sub

    Public Sub New(ByVal nameForPart As String, _
        ByVal numberForPart As Integer)
        PartName = nameForPart
        PartNumber = numberForPart

    End Sub


    Public Property PartName() As String
        Get
            Return name
        End Get
        Set(ByVal value As String)
            name = Value
        End Set
    End Property

    Public Property PartNumber() As Integer
        Get
            Return number
        End Get
        Set(ByVal value As Integer)
            number = Value
        End Set
    End Property
End Class
'</snippet1>