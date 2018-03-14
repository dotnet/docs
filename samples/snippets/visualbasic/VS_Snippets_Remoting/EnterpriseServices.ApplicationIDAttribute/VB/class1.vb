' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
' The GUID (Globally Unique Identifier) shown below is for example purposes
' only and should be replaced by a GUID that you have generated.
<Assembly: ApplicationID("727FC170-1D80-4e89-84CC-22AAB10A6F24")> 
' </snippet1>

Public Class ApplicationIDAttribute_Value
    Inherits ServicedComponent
    
    Public Sub ValueExample() 
        ' Get the ApplicationIDAttribute applied to the assembly.
        Dim attribute As ApplicationIDAttribute = CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), GetType(ApplicationIDAttribute), False), ApplicationIDAttribute)
        
        ' Display the value of the attribute's Value property.
        MsgBox("ApplicationIDAttribute.Value: " & attribute.Value.ToString())

    End Sub 'ValueExample
End Class 'ApplicationIDAttribute_Value

' </snippet0>

' Test client code

Public Class ApplicationIDAttribute_Example
    
    Public Shared Sub Main() 
        ' Create a new instance of each example class.
        Dim valueExample As New ApplicationIDAttribute_Value()
        
        ' Demonstrate the ApplicationIDAttribute properties.
        valueExample.ValueExample()
    
    End Sub 'Main
End Class 'ApplicationIDAttribute_Example
