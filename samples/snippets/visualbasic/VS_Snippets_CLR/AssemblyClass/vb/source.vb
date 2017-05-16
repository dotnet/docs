' GlennHa 1/23/06
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Security.Permissions

<assembly: AssemblyVersionAttribute("1.0.2000.0")>

Public Class Example
    Private factor As Integer
    
    Public Sub New(ByVal f As Integer) 
        factor = f
    End Sub 
    
    Public Function SampleMethod(ByVal x As Integer) As Integer 
        Console.WriteLine(vbCrLf & "Example.SampleMethod({0}) executes.", x)
        Return x * factor
    End Function 
    
    Public Shared Sub Main() 
        Dim assem As Assembly = GetType(Example).Assembly
        
        Console.WriteLine("Assembly Full Name:")
        Console.WriteLine(assem.FullName)
        
        ' The AssemblyName type can be used to parse the full name.
        Dim assemName As AssemblyName = assem.GetName()
        Console.WriteLine(vbLf + "Name: {0}", assemName.Name)
        Console.WriteLine("Version: {0}.{1}", assemName.Version.Major, _
            assemName.Version.Minor)
        
        Console.WriteLine(vbLf + "Assembly CodeBase:")
        Console.WriteLine(assem.CodeBase)
        
        ' Create an object from the assembly, passing in the correct number
        ' and type of arguments for the constructor.
        Dim o As Object = assem.CreateInstance("Example", False, _
            BindingFlags.ExactBinding, Nothing, _
            New Object() { 2 }, Nothing, Nothing)
        
        ' Make a late-bound call to an instance method of the object.    
        Dim m As MethodInfo = assem.GetType("Example").GetMethod("SampleMethod")
        Dim ret As Object = m.Invoke(o, New Object() { 42 })
        Console.WriteLine("SampleMethod returned {0}.", ret)
        
        Console.WriteLine(vbCrLf & "Assembly entry point:")
        Console.WriteLine(assem.EntryPoint)
    
    End Sub 
End Class 

' This code example produces output similar to the following:
'
'Assembly Full Name:
'source, Version=1.0.2000.0, Culture=neutral, PublicKeyToken=null
'
'Name: source
'Version: 1.0
'
'Assembly CodeBase:
'file:///C:/sdtree/AssemblyClass/vb/source.exe
'
'Example.SampleMethod(42) executes.
'SampleMethod returned 84.
'
'Assembly entry point:
'Void Main()
' 
'</Snippet1>