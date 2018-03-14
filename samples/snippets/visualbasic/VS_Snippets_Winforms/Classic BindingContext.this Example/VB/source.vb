Imports System
Imports System.Collections
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected Text1 As TextBox
 Protected myDataView As DataView
 Protected myArrayList As ArrayList
' <Snippet1>
Private Sub ReturnBindingManagerBase()
   ' Get the BindingManagerBase for a DataView. 
   Dim bmCustomers As BindingManagerBase = _
      Me.BindingContext(myDataView)

   ' Get the BindingManagerBase for an ArrayList.
   Dim bmOrders As BindingManagerBase = _
      Me.BindingContext(myArrayList)

   ' Get the BindingManagerBase for a TextBox control.
   Dim baseArray As BindingManagerBase = _
      Me.BindingContext(Text1.DataBindings(0).DataSource)
End Sub

' </Snippet1>
End Class
