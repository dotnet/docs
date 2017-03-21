    ' Set the employee's salary. Only managers can do this.
    Public Sub SetSalary(ByVal ammount As Double) 
        If SecurityCallContext.CurrentCall.IsCallerInRole("Manager") Then
            salary = ammount
        Else
            Throw New UnauthorizedAccessException()
        End If
    
    End Sub 'SetSalary