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