'<snippet2>
Imports System
Imports System.Reflection

Class AppDomain1
    Public Shared Sub Main()
        Console.WriteLine("Creating new AppDomain.")
        Dim domain As AppDomain = AppDomain.CreateDomain("MyDomain")

        Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName)
        Console.WriteLine("child domain: " + domain.FriendlyName)
    End Sub
End Class
'</snippet2>
