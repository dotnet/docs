'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Public Class Example 
   Inherits MarshalByRefObject
   
   Shared Sub Main(args() As String)

      ' Prepare to create a new application domain.
      Dim setup As New AppDomainSetup()

      ' Set the application name before setting the dynamic base.
      setup.ApplicationName = "Example"
      
      ' Set the location of the base directory where assembly resolution 
      ' probes for dynamic assemblies. Note that the hash code of the 
      ' application name is concatenated to the base directory name you 
      ' supply. 
      setup.DynamicBase = "C:\DynamicAssemblyDir"
      Console.WriteLine("DynamicBase is set to '{0}'.", setup.DynamicBase)

      Dim ad As AppDomain = AppDomain.CreateDomain("MyDomain", Nothing, setup)
      
      ' The dynamic directory name is the dynamic base concatenated with
      ' the application name: <DynamicBase>\<hash code>\<ApplicationName>
      Dim dynamicDir As String = ad.DynamicDirectory 
      Console.WriteLine("Dynamic directory is '{0}'.", dynamicDir)

      ' The AssemblyBuilder won't create this directory automatically.
      If Not System.IO.Directory.Exists(dynamicDir) Then 
         Console.WriteLine("Creating the dynamic directory.")
         System.IO.Directory.CreateDirectory(dynamicDir)
      End If

      ' Generate a dynamic assembly and store it in the dynamic 
      ' directory.
      GenerateDynamicAssembly(dynamicDir) 

      ' Create an instance of the Example class in the application domain,
      ' and call its Test method to load the dynamic assembly and use it.  
      Dim ex As Example = CType( _
         ad.CreateInstanceAndUnwrap( _
            GetType(Example).Assembly.FullName, "Example"), Example)
      ex.Test()
   End Sub

   Public Sub Test() 

      Dim dynAssem As [Assembly] = Assembly.Load(
         "DynamicHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")

      Dim myType As Type = dynAssem.GetType("HelloWorld")
      myType.InvokeMember("HelloFromAD", BindingFlags.Public Or _
         BindingFlags.Static Or BindingFlags.InvokeMethod, _
         Type.DefaultBinder, Nothing, Nothing) 'New Object() {})
   End Sub


   Private Shared Sub GenerateDynamicAssembly(ByVal location As String)
      
      ' Define the dynamic assembly and the module. There is only one
      ' module in this assembly. Note that the call to DefineDynamicAssembly 
      ' specifies the location where the assembly will be saved. The 
      ' assembly version is 1.0.0.0.
      '
      Dim asmName As New AssemblyName("DynamicHelloWorld")
      asmName.Version = New Version("1.0.0.0")

      Dim ab As AssemblyBuilder = _
         AppDomain.CurrentDomain.DefineDynamicAssembly( _
            asmName, AssemblyBuilderAccess.Save, location)

      Dim moduleName As String = asmName.Name & ".dll"
      Dim mb As ModuleBuilder = ab.DefineDynamicModule(asmName.Name, moduleName)
      
      ' Define the "HelloWorld" type, with one static method.
      Dim tb As TypeBuilder = mb.DefineType("HelloWorld", TypeAttributes.Public)
      Dim hello As MethodBuilder = tb.DefineMethod("HelloFromAD", _
         MethodAttributes.Public Or MethodAttributes.Static, Nothing, Nothing)

      ' The method displays a message that contains the name of the application
      ' domain where the method is executed.
      Dim il As ILGenerator = hello.GetILGenerator()
      il.Emit(OpCodes.Ldstr, "Hello from '{0}'!")
      il.Emit(OpCodes.Call, GetType(AppDomain).GetProperty("CurrentDomain").GetGetMethod())
      il.Emit(OpCodes.Call, GetType(AppDomain).GetProperty("FriendlyName").GetGetMethod())
      il.Emit(OpCodes.Call, GetType(Console).GetMethod("WriteLine", _
                             New Type() { GetType(String), GetType(String) }))
      il.Emit(OpCodes.Ret)

      ' Complete the HelloWorld type and save the assembly. The assembly
      ' is placed in the location specified by DefineDynamicAssembly.
      Dim myType As Type = tb.CreateType()
      ab.Save(moduleName)
   End Sub
End Class 

' This example produces output similar to the following:
'
'DynamicBase is set to 'C:\DynamicAssemblyDir\5e4a7545'.
'Dynamic directory is 'C:\DynamicAssemblyDir\5e4a7545\Example'.
'Creating the dynamic directory.
'Hello from 'MyDomain'!
'</Snippet1>
