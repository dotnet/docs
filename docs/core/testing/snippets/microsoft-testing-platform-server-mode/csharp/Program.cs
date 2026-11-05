// <RunClient>
using TestClientSample;

if (args.Length != 1)
{
    Console.Error.WriteLine("Usage: DiscoverAndRun <test-application-path>");
    return 1;
}

return await TestClient.DiscoverAndRunAsync(args[0]);
// </RunClient>
