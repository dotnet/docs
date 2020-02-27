' <Snippet1>
Class Example
    Public Shared Sub Main()
        Dim objType As Type = GetType(Array)

        ' Display the assembly full name.
        Console.WriteLine($"Assembly full name:{vbCrLf}   {objType.Assembly.FullName}.")

        ' Display the assembly qualified name.
        Console.WriteLine($"Assembly qualified name:{vbCrLf}   {objType.AssemblyQualifiedName}.")
    End Sub
End Class
' The example displays the following output if run under the .NET Framework 4.5:
'    Assembly full name:
'       mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
'    Assembly qualified name:
'       System.Array, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
' </Snippet1>
