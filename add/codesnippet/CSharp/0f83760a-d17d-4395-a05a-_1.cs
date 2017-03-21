// Remove membership and personalization.
SqlServices.Uninstall(database,
	SqlFeatures.Membership &
	SqlFeatures.Personalization,
	connectionString);