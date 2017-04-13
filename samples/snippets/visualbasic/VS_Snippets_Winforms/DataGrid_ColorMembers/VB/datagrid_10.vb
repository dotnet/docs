' System.Windows.Forms.DataGrid.SelectionBackColor
' System.Windows.Forms.DataGrid.SelectionForeColor
' System.Windows.Forms.DataGrid.ResetSelectionBackColor
' System.Windows.Forms.DataGrid.ResetSelectionForeColor
' System.Windows.Forms.DataGrid.ResetBackColor
' System.Windows.Forms.DataGrid.ResetForeColor
' System.Windows.Forms.DataGrid.ForeColor
' System.Windows.Forms.DataGrid.ResetAlternatingBackColor
' System.Windows.Forms.DataGrid.ResetLinkColor
' System.Windows.Forms.DataGrid.ResetGridLineColor

' The following program demonstrates the 'SelectionBackColor',
' 'SelectionForeColor', 'ResetSelectionBackColor','ResetForeColor',
' 'ResetSelectionForeColor', 'ResetBackColor', 'ResetLinkColor',
' 'ResetAlternatingBackColor', 'ForeColor' and 
' 'ResetGridLineColor' of 'System.Windows.Forms.DataGrid class'. 
' It creates a windows form, a 'DataSet' containing two 'DataTable' 
' objects, and a 'DataRelation' that relates the two tables. To 
' display the data, a 'DataGrid' control is then bound to the 
' 'DataSet' through the 'SetDataBinding' method. 
' Ten buttons are provided on form to demonstrate each property.
' Effect of each property can be seen on 'DataGrid'.


Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


