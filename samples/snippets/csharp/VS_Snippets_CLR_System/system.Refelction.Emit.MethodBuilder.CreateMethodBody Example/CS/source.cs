// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class MethodBodyDemo {
// This class will demonstrate how to create a method body using 
// the MethodBuilder.CreateMethodBody(byte[], int) method.

   public static Type BuildDynType() {
    
  	Type addType = null;

    	AppDomain currentDom = Thread.GetDomain();

        AssemblyName myAsmName = new AssemblyName();
	myAsmName.Name = "MyDynamicAssembly";

        AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
					       myAsmName,
					       AssemblyBuilderAccess.RunAndSave);

        // The dynamic assembly space has been created.  Next, create a module
        // within it.  The type Point will be reflected into this module.

	ModuleBuilder myModuleBldr = myAsmBldr.DefineDynamicModule("MyModule");
      
	TypeBuilder myTypeBldr =  myModuleBldr.DefineType("Adder");

        MethodBuilder myMthdBldr = myTypeBldr.DefineMethod("DoAdd",
							    MethodAttributes.Public |
							    MethodAttributes.Static,
							    typeof(int),
							    new Type[] 
							    {typeof(int), typeof(int)});
        // Build the array of Bytes holding the MSIL instructions.

        byte[] ILcodes = new byte[] {
          0x02,   /* 02h is the opcode for ldarg.0 */
	  0x03,   /* 03h is the opcode for ldarg.1 */
	  0x58,   /* 58h is the opcode for add     */
	  0x2A    /* 2Ah is the opcode for ret     */
	};
	
	myMthdBldr.CreateMethodBody(ILcodes, ILcodes.Length);

        addType = myTypeBldr.CreateType();

	return addType;
   }

   public static void Main() {

	Type myType = BuildDynType(); 
        Console.WriteLine("---");
	Console.Write("Enter the first integer to add: "); 
        int aVal = Convert.ToInt32(Console.ReadLine());
     
     	Console.Write("Enter the second integer to add: ");
     	int bVal = Convert.ToInt32(Console.ReadLine());
   
     	object adderInst = Activator.CreateInstance(myType, new object[0]); 

	Console.WriteLine("The value of adding {0} to {1} is: {2}.",
			   aVal, bVal,	
     			   myType.InvokeMember("DoAdd",
			  		       BindingFlags.InvokeMethod,
			  		       null,
			  		       adderInst,
			  		       new object[] {aVal, bVal})); 
   }

}

// </Snippet1>
