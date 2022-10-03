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

var accountNames = new[] { "Xaawo", "Pasqualino", "Derick", "Ida", "Stacy", "Xiao" };
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

    var fromKey = accountNames[fromIndex];
    var toKey = accountNames[toIndex];
    var from = client.GetGrain<IAccountGrain>(fromKey);
    var to = client.GetGrain<IAccountGrain>(toKey);

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
            $"We transfered {transferAmount} credits from {fromKey} to " +
            $"{toKey}.\n{fromKey} balance: {fromBalance}\n{toKey} balance: {toBalance}\n");
    }
    catch (Exception exception)
    {
        Console.WriteLine(
            $"Error transfering credits from " +
            $"{fromKey} to {toKey}: {exception.Message}");

        if (exception.InnerException is { } inner)
        {
            Console.WriteLine($"\tInnerException: {inner.Message}\n");
        }

        Console.WriteLine();
    }

    // Sleep and run again
    await Task.Delay(TimeSpan.FromMilliseconds(200));
}
