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