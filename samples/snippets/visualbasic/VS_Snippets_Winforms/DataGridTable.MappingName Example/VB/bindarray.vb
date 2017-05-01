Imports System
Imports System.Windows.Forms
Imports System.Collections


Public Class Form1
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(40, 32)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(216, 200)
        Me.DataGrid1.TabIndex = 0
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindToArray()
    End Sub

    '<snippet1>
    Sub BindToArray()
        ' Creates an array of Widget objects (defined below).
        Dim Widgets(2) As Widget
        Dim tempWidget As Widget

        tempWidget = New Widget()
        tempWidget.Model = "AAA"
        tempWidget.Id = "A100"
        tempWidget.Price = Convert.ToDecimal(3.8)
        Widgets(0) = tempWidget

        ' The first Widget includes an array of Part objects.
        Dim p1 As New Part()
        p1.PartId = "PartX"
        Dim p2 As New Part()
        p2.PartId = "PartY"

        ' Note that the Widgets.Parts property returns an ArrayList.
        ' Add the parts to the ArrayList using the AddRange method.
        tempWidget.Parts.AddRange(New Part() {p1, p2})

        tempWidget = New Widget()
        tempWidget.Model = "BBB"
        tempWidget.Id = "B100"
        tempWidget.Price = Convert.ToDecimal(1.52)
        Widgets(1) = tempWidget

        tempWidget = New Widget()
        tempWidget.Id = "CCC"
        tempWidget.Model = "B100"
        tempWidget.Price = Convert.ToDecimal(2.14)
        Widgets(2) = tempWidget

        DataGrid1.SetDataBinding(Widgets, "")
        CreateTableStyle()
    End Sub


    Private Sub CreateTableStyle()
        ' Creates two DataGridTableStyle objects, one for the Widget
        ' array, and one for the Parts ArrayList.
        Dim widgetTable As New DataGridTableStyle()
        ' Sets the MappingName to the class name plus brackets.    
        widgetTable.MappingName = "Widget[]"

        ' Sets the AlternatingBackColor so you can see the difference.
        widgetTable.AlternatingBackColor = System.Drawing.Color.LightBlue

        ' Creates three column styles.
        Dim modelColumn As New DataGridTextBoxColumn()
        modelColumn.MappingName = "Model"
        modelColumn.HeaderText = "Model"

        Dim IdColumn As New DataGridTextBoxColumn()
        IdColumn.MappingName = "Id"
        IdColumn.HeaderText = "Id"

        Dim priceColumn As New DataGridTextBoxColumn()
        priceColumn.MappingName = "Price"
        priceColumn.HeaderText = "Price"
        priceColumn.Format = "c"

        ' Adds the column styles to the grid table style.
        widgetTable.GridColumnStyles.Add(modelColumn)
        widgetTable.GridColumnStyles.Add(IdColumn)
        widgetTable.GridColumnStyles.Add(priceColumn)

        ' Add the table style to the collection, but clear the 
        ' collection first.
        DataGrid1.TableStyles.Clear()
        DataGrid1.TableStyles.Add(widgetTable)

        ' Create another table style, one for the related data.
        Dim partsTable As New DataGridTableStyle()
        ' Set the MappingName to an ArrayList. Note that you need not 
        ' include brackets.
        partsTable.MappingName = "ArrayList"
        Dim partIdColumn As New DataGridTextBoxColumn()
        partIdColumn.MappingName = "PartID"
        partIdColumn.HeaderText = "Part ID"
        partsTable.GridColumnStyles.Add(partIdColumn)

        DataGrid1.TableStyles.Add(partsTable)
    End Sub


    Public Class Widget
        Private myModel As String
        Private myId As String
        Private myPrice As Decimal

        ' Use an ArrayList to create a related collection.
        Private myParts As New ArrayList()

        Public Property Model() As String
            Get
                Return myModel
            End Get
            Set(ByVal Value As String)
                myModel = Value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return myId
            End Get
            Set(ByVal Value As String)
                myId = Value
            End Set
        End Property

        Public Property Parts() As ArrayList
            Get
                Return myParts
            End Get
            Set(ByVal Value As ArrayList)
                myParts = Value
            End Set
        End Property

        Public Property Price() As Decimal
            Get
                Return myPrice
            End Get
            Set(ByVal Value As Decimal)
                myPrice = Value
            End Set
        End Property
    End Class


    Public Class Part
        Private myPartId As String


        Public Property PartId() As String
            Get
                Return myPartId
            End Get
            Set(ByVal Value As String)
                myPartId = Value
            End Set
        End Property
    End Class
    '</snippet1>
End Class



