' <snippet0>
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<Assembly: ApplicationQueuing()> 
' </snippet1>

Public Class ApplicationQueuingExample
    Inherits ServicedComponent
    
    Public Sub ApplicationQueuingAttribute_Enabled() 
        ' <snippet2>
        ' This example code requires that an ApplicationQueuing attribute be
        ' applied to the assembly, as shown below:
        ' [assembly: ApplicationQueuing]
        ' Get the ApplicationQueuingAttribute applied to the assembly.
        Dim attribute As ApplicationQueuingAttribute = CType(Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), GetType(ApplicationQueuingAttribute), False), ApplicationQueuingAttribute)
        
        ' Display the current value of the attribute's Enabled property.
        MsgBox("ApplicationQueuingAttribute.Enabled: " & attribute.Enabled)

        ' Set the Enabled property value of the attribute.
        attribute.Enabled = False
        
        ' Display the new value of the attribute's Enabled property.
        MsgBox("ApplicationQueuingAttribute.Enabled: " & attribute.Enabled)

        ' </snippet2>
    End Sub



    Public Sub ApplicationQueuingAttribute_QueueListenerEnabled()
        ' <snippet3>
        ' This example code requires that an ApplicationQueuing attribute be
        ' applied to the assembly, as shown below:
        ' [assembly: ApplicationQueuing]
        ' Get the ApplicationQueuingAttribute applied to the assembly.
        Dim attribute As ApplicationQueuingAttribute = CType(attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), GetType(ApplicationQueuingAttribute), False), ApplicationQueuingAttribute)

        ' Display the current value of the attribute's QueueListenerEnabled
        ' property.
        MsgBox("ApplicationQueuingAttribute.QueueListenerEnabled: " & attribute.Enabled)

        ' Set the QueueListenerEnabled property value of the attribute.
        attribute.QueueListenerEnabled = False

        ' Display the new value of the attribute's QueueListenerEnabled
        ' property.
        MsgBox("ApplicationQueuingAttribute.QueueListenerEnabled: " & attribute.QueueListenerEnabled)

        ' </snippet3>
    End Sub



    Public Sub ApplicationQueuingAttribute_MaxListenerThreads()
        ' <snippet4>
        ' This example code requires that an ApplicationQueuing attribute be
        ' applied to the assembly, as shown below:
        ' [assembly: ApplicationQueuing]
        ' Get the ApplicationQueuingAttribute applied to the assembly.
        Dim attribute As ApplicationQueuingAttribute = CType(attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), GetType(ApplicationQueuingAttribute), False), ApplicationQueuingAttribute)

        ' Display the current value of the attribute's MaxListenerThreads
        ' property.
        MsgBox("ApplicationQueuingAttribute.MaxListenerThreads: " & attribute.MaxListenerThreads)

        ' Set the MaxListenerThreads property value of the attribute.
        attribute.MaxListenerThreads = 1

        ' Display the new value of the attribute's MaxListenerThreads
        ' property.
        MsgBox("ApplicationQueuingAttribute.MaxListenerThreads: " & attribute.MaxListenerThreads)
        ' </snippet4>
    End Sub

End Class

' </snippet0>

' Test client

Public Class TestClient
    
    Public Shared Sub Main() 
        ' Create a new instance of the example class.
        'Dim example As New ApplicationQueuingExample()
        
        ' Demonstrate the ApplicationQueuingAttribute properties.
        'example.ApplicationQueuingAttribute_Enabled()
        'example.ApplicationQueuingAttribute_QueueListenerEnabled()
        'example.ApplicationQueuingAttribute_MaxListenerThreads()
    
    End Sub
End Class