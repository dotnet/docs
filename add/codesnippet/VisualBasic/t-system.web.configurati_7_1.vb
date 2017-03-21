
            ' Get the Web application configuration.
            Dim webConfig _
            As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

            ' Get the section.
            Dim configPath As String _
            = "system.web/httpCookies"

            Dim httpCookiesSection _
            As System.Web.Configuration.HttpCookiesSection = _
            CType(webConfig.GetSection(configPath), _
            System.Web.Configuration.HttpCookiesSection)
           