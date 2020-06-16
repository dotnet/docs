Imports System.Resources

Public Module Example
    Public Sub Main()
        CallCtor1()
        CallCtor2()
    End Sub

    Sub CallCtor1()
        ' <Snippet1>
        Dim rm As New ResourceManager("MyCompany.StringResources",
                                      GetType(Example).Assembly)
        ' </Snippet1>                             
    End Sub

    Sub CallCtor2()
        ' <Snippet2>
        Dim rm As New ResourceManager(GetType(MyCompany.StringResources))
        ' </Snippet2>
    End Sub
End Module

Namespace MyCompany
    Class StringResources
    End Class
End Namespace
