' System.Reflection.Emit.ModuleBuilder.DefineGlobalMethod(String,MethodAttributes,Type,Type())
' System.Reflection.Emit.ModuleBuilder.CreateGlobalFunctions

' The following example demonstrates the 'DefineGlobalMethod(String,MethodAttributes,Type,Type())'
' and 'CreateGlobalFunctions' methods of 'ModuleBuilder' class. 
' A dynamic assembly with a module in it is created in 'CodeGenerator' class. Then a global method 
' is created in the module using the 'DefineGlobalMethod' method. The global method is called from
' the 'CallerClass'.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Public Class CodeGenerator
   Private myModuleBuilder As ModuleBuilder = Nothing
   Private myAssemblyBuilder As AssemblyBuilder = Nothing
   
   Public Sub New()
' <Snippet1>
' <Snippet2>
      Dim currentDomain As AppDomain
      Dim myAssemblyName As AssemblyName
      Dim myMethodBuilder As MethodBuilder = Nothing
      Dim myILGenerator As ILGenerator
      
      ' Get the current application domain for the current thread.
      currentDomain = AppDomain.CurrentDomain
      myAssemblyName = New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      
      ' Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder = currentDomain.DefineDynamicAssembly(myAssemblyName, _
                                                         AssemblyBuilderAccess.RunAndSave)
      ' Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      
      ' Define a global method in the 'TempModule' module.
      myMethodBuilder = myModuleBuilder.DefineGlobalMethod("MyMethod1", MethodAttributes.Static _
                                                Or MethodAttributes.Public, Nothing, Nothing)
      myILGenerator = myMethodBuilder.GetILGenerator()
      myILGenerator.EmitWriteLine("Hello World from global method.")
      myILGenerator.Emit(OpCodes.Ret)
      ' Fix up the 'TempModule' module .
      myModuleBuilder.CreateGlobalFunctions()
' </Snippet2>
' </Snippet1>
   End Sub 'New 
   
   Public ReadOnly Property MyAssembly() As AssemblyBuilder
      Get
         Return Me.myAssemblyBuilder
      End Get
   End Property
End Class 'CodeGenerator

Public Class CallerClass
   
   Public Shared Sub Main()
      Dim myGenerator As New CodeGenerator()
      Dim myAssembly As AssemblyBuilder = myGenerator.MyAssembly
      Dim myBuilder As ModuleBuilder = myAssembly.GetDynamicModule("TempModule")
      Console.WriteLine("Invoking the global method...")
      Dim myMethodInfo As MethodInfo = myBuilder.GetMethod("MyMethod1")
      myMethodInfo.Invoke(Nothing, Nothing)
   End Sub 'Main
End Class 'CallerClass
