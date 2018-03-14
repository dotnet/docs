' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Collections.Generic

' Define a trivial base class and two trivial interfaces 
' to use when demonstrating constraints.
'
Public Class ExampleBase
End Class

Public Interface IExampleA
End Interface

Public Interface IExampleB
End Interface

' Define a trivial type that can substitute for type parameter 
' TSecond.
'
Public Class ExampleDerived
    Inherits ExampleBase
    Implements IExampleA, IExampleB
End Class

Public Class Example
    Public Shared Sub Main()
        ' Define a dynamic assembly to contain the sample type. The
        ' assembly will not be run, but only saved to disk, so
        ' AssemblyBuilderAccess.Save is specified.
        '
        '<Snippet2>
        Dim myDomain As AppDomain = AppDomain.CurrentDomain
        Dim myAsmName As New AssemblyName("GenericEmitExample1")
        Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly( _
            myAsmName, _
            AssemblyBuilderAccess.RunAndSave)
        '</Snippet2>

        ' An assembly is made up of executable modules. For a single-
        ' module assembly, the module name and file name are the same 
        ' as the assembly name. 
        '
        '<Snippet3>
        Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule( _
            myAsmName.Name, _
            myAsmName.Name & ".dll")
        '</Snippet3>

        ' Get type objects for the base class trivial interfaces to
        ' be used as constraints.
        '
        Dim baseType As Type = GetType(ExampleBase)
        Dim interfaceA As Type = GetType(IExampleA)
        Dim interfaceB As Type = GetType(IExampleB)
                
        ' Define the sample type.
        '
        '<Snippet4>
        Dim myType As TypeBuilder = myModule.DefineType( _
            "Sample", _
            TypeAttributes.Public)
        '</Snippet4>

        Console.WriteLine("Type 'Sample' is generic: {0}", _
            myType.IsGenericType)

        ' Define type parameters for the type. Until you do this, 
        ' the type is not generic, as the preceding and following 
        ' WriteLine statements show. The type parameter names are
        ' specified as an array of strings. To make the code
        ' easier to read, each GenericTypeParameterBuilder is placed
        ' in a variable with the same name as the type parameter.
        ' 
        '<Snippet5>
        Dim typeParamNames() As String = {"TFirst", "TSecond"}
        Dim typeParams() As GenericTypeParameterBuilder = _
            myType.DefineGenericParameters(typeParamNames)

        Dim TFirst As GenericTypeParameterBuilder = typeParams(0)
        Dim TSecond As GenericTypeParameterBuilder = typeParams(1)
        '</Snippet5>

        Console.WriteLine("Type 'Sample' is generic: {0}", _
            myType.IsGenericType)

        ' Apply constraints to the type parameters.
        '
        ' A type that is substituted for the first parameter, TFirst,
        ' must be a reference type and must have a parameterless
        ' constructor.
        '<Snippet6>
        TFirst.SetGenericParameterAttributes( _
            GenericParameterAttributes.DefaultConstructorConstraint _
            Or GenericParameterAttributes.ReferenceTypeConstraint)
        '</Snippet6>

        ' A type that is substituted for the second type
        ' parameter must implement IExampleA and IExampleB, and
        ' inherit from the trivial test class ExampleBase. The
        ' interface constraints are specified as an array 
        ' containing the interface types.
        '<Snippet7>
        TSecond.SetBaseTypeConstraint(baseType)
        Dim interfaceTypes() As Type = {interfaceA, interfaceB}
        TSecond.SetInterfaceConstraints(interfaceTypes)
        '</Snippet7>

        ' The following code adds a private field named ExampleField,
        ' of type TFirst.
        '<Snippet21>
        Dim exField As FieldBuilder = _
            myType.DefineField("ExampleField", TFirst, _
                FieldAttributes.Private)
        '</Snippet21>

        ' Define a Shared method that takes an array of TFirst and 
        ' returns a List(Of TFirst) containing all the elements of 
        ' the array. To define this method it is necessary to create
        ' the type List(Of TFirst) by calling MakeGenericType on the
        ' generic type definition, List(Of T). (The T is omitted with
        ' the GetType operator when you get the generic type 
        ' definition.) The parameter type is created by using the
        ' MakeArrayType method. 
        '
        '<Snippet22>
        Dim listOf As Type = GetType(List(Of ))
        Dim listOfTFirst As Type = listOf.MakeGenericType(TFirst)
        Dim mParamTypes() As Type = { TFirst.MakeArrayType() }

        Dim exMethod As MethodBuilder = _
            myType.DefineMethod("ExampleMethod", _
                MethodAttributes.Public Or MethodAttributes.Static, _
                listOfTFirst, _
                mParamTypes)
        '</Snippet22>

        ' Emit the method body. 
        ' The method body consists of just three opcodes, to load 
        ' the input array onto the execution stack, to call the 
        ' List(Of TFirst) constructor that takes IEnumerable(Of TFirst),
        ' which does all the work of putting the input elements into
        ' the list, and to return, leaving the list on the stack. The
        ' hard work is getting the constructor.
        ' 
        ' The GetConstructor method is not supported on a 
        ' GenericTypeParameterBuilder, so it is not possible to get 
        ' the constructor of List(Of TFirst) directly. There are two
        ' steps, first getting the constructor of List(Of T) and then
        ' calling a method that converts it to the corresponding 
        ' constructor of List(Of TFirst).
        '
        ' The constructor needed here is the one that takes an
        ' IEnumerable(Of T). Note, however, that this is not the 
        ' generic type definition of IEnumerable(Of T); instead, the
        ' T from List(Of T) must be substituted for the T of 
        ' IEnumerable(Of T). (This seems confusing only because both
        ' types have type parameters named T. That is why this example
        ' uses the somewhat silly names TFirst and TSecond.) To get
        ' the type of the constructor argument, take the generic
        ' type definition IEnumerable(Of T) (expressed as 
        ' IEnumerable(Of ) when you use the GetType operator) and 
        ' call MakeGenericType with the first generic type parameter
        ' of List(Of T). The constructor argument list must be passed
        ' as an array, with just one argument in this case.
        ' 
        ' Now it is possible to get the constructor of List(Of T),
        ' using GetConstructor on the generic type definition. To get
        ' the constructor of List(Of TFirst), pass List(Of TFirst) and
        ' the constructor from List(Of T) to the static
        ' TypeBuilder.GetConstructor method.
        '
        '<Snippet23>
        Dim ilgen As ILGenerator = exMethod.GetILGenerator()
        
        Dim ienumOf As Type = GetType(IEnumerable(Of ))
        Dim listOfTParams() As Type = listOf.GetGenericArguments()
        Dim TfromListOf As Type = listOfTParams(0)
        Dim ienumOfT As Type = ienumOf.MakeGenericType(TfromListOf)
        Dim ctorArgs() As Type = { ienumOfT }

        Dim ctorPrep As ConstructorInfo = _
            listOf.GetConstructor(ctorArgs)
        Dim ctor As ConstructorInfo = _
            TypeBuilder.GetConstructor(listOfTFirst, ctorPrep)

        ilgen.Emit(OpCodes.Ldarg_0)
        ilgen.Emit(OpCodes.Newobj, ctor)
        ilgen.Emit(OpCodes.Ret)
        '</Snippet23>

        ' Create the type and save the assembly. 
        '<Snippet8>
        Dim finished As Type = myType.CreateType()
        myAssembly.Save(myAsmName.Name & ".dll")
        '</Snippet8>

        ' Invoke the method.
        ' ExampleMethod is not generic, but the type it belongs to is
        ' generic, so in order to get a MethodInfo that can be invoked
        ' it is necessary to create a constructed type. The Example 
        ' class satisfies the constraints on TFirst, because it is a 
        ' reference type and has a default constructor. In order to
        ' have a class that satisfies the constraints on TSecond, 
        ' this code example defines the ExampleDerived type. These
        ' two types are passed to MakeGenericMethod to create the
        ' constructed type.
        '
        '<Snippet9>
        Dim typeArgs() As Type = _
            { GetType(Example), GetType(ExampleDerived) }
        Dim constructed As Type = finished.MakeGenericType(typeArgs)
        Dim mi As MethodInfo = constructed.GetMethod("ExampleMethod")
        '</Snippet9>

        ' Create an array of Example objects, as input to the generic
        ' method. This array must be passed as the only element of an 
        ' array of arguments. The first argument of Invoke is 
        ' Nothing, because ExampleMethod is Shared. Display the count
        ' on the resulting List(Of Example).
        ' 
        '<Snippet10>
        Dim input() As Example = { New Example(), New Example() }
        Dim arguments() As Object = { input }

        Dim listX As List(Of Example) = mi.Invoke(Nothing, arguments)

        Console.WriteLine(vbLf & _
            "There are {0} elements in the List(Of Example).", _
            listX.Count _ 
        )
        '</Snippet10>

        DisplayGenericParameters(finished)
    End Sub

    Private Shared Sub DisplayGenericParameters(ByVal t As Type)

        If Not t.IsGenericType Then
            Console.WriteLine("Type '{0}' is not generic.")
            Return
        End If
        If Not t.IsGenericTypeDefinition Then _
            t = t.GetGenericTypeDefinition()

        Dim typeParameters() As Type = t.GetGenericArguments()
        Console.WriteLine(vbCrLf & _
            "Listing {0} type parameters for type '{1}'.", _
            typeParameters.Length, t)

        For Each tParam As Type In typeParameters

            Console.WriteLine(vbCrLf & "Type parameter {0}:", _
                tParam.ToString())

            For Each c As Type In tParam.GetGenericParameterConstraints()
                If c.IsInterface Then
                    Console.WriteLine("    Interface constraint: {0}", c)
                Else
                    Console.WriteLine("    Base type constraint: {0}", c)
                End If
            Next 

            ListConstraintAttributes(tParam)
        Next tParam
    End Sub

    ' List the constraint flags. The GenericParameterAttributes
    ' enumeration contains two sets of attributes, variance and
    ' constraints. For this example, only constraints are used.
    '
    Private Shared Sub ListConstraintAttributes(ByVal t As Type)

        ' Mask off the constraint flags. 
        Dim constraints As GenericParameterAttributes = _
            t.GenericParameterAttributes And _
            GenericParameterAttributes.SpecialConstraintMask

        If (constraints And GenericParameterAttributes.ReferenceTypeConstraint) _
                <> GenericParameterAttributes.None Then _
            Console.WriteLine("    ReferenceTypeConstraint")

        If (constraints And GenericParameterAttributes.NotNullableValueTypeConstraint) _
                <> GenericParameterAttributes.None Then _
            Console.WriteLine("    NotNullableValueTypeConstraint")

        If (constraints And GenericParameterAttributes.DefaultConstructorConstraint) _
                <> GenericParameterAttributes.None Then _
            Console.WriteLine("    DefaultConstructorConstraint")

    End Sub 

End Class

' This code example produces the following output:
'
'Type 'Sample' is generic: False
'Type 'Sample' is generic: True
'
'There are 2 elements in the List(Of Example).
'
'Listing 2 type parameters for type 'Sample[TFirst,TSecond]'.
'
'Type parameter TFirst:
'    ReferenceTypeConstraint
'    DefaultConstructorConstraint
'
'Type parameter TSecond:
'    Interface constraint: IExampleA
'    Interface constraint: IExampleB
'    Base type constraint: ExampleBase
'</Snippet1>