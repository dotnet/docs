'<Snippet1>
Imports System

Module DemoModule
	' This attribute is only valid on a class.
	<AttributeUsage(AttributeTargets.Class)> _
	Public Class ClassTargetAttribute
        Inherits Attribute
	End Class

	' This attribute is only valid on a method.
	<AttributeUsage(AttributeTargets.Method)> _
	Public Class MethodTargetAttribute
        Inherits Attribute
	End Class

	' This attribute is only valid on a constructor.
	<AttributeUsage(AttributeTargets.Constructor)> _
	Public Class ConstructorTargetAttribute 
        Inherits Attribute
	End Class

	' This attribute is only valid on a field.
	<AttributeUsage(AttributeTargets.Field)> _
	Public Class FieldTargetAttribute 
        Inherits Attribute
	End Class

	' This attribute is valid on a class or a method.
	<AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method)> _
	Public Class ClassMethodTargetAttribute 
        Inherits Attribute
	End Class

	' This attribute is valid on any target.
	<AttributeUsage(AttributeTargets.All)> _
	Public Class AllTargetsAttribute 
        Inherits Attribute
	End Class

	<ClassTarget, _
	ClassMethodTarget, _
	AllTargets> _
	Public Class TestClassAttribute
		<ConstructorTarget, _
		AllTargets> _
		Public Sub New
		End Sub

		<MethodTarget, _
		ClassMethodTarget, _
		AllTargets> _
		Public Sub Method1()
		End Sub

		<FieldTarget, _
		AllTargets> _
		Public myInt as Integer
	End Class

	Sub Main()
	End Sub
End Module
'</Snippet1>