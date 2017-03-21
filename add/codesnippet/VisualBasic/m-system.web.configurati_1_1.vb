      ' Get the section related object.
      Dim configSection As System.Web.Configuration.HttpRuntimeSection = _
       CType(config.GetSection("system.web/httpRuntime"), _
       System.Web.Configuration.HttpRuntimeSection)