' Accept a constructor string.
<ConstructionEnabled()>  _
Public Class EmployeeInformation
    
    Inherits ServicedComponent
    
    ' The employee's user name and salary.
    Private accountName As String
    Private salary As Double = 0
    
    ' Get the employee's name. All users can call this method.
    Public Function GetName() As String 
        Return accountName
    
    End Function 'GetName
    
    ' Set the employee's salary. Only managers can do this.
    Public Sub SetSalary(ByVal ammount As Double) 
        If SecurityCallContext.CurrentCall.IsCallerInRole("Manager") Then
            salary = ammount
        Else
            Throw New UnauthorizedAccessException()
        End If
    
    End Sub 'SetSalary
    
    ' Get the employee's salary. Only the employee and managers can do this.
    Public Function GetSalary() As Double 
        If SecurityCallContext.CurrentCall.DirectCaller.AccountName = accountName OrElse SecurityCallContext.CurrentCall.IsCallerInRole("Manager") Then
            Return salary
        Else
            Throw New UnauthorizedAccessException()
        End If
    
    End Function 'GetSalary
    
    ' Use the constructor string.
    ' This method is called when the object is instantiated.
    Protected Overrides Sub Construct(ByVal constructorString As String) 
        accountName = constructorString
    
    End Sub 'Construct

End Class 'EmployeeInformation