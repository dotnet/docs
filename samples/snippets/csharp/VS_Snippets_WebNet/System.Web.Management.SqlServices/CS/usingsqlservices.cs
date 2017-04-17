// <Snippet1>
using System;
using System.Web.Management;

namespace UsingSQLServices
{
	class UsingSqlServices
	{
		static void Main(string[] args)
		{
			try
			{
// Values to use.
string server = "ASPFeatureServer";
string database = "ASPFeatureDB";
string connectionString =
	"server=ASPFeatureServer, pooling=False, user=<user name>, password=<secure password>";
string user = "AspAdmin";
string password = "Secure Password"; // Use a sicure password.

// <Snippet2>
// Install membership and personalization.
SqlServices.Install(database,
	SqlFeatures.Membership &
	SqlFeatures.Personalization,
	connectionString);
// </Snippet2>

// <Snippet3>
// Remove membership and personalization.
SqlServices.Uninstall(database,
	SqlFeatures.Membership &
	SqlFeatures.Personalization,
	connectionString);
// </Snippet3>

// <Snippet4>
// Install all features.
SqlServices.Install(server, database,
	SqlFeatures.All);
// </Snippet4>

// <Snippet5>
// Remove all features.
SqlServices.Uninstall(server, database,
	SqlFeatures.All);
// </Snippet5>

// <Snippet8>
// Install a custom session state database.
SqlServices.InstallSessionState(database,
	SessionStateType.Custom,
	connectionString);
// </Snippet8>

// <Snippet9>
// Remove a custom session state database.
SqlServices.UninstallSessionState(database,
	SessionStateType.Custom,
	connectionString);
// </Snippet9>

// <Snippet10>
// Install temporary session state.
SqlServices.InstallSessionState(server, null,
	SessionStateType.Temporary);
// </Snippet10>

// <Snippet11>
// Remove temporary session state.
SqlServices.UninstallSessionState(server, null,
	SessionStateType.Temporary);
// </Snippet11>

// <Snippet12>
// Install persisted session state.
SqlServices.InstallSessionState(server, user, password,
	null, SessionStateType.Persisted);
// </Snippet12>

// <Snippet13>
// Remove persisted session state.
SqlServices.UninstallSessionState(server, user, password,
	null, SessionStateType.Persisted);
// </Snippet13>
			}
			catch (SqlExecutionException sqlExecutionException)
			{
// <Snippet14>
Console.WriteLine(
	"An SQL execution exception occurred.");
Console.WriteLine();
// <Snippet15>
Console.WriteLine("  Message: {0}",
	sqlExecutionException.Message);
// </Snippet15>
// <Snippet16>
Console.WriteLine("  Server: {0}",
	sqlExecutionException.Server);
// </Snippet16>
// <Snippet17>
Console.WriteLine("  Database: {0}",
	sqlExecutionException.Database);
// </Snippet17>
// <Snippet18>
Console.WriteLine("  Commands: {0}",
	sqlExecutionException.Commands);
// </Snippet18>
// <Snippet19>
Console.WriteLine("  SqlFile: {0}",
	sqlExecutionException.SqlFile);
// </Snippet19>
// <Snippet20>
Console.WriteLine("  Inner Exception: {0}",
	sqlExecutionException.Exception);
// </Snippet20>
// </Snippet14>
			}
			catch (Exception ex)
			{
Console.WriteLine("An unknown exception occurred.");
Console.WriteLine();
Console.WriteLine("  Message: {0}", ex.Message);
			}
		}
	}
}
// </Snippet1>
