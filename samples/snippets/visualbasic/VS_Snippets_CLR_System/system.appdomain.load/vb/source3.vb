'<snippet3>
Imports System.Reflection

Class AppDomain2
    Public Shared Sub Main()
        Console.WriteLine("Creating new AppDomain.")
        Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", Nothing)

        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName)
        Console.WriteLine("child domain: " + domain.FriendlyName)
        AppDomain.Unload(domain)
        Try
            Console.WriteLine()
            Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName)
            ' The following statement creates an exception because the domain no longer exists.
            Console.WriteLine("child domain: " + domain.FriendlyName)
        Catch e As AppDomainUnloadedException
            Console.WriteLine(e.GetType().FullName)
            Console.WriteLine("The appdomain MyDomain does not exist.")
        End Try
    End Sub
End Class
'</snippet3>
