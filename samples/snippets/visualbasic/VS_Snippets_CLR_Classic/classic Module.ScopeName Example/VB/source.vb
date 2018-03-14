' <Snippet1>
Imports System.Reflection

Public Class Simple
    Public Shared Sub Main()
        Dim myMod As [Module] = GetType(Simple).Assembly.GetModules()(0)
        Console.WriteLine("Module Name is " + myMod.Name)
        Console.WriteLine("Module FullyQualifiedName is " +
                          myMod.FullyQualifiedName)
        Console.WriteLine("Module ScopeName is " +
                          myMod.ScopeName)
    End Sub
End Class
' The example displays output like the following:
' Module Name is modname.exe
' Module FullyQualifiedName is C:\Bin\modname.exe
' Module ScopeName is modname.exe 
' </Snippet1>
