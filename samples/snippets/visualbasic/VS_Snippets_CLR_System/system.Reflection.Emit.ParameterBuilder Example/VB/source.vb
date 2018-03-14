' <Snippet1>

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class ParamBuilderDemo
   
   Public Shared Function BuildCustomerDataType() As Type
      
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, _
						AssemblyBuilderAccess.Run)
      
      Dim myModBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyMod")
      
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType("CustomerData", TypeAttributes.Public)
      
      Dim customerNameBldr As FieldBuilder = myTypeBuilder.DefineField("customerName", _
								GetType(String), _
								FieldAttributes.Private)
      Dim acctIDBldr As FieldBuilder = myTypeBuilder.DefineField("acctID", _
								GetType(String), _
								FieldAttributes.Private)
      Dim balanceAmtBldr As FieldBuilder = myTypeBuilder.DefineField("balanceAmt", _
								GetType(Double), _
								FieldAttributes.Private)
      
      Dim myCtorBuilder As ConstructorBuilder = myTypeBuilder.DefineConstructor(MethodAttributes.Public, _
								CallingConventions.HasThis, _
								New Type() {GetType(String), _
									    GetType(String), _
									    GetType(Double)})
      
      
      Dim ctorIL As ILGenerator = myCtorBuilder.GetILGenerator()
      
      Dim objType As Type = Type.GetType("System.Object")
      Dim objCtor As ConstructorInfo = objType.GetConstructor(New Type(){})
      
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Call, objCtor)
      
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_1)
      ctorIL.Emit(OpCodes.Stfld, customerNameBldr)
      
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_2)
      ctorIL.Emit(OpCodes.Stfld, acctIDBldr)
      
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_3)
      ctorIL.Emit(OpCodes.Stfld, balanceAmtBldr)
      
      ctorIL.Emit(OpCodes.Ret)
      
      ' This method will take an amount from a static pool and add it to the balance.
      ' Note that we are passing the first parameter, fundsPool, by reference. Therefore,
      ' we need to inform the MethodBuilder to expect a ref, by declaring the first
      ' parameter's type to be System.Double& (a reference to a double).

      Dim myMthdBuilder As MethodBuilder = myTypeBuilder.DefineMethod("AddFundsFromPool", _
								MethodAttributes.Public, _
								GetType(Double), _
								New Type() {Type.GetType("System.Double&"), _
										 GetType(Double)})
      
      Dim poolRefBuilder As ParameterBuilder = myMthdBuilder.DefineParameter(1, _
							ParameterAttributes.Out, "fundsPool")
      
      Dim amountFromPoolBuilder As ParameterBuilder = myMthdBuilder.DefineParameter(2, _
							ParameterAttributes.In, "amountFromPool")
      
      Dim mthdIL As ILGenerator = myMthdBuilder.GetILGenerator()
      
      mthdIL.Emit(OpCodes.Ldarg_1)
      mthdIL.Emit(OpCodes.Ldarg_1)
      mthdIL.Emit(OpCodes.Ldind_R8)
      mthdIL.Emit(OpCodes.Ldarg_2)
      mthdIL.Emit(OpCodes.Sub)
      
      mthdIL.Emit(OpCodes.Stind_R8)
      
      mthdIL.Emit(OpCodes.Ldarg_0)
      mthdIL.Emit(OpCodes.Ldarg_0)
      mthdIL.Emit(OpCodes.Ldfld, balanceAmtBldr)
      mthdIL.Emit(OpCodes.Ldarg_2)
      mthdIL.Emit(OpCodes.Add)
      
      mthdIL.Emit(OpCodes.Stfld, balanceAmtBldr)
      
      mthdIL.Emit(OpCodes.Ldarg_0)
      mthdIL.Emit(OpCodes.Ldfld, balanceAmtBldr)
      mthdIL.Emit(OpCodes.Ret)
      
      Return myTypeBuilder.CreateType()

   End Function 'BuildCustomerDataType
    
   
   Public Shared Sub Main()

      Dim custType As Type = Nothing
      Dim custObj As Object = Nothing
      
      Dim custArgTypes() As Type = {GetType(String), GetType(String), GetType(Double)}
      
      ' Call the method to build our dynamic class.
      custType = BuildCustomerDataType()
      
      Console.WriteLine("---")
      
      Dim myCustCtor As ConstructorInfo = custType.GetConstructor(custArgTypes)
      Dim initialBalance As Double = 100.0
      custObj = myCustCtor.Invoke(New Object() {"Joe Consumer", "5678-XYZ", initialBalance})
      
      Dim myMemberInfo As MemberInfo() = custType.GetMember("AddFundsFromPool")
      
      
      Dim thePool As Double = 1000.0
      Console.WriteLine("The pool is currently ${0}", thePool)
      Console.WriteLine("The original balance of the account instance is ${0}", initialBalance)
      
      Dim amountFromPool As Double = 50.0
      Console.WriteLine("The amount to be subtracted from the pool and added " & _
			"to the account is ${0}", amountFromPool)
      
      Console.WriteLine("---")
      Console.WriteLine("Calling {0} ...", myMemberInfo(0).ToString())
      Console.WriteLine("---")
      
      Dim passMe() As Object = {thePool, amountFromPool}
      Console.WriteLine("The new balance in the account instance is ${0}", _
				custType.InvokeMember("AddFundsFromPool", _
				BindingFlags.InvokeMethod, Nothing, custObj, passMe))
      thePool = CDbl(passMe(0))
      Console.WriteLine("The new amount in the pool is ${0}", thePool)

   End Sub 'Main 

End Class 'ParamBuilderDemo

' </Snippet1>
