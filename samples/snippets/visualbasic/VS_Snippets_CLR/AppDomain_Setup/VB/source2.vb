'<snippet2>
Imports System.Reflection

Class AppDomain3
    Public Shared Sub Main()
        ' Create the new application domain.
        Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain", Nothing)

        ' Output to the console.
        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName)
        Console.WriteLine("New domain: " + domain.FriendlyName)
        Console.WriteLine("Application base is: " + domain.BaseDirectory)
        Console.WriteLine("Relative search path is: " + domain.RelativeSearchPath)
        Console.WriteLine("Shadow copy files is set to: " + domain.ShadowCopyFiles)
        AppDomain.Unload(domain)
    End Sub
End Class
'</snippet2>
