    // Get the class type for which to access metadata.
    Type clsType = typeof(TemplatedFirstControl);
    // Get the PropertyInfo object for FirstTemplate.
    PropertyInfo pInfo = clsType.GetProperty("FirstTemplate");
    // See if the TemplateContainer attribute is defined for this property.
    bool isDef = Attribute.IsDefined(pInfo, typeof(TemplateContainerAttribute));
    // Display the result if the attribute exists.
    if (isDef)
    {
      TemplateContainerAttribute tca =
        (TemplateContainerAttribute)Attribute.GetCustomAttribute(pInfo, typeof(TemplateContainerAttribute));
      Response.Write("The binding direction is: " + tca.BindingDirection.ToString());
    }