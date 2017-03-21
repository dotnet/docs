Console.WriteLine( _
    "An SQL execution exception occurred.")
Console.WriteLine()
Console.WriteLine("  Message: {0}", _
    sqlExecutionException.Message)
Console.WriteLine("  Server: {0}", _
    sqlExecutionException.Server)
Console.WriteLine("  Database: {0}", _
    sqlExecutionException.Database)
Console.WriteLine("  Commands: {0}", _
    sqlExecutionException.Commands)
Console.WriteLine("  SqlFile: {0}", _
    sqlExecutionException.SqlFile)
Console.WriteLine("  Inner Exception: {0}", _
    sqlExecutionException.Exception)