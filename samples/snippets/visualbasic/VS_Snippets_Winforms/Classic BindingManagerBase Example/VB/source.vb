Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
   Inherits Form

   Protected textBox1 As TextBox
   Protected DataSet1 As DataSet
   Protected myBindingManagerBase As BindingManagerBase

   ' <Snippet1>
   Private Sub GetBindingManagerBase
      ' CustomersToOrders is the RelationName of a DataRelation.
      ' Therefore, the list maintained by the BindingManagerBase is the
      ' list of orders that belong to a specific customer in the
      ' DataTable named Customers, found in DataSet.
      myBindingManagerBase = Me.BindingContext(DataSet1, _
      "Customers.CustomersToOrders")

      ' Adds delegates to the CurrentChanged and PositionChanged events.
      AddHandler myBindingManagerBase.PositionChanged, _
      AddressOf BindingManagerBase_PositionChanged
      AddHandler myBindingManagerBase.CurrentChanged, _
      AddressOf BindingManagerBase_CurrentChanged
   End Sub

   Private Sub BindingManagerBase_PositionChanged _
   (sender As Object, e As EventArgs)

      ' Prints the new Position of the BindingManagerBase.
      Console.Write("Position Changed: ")
      Console.WriteLine(CType(sender, BindingManagerBase).Position)
   End Sub

   Private Sub BindingManagerBase_CurrentChanged _
   (sender As Object, e As EventArgs)

      ' Prints the new value of the current object.
      Console.Write("Current Changed: ")
      Console.WriteLine(CType(sender, BindingManagerBase).Current)
   End Sub

   Private Sub MoveNext
      ' Increments the Position property value by one.
      myBindingManagerBase.Position += 1
   End Sub

   Private Sub MovePrevious
      ' Decrements the Position property value by one.
      myBindingManagerBase.Position -= 1
   End Sub

   Private Sub MoveFirst
      ' Goes to the first row in the list.
      myBindingManagerBase.Position = 0
   End Sub

   Private Sub MoveLast
      ' Goes to the last row in the list.
      myBindingManagerBase.Position = _
      myBindingManagerBase.Count - 1
   End Sub
   ' </Snippet1>
End Class