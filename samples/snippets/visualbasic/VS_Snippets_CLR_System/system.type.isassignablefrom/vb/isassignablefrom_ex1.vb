' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection
Imports System.Reflection.Emit

Public Class A
End Class

Module Example
   Public Sub Main()
      Dim domain As AppDomain = AppDomain.CurrentDomain
      Dim assemName As New AssemblyName()
      assemName.Name = "TempAssembly"

      ' Define a dynamic assembly in the current application domain.
      Dim assemBuilder As AssemblyBuilder = domain.DefineDynamicAssembly(assemName,
                                                   AssemblyBuilderAccess.Run)

      ' Define a dynamic module in this assembly.
      Dim moduleBuilder As ModuleBuilder = assemBuilder.DefineDynamicModule("TempModule")

      Dim b1 As TypeBuilder = moduleBuilder.DefineType("B", TypeAttributes.Public, GetType(A))
      Console.WriteLine(GetType(A).IsAssignableFrom(b1))
   End Sub
End Module
' The example displays the following output:
'       True
' </Snippet1>
