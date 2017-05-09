// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class EmitWriteLineDemo {

   public static Type CreateDynamicType() {       
       Type[] ctorParams = new Type[] {typeof(int),
				   typeof(int)};
 	
       AppDomain myDomain = Thread.GetDomain();
       AssemblyName myAsmName = new AssemblyName();
       myAsmName.Name = "MyDynamicAssembly";

       AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
				      myAsmName, 
				      AssemblyBuilderAccess.Run);

       ModuleBuilder pointModule = myAsmBuilder.DefineDynamicModule("PointModule",
								    "Point.dll");

       TypeBuilder pointTypeBld = pointModule.DefineType("Point",
					              TypeAttributes.Public);

       FieldBuilder xField = pointTypeBld.DefineField("x", typeof(int),
                                                      FieldAttributes.Public);
       FieldBuilder yField = pointTypeBld.DefineField("y", typeof(int), 
                                                      FieldAttributes.Public);


       Type objType = Type.GetType("System.Object"); 
       ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);

       ConstructorBuilder pointCtor = pointTypeBld.DefineConstructor(
 				                   MethodAttributes.Public,
				                   CallingConventions.Standard,
				                   ctorParams);
       ILGenerator ctorIL = pointCtor.GetILGenerator();


       // First, you build the constructor.
       ctorIL.Emit(OpCodes.Ldarg_0);
       ctorIL.Emit(OpCodes.Call, objCtor);
       ctorIL.Emit(OpCodes.Ldarg_0);
       ctorIL.Emit(OpCodes.Ldarg_1);
       ctorIL.Emit(OpCodes.Stfld, xField); 
       ctorIL.Emit(OpCodes.Ldarg_0);
       ctorIL.Emit(OpCodes.Ldarg_2);
       ctorIL.Emit(OpCodes.Stfld, yField); 
       ctorIL.Emit(OpCodes.Ret); 

       //  Now, you'll build a method to output some information on the
       // inside your dynamic class. This method will have the following
       // definition in C#:
	//  public void WritePoint()
      
       MethodBuilder writeStrMthd = pointTypeBld.DefineMethod(
        		                     "WritePoint", 
				             MethodAttributes.Public,
                                             typeof(void), 
                                             null);

       
       ILGenerator writeStrIL = writeStrMthd.GetILGenerator();
      
       // The below ILGenerator created demonstrates a few ways to create
       // string output through STDIN. 

       // ILGenerator.EmitWriteLine(string) will generate a ldstr and a 
       // call to WriteLine for you.

       writeStrIL.EmitWriteLine("The value of this current instance is:");

       // Here, you will do the hard work yourself. First, you need to create
       // the string we will be passing and obtain the correct WriteLine overload
       // for said string. In the below case, you are substituting in two values,
       // so the chosen overload is Console.WriteLine(string, object, object).

       String inStr = "({0}, {1})";
       Type[] wlParams = new Type[] {typeof(string),
				     typeof(object),
				     typeof(object)};

       // We need the MethodInfo to pass into EmitCall later.

       MethodInfo writeLineMI = typeof(Console).GetMethod(
					        "WriteLine",
						wlParams);

       // Push the string with the substitutions onto the stack.
       // This is the first argument for WriteLine - the string one. 

       writeStrIL.Emit(OpCodes.Ldstr, inStr);

       // Since the second argument is an object, and it corresponds to
       // to the substitution for the value of our integer field, you 
       // need to box that field to an object. First, push a reference
       // to the current instance, and then push the value stored in
       // field 'x'. We need the reference to the current instance (stored
       // in local argument index 0) so Ldfld can load from the correct
       // instance (this one).

       writeStrIL.Emit(OpCodes.Ldarg_0);
       writeStrIL.Emit(OpCodes.Ldfld, xField);

       // Now, we execute the box opcode, which pops the value of field 'x',
       // returning a reference to the integer value boxed as an object.

       writeStrIL.Emit(OpCodes.Box, typeof(int));

       // Atop the stack, you'll find our string inStr, followed by a reference
       // to the boxed value of 'x'. Now, you need to likewise box field 'y'.

       writeStrIL.Emit(OpCodes.Ldarg_0);
       writeStrIL.Emit(OpCodes.Ldfld, yField);
       writeStrIL.Emit(OpCodes.Box, typeof(int));

       // Now, you have all of the arguments for your call to
       // Console.WriteLine(string, object, object) atop the stack:
       // the string InStr, a reference to the boxed value of 'x', and
       // a reference to the boxed value of 'y'.

       // Call Console.WriteLine(string, object, object) with EmitCall.

       writeStrIL.EmitCall(OpCodes.Call, writeLineMI, null);

       // Lastly, EmitWriteLine can also output the value of a field
       // using the overload EmitWriteLine(FieldInfo).

       writeStrIL.EmitWriteLine("The value of 'x' is:");
       writeStrIL.EmitWriteLine(xField);
       writeStrIL.EmitWriteLine("The value of 'y' is:");
       writeStrIL.EmitWriteLine(yField);

       // Since we return no value (void), the the ret opcode will not
       // return the top stack value.

       writeStrIL.Emit(OpCodes.Ret);
      
       return pointTypeBld.CreateType();

   }

   public static void Main() {

      object[] ctorParams = new object[2];

      Console.Write("Enter a integer value for X: "); 
      string myX = Console.ReadLine();
      Console.Write("Enter a integer value for Y: "); 
      string myY = Console.ReadLine();

      Console.WriteLine("---");

      ctorParams[0] = Convert.ToInt32(myX);
      ctorParams[1] = Convert.ToInt32(myY);

      Type ptType = CreateDynamicType();
  
      object ptInstance = Activator.CreateInstance(ptType, ctorParams);
      ptType.InvokeMember("WritePoint",
			  BindingFlags.InvokeMethod,
			  null,
			  ptInstance,
			  new object[0]);
   }
}

// </Snippet1>
