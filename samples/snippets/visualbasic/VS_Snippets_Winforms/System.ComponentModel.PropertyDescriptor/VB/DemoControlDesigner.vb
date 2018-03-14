 ' <snippet10>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports System.Windows.Forms.Design

Class DemoControlDesigner
    Inherits ControlDesigner
    
    ' The PostFilterProperties method replaces the control's 
    ' Size property with a read-only Size property by using 
    ' the SerializeReadOnlyPropertyDescriptor class.
    Protected Overrides Sub PostFilterProperties(ByVal properties As IDictionary) 
        If properties.Contains("Size") Then
            Dim original As PropertyDescriptor = properties("Size")
            
            Dim readOnlyDescriptor As New SerializeReadOnlyPropertyDescriptor(original)
            
            properties("Size") = readOnlyDescriptor
        End If
        
        MyBase.PostFilterProperties(properties)
    
    End Sub
End Class
' </snippet10>