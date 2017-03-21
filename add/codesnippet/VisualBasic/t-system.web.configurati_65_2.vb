      ' Get the section.
        Dim authorizationSection _
        As AuthorizationSection = _
        CType(configuration.GetSection( _
        "system.web/authorization"), AuthorizationSection)