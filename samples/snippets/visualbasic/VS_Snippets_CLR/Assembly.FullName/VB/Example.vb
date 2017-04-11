' <Snippet1>
Imports System.Reflection

Class Example
    Shared Sub Main()
        Console.WriteLine("The FullName property (also called the display name) of...")
        Console.WriteLine("...the currently executing assembly:")
        Console.WriteLine(GetType(Example).Assembly.FullName)

        Console.WriteLine("...the assembly that contains the Int32 type:")
        Console.WriteLine(GetType(Integer).Assembly.FullName)
    End Sub 
End Class 

' This example produces output similar to the following:
'
'The FullName property (also called the display name) of...
'...the currently executing assembly:
'ExampleAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
'...the assembly that contains the Int32 type:
'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
' </Snippet1>
