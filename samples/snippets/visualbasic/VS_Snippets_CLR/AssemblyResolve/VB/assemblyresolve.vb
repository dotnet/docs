Imports System
Imports System.Reflection

' <Snippet1>
Public Class MyType

    Public Sub New()
        Console.WriteLine()
        Console.WriteLine("MyType instantiated!")
    End Sub 'New

End Class 'MyType

Class Test

    Public Shared Sub Main()
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain

        ' This call will fail to create an instance of MyType since the
        ' assembly resolver is not set
        InstantiateMyTypeFail(currentDomain)

        AddHandler currentDomain.AssemblyResolve, AddressOf MyResolveEventHandler

        ' This call will succeed in creating an instance of MyType since the
        ' assembly resolver is now set.
        InstantiateMyTypeFail(currentDomain)

        ' This call will succeed in creating an instance of MyType since the
        ' assembly name is valid.
        InstantiateMyTypeSucceed(currentDomain)
    End Sub 'Main

    Private Shared Sub InstantiateMyTypeFail(domain As AppDomain)
        ' Calling InstantiateMyType will always fail since the assembly info
        ' given to CreateInstance is invalid.
        Try
            ' You must supply a valid fully qualified assembly name here.
            domain.CreateInstance("Assembly text name, Version, Culture, PublicKeyToken", "MyType")
        Catch e As Exception
            Console.WriteLine()
            Console.WriteLine(e.Message)
        End Try
    End Sub 'InstantiateMyType

    Private Shared Sub InstantiateMyTypeSucceed(domain As AppDomain)
        Try
            Dim asmname As String = Assembly.GetCallingAssembly().FullName
            domain.CreateInstance(asmname, "MyType")
        Catch e As Exception
            Console.WriteLine()
            Console.WriteLine(e.Message)
        End Try
    End Sub

    Private Shared Function MyResolveEventHandler(sender As Object, args As ResolveEventArgs) As Assembly
        Console.WriteLine("Resolving...")
        Return GetType(MyType).Assembly
    End Function 'MyResolveEventHandler

End Class 'Test
' </Snippet1>