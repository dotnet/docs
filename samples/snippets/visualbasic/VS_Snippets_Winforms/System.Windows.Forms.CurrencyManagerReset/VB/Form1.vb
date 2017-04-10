 '<snippet1>
Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Public Sub New() 
        InitializeControlsAndDataSource()
    
    End Sub
    
    ' Declare the controls to be used.
    Private WithEvents bindingSource1 As BindingSource
    Private dataGridView1 As DataGridView
    Private WithEvents button1 As Button
    Private dataGridView2 As DataGridView
    Private cachePositionCheckBox As CheckBox
    Public set1 As DataSet
    
    
    Private Sub InitializeControlsAndDataSource() 
        ' Initialize the controls and set location, size and 
        ' other basic properties.
        Me.dataGridView1 = New DataGridView()
        Me.bindingSource1 = New BindingSource()
        Me.button1 = New Button()
        Me.dataGridView2 = New DataGridView()
        Me.cachePositionCheckBox = New System.Windows.Forms.CheckBox()
        Me.dataGridView1.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Dock = DockStyle.Top
        Me.dataGridView1.Location = New Point(0, 20)
        Me.dataGridView1.Size = New Size(292, 170)
        Me.button1.Location = New System.Drawing.Point(18, 175)
        Me.button1.Size = New System.Drawing.Size(125, 23)
        
        button1.Text = "Clear Parent Field"

        Me.dataGridView2.ColumnHeadersHeightSizeMode = _
            System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView2.Location = New System.Drawing.Point(0, 225)
        Me.dataGridView2.Size = New System.Drawing.Size(309, 130)
        Me.cachePositionCheckBox.AutoSize = True
        Me.cachePositionCheckBox.Checked = True
        Me.cachePositionCheckBox.Location = New System.Drawing.Point(150, 175)
        Me.cachePositionCheckBox.Name = "radioButton1"
        Me.cachePositionCheckBox.Size = New System.Drawing.Size(151, 17)
        Me.cachePositionCheckBox.Text = "Cache and restore position"
        Me.ClientSize = New System.Drawing.Size(325, 420)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.cachePositionCheckBox)
        Me.Controls.Add(Me.dataGridView2)
        Me.Controls.Add(Me.button1)
        
        ' Initialize the data.
        set1 = InitializeDataSet()
        
        ' Set the data source to the DataSet.
        bindingSource1.DataSource = set1
        
        'Set the DataMember to the Menu table.
        bindingSource1.DataMember = "Customers"
        
        ' Add the control data bindings.
        dataGridView1.DataSource = bindingSource1
        
        ' Set the data source and member for the second DataGridView.
        dataGridView2.DataSource = bindingSource1
        dataGridView2.DataMember = "custOrders"
        
        ' Get the currency manager for the customer orders binding.
        Dim relatedCM As CurrencyManager = _
            bindingSource1.GetRelatedCurrencyManager("custOrders")

        ' Handle the two events for caching and resetting the position.
        AddHandler relatedCM.ListChanged, AddressOf relatedCM_ListChanged
        AddHandler relatedCM.PositionChanged, AddressOf relatedCM_PositionChanged
        
        ' Set the position in the child table for demonstration purposes.
        relatedCM.Position = 3

        ' Set cacheing to true in case current changed event
        ' occured on set up.
        cacheChildPosition = True
      
    
    End Sub 'InitializeControlsAndDataSource
    
    
    
    ' Establish the data set with two tables and a relationship
    ' between them.
    Private Function InitializeDataSet() As DataSet 
        set1 = New DataSet()
        ' Declare the DataSet and add a table and column.
        set1.Tables.Add("Customers")
        set1.Tables(0).Columns.Add("CustomerID")
        set1.Tables(0).Columns.Add("Customer Name")
        set1.Tables(0).Columns.Add("Contact Name")
        
        ' Add some rows to the table.
        set1.Tables("Customers").Rows.Add("c1", "Fabrikam, Inc.", _
            "Ellen Adams")
        set1.Tables(0).Rows.Add("c2", "Lucerne Publishing", "Don Hall")
        set1.Tables(0).Rows.Add("c3", "Northwind Traders", "Lori Penor")
        set1.Tables(0).Rows.Add("c4", "Tailspin Toys", "Michael Patten")
        set1.Tables(0).Rows.Add("c5", "Woodgrove Bank", "Jyothi Pai")
        
        ' Declare the DataSet and add a table and column.
        set1.Tables.Add("Orders")
        set1.Tables(1).Columns.Add("CustomerID")
        set1.Tables(1).Columns.Add("OrderNo")
        set1.Tables(1).Columns.Add("OrderDate")
        
        ' Add some rows to the table.
        set1.Tables(1).Rows.Add("c1", "119", "10/04/2006")
        set1.Tables(1).Rows.Add("c1", "149", "10/10/2006")
        set1.Tables(1).Rows.Add("c1", "159", "10/12/2006")
        set1.Tables(1).Rows.Add("c2", "169", "10/10/2006")
        set1.Tables(1).Rows.Add("c2", "179", "10/10/2006")
        set1.Tables(1).Rows.Add("c2", "189", "10/12/2006")
        set1.Tables(1).Rows.Add("c3", "122", "10/04/2006")
        set1.Tables(1).Rows.Add("c4", "130", "10/10/2006")
        set1.Tables(1).Rows.Add("c5", "1.29", "10/14/2006")
        
        Dim dr As New DataRelation("custOrders", _
            set1.Tables("Customers").Columns("CustomerID"), _
            set1.Tables("Orders").Columns("CustomerID"))
        set1.Relations.Add(dr)
        Return set1
    
    End Function '
    '<snippet4>
    Private cachedPosition As Integer = - 1
    Private cacheChildPosition As Boolean = True
    
    '</snippet4>
    '<snippet2>
    Private Sub relatedCM_ListChanged(ByVal sender As Object, _
        ByVal e As ListChangedEventArgs)
        ' Check to see if this is a caching situation.
        If cacheChildPosition AndAlso cachePositionCheckBox.Checked Then
            ' If so, check to see if it is a reset situation, and the current
            ' position is greater than zero.
            Dim relatedCM As CurrencyManager = sender
            If e.ListChangedType = ListChangedType.Reset _
                AndAlso relatedCM.Position > 0 Then

                ' If so, cache the position of the child table.
                cachedPosition = relatedCM.Position
            End If
        End If

    End Sub
    '</snippet2>

    '<snippet5>
    ' Handle the current changed event. This event occurs when
    ' the current item is changed, but not when a field of the current
    ' item is changed.
    Private Sub bindingSource1_CurrentChanged(ByVal sender As Object, _
        ByVal e As EventArgs) Handles bindingSource1.CurrentChanged
        ' If the CurrentChanged event occurs, this is not a caching 
        ' situation.
        cacheChildPosition = False

    End Sub
    '</snippet5>

    '<snippet3>
    Private Sub relatedCM_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) 
        ' Check to see if this is a caching situation.
        If cacheChildPosition AndAlso cachePositionCheckBox.Checked Then
            Dim relatedCM As CurrencyManager = sender
            
            ' If so, check to see if the current position is 
            ' not equal to the cached position and the cached 
            ' position is not out of bounds.
            If relatedCM.Position <> cachedPosition AndAlso _
                cachedPosition > 0 AndAlso cachedPosition < _
                relatedCM.Count Then
                relatedCM.Position = cachedPosition
                cachedPosition = -1
            End If
        End If
    End Sub
    '</snippet3>

    Private count As Integer = 0
    
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles button1.Click
        ' For demo purposes--modifies a value in the first row of the
        ' parent table.
        Dim row1 As DataRow = set1.Tables(0).Rows(0)
        row1(1) = DBNull.Value
    End Sub
     
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    
    End Sub
End Class

'</snippet1>