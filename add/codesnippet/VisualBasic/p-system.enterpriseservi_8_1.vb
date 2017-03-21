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
