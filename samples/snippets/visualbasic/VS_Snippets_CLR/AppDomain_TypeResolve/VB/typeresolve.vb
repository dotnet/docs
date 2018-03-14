' REDMOND\glennha
' VSWhidbey 445288
' <Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Module Test

    ' For this code example, the following information needs to be
    ' available to both Main and the HandleTypeResolve event
    ' handler:
    Private ab As AssemblyBuilder
    Private moduleName As String

    Sub Main() 
    
        Dim currDom As AppDomain = AppDomain.CurrentDomain

        ' Create a dynamic assembly with one module, to be saved to 
        ' disk (AssemblyBuilderAccess.Save).
        ' 
        Dim aName As AssemblyName = new AssemblyName()
        aName.Name = "Transient"
        moduleName = aName.Name + ".dll"
        ab = currDom.DefineDynamicAssembly(aName, _
            AssemblyBuilderAccess.Save)
        Dim mb As ModuleBuilder = _
            ab.DefineDynamicModule(aName.Name, moduleName)

        ' The dynamic assembly has just one dummy type, to demonstrate
        ' type resolution.
        Dim tb As TypeBuilder = mb.DefineType("Example")
        tb.CreateType()


        ' First, try to load the type without saving the dynamic 
        ' assembly and without hooking up the TypeResolve event. The
        ' type cannot be loaded.
        Try
            Dim temp As Type = Type.GetType("Example", true)
            Console.WriteLine("Loaded type {0}.", temp)
        Catch ex As TypeLoadException
            Console.WriteLine("Loader could not resolve the type.")
        End Try

        ' Hook up the TypeResolve event.
        '      
        AddHandler currDom.TypeResolve, AddressOf HandleTypeResolve

        ' Now try to load the type again. The TypeResolve event is 
        ' raised, the dynamic assembly is saved, and the dummy type is
        ' loaded successfully. Display it to the console, and create
        ' an instance.
        Dim t As Type = Type.GetType("Example", true)
        Console.WriteLine("Loaded type ""{0}"".", t)
        Dim o As Object = Activator.CreateInstance(t)
    End Sub

    Private Function HandleTypeResolve(ByVal sender As Object, _
        ByVal e As ResolveEventArgs) As [Assembly]
    
        Console.WriteLine("TypeResolve event handler.")

        ' Save the dynamic assembly, and then load it using its
        ' display name. Return the loaded assembly.
        '
        ab.Save(moduleName)
        Return [Assembly].Load(ab.FullName) 
    End Function
End Module

' This code example produces the following output:
'
'Loader could not resolve the type.
'TypeResolve event handler.
'Loaded type "Example".
'
' </Snippet1>