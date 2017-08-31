<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
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
Me.NorthwindDataSet1 = New VB.NorthwindDataSet
Me.CustomersTableAdapter1 = New VB.NorthwindDataSetTableAdapters.CustomersTableAdapter
Me.Order_DetailsTableAdapter1 = New VB.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter
Me.OrdersTableAdapter1 = New VB.NorthwindDataSetTableAdapters.OrdersTableAdapter
Me.RegionTableAdapter1 = New VB.NorthwindDataSetTableAdapters.RegionTableAdapter
Me.DataSet1 = New System.Data.DataSet
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'NorthwindDataSet1
'
Me.NorthwindDataSet1.DataSetName = "NorthwindDataSet"
'
'CustomersTableAdapter1
'
Me.CustomersTableAdapter1.ClearBeforeFill = True
'
'Order_DetailsTableAdapter1
'
Me.Order_DetailsTableAdapter1.ClearBeforeFill = True
'
'OrdersTableAdapter1
'
Me.OrdersTableAdapter1.ClearBeforeFill = True
'
'RegionTableAdapter1
'
Me.RegionTableAdapter1.ClearBeforeFill = True
'
'DataSet1
'
Me.DataSet1.DataSetName = "NewDataSet"
'
'Form1
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(328, 266)
Me.Name = "Form1"
Me.Text = "Form1"
CType(Me.NorthwindDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents NorthwindDataSet1 As VB.NorthwindDataSet
    Friend WithEvents CustomersTableAdapter1 As VB.NorthwindDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents Order_DetailsTableAdapter1 As VB.NorthwindDataSetTableAdapters.Order_DetailsTableAdapter
    Friend WithEvents OrdersTableAdapter1 As VB.NorthwindDataSetTableAdapters.OrdersTableAdapter
    Friend WithEvents RegionTableAdapter1 As VB.NorthwindDataSetTableAdapters.RegionTableAdapter
    Friend WithEvents DataSet1 As System.Data.DataSet

End Class
