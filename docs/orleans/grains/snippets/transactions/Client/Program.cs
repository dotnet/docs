using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient((_, builder) =>
    {
        builder.UseLocalhostClustering()
            .UseTransactions();
    })
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();
var transactionClient= host.Services.GetRequiredService<ITransactionClient>();

var accountNames = new[]
{ 
    KnownAccounts.Ida, KnownAccounts.Stacy, KnownAccounts.Xaawo,
    KnownAccounts.Pasqualino, KnownAccounts.Derick, KnownAccounts.Xiao
};
var random = Random.Shared;

while (!Console.KeyAvailable)
{
    // Choose some random accounts to exchange money
    var fromIndex = random.Next(accountNames.Length);
    var toIndex = random.Next(accountNames.Length);
    while (toIndex == fromIndex)
    {
        // Avoid transfering to/from the same account, since it would be meaningless
        toIndex = (toIndex + 1) % accountNames.Length;
    }

    var fromLookup = accountNames[fromIndex];
    var toLookup = accountNames[toIndex];
    var from = client.GetGrain<IAccountGrain>(fromLookup.Id);
    var to = client.GetGrain<IAccountGrain>(toLookup.Id);

    // Perform the transfer and query the results
    try
    {
        var transferAmount = random.Next(200);

        await transactionClient.RunTransaction(
            TransactionOption.Create, async () =>
            {
                await from.Withdraw(transferAmount);
                await to.Deposit(transferAmount);
            });

        var fromBalance = await from.GetBalance();
        var toBalance = await to.GetBalance();

        Console.WriteLine(
            $"We transfered {transferAmount} credits from {fromLookup} to " +
            $"{toLookup}.\n{fromLookup} balance: {fromBalance}\n{toLookup} balance: {toBalance}\n");
    }
    catch (Exception exception)
    {
        Console.WriteLine(
            $"Error transfering credits from " +
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
