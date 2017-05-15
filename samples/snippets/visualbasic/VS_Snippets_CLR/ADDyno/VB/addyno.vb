 ' <Snippet1>
Imports System
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.Remoting



Class ADDyno
   
   
   
   Public Shared Function CreateADynamicAssembly(ByRef myNewDomain As AppDomain, executableNameNoExe As String) As Type
      
      Dim executableName As String = executableNameNoExe + ".exe"
      
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = executableNameNoExe
      myAsmName.CodeBase = Environment.CurrentDirectory
      
      Dim myAsmBuilder As AssemblyBuilder = myNewDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave)
      Console.WriteLine("-- Dynamic Assembly instantiated.")
      
      Dim myModBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule(executableNameNoExe, executableName)
      
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType(executableNameNoExe, TypeAttributes.Public, GetType(MarshalByRefObject))
      
      Dim myFCMethod As MethodBuilder = myTypeBuilder.DefineMethod("CountLocalFiles", MethodAttributes.Public Or MethodAttributes.Static, Nothing, New Type() {})
      
      Dim currentDirGetMI As MethodInfo = GetType(Environment).GetProperty("CurrentDirectory").GetGetMethod()
      Dim writeLine0objMI As MethodInfo = GetType(Console).GetMethod("WriteLine", New Type() {GetType(String)})
      Dim writeLine2objMI As MethodInfo = GetType(Console).GetMethod("WriteLine", New Type() {GetType(String), GetType(Object), GetType(Object)})
      Dim getFilesMI As MethodInfo = GetType(Directory).GetMethod("GetFiles", New Type() {GetType(String)})
      
      myFCMethod.InitLocals = True
      
      Dim myFCIL As ILGenerator = myFCMethod.GetILGenerator()
      
      Console.WriteLine("-- Generating MSIL method body...")
      Dim v0 As LocalBuilder = myFCIL.DeclareLocal(GetType(String))
      Dim v1 As LocalBuilder = myFCIL.DeclareLocal(GetType(Integer))
      Dim v2 As LocalBuilder = myFCIL.DeclareLocal(GetType(String))
      Dim v3 As LocalBuilder = myFCIL.DeclareLocal(GetType(String()))
      
      Dim evalForEachLabel As Label = myFCIL.DefineLabel()
      Dim topOfForEachLabel As Label = myFCIL.DefineLabel()
      
      ' Build the method body.
      myFCIL.EmitCall(OpCodes.Call, currentDirGetMI, Nothing)
      myFCIL.Emit(OpCodes.Stloc_S, v0)
      myFCIL.Emit(OpCodes.Ldc_I4_0)
      myFCIL.Emit(OpCodes.Stloc_S, v1)
      myFCIL.Emit(OpCodes.Ldstr, "---")
      myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, Nothing)
      myFCIL.Emit(OpCodes.Ldloc_S, v0)
      myFCIL.EmitCall(OpCodes.Call, getFilesMI, Nothing)
      myFCIL.Emit(OpCodes.Stloc_S, v3)
      
      myFCIL.Emit(OpCodes.Br_S, evalForEachLabel)
      
      ' foreach loop starts here.
      myFCIL.MarkLabel(topOfForEachLabel)
      
      ' Load array of strings and index, store value at index for output.
      myFCIL.Emit(OpCodes.Ldloc_S, v3)
      myFCIL.Emit(OpCodes.Ldloc_S, v1)
      myFCIL.Emit(OpCodes.Ldelem_Ref)
      myFCIL.Emit(OpCodes.Stloc_S, v2)
      
      myFCIL.Emit(OpCodes.Ldloc_S, v2)
      myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, Nothing)
      
      ' Increment counter by one.
      myFCIL.Emit(OpCodes.Ldloc_S, v1)
      myFCIL.Emit(OpCodes.Ldc_I4_1)
      myFCIL.Emit(OpCodes.Add)
      myFCIL.Emit(OpCodes.Stloc_S, v1)
      
      ' Determine if end of file list array has been reached.
      myFCIL.MarkLabel(evalForEachLabel)
      myFCIL.Emit(OpCodes.Ldloc_S, v1)
      myFCIL.Emit(OpCodes.Ldloc_S, v3)
      myFCIL.Emit(OpCodes.Ldlen)
      myFCIL.Emit(OpCodes.Conv_I4)
      myFCIL.Emit(OpCodes.Blt_S, topOfForEachLabel)
      'foreach loop end here.
      myFCIL.Emit(OpCodes.Ldstr, "---")
      myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, Nothing)
      myFCIL.Emit(OpCodes.Ldstr, "There are {0} files in {1}.")
      myFCIL.Emit(OpCodes.Ldloc_S, v1)
      myFCIL.Emit(OpCodes.Box, GetType(Integer))
      myFCIL.Emit(OpCodes.Ldloc_S, v0)
      myFCIL.EmitCall(OpCodes.Call, writeLine2objMI, Nothing)
      
      myFCIL.Emit(OpCodes.Ret)
      
      Dim myType As Type = myTypeBuilder.CreateType()
      
      myAsmBuilder.SetEntryPoint(myFCMethod)
      myAsmBuilder.Save(executableName)
      Console.WriteLine("-- Method generated, type completed, and assembly saved to disk.")
      
      Return myType
   End Function 'CreateADynamicAssembly
    
   
   Public Shared Sub Main()
      
      Dim executableName As String = Nothing
      Dim domainDir As String
      
      Console.Write("Enter a name for the file counting assembly: ")
      Dim executableNameNoExe As String = Console.ReadLine()
      executableName = executableNameNoExe + ".exe"
      Console.WriteLine("---")
      
      domainDir = Environment.CurrentDirectory
      
      Dim curDomain As AppDomain = Thread.GetDomain()
      
      
      ' Create a new AppDomain, with the current directory as the base.
      Console.WriteLine("Current Directory: {0}", Environment.CurrentDirectory)
      Dim mySetupInfo As New AppDomainSetup()
      mySetupInfo.ApplicationBase = domainDir
      mySetupInfo.ApplicationName = executableNameNoExe
      mySetupInfo.LoaderOptimization = LoaderOptimization.SingleDomain
      
      Dim myDomain As AppDomain = AppDomain.CreateDomain(executableNameNoExe, Nothing, mySetupInfo)
      
      Console.WriteLine("Creating a new AppDomain '{0}'...", executableNameNoExe)
      
      Console.WriteLine("-- Base Directory = '{0}'", myDomain.BaseDirectory)
      Console.WriteLine("-- Shadow Copy? = '{0}'", myDomain.ShadowCopyFiles)
      
      Console.WriteLine("---")
      Dim myFCType As Type = CreateADynamicAssembly(curDomain, executableNameNoExe)
      
      Console.WriteLine("Loading '{0}' from '{1}'...", executableName, myDomain.BaseDirectory.ToString())
      
      
      Dim bFlags As BindingFlags = BindingFlags.Public Or BindingFlags.CreateInstance Or BindingFlags.Instance
      
      Dim myObjInstance As [Object] = myDomain.CreateInstanceAndUnwrap(executableNameNoExe, executableNameNoExe, False, bFlags, Nothing, Nothing, Nothing, Nothing, Nothing)
      
      Console.WriteLine("Executing method 'CountLocalFiles' in {0}...", myObjInstance.ToString())
      
      myFCType.InvokeMember("CountLocalFiles", BindingFlags.InvokeMethod, Nothing, myObjInstance, New Object() {})
   End Sub 'Main
End Class 'ADDyno 



' </Snippet1>