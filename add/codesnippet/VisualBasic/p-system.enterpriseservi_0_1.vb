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
