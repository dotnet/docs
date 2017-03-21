  protected void Page_Load(object sender, EventArgs e)
  {
        
    // Get the class type for which to access metadata.
    Type clsType = typeof(MyLoginViewA);
    // Get the PropertyInfo object for FirstTemplate.
    PropertyInfo pInfo = clsType.GetProperty("AnonymousTemplate");
    // See if the TemplateInstanceAttribute is defined for this property.
    bool isDef = Attribute.IsDefined(pInfo, typeof(TemplateInstanceAttribute));

    // Display the result if the attribute exists.
    if (isDef)
    {
      TemplateInstanceAttribute tia =
        (TemplateInstanceAttribute)Attribute.GetCustomAttribute(pInfo, typeof(TemplateInstanceAttribute));
      Response.Write("The <AnonymousTemplate> has the TemplateInstanceAttribute = " + tia.Instances.ToString() + ".<br />");
      if (tia.IsDefaultAttribute())
        Response.Write("The TemplateInstanceAttribute used is the same as the default instance.");
      else
        Response.Write("The TemplateInstanceAttribute used is not the same as the default instance.");
    }

  }