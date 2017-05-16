 ' <snippet0>
Imports System
Imports System.EnterpriseServices

<Assembly: ApplicationName("Calculator")> 
<Assembly: ApplicationActivation(ActivationOption.Library)> 
<Assembly: System.Reflection.AssemblyKeyFile("Calculator.snk")> 


Public Class Calculator
    Inherits ServicedComponent
    
    Public Function Add(ByVal x As Integer, ByVal y As Integer) As Integer 
        Return x + y
    
    End Function 'Add
End Class 'Calculator
' </snippet0>

Public Class Test
    
    Public Shared Sub Main() 
    
    End Sub 'Main
End Class 'Test 

