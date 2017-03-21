' Remove membership and personalization.
SqlServices.Uninstall(database, _
    SqlFeatures.Membership And _
    SqlFeatures.Personalization, _
    connectionString)