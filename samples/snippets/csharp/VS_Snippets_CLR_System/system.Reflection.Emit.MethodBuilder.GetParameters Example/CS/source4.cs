
using System;
using System.Reflection;
using System.Reflection.Emit;

class MoreMethodBuilderSnippets

{
	
   public static void ContainerMethod(ModuleBuilder myModBuilder)
   {

	// <Snippet1>	

	TypeBuilder myType1 = myModBuilder.DefineType("MyMathFunctions",
					TypeAttributes.Public);

	MethodBuilder myMthdBuilder = myType1.DefineMethod("AddToRefValue",
					MethodAttributes.Public,
					typeof(void),
					new Type[] { Type.GetType("System.Int32&"),
						     typeof(int) });
	ParameterBuilder myParam1 = myMthdBuilder.DefineParameter(1,
					ParameterAttributes.Out,
					"thePool");
	ParameterBuilder myParam2 = myMthdBuilder.DefineParameter(2,
					ParameterAttributes.In,
					"addMeToPool");

	// Create body via ILGenerator here, and complete the type.

	ParameterInfo[] myParams = myMthdBuilder.GetParameters();

	Console.WriteLine("Method: {0}", myMthdBuilder.Name);

	foreach (ParameterInfo myParam in myParams)
        {
	   Console.WriteLine("------- Parameter: {0} {1} at pos {2}, with attribute {3}", 
			     myParam.ParameterType, myParam.Name, myParam.Position,
			     myParam.Attributes.ToString());

        }
	
	// </Snippet1>	
   }

}
