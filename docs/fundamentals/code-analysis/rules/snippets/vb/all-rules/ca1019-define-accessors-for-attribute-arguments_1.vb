Imports System

Namespace ca1019

    ' Violates rule: DefineAccessorsForAttributeArguments.
    <AttributeUsage(AttributeTargets.All)>
    Public NotInheritable Class BadCustomAttribute
        Inherits Attribute
        Private data As String

        ' Missing the property that corresponds to 
        ' the someStringData parameter.
        Public Sub New(someStringData As String)
            data = someStringData
        End Sub 'New
    End Class 'BadCustomAttribute

    ' Satisfies rule: Attributes should have accessors for all arguments.
    <AttributeUsage(AttributeTargets.All)>
    Public NotInheritable Class GoodCustomAttribute
        Inherits Attribute

        Public Sub New(someStringData As String)
            Me.SomeStringData = someStringData
        End Sub 'New

        'The constructor parameter and property
        'name are the same except for case.

        Public ReadOnly Property SomeStringData() As String
    End Class

End Namespace
