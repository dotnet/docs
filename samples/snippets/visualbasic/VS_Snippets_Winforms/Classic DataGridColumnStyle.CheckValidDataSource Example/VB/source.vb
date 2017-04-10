Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms


Namespace MyNameSpace
    
    Class MyDataGridColumnStyle
        Inherits DataGridColumnStyle
        
        ' <Snippet1>
        Private Sub CheckCurrencyManager(myCurrencyManager As CurrencyManager)
            ' This code is from a class named MyDataGridColumnStyle derived
            ' from DataGridColumnStyle.
            Dim myGridColumn As MyDataGridColumnStyle = Me
            Try
                myGridColumn.CheckValidDataSource(myCurrencyManager)
            Catch e As ArgumentNullException
                Console.WriteLine(e.Message)
            Catch e As ApplicationException
                Console.WriteLine(e.Message)
            End Try
        End Sub 'CheckCurrencyManager
        ' </Snippet1>

        Overloads Protected Overrides Sub Edit(source As System.Windows.Forms.CurrencyManager, rowNum As Integer, bounds As System.Drawing.Rectangle, readOnly1 As Boolean, displayText As String, cellIsVisiblen As Boolean)
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