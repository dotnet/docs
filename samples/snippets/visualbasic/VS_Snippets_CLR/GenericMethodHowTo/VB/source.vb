'<Snippet1>
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Reflection.Emit

' Declare a generic delegate that can be used to execute the 
' finished method.
'
'<Snippet24>
Delegate Function D(Of TIn, TOut)(ByVal input() As TIn) As TOut
'</Snippet24>

Class GenericMethodBuilder

    ' This method shows how to declare, in Visual Basic, the generic
    ' method this program emits. The method has two type parameters,
    ' TInput and TOutput, the second of which must be a reference type
    ' (Class), must have a parameterless constructor (New), and must
    ' implement ICollection(Of TInput). This interface constraint
    ' ensures that ICollection(Of TInput).Add can be used to add
    ' elements to the TOutput object the method creates. The method 
    ' has one formal parameter, input, which is an array of TInput. 
    ' The elements of this array are copied to the new TOutput.
    '
    '<Snippet20>
    Public Shared Function Factory(Of TInput, _
        TOutput As {ICollection(Of TInput), Class, New}) _
        (ByVal input() As TInput) As TOutput

        Dim retval As New TOutput()
        Dim ic As ICollection(Of TInput) = retval

        For Each t As TInput In input
            ic.Add(t)
        Next

        Return retval
    End Function
    '</Snippet20>


    Public Shared Sub Main()
        ' The following shows the usage syntax of the Visual Basic
        ' version of the generic method emitted by this program.
        ' Note that the generic parameters must be specified 
        ' explicitly, because the compiler does not have enough 
        ' context to infer the type of TOutput. In this case, TOutput
        ' is a generic List containing strings.
        ' 
        '<Snippet17>
        Dim arr() As String = {"a", "b", "c", "d", "e"}
        Dim list1 As List(Of String) = _
            GenericMethodBuilder.Factory(Of String, List(Of String))(arr)
        Console.WriteLine("The first element is: {0}", list1(0))
        '</Snippet17>


        ' Creating a dynamic assembly requires an AssemblyName
        ' object, and the current application domain.
        '
        '<Snippet2>
        Dim asmName As New AssemblyName("DemoMethodBuilder1")
        Dim domain As AppDomain = AppDomain.CurrentDomain
        Dim demoAssembly As AssemblyBuilder = _
            domain.DefineDynamicAssembly(asmName, _
                AssemblyBuilderAccess.RunAndSave)

        ' Define the module that contains the code. For an 
        ' assembly with one module, the module name is the 
        ' assembly name plus a file extension.
        Dim demoModule As ModuleBuilder = _
            demoAssembly.DefineDynamicModule( _
                asmName.Name, _
                asmName.Name & ".dll")
        '</Snippet2>

        ' Define a type to contain the method.
        '<Snippet3>
        Dim demoType As TypeBuilder = demoModule.DefineType( _
            "DemoType", _
            TypeAttributes.Public)
        '</Snippet3>

        ' Define a Shared, Public method with standard calling
        ' conventions. Do not specify the parameter types or the
        ' return type, because type parameters will be used for 
        ' those types, and the type parameters have not been
        ' defined yet.
        '
        '<Snippet4>
        Dim factory As MethodBuilder = _
            demoType.DefineMethod("Factory", _
                MethodAttributes.Public Or MethodAttributes.Static)
        '</Snippet4>

        ' Defining generic type parameters for the method makes it a
        ' generic method. To make the code easier to read, each
        ' type parameter is copied to a variable of the same name.
        '
        '<Snippet5>
        Dim typeParameterNames() As String = {"TInput", "TOutput"}
        Dim typeParameters() As GenericTypeParameterBuilder = _
            factory.DefineGenericParameters(typeParameterNames)

        Dim TInput As GenericTypeParameterBuilder = typeParameters(0)
        Dim TOutput As GenericTypeParameterBuilder = typeParameters(1)
        '</Snippet5>

        ' Add special constraints.
        ' The type parameter TOutput is constrained to be a reference
        ' type, and to have a parameterless constructor. This ensures
        ' that the Factory method can create the collection type.
        ' 
        '<Snippet6>
        TOutput.SetGenericParameterAttributes( _
            GenericParameterAttributes.ReferenceTypeConstraint Or _
            GenericParameterAttributes.DefaultConstructorConstraint)
        '</Snippet6>

        ' Add interface and base type constraints.
        ' The type parameter TOutput is constrained to types that
        ' implement the ICollection(Of T) interface, to ensure that
        ' they have an Add method that can be used to add elements.
        '
        ' To create the constraint, first use MakeGenericType to bind 
        ' the type parameter TInput to the ICollection(Of T) interface,
        ' returning the type ICollection(Of TInput), then pass
        ' the newly created type to the SetInterfaceConstraints
        ' method. The constraints must be passed as an array, even if
        ' there is only one interface.
        '
        '<Snippet7>
        Dim icoll As Type = GetType(ICollection(Of ))
        Dim icollOfTInput As Type = icoll.MakeGenericType(TInput)
        Dim constraints() As Type = {icollOfTInput}
        TOutput.SetInterfaceConstraints(constraints)
        '</Snippet7>

        ' Set parameter types for the method. The method takes
        ' one parameter, an array of type TInput.
        '<Snippet8>
        Dim params() As Type = {TInput.MakeArrayType()}
        factory.SetParameters(params)
        '</Snippet8>

        ' Set the return type for the method. The return type is
        ' the generic type parameter TOutput.
        '<Snippet9>
        factory.SetReturnType(TOutput)
        '</Snippet9>

        ' Generate a code body for the method. 
        ' -----------------------------------
        ' Get a code generator and declare local variables and
        ' labels. Save the input array to a local variable.
        '
        '<Snippet10>
        Dim ilgen As ILGenerator = factory.GetILGenerator()

        Dim retVal As LocalBuilder = ilgen.DeclareLocal(TOutput)
        Dim ic As LocalBuilder = ilgen.DeclareLocal(icollOfTInput)
        Dim input As LocalBuilder = _
            ilgen.DeclareLocal(TInput.MakeArrayType())
        Dim index As LocalBuilder = _
            ilgen.DeclareLocal(GetType(Integer))

        Dim enterLoop As Label = ilgen.DefineLabel()
        Dim loopAgain As Label = ilgen.DefineLabel()

        ilgen.Emit(OpCodes.Ldarg_0)
        ilgen.Emit(OpCodes.Stloc_S, input)
        '</Snippet10>

        ' Create an instance of TOutput, using the generic method 
        ' overload of the Activator.CreateInstance method. 
        ' Using this overload requires the specified type to have
        ' a parameterless constructor, which is the reason for adding 
        ' that constraint to TOutput. Create the constructed generic
        ' method by passing TOutput to MakeGenericMethod. After
        ' emitting code to call the method, emit code to store the
        ' new TOutput in a local variable. 
        '
        '<Snippet11>
        Dim createInst As MethodInfo = _
            GetType(Activator).GetMethod("CreateInstance", Type.EmptyTypes)
        Dim createInstOfTOutput As MethodInfo = _
            createInst.MakeGenericMethod(TOutput)

        ilgen.Emit(OpCodes.Call, createInstOfTOutput)
        ilgen.Emit(OpCodes.Stloc_S, retVal)
        '</Snippet11>

        ' Load the reference to the TOutput object, cast it to
        ' ICollection(Of TInput), and save it.
        '<Snippet31>
        ilgen.Emit(OpCodes.Ldloc_S, retVal)
        ilgen.Emit(OpCodes.Box, TOutput)
        ilgen.Emit(OpCodes.Castclass, icollOfTInput)
        ilgen.Emit(OpCodes.Stloc_S, ic)
        '</Snippet31>

        ' Loop through the array, adding each element to the new
        ' instance of TOutput. Note that in order to get a MethodInfo
        ' for ICollection(Of TInput).Add, it is necessary to first 
        ' get the Add method for the generic type defintion,
        ' ICollection(Of T).Add. This is because it is not possible
        ' to call GetMethod on icollOfTInput. The static overload of
        ' TypeBuilder.GetMethod produces the correct MethodInfo for
        ' the constructed type.
        '
        '<Snippet12>
        Dim mAddPrep As MethodInfo = icoll.GetMethod("Add")
        Dim mAdd As MethodInfo = _
            TypeBuilder.GetMethod(icollOfTInput, mAddPrep)
        '</Snippet12>

        '<Snippet32>
        ' Initialize the count and enter the loop.
        ilgen.Emit(OpCodes.Ldc_I4_0)
        ilgen.Emit(OpCodes.Stloc_S, index)
        ilgen.Emit(OpCodes.Br_S, enterLoop)
        '</Snippet32>

        ' Mark the beginning of the loop. Push the ICollection
        ' reference on the stack, so it will be in position for the
        ' call to Add. Then push the array and the index on the 
        ' stack, get the array element, and call Add (represented
        ' by the MethodInfo mAdd) to add it to the collection.
        ' 
        ' The other ten instructions just increment the index
        ' and test for the end of the loop. Note the MarkLabel
        ' method, which sets the point in the code where the 
        ' loop is entered. (See the earlier Br_S to enterLoop.)
        '
        '<Snippet13>
        ilgen.MarkLabel(loopAgain)

        ilgen.Emit(OpCodes.Ldloc_S, ic)
        ilgen.Emit(OpCodes.Ldloc_S, input)
        ilgen.Emit(OpCodes.Ldloc_S, index)
        ilgen.Emit(OpCodes.Ldelem, TInput)
        ilgen.Emit(OpCodes.Callvirt, mAdd)

        ilgen.Emit(OpCodes.Ldloc_S, index)
        ilgen.Emit(OpCodes.Ldc_I4_1)
        ilgen.Emit(OpCodes.Add)
        ilgen.Emit(OpCodes.Stloc_S, index)

        ilgen.MarkLabel(enterLoop)
        ilgen.Emit(OpCodes.Ldloc_S, index)
        ilgen.Emit(OpCodes.Ldloc_S, input)
        ilgen.Emit(OpCodes.Ldlen)
        ilgen.Emit(OpCodes.Conv_I4)
        ilgen.Emit(OpCodes.Clt)
        ilgen.Emit(OpCodes.Brtrue_S, loopAgain)
        '</Snippet13>

        '<Snippet33>
        ilgen.Emit(OpCodes.Ldloc_S, retVal)
        ilgen.Emit(OpCodes.Ret)
        '</Snippet33>

        '<Snippet14>
        ' Complete the type.
        Dim dt As Type = demoType.CreateType()
        ' Save the assembly, so it can be examined with Ildasm.exe.
        demoAssembly.Save(asmName.Name & ".dll")
        '</Snippet14>

        ' To create a constructed generic method that can be
        ' executed, first call the GetMethod method on the completed 
        ' type to get the generic method definition. Call MakeGenericType
        ' on the generic method definition to obtain the constructed
        ' method, passing in the type arguments. In this case, the
        ' constructed method has String for TInput and List(Of String)
        ' for TOutput. 
        '
        '<Snippet21>
        Dim m As MethodInfo = dt.GetMethod("Factory")
        Dim bound As MethodInfo = m.MakeGenericMethod( _
            GetType(String), GetType(List(Of String)))

        ' Display a string representing the bound method.
        Console.WriteLine(bound)
        '</Snippet21>


        ' Once the generic method is constructed, 
        ' you can invoke it and pass in an array of objects 
        ' representing the arguments. In this case, there is only
        ' one element in that array, the argument 'arr'.
        '
        '<Snippet22>
        Dim o As Object = bound.Invoke(Nothing, New Object() {arr})
        Dim list2 As List(Of String) = CType(o, List(Of String))

        Console.WriteLine("The first element is: {0}", list2(0))
        '</Snippet22>


        ' You can get better performance from multiple calls if
        ' you bind the constructed method to a delegate. The 
        ' following code uses the generic delegate D defined 
        ' earlier.
        '
        '<Snippet23>
        Dim dType As Type = GetType(D(Of String, List(Of String)))
        Dim test As D(Of String, List(Of String))
        test = CType( _
            [Delegate].CreateDelegate(dType, bound), _
            D(Of String, List(Of String)))

        Dim list3 As List(Of String) = test(arr)
        Console.WriteLine("The first element is: {0}", list3(0))
        '</Snippet23>

    End Sub
End Class

' This code example produces the following output:
'
'The first element is: a
'System.Collections.Generic.List`1[System.String] Factory[String,List`1](System.String[])
'The first element is: a
'The first element is: a
'</Snippet1>
