  Dim p As SqlProfileProvider = _
    CType(Profile.Providers("SqlProvider"), SqlProfileProvider)

  Dim pvalues As SettingsPropertyValueCollection = _
    p.GetPropertyValues(Profile.Context, ProfileBase.Properties)

  pvalues("ZipCode").PropertyValue = "98052"
  pvalues("CityAndState").PropertyValue = "Redmond, WA"

  p.SetPropertyValues(Profile.Context, pvalues)