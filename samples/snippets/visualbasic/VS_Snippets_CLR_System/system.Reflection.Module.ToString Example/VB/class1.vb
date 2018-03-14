'<snippet1>
Imports System.Reflection

Namespace ReflectionModule_Examples
    Class MyMainClass
        Shared Sub Main()
            Dim moduleArray() As [Module]

            moduleArray = GetType(MyMainClass).Assembly.GetModules(False)

            'In a simple project with only one module, the module at index
            ' 0 will be the module containing this class.
            Dim myModule As [Module] = moduleArray(0)

            Console.WriteLine("myModule.ToString returns: {0}", myModule.ToString())
        End Sub 'Main
    End Class 'MyMainClass
End Namespace 'ReflectionModule_Examples
'</snippet1>
