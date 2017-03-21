  Dim p As SqlProfileProvider = _
    CType(Profile.Providers("SqlProvider"), SqlProfileProvider)

  Dim pvalues As SettingsPropertyValueCollection = _
    p.GetPropertyValues(Profile.Context, ProfileBase.Properties)

  For Each pval As SettingsPropertyValue In pvalues
    Response.Write(pval.Name & " = " & pval.PropertyValue.ToString() & "<br />")
  Next