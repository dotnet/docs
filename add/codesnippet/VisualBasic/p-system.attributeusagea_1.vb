<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method _ 
                Or AttributeTargets.Property Or AttributeTargets.Field, 
                Inherited := True)>
Public Class InheritedAttribute : Inherits Attribute
End Class

<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method _
                Or AttributeTargets.Property Or AttributeTargets.Field, 
                Inherited := False)>
Public Class NotInheritedAttribute : Inherits Attribute
End Class