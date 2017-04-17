using System;
using System.Configuration;
using System.Collections.Specialized;
using System.Web.Profile;

public class SnippetProfileProvider: ProfileProvider
{

	//
	// System.Configuration.Provider.ProviderBase.Initialize Method
	//

	public override void Initialize(string name, NameValueCollection config)
	{
		base.Initialize(name, config);
	}


	//
	// System.Configuration.SettingsProvider.ApplicationName
	//

	private string pApplicationName;

	public override string ApplicationName
	{
		get { return pApplicationName; }
		set { pApplicationName = value; }
	} 



	//
	// System.Configuration.SettingsProvider methods.
	//

	//
	// SettingsProvider.GetPropertyValues
	//

	public override SettingsPropertyValueCollection 
				GetPropertyValues(SettingsContext context,
						  SettingsPropertyCollection ppc)
	{
		return new SettingsPropertyValueCollection();
	}



	//
	// SettingsProvider.SetPropertyValues
	//

	public override void SetPropertyValues(SettingsContext context,
					       SettingsPropertyValueCollection ppvc)
	{

	}




	//
	// ProfileProvider.DeleteProfiles(ProfileInfoCollection)
	//

//<Snippet1>
public override int DeleteProfiles(ProfileInfoCollection profiles)
{
	return 0;
}
//</Snippet1>

	//
	// ProfileProvider.DeleteProfiles(string[])
	//

//<Snippet2>
public override int DeleteProfiles(string[] usernames)
{
	return 0;
}
//</Snippet2>


	//
	// ProfileProvider.DeleteInactiveProfiles
	//

//<Snippet3>
public override int DeleteInactiveProfiles(
	ProfileAuthenticationOption authenticationOption,
	DateTime userInactiveSinceDate)
{
	return 0;
}
//</Snippet3>


	//
	// ProfileProvider.FindProfilesByUserName
	//

//<Snippet4>
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
//</Snippet4>

	//
	// ProfileProvider.FindInactiveProfilesByUserName
	//

//<Snippet5>
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
//</Snippet5>

	//
	// ProfileProvider.GetAllProfiles
	//

//<Snippet6>
public override ProfileInfoCollection GetAllProfiles(
	ProfileAuthenticationOption authenticationOption,
	int pageIndex,
	int pageSize,
	out int totalRecords)
{
	totalRecords = 0;

	return new ProfileInfoCollection();
}
//</Snippet6>

	//
	// ProfileProvider.GetAllInactiveProfiles
	//

//<Snippet7>
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
//</Snippet7>

	//
	// ProfileProvider.GetNumberOfInactiveProfiles
	//

//<Snippet8>
public override int GetNumberOfInactiveProfiles(
	ProfileAuthenticationOption authenticationOption,
	DateTime userInactiveSinceDate)
{
	return 0;
}
//</Snippet8>
}