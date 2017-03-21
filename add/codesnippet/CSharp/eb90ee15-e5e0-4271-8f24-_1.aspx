  SqlProfileProvider p = 
    (SqlProfileProvider)Profile.Providers["SqlProvider"];

  SettingsPropertyValueCollection pvalues = 
    p.GetPropertyValues(Profile.Context, ProfileBase.Properties);

  pvalues["ZipCode"].PropertyValue = "98052";
  pvalues["CityAndState"].PropertyValue = "Redmond, WA";

  p.SetPropertyValues(Profile.Context, pvalues);