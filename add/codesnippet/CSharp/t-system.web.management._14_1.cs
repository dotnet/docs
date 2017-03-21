// Install membership and personalization.
SqlServices.Install(database,
	SqlFeatures.Membership &
	SqlFeatures.Personalization,
	connectionString);