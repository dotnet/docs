' Simplified 1/17/06 GlennHa
' System.Reflection.Emit.ModuleBuilder.DefineEnum

' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Module Example
   
    Sub Main()
      
        ' Get the current application domain for the current thread.
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      
        ' Create a dynamic assembly in the current application domain, 
        ' and allow it to be executed and saved to disk.
        Dim aName As AssemblyName = New AssemblyName("TempAssembly")
        Dim ab As AssemblyBuilder = currentDomain.DefineDynamicAssembly( _ 
            aName, AssemblyBuilderAccess.RunAndSave)
      
        ' Define a dynamic module in "TempAssembly" assembly. For a single-
        ' module assembly, the module has the same name as the assembly.
        Dim mb As ModuleBuilder = _
            ab.DefineDynamicModule(aName.Name, aName.Name & ".dll")
      
        ' Define a public enumeration with the name "Elevation" and an 
        ' underlying type of Integer.
        Dim eb As EnumBuilder = _
            mb.DefineEnum("Elevation", TypeAttributes.Public, GetType(Integer))
      
        ' Define two members, "High" and "Low".
        eb.DefineLiteral("Low", 0)
        eb.DefineLiteral("High", 1)

        ' Create the type and save the assembly.
        Dim finished As Type = eb.CreateType()
        ab.Save(aName.Name & ".dll")

        For Each o As Object In [Enum].GetValues(finished)
            Console.WriteLine("{0}.{1} = {2}", finished, o, CInt(o))
        Next
   End Sub
End Module

' This code example produces the following output:
'
'Elevation.Low = 0
'Elevation.High = 1 
' </Snippet1>