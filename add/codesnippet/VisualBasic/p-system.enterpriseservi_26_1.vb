    ' Get the employee's salary. Only the employee and managers can do this.
    Public Function GetSalary() As Double 
        If SecurityCallContext.CurrentCall.DirectCaller.AccountName = accountName OrElse SecurityCallContext.CurrentCall.IsCallerInRole("Manager") Then
            Return salary
        Else
            Throw New UnauthorizedAccessException()
        End If
    
    End Function 'GetSalary