public override ProfileInfoCollection FindProfilesByUserName(
	ProfileAuthenticationOption authenticationOption,
	string usernameToMatch,
	int pageIndex,
	int pageSize,
	out int totalRecords)
{
	totalRecords = 0;

	return new ProfileInfoCollection();
}