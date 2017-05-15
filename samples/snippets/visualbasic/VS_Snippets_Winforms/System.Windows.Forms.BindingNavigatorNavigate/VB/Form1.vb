 '<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports System.Text



Class Form1
    Inherits Form
    Private components As IContainer
    Private bindingNavigator1 As BindingNavigator
    Private bindingNavigatorAddNewItem As ToolStripButton
    Private bindingNavigatorCountItem As ToolStripLabel
    Private bindingNavigatorDeleteItem As ToolStripButton
    Private bindingNavigatorMoveFirstItem As ToolStripButton
    Private bindingNavigatorMovePreviousItem As ToolStripButton
    Private bindingNavigatorSeparator As ToolStripSeparator
    Private bindingNavigatorPositionItem As ToolStripTextBox
    Private bindingNavigatorSeparator1 As ToolStripSeparator
    Private bindingNavigatorMoveNextItem As ToolStripButton
    Private bindingNavigatorMoveLastItem As ToolStripButton
    Private textBox1 As TextBox
    Private textBox2 As TextBox
    Private bindingSource1 As BindingSource
    Private bindingNavigatorSeparator2 As ToolStripSeparator
    
    
    Public Sub New() 
        InitializeComponent()
        LoadData()
        
        '<snippet3>
        bindingNavigator1.BindingSource = bindingSource1
        '</snippet3>
    
    End Sub 'New
    '<snippet2>
    Private Sub LoadData() 
        ' The xml to bind to.
        Dim xml As String = "<US><states>" + "<state><name>Washington</name><capital>Olympia</capital></state>" + "<state><name>Oregon</name><capital>Salem</capital></state>" + "<state><name>California</name><capital>Sacramento</capital></state>" + "<state><name>Nevada</name><capital>Carson City</capital></state>" + "</states></US>"
        
        ' Convert the xml string to bytes and load into a memory stream.
        Dim xmlBytes As Byte() = Encoding.UTF8.GetBytes(xml)
        Dim stream As New MemoryStream(xmlBytes, False)
        
        ' Create a DataSet and load the xml into it.
        Dim [set] As New DataSet()
        [set].ReadXml(stream)
        
        ' Set the DataSource to the DataSet, and the DataMember
        ' to state.
        bindingSource1.DataSource = [set]
        bindingSource1.DataMember = "state"
        
        textBox1.DataBindings.Add("Text", bindingSource1, "name")
        textBox2.DataBindings.Add("Text", bindingSource1, "capital")
    
    End Sub 'LoadData
     
    '</snippet2>
    <STAThread()>  _
    Public Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    Private Sub InitializeComponent() 
        Me.components = New System.ComponentModel.Container()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.bindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.bindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.bindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingNavigator1.SuspendLayout()
        CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        ' 
        ' bindingNavigator1
        ' 
        Me.bindingNavigator1.AddNewItem = Me.bindingNavigatorAddNewItem
        Me.bindingNavigator1.CountItem = Me.bindingNavigatorCountItem
        Me.bindingNavigator1.CountItemFormat = "of {0}"
        Me.bindingNavigator1.DeleteItem = Me.bindingNavigatorDeleteItem
        Me.bindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingNavigatorMoveFirstItem, Me.bindingNavigatorMovePreviousItem, Me.bindingNavigatorSeparator, Me.bindingNavigatorPositionItem, Me.bindingNavigatorCountItem, Me.bindingNavigatorSeparator1, Me.bindingNavigatorMoveNextItem, Me.bindingNavigatorMoveLastItem, Me.bindingNavigatorSeparator2, Me.bindingNavigatorAddNewItem, Me.bindingNavigatorDeleteItem})
        Me.bindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.bindingNavigator1.MoveFirstItem = Me.bindingNavigatorMoveFirstItem
        Me.bindingNavigator1.MoveLastItem = Me.bindingNavigatorMoveLastItem
        Me.bindingNavigator1.MoveNextItem = Me.bindingNavigatorMoveNextItem
        Me.bindingNavigator1.MovePreviousItem = Me.bindingNavigatorMovePreviousItem
        Me.bindingNavigator1.Name = "bindingNavigator1"
        Me.bindingNavigator1.PositionItem = Me.bindingNavigatorPositionItem
        Me.bindingNavigator1.TabIndex = 2
        Me.bindingNavigator1.Text = "bindingNavigator1"
        ' 
        ' bindingNavigatorAddNewItem
        ' 
        Me.bindingNavigatorAddNewItem.Image = CType(resources.GetObject("bindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem"
        Me.bindingNavigatorAddNewItem.Text = "Add new"
        ' 
        ' bindingNavigatorCountItem
        ' 
        Me.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem"
        Me.bindingNavigatorCountItem.Text = "of {0}"
        Me.bindingNavigatorCountItem.ToolTipText = "Total number of items"
        ' 
        ' bindingNavigatorDeleteItem
        ' 
        Me.bindingNavigatorDeleteItem.Image = CType(resources.GetObject("bindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem"
        Me.bindingNavigatorDeleteItem.Text = "Delete"
        ' 
        ' bindingNavigatorMoveFirstItem
        ' 
        Me.bindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem"
        Me.bindingNavigatorMoveFirstItem.Text = "Move first"
        ' 
        ' bindingNavigatorMovePreviousItem
        ' 
        Me.bindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem"
        Me.bindingNavigatorMovePreviousItem.Text = "Move previous"
        ' 
        ' bindingNavigatorSeparator
        ' 
        Me.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator"
        
        ' 
        ' bindingNavigatorPositionItem
        ' 
        Me.bindingNavigatorPositionItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        Me.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem"
        Me.bindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.bindingNavigatorPositionItem.Text = "0"
        Me.bindingNavigatorPositionItem.ToolTipText = "Current position"
        ' 
        ' bindingNavigatorSeparator1
        ' 
        Me.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1"
            ' 
        ' bindingNavigatorMoveNextItem
        ' 
        Me.bindingNavigatorMoveNextItem.Image = CType(resources.GetObject("bindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem"
        Me.bindingNavigatorMoveNextItem.Text = "Move next"
        ' 
        ' bindingNavigatorMoveLastItem
        ' 
        Me.bindingNavigatorMoveLastItem.Image = CType(resources.GetObject("bindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem"
        Me.bindingNavigatorMoveLastItem.Text = "Move last"
        ' 
        ' bindingNavigatorSeparator2
        ' 
        Me.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2"
      
        ' 
        ' textBox1
        ' 
        Me.textBox1.Location = New System.Drawing.Point(46, 64)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.TabIndex = 3
        ' 
        ' textBox2
        ' 
        Me.textBox2.Location = New System.Drawing.Point(46, 104)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.TabIndex = 4
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(textBox2)
        Me.Controls.Add(textBox1)
        Me.Controls.Add(bindingNavigator1)
        Me.Name = "Form1"
        CType(Me.bindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingNavigator1.ResumeLayout(False)
        Me.bindingNavigator1.PerformLayout()
        CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
    End Sub 'InitializeComponent
End Class 'Form1
'</snippet1>