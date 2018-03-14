//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;

class DemoAssemblyBuilder
{
    public static void Main()
    {
        // An assembly consists of one or more modules, each of which
        // contains zero or more types. This code creates a single-module
        // assembly, the most common case. The module contains one type,
        // named "MyDynamicType", that has a private field, a property 
        // that gets and sets the private field, constructors that 
        // initialize the private field, and a method that multiplies 
        // a user-supplied number by the private field value and returns
        // the result. In C# the type might look like this:
        /*
        public class MyDynamicType
        {
            private int m_number;
        
            public MyDynamicType() : this(42) {}
            public MyDynamicType(int initNumber)
            {
                m_number = initNumber;
            }

            public int Number
            {
                get { return m_number; }
                set { m_number = value; }
            }

            public int MyMethod(int multiplier)
            {
                return m_number * multiplier;
            }
        }
        */
      
        AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
        AssemblyBuilder ab = 
            AppDomain.CurrentDomain.DefineDynamicAssembly(
                aName, 
                AssemblyBuilderAccess.RunAndSave);

        // For a single-module assembly, the module name is usually
        // the assembly name plus an extension.
        ModuleBuilder mb = 
            ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
      
        TypeBuilder tb = mb.DefineType(
            "MyDynamicType", 
             TypeAttributes.Public);

        // Add a private field of type int (Int32).
        FieldBuilder fbNumber = tb.DefineField(
            "m_number", 
            typeof(int), 
            FieldAttributes.Private);

        // Define a constructor that takes an integer argument and 
        // stores it in the private field. 
        Type[] parameterTypes = { typeof(int) };
        ConstructorBuilder ctor1 = tb.DefineConstructor(
            MethodAttributes.Public, 
            CallingConventions.Standard, 
            parameterTypes);

        ILGenerator ctor1IL = ctor1.GetILGenerator();
        // For a constructor, argument zero is a reference to the new
        // instance. Push it on the stack before calling the base
        // class constructor. Specify the default constructor of the 
        // base class (System.Object) by passing an empty array of 
        // types (Type.EmptyTypes) to GetConstructor.
        ctor1IL.Emit(OpCodes.Ldarg_0);
        ctor1IL.Emit(OpCodes.Call, 
            typeof(object).GetConstructor(Type.EmptyTypes));
        // Push the instance on the stack before pushing the argument
        // that is to be assigned to the private field m_number.
        ctor1IL.Emit(OpCodes.Ldarg_0);
        ctor1IL.Emit(OpCodes.Ldarg_1);
        ctor1IL.Emit(OpCodes.Stfld, fbNumber);
        ctor1IL.Emit(OpCodes.Ret);

        // Define a default constructor that supplies a default value
        // for the private field. For parameter types, pass the empty
        // array of types or pass null.
        ConstructorBuilder ctor0 = tb.DefineConstructor(
            MethodAttributes.Public, 
            CallingConventions.Standard, 
            Type.EmptyTypes);

        ILGenerator ctor0IL = ctor0.GetILGenerator();
        // For a constructor, argument zero is a reference to the new
        // instance. Push it on the stack before pushing the default
        // value on the stack, then call constructor ctor1.
        ctor0IL.Emit(OpCodes.Ldarg_0);
        ctor0IL.Emit(OpCodes.Ldc_I4_S, 42);
        ctor0IL.Emit(OpCodes.Call, ctor1);
        ctor0IL.Emit(OpCodes.Ret);

        // Define a property named Number that gets and sets the private 
        // field.
        //
        // The last argument of DefineProperty is null, because the
        // property has no parameters. (If you don't specify null, you must
        // specify an array of Type objects. For a parameterless property,
        // use the built-in array with no elements: Type.EmptyTypes)
        PropertyBuilder pbNumber = tb.DefineProperty(
            "Number", 
            PropertyAttributes.HasDefault, 
            typeof(int), 
            null);
      
        // The property "set" and property "get" methods require a special
        // set of attributes.
        MethodAttributes getSetAttr = MethodAttributes.Public | 
            MethodAttributes.SpecialName | MethodAttributes.HideBySig;

        // Define the "get" accessor method for Number. The method returns
        // an integer and has no arguments. (Note that null could be 
        // used instead of Types.EmptyTypes)
        MethodBuilder mbNumberGetAccessor = tb.DefineMethod(
            "get_Number", 
            getSetAttr, 
            typeof(int), 
            Type.EmptyTypes);
      
        ILGenerator numberGetIL = mbNumberGetAccessor.GetILGenerator();
        // For an instance property, argument zero is the instance. Load the 
        // instance, then load the private field and return, leaving the
        // field value on the stack.
        numberGetIL.Emit(OpCodes.Ldarg_0);
        numberGetIL.Emit(OpCodes.Ldfld, fbNumber);
        numberGetIL.Emit(OpCodes.Ret);
        
        // Define the "set" accessor method for Number, which has no return
        // type and takes one argument of type int (Int32).
        MethodBuilder mbNumberSetAccessor = tb.DefineMethod(
            "set_Number", 
            getSetAttr, 
            null, 
            new Type[] { typeof(int) });
      
        ILGenerator numberSetIL = mbNumberSetAccessor.GetILGenerator();
        // Load the instance and then the numeric argument, then store the
        // argument in the field.
        numberSetIL.Emit(OpCodes.Ldarg_0);
        numberSetIL.Emit(OpCodes.Ldarg_1);
        numberSetIL.Emit(OpCodes.Stfld, fbNumber);
        numberSetIL.Emit(OpCodes.Ret);
      
        // Last, map the "get" and "set" accessor methods to the 
        // PropertyBuilder. The property is now complete. 
        pbNumber.SetGetMethod(mbNumberGetAccessor);
        pbNumber.SetSetMethod(mbNumberSetAccessor);

        // Define a method that accepts an integer argument and returns
        // the product of that integer and the private field m_number. This
        // time, the array of parameter types is created on the fly.
        MethodBuilder meth = tb.DefineMethod(
            "MyMethod", 
            MethodAttributes.Public, 
            typeof(int), 
            new Type[] { typeof(int) });

        ILGenerator methIL = meth.GetILGenerator();
        // To retrieve the private instance field, load the instance it
        // belongs to (argument zero). After loading the field, load the 
        // argument one and then multiply. Return from the method with 
        // the return value (the product of the two numbers) on the 
        // execution stack.
        methIL.Emit(OpCodes.Ldarg_0);
        methIL.Emit(OpCodes.Ldfld, fbNumber);
        methIL.Emit(OpCodes.Ldarg_1);
        methIL.Emit(OpCodes.Mul);
        methIL.Emit(OpCodes.Ret);

        // Finish the type.
        Type t = tb.CreateType();
     
        // The following line saves the single-module assembly. This
        // requires AssemblyBuilderAccess to include Save. You can now
        // type "ildasm MyDynamicAsm.dll" at the command prompt, and 
        // examine the assembly. You can also write a program that has
        // a reference to the assembly, and use the MyDynamicType type.
        // 
        ab.Save(aName.Name + ".dll");

        // Because AssemblyBuilderAccess includes Run, the code can be
        // executed immediately. Start by getting reflection objects for
        // the method and the property.
        MethodInfo mi = t.GetMethod("MyMethod");
        PropertyInfo pi = t.GetProperty("Number");
  
        // Create an instance of MyDynamicType using the default 
        // constructor. 
        object o1 = Activator.CreateInstance(t);

        // Display the value of the property, then change it to 127 and 
        // display it again. Use null to indicate that the property
        // has no index.
        Console.WriteLine("o1.Number: {0}", pi.GetValue(o1, null));
        pi.SetValue(o1, 127, null);
        Console.WriteLine("o1.Number: {0}", pi.GetValue(o1, null));

        // Call MyMethod, passing 22, and display the return value, 22
        // times 127. Arguments must be passed as an array, even when
        // there is only one.
        object[] arguments = { 22 };
        Console.WriteLine("o1.MyMethod(22): {0}", 
            mi.Invoke(o1, arguments));

        // Create an instance of MyDynamicType using the constructor
        // that specifies m_Number. The constructor is identified by
        // matching the types in the argument array. In this case, 
        // the argument array is created on the fly. Display the 
        // property value.
        object o2 = Activator.CreateInstance(t, 
            new object[] { 5280 });
        Console.WriteLine("o2.Number: {0}", pi.GetValue(o2, null));
    }
}

/* This code produces the following output:

o1.Number: 42
o1.Number: 127
o1.MyMethod(22): 2794
o2.Number: 5280
 */
//</Snippet1>


