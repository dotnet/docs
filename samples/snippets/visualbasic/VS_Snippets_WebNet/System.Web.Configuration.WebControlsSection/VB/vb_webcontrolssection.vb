Imports System
Imports System.Text
Imports System.Configuration
Imports System.Web.Configuration


Class UsingWebControlsSection


    Public Overloads Shared Sub Main(ByVal args() As String)

        ' <Snippet1>

        ' Get the Web application configuration.
        Dim configuration _
        As System.Configuration.Configuration = _
        WebConfigurationManager.OpenWebConfiguration( _
        "/aspnetTest")

        ' Get the <webControls> section.
        Dim webControlsSection _
        As WebControlsSection = _
        CType(configuration.GetSection( _
        "system.web/webControls"), WebControlsSection)

        ' Read the client script location.
        Dim clientScriptLocation As String = _
        webControlsSection.ClientScriptsLocation

        Dim msg As String = _
        String.Format( _
        "Client script location: {0}" + _
        ControlChars.Lf, clientScriptLocation)
        Console.Write(msg)

        ' </Snippet1>

    End Sub 'Main 
End Class 'UsingUrlMapping 


