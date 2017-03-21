
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
	    