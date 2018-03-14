
using System;
using System.Reflection;
using System.Reflection.Emit;

class MethodBuilderAssortedMembersDemo

{

   public static void MemberSnippets(TypeBuilder myTypeBuilder) {

	// <Snippet1>
	MethodBuilder myMthdBuilder = myTypeBuilder.DefineMethod("MyMethod",
						MethodAttributes.Public,
						CallingConventions.HasThis,
						typeof(int),
						new Type[] { typeof(int),
							     typeof(int) });	

	// Specifies that the dynamic method declared above has a an MSIL implementation,
        // is managed, synchronized (single-threaded) through the body, and that it 
	// cannot be inlined.
 
	myMthdBuilder.SetImplementationFlags(MethodImplAttributes.IL |
					     MethodImplAttributes.Managed |
					     MethodImplAttributes.Synchronized |
					     MethodImplAttributes.NoInlining);

	// Create an ILGenerator for the MethodBuilder and emit MSIL here ...

	// </Snippet1>

   }

}
