<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form5
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
Me.NorthwindDataSet = New VB.NorthwindDataSet
Me.RegionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.RegionTableAdapter = New VB.NorthwindDataSetTableAdapters.RegionTableAdapter
Me.RegionBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
Me.RegionBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
Me.RegionDataGridView = New System.Windows.Forms.DataGridView
Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
CType(Me.NorthwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.RegionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.RegionBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
Me.RegionBindingNavigator.SuspendLayout()
CType(Me.RegionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'NorthwindDataSet
'
Me.NorthwindDataSet.DataSetName = "NorthwindDataSet"
'
'RegionBindingSource
'
Me.RegionBindingSource.DataMember = "Region"
Me.RegionBindingSource.DataSource = Me.NorthwindDataSet
'
'RegionTableAdapter
'
Me.RegionTableAdapter.ClearBeforeFill = True
'
'RegionBindingNavigator
'
Me.RegionBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
Me.RegionBindingNavigator.BindingSource = Me.RegionBindingSource
Me.RegionBindingNavigator.CountItem = Me.BindingNavigatorCountItem
Me.RegionBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
Me.RegionBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.RegionBindingNavigatorSaveItem})
Me.RegionBindingNavigator.Location = New System.Drawing.Point(0, 0)
Me.RegionBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
Me.RegionBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
Me.RegionBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
Me.RegionBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
Me.RegionBindingNavigator.Name = "RegionBindingNavigator"
Me.RegionBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
Me.RegionBindingNavigator.Size = New System.Drawing.Size(372, 25)
Me.RegionBindingNavigator.TabIndex = 0
Me.RegionBindingNavigator.Text = "BindingNavigator1"
'
'BindingNavigatorMoveFirstItem
'
Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorMoveFirstItem.Text = "Move first"
'
'BindingNavigatorMovePreviousItem
'
Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
'
'BindingNavigatorSeparator
'
Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
'
'BindingNavigatorPositionItem
'
Me.BindingNavigatorPositionItem.AccessibleName = "Position"
Me.BindingNavigatorPositionItem.AutoSize = False
Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
Me.BindingNavigatorPositionItem.Text = "0"
Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
'
'BindingNavigatorCountItem
'
Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 13)
Me.BindingNavigatorCountItem.Text = "of {0}"
Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
'
'BindingNavigatorSeparator1
'
Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
'
'BindingNavigatorMoveNextItem
'
Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
Me.BindingNavigatorMoveNextItem.Text = "Move next"
'
'BindingNavigatorMoveLastItem
'
Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
Me.BindingNavigatorMoveLastItem.Text = "Move last"
'
'BindingNavigatorSeparator2
'
Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
'
'BindingNavigatorAddNewItem
'
Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
Me.BindingNavigatorAddNewItem.Text = "Add new"
'
'BindingNavigatorDeleteItem
'
Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
Me.BindingNavigatorDeleteItem.Text = "Delete"
'
'RegionBindingNavigatorSaveItem
'
Me.RegionBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
Me.RegionBindingNavigatorSaveItem.Image = CType(resources.GetObject("RegionBindingNavigatorSaveItem.Image"), System.Drawing.Image)
Me.RegionBindingNavigatorSaveItem.Name = "RegionBindingNavigatorSaveItem"
Me.RegionBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
Me.RegionBindingNavigatorSaveItem.Text = "Save Data"
'
'RegionDataGridView
'
Me.RegionDataGridView.AutoGenerateColumns = False
Me.RegionDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
Me.RegionDataGridView.DataSource = Me.RegionBindingSource
Me.RegionDataGridView.ImeMode = System.Windows.Forms.ImeMode.Disable
Me.RegionDataGridView.Location = New System.Drawing.Point(12, 38)
Me.RegionDataGridView.Name = "RegionDataGridView"
Me.RegionDataGridView.Size = New System.Drawing.Size(300, 220)
Me.RegionDataGridView.TabIndex = 1
'
'DataGridViewTextBoxColumn1
'
Me.DataGridViewTextBoxColumn1.DataPropertyName = "RegionID"
Me.DataGridViewTextBoxColumn1.HeaderText = "RegionID"
Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
'
'DataGridViewTextBoxColumn2
'
Me.DataGridViewTextBoxColumn2.DataPropertyName = "RegionDescription"
Me.DataGridViewTextBoxColumn2.HeaderText = "RegionDescription"
Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
'
'Form5
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(372, 287)
Me.Controls.Add(Me.RegionDataGridView)
Me.Controls.Add(Me.RegionBindingNavigator)
Me.Name = "Form5"
Me.Text = "Form5"
CType(Me.NorthwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.RegionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.RegionBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
Me.RegionBindingNavigator.ResumeLayout(False)
Me.RegionBindingNavigator.PerformLayout()
CType(Me.RegionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents NorthwindDataSet As VB.NorthwindDataSet
    Friend WithEvents RegionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RegionTableAdapter As VB.NorthwindDataSetTableAdapters.RegionTableAdapter
    Friend WithEvents RegionBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RegionBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents RegionDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
