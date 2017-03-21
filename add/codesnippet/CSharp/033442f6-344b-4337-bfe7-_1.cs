public override ProfileInfoCollection GetAllInactiveProfiles(
	ProfileAuthenticationOption authenticationOption,
	DateTime userInactiveSinceDate,
	int pageIndex,
	int pageSize,
	out int totalRecords)
{
	totalRecords = 0;

	return new ProfileInfoCollection();
}