Option Explicit On
Option Strict On

Class Class3e7df17a74954c74868484ac547daebe

    Public Sub Method1()
        ' 3e7df17a-7495-4c74-8684-84ac547daebe : How to: Determine if a User is a Group
        ' f94d2d63-b41c-4767-918d-0318e1a1e969 : My.User.IsInRole Method
        ' <snippet1>
        If My.User.IsInRole( 
                ApplicationServices.BuiltInRole.Administrator) Then
            ' Insert code to access a resource here.
        End If
        ' </snippet1>

        ' 4b7dae81-935b-403d-b3fd-3342cbb2dc05 : My.User.IsAuthenticated Property
        ' <snippet2>
        If My.User.IsAuthenticated Then
            ' Insert code to access a resource here.
        End If
        ' </snippet2>

    End Sub

    ' 94eecbea-176e-4fff-9fe3-477399f60622 : My.User.Name Property
    ' caa7462e-2149-4bdb-8850-802b80b93cbf : My.User Object
    ' d6f68334-9935-4c92-bbd9-ae28649a4932 : How to: Determine a User's Login Name
    ' e9aa1d68-8ef8-4dca-9d88-c729663269d3 : My.User.CurrentPrincipal Property
    ' <snippet3>
    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is 
          Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function
    ' </snippet3>

    ' f7e734bd-33d4-402e-8eed-ffc905f94fa0 : How to: Determine the User's Domain
    ' <snippet23>
    Function GetUserDomain() As String
        If TypeOf My.User.CurrentPrincipal Is 
          Security.Principal.WindowsPrincipal Then
            ' My.User is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim domain As String = parts(0)
            Return domain
        Else
            ' My.User is using custom authentication.
            Return ""
        End If
    End Function
    ' </snippet23>

End Class