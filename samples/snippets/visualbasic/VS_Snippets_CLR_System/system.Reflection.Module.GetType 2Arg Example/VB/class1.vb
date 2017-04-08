'<snippet1>
Imports System.Reflection

'This code assumes that the root namespace is set to empty("").
Namespace ReflectionModule_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim moduleArray() As [Module]

            moduleArray = GetType(MyMainClass).Assembly.GetModules(False)

            'In a simple project with only one module, the module at index
            ' 0 will be the module containing these classes.
            Dim myModule As [Module] = moduleArray(0)

            Dim myType As Type
            myType = myModule.GetType("ReflectionModule_Examples.MyMainClass", False)
            Console.WriteLine("Got type: {0}", myType.ToString())
        End Sub 'Main
    End Class 'MyMainClass
End Namespace 'ReflectionModule_Examples
'</snippet1>
