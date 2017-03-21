public override ProfileInfoCollection FindInactiveProfilesByUserName(
	ProfileAuthenticationOption authenticationOption,
	string usernameToMatch,
	DateTime userInactiveSinceDate,
	int pageIndex,
	int pageSize,
	out int totalRecords)
{
	totalRecords = 0;

	return new ProfileInfoCollection();
}