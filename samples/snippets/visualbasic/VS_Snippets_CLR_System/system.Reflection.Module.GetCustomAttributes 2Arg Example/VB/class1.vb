' <snippet1>
Imports System.Reflection

' Define a module-level attribute.
<Module: ReflectionModule_Examples.MySimpleAttribute("module-level")> 
' This code assumes that the root namespace is set to empty("").
Namespace ReflectionModule_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim moduleArray() As [Module]
            moduleArray = GetType(MyMainClass).Assembly.GetModules(False)
            ' In a simple project with only one module, the module at index
            ' 0 will be the module containing these classes.
            Dim myModule As [Module] = moduleArray(0)
            Dim attributes() As Object
            ' Get only MySimpleAttribute attributes for this module.
            attributes = myModule.GetCustomAttributes( _
                myModule.GetType("ReflectionModule_Examples.MySimpleAttribute", _
                False, False), True)
            Dim o As [Object]
            For Each o In attributes
                Console.WriteLine("Found this attribute on myModule: {0}", o.ToString())
            Next o
        End Sub 'Main
    End Class 'MyMainClass
    ' Define a very simple custom attribute.
    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Module)> _
     Public Class MySimpleAttribute
        Inherits Attribute
        Private name As String
        Public Sub New(ByVal newName As String)
            name = newName
        End Sub 'New
    End Class 'MySimpleAttribute
End Namespace 'ReflectionModule_Examples
' </snippet1>