 '<snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data

Public Class MainForm
    Inherits Form

    Public Sub New()
    End Sub

    Private WithEvents bindingSource1 As BindingSource
    Private WithEvents button1 As Button

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        InitializeData()
    End Sub


    Private Sub InitializeData()
        bindingSource1 = New System.Windows.Forms.BindingSource()
        Dim dataset1 As New DataSet()
        ClientSize = New System.Drawing.Size(292, 266)

        ' Some xml data to populate the DataSet with.
        ' Some xml data to populate the DataSet with.
        Dim musicXml As String = "<?xml version='1.0' encoding='UTF-8'?>" & _
            "<music><recording><artist>Dave Matthews</artist>" & _
            "<cd>Under the Table and Dreaming</cd>" & _
            "<releaseDate>1994</releaseDate><rating>3.5</rating></recording>" & _
            "<recording><artist>Coldplay</artist><cd>X&amp;Y</cd>" & _
            "<releaseDate>2005</releaseDate><rating>4</rating></recording>" & _
            "<recording><artist>Dave Matthews</artist>" & _
            "<cd>Live at Red Rocks</cd>" & _
            "<releaseDate>1997</releaseDate><rating>4</rating></recording>" & _
            "<recording><artist>U2</artist>" & _
            "<cd>Joshua Tree</cd><releaseDate>1987</releaseDate>" & _
            "<rating>5</rating></recording>" & _
            "<recording><artist>U2</artist>" & _
            "<cd>How to Dismantle an Atomic Bomb</cd>" & _
            "<releaseDate>2004</releaseDate><rating>4.5</rating></recording>" & _
            "<recording><artist>Natalie Merchant</artist>" & _
            "<cd>Tigerlily</cd><releaseDate>1995</releaseDate>" & _
            "<rating>3.5</rating></recording>" & _
            "</music>"

        ' Read the xml.
        Dim reader As New System.IO.StringReader(musicXml)
        dataset1.ReadXml(reader)

        ' Get a DataView of the table contained in the dataset.
        Dim tables As DataTableCollection = dataset1.Tables
        Dim view1 As New DataView(tables(0))

        ' Create a DataGridView control and add it to the form.
        Dim datagridview1 As New DataGridView()
        datagridview1.ReadOnly = True
        datagridview1.AutoGenerateColumns = True
        datagridview1.Width = 300
        Me.Controls.Add(datagridview1)
        bindingSource1.DataSource = view1
        datagridview1.DataSource = bindingSource1
        datagridview1.Columns.Remove("artist")
        datagridview1.Columns.Remove("releaseDate")

        ' Create and add a button to the form. 
        button1 = New Button()
        button1.AutoSize = True
        button1.Text = "Show/Edit Details"
        Me.Controls.Add(button1)
        button1.Location = New Point(50, 200)

    End Sub

    ' Handle the BindingComplete event to ensure the two forms
    ' remain synchronized.
    Private Sub bindingSource1_BindingComplete(ByVal sender As Object, _
        ByVal e As BindingCompleteEventArgs) Handles bindingSource1.BindingComplete
        If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate _
            AndAlso e.Exception Is Nothing Then
            e.Binding.BindingManagerBase.EndCurrentEdit()
        End If

    End Sub

    ' The detailed form will be shown when the button is clicked.
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        Dim detailForm As New DetailForm(bindingSource1)
        detailForm.Show()
    End Sub


    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New MainForm())

    End Sub
End Class

' The detail form class. 
Public Class DetailForm
    Inherits Form
    Private formDataSource As BindingSource

    ' The constructor takes a BindingSource object.
    Public Sub New(ByVal dataSource As BindingSource)
        formDataSource = dataSource
        Me.ClientSize = New Size(240, 200)
        Dim textBox1 As New TextBox()
        Me.Text = "Selection Details"
        textBox1.Width = 220
        Dim textBox2 As New TextBox()
        Dim textBox3 As New TextBox()
        Dim textBox4 As New TextBox()
        textBox4.Width = 30
        textBox3.Width = 50

        ' Associate each text box with a column from the data source.
        textBox1.DataBindings.Add("Text", formDataSource, "cd", _
            True, DataSourceUpdateMode.OnPropertyChanged)

        textBox2.DataBindings.Add("Text", formDataSource, "artist", True)
        textBox3.DataBindings.Add("Text", formDataSource, "releaseDate", True)
        textBox4.DataBindings.Add("Text", formDataSource, "rating", True)
        textBox1.Location = New Point(10, 10)
        textBox2.Location = New Point(10, 40)
        textBox3.Location = New Point(10, 80)
        textBox4.Location = New Point(10, 120)
        Me.Controls.AddRange(New Control() {textBox1, textBox2, textBox3, _
            textBox4})

    End Sub
End Class
'</snippet1>