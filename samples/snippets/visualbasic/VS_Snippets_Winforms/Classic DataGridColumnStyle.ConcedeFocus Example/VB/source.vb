Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Namespace MyNameSpace
    
    Class MyDataGridColumnStyle
        Inherits DataGridTextBoxColumn
        
        ' <Snippet1>
        Protected Overrides Sub ConcedeFocus()
            ' Hide the TextBox when conceding focus.
            MyBase.TextBox.Visible = False
        End Sub 'ConcedeFocus
        ' </Snippet1>

        Protected Overloads Overrides Sub Edit(source As System.Windows.Forms.CurrencyManager, rowNum As Integer, bounds As System.Drawing.Rectangle, readOnly1 As Boolean, displayText As String, cellIsVisiblen As Boolean)
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
