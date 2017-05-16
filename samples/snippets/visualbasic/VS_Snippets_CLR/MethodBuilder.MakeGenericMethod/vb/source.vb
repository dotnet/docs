' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class Example

    Public Shared Sub Main()
    
        ' Define a transient dynamic assembly (only to run, not
        ' to save) with one module and a type "Test".
        ' 
        Dim aName As AssemblyName = New AssemblyName("MyDynamic")
        Dim ab As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly( _
                aName, _
                AssemblyBuilderAccess.Run)
        Dim mb As ModuleBuilder = ab.DefineDynamicModule(aName.Name)
        Dim tb As TypeBuilder = mb.DefineType("Test")

        ' Add a Public Shared method "M" to Test, and make it a
        ' generic method with one type parameter named "T").
        '
        Dim meb As MethodBuilder = tb.DefineMethod("M", _
            MethodAttributes.Public Or MethodAttributes.Static)
        Dim typeParams() As GenericTypeParameterBuilder = _
            meb.DefineGenericParameters(New String() { "T" })

        ' Give the method one parameter, of type T, and a 
        ' return type of T.
        meb.SetParameters(typeParams)
        meb.SetReturnType(typeParams(0))

        ' Create a MethodInfo for M(Of String), which can be used 
        ' in emitted code. This is possible even though the method
        ' does not yet have a body, and the enclosing type is not
        ' created.
        Dim mi As MethodInfo = _
            meb.MakeGenericMethod(GetType(String))
        ' Note that this is actually a subclass of MethodInfo, 
        ' which has rather limited capabilities -- for
        ' example, you cannot reflect on its parameters.
    End Sub
End Class
' </Snippet1>