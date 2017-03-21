<ObjectPooling(False)>  _
Public Class ObjectPoolingAttribute_Enabled
    Inherits ServicedComponent
    
    Public Sub EnabledExample() 
        ' Get the ObjectPoolingAttribute applied to the class.
        Dim attribute As ObjectPoolingAttribute = CType(Attribute.GetCustomAttribute(Me.GetType(), GetType(ObjectPoolingAttribute), False), ObjectPoolingAttribute)
        
        ' Display the current value of the attribute's Enabled property.
        MsgBox("ObjectPoolingAttribute.Enabled: " & attribute.Enabled)
        
        ' Set the Enabled property value of the attribute.
        attribute.Enabled = True
        
        ' Display the new value of the attribute's Enabled property.
        MsgBox("ObjectPoolingAttribute.Enabled: " & attribute.Enabled)
    
    End Sub 'EnabledExample
End Class 'ObjectPoolingAttribute_Enabled