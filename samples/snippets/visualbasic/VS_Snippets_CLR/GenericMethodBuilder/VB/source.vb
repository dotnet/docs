'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class DemoMethodBuilder
   
    Public Shared Sub Main()
        ' Creating a dynamic assembly requires an AssemblyName
        ' object, and the current application domain.
        '
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
      
        Dim demoType As TypeBuilder = demoModule.DefineType( _
            "DemoType", _
            TypeAttributes.Public Or TypeAttributes.Abstract)

        '<Snippet4>
        ' Define a Shared, Public method with standard calling
        ' conventions. Do not specify the parameter types or the
        ' return type, because type parameters will be used for 
        ' those types, and the type parameters have not been
        ' defined yet.
        Dim demoMethod As MethodBuilder = _
            demoType.DefineMethod("DemoMethod", _
                MethodAttributes.Public Or MethodAttributes.Static)
        '</Snippet4>

        '<Snippet3>
        ' Defining generic parameters for the method makes it a
        ' generic method. By convention, type parameters are 
        ' single alphabetic characters. T and U are used here.
        '
        Dim typeParamNames() As String = {"T", "U"}
        Dim typeParameters() As GenericTypeParameterBuilder = _
            demoMethod.DefineGenericParameters(typeParamNames)

        ' The second type parameter is constrained to be a 
        ' reference type.
        typeParameters(1).SetGenericParameterAttributes( _
            GenericParameterAttributes.ReferenceTypeConstraint)
        '</Snippet3>

        '<Snippet7>
        ' Use the IsGenericMethod property to find out if a
        ' dynamic method is generic, and IsGenericMethodDefinition
        ' to find out if it defines a generic method.
        Console.WriteLine("Is DemoMethod generic? {0}", _
            demoMethod.IsGenericMethod)
        Console.WriteLine("Is DemoMethod a generic method definition? {0}", _
            demoMethod.IsGenericMethodDefinition)
        '</Snippet7>

        '<Snippet5>
        ' Set parameter types for the method. The method takes
        ' one parameter, and its type is specified by the first
        ' type parameter, T.
        Dim params() As Type = {typeParameters(0)}
        demoMethod.SetParameters(params)

        ' Set the return type for the method. The return type is
        ' specified by the second type parameter, U.
        demoMethod.SetReturnType(typeParameters(1))
        '</Snippet5>

        ' Generate a code body for the method. The method doesn't
        ' do anything except return Nothing.
        '
        Dim ilgen As ILGenerator = demoMethod.GetILGenerator()
        ilgen.Emit(OpCodes.Ldnull)
        ilgen.Emit(OpCodes.Ret)

        '<Snippet6>
        ' Complete the type.
        Dim dt As Type = demoType.CreateType()

        ' To bind types to a dynamic generic method, you must 
        ' first call the GetMethod method on the completed type.
        ' You can then define an array of types, and bind them
        ' to the method.
        Dim m As MethodInfo = dt.GetMethod("DemoMethod")
        Dim typeArgs() As Type = _
            {GetType(String), GetType(DemoMethodBuilder)}
        Dim bound As MethodInfo = m.MakeGenericMethod(typeArgs)
        ' Display a string representing the bound method.
        Console.WriteLine(bound)
        '</Snippet6>

        ' Save the assembly, so it can be examined with Ildasm.exe.
        demoAssembly.Save(asmName.Name & ".dll")
    End Sub  
End Class 

' This code example produces the following output:
'Is DemoMethod generic? True
'Is DemoMethod a generic method definition? True
'DemoMethodBuilder DemoMethod[String,DemoMethodBuilder](System.String)
'</Snippet1>
