// <Snippet1>

using System;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting;

class ADDyno

{

   public static Type CreateADynamicAssembly(ref AppDomain myNewDomain,
					     string executableNameNoExe)
   {

	string executableName = executableNameNoExe + ".exe";

	AssemblyName myAsmName = new AssemblyName();
	myAsmName.Name = executableNameNoExe;
	myAsmName.CodeBase = Environment.CurrentDirectory;

	AssemblyBuilder myAsmBuilder = myNewDomain.DefineDynamicAssembly(myAsmName,
						AssemblyBuilderAccess.RunAndSave);
	Console.WriteLine("-- Dynamic Assembly instantiated.");

	ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(executableNameNoExe,
								      executableName);

	TypeBuilder myTypeBuilder = myModBuilder.DefineType(executableNameNoExe,
						TypeAttributes.Public,
						typeof(MarshalByRefObject));

	MethodBuilder myFCMethod = myTypeBuilder.DefineMethod("CountLocalFiles",
						MethodAttributes.Public |
						MethodAttributes.Static,
						null,
						new Type[] {  });

	MethodInfo currentDirGetMI = typeof(Environment).GetProperty("CurrentDirectory").GetGetMethod();
	MethodInfo writeLine0objMI = typeof(Console).GetMethod("WriteLine",
				     new Type[] { typeof(string) });
	MethodInfo writeLine2objMI = typeof(Console).GetMethod("WriteLine",
				     new Type[] { typeof(string), typeof(object), typeof(object) });
	MethodInfo getFilesMI = typeof(Directory).GetMethod("GetFiles", 
				new Type[] { typeof(string) });

	myFCMethod.InitLocals = true;

	ILGenerator myFCIL = myFCMethod.GetILGenerator();

	Console.WriteLine("-- Generating MSIL method body...");
	LocalBuilder v0 = myFCIL.DeclareLocal(typeof(string));
	LocalBuilder v1 = myFCIL.DeclareLocal(typeof(int));
	LocalBuilder v2 = myFCIL.DeclareLocal(typeof(string));
	LocalBuilder v3 = myFCIL.DeclareLocal(typeof(string[]));

	Label evalForEachLabel = myFCIL.DefineLabel();
	Label topOfForEachLabel = myFCIL.DefineLabel();

	// Build the method body.

	myFCIL.EmitCall(OpCodes.Call, currentDirGetMI, null);
	myFCIL.Emit(OpCodes.Stloc_S, v0);
	myFCIL.Emit(OpCodes.Ldc_I4_0);
	myFCIL.Emit(OpCodes.Stloc_S, v1);
	myFCIL.Emit(OpCodes.Ldstr, "---");
	myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, null);
	myFCIL.Emit(OpCodes.Ldloc_S, v0);
	myFCIL.EmitCall(OpCodes.Call, getFilesMI, null);
	myFCIL.Emit(OpCodes.Stloc_S, v3);

	myFCIL.Emit(OpCodes.Br_S, evalForEachLabel);

	// foreach loop starts here.
	myFCIL.MarkLabel(topOfForEachLabel);
	
        // Load array of strings and index, store value at index for output.
	myFCIL.Emit(OpCodes.Ldloc_S, v3);
	myFCIL.Emit(OpCodes.Ldloc_S, v1);
	myFCIL.Emit(OpCodes.Ldelem_Ref);
	myFCIL.Emit(OpCodes.Stloc_S, v2);

	myFCIL.Emit(OpCodes.Ldloc_S, v2);
	myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, null);

	// Increment counter by one.
	myFCIL.Emit(OpCodes.Ldloc_S, v1);
	myFCIL.Emit(OpCodes.Ldc_I4_1);
	myFCIL.Emit(OpCodes.Add);
	myFCIL.Emit(OpCodes.Stloc_S, v1);

	// Determine if end of file list array has been reached.
	myFCIL.MarkLabel(evalForEachLabel);
	myFCIL.Emit(OpCodes.Ldloc_S, v1);
	myFCIL.Emit(OpCodes.Ldloc_S, v3);
	myFCIL.Emit(OpCodes.Ldlen);
	myFCIL.Emit(OpCodes.Conv_I4);
	myFCIL.Emit(OpCodes.Blt_S, topOfForEachLabel);
	//foreach loop end here.

	myFCIL.Emit(OpCodes.Ldstr, "---");
	myFCIL.EmitCall(OpCodes.Call, writeLine0objMI, null);
	myFCIL.Emit(OpCodes.Ldstr, "There are {0} files in {1}.");
	myFCIL.Emit(OpCodes.Ldloc_S, v1);
	myFCIL.Emit(OpCodes.Box, typeof(int));
	myFCIL.Emit(OpCodes.Ldloc_S, v0);
	myFCIL.EmitCall(OpCodes.Call, writeLine2objMI, null);

	myFCIL.Emit(OpCodes.Ret);

	Type myType = myTypeBuilder.CreateType();

	myAsmBuilder.SetEntryPoint(myFCMethod);
	myAsmBuilder.Save(executableName);		
	Console.WriteLine("-- Method generated, type completed, and assembly saved to disk."); 

	return myType;

   }

   public static void Main() 
   {

	string domainDir, executableName = null;
	
	Console.Write("Enter a name for the file counting assembly: ");
	string executableNameNoExe = Console.ReadLine();
	executableName = executableNameNoExe + ".exe";
	Console.WriteLine("---");

	domainDir = Environment.CurrentDirectory;

	AppDomain curDomain = Thread.GetDomain();	


	// Create a new AppDomain, with the current directory as the base.

	Console.WriteLine("Current Directory: {0}", Environment.CurrentDirectory);
	AppDomainSetup mySetupInfo = new AppDomainSetup();
	mySetupInfo.ApplicationBase = domainDir;
	mySetupInfo.ApplicationName = executableNameNoExe;
	mySetupInfo.LoaderOptimization = LoaderOptimization.SingleDomain;

	AppDomain myDomain = AppDomain.CreateDomain(executableNameNoExe,
					null, mySetupInfo);

	Console.WriteLine("Creating a new AppDomain '{0}'...",
					executableNameNoExe);

	Console.WriteLine("-- Base Directory = '{0}'", myDomain.BaseDirectory); 
	Console.WriteLine("-- Shadow Copy? = '{0}'", myDomain.ShadowCopyFiles); 

	Console.WriteLine("---");
	Type myFCType = CreateADynamicAssembly(ref curDomain, 
					 executableNameNoExe);

	Console.WriteLine("Loading '{0}' from '{1}'...", executableName,
			  myDomain.BaseDirectory.ToString());


	BindingFlags bFlags = (BindingFlags.Public | BindingFlags.CreateInstance |
			       BindingFlags.Instance);

	Object myObjInstance = myDomain.CreateInstanceAndUnwrap(executableNameNoExe,
				executableNameNoExe, false, bFlags, 
				null, null, null, null, null);

	Console.WriteLine("Executing method 'CountLocalFiles' in {0}...",
			   myObjInstance.ToString());

	myFCType.InvokeMember("CountLocalFiles", BindingFlags.InvokeMethod, null,
				myObjInstance, new object[] { });
			
		
   }

}

// </Snippet1>
