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
      ' Define the managed embedded resource, 'MyResource' in 'TempModule'
      ' with the specified attribute.
      Dim writer As IResourceWriter = myModuleBuilder.DefineResource _
                              ("MyResource.resource", "Description", ResourceAttributes.Public)
      ' Add resources to the resource writer.
      writer.AddResource("String 1", "First String")
      writer.AddResource("String 2", "Second String")
      writer.AddResource("String 3", "Third String")
      myAssemblyBuilder.Save("MyAssembly.dll")

   End Sub 'New 
End Class 'CodeGenerator

Public Class CallerClass
   
   Public Shared Sub Main()
      Dim myGenerator As New CodeGenerator()
      Console.WriteLine("A resource named 'MyResource.resource' has been created and can be " + _
                                                         "viewed  in the 'MyAssembly.dll'")
   End Sub 'Main
End Class 'CallerClass