' System.Windows.Forms.DataGridTableStyle.HeaderForeColorChanged;System.Windows.Forms.DataGridTableStyle.HeaderForeColor
' System.Windows.Forms.DataGridTableStyle.HeaderBackColorChanged;System.Windows.Forms.DataGridTableStyle.HeaderBackColor

' The following program demonstrates the usage of properties 'HeaderBackColor',
' 'HeaderForeColor' and events 'HeaderBackColorChanged','HeaderForeColorChanged'.
'  A table is created and added to a datagrid with two coloumns.The table allows to change
'  Header's  background and foreground colors through selection of combobox values.

Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace Datagrid
  
   Public Class Form1
      Inherits System.Windows.Forms.Form
      
      Private dataGrid1 As System.Windows.Forms.DataGrid
      Private WithEvents button1 As System.Windows.Forms.Button
      Private comboBox1 As System.Windows.Forms.ComboBox
      Private comboBox2 As System.Windows.Forms.ComboBox
      Private WithEvents button2 As System.Windows.Forms.Button
      
      
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         InitializeComponent()
      End Sub 'New
      
      
      ' Clean up resources.
      Protected Overrides overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose
      
      Private Sub InitializeComponent()
         Me.comboBox1 = New System.Windows.Forms.ComboBox()
         Me.button1 = New System.Windows.Forms.Button()
         Me.dataGrid1 = New System.Windows.Forms.DataGrid()
         Me.comboBox2 = New System.Windows.Forms.ComboBox()
         Me.button2 = New System.Windows.Forms.Button()
         CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' comboBox1
         ' 
         Me.comboBox1.DropDownWidth = 136
         Me.comboBox1.Items.AddRange(New Object() {"Blue", "Red", "Yellow"})
         Me.comboBox1.Location = New System.Drawing.Point(56, 144)
         Me.comboBox1.Name = "comboBox1"
         Me.comboBox1.Size = New System.Drawing.Size(136, 21)
         Me.comboBox1.Sorted = True
         Me.comboBox1.TabIndex = 2
         Me.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList
         ' 
         ' button1
         ' 
         Me.button1.Location = New System.Drawing.Point(232, 144)
         Me.button1.Name = "button1"
         Me.button1.Size = New System.Drawing.Size(96, 32)
         Me.button1.TabIndex = 1
         Me.button1.Text = "Change Header Background"
         ' 
         ' dataGrid1
         ' 
         Me.dataGrid1.CaptionText = "DataGrid"
         Me.dataGrid1.DataMember = ""
         Me.dataGrid1.Location = New System.Drawing.Point(56, 48)
         Me.dataGrid1.Name = "dataGrid1"
         Me.dataGrid1.Size = New System.Drawing.Size(272, 80)
         Me.dataGrid1.TabIndex = 0
         ' 
         ' comboBox2
         ' 
         Me.comboBox2.DropDownWidth = 136
         Me.comboBox2.Items.AddRange(New Object() {"Green", "White", "Violet"})
         Me.comboBox2.Location = New System.Drawing.Point(56, 192)
         Me.comboBox2.Name = "comboBox2"
         Me.comboBox2.Size = New System.Drawing.Size(136, 21)
         Me.comboBox2.TabIndex = 3
         Me.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList
         ' 
         ' button2
         ' 
         Me.button2.Location = New System.Drawing.Point(232, 184)
         Me.button2.Name = "button2"
         Me.button2.Size = New System.Drawing.Size(96, 32)
         Me.button2.TabIndex = 4
         Me.button2.Text = "Change Header ForeGround"
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(536, 301)
         Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button2, Me.comboBox2, Me.comboBox1, Me.button1, Me.dataGrid1})
         Me.Name = "Form1"
         Me.Text = "Form1"
         CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
      End Sub 'InitializeComponent
       
       <STAThread()> Shared Sub Main()
         Application.Run(New Form1())
      End Sub 'Main
      
      ' Declare objects of DataSet,DataGrid,DataTable.
      Private myDataSet As DataSet
      Public myCustomerTable As DataTable
      Public myTableStyle As DataGridTableStyle
      
      
      Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
         comboBox1.SelectedIndex = 0
         comboBox2.SelectedIndex = 0
         Create_Table()
      End Sub 'Form1_Load
      
' <Snippet1>
' <Snippet2>
' <Snippet3>
' <Snippet4>
      Private Sub Create_Table()
         ' Create DataSet.
         myDataSet = New DataSet("myDataSet")
         ' Create DataTable.
         Dim myCustomerTable As New DataTable("Customers")
         ' Create two columns, and add them to the table.
         Dim CustID As New DataColumn("CustID", GetType(Integer))
         Dim CustName As New DataColumn("CustName")
         myCustomerTable.Columns.Add(CustID)
         myCustomerTable.Columns.Add(CustName)
         ' Add table to DataSet.
         myDataSet.Tables.Add(myCustomerTable)
         dataGrid1.SetDataBinding(myDataSet, "Customers")
         myTableStyle = New DataGridTableStyle()
         myTableStyle.MappingName = "Customers"
         AddHandler myTableStyle.HeaderBackColorChanged, AddressOf HeaderBackColorChangedHandler
         AddHandler myTableStyle.HeaderForeColorChanged, AddressOf HeaderForeColorChangedHandler
      End Sub 'Create_Table
      
      
      ' Change header background color.
      Private Sub OnHeaderBackColor_Click(sender As Object, e As System.EventArgs) Handles button1.Click
         dataGrid1.TableStyles.Clear()
         Select Case comboBox1.SelectedItem.ToString()
            Case "Red"
               myTableStyle.HeaderBackColor = Color.Red
            Case "Yellow"
               myTableStyle.HeaderBackColor = Color.Yellow
            Case "Blue"
               myTableStyle.HeaderBackColor = Color.Blue
         End Select
         myTableStyle.AlternatingBackColor = Color.LightGray
         dataGrid1.TableStyles.Add(myTableStyle)
      End Sub 'OnHeaderBackColor_Click
      
' </Snippet4>
        Private Sub HeaderBackColorChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Changed Header Background color to : " + comboBox1.SelectedItem.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'HeaderBackColorChangedHandler
      
' </Snippet3>
      ' Change header forecolor.
      Private Sub OnHeaderForeColor_Click(sender As Object, e As System.EventArgs) Handles button2.Click
         dataGrid1.TableStyles.Clear()
         Select Case comboBox2.SelectedItem.ToString()
            Case "Green"
               myTableStyle.HeaderForeColor = Color.Green
            Case "White"
               myTableStyle.HeaderForeColor = Color.White
            Case "Violet"
               myTableStyle.HeaderForeColor = Color.Violet
         End Select
         myTableStyle.AlternatingBackColor = Color.LightGray
         dataGrid1.TableStyles.Add(myTableStyle)
      End Sub 'OnHeaderForeColor_Click
      
' </Snippet2>
        Private Sub HeaderForeColorChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("Changed Header Fore color to : " + comboBox2.SelectedItem.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Sub 'HeaderForeColorChangedHandler
' </Snippet1>
   End Class 'Form1
End Namespace 'Datagrid
