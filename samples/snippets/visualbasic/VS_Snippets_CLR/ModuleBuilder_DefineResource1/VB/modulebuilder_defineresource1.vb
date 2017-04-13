' System.Reflection.Emit.ModuleBuilder.DefineResource(String,String)

' The following example demonstrates the 'DefineResource(String,String)' method
' of 'ModuleBuilder' class.
' A dynamic assembly with a module in it is created in 'CodeGenerator' class.
' Then a managed resource is defined in the module using the 'DefineResource' 
' method.
' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Resources

Public Class CodeGenerator
   
   Public Sub New()
      ' Get the current application domain for the current thread.
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain

      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "TempAssembly"
      
      ' Define 'TempAssembly' assembly in the current application domain.
      Dim myAssemblyBuilder As AssemblyBuilder = currentDomain.DefineDynamicAssembly _
                                       (myAssemblyName, AssemblyBuilderAccess.RunAndSave)
      ' Define 'TempModule' module in 'TempAssembly' assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule _
                                             ("TempModule", "TempModule.netmodule", True)
      ' Define the managed embedded resource, 'MyResource' in 'TempModule'.
      Dim myResourceWriter As IResourceWriter = myModuleBuilder.DefineResource _
                                                   ("MyResource.resource", "Description")
      ' Add resources to the resource writer.
      myResourceWriter.AddResource("String 1", "First String")
      myResourceWriter.AddResource("String 2", "Second String")
      myResourceWriter.AddResource("String 3", "Third String")
      myAssemblyBuilder.Save("MyAssembly.dll")

   End Sub 'New 
End Class 'CodeGenerator

Public Class CallerClass
   
   Public Shared Sub Main()
      Dim myGenerator As New CodeGenerator()
      Console.WriteLine("A resource named 'MyResource.resource' has been created and can be" + _
                                                               " viewed  in the 'MyAssembly.dll'")
   End Sub 'Main
End Class 'CallerClass
' </Snippet1>