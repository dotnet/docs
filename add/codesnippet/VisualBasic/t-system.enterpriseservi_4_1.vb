Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

<Assembly: ApplicationQueuing()> 

Public Class ApplicationQueuingExample
    Inherits ServicedComponent
    
    Public Sub ApplicationQueuingAttribute_Enabled() 
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

    End Sub 'ApplicationQueuingAttribute_Enabled



    Public Sub ApplicationQueuingAttribute_QueueListenerEnabled()
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

    End Sub 'ApplicationQueuingAttribute_QueueListenerEnabled



    Public Sub ApplicationQueuingAttribute_MaxListenerThreads()
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
    End Sub 'ApplicationQueuingAttribute_MaxListenerThreads

End Class 'ApplicationQueuingExample
