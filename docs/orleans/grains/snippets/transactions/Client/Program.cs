using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient((_, builder) =>
    {
        builder.UseLocalhostClustering();
    })
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();
var accountNames = new[]
{ 
    KnownAccounts.Ida, KnownAccounts.Stacy, KnownAccounts.Xaawo,
    KnownAccounts.Pasqualino, KnownAccounts.Derick, KnownAccounts.Xiao
};
var random = Random.Shared;

while (!Console.KeyAvailable)
{
    var atm = client.GetGrain<IAtmGrain>(1);

    // Choose some random accounts to exchange money
    var fromId = random.Next(accountNames.Length);
    var toId = random.Next(accountNames.Length);
    while (toId == fromId)
    {
        // Avoid transfering to/from the same account, since it would be meaningless
        toId = (toId + 1) % accountNames.Length;
    }

    var fromLookup = accountNames[fromId];
    var toLookup = accountNames[toId];
    var from = client.GetGrain<IAccountGrain>(fromLookup.Id);
    var to = client.GetGrain<IAccountGrain>(toLookup.Id);

    // Perform the transfer and query the results
    try
    {
        await atm.Transfer(fromLookup.Id, toLookup.Id, 100);

        var fromBalance = await from.GetBalance();
        var toBalance = await to.GetBalance();

        Console.WriteLine(
            $"We transfered 100 credits from {fromLookup} to " +
            $"{toLookup}.\n{fromLookup} balance: {fromBalance}\n{toLookup} balance: {toBalance}\n");
    }
    catch (Exception exception)
    {
        Console.WriteLine(
            $"Error transfering 100 credits from " +
            $"{fromLookup} to {toLookup}: {exception.Message}");

        if (exception.InnerException is { } inner)
        {
            Console.WriteLine($"\tInnerException: {inner.Message}\n");
        }

        Console.WriteLine();
    }

    // Sleep and run again
    await Task.Delay(TimeSpan.FromMilliseconds(200));
}
