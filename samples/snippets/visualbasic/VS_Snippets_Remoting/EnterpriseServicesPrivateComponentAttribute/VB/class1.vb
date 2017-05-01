' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
' Note: Access checks must be performed at the component level to allow access
' to private components.

<assembly: ApplicationAccessControl(False, AccessChecksLevel := AccessChecksLevelOption.ApplicationComponent)>


<PrivateComponent()>  _
Public Class PrivateComponentAttribute_Example
    Inherits ServicedComponent
    
    Public Sub Example() 
        ' Display some output.
        MsgBox("Private component called successfully.")
    
    End Sub 'Example
End Class 'PrivateComponentAttribute_Example
' </snippet1>

Public Class PrivateComponentAttribute_Test
    Inherits ServicedComponent
    
    Public Sub Test() 
        ' Create a new instance of the example class.
        Dim example As New PrivateComponentAttribute_Example()
        
        ' Call a method on the class.
        example.Example()
    
    End Sub 'Test
End Class 'PrivateComponentAttribute_Test
' </snippet0>

'add Main so code compiles
Public Class Test
    
    Public Shared Sub Main() 
    
    End Sub 'Main
End Class 'Test 
