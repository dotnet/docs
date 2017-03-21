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