Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
   Inherits Form

   Protected text1 As TextBox
   Protected ds As DataSet
   ' <Snippet1>
   Private Sub PrintBoundControls1
      ' Gets the BindingManagerBase for the Customers table.
      Dim myBindingBase As BindingManagerBase = _
      Me.BindingContext(ds, "Customers")

      ' Prints the information of each control managed by
      ' the BindingManagerBase.
      Dim b As Binding
      For Each b In myBindingBase.Bindings
         Console.WriteLine(b.Control.ToString)
      Next
   End Sub

   Private Sub PrintBoundControls2
      ' Gets the BindingManagerBase for a child table of
      ' the Customers table. The RelationName of a DataRelation
      ' is appended to the parent table's name.
      Dim myBindingBase As BindingManagerBase = _
      Me.BindingContext(ds, "Customers.CustToOrders")


      ' Prints the information of each control managed by
      ' the BindingManagerBase.
      Dim b As Binding
      For Each b In myBindingBase.Bindings
         Console.WriteLine(b.Control.ToString)
      Next
   End Sub
	' </Snippet1>
End Class
