' REDMOND\glennha
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices

Public Class Example

    Public Shared Sub Main()

        Dim myDomain As AppDomain = AppDomain.CurrentDomain
        Dim myAsmName As New AssemblyName("EmitMarshalAs")

        Dim myAssembly As AssemblyBuilder = _
            myDomain.DefineDynamicAssembly(myAsmName, _
                AssemblyBuilderAccess.RunAndSave)

        Dim myModule As ModuleBuilder = _
            myAssembly.DefineDynamicModule(myAsmName.Name, _
                myAsmName.Name & ".dll")

        Dim myType As TypeBuilder = _
            myModule.DefineType("Sample", TypeAttributes.Public)
        
        Dim myMethod As MethodBuilder = _
            myType.DefineMethod("Test", MethodAttributes.Public, _
                Nothing, new Type() { GetType(String) })


        ' Get a parameter builder for the parameter that needs the 
        ' attribute, using the HasFieldMarshal attribute. In this
        ' example, the parameter is at position 0 and has the name
        ' "arg".
        Dim pb As ParameterBuilder = _
            myMethod.DefineParameter(0, _
               ParameterAttributes.HasFieldMarshal, "arg")

        ' Get the MarshalAsAttribute constructor that takes an
        ' argument of type UnmanagedType.
        '
        Dim ciParameters() As Type = { GetType(UnmanagedType) }
        Dim ci As ConstructorInfo = _
            GetType(MarshalAsAttribute).GetConstructor(ciParameters)

        ' Create a CustomAttributeBuilder representing the attribute,
        ' specifying the necessary unmanaged type. In this case, 
        ' UnmanagedType.BStr is specified.
        '
        Dim ciArguments() As Object = { UnmanagedType.BStr }
        Dim cabuilder As New CustomAttributeBuilder(ci, ciArguments)

        ' Apply the attribute to the parameter.
        '
        pb.SetCustomAttribute(cabuilder)


        ' Emit a dummy method body.
        Dim il As ILGenerator = myMethod.GetILGenerator()
        il.Emit(OpCodes.Ret)

        myType.CreateType()
        myAssembly.Save(myAsmName.Name & ".dll")

    End Sub

End Class
'</Snippet1>
