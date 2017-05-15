// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class DynamicJumpTableDemo

{

   public static Type BuildMyType()
   {
	AppDomain myDomain = Thread.GetDomain();
	AssemblyName myAsmName = new AssemblyName();
	myAsmName.Name = "MyDynamicAssembly";

	AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
						myAsmName,
						AssemblyBuilderAccess.Run);
	ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(
						"MyJumpTableDemo");

	TypeBuilder myTypeBuilder = myModBuilder.DefineType("JumpTableDemo",
							TypeAttributes.Public);
	MethodBuilder myMthdBuilder = myTypeBuilder.DefineMethod("SwitchMe", 
				             MethodAttributes.Public |
				             MethodAttributes.Static,
                                             typeof(string), 
                                             new Type[] {typeof(int)});

	ILGenerator myIL = myMthdBuilder.GetILGenerator();

	Label defaultCase = myIL.DefineLabel();	
	Label endOfMethod = myIL.DefineLabel();	

	// We are initializing our jump table. Note that the labels
	// will be placed later using the MarkLabel method. 

	Label[] jumpTable = new Label[] { myIL.DefineLabel(),
					  myIL.DefineLabel(),
					  myIL.DefineLabel(),
					  myIL.DefineLabel(),
					  myIL.DefineLabel() };

	// arg0, the number we passed, is pushed onto the stack.
	// In this case, due to the design of the code sample,
	// the value pushed onto the stack happens to match the
	// index of the label (in IL terms, the index of the offset
	// in the jump table). If this is not the case, such as
	// when switching based on non-integer values, rules for the correspondence
	// between the possible case values and each index of the offsets
	// must be established outside of the ILGenerator.Emit calls,
	// much as a compiler would.

	myIL.Emit(OpCodes.Ldarg_0);
	myIL.Emit(OpCodes.Switch, jumpTable);
	
	// Branch on default case
	myIL.Emit(OpCodes.Br_S, defaultCase);

	// Case arg0 = 0
	myIL.MarkLabel(jumpTable[0]); 
	myIL.Emit(OpCodes.Ldstr, "are no bananas");
	myIL.Emit(OpCodes.Br_S, endOfMethod);

	// Case arg0 = 1
	myIL.MarkLabel(jumpTable[1]); 
	myIL.Emit(OpCodes.Ldstr, "is one banana");
	myIL.Emit(OpCodes.Br_S, endOfMethod);

	// Case arg0 = 2
	myIL.MarkLabel(jumpTable[2]); 
	myIL.Emit(OpCodes.Ldstr, "are two bananas");
	myIL.Emit(OpCodes.Br_S, endOfMethod);

	// Case arg0 = 3
	myIL.MarkLabel(jumpTable[3]); 
	myIL.Emit(OpCodes.Ldstr, "are three bananas");
	myIL.Emit(OpCodes.Br_S, endOfMethod);

	// Case arg0 = 4
	myIL.MarkLabel(jumpTable[4]); 
	myIL.Emit(OpCodes.Ldstr, "are four bananas");
	myIL.Emit(OpCodes.Br_S, endOfMethod);

	// Default case
	myIL.MarkLabel(defaultCase);
	myIL.Emit(OpCodes.Ldstr, "are many bananas");

	myIL.MarkLabel(endOfMethod);
	myIL.Emit(OpCodes.Ret);
	
	return myTypeBuilder.CreateType();

   }

   public static void Main()
   {
	Type myType = BuildMyType();
	
	Console.Write("Enter an integer between 0 and 5: ");
	int theValue = Convert.ToInt32(Console.ReadLine());

	Console.WriteLine("---");
	Object myInstance = Activator.CreateInstance(myType, new object[0]);	
	Console.WriteLine("Yes, there {0} today!", myType.InvokeMember("SwitchMe",
			  		           BindingFlags.InvokeMethod,
			  		           null,
			  		           myInstance,
			  		           new object[] {theValue}));  
			  
   }

}

// </Snippet1>
