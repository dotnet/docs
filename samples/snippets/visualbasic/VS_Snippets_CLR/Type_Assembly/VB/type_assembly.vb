' <Snippet1>
Imports System.Reflection

Class Example
    Public Shared Sub Main()
        Dim objType As Type = GetType(System.Array)
        ' Display the full assembly name.
        Console.WriteLine("Full assembly name:{1}   {0}.", 
                          objType.Assembly.FullName.ToString(), vbCrLf)
        ' Display the qualified assembly name.
        Console.WriteLine("Qualified assembly name: {1}   {0}.", 
                          objType.AssemblyQualifiedName.ToString(), vbCrLf)
    End Sub
End Class 
' The example displays the following output if run under the .NET Framework 4.5:
'    Full assembly name:
'       mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
'    Qualified assembly name:
'       System.Array, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089.
' </Snippet1>