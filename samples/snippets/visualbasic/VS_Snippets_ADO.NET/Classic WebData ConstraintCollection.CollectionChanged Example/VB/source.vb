Imports System
Imports System.Data

Public Class Sample
    
Public Shared Sub Main()
  ConstraintCollectionChanged()
End Sub

' <Snippet1>
Private Shared Sub ConstraintCollectionChanged()
	' Demonstrate ConstraintCollection.CollectionChanged event.
	Try
		' Create Customers table.
		Dim customersTable As DataTable = New DataTable("Customers")
		customersTable.Columns.Add("id", Type.GetType("System.Int32"))
		customersTable.Columns.Add("Name", Type.GetType("System.String"))
		AddHandler customersTable.Constraints.CollectionChanged, _ 
			New System.ComponentModel.CollectionChangeEventHandler( _
            AddressOf Collection_Changed)

		' Create Orders table.
		Dim ordersTable As DataTable = New DataTable("Orders")
		ordersTable.Columns.Add("CustID", Type.GetType("System.Int32"))
		ordersTable.Columns.Add("CustName", Type.GetType("System.String"))
		AddHandler ordersTable.Constraints.CollectionChanged, _
			New System.ComponentModel.CollectionChangeEventHandler( _
            AddressOf Collection_Changed)

		' Create unique constraint.
		Dim constraint As UniqueConstraint = New _
            UniqueConstraint(customersTable.Columns("id"))
		customersTable.Constraints.Add(constraint)
		
		' Create unique constraint and specify as primary key.
		ordersTable.Constraints.Add( _
            "pKey", ordersTable.Columns("CustID"), True)

		' Remove constraints.
		customersTable.Constraints.RemoveAt( 0)

		' Results in an Exception. You can't remove 
        ' a primary key constraint.
		ordersTable.Constraints.RemoveAt( 0) 
 
	Catch ex As Exception
		' Process exception and return.
        Console.WriteLine("Exception of type {0} occurred.", _
            ex.GetType().ToString())
	End Try
End Sub

Private Shared Sub Collection_Changed( sender As object, _
    ex As System.ComponentModel.CollectionChangeEventArgs)
	Console.WriteLine("List_Changed Event: '{0}'\t element={1}", _
        ex.Action, ex.Element)
End Sub
' </Snippet1>
End Class
