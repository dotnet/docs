Imports System
Imports System.Diagnostics.CodeAnalysis
Imports System.Globalization
Imports System.Reflection

' <snippet_InvokeMember>
Class MyType
    Implements IReflect

    <DynamicallyAccessedMembers(
        DynamicallyAccessedMemberTypes.PublicFields Or
        DynamicallyAccessedMemberTypes.NonPublicFields Or
        DynamicallyAccessedMemberTypes.PublicMethods Or
        DynamicallyAccessedMemberTypes.NonPublicMethods Or
        DynamicallyAccessedMemberTypes.PublicProperties Or
        DynamicallyAccessedMemberTypes.NonPublicProperties Or
        DynamicallyAccessedMemberTypes.PublicConstructors Or
        DynamicallyAccessedMemberTypes.NonPublicConstructors)>
    Public Function InvokeMember(
        name As String,
        invokeAttr As BindingFlags,
        binder As Binder,
        target As Object,
        args As Object(),
        modifiers As ParameterModifier(),
        culture As CultureInfo,
        namedParameters As String()) As Object Implements IReflect.InvokeMember
        Throw New NotImplementedException()
    End Function

    Public Function GetField(name As String, bindingAttr As BindingFlags) As FieldInfo Implements IReflect.GetField
        Throw New NotImplementedException()
    End Function

    Public Function GetFields(bindingAttr As BindingFlags) As FieldInfo() Implements IReflect.GetFields
        Throw New NotImplementedException()
    End Function

    Public Function GetMember(name As String, bindingAttr As BindingFlags) As MemberInfo() Implements IReflect.GetMember
        Throw New NotImplementedException()
    End Function

    Public Function GetMembers(bindingAttr As BindingFlags) As MemberInfo() Implements IReflect.GetMembers
        Throw New NotImplementedException()
    End Function

    Public Function GetMethod(name As String, bindingAttr As BindingFlags) As MethodInfo Implements IReflect.GetMethod
        Throw New NotImplementedException()
    End Function

    Public Function GetMethod(name As String, bindingAttr As BindingFlags, binder As Binder, types As Type(), modifiers As ParameterModifier()) As MethodInfo Implements IReflect.GetMethod
        Throw New NotImplementedException()
    End Function

    Public Function GetMethods(bindingAttr As BindingFlags) As MethodInfo() Implements IReflect.GetMethods
        Throw New NotImplementedException()
    End Function

    Public Function GetProperties(bindingAttr As BindingFlags) As PropertyInfo() Implements IReflect.GetProperties
        Throw New NotImplementedException()
    End Function

    Public Function GetProperty(name As String, bindingAttr As BindingFlags) As PropertyInfo Implements IReflect.GetProperty
        Throw New NotImplementedException()
    End Function

    Public Function GetProperty(name As String, bindingAttr As BindingFlags, binder As Binder, returnType As Type, types As Type(), modifiers As ParameterModifier()) As PropertyInfo Implements IReflect.GetProperty
        Throw New NotImplementedException()
    End Function

    Public ReadOnly Property UnderlyingSystemType As Type Implements IReflect.UnderlyingSystemType
        Get
            Throw New NotImplementedException()
        End Get
    End Property
End Class
' </snippet_InvokeMember>
