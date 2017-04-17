' <Snippet1>
' Create a Class with a number of nested Classes.
Public Class OuterClass
    Private Class PrivateClass
    End Class

    Protected Class ProtectedClass
    End Class

    Friend Class InternalClass
    End Class

    Protected Friend Class ProtectedInternalClass
    End Class

    Public Class PublicClass
    End Class

    Public Shared Sub Main()
        ' Create an array of Type objects for all the Classes.
        Dim types() As Type = { GetType(OuterClass),
                                GetType(OuterClass.PublicClass),
                                GetType(OuterClass.PrivateClass),
                                GetType(OuterClass.ProtectedClass),
                                GetType(OuterClass.InternalClass),
                                GetType(OuterClass.ProtectedInternalClass) }
        ' Display the property values of each nested Class.
        For Each type In types
           Console.WriteLine("{0} property values:", type.Name)
           Console.WriteLine("   Public Class: {0}", type.IsPublic)
           Console.WriteLine("   Not a Public Class: {0}", type.IsNotPublic)
           Console.WriteLine("   Nested Class: {0}", type.IsNested)
           Console.WriteLine("   Nested Private Class: {0}", type.IsNestedPrivate)
           Console.WriteLine("   Nested Internal Class: {0}", type.IsNestedAssembly)
           Console.WriteLine("   Nested Protected Class: {0}", type.IsNestedFamily)
           Console.WriteLine("   Nested Family Or Assembly Class: {0}", type.IsNestedFamORAssem)
           Console.WriteLine("   Nested Family And Assembly Class: {0}", type.IsNestedFamANDAssem)
           Console.WriteLine("   Nested Public Class: {0}", type.IsNestedPublic)
           Console.WriteLine()
        Next
    End Sub
End Class
' The example displays the following output:
'    OuterClass property values:
'       Public Class: True
'       Not a Public Class: False
'       Nested Class: False
'       Nested Private Class: False
'       Nested Internal Class: False
'       Nested Protected Class: False
'       Nested Family Or Assembly Class: False
'       Nested Family And Assembly Class: False
'       Nested Public Class: False
'
'    PublicClass property values:
'       Public Class: False
'       Not a Public Class: False
'       Nested Class: True
'       Nested Private Class: False
'       Nested Internal Class: False
'       Nested Protected Class: False
'       Nested Family Or Assembly Class: False
'       Nested Family And Assembly Class: False
'       Nested Public Class: True
'
'    PrivateClass property values:
'       Public Class: False
'       Not a Public Class: False
'       Nested Class: True
'       Nested Private Class: True
'       Nested Internal Class: False
'       Nested Protected Class: False
'       Nested Family Or Assembly Class: False
'       Nested Family And Assembly Class: False
'       Nested Public Class: False
'
'    ProtectedClass property values:
'       Public Class: False
'       Not a Public Class: False
'       Nested Class: True
'       Nested Private Class: False
'       Nested Internal Class: False
'       Nested Protected Class: True
'       Nested Family Or Assembly Class: False
'       Nested Family And Assembly Class: False
'       Nested Public Class: False
'
'    InternalClass property values:
'       Public Class: False
'       Not a Public Class: False
'       Nested Class: True
'       Nested Private Class: False
'       Nested Internal Class: True
'       Nested Protected Class: False
'       Nested Family Or Assembly Class: False
'       Nested Family And Assembly Class: False
'       Nested Public Class: False
'
'    ProtectedInternalClass property values:
'       Public Class: False
'       Not a Public Class: False
'       Nested Class: True
'       Nested Private Class: False
'       Nested Internal Class: False
'       Nested Protected Class: False
'       Nested Family Or Assembly Class: True
'       Nested Family And Assembly Class: False
'       Nested Public Class: False
' </Snippet1>