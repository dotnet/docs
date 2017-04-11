'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports Microsoft.VisualBasic

Public Class Example
    Public Shared Sub Main()
        ' Define a dynamic assembly to contain the sample type. The
        ' assembly will not be run, but only saved to disk, so
        ' AssemblyBuilderAccess.Save is specified.
        '
        Dim myDomain As AppDomain = AppDomain.CurrentDomain
        Dim myAsmName As New AssemblyName("MakeXxxGenericTypeParameterExample")
        Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly( _
            myAsmName, _
            AssemblyBuilderAccess.Save)

        ' An assembly is made up of executable modules. For a single-
        ' module assembly, the module name and file name are the same 
        ' as the assembly name. 
        '
        Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule( _
            myAsmName.Name, _
            myAsmName.Name & ".dll")

        ' Define the sample type.
        Dim myType As TypeBuilder = myModule.DefineType( _
            "Sample", _
            TypeAttributes.Public Or TypeAttributes.Abstract)

        ' Make the sample type a generic type, by defining a type
        ' parameter T. All type parameters are defined at the same
        ' time, by passing an array containing the type parameter
        ' names. 
        Dim typeParamNames() As String = {"T"}
        Dim typeParams() As GenericTypeParameterBuilder = _
            myType.DefineGenericParameters(typeParamNames)

        ' Define a method that takes a ByRef argument of type T, a
        ' pointer to type T, and one-dimensional array of type T. The
        ' method returns a two-dimensional array of type T.
        '
        ' To create this method, you need Type objects that represent the
        ' parameter types and the return type. Use the MakeByRefType, 
        ' MakePointerType, and MakeArrayType methods to create the Type
        ' objects, using the generic type parameter T.
        '
        Dim byRefType As Type = typeParams(0).MakeByRefType
        Dim pointerType As Type = typeParams(0).MakePointerType
        Dim arrayType As Type = typeParams(0).MakeArrayType
        Dim twoDimArrayType As Type = typeParams(0).MakeArrayType(2)

        ' Create the array of parameter types.
        Dim parameterTypes() As Type = _
            {byRefType, pointerType, arrayType}

        ' Define the abstract Test method. After you have compiled
        ' and run this example code, you can use ildasm.exe to open
        ' MakeXxxGenericTypeParameterExample.dll, examine the Sample
        ' type, and verify the parameter types and return type of
        ' the TestMethod method.
        '
        Dim myMethodBuilder As MethodBuilder = myType.DefineMethod( _
            "TestMethod", _
            MethodAttributes.Abstract Or MethodAttributes.Virtual _
                Or MethodAttributes.Public, _
            twoDimArrayType, _
            parameterTypes)

        ' Create the type and save the assembly. For a single-file 
        ' assembly, there is only one module to store the manifest 
        ' information in.
        '
        myType.CreateType()
        myAssembly.Save(myAsmName.Name & ".dll")

    End Sub
End Class
'</Snippet1>