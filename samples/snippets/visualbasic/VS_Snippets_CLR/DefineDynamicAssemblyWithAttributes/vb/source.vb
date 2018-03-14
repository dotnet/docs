'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Security

Module Example

    Sub Main()
    
        ' Create a CustomAttributeBuilder for the assembly attribute. 
        ' 
        ' SecurityTransparentAttribute has a parameterless constructor, 
        ' which is retrieved by passing an array of empty types for the
        ' constructor's parameter types. The CustomAttributeBuilder is 
        ' then created by passing the ConstructorInfo and an empty array
        ' of objects to represent the parameters.
        '
        Dim transparentCtor As ConstructorInfo = _
            GetType(SecurityTransparentAttribute).GetConstructor( _
                Type.EmptyTypes)
        Dim transparent As New CustomAttributeBuilder( _
            transparentCtor, _
            New Object() {} )
      
        ' Create a dynamic assembly Imports the attribute. The attribute is
        ' passed as an array with one element.
        Dim aName As New AssemblyName("EmittedAssembly")
        Dim ab As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly( _
                aName, _
                AssemblyBuilderAccess.Run, _
                New CustomAttributeBuilder() { transparent } )

        Dim mb As ModuleBuilder = ab.DefineDynamicModule( aName.Name )
        Dim tb As TypeBuilder = mb.DefineType( _
            "MyDynamicType", _
            TypeAttributes.Public )
        tb.CreateType()

        Console.WriteLine("{0}" & vbLf & "Assembly attributes:", ab)
        For Each attr As Attribute In ab.GetCustomAttributes(True)
            Console.WriteLine(vbTab & "{0}", attr)
        Next
    End Sub
End Module

' This code example produces the following output:
'
'EmittedAssembly, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
'Assembly attributes:
'        System.Security.SecurityTransparentAttribute
'</Snippet1>
