' <Snippet1>

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class EmitWriteLineDemo
   
   
   Public Shared Function CreateDynamicType() As Type

      Dim ctorParams() As Type = {GetType(Integer), GetType(Integer)}
      
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave)
      
      Dim pointModule As ModuleBuilder = myAsmBuilder.DefineDynamicModule("PointModule", "Point.dll")
      
      Dim pointTypeBld As TypeBuilder = pointModule.DefineType("Point", _
							       TypeAttributes.Public)
      
      Dim xField As FieldBuilder = pointTypeBld.DefineField("x", _
							    GetType(Integer), _
							    FieldAttributes.Public)
      Dim yField As FieldBuilder = pointTypeBld.DefineField("y", _
							    GetType(Integer), _
						 	    FieldAttributes.Public)
      
      
      Dim objType As Type = Type.GetType("System.Object")
      Dim objCtor As ConstructorInfo = objType.GetConstructor(New Type(){})
      
      Dim pointCtor As ConstructorBuilder = pointTypeBld.DefineConstructor( _
							 MethodAttributes.Public, _
							 CallingConventions.Standard, _
							 ctorParams)
      Dim ctorIL As ILGenerator = pointCtor.GetILGenerator()
      
      
      ' First, you build the constructor.

      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Call, objCtor)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_1)
      ctorIL.Emit(OpCodes.Stfld, xField)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_2)
      ctorIL.Emit(OpCodes.Stfld, yField)
      ctorIL.Emit(OpCodes.Ret)
      
      '  Now, you'll build a method to output some information on the
      ' inside your dynamic class. This method will have the following
      ' definition in C#:
      '  Public Sub WritePoint() 

      Dim writeStrMthd As MethodBuilder = pointTypeBld.DefineMethod("WritePoint", _
								    MethodAttributes.Public, _
								    Nothing, Nothing)
      
      Dim writeStrIL As ILGenerator = writeStrMthd.GetILGenerator()
      
      ' The below ILGenerator created demonstrates a few ways to create
      ' string output through STDIN. 
      ' ILGenerator.EmitWriteLine(string) will generate a ldstr and a 
      ' call to WriteLine for you.

      writeStrIL.EmitWriteLine("The value of this current instance is:")
      
      ' Here, you will do the hard work yourself. First, you need to create
      ' the string we will be passing and obtain the correct WriteLine overload
      ' for said string. In the below case, you are substituting in two values,
      ' so the chosen overload is Console.WriteLine(string, object, object).

      Dim inStr As [String] = "({0}, {1})"
      Dim wlParams() As Type = {GetType(String), GetType(Object), GetType(Object)}
      
      ' We need the MethodInfo to pass into EmitCall later.

      Dim writeLineMI As MethodInfo = GetType(Console).GetMethod("WriteLine", wlParams)
      
      ' Push the string with the substitutions onto the stack.
      ' This is the first argument for WriteLine - the string one. 

      writeStrIL.Emit(OpCodes.Ldstr, inStr)
      
      ' Since the second argument is an object, and it corresponds to
      ' to the substitution for the value of our integer field, you 
      ' need to box that field to an object. First, push a reference
      ' to the current instance, and then push the value stored in
      ' field 'x'. We need the reference to the current instance (stored
      ' in local argument index 0) so Ldfld can load from the correct
      ' instance (this one).

      writeStrIL.Emit(OpCodes.Ldarg_0)
      writeStrIL.Emit(OpCodes.Ldfld, xField)
      
      ' Now, we execute the box opcode, which pops the value of field 'x',
      ' returning a reference to the integer value boxed as an object.

      writeStrIL.Emit(OpCodes.Box, GetType(Integer))
      
      ' Atop the stack, you'll find our string inStr, followed by a reference
      ' to the boxed value of 'x'. Now, you need to likewise box field 'y'.

      writeStrIL.Emit(OpCodes.Ldarg_0)
      writeStrIL.Emit(OpCodes.Ldfld, yField)
      writeStrIL.Emit(OpCodes.Box, GetType(Integer))
      
      ' Now, you have all of the arguments for your call to
      ' Console.WriteLine(string, object, object) atop the stack:
      ' the string InStr, a reference to the boxed value of 'x', and
      ' a reference to the boxed value of 'y'.
      ' Call Console.WriteLine(string, object, object) with EmitCall.

      writeStrIL.EmitCall(OpCodes.Call, writeLineMI, Nothing)
      
      ' Lastly, EmitWriteLine can also output the value of a field
      ' using the overload EmitWriteLine(FieldInfo).

      writeStrIL.EmitWriteLine("The value of 'x' is:")
      writeStrIL.EmitWriteLine(xField)
      writeStrIL.EmitWriteLine("The value of 'y' is:")
      writeStrIL.EmitWriteLine(yField)
      
      ' Since we return no value (void), the the ret opcode will not
      ' return the top stack value.

      writeStrIL.Emit(OpCodes.Ret)
      
      Return pointTypeBld.CreateType()

   End Function 'CreateDynamicType
    
   
   Public Shared Sub Main()
      
      Dim ctorParams(1) As Object
      
      Console.Write("Enter a integer value for X: ")
      Dim myX As String = Console.ReadLine()
      Console.Write("Enter a integer value for Y: ")
      Dim myY As String = Console.ReadLine()
      
      Console.WriteLine("---")
      
      ctorParams(0) = Convert.ToInt32(myX)
      ctorParams(1) = Convert.ToInt32(myY)
      
      Dim ptType As Type = CreateDynamicType()

      Dim ptInstance As Object = Activator.CreateInstance(ptType, ctorParams)

      ptType.InvokeMember("WritePoint", _
			  BindingFlags.InvokeMethod, _
			  Nothing, ptInstance, Nothing)

   End Sub 'Main

End Class 'EmitWriteLineDemo

' </Snippet1>