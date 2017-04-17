
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class MyDynamicAssembly
   
   
   
   Public Shared Sub BuildDynamicMethod(myTypeBuilder As TypeBuilder, _
					mthdParamTypes() As Type, _
					returnType As Type, _
					addrOfLegacyNumberObject As Integer)
      
      	' <Snippet1>
      	Dim myMthdBuilder As MethodBuilder = myTypeBuilder.DefineMethod("MyMethod", _
						MethodAttributes.Public, _
						returnType, mthdParamTypes)
      
      	' We will assume that an external unmanaged type "LegacyNumber" has been loaded, and
      	' that it has a method "ToString" which returns a string.

      	Dim unmanagedMthdMI As MethodInfo = Type.GetType("LegacyNumber").GetMethod("ToString")
      	Dim myMthdIL As ILGenerator = myMthdBuilder.GetILGenerator()
      
      	' Code to emit various IL opcodes here ...
      	' Load a reference to the specific object instance onto the stack.

      	myMthdIL.Emit(OpCodes.Ldc_I4, addrOfLegacyNumberObject)
      	myMthdIL.Emit(OpCodes.Ldobj, Type.GetType("LegacyNumber"))
      
      	' Make the call to the unmanaged type method, telling it that the method is
      	' the member of a specific instance, to expect a string 
      	' as a return value, and that there are no explicit parameters.

      	myMthdIL.EmitCalli(OpCodes.Calli, System.Runtime.InteropServices.CallingConvention.ThisCall, _
					  GetType(String), New Type() {})

	' More IL code emission here ...
	' </Snippet1>

   End Sub 'BuildDynamicMethod

End Class 'MyDynamicAssembly

