' System.Reflection.Emit.ModuleBuilder.DefineInitializedData

' The following example demonstrates the 'DefineInitializedData' method of 
' 'ModuleBuilder' class.
' A dynamic assembly with a module in it is created in 'CodeGenerator' class. 
' A initialized data field is created using  'DefineInitializedData'
' method for creating the initialized data.

Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Public Class CodeGenerator
   Private myModuleBuilder As ModuleBuilder
   Private myAssemblyBuilder As AssemblyBuilder

   Public Sub New()
' <Snippet1>
      Dim currentDomain As AppDomain
      Dim myAssemblyName As AssemblyName
      ' Get the current application domain for the current thread.
      currentDomain = AppDomain.CurrentDomain
      myAssemblyName = New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      ' Define a dynamic assembly in the 'currentDomain'.
      myAssemblyBuilder = _
            currentDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)
      ' Define a dynamic module in "TempAssembly" assembly.
      myModuleBuilder = myAssemblyBuilder.DefineDynamicModule("TempModule")
      ' Define the initialized data field in the .sdata section of the PE file.
      Dim myFieldBuilder As FieldBuilder = _
            myModuleBuilder.DefineInitializedData("MyField", New Byte() {1, 0, 1}, _
            FieldAttributes.Static Or FieldAttributes.Public)
      myModuleBuilder.CreateGlobalFunctions()
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
      Dim myInfo As FieldInfo = myBuilder.GetField("MyField")
      Console.WriteLine("The name of the initialized data field is :" + myInfo.Name)
      Console.WriteLine("The object having the field value is :" + _
                        myInfo.GetValue(myBuilder).ToString())
   End Sub 'Main
End Class 'CallerClass