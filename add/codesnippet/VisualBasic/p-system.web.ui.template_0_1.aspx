    ' Get the class type for which to access metadata.
    Dim clsType As Type = GetType(VB_TemplatedFirstControl)
    ' Get the PropertyInfo object for FirstTemplate.
    Dim pInfo As PropertyInfo = clsType.GetProperty("FirstTemplate")
    ' See if the TemplateContainer attribute is defined for this property.
    Dim isDef As Boolean = Attribute.IsDefined(pInfo, GetType(TemplateContainerAttribute))
    ' Display the result if the attribute exists.
    If isDef Then
      Dim tca As TemplateContainerAttribute = CType(Attribute.GetCustomAttribute(pInfo, GetType(TemplateContainerAttribute)), TemplateContainerAttribute)
      Response.Write("The binding direction is: " & tca.BindingDirection.ToString())
    End If