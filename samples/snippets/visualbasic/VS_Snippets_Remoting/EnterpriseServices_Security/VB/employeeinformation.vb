' <snippet0>
Imports System
Imports System.EnterpriseServices


' <snippet1>
' Set component name and strong name key.
<Assembly: ApplicationName("EmployeeInformation")> 
<Assembly: System.Reflection.AssemblyKeyFile("EmployeeInformation.snk")> 
' </snippet1>

' <snippet2>
' Set component access controls.
<Assembly: ApplicationAccessControl(Authentication:=AuthenticationOption.Privacy, ImpersonationLevel:=ImpersonationLevelOption.Identify, AccessChecksLevel:=AccessChecksLevelOption.ApplicationComponent)> 
' </snippet2>

' <snippet3>
' Create a security role for the component.
<Assembly: SecurityRole("Manager")> 
' </snippet3>

' <snippet4>
' Accept a constructor string.
<ConstructionEnabled()>  _
Public Class EmployeeInformation
    
    Inherits ServicedComponent
    
    ' The employee's user name and salary.
    Private accountName As String
    Private salary As Double = 0
    
    ' <snippet5>
    ' Get the employee's name. All users can call this method.
    Public Function GetName() As String 
        Return accountName
    
    End Function 'GetName
    ' </snippet5>
    
    ' <snippet6>
    ' Set the employee's salary. Only managers can do this.
    Public Sub SetSalary(ByVal ammount As Double) 
        If SecurityCallContext.CurrentCall.IsCallerInRole("Manager") Then
            salary = ammount
        Else
            Throw New UnauthorizedAccessException()
        End If
    
    End Sub 'SetSalary
    ' </snippet6>
    
    ' <snippet7>
    ' Get the employee's salary. Only the employee and managers can do this.
    Public Function GetSalary() As Double 
        If SecurityCallContext.CurrentCall.DirectCaller.AccountName = accountName OrElse SecurityCallContext.CurrentCall.IsCallerInRole("Manager") Then
            Return salary
        Else
            Throw New UnauthorizedAccessException()
        End If
    
    End Function 'GetSalary
    ' </snippet7>
    
    ' <snippet8>
    ' Use the constructor string.
    ' This method is called when the object is instantiated.
    Protected Overrides Sub Construct(ByVal constructorString As String) 
        accountName = constructorString
    
    End Sub 'Construct
    ' </snippet8>

End Class 'EmployeeInformation
' </snippet4>
' </snippet0>

'added to make it compile
Public Class Test

    Public Shared Sub Main()

    End Sub 'Main
End Class 'Test
