'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class DemoAssemblyBuilder

    Public Shared Sub Main()

        ' An assembly consists of one or more modules, each of which
        ' contains zero or more types. This code creates a single-module
        ' assembly, the most common case. The module contains one type,
        ' named "MyDynamicType", that has a private field, a property 
        ' that gets and sets the private field, constructors that 
        ' initialize the private field, and a method that multiplies
        ' a user-supplied number by the private field value and returns 
        ' the result. The code might look like this in Visual Basic:
        '
        'Public Class MyDynamicType
        '    Private m_number As Integer
        '
        '    Public Sub New()
        '        Me.New(42)
        '    End Sub
        '
        '    Public Sub New(ByVal initNumber As Integer)
        '        m_number = initNumber
        '    End Sub
        '
        '    Public Property Number As Integer
        '        Get
        '            Return m_number
        '        End Get
        '        Set
        '            m_Number = Value
        '        End Set
        '    End Property
        '
        '    Public Function MyMethod(ByVal multiplier As Integer) As Integer
        '        Return m_Number * multiplier
        '    End Function
        'End Class
      
        Dim aName As New AssemblyName("DynamicAssemblyExample")
        Dim ab As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly( _
                aName, _
                AssemblyBuilderAccess.RunAndSave)

        ' For a single-module assembly, the module name is usually
        ' the assembly name plus an extension.
        Dim mb As ModuleBuilder = ab.DefineDynamicModule( _
            aName.Name, _
            aName.Name & ".dll")
      
        Dim tb As TypeBuilder = _
            mb.DefineType("MyDynamicType", TypeAttributes.Public)

        ' Add a private field of type Integer (Int32).
        Dim fbNumber As FieldBuilder = tb.DefineField( _
            "m_number", _
            GetType(Integer), _
            FieldAttributes.Private)

        ' Define a constructor that takes an integer argument and 
        ' stores it in the private field. 
        Dim parameterTypes() As Type = { GetType(Integer) }
        Dim ctor1 As ConstructorBuilder = _
            tb.DefineConstructor( _
                MethodAttributes.Public, _
                CallingConventions.Standard, _
                parameterTypes)

        Dim ctor1IL As ILGenerator = ctor1.GetILGenerator()
        ' For a constructor, argument zero is a reference to the new
        ' instance. Push it on the stack before calling the base
        ' class constructor. Specify the default constructor of the 
        ' base class (System.Object) by passing an empty array of 
        ' types (Type.EmptyTypes) to GetConstructor.
        ctor1IL.Emit(OpCodes.Ldarg_0)
        ctor1IL.Emit(OpCodes.Call, _
            GetType(Object).GetConstructor(Type.EmptyTypes))
        ' Push the instance on the stack before pushing the argument
        ' that is to be assigned to the private field m_number.
        ctor1IL.Emit(OpCodes.Ldarg_0)
        ctor1IL.Emit(OpCodes.Ldarg_1)
        ctor1IL.Emit(OpCodes.Stfld, fbNumber)
        ctor1IL.Emit(OpCodes.Ret)

        ' Define a default constructor that supplies a default value
        ' for the private field. For parameter types, pass the empty
        ' array of types or pass Nothing.
        Dim ctor0 As ConstructorBuilder = tb.DefineConstructor( _
            MethodAttributes.Public, _
            CallingConventions.Standard, _
            Type.EmptyTypes)

        Dim ctor0IL As ILGenerator = ctor0.GetILGenerator()
        ' For a constructor, argument zero is a reference to the new
        ' instance. Push it on the stack before pushing the default
        ' value on the stack, then call constructor ctor1.
        ctor0IL.Emit(OpCodes.Ldarg_0)
        ctor0IL.Emit(OpCodes.Ldc_I4_S, 42)
        ctor0IL.Emit(OpCodes.Call, ctor1)
        ctor0IL.Emit(OpCodes.Ret)

        ' Define a property named Number that gets and sets the private 
        ' field.
        '
        ' The last argument of DefineProperty is Nothing, because the
        ' property has no parameters. (If you don't specify Nothing, you must
        ' specify an array of Type objects. For a parameterless property,
        ' use the built-in array with no elements: Type.EmptyTypes)
        Dim pbNumber As PropertyBuilder = tb.DefineProperty( _
            "Number", _
            PropertyAttributes.HasDefault, _
            GetType(Integer), _
            Nothing)
      
        ' The property Set and property Get methods require a special
        ' set of attributes.
        Dim getSetAttr As MethodAttributes = _
            MethodAttributes.Public Or MethodAttributes.SpecialName _
                Or MethodAttributes.HideBySig

        ' Define the "get" accessor method for Number. The method returns
        ' an integer and has no arguments. (Note that Nothing could be 
        ' used instead of Types.EmptyTypes)
        Dim mbNumberGetAccessor As MethodBuilder = tb.DefineMethod( _
            "get_Number", _
            getSetAttr, _
            GetType(Integer), _
            Type.EmptyTypes)
      
        Dim numberGetIL As ILGenerator = mbNumberGetAccessor.GetILGenerator()
        ' For an instance property, argument zero is the instance. Load the 
        ' instance, then load the private field and return, leaving the
        ' field value on the stack.
        numberGetIL.Emit(OpCodes.Ldarg_0)
        numberGetIL.Emit(OpCodes.Ldfld, fbNumber)
        numberGetIL.Emit(OpCodes.Ret)
        
        ' Define the "set" accessor method for Number, which has no return
        ' type and takes one argument of type Integer (Int32).
        Dim mbNumberSetAccessor As MethodBuilder = _
            tb.DefineMethod( _
                "set_Number", _
                getSetAttr, _
                Nothing, _
                New Type() { GetType(Integer) })
      
        Dim numberSetIL As ILGenerator = mbNumberSetAccessor.GetILGenerator()
        ' Load the instance and then the numeric argument, then store the
        ' argument in the field.
        numberSetIL.Emit(OpCodes.Ldarg_0)
        numberSetIL.Emit(OpCodes.Ldarg_1)
        numberSetIL.Emit(OpCodes.Stfld, fbNumber)
        numberSetIL.Emit(OpCodes.Ret)
      
        ' Last, map the "get" and "set" accessor methods to the 
        ' PropertyBuilder. The property is now complete. 
        pbNumber.SetGetMethod(mbNumberGetAccessor)
        pbNumber.SetSetMethod(mbNumberSetAccessor)

        ' Define a method that accepts an integer argument and returns
        ' the product of that integer and the private field m_number. This
        ' time, the array of parameter types is created on the fly.
        Dim meth As MethodBuilder = tb.DefineMethod( _
            "MyMethod", _
            MethodAttributes.Public, _
            GetType(Integer), _
            New Type() { GetType(Integer) })

        Dim methIL As ILGenerator = meth.GetILGenerator()
        ' To retrieve the private instance field, load the instance it
        ' belongs to (argument zero). After loading the field, load the 
        ' argument one and then multiply. Return from the method with 
        ' the return value (the product of the two numbers) on the 
        ' execution stack.
        methIL.Emit(OpCodes.Ldarg_0)
        methIL.Emit(OpCodes.Ldfld, fbNumber)
        methIL.Emit(OpCodes.Ldarg_1)
        methIL.Emit(OpCodes.Mul)
        methIL.Emit(OpCodes.Ret)

        ' Finish the type.
        Dim t As Type = tb.CreateType()
     
        ' The following line saves the single-module assembly. This
        ' requires AssemblyBuilderAccess to include Save. You can now
        ' type "ildasm MyDynamicAsm.dll" at the command prompt, and 
        ' examine the assembly. You can also write a program that has
        ' a reference to the assembly, and use the MyDynamicType type.
        ' 
        ab.Save(aName.Name & ".dll") 

        ' Because AssemblyBuilderAccess includes Run, the code can be
        ' executed immediately. Start by getting reflection objects for
        ' the method and the property.
        Dim mi As MethodInfo = t.GetMethod("MyMethod")
        Dim pi As PropertyInfo = t.GetProperty("Number")
  
        ' Create an instance of MyDynamicType using the default 
        ' constructor. 
        Dim o1 As Object = Activator.CreateInstance(t)

        ' Display the value of the property, then change it to 127 and 
        ' display it again. Use Nothing to indicate that the property
        ' has no index.
        Console.WriteLine("o1.Number: {0}", pi.GetValue(o1, Nothing))
        pi.SetValue(o1, 127, Nothing)
        Console.WriteLine("o1.Number: {0}", pi.GetValue(o1, Nothing))

        ' Call MyMethod, passing 22, and display the return value, 22
        ' times 127. Arguments must be passed as an array, even when
        ' there is only one.
        Dim arguments() As Object = { 22 }
        Console.WriteLine("o1.MyMethod(22): {0}", _
            mi.Invoke(o1, arguments))

        ' Create an instance of MyDynamicType using the constructor
        ' that specifies m_Number. The constructor is identified by
        ' matching the types in the argument array. In this case, 
        ' the argument array is created on the fly. Display the 
        ' property value.
        Dim o2 As Object = Activator.CreateInstance(t, _
            New Object() { 5280 })
        Console.WriteLine("o2.Number: {0}", pi.GetValue(o2, Nothing))
      
    End Sub  
End Class

' This code produces the following output:
'
'o1.Number: 42
'o1.Number: 127
'o1.MyMethod(22): 2794
'o2.Number: 5280
'</Snippet1>