Imports System
Imports System.Data

Public Class Sample

' <Snippet1>
 Public Shared Sub RemoveConstraint( _
    constraints As ConstraintCollection, constraint As Constraint)
	Try
		If constraints.Contains(constraint.ConstraintName) Then
			If constraints.CanRemove(constraint)
				constraints.Remove(constraint.ConstraintName)
			End If
		End If

	Catch e As Exception
		' Process exception and return.
        Console.WriteLine("Exception of type {0} occurred.", _
            e.GetType().ToString())
	End Try
 End Sub
' </Snippet1>
End Class

