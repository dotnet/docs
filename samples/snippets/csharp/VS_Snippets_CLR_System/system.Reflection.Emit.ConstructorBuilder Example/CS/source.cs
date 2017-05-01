// <Snippet1>

using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

class TestCtorBuilder {
 
  	public static Type DynamicPointTypeGen() {
	  
	   Type pointType = null;
	   Type[] ctorParams = new Type[] {typeof(int),
					    typeof(int),
					    typeof(int)};
 	
	   AppDomain myDomain = Thread.GetDomain();
	   AssemblyName myAsmName = new AssemblyName();
	   myAsmName.Name = "MyDynamicAssembly";
	
	   AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(
					  myAsmName, 
					  AssemblyBuilderAccess.RunAndSave);

   	   ModuleBuilder pointModule = myAsmBuilder.DefineDynamicModule("PointModule",
									"Point.dll");

	   TypeBuilder pointTypeBld = pointModule.DefineType("Point",
						              TypeAttributes.Public);

	   FieldBuilder xField = pointTypeBld.DefineField("x", typeof(int),
                                                          FieldAttributes.Public);
	   FieldBuilder yField = pointTypeBld.DefineField("y", typeof(int), 
                                                          FieldAttributes.Public);
	   FieldBuilder zField = pointTypeBld.DefineField("z", typeof(int),
                                                          FieldAttributes.Public);


           Type objType = Type.GetType("System.Object"); 
           ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);

	   ConstructorBuilder pointCtor = pointTypeBld.DefineConstructor(
					  MethodAttributes.Public,
					  CallingConventions.Standard,
					  ctorParams);
	   ILGenerator ctorIL = pointCtor.GetILGenerator();

	   // NOTE: ldarg.0 holds the "this" reference - ldarg.1, ldarg.2, and ldarg.3
	   // hold the actual passed parameters. ldarg.0 is used by instance methods
	   // to hold a reference to the current calling object instance. Static methods
	   // do not use arg.0, since they are not instantiated and hence no reference
	   // is needed to distinguish them. 

           ctorIL.Emit(OpCodes.Ldarg_0);

	   // Here, we wish to create an instance of System.Object by invoking its
  	   // constructor, as specified above.

           ctorIL.Emit(OpCodes.Call, objCtor);

	   // Now, we'll load the current instance ref in arg 0, along
	   // with the value of parameter "x" stored in arg 1, into stfld.

           ctorIL.Emit(OpCodes.Ldarg_0);
           ctorIL.Emit(OpCodes.Ldarg_1);
           ctorIL.Emit(OpCodes.Stfld, xField); 

	   // Now, we store arg 2 "y" in the current instance with stfld.

           ctorIL.Emit(OpCodes.Ldarg_0);
           ctorIL.Emit(OpCodes.Ldarg_2);
           ctorIL.Emit(OpCodes.Stfld, yField); 

	   // Last of all, arg 3 "z" gets stored in the current instance.

           ctorIL.Emit(OpCodes.Ldarg_0);
           ctorIL.Emit(OpCodes.Ldarg_3);
           ctorIL.Emit(OpCodes.Stfld, zField); 
           
           // Our work complete, we return.

	   ctorIL.Emit(OpCodes.Ret); 

	   // Now, let's create three very simple methods so we can see our fields.

	   string[] mthdNames = new string[] {"GetX", "GetY", "GetZ"}; 

           foreach (string mthdName in mthdNames) {
              MethodBuilder getFieldMthd = pointTypeBld.DefineMethod(
				           mthdName, 
				           MethodAttributes.Public,
                                           typeof(int), 
                                           null);
	      ILGenerator mthdIL = getFieldMthd.GetILGenerator();
	   
	      mthdIL.Emit(OpCodes.Ldarg_0);
  	      switch (mthdName) {
	         case "GetX": mthdIL.Emit(OpCodes.Ldfld, xField);
			      break;
	         case "GetY": mthdIL.Emit(OpCodes.Ldfld, yField);
			      break;
	         case "GetZ": mthdIL.Emit(OpCodes.Ldfld, zField);
			      break;

	      }
	      mthdIL.Emit(OpCodes.Ret);

           }
	   // Finally, we create the type.

 	   pointType = pointTypeBld.CreateType();

	   // Let's save it, just for posterity.
	   
	   myAsmBuilder.Save("Point.dll");
	
	   return pointType;

 	}

	public static void Main() {
	
	   Type myDynamicType = null;
           object aPoint = null;
	   Type[] aPtypes = new Type[] {typeof(int), typeof(int), typeof(int)};
           object[] aPargs = new object[] {4, 5, 6};
	
	   // Call the  method to build our dynamic class.

	   myDynamicType = DynamicPointTypeGen();

	   Console.WriteLine("Some information about my new Type '{0}':",
			      myDynamicType.FullName);
	   Console.WriteLine("Assembly: '{0}'", myDynamicType.Assembly);
	   Console.WriteLine("Attributes: '{0}'", myDynamicType.Attributes);
	   Console.WriteLine("Module: '{0}'", myDynamicType.Module);
	   Console.WriteLine("Members: "); 
	   foreach (MemberInfo member in myDynamicType.GetMembers()) {
		Console.WriteLine("-- {0} {1};", member.MemberType, member.Name);
	   }

           Console.WriteLine("---");

	   // Let's take a look at the constructor we created.

	   ConstructorInfo myDTctor = myDynamicType.GetConstructor(aPtypes);
           Console.WriteLine("Constructor: {0};", myDTctor.ToString());

           Console.WriteLine("---");
	  
           // Now, we get to use our dynamically-created class by invoking the constructor. 

	   aPoint = myDTctor.Invoke(aPargs);
           Console.WriteLine("aPoint is type {0}.", aPoint.GetType());
	   	   

	   // Finally, let's reflect on the instance of our new type - aPoint - and
	   // make sure everything proceeded according to plan.

	   Console.WriteLine("aPoint.x = {0}",
			     myDynamicType.InvokeMember("GetX",
						        BindingFlags.InvokeMethod,
							null,
							aPoint,
							new object[0]));
	   Console.WriteLine("aPoint.y = {0}",
			     myDynamicType.InvokeMember("GetY",
						        BindingFlags.InvokeMethod,
							null,
							aPoint,
							new object[0]));
	   Console.WriteLine("aPoint.z = {0}",
			     myDynamicType.InvokeMember("GetZ",
						        BindingFlags.InvokeMethod,
							null,
							aPoint,
							new object[0]));

	    

	   // +++ OUTPUT +++
	   // Some information about my new Type 'Point':
	   // Assembly: 'MyDynamicAssembly, Version=0.0.0.0'
	   // Attributes: 'AutoLayout, AnsiClass, NotPublic, Public'
	   // Module: 'PointModule'
	   // Members: 
	   // -- Field x;
	   // -- Field y;
	   // -- Field z;
           // -- Method GetHashCode;
           // -- Method Equals;
           // -- Method ToString;
           // -- Method GetType;
           // -- Constructor .ctor;
	   // ---
	   // Constructor: Void .ctor(Int32, Int32, Int32);
	   // ---
	   // aPoint is type Point.
	   // aPoint.x = 4
	   // aPoint.y = 5
	   // aPoint.z = 6
	    
	}
    
}

// </Snippet1>
