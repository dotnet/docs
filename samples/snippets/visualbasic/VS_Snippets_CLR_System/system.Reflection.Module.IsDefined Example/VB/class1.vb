'<snippet1>
Imports System.Reflection

'Define a module-level attribute.
<Module: ReflectionModule_Examples.MySimpleAttribute("module-level")> 

'Define a module-level attribute.
Namespace ReflectionModule_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim moduleArray() As [Module]

            moduleArray = GetType(MyMainClass).Assembly.GetModules(False)

            'In a simple project with only one module, the module at index
            ' 0 will be the module containing these classes.
            Dim myModule As [Module] = moduleArray(0)

            Dim myType As Type
            myType = myModule.GetType("ReflectionModule_Examples.MySimpleAttribute")
            Console.WriteLine("IsDefined(MySimpleAttribute) = {0}", myModule.IsDefined(myType, False))
        End Sub 'Main
    End Class 'MyMainClass

    'A very simple custom attribute.
    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Module)> _
    Public Class MySimpleAttribute
        Inherits Attribute
        Private name As String

        Public Sub New(ByVal newName As String)
            name = newName
        End Sub 'New
    End Class 'MySimpleAttribute
End Namespace 'ReflectionModule_Examples
'</snippet1>