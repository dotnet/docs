' System.Windows.Forms.DataGridBoolColumn.TrueValueChanged
' System.Windows.Forms.DataGridBoolColumn.AllowNullChanged
' System.Windows.Forms.DataGridBoolColumn.FalseValueChanged

'   The following example demonstrates 'TrueValueChanged',
'   AllowNullChanged' and 'FalseValueChanged' events for the
'   'DataGridBoolColumn' class. This example had a 'DataGrid'
'   which is associated with three columns and a datasource 
'   created with the 'CreateSource' method. There are three
'   additional combo boxes each to change the 'TrueValue',
'   'FalseValue' and 'AllowNull' properties of the 'DataGridBoolColumn'.
'   The 'TrueValue' property is used to specify the object that
'   the 'DataGridBoolColumn' presumes to be a true value. The
'   'FalseValue' property has the same semantics. Changing
'   the value of these properties raises the corresponding 
'   events. Changing 'TrueValue' raises the 'TrueValueChanged', 
'   changing 'FalseValue' raises the 'FalseValueChanged' and
'   'AllowNull' changes the 'AllowNullChanged' events respectively.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Public Class MyForm
   Inherits System.Windows.Forms.Form
   Private myDataGrid As System.Windows.Forms.DataGrid
   Private myDataGridTableStyle As System.Windows.Forms.DataGridTableStyle
   Private myDataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
   Private myDataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
   Private myDataGridBoolColumn As System.Windows.Forms.DataGridBoolColumn
   Private myLabel1 As System.Windows.Forms.Label
   Private myComboBox1 As System.Windows.Forms.ComboBox
   Private myLabel2 As System.Windows.Forms.Label
   Private myComboBox2 As System.Windows.Forms.ComboBox
   Private myLabel3 As System.Windows.Forms.Label
   Private myComboBox3 As System.Windows.Forms.ComboBox
   Private components As System.ComponentModel.Container = Nothing
   
   
   Public Sub New()
      InitializeComponent()
   End Sub 'New
   
   
   Protected Overrides OverLoads Sub Dispose(disposing As Boolean)
      If disposing Then
         If (components IsNot Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub 'Dispose
   
   
   Function CreateSource() As ICollection
      'Create a new 'DataTable' object.
      Dim myDataTable As New DataTable("TestTable")
      Dim myDataRow As DataRow
      
      'Associate 'DataColumns' with the 'DataTable' object.
      myDataTable.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
      myDataTable.Columns.Add(New DataColumn("StringValue", GetType(String)))
      myDataTable.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
      myDataTable.Columns.Add(New DataColumn("BooleanValue", GetType(Boolean)))
      
      Dim count As Integer = 1
      Dim even As Boolean = False
      'Insert new rows into the 'DataTable' object.
      Dim i As Integer
      For i = - 5 To 4
         myDataRow = myDataTable.NewRow()
         myDataRow(0) = count
         myDataRow(1) = "Item " + count.ToString()
         myDataRow(2) = 1.23 *(count + 1)
         ' If 'even' insert a 'DBNull' into the table.
         If even Then
            myDataRow(3) = Convert.DBNull
            even = False
         Else
            If i < 0 Then
               ' If 'negative' insert a 'false' into the table.
               myDataRow(3) = False
            ' If 'positive' insert a 'true' into the table.
            Else
               myDataRow(3) = True
            End If
            even = True
         End If
         myDataTable.Rows.Add(myDataRow)
         count += 1
      Next i
      
      'Create a new instance of 'DataView' from the 'DataTable' instance.
      Dim myDataView As New DataView(myDataTable)
      
      Return myDataView
   End Function 'CreateSource
   
   
   Private Sub InitializeComponent()
      Dim resources As New System.Resources.ResourceManager(GetType(MyForm))
      myDataGridTableStyle = New System.Windows.Forms.DataGridTableStyle()
      myDataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
      myDataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
      myDataGridBoolColumn = New System.Windows.Forms.DataGridBoolColumn()
      myLabel1 = New System.Windows.Forms.Label()
      myLabel2 = New System.Windows.Forms.Label()
      myDataGrid = New System.Windows.Forms.DataGrid()
      myLabel3 = New System.Windows.Forms.Label()
      myComboBox3 = New System.Windows.Forms.ComboBox()
      myComboBox2 = New System.Windows.Forms.ComboBox()
      myComboBox1 = New System.Windows.Forms.ComboBox()
      CType(myDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
      SuspendLayout()
      ' 
      ' myDataGridTableStyle
      ' 
      myDataGridTableStyle.DataGrid = myDataGrid
      myDataGridTableStyle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() _
                         {myDataGridTextBoxColumn1, myDataGridTextBoxColumn2, myDataGridBoolColumn})
      myDataGridTableStyle.MappingName = "TestTable"
      ' 
      ' myDataGridTextBoxColumn1
      ' 
      myDataGridTextBoxColumn1.MappingName = "IntegerValue"
      ' 
      ' myDataGridTextBoxColumn2
      ' 
      myDataGridTextBoxColumn2.MappingName = "StringValue"
      ' 
      ' myDataGridBoolColumn
      ' 
      myDataGridBoolColumn.MappingName = "BooleanValue"
      myDataGridBoolColumn.TrueValue = True
      myDataGridBoolColumn.FalseValue = False
      myDataGridBoolColumn.NullValue = Convert.DBNull
      myDataGridBoolColumn.AllowNull = True
      RegisterEventHandlers(myDataGridBoolColumn)
      ' 
      ' myLabel1
      ' 
      myLabel1.Location = New System.Drawing.Point(16, 232)
      myLabel1.Size = New System.Drawing.Size(136, 24)
      myLabel1.Text = "Change the TrueValue to:"
      ' 
      ' myLabel2
      ' 
      myLabel2.Location = New System.Drawing.Point(16, 264)
      myLabel2.Size = New System.Drawing.Size(136, 24)
      myLabel2.Text = "Change the FalseValue to:"
      ' 
      ' myDataGrid
      ' 
      myDataGrid.Location = New System.Drawing.Point(16, 0)
      myDataGrid.Size = New System.Drawing.Size(296, 216)
      myDataGrid.DataSource = CreateSource()
      myDataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() _
                                                               {myDataGridTableStyle})
      ' 
      ' myLabel3
      ' 
      myLabel3.Location = New System.Drawing.Point(16, 296)
      myLabel3.Size = New System.Drawing.Size(136, 24)
      myLabel3.Text = "Allow null values to appear:"
      ' 
      ' myComboBox3
      ' 
      myComboBox3.Location = New System.Drawing.Point(168, 288)
      myComboBox3.Size = New System.Drawing.Size(144, 21)
      myComboBox3.Items.AddRange(New Object() {True, False})
      AddHandler myComboBox3.SelectedIndexChanged, AddressOf myComboBox3_SelectedIndexChanged
      ' 
      ' myComboBox2
      ' 
      myComboBox2.Location = New System.Drawing.Point(168, 256)
      myComboBox2.Size = New System.Drawing.Size(144, 21)
      myComboBox2.Items.AddRange(New Object() {True, False})
      AddHandler myComboBox2.SelectedIndexChanged, AddressOf myComboBox2_SelectedIndexChanged
      ' 
      ' myComboBox1
      ' 
      myComboBox1.Location = New System.Drawing.Point(168, 224)
      myComboBox1.Size = New System.Drawing.Size(144, 21)
      myComboBox1.Items.AddRange(New Object() {True, False})
      AddHandler myComboBox1.SelectedIndexChanged, AddressOf myComboBox1_SelectedIndexChanged
      ' 
      ' MyForm
      ' 
      ClientSize = New System.Drawing.Size(336, 341)
      Controls.AddRange(New System.Windows.Forms.Control() _
           {myComboBox3, myLabel3, myComboBox2, myLabel2, myComboBox1, myLabel1, myDataGrid})
      Name = "MyForm"
      [Text] = "MyForm"
      CType(myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
      ResumeLayout(False)
   End Sub 'InitializeComponent
    
   
  <STAThread()> Shared _
   Sub Main()
      Application.Run(New MyForm())
   End Sub 'Main
   
   
' <Snippet1>
' <Snippet2>
' <Snippet3>
   Private Sub RegisterEventHandlers(myDataGridBoolColumn As DataGridBoolColumn)
      AddHandler myDataGridBoolColumn.AllowNullChanged, _
                          AddressOf myDataGridBoolColumn_AllowNullChanged
      AddHandler myDataGridBoolColumn.TrueValueChanged, _
                          AddressOf myDataGridBoolColumn_TrueValueChanged
      AddHandler myDataGridBoolColumn.FalseValueChanged, _
                          AddressOf myDataGridBoolColumn_FalseValueChanged
   End Sub 'RegisterEventHandlers
   
   
   ' Event handler for event when 'TrueValue' is property changed.
   Private Sub myDataGridBoolColumn_TrueValueChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The TrueValue property of the DataGridBoolColumn has been changed to " _
                                                    & myDataGridBoolColumn.TrueValue)
   End Sub 'myDataGridBoolColumn_TrueValueChanged
   
   
   ' Event handler for event when 'FalseValue' is property changed.
   Private Sub myDataGridBoolColumn_FalseValueChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The FalseValue property of the DataGridBoolColumn has been changed to " _
                                                        & myDataGridBoolColumn.FalseValue)
   End Sub 'myDataGridBoolColumn_FalseValueChanged
   
   
   ' Event handler for event when 'AllowNull' is property changed.
   Private Sub myDataGridBoolColumn_AllowNullChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The AllowNull property of DataGridBoolColumn has been changed to " _
                                                          & myDataGridBoolColumn.AllowNull)
   End Sub 'myDataGridBoolColumn_AllowNullChanged
   
   
' </Snippet3>
' </Snippet2>
' </Snippet1>
   ' Change the value of 'TrueValue' property to what user specifies.
   Private Sub myComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
     myDataGridBoolColumn.TrueValue = CType(myComboBox1.Items(myComboBox1.SelectedIndex), Boolean)
   End Sub 'myComboBox1_SelectedIndexChanged
   
   
   ' Change the value of 'FalseValue' property to what user specifies.
   Private Sub myComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
     myDataGridBoolColumn.FalseValue = CType(myComboBox2.Items(myComboBox2.SelectedIndex), Boolean)
   End Sub 'myComboBox2_SelectedIndexChanged
   
   
   ' Change the value of 'AllowNull' property to what user specifies.
   Private Sub myComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
     myDataGridBoolColumn.AllowNull = CType(myComboBox3.Items(myComboBox3.SelectedIndex), Boolean)
   End Sub 'myComboBox3_SelectedIndexChanged
End Class 'MyForm