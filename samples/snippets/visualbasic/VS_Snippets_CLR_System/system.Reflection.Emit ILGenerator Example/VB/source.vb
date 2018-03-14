 ' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _


Class TestILGenerator
   
   
   Public Shared Function DynamicDotProductGen() As Type
      
      Dim ivType As Type = Nothing
      Dim ctorParams() As Type = {GetType(Integer), GetType(Integer), GetType(Integer)}
      
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "IntVectorAsm"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly( _
					    myAsmName, _
					    AssemblyBuilderAccess.RunAndSave)
      
      Dim IntVectorModule As ModuleBuilder = myAsmBuilder.DefineDynamicModule( _
					     "IntVectorModule", _
					     "Vector.dll")
      
      Dim ivTypeBld As TypeBuilder = IntVectorModule.DefineType("IntVector", TypeAttributes.Public)
      
      Dim xField As FieldBuilder = ivTypeBld.DefineField("x", _
						         GetType(Integer), _
						         FieldAttributes.Private)
      Dim yField As FieldBuilder = ivTypeBld.DefineField("y", _ 
						         GetType(Integer), _
						         FieldAttributes.Private)
      Dim zField As FieldBuilder = ivTypeBld.DefineField("z", _
						         GetType(Integer), _
						         FieldAttributes.Private)
      
      
      Dim objType As Type = Type.GetType("System.Object")
      Dim objCtor As ConstructorInfo = objType.GetConstructor(New Type() {})
      
      Dim ivCtor As ConstructorBuilder = ivTypeBld.DefineConstructor( _
					 MethodAttributes.Public, _
					 CallingConventions.Standard, _
					 ctorParams)
      Dim ctorIL As ILGenerator = ivCtor.GetILGenerator()
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Call, objCtor)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_1)
      ctorIL.Emit(OpCodes.Stfld, xField)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_2)
      ctorIL.Emit(OpCodes.Stfld, yField)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_3)
      ctorIL.Emit(OpCodes.Stfld, zField)
      ctorIL.Emit(OpCodes.Ret)
     

      ' Now, you'll construct the method find the dot product of two vectors. First,
      ' let's define the parameters that will be accepted by the method. In this case,
      ' it's an IntVector itself!

      Dim dpParams() As Type = {ivTypeBld}
      
      ' Here, you create a MethodBuilder containing the
      ' name, the attributes (public, static, private, and so on),
      ' the return type (int, in this case), and a array of Type
      ' indicating the type of each parameter. Since the sole parameter
      ' is a IntVector, the very class you're creating, you will
      ' pass in the TypeBuilder (which is derived from Type) instead of 
      ' a Type object for IntVector, avoiding an exception. 
      ' -- This method would be declared in VB.NET as:
      '    Public Function DotProduct(IntVector aVector) As Integer

      Dim dotProductMthd As MethodBuilder = ivTypeBld.DefineMethod("DotProduct", _
					    MethodAttributes.Public, GetType(Integer), _
                                            dpParams)
      
      ' A ILGenerator can now be spawned, attached to the MethodBuilder.
      Dim mthdIL As ILGenerator = dotProductMthd.GetILGenerator()
      
      ' Here's the body of our function, in MSIL form. We're going to find the
      ' "dot product" of the current vector instance with the passed vector 
      ' instance. For reference purposes, the equation is:
      ' (x1 * x2) + (y1 * y2) + (z1 * z2) = the dot product
      ' First, you'll load the reference to the current instance "this"
      ' stored in argument 0 (ldarg.0) onto the stack. Ldfld, the subsequent
      ' instruction, will pop the reference off the stack and look up the
      ' field "x", specified by the FieldInfo token "xField".
      mthdIL.Emit(OpCodes.Ldarg_0)
      mthdIL.Emit(OpCodes.Ldfld, xField)
      
      ' That completed, the value stored at field "x" is now atop the stack.
      ' Now, you'll do the same for the object reference we passed as a
      ' parameter, stored in argument 1 (ldarg.1). After Ldfld executed,
      ' you'll have the value stored in field "x" for the passed instance
      ' atop the stack.
      mthdIL.Emit(OpCodes.Ldarg_1)
      mthdIL.Emit(OpCodes.Ldfld, xField)
      
      ' There will now be two values atop the stack - the "x" value for the
      ' current vector instance, and the "x" value for the passed instance.
      ' You'll now multiply them, and push the result onto the evaluation stack.
      mthdIL.Emit(OpCodes.Mul_Ovf_Un)
      
      ' Now, repeat this for the "y" fields of both vectors.
      mthdIL.Emit(OpCodes.Ldarg_0)
      mthdIL.Emit(OpCodes.Ldfld, yField)
      mthdIL.Emit(OpCodes.Ldarg_1)
      mthdIL.Emit(OpCodes.Ldfld, yField)
      mthdIL.Emit(OpCodes.Mul_Ovf_Un)
      
      ' At this time, the results of both multiplications should be atop
      ' the stack. You'll now add them and push the result onto the stack.
      mthdIL.Emit(OpCodes.Add_Ovf_Un)
      
      ' Multiply both "z" field and push the result onto the stack.
      mthdIL.Emit(OpCodes.Ldarg_0)
      mthdIL.Emit(OpCodes.Ldfld, zField)
      mthdIL.Emit(OpCodes.Ldarg_1)
      mthdIL.Emit(OpCodes.Ldfld, zField)
      mthdIL.Emit(OpCodes.Mul_Ovf_Un)
      
      ' Finally, add the result of multiplying the "z" fields with the
      ' result of the earlier addition, and push the result - the dot product -
      ' onto the stack.
      mthdIL.Emit(OpCodes.Add_Ovf_Un)
      
      ' The "ret" opcode will pop the last value from the stack and return it
      ' to the calling method. You're all done!
      mthdIL.Emit(OpCodes.Ret)
      
      
      ivType = ivTypeBld.CreateType()
      
      Return ivType
   End Function 'DynamicDotProductGen
    
   
   Public Shared Sub Main()
      
      Dim IVType As Type = Nothing
      Dim aVector1 As Object = Nothing
      Dim aVector2 As Object = Nothing
      Dim aVtypes() As Type = {GetType(Integer), GetType(Integer), GetType(Integer)}
      Dim aVargs1() As Object = {10, 10, 10}
      Dim aVargs2() As Object = {20, 20, 20}
      
      ' Call the  method to build our dynamic class.
      IVType = DynamicDotProductGen()
      
      
      Dim myDTctor As ConstructorInfo = IVType.GetConstructor(aVtypes)
      aVector1 = myDTctor.Invoke(aVargs1)
      aVector2 = myDTctor.Invoke(aVargs2)
      
      Console.WriteLine("---")
      Dim passMe(0) As Object
      passMe(0) = CType(aVector2, Object)
      
      Console.WriteLine("(10, 10, 10) . (20, 20, 20) = {0}", _
                        IVType.InvokeMember("DotProduct", BindingFlags.InvokeMethod, _
                        Nothing, aVector1, passMe))
   End Sub 'Main
End Class 'TestILGenerator



' +++ OUTPUT +++
' ---
' (10, 10, 10) . (20, 20, 20) = 600 


' </Snippet1>