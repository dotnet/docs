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

// Install membership and personalization.
SqlServices.Install(database,
	SqlFeatures.Membership &
	SqlFeatures.Personalization,
	connectionString);

// Remove membership and personalization.
SqlServices.Uninstall(database,
	SqlFeatures.Membership &
	SqlFeatures.Personalization,
	connectionString);

// Install all features.
SqlServices.Install(server, database,
	SqlFeatures.All);

// Remove all features.
SqlServices.Uninstall(server, database,
	SqlFeatures.All);

// Install a custom session state database.
SqlServices.InstallSessionState(database,
	SessionStateType.Custom,
	connectionString);

// Remove a custom session state database.
SqlServices.UninstallSessionState(database,
	SessionStateType.Custom,
	connectionString);

// Install temporary session state.
SqlServices.InstallSessionState(server, null,
	SessionStateType.Temporary);

// Remove temporary session state.
SqlServices.UninstallSessionState(server, null,
	SessionStateType.Temporary);

// Install persisted session state.
SqlServices.InstallSessionState(server, user, password,
	null, SessionStateType.Persisted);

// Remove persisted session state.
SqlServices.UninstallSessionState(server, user, password,
	null, SessionStateType.Persisted);
			}
			catch (SqlExecutionException sqlExecutionException)
			{
Console.WriteLine(
	"An SQL execution exception occurred.");
Console.WriteLine();
Console.WriteLine("  Message: {0}",
	sqlExecutionException.Message);
Console.WriteLine("  Server: {0}",
	sqlExecutionException.Server);
Console.WriteLine("  Database: {0}",
	sqlExecutionException.Database);
Console.WriteLine("  Commands: {0}",
	sqlExecutionException.Commands);
Console.WriteLine("  SqlFile: {0}",
	sqlExecutionException.SqlFile);
Console.WriteLine("  Inner Exception: {0}",
	sqlExecutionException.Exception);
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