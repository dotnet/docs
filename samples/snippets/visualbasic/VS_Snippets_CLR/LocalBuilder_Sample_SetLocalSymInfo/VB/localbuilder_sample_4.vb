' System.Reflection.Emit.LocalBuilder
' System.Reflection.Emit.ILGenerator.DeclareLocal(Type)
' System.Reflection.Emit.LocalBuilder.SetLocalSymInfo(String)
' System.Reflection.Emit.LocalBuilder.LocalType()
' System.Reflection.Emit.LocalBuilder.SetLocalSymInfo(String, Int32, Int32)

' This program demonstrates 'LocalType' property, 'SetLocalSymInfo(String)',
' 'SetLocalSymInfo(String, Int32,Int32)' methods, class level for 'LocalBuilder' and
' 'DeclareLocal(Type)' method of ILGenerator class. An assembly 'Example' is created using
' AssemblyBuilder, ModuleBuilder, FieldBuilder, TypeBuilder, ConstructorBuilder classes.
' Localbuilder class is used to create local variables of the specified type.

' Revised 3/16/06 by REDMOND\GlennHa, for vswhidbey 191996.
' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading

Class LocalBuilder_Sample

    Public Shared Sub Main()

        ' Create an assembly.
        Dim myAssemblyName As New AssemblyName()
        myAssemblyName.Name = "SampleAssembly"

        Dim myAssembly As AssemblyBuilder = _
            Thread.GetDomain().DefineDynamicAssembly( myAssemblyName, _
                             AssemblyBuilderAccess.RunAndSave )

        ' Create a module. For a single-file assembly the module
        ' name is usually the same as the assembly name.
        Dim myModule As ModuleBuilder = _
            myAssembly.DefineDynamicModule(myAssemblyName.Name, _
                myAssemblyName.Name & ".dll", True)

        ' Define a public class 'Example'.
        Dim myTypeBuilder As TypeBuilder = _
            myModule.DefineType("Example", TypeAttributes.Public)

        ' Create the 'Function1' public method, which takes an Integer
        ' and returns a string.
        Dim myMethod As MethodBuilder = myTypeBuilder.DefineMethod("Function1", _
            MethodAttributes.Public Or MethodAttributes.Static, _
            GetType(String), New Type() { GetType(Integer) })

        ' Generate IL for 'Function1'. The function body demonstrates
        ' assigning an argument to a local variable, assigning a 
        ' constant string to a local variable, and putting the contents
        ' of local variables on the stack.
        Dim myMethodIL As ILGenerator = myMethod.GetILGenerator()

        ' <Snippet2>
        ' Create local variables named myString and myInt.
        Dim myLB1 As LocalBuilder = myMethodIL.DeclareLocal(GetType(String))
        myLB1.SetLocalSymInfo("myString")
        Console.WriteLine("local 'myString' type is: {0}", myLB1.LocalType)

        Dim myLB2 As LocalBuilder = myMethodIL.DeclareLocal(GetType(Integer))
        myLB2.SetLocalSymInfo("myInt", 1, 2)
        Console.WriteLine("local 'myInt' type is: {0}", myLB2.LocalType)
        ' </Snippet2>

        ' Store the function argument in myInt.
        myMethodIL.Emit(OpCodes.Ldarg_0 )
        myMethodIL.Emit(OpCodes.Stloc_1 )

        ' Store a literal value in myString, and return the value.
        myMethodIL.Emit(OpCodes.Ldstr, "string value"  )
        myMethodIL.Emit(OpCodes.Stloc_0 )
        myMethodIL.Emit(OpCodes.Ldloc_0 )
        myMethodIL.Emit(OpCodes.Ret )

        ' Create "Example" class.
        Dim myType1 As Type = myTypeBuilder.CreateType()
        Console.WriteLine("'Example' is created.")

        myAssembly.Save(myAssemblyName.Name & ".dll")
        Console.WriteLine( "'{0}' is created.", myAssemblyName.Name & ".dll" )

        ' Invoke 'Function1' method of 'Example', passing the value 42.
        Dim myObject2 As Object = myType1.InvokeMember("Function1", _
            BindingFlags.InvokeMethod, Nothing, Nothing, New Object() { 42 })

        Console.WriteLine("Example.Function1 returned: {0}", myObject2)

   End Sub 
End Class 

' This code example produces the following output:
'
'local 'myString' type is: System.String
'local 'myInt' type is: System.Int32
''Example' is created.
''SampleAssembly.dll' is created.
'Example.Function1 returned: string value
' </Snippet1>