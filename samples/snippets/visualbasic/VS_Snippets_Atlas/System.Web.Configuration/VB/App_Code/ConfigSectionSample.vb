Imports System
Imports System.Web.Configuration

Public Class ConfigSectionSample
    
    Public Shared Sub GetAuthServiceSection() 
        '<snippet1>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")
        
        ' Get the external Web services section.
        Dim webServicesSection As ScriptingWebServicesSectionGroup = _
            CType(configuration.GetSectionGroup( _
            "system.web.extensions/scripting/webServices"), ScriptingWebServicesSectionGroup)
        
        ' Get the authentication service section.
        Dim authenticationSection _
            As ScriptingAuthenticationServiceSection = _
            webServicesSection.AuthenticationService
        '</snippet1>
    End Sub
    
    Public Shared Sub GetProfileServiceSection()
        '<snippet2>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the external Web services section.
        Dim webServicesSection As ScriptingWebServicesSectionGroup = _
            CType(configuration.GetSectionGroup( _
            "system.web.extensions/scripting/webServices"), ScriptingWebServicesSectionGroup)

        ' Get the profile service section.
        Dim profileSection _
            As ScriptingProfileServiceSection = _
            webServicesSection.ProfileService
        '</snippet2>
    End Sub

    Public Shared Sub GetConverterElement()
        '<snippet3>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the external JSON section.
        Dim jsonSection As ScriptingJsonSerializationSection = _
            CType(configuration.GetSection( _
                "system.web.extensions/scripting/webServices/jsonSerialization"), _
                ScriptingJsonSerializationSection)

        'Get the converters collection.
        Dim converters As ConvertersCollection = _
            jsonSection.Converters

        If Not (converters Is Nothing) AndAlso _
            converters.Count > 0 Then
            ' Get the first registered converter.
            Dim converterElement As Converter = converters(0)
        End If
        '</snippet3>

    End Sub

    Public Shared Sub GetRoleServiceSection()
        '<snippet4>
        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the external Web services section.
        Dim webServicesSection As ScriptingWebServicesSectionGroup = _
            CType(configuration.GetSectionGroup( _
            "system.web.extensions/scripting/webServices"), ScriptingWebServicesSectionGroup)

        ' Get the role service section.
        Dim roleSection _
            As ScriptingRoleServiceSection = _
            webServicesSection.RoleService
        '</snippet4>
    End Sub

End Class
