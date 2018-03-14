'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Timers

Public Class Example
    
    Public Shared Sub Main() 
        ' Get the assembly display name for System.dll, the assembly 
        ' that contains System.Timers.Timer. Note that this causes
        ' System.dll to be loaded into the execution context.
        '
        Dim displayName As String = GetType(Timer).Assembly.FullName
        
        ' Load System.dll into the reflection-only context. Note that 
        ' if you obtain the display name (for example, by running this
        ' example program), and enter it as a literal string in the 
        ' preceding line of code, you can load System.dll into the 
        ' reflection-only context without loading it into the execution 
        ' context.
        Assembly.ReflectionOnlyLoad(displayName)
        
        ' Display the assemblies loaded into the execution and 
        ' reflection-only contexts. System.dll appears in both contexts.
        '
        Dim ad As AppDomain = AppDomain.CurrentDomain
        Console.WriteLine("------------- Execution Context --------------")
        For Each a As Assembly In ad.GetAssemblies()
            Console.WriteLine(vbTab + "{0}", a.GetName())
        Next a
        Console.WriteLine("------------- Reflection-only Context --------------")
        For Each a As Assembly In ad.ReflectionOnlyGetAssemblies()
            Console.WriteLine(vbTab + "{0}", a.GetName())
        Next a
    
    End Sub
End Class
'</Snippet1>