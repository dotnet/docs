Imports Microsoft.VisualBasic

' <Snippet5>
Public Class EmployeeLogic
    Public Shared Function GetFullNamesAndIDs() As Array
        Dim ndc As New NorthwindDataContext()

        Dim employeeQuery = _
            From e In ndc.Employees _
            Order By e.LastName _
            Select FullName = e.FirstName + " " + e.LastName, EmployeeID = e.EmployeeID

        Return employeeQuery.ToArray()
    End Function

    Public Shared Function GetEmployee(ByVal empID As Integer) As Employee

        If (empID < 0) Then
            Return Nothing
        Else
            Dim ndc As New NorthwindDataContext()
            Dim employeeQuery = _
                From e In ndc.Employees _
                Where e.EmployeeID = empID _
                Select e

            Return employeeQuery.Single()
        End If
    End Function

    Public Shared Sub UpdateEmployeeAddress(ByVal originalEmployee As Employee, ByVal address As String, ByVal city As String, ByVal postalcode As String)

        Dim ndc As New NorthwindDataContext()
        ndc.Employees.Attach(originalEmployee, False)
        originalEmployee.Address = address
        originalEmployee.City = city
        originalEmployee.PostalCode = postalcode
        ndc.SubmitChanges()
    End Sub
End Class
' </Snippet5>
