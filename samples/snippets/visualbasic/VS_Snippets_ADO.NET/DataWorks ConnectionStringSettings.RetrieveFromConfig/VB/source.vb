Option Explicit On
Option Strict On
' <Snippet1>
Imports System.Configuration

Class Program
    Shared Sub Main()
        GetConnectionStrings()
        Console.ReadLine()
    End Sub

    Private Shared Sub GetConnectionStrings()

        Dim settings As ConnectionStringSettingsCollection = _
            ConfigurationManager.ConnectionStrings

        If Not settings Is Nothing Then
            For Each cs As ConnectionStringSettings In settings
                Console.WriteLine(cs.Name)
                Console.WriteLine(cs.ProviderName)
                Console.WriteLine(cs.ConnectionString)
            Next
        End If
    End Sub
End Class
' </Snippet1>

