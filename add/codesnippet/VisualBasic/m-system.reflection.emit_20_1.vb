Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Resources

Public Class MyAssemblyResource
   
   Friend Shared Sub Main()
      Dim myAssembly As AssemblyBuilder = _
          CreateAssembly("MyEmitTestAssembly")
      
      ' Defines a standalone managed resource for this assembly.
      Dim myResourceWriter As IResourceWriter = _
         myAssembly.DefineResource("myResourceFile", _
            "A sample Resource File", "MyAssemblyResource.resources", _
            ResourceAttributes.Private)

      myResourceWriter.AddResource("AddResource Test", "Testing for the added resource")

      myAssembly.Save(myAssembly.GetName().Name & ".dll")
      
      ' Defines an unmanaged resource file for this assembly.
      myAssembly.DefineUnmanagedResource(New Byte() {1, 0, 1})

   End Sub 
   
   Private Shared Function CreateAssembly(ByVal name As String) As AssemblyBuilder

      Dim aName As New AssemblyName(name)

      Dim myAssembly As AssemblyBuilder = _
         AppDomain.CurrentDomain.DefineDynamicAssembly(aName, _
            AssemblyBuilderAccess.Save)
      
      ' Define a dynamic module.
      Dim myModule As ModuleBuilder = _
         myAssembly.DefineDynamicModule(aName.Name, aName.Name & ".dll")

      ' Define a public class named "EmitClass" in the assembly.
      Dim myEmitClass As TypeBuilder = _
         myModule.DefineType("EmitClass", TypeAttributes.Public)
      
      ' Define the Display method.
      Dim myMethod As MethodBuilder = _
         myEmitClass.DefineMethod("Display", MethodAttributes.Public, _
                                                GetType(String), Nothing)
      
      ' Generate IL for Display method.
      Dim methodIL As ILGenerator = myMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldstr, "Display method get called.")
      methodIL.Emit(OpCodes.Ret)
      
      myEmitClass.CreateType()

      Return myAssembly

   End Function 
End Class 