' Set Assembly name to ConfigurationElement
' and set Root namespace to Samples.AspNet
Imports System
Imports System.Configuration
Imports System.Collections

Class TestConfigurationElement
    ' Entry point for console application that reads the 
    ' app.config file and writes to the console the 
    ' URLs in the custom section.
    Shared Sub Main(ByVal args() As String)
        ' Get the current configuration file.
        Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

        ' Get the MyUrls section.
        Dim myUrlsSection As UrlsSection = _
            config.GetSection("MyUrls")

        If myUrlsSection Is Nothing Then
            Console.WriteLine("Failed to load UrlsSection.")
        Else
            Console.WriteLine("The 'simple' element of app.config:")
            Console.WriteLine("  Name={0} URL={1} Port={2}", _
                myUrlsSection.Simple.Name, _
                myUrlsSection.Simple.Url, _
                myUrlsSection.Simple.Port)
            Console.WriteLine("The urls collection of app.config:")
            Dim i As Integer
            For i = 0 To myUrlsSection.Urls.Count - 1
                Console.WriteLine("  Name={0} URL={1} Port={2}", _
                i, myUrlsSection.Urls(i).Name, _
                myUrlsSection.Urls(i).Url, _
                myUrlsSection.Urls(i).Port)
            Next i
        End If
        Console.ReadLine()
    End Sub
End Class