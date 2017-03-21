  SqlProfileProvider p = 
    (SqlProfileProvider)Profile.Providers["SqlProvider"];

  SettingsPropertyValueCollection pvalues = 
        p.GetPropertyValues(Profile.Context, ProfileBase.Properties);

  foreach (SettingsPropertyValue pval in pvalues)
  {
    Response.Write(pval.Name + " = " + pval.PropertyValue + "<br />");
  } 