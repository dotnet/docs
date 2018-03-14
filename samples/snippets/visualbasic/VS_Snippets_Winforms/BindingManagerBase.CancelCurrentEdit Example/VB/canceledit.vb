Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Public NotInheritable Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Private myDataView As DataView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(24, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(216, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetBinding()
        CancelEdit()
        EndEdit()
    End Sub
    ' <snippet1>
    Private Sub CancelEdit()
        ' Gets the CurrencyManager which is returned when the 
        ' data source is a DataView.
        Dim myMgr As BindingManagerBase = _
        CType(BindingContext(myDataView), CurrencyManager)

        ' Gets the current row and changes a value. Then cancels the 
        ' edit and thereby discards the changes.
        Dim tempRowView As DataRowView = _
        CType(myMgr.Current, DataRowView)
        Console.WriteLine("Original: {0}", tempRowView("myCol"))
        tempRowView("myCol") = "These changes will be discarded"
        Console.WriteLine("Edit: {0}", tempRowView("myCol"))
        myMgr.CancelCurrentEdit()
        Console.WriteLine("After CanceCurrentlEdit: {0}", _
        tempRowView("myCol"))
    End Sub

    Private Sub EndEdit()
        ' Gets the CurrencyManager which is returned when the 
        ' data source is a DataView.
        Dim myMgr As BindingManagerBase = _
        CType(BindingContext(myDataView), CurrencyManager)

        ' Gets the current row and changes a value. Then ends the 
        ' edit and thereby keeps the changes.
        Dim tempRowView As DataRowView = _
        CType(myMgr.Current, DataRowView)
        Console.WriteLine("Original: {0}", tempRowView("myCol"))
        tempRowView("myCol") = "These changes will be kept"
        Console.WriteLine("Edit: {0}", tempRowView("myCol"))
        myMgr.EndCurrentEdit()
        Console.WriteLine("After EndCurrentEdit: {0}", _
        tempRowView("myCol"))
    End Sub
    '</snippet1>

    Private Sub SetBinding()
        ' Creates a DataView to be used as a data source. Sets the 
        ' myDataView variable, defined in the form, to the DataView. 
        ' Then binds the TextBox control to the DataView.
        Dim myTable As DataTable = New DataTable("myTable")
        Dim myCol As DataColumn = New DataColumn("myCol")
        myTable.Columns.Add(myCol)
        Dim tempRow As DataRow

        tempRow = myTable.NewRow()
        tempRow("myCol") = "Original Data"
        myTable.Rows.Add(tempRow)

        myDataView = myTable.DefaultView
        TextBox1.DataBindings.Add( _
        New Binding("Text", myDataView, "myCol"))
    End Sub

End Class
