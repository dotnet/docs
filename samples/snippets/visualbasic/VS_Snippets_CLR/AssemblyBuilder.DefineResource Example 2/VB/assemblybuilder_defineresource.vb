' System.Reflection.Emit.AssemblyBuilder.DefineResource(String, String, String)
' System.Reflection.Emit.AssemblyBuilder.DefineVersionInfoResource(String, String, String, String, String)

' The following program demonstrates the 'DefineResource(String, String, String)' and 
' 'DefineVersionInfoResource' (String, String, String, String, String) methods of 
' 'AssemblyBuilder' class. It builds an assembly and a resource file at runtime.
' The unmanaged version information like product, product version, Company, Copyright, 
' trademark are defined with 'DefineVersionInfoResource' method. The EmittedTest.vb file
' calls the methods of "MyEmitAssembly.dll" assembly and the message is displayed to console.

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Resources

Public Class MyEmitTest
   
' <Snippet1>  
' <Snippet2> 
   Public Shared Sub Main()
      Dim myAssembly As AssemblyBuilder
      Dim myResourceWriter As IResourceWriter
      myAssembly = CType(CreateAssembly(Thread.GetDomain()).Assembly, AssemblyBuilder)
      
      myResourceWriter = myAssembly.DefineResource("myResourceFile", "A sample Resource File", _
                                                         "MyEmitAssembly.MyResource.resources")
      myResourceWriter.AddResource("AddResource 1", "First added resource")
      myResourceWriter.AddResource("AddResource 2", "Second added resource")
      myResourceWriter.AddResource("AddResource 3", "Third added resource")
      
      myAssembly.DefineVersionInfoResource("AssemblySample", "2:0:0:1", "Microsoft Corporation", _
            "@Copyright Microsoft Corp. 1990-2001", ".NET is a trademark of Microsoft Corporation")
      myAssembly.Save("MyEmitAssembly.dll")
   End Sub 'Main
   
   ' Create the callee transient dynamic assembly.
   Private Shared Function CreateAssembly(myAppDomain As AppDomain) As Type
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "MyEmitAssembly"
      Dim myAssembly As AssemblyBuilder = myAppDomain.DefineDynamicAssembly(myAssemblyName, _
                                                               AssemblyBuilderAccess.Save)
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule", _
                                                               "EmittedModule.mod")
      
      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldClass As TypeBuilder = myModule.DefineType("HelloWorld", TypeAttributes.Public)
      ' Define the Display method.
      Dim myMethod As MethodBuilder = helloWorldClass.DefineMethod("Display", _
                                    MethodAttributes.Public, GetType(String), Nothing)
      
      ' Generate IL for GetGreeting.
      Dim methodIL As ILGenerator = myMethod.GetILGenerator()
      methodIL.Emit(OpCodes.Ldstr, "Display method get called.")
      methodIL.Emit(OpCodes.Ret)
      ' Returns the type HelloWorld.
      Return helloWorldClass.CreateType()
   End Function 'CreateAssembly
' </Snippet2>
' </Snippet1>
End Class 'MyEmitTest 
