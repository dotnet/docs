
using System;
using System.Reflection;
using System.Reflection.Emit;

class MoreMethodBuilderSnippets

{
	
   public static void ContainerMethod(AssemblyBuilder myAsmBuilder)
   {

	// <Snippet1>
	ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule("MathFunctions");

	TypeBuilder myTypeBuilder = myModBuilder.DefineType("MyMathFunctions",
					TypeAttributes.Public);

	MethodBuilder myMthdBuilder = myTypeBuilder.DefineMethod("Adder",
					MethodAttributes.Public,
					typeof(int),
					new Type[] { typeof(int),
						     typeof(int) });

	// Create body via ILGenerator here ...

	Type myNewType = myTypeBuilder.CreateType();

	Module myModule = myMthdBuilder.GetModule();

 	Type[] myModTypes = myModule.GetTypes();
	Console.WriteLine("Module: {0}", myModule.Name);
	Console.WriteLine("------- with path {0}", myModule.FullyQualifiedName);
	Console.WriteLine("------- in assembly {0}", myModule.Assembly.FullName);
	foreach (Type myModType in myModTypes)
        {
		Console.WriteLine("------- has type {0}", myModType.FullName);
	}
	// </Snippet1>		
	
   }

}
