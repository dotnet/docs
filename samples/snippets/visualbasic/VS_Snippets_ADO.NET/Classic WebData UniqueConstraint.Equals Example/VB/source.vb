imports System
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub CompareConstraints()
    Dim constraintCustomerOrders As UniqueConstraint
    Dim constraintOrderDetails As UniqueConstraint
    Dim relationCustomerOrders As DataRelation
    Dim relationOrderDetails As DataRelation

    ' Get a DataRelation from a DataSet.
    relationCustomerOrders = DataSet1.Relations("CustomerOrders")

    '  Get a constraint.
    constraintCustomerOrders = relationCustomerOrders.ParentKeyConstraint

    ' Get a second relation and constraint.
    relationOrderDetails = DataSet1.Relations("OrderDetails")
    constraintOrderDetails = relationOrderDetails.ParentKeyConstraint

    ' Compare the two.
    Console.WriteLine( _
        constraintCustomerOrders.Equals(constraintOrderDetails).ToString())
 End Sub
   ' </Snippet1>

End Class
