Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Namespace MyNameSpace
    
    Class MyDataGridColumnStyle
        Inherits DataGridTextBoxColumn
        Private myCurrencyManager As CurrencyManager
        Private dataGrid1 As DataGrid
        
        ' <Snippet1>
Private Sub UpdateGridUI()
   ' Get the MyDataGridColumnStyle to update.
   ' MyDataGridColumnStyle is a class derived from DataGridColumnStyle.
   Dim myGridColumn As MyDataGridColumnStyle = CType _
   (dataGrid1.TableStyles(0).GridColumnStyles("CompanyName"), _
   MyDataGridColumnStyle)
   ' Call UpdateUI.
   myGridColumn.UpdateUI(myCurrencyManager, 10, "my new value")
End Sub 
        ' </Snippet1>

        Protected Sub SetMyVars (dataGrid2 As DataGrid, curMan2 As CurrencyManager)
            myCurrencyManager = curMan2
            dataGrid1 = dataGrid2
        End Sub 'SetMyVars
        
        
        Protected Overrides Overloads Sub Edit(source As System.Windows.Forms.CurrencyManager, rowNum As Integer, bounds As System.Drawing.Rectangle, readOnly1 As Boolean, displayText As String, cellIsVisiblen As Boolean)
        End Sub 'Edit
         
        
        Protected Overrides Function Commit(dataSource As System.Windows.Forms.CurrencyManager, rowNum As Integer) As Boolean
            Return True
        End Function 'Commit
        
        
        Protected Overrides Function GetPreferredSize(g As System.Drawing.Graphics, value As Object) As System.Drawing.Size
            Return New Size(New Point(1, 2))
        End Function 'GetPreferredSize
        
        
        Protected Overrides Function GetPreferredHeight(g As System.Drawing.Graphics, value As Object) As Integer
            Return 1
        End Function 'GetPreferredHeight
        
        
        Protected Overrides Function GetMinimumHeight() As Integer
            Return 1
        End Function 'GetMinimumHeight
        
        
        Protected Overrides Sub Abort(rowNum As Integer)
        End Sub 'Abort
         
        
        Overloads Protected Overrides Sub Paint(g As System.Drawing.Graphics, bounds As System.Drawing.Rectangle, source As System.Windows.Forms.CurrencyManager, rowNum As Integer, b As Boolean)
        End Sub 'Paint
        
        
        Overloads Protected Overrides Sub Paint(g As System.Drawing.Graphics, bounds As System.Drawing.Rectangle, source As System.Windows.Forms.CurrencyManager, rowNum As Integer)
        End Sub 'Paint 
    End Class 'MyDataGridColumnStyle
End Namespace 'MyNameSpace
