'<Snippet2>
Public Class Employee
    'Create employee level property.
    Public Property Emlevel As Integer
        Get
            Return emlevelValue
        End Get
        Set
            emlevelValue = Value
        End Set
    End Property

    Private emlevelValue As Integer = 0
End Class

Public Class Ex13
    Public Shared Sub PromoteEmployee(emp As Object)
        ' Cast object to Employee.
        Dim e As Employee = CType(emp, Employee)
        ' Increment employee level.
        e.Emlevel = e.Emlevel + 1
    End Sub

    Public Shared Sub Main()
        Try
            Dim o As Object = New Employee()
            Dim newYears As New DateTime(2001, 1, 1)
            ' Promote the new employee.
            PromoteEmployee(o)
            ' Promote DateTime; results in InvalidCastException as newYears is not an employee instance.
            PromoteEmployee(newYears)
        Catch e As InvalidCastException
            Console.WriteLine("Error passing data to PromoteEmployee method. " + e.Message)
        End Try
    End Sub
End Class
'</Snippet2>
