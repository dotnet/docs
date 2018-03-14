'<Snippet1>
Imports System
Imports System.Reflection

<Assembly:AssemblyVersion("1.1.0.0")>

Class Example

    Shared Sub Main()
    
        Console.WriteLine("The version of the currently executing assembly is: {0} ", _
            GetType(Example).Assembly.GetName().Version)

        Console.WriteLine("The version of mscorlib.dll is: {0} ", _
            GetType(String).Assembly.GetName().Version)
    End Sub
End Class

' This example produces output similar to the following:
'
'The version of the currently executing assembly is: 1.1.0.0
'The version of mscorlib.dll is: 2.0.0.0
'</Snippet1>
