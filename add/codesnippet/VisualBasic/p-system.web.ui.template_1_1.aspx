  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
    
    ' Get the class type for which to access metadata.
    Dim clsType As Type = GetType(MyLoginViewA)
    ' Get the PropertyInfo object for FirstTemplate.
    Dim pInfo As PropertyInfo = clsType.GetProperty("AnonymousTemplate")
    ' See if the TemplateInstanceAttribute is defined for this property.
    Dim isDef As Boolean = Attribute.IsDefined(pInfo, GetType(TemplateContainerAttribute))
    
    ' Display the result if the attribute exists.
    If isDef Then
      Dim tia As TemplateInstanceAttribute = CType(Attribute.GetCustomAttribute(pInfo, GetType(TemplateInstanceAttribute)), TemplateInstanceAttribute)
      Response.Write("The <AnonymousTemplate> has the TemplateInstanceAttribute = " & tia.Instances.ToString() & ".<br />")
      If (tia.IsDefaultAttribute()) Then
        Response.Write("The TemplateInstanceAttribute used is the same as the default instance.")
      Else
        Response.Write("The TemplateInstanceAttribute used is not the same as the default instance.")
      End If

    End If

  End Sub