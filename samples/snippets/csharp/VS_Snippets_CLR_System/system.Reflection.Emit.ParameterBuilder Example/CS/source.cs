// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class ParamBuilderDemo 

{

   public static Type BuildCustomerDataType()
   {

	AppDomain myDomain = Thread.GetDomain();
	AssemblyName myAsmName = new AssemblyName();
	myAsmName.Name = "MyDynamicAssembly";

	AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName,
						AssemblyBuilderAccess.Run);

	ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule("MyMod");

	TypeBuilder myTypeBuilder = myModBuilder.DefineType("CustomerData",
						TypeAttributes.Public);

	FieldBuilder customerNameBldr = myTypeBuilder.DefineField("customerName",
							typeof(string),
							FieldAttributes.Private);
	FieldBuilder acctIDBldr = myTypeBuilder.DefineField("acctID",
						 	typeof(string),
							FieldAttributes.Private);
	FieldBuilder balanceAmtBldr = myTypeBuilder.DefineField("balanceAmt",
							typeof(double),
							FieldAttributes.Private);
								
	ConstructorBuilder myCtorBuilder = myTypeBuilder.DefineConstructor(
							MethodAttributes.Public,
							CallingConventions.HasThis, 
							new Type[] { typeof(string),
								     typeof(string),
								     typeof(double) });


	ILGenerator ctorIL = myCtorBuilder.GetILGenerator();

	Type objType = Type.GetType("System.Object"); 
        ConstructorInfo objCtor = objType.GetConstructor(new Type[] {});

	ctorIL.Emit(OpCodes.Ldarg_0);
	ctorIL.Emit(OpCodes.Call, objCtor);

	ctorIL.Emit(OpCodes.Ldarg_0);
	ctorIL.Emit(OpCodes.Ldarg_1);
	ctorIL.Emit(OpCodes.Stfld, customerNameBldr);

	ctorIL.Emit(OpCodes.Ldarg_0);
	ctorIL.Emit(OpCodes.Ldarg_2);
	ctorIL.Emit(OpCodes.Stfld, acctIDBldr);

	ctorIL.Emit(OpCodes.Ldarg_0);
	ctorIL.Emit(OpCodes.Ldarg_3);
	ctorIL.Emit(OpCodes.Stfld, balanceAmtBldr);

	ctorIL.Emit(OpCodes.Ret);

	// This method will take an amount from a static pool and add it to the balance.
       
	// Note that we are passing the first parameter, fundsPool, by reference. Therefore,
	// we need to inform the MethodBuilder to expect a ref, by declaring the first
	// parameter's type to be System.Double& (a reference to a double).
 
	MethodBuilder myMthdBuilder = myTypeBuilder.DefineMethod("AddFundsFromPool",
						MethodAttributes.Public,
						typeof(double),
						new Type[] { Type.GetType("System.Double&"),
							     typeof(double) });

	ParameterBuilder poolRefBuilder = myMthdBuilder.DefineParameter(1,
						ParameterAttributes.Out,
						"fundsPool");

	ParameterBuilder amountFromPoolBuilder = myMthdBuilder.DefineParameter(2,
						ParameterAttributes.In,
					        "amountFromPool");

	ILGenerator mthdIL = myMthdBuilder.GetILGenerator();

	mthdIL.Emit(OpCodes.Ldarg_1); 
	mthdIL.Emit(OpCodes.Ldarg_1); 
	mthdIL.Emit(OpCodes.Ldind_R8);
	mthdIL.Emit(OpCodes.Ldarg_2);
	mthdIL.Emit(OpCodes.Sub);

	mthdIL.Emit(OpCodes.Stind_R8);

	mthdIL.Emit(OpCodes.Ldarg_0);
	mthdIL.Emit(OpCodes.Ldarg_0);
	mthdIL.Emit(OpCodes.Ldfld, balanceAmtBldr);
	mthdIL.Emit(OpCodes.Ldarg_2);
	mthdIL.Emit(OpCodes.Add);

	mthdIL.Emit(OpCodes.Stfld, balanceAmtBldr);

	mthdIL.Emit(OpCodes.Ldarg_0);
	mthdIL.Emit(OpCodes.Ldfld, balanceAmtBldr);
	mthdIL.Emit(OpCodes.Ret);

	return myTypeBuilder.CreateType();

   }

   public static void Main()
   {
 	Type custType = null;
	object custObj = null;

	Type[] custArgTypes = new Type[] {typeof(string), typeof(string), typeof(double)};
	
	// Call the method to build our dynamic class.

	custType = BuildCustomerDataType();

	Console.WriteLine("---");

	ConstructorInfo myCustCtor = custType.GetConstructor(custArgTypes);
	double initialBalance = 100.00;
	custObj = myCustCtor.Invoke(new object[] { "Joe Consumer", 
						   "5678-XYZ", 
					  	   initialBalance });

	MemberInfo[] myMemberInfo = custType.GetMember("AddFundsFromPool");


	double thePool = 1000.00;
	Console.WriteLine("The pool is currently ${0}", thePool);
	Console.WriteLine("The original balance of the account instance is ${0}",
							initialBalance);

	double amountFromPool = 50.00;
	Console.WriteLine("The amount to be subtracted from the pool and added " +
			  "to the account is ${0}", amountFromPool);
	
	Console.WriteLine("---");
	Console.WriteLine("Calling {0} ...", myMemberInfo[0].ToString());
	Console.WriteLine("---");

	object[] passMe = new object[] { thePool, amountFromPool };
	Console.WriteLine("The new balance in the account instance is ${0}",
					custType.InvokeMember("AddFundsFromPool",
					BindingFlags.InvokeMethod,
					null, custObj, passMe));
	thePool = (double)passMe[0];
	Console.WriteLine("The new amount in the pool is ${0}", thePool);

   }

}

// </Snippet1>
