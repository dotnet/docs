Option Strict On
Option Explicit On

' <Snippet1>
Imports System
Imports System.IO
Imports System.Reflection
Imports System.Reflection.Emit

Module Test
   
   Sub Main()
      Dim currentDomain As AppDomain = AppDomain.CurrentDomain
      
      InstantiateMyType(currentDomain)      ' Failed!

      AddHandler currentDomain.AssemblyResolve, AddressOf MyResolver
      
      InstantiateMyType(currentDomain)      ' OK!
   End Sub 'Main
   
   
   Sub InstantiateMyType(domain As AppDomain)
      Try
	 ' You must supply a valid fully qualified assembly name here.
         domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType")
      Catch e As Exception
         Console.WriteLine(e.Message)
      End Try
   End Sub 'InstantiateMyType
   
   
   ' Loads the content of a file to a byte array. 
   Function loadFile(filename As String) As Byte()
      Dim fs As New FileStream(filename, FileMode.Open)
      Dim buffer(CInt(fs.Length)) As Byte
      fs.Read(buffer, 0, buffer.Length)
      fs.Close()
      
      Return buffer
   End Function 'loadFile
   
   
   Function MyResolver(sender As Object, args As ResolveEventArgs) As System.Reflection.Assembly
      Dim domain As AppDomain = DirectCast(sender, AppDomain)
      
      ' Once the files are generated, this call is
      ' actually no longer necessary.
      EmitAssembly(domain)
      
      Dim rawAssembly As Byte() = loadFile("temp.dll")
      Dim rawSymbolStore As Byte() = loadFile("temp.pdb")
      Dim myAssembly As System.Reflection.Assembly = domain.Load(rawAssembly, rawSymbolStore)
      
      Return myAssembly
   End Function 'MyResolver
   
   
   ' Creates a dynamic assembly with symbol information
   ' and saves them to temp.dll and temp.pdb
   Sub EmitAssembly(domain As AppDomain)
      Dim assemblyName As New AssemblyName()
      assemblyName.Name = "MyAssembly"
      
      Dim assemblyBuilder As AssemblyBuilder = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save)
      Dim moduleBuilder As ModuleBuilder = assemblyBuilder.DefineDynamicModule("MyModule", "temp.dll", True)
      Dim typeBuilder As TypeBuilder = moduleBuilder.DefineType("MyType", TypeAttributes.Public)
      
      Dim constructorBuilder As ConstructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Nothing)
      Dim ilGenerator As ILGenerator = constructorBuilder.GetILGenerator()
      ilGenerator.EmitWriteLine("MyType instantiated!")
      ilGenerator.Emit(OpCodes.Ret)
      
      typeBuilder.CreateType()
      
      assemblyBuilder.Save("temp.dll")
   End Sub 'EmitAssembly

End Module 'Test
' </Snippet1>