Namespace DataGridSample

   ' <summary>
   ' Summary description for DatGridClass.
   ' </summary>
   Public Class DatGridClass
      Inherits System.Windows.Forms.Form
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private myDataSet As DataSet
      Private myDataGrid As System.Windows.Forms.DataGrid
        Private WithEvents btnResetSelectionBkColor As System.Windows.Forms.Button
        Private WithEvents btnSeSelectiontBkColor As System.Windows.Forms.Button
        Private WithEvents btnSetSelectionForeColor As System.Windows.Forms.Button
        Private WithEvents btnResetSelectionForeColor As System.Windows.Forms.Button
        Private WithEvents btnSetForeColor As System.Windows.Forms.Button
        Private WithEvents btnResetForeColor As System.Windows.Forms.Button
        Private WithEvents btnSetBkColor As System.Windows.Forms.Button
        Private WithEvents btnResetBkColor As System.Windows.Forms.Button
        Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
        Private WithEvents btnResetLinkColor As System.Windows.Forms.Button
        Private WithEvents btnResetAlternatingBackColor As System.Windows.Forms.Button
        Private WithEvents btnSetLinkColor As System.Windows.Forms.Button
        Private WithEvents btnSetAlternatingBkColor As System.Windows.Forms.Button
        Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
        Private WithEvents btnResetGridLineColor As System.Windows.Forms.Button
        Private WithEvents btnSetGridLineColor As System.Windows.Forms.Button
      ' <summary>
      ' Required designer variable.
      ' </summary>
      Private components As System.ComponentModel.Container = Nothing
      
      
      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         ' Setup GridControl data.
         SetUp()
      End Sub 'New
      
      
      ' <summary>
      ' Clean up any resources being used.
      ' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
            Me.btnResetBkColor = New System.Windows.Forms.Button()
            Me.btnSetBkColor = New System.Windows.Forms.Button()
            Me.btnResetForeColor = New System.Windows.Forms.Button()
            Me.groupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnSeSelectiontBkColor = New System.Windows.Forms.Button()
            Me.btnResetSelectionBkColor = New System.Windows.Forms.Button()
            Me.btnSetSelectionForeColor = New System.Windows.Forms.Button()
            Me.btnResetSelectionForeColor = New System.Windows.Forms.Button()
            Me.groupBox2 = New System.Windows.Forms.GroupBox()
            Me.btnSetForeColor = New System.Windows.Forms.Button()
            Me.groupBox3 = New System.Windows.Forms.GroupBox()
            Me.btnSetAlternatingBkColor = New System.Windows.Forms.Button()
            Me.btnSetLinkColor = New System.Windows.Forms.Button()
            Me.btnResetAlternatingBackColor = New System.Windows.Forms.Button()
            Me.btnResetLinkColor = New System.Windows.Forms.Button()
            Me.groupBox4 = New System.Windows.Forms.GroupBox()
            Me.btnSetGridLineColor = New System.Windows.Forms.Button()
            Me.btnResetGridLineColor = New System.Windows.Forms.Button()
            Me.myDataGrid = New System.Windows.Forms.DataGrid()
            Me.groupBox1.SuspendLayout()
            Me.groupBox2.SuspendLayout()
            Me.groupBox3.SuspendLayout()
            Me.groupBox4.SuspendLayout()
            CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' btnResetBkColor
            ' 
            Me.btnResetBkColor.Location = New System.Drawing.Point(120, 56)
            Me.btnResetBkColor.Name = "btnResetBkColor"
            Me.btnResetBkColor.Size = New System.Drawing.Size(104, 32)
            Me.btnResetBkColor.TabIndex = 3
            Me.btnResetBkColor.Text = "Reset background color"
            ' 
            ' btnSetBkColor
            ' 
            Me.btnSetBkColor.Location = New System.Drawing.Point(120, 24)
            Me.btnSetBkColor.Name = "btnSetBkColor"
            Me.btnSetBkColor.Size = New System.Drawing.Size(104, 32)
            Me.btnSetBkColor.TabIndex = 2
            Me.btnSetBkColor.Text = "Set background color"
            ' 
            ' btnResetForeColor
            ' 
            Me.btnResetForeColor.Location = New System.Drawing.Point(16, 56)
            Me.btnResetForeColor.Name = "btnResetForeColor"
            Me.btnResetForeColor.Size = New System.Drawing.Size(104, 32)
            Me.btnResetForeColor.TabIndex = 1
            Me.btnResetForeColor.Text = "Reset foreground color"
            ' 
            ' groupBox1
            ' 
            Me.groupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSeSelectiontBkColor, Me.btnResetSelectionBkColor, Me.btnSetSelectionForeColor, Me.btnResetSelectionForeColor})
            Me.groupBox1.Location = New System.Drawing.Point(296, 24)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(248, 96)
            Me.groupBox1.TabIndex = 4
            Me.groupBox1.TabStop = False
            ' 
            ' btnSeSelectiontBkColor
            ' 
            Me.btnSeSelectiontBkColor.Location = New System.Drawing.Point(125, 24)
            Me.btnSeSelectiontBkColor.Name = "btnSeSelectiontBkColor"
            Me.btnSeSelectiontBkColor.Size = New System.Drawing.Size(112, 32)
            Me.btnSeSelectiontBkColor.TabIndex = 0
            Me.btnSeSelectiontBkColor.Text = "Set selection  background color"
            ' 
            ' btnResetSelectionBkColor
            ' 
            Me.btnResetSelectionBkColor.Location = New System.Drawing.Point(125, 56)
            Me.btnResetSelectionBkColor.Name = "btnResetSelectionBkColor"
            Me.btnResetSelectionBkColor.Size = New System.Drawing.Size(112, 32)
            Me.btnResetSelectionBkColor.TabIndex = 1
            Me.btnResetSelectionBkColor.Text = "Reset selection background color"
            ' 
            ' btnSetSelectionForeColor
            ' 
            Me.btnSetSelectionForeColor.Location = New System.Drawing.Point(13, 24)
            Me.btnSetSelectionForeColor.Name = "btnSetSelectionForeColor"
            Me.btnSetSelectionForeColor.Size = New System.Drawing.Size(112, 32)
            Me.btnSetSelectionForeColor.TabIndex = 2
            Me.btnSetSelectionForeColor.Text = "Set selection  foreground color"
            ' 
            ' btnResetSelectionForeColor
            ' 
            Me.btnResetSelectionForeColor.Location = New System.Drawing.Point(13, 56)
            Me.btnResetSelectionForeColor.Name = "btnResetSelectionForeColor"
            Me.btnResetSelectionForeColor.Size = New System.Drawing.Size(112, 32)
            Me.btnResetSelectionForeColor.TabIndex = 3
            Me.btnResetSelectionForeColor.Text = "Reset selection  foreground color"
            ' 
            ' groupBox2
            ' 
            Me.groupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResetBkColor, Me.btnSetBkColor, Me.btnResetForeColor, Me.btnSetForeColor})
            Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, System.Byte))
            Me.groupBox2.Location = New System.Drawing.Point(296, 128)
            Me.groupBox2.Name = "groupBox2"
            Me.groupBox2.Size = New System.Drawing.Size(248, 96)
            Me.groupBox2.TabIndex = 5
            Me.groupBox2.TabStop = False
            ' 
            ' btnSetForeColor
            ' 
            Me.btnSetForeColor.Location = New System.Drawing.Point(16, 24)
            Me.btnSetForeColor.Name = "btnSetForeColor"
            Me.btnSetForeColor.Size = New System.Drawing.Size(104, 32)
            Me.btnSetForeColor.TabIndex = 0
            Me.btnSetForeColor.Text = "Set foreground color"
            ' 
            ' groupBox3
            ' 
            Me.groupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSetAlternatingBkColor, Me.btnSetLinkColor, Me.btnResetAlternatingBackColor, Me.btnResetLinkColor})
            Me.groupBox3.Location = New System.Drawing.Point(296, 224)
            Me.groupBox3.Name = "groupBox3"
            Me.groupBox3.Size = New System.Drawing.Size(248, 96)
            Me.groupBox3.TabIndex = 7
            Me.groupBox3.TabStop = False
            ' 
            ' btnSetAlternatingBkColor
            ' 
            Me.btnSetAlternatingBkColor.Location = New System.Drawing.Point(121, 24)
            Me.btnSetAlternatingBkColor.Name = "btnSetAlternatingBkColor"
            Me.btnSetAlternatingBkColor.Size = New System.Drawing.Size(104, 32)
            Me.btnSetAlternatingBkColor.TabIndex = 5
            Me.btnSetAlternatingBkColor.Text = "Set alternating back color"
            ' 
            ' btnSetLinkColor
            ' 
            Me.btnSetLinkColor.Location = New System.Drawing.Point(17, 24)
            Me.btnSetLinkColor.Name = "btnSetLinkColor"
            Me.btnSetLinkColor.Size = New System.Drawing.Size(104, 32)
            Me.btnSetLinkColor.TabIndex = 4
            Me.btnSetLinkColor.Text = "Set link color"
            ' 
            ' btnResetAlternatingBackColor
            ' 
            Me.btnResetAlternatingBackColor.Location = New System.Drawing.Point(121, 56)
            Me.btnResetAlternatingBackColor.Name = "btnResetAlternatingBackColor"
            Me.btnResetAlternatingBackColor.Size = New System.Drawing.Size(104, 32)
            Me.btnResetAlternatingBackColor.TabIndex = 3
            Me.btnResetAlternatingBackColor.Text = "Reset alternating back color"
            ' 
            ' btnResetLinkColor
            ' 
            Me.btnResetLinkColor.Location = New System.Drawing.Point(17, 56)
            Me.btnResetLinkColor.Name = "btnResetLinkColor"
            Me.btnResetLinkColor.Size = New System.Drawing.Size(104, 32)
            Me.btnResetLinkColor.TabIndex = 1
            Me.btnResetLinkColor.Text = "Reset link color"
            ' 
            ' groupBox4
            ' 
            Me.groupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSetGridLineColor, Me.btnResetGridLineColor})
            Me.groupBox4.Location = New System.Drawing.Point(164, 226)
            Me.groupBox4.Name = "groupBox4"
            Me.groupBox4.Size = New System.Drawing.Size(124, 93)
            Me.groupBox4.TabIndex = 8
            Me.groupBox4.TabStop = False
            ' 
            ' btnSetGridLineColor
            ' 
            Me.btnSetGridLineColor.Location = New System.Drawing.Point(8, 16)
            Me.btnSetGridLineColor.Name = "btnSetGridLineColor"
            Me.btnSetGridLineColor.Size = New System.Drawing.Size(104, 32)
            Me.btnSetGridLineColor.TabIndex = 3
            Me.btnSetGridLineColor.Text = "Set grid line color"
            ' 
            ' btnResetGridLineColor
            ' 
            Me.btnResetGridLineColor.Location = New System.Drawing.Point(8, 48)
            Me.btnResetGridLineColor.Name = "btnResetGridLineColor"
            Me.btnResetGridLineColor.Size = New System.Drawing.Size(104, 32)
            Me.btnResetGridLineColor.TabIndex = 0
            Me.btnResetGridLineColor.Text = "Reset grid line color"
            ' 
            ' myDataGrid
            ' 
            Me.myDataGrid.DataMember = ""
            Me.myDataGrid.ForeColor = System.Drawing.Color.Blue
            Me.myDataGrid.Location = New System.Drawing.Point(12, 32)
            Me.myDataGrid.Name = "myDataGrid"
            Me.myDataGrid.Size = New System.Drawing.Size(272, 192)
            Me.myDataGrid.TabIndex = 6
            Me.myDataGrid.ReadOnly = True
            ' 
            ' DatGridClass
            ' 
            Me.ClientSize = New System.Drawing.Size(560, 333)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.groupBox4, Me.groupBox3, Me.myDataGrid, Me.groupBox2, Me.groupBox1})
            Me.Name = "DatGridClass"
            Me.Text = "Sample Program"
            Me.groupBox1.ResumeLayout(False)
            Me.groupBox2.ResumeLayout(False)
            Me.groupBox3.ResumeLayout(False)
            Me.groupBox4.ResumeLayout(False)
            CType(Me.myDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub 'InitializeComponent

        ' <summary>
        ' The main entry point for the application.
        ' </summary>
        <STAThread()> Shared Sub Main()
            Application.Run(New DatGridClass())
        End Sub 'Main

        Private Sub SetUp()
            ' Create a 'DataSet' with two tables and one relation.
            MakeDataSet()
            ' Bind the 'DataGrid' to the 'DataSet'. The data member
            ' specifies that the 'Customers Table' should be displayed.
            myDataGrid.SetDataBinding(myDataSet, "Customers")
        End Sub 'SetUp

        ' Create a 'DataSet' with two tables and populate it.
        Private Sub MakeDataSet()
            ' Create a 'DataSet'.
            myDataSet = New DataSet("myDataSet")
            ' Create two 'DataTables'.
            Dim tCust As New DataTable("Customers")
            Dim tOrders As New DataTable("Orders")

            ' Create two columns, and add them to the first table.
            Dim cCustID As New DataColumn("CustID", GetType(Integer))
            Dim cCustName As New DataColumn("CustName")
            Dim cCurrent As New DataColumn("Current", GetType(Boolean))
            tCust.Columns.Add(cCustID)
            tCust.Columns.Add(cCustName)
            tCust.Columns.Add(cCurrent)

            ' Create three columns and add them to the second table.
            Dim cID As New DataColumn("CustID", GetType(Integer))
            Dim cOrderDate As New DataColumn("OrderDate", GetType(DateTime))
            Dim cOrderAmount As New DataColumn("OrderAmount", GetType(String))
            tOrders.Columns.Add(cID)
            tOrders.Columns.Add(cOrderAmount)
            tOrders.Columns.Add(cOrderDate)

            ' Add the tables to the 'DataSet'.
            myDataSet.Tables.Add(tCust)
            myDataSet.Tables.Add(tOrders)

            ' Create a 'DataRelation' and add it to the 'DataSet'.
            Dim dr As New DataRelation("custToOrders", cCustID, cID)
            myDataSet.Relations.Add(dr)

            ' Populate the tables. For each customer and order, 
            ' create need two 'DataRow' variables. 
            Dim newRow1 As DataRow
            Dim newRow2 As DataRow

            ' Create three customers in the 'Customers Table'.
            Dim i As Integer
            For i = 1 To 3
                newRow1 = tCust.NewRow()
                newRow1("custID") = i
                ' Add the row to the 'Customers Table'.
                tCust.Rows.Add(newRow1)
            Next i
            ' Give each customer a distinct name.
            tCust.Rows(0)("custName") = "Alpha"
            tCust.Rows(1)("custName") = "Beta"
            tCust.Rows(2)("custName") = "Omega"

            ' Give the current column a value.
            tCust.Rows(0)("Current") = True
            tCust.Rows(1)("Current") = True
            tCust.Rows(2)("Current") = False

            ' For each customer, create five rows in the orders table.
            Dim myNumber As Double = 0
            Dim myString As String


            For i = 1 To 3
                Dim j As Integer
                For j = 1 To 5
                    newRow2 = tOrders.NewRow()
                    newRow2("CustID") = i
                    newRow2("orderDate") = New DateTime(2001, i, j * 2)
                    myNumber = i * 10 + j * 0.1
                    myString = "$ "
                    myString += myNumber.ToString()
                    newRow2("OrderAmount") = myString
                    ' Add the row to the orders table.
                    tOrders.Rows.Add(newRow2)
                Next j
            Next i
        End Sub 'MakeDataSet

        Private Sub btnSetSelectionBkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSeSelectiontBkColor.Click
' <Snippet1> 
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help.
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.SelectionBackColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set selection background color to selected color.
            myDataGrid.SelectionBackColor = myColorDialog.Color
  ' </Snippet1>
      End Sub 'btnSetSelectionBkColor_Click
        Private Sub btnResetSelectionBkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetSelectionBkColor.Click
' <Snippet2>
            ' String variable used to show message.
            Dim myString As String = "Selection backgound color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.SelectionBackColor
            myString += myCurrentColor.ToString()
            ' Reset selection background color to default.
            myDataGrid.ResetSelectionBackColor()
            myString += "  to "
            myString += myDataGrid.SelectionBackColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Selection background color information")
  ' </Snippet2>    
      End Sub 'btnResetSelectionBkColor_Click

        Private Sub btnSetSelectionForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetSelectionForeColor.Click
' <Snippet3>
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help. 
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.SelectionForeColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set selection foreground color to selected color.
            myDataGrid.SelectionForeColor = myColorDialog.Color
  ' </Snippet3>        
      End Sub 'btnSetSelectionForeColor_Click
      
        Private Sub btnResetSelectionForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetSelectionForeColor.Click
' <Snippet4>
            ' String variable used to show message.   
            Dim myString As String = "Selection foreground color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.SelectionForeColor
            myString += myCurrentColor.ToString()
            ' Reset selection foreground color to default.
            myDataGrid.ResetSelectionForeColor()
            myString += "  to "
            myString += myDataGrid.SelectionForeColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Selection foreground color information")
   ' </Snippet4> 
      End Sub 'btnResetSelectionForeColor_Click

        Private Sub btnSetForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetForeColor.Click
' <Snippet5>
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help. 
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.ForeColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set foreground color to selected color.
            myDataGrid.ForeColor = myColorDialog.Color
  ' </Snippet5> 
    End Sub 'btnSetForeColor_Click

        Private Sub btnResetForeColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetForeColor.Click
' <Snippet6>
            ' String variable used to show message.   
            Dim myString As String = "Foreground color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.ForeColor
            myString += myCurrentColor.ToString()
            ' Reset foreground color to default.
            myDataGrid.ResetForeColor()
            myString += "  to "
            myString += myDataGrid.ForeColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Foreground color information")
  ' </Snippet6>   
         End Sub 'btnResetForeColor_Click

        Private Sub btnSetBkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetBkColor.Click
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help. 
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.BackColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set background color to selected color.
            myDataGrid.BackColor = myColorDialog.Color
        End Sub 'btnSetBkColor_Click

        Private Sub btnResetBkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetBkColor.Click
' <Snippet7>
            ' String variable used to show message.   
            Dim myString As String = "Backgound color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.BackColor
            myString += myCurrentColor.ToString()
            ' Reset background color to default.
            myDataGrid.ResetBackColor()
            myString += "  to "
            myString += myDataGrid.BackColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Background color information")
 ' </Snippet7>   
      End Sub 'btnResetBkColor_Click

        Private Sub btnResetGridLineColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetGridLineColor.Click
' <Snippet8>
            ' String variable used to show message.   
            Dim myString As String = "Grid line color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.GridLineColor
            myString += myCurrentColor.ToString()
            ' Reset grid line color to default.
            myDataGrid.ResetGridLineColor()
            myString += "  to "
            myString += myDataGrid.GridLineColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Grid line color information")
 ' </Snippet8>      
      End Sub 'btnResetGridLineColor_Click

        Private Sub btnResetLinkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetLinkColor.Click
' <Snippet9>
            ' String variable used to show message.   
            Dim myString As String = "Link color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.LinkColor
            myString += myCurrentColor.ToString()
            ' Reset link color to default.
            myDataGrid.ResetLinkColor()
            myString += "  to "
            myString += myDataGrid.LinkColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Link line color information")
' </Snippet9>
       End Sub 'btnResetLinkColor_Click

        Private Sub btnResetAlternatingBackColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetAlternatingBackColor.Click
' <Snippet10>
            ' String variable used to show message.   
            Dim myString As String = "Alternating back color changed from: "
            ' Store current foreground color of selected cells.
            Dim myCurrentColor As Color = myDataGrid.AlternatingBackColor
            myString += myCurrentColor.ToString()
            ' Reset alternating back color to default.
            myDataGrid.ResetAlternatingBackColor()
            myString += "  to "
            myString += myDataGrid.AlternatingBackColor.ToString()
            ' Show information about changes in color setting.  
            MessageBox.Show(myString, "Alternating back color information")
 ' </Snippet10>  
      End Sub 'btnResetAlternatingBackColor_Click

        Private Sub btnSetGridLineColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetGridLineColor.Click
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help. 
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.GridLineColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set grid line color to selected color.
            myDataGrid.GridLineColor = myColorDialog.Color
        End Sub 'btnSetGridLineColor_Click

        Private Sub btnSetLinkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetLinkColor.Click
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help. 
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.LinkColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set link color to selected color.
            myDataGrid.LinkColor = myColorDialog.Color
        End Sub 'btnSetLinkColor_Click

        Private Sub btnSetAlternatingBkColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetAlternatingBkColor.Click
            ' Creates a common color dialog box.
            Dim myColorDialog As New ColorDialog()
            ' Keep the user from selecting a custom color.
            myColorDialog.AllowFullOpen = False
            ' Allow the user to get help. 
            myColorDialog.ShowHelp = True
            ' Set the initial color select to the current color.
            myColorDialog.Color = myDataGrid.AlternatingBackColor
            ' Show color dialog box.
            myColorDialog.ShowDialog()
            ' Set alternating background color to selected color.
            myDataGrid.AlternatingBackColor = myColorDialog.Color
        End Sub 'btnSetAlternatingBkColor_Click
    End Class 'DatGridClass
End Namespace 'DataGridSample