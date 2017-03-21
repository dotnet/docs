' Install membership and personalization.
SqlServices.Install(database, _
    SqlFeatures.Membership And _
    SqlFeatures.Personalization, _
    connectionString)