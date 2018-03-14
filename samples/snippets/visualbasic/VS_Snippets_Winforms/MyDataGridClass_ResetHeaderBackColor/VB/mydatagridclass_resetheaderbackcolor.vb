' System.Windows.Forms.DataGrid.ResetHeaderBackColor
' System.Windows.Forms.DataGrid.ResetHeaderForeColor
' System.Windows.Forms.DataGrid.ResetHeaderFont
' System.Windows.Forms.DataGrid.Select
' System.Windows.Forms.DataGrid.IsSelected
' System.Windows.Forms.DataGrid.RowHeaderWidth

'  The following program demonstrates various methods and properties of
'	the 'DataGrid' class. It creates a 'GridControl', changes the 
'	header background color,header foreground color, header font
'	and resets them. It also selects a row, checks weather the row is selected 
'	and checks the 'ReadOnly'	and 'FlatMode' properties of the data grid.
'	Displays the 'RowHeaderWidth', depending on the selection of 
'	buttons.
'
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace MyDataGridClass

   ' <summary>
   ' Summary description for MyDataGridClass_ResetHeaderBackColor.
   ' </summary>

    Public Class MyDataGridClass_ResetHeaderBackColor
        Inherits Form
        Private myDataGrid As DataGrid
        ' <summary>
        ' Required designer variable.
        ' </summary>
        Private components As Container = Nothing
        Private WithEvents button1 As Button
        Private WithEvents button2 As Button
        Private WithEvents button3 As Button
        Private WithEvents button4 As Button
        Private WithEvents button5 As Button
        Private WithEvents button6 As Button
        Private WithEvents button7 As Button
        Private WithEvents button8 As Button
        Private myDataSet As DataSet
        Private WithEvents button9 As Button
        Private WithEvents button11 As Button


        Public Sub New()
            InitializeComponent()
            SetUp()
        End Sub 'New

        ' <summary>
        ' Clean up any resources being used.
        ' </summary>
        Protected Overloads Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If (components IsNot Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose



        ' <summary>

        ' </summary>
        Private Sub InitializeComponent()
            Me.FormBorderStyle = FormBorderStyle.FixedDialog
            Me.button8 = New Button()
            Me.button9 = New Button()
            Me.button11 = New Button()
            Me.button4 = New Button()
            Me.button5 = New Button()
            Me.button6 = New Button()
            Me.button7 = New Button()
            Me.button1 = New Button()
            Me.button2 = New Button()
            Me.button3 = New Button()
            Me.myDataGrid = New DataGrid()
            CType(Me.myDataGrid, ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' button8
            ' 
            Me.button8.Location = New Point(352, 176)
            Me.button8.Name = "button8"
            Me.button8.Size = New Size(96, 40)
            Me.button8.TabIndex = 8
            Me.button8.Text = "Display Status"
            ' 
            ' button9
            ' 
            Me.button9.Location = New Point(24, 216)
            Me.button9.Name = "button9"
            Me.button9.Size = New Size(96, 40)
            Me.button9.TabIndex = 9
            Me.button9.Text = "Get Row Header Width"
            ' 
            ' button11
            ' 
            Me.button11.Location = New Point(256, 216)
            Me.button11.Name = "button11"
            Me.button11.Size = New Size(96, 40)
            Me.button11.TabIndex = 7
            Me.button11.Text = "UnSelect Row"
            ' 
            ' button4
            ' 
            Me.button4.Location = New Point(352, 72)
            Me.button4.Name = "button4"
            Me.button4.Size = New Size(96, 40)
            Me.button4.TabIndex = 4
            Me.button4.Text = "Reset Header Fore Color"
            ' 
            ' button5
            ' 
            Me.button5.Location = New Point(352, 128)
            Me.button5.Name = "button5"
            Me.button5.Size = New Size(96, 40)
            Me.button5.TabIndex = 5
            Me.button5.Text = "Reset Header Font"
            ' 
            ' button6
            ' 
            Me.button6.Location = New Point(256, 128)
            Me.button6.Name = "button6"
            Me.button6.Size = New Size(96, 40)
            Me.button6.TabIndex = 6
            Me.button6.Text = "Change Header Font"
            ' 
            ' button7
            ' 
            Me.button7.Location = New Point(256, 176)
            Me.button7.Name = "button7"
            Me.button7.Size = New Size(96, 40)
            Me.button7.TabIndex = 7
            Me.button7.Text = "Select Row"
            ' 
            ' button1
            ' 
            Me.button1.Location = New Point(256, 24)
            Me.button1.Name = "button1"
            Me.button1.Size = New Size(96, 40)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Change Header Back Color"
            ' 
            ' button2
            ' 
            Me.button2.Location = New Point(352, 24)
            Me.button2.Name = "button2"
            Me.button2.Size = New Size(96, 40)
            Me.button2.TabIndex = 2
            Me.button2.Text = "Reset Header Back Color"
            ' 
            ' button3
            ' 
            Me.button3.Location = New Point(256, 72)
            Me.button3.Name = "button3"
            Me.button3.Size = New Size(96, 40)
            Me.button3.TabIndex = 3
            Me.button3.Text = "Change Header Fore Color"
            ' 
            ' myDataGrid
            ' 
            Me.myDataGrid.CaptionText = "My Grid Control"
            Me.myDataGrid.DataMember = ""
            Me.myDataGrid.Location = New Point(8, 32)
            Me.myDataGrid.Name = "myDataGrid"
            Me.myDataGrid.RowHeaderWidth = 50
            Me.myDataGrid.Size = New Size(216, 152)
            Me.myDataGrid.TabIndex = 0
            ' 
            ' MyDataGridClass_ResetHeaderBackColor
            ' 
            Me.AutoScale = False
            Me.ClientSize = New Size(528, 273)
            Me.Controls.AddRange(New Control() {Me.button9, Me.button8, Me.button7, Me.button6, 	    Me.button5, Me.button4, Me.button3, Me.button2, Me.button1, Me.myDataGrid, Me.button11})
            Me.MaximizeBox = False
            Me.Name = "MyDataGridClass_ResetHeaderBackColor"
            Me.Text = "Grid Control"
            CType(Me.myDataGrid, ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent

        ' <summary>
        ' The main entry point for the application.
        ' </summary>
        <STAThread()> Shared Sub Main()
            Application.Run(New MyDataGridClass_ResetHeaderBackColor())
        End Sub 'Main

        Private Sub SetUp()
            MakeDataSet()
            myDataGrid.SetDataBinding(myDataSet, "Customers")
            myDataGrid.ReadOnly = True
        End Sub 'SetUp


        Private Sub MakeDataSet()
            ' Create a 'DataSet'.
            myDataSet = New DataSet("myDataSet")
            ' Create a 'DataTable'.
            Dim myTable As New DataTable("Customers")
            ' Create two columns, and add them to the table.
            Dim myColumn1 As New DataColumn("CustID", GetType(Integer))
            Dim myColumn2 As New DataColumn("CustName")
            myTable.Columns.Add(myColumn1)
            myTable.Columns.Add(myColumn2)
            ' Add the table to the 'DataSet'.
            myDataSet.Tables.Add(myTable)
            ' For the customer, create a 'DataRow' variable. 
            Dim newRow As DataRow
            ' Create one customer in the customers table.
            Dim i As Integer
            For i = 1 To 1
                newRow = myTable.NewRow()
                newRow("custID") = i
                ' Add the row to the 'Customers' table.
                myTable.Rows.Add(newRow)
            Next i
            ' Give the customer a name.
            myTable.Rows(0)("custName") = "Customer"
        End Sub 'MakeDataSet

' <Snippet1>		
        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            Dim myColorDialog As New ColorDialog()
            ' Disable selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Enable the help button.
            myColorDialog.ShowHelp = True
            ' Set the initial color to the current color.
            myColorDialog.Color = myDataGrid.HeaderBackColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set the header background color.   
            myDataGrid.HeaderBackColor = myColorDialog.Color
        End Sub 'button1_Click

        ' Reset the header background color.
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            myDataGrid.ResetHeaderBackColor()
        End Sub 'button2_Click

' </Snippet1>		
' <Snippet2>
        Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
            Dim myColorDialog As New ColorDialog()
            ' Disable selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Enable the help button.
            myColorDialog.ShowHelp = True
            ' Set the initial color to the current color.
            myColorDialog.Color = myDataGrid.HeaderForeColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set the header foreground color.
            myDataGrid.HeaderForeColor = myColorDialog.Color
        End Sub 'button3_Click

        ' Reset the header foregroundcolor.
        Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click
            myDataGrid.ResetHeaderForeColor()
        End Sub 'button4_Click

' </Snippet2>
' <Snippet3>
        ' Set the header font to Arial with size 20.
        Private Sub button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button6.Click
            myDataGrid.HeaderFont = New Font("Arial", 20)
        End Sub 'button6_Click

        ' Reset the header font.
        Private Sub button5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button5.Click
            myDataGrid.ResetHeaderFont()
        End Sub 'button5_Click

' </Snippet3>
' <Snippet4>
        ' Select the first row.
        Private Sub button7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button7.Click
            myDataGrid.Select(0)
        End Sub 'button7_Click

        ' <Snippet5>
        ' Check if the first row is selected.
        Private Sub button8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button8.Click
            If myDataGrid.IsSelected(0) Then
                MessageBox.Show("Row selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                MessageBox.Show("Row not selected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End Sub 'button8_Click

        ' Deselect the first row.
        Private Sub button11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button11.Click
            myDataGrid.UnSelect(0)
        End Sub 'button11_Click

' </Snippet4>
' </Snippet5>
' <Snippet6>
        ' Get the width of row header.
        Private Sub button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button9.Click
            Dim myRowHeaderWidth As Int32 = myDataGrid.RowHeaderWidth
            MessageBox.Show("Width of row headers is: " + myRowHeaderWidth.ToString(), "Message", MessageBoxButtons.OK, 	    MessageBoxIcon.Exclamation)
        End Sub 'button9_Click
' </Snippet6>		
    End Class 'MyDataGridClass_ResetHeaderBackColor
End Namespace 'MyDataGridClass
