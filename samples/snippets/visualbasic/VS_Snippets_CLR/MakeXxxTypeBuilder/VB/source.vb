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
        Dim myAsmName As New AssemblyName("MakeXxxTypeExample")
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

        ' Define a method that takes a ByRef argument of type Sample,
        ' a pointer to type Sample, and an array of Sample objects. The
        ' method returns a two-dimensional array of Sample objects.
        '
        ' To create this method, you need Type objects that represent the
        ' parameter types and the return type. Use the MakeByRefType, 
        ' MakePointerType, and MakeArrayType methods to create the Type
        ' objects.
        '
        Dim byRefMyType As Type = myType.MakeByRefType
        Dim pointerMyType As Type = myType.MakePointerType
        Dim arrayMyType As Type = myType.MakeArrayType
        Dim twoDimArrayMyType As Type = myType.MakeArrayType(2)

        ' Create the array of parameter types.
        Dim parameterTypes() As Type = _
            {byRefMyType, pointerMyType, arrayMyType}

        ' Define the abstract Test method. After you have compiled
        ' and run this code example code, you can use ildasm.exe 
        ' to open MakeXxxTypeExample.dll, examine the Sample type,
        ' and verify the parameter types and return type of the
        ' TestMethod method.
        '
        Dim myMethodBuilder As MethodBuilder = myType.DefineMethod( _
            "TestMethod", _
            MethodAttributes.Abstract Or MethodAttributes.Virtual _
                Or MethodAttributes.Public, _
            twoDimArrayMyType, _
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