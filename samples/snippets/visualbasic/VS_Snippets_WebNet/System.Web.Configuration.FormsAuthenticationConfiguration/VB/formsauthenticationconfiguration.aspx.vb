Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Text
Imports System.Collections.Specialized

Partial Public Class FormsAuthenticationConfiguration_Test
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    ' Access the AuthenticationSection section to get 
    ' the current cookie name.
    Protected Sub GetCookieName()

        Dim buffer As New StringBuilder()

        Try
            ' <Snippet21>

            ' Get the configuration file. Replace the name configTarget
            ' with the name of your site.
            Dim configuration As System.Configuration.Configuration = _
                WebConfigurationManager.OpenWebConfiguration("/configTarget")


            ' Get the authentication section.
            Dim authenticationSection As AuthenticationSection = _
                CType(configuration.GetSection("system.web/authentication"), AuthenticationSection)


            ' Get the external Forms section .
            Dim formsAuthentication As FormsAuthenticationConfiguration = _
                authenticationSection.Forms

            Dim cookieName As String = formsAuthentication.Name
	    
            ' </Snippet21>

            buffer.AppendLine(String.Format("Cookie name: {0} <br/>", cookieName))

            ' Display cookie name
            ' Label1.Text = buffer.ToString()
            Catch e As ConfigurationErrorsException
            buffer.AppendLine(String.Format("[Accessing AuthenticationSection: {0}]", e.ToString()))
            ' Display error.
            ' Label1.Text = buffer.ToString()
        End Try

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        GetCookieName()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Label1.Text = "[Cookie name goes here]"
    End Sub
End Class