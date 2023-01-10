---
title: Transactions in Orleans
description: Learn how to use transactions in .NET Orleans.
ms.date: 10/26/2022
---

# Orleans transactions

Orleans supports distributed ACID transactions against persistent grain state. Transactions are implemented using the [Microsoft.Orleans.Transactions](https://www.nuget.org/packages/Microsoft.Orleans.Transactions) NuGet package. The source code for the sample app in this article is comprised of four projects:

- **_Abstractions_**: A class library containing the grain interfaces and shared classes.
- **_Grains_**: A class library containing the grain implementations.
- **_Server_**: A console app that consumes the abstractions and grains class libraries and acts as the Orleans silo.
- **_Client_**: A console app that consumes the abstractions class library that represents the Orleans client.

## Setup

Orleans transactions are opt-in. A silo and client both must be configured to use transactions. If they aren't configured, any calls to transactional methods on a grain implementation will receive the <xref:Orleans.Transactions.OrleansTransactionsDisabledException>. To enable transactions on a silo, call <xref:Orleans.Hosting.SiloBuilderExtensions.UseTransactions%2A?displayProperty=nameWithType> on the silo host builder:

```csharp
var builder = Host.CreateDefaultBuilder(args)
    UseOrleans((context, siloBuilder) =>
    {
        siloBuilder.UseTransactions();
    });
```

Likewise, to enable transactions on the client, call `UseTransactions` <!-- <xref:Orleans.Hosting.ClientBuilderExtensions.UseTransactions%2A?displayProperty=nameWithType> --> on the client host builder:

```csharp
var builder = Host.CreateDefaultBuilder(args)
    UseOrleansClient((context, clientBuilder) =>
    {
        clientBuilder.UseTransactions();
    });
```

### Transactional state storage

To use transactions, you need to configure a data store. To support various data stores with transactions, the storage abstraction <xref:Orleans.Transactions.Abstractions.ITransactionalStateStorage%601> is used. This abstraction is specific to the needs of transactions, unlike generic grain storage (<xref:Orleans.Storage.IGrainStorage>). To use transaction-specific storage, configure the silo using any implementation of `ITransactionalStateStorage`, such as Azure (<xref:Orleans.Hosting.AzureTableSiloBuilderExtensions.AddAzureTableTransactionalStateStorage%2A>).

For example, consider the following host builder configuration:

:::code source="snippets/transactions/Server/Program.cs":::

For development purposes, if transaction-specific storage is not available for the datastore you need, you can use an `IGrainStorage` implementation instead. For any transactional state that doesn't have a store configured, transactions will attempt to fail over to the grain storage using a bridge. Accessing a transactional state via a bridge to grain storage is less efficient and may not be supported in the future. Hence, the recommendation is to only use this for development purposes.

## Grain interfaces

For a grain to support transactions, transactional methods on a grain interface must be marked as being part of a transaction using the <xref:Orleans.TransactionAttribute>. The attribute needs to indicate how the grain call behaves in a transactional environment as detailed with the following <xref:Orleans.TransactionOption> values:

- <xref:Orleans.TransactionOption.Create?displayProperty=nameWithType>: Call is transactional and will always create a new transaction context (it starts a new transaction), even if called within an existing transaction context.
- <xref:Orleans.TransactionOption.Join?displayProperty=nameWithType>: Call is transactional but can only be called within the context of an existing transaction.
- <xref:Orleans.TransactionOption.CreateOrJoin?displayProperty=nameWithType>: Call is transactional. If called within the context of a transaction, it will use that context, else it will create a new context.
- <xref:Orleans.TransactionOption.Suppress?displayProperty=nameWithType>: Call is not transactional but can be called from within a transaction. If called within the context of a transaction, the context will not be passed to the call.
- <xref:Orleans.TransactionOption.Supported?displayProperty=nameWithType>: Call is not transactional but supports transactions. If called within the context of a transaction, the context will be passed to the call.
- <xref:Orleans.TransactionOption.NotAllowed?displayProperty=nameWithType>:  Call is not transactional and cannot be called from within a transaction. If called within the context of a transaction, it will throw the <xref:System.NotSupportedException>.

Calls can be marked as `TransactionOption.Create`, meaning the call will always start its transaction. For example, the `Transfer` operation in the ATM grain below will always start a new transaction that involves the two referenced accounts.

:::code source="snippets/transactions/Abstractions/IAtmGrain.cs":::

The transactional operations `Withdraw` and `Deposit` on the account grain are marked `TransactionOption.Join`, indicating that they can only be called within the context of an existing transaction, which would be the case if they were called during `IAtmGrain.Transfer`. The `GetBalance` call is marked `CreateOrJoin` so it can be called from within an existing transaction, like via `IAtmGrain.Transfer`, or on its own.

:::code source="snippets/transactions/Abstractions/IAccountGrain.cs":::

### Important considerations

The `OnActivateAsync` couldn't be marked as transactional as any such call requires a proper setup before the call. It exists only for the grain application API. This means that an attempt to read transactional state as part of these methods will throw an exception in the runtime.

## Grain implementations

A grain implementation needs to use an <xref:Orleans.Transactions.Abstractions.ITransactionalState%601> facet to manage grain state via [ACID transactions](../overview.md#distributed-acid-transactions).

```csharp
public interface ITransactionalState<TState>
    where TState : class, new()
{
    Task<TResult> PerformRead<TResult>(
        Func<TState, TResult> readFunction);

    Task<TResult> PerformUpdate<TResult>(
        Func<TState, TResult> updateFunction);
}
```

All read or write access to the persisted state must be performed via synchronous functions passed to the transactional state facet. This allows the transaction system to perform or cancel these operations transactionally. To use a transactional state within a grain, you define a serializable state class to be persisted and declare the transactional state in the grain's constructor with a <xref:Orleans.Transactions.Abstractions.TransactionalStateAttribute>. The latter declares the state name and, optionally, which transactional state storage to use. For more information, see [Setup](#setup).

```csharp
[AttributeUsage(AttributeTargets.Parameter)]
public class TransactionalStateAttribute : Attribute
{
    public TransactionalStateAttribute(string stateName, string storageName = null)
    {
        // ...
    }
}
```

As an example, the `Balance` state object is defined as follows:

:::code source="snippets/transactions/Abstractions/Balance.cs":::

The preceding state object:

- Is decorated with the <xref:Orleans.CodeGeneration.GenerateSerializerAttribute> to instruct the Orleans code generator to generate a serializer.
- Has a `Value` property that's decorated with the `IdAttribute` to uniquely identify the member.

The `Balance` state object is then used in the `AccountGrain` implementation as follows:

:::code source="snippets/transactions/Grains/AccountGrain.cs":::

> [!IMPORTANT]
> A transactional grain must be marked with the <xref:Orleans.Concurrency.ReentrantAttribute> to ensure that the transaction context is correctly passed to the grain call.

In the preceding example, the <xref:Orleans.Transactions.Abstractions.TransactionalStateAttribute> is used to declare that the `balance` constructor parameter should be associated with a transactional state named `"balance"`. With this declaration, Orleans will inject an <xref:Orleans.Transactions.Abstractions.ITransactionalState%601> instance with a state loaded from the transactional state storage named `"TransactionStore"`. The state can be modified via `PerformUpdate` or read via `PerformRead`. The transaction infrastructure will ensure that any such changes performed as part of a transaction, even among multiple grains distributed over an Orleans cluster, will either all be committed or all be undone upon completion of the grain call that created the transaction (`IAtmGrain.Transfer` in the preceding example).

## Call transaction methods from a client

The recommended way to call a transaction grain method is to use the `ITransactionClient`. The `ITransactionClient` is automatically registered with the dependency injection service provider when the Orleans client is configured. The `ITransactionClient` is used to create a transaction context and to call transactional grain methods within that context. The following example shows how to use the `ITransactionClient` to call transactional grain methods.

:::code source="snippets/transactions/Client/Program.cs" highlight="11-12,30-31,38-44":::

In the preceding client code:

- The `IHostBuilder` is configured with `UseOrleansClient`.
  - The `IClientBuilder` uses localhost clustering and transactions.
- The `IClusterClient` and `ITransactionClient` interfaces are retrieved from the service provider.
- The `from` and `to` variables are assigned their `IAccountGrain` references.
- The `ITransactionClient` is used to create a transaction, calling:
  - `Withdraw` on the `from` account grain reference.
  - `Deposit` on the `to` account grain reference.

Transactions are always committed unless there is an exception that is thrown in the `transactionDelegate` or a contradictory `transactionOption` specified. While the recommended way to call transactional grain methods is to use the `ITransactionClient`, you can also call transactional grain methods directly from another grain.

## Call transaction methods from another grain

Transactional methods on a grain interface are called like any other grain method. As an alternative approach using the `ITransactionClient`, the `AtmGrain` implementation below calls the `Transfer` method (which is transactional) on the `IAccountGrain` interface.

Consider the `AtmGrain` implementation, which resolves the two referenced account grains and makes the appropriate calls to `Withdraw` and `Deposit`:

:::code source="snippets/transactions/Grains/AtmGrain.cs":::

Your client app code can call `AtmGrain.Transfer` in a transactional manner as follows:

```csharp
IAtmGrain atmOne = client.GetGrain<IAtmGrain>(0);

Guid from = Guid.NewGuid();
Guid to = Guid.NewGuid();

await atmOne.Transfer(from, to, 100);

uint fromBalance = await client.GetGrain<IAccountGrain>(from).GetBalance();
uint toBalance = await client.GetGrain<IAccountGrain>(to).GetBalance();
```

In the preceding calls, an `IAtmGrain` is used to transfer 100 units of currency from one account to another. After the transfer is complete, both accounts are queried to get their current balance. The currency transfer, as well as both account queries, are performed as ACID transactions.

As shown in the preceding example, transactions can return values within a `Task`, like other grain calls. But upon call failure, they will not throw application exceptions but rather an <xref:Orleans.Transactions.OrleansTransactionException> or <xref:System.TimeoutException>. If the application throws an exception during the transaction and that exception causes the transaction to fail (as opposed to failing because of other system failures), the application exception will be the inner exception of the `OrleansTransactionException`.

If a transaction exception is thrown of type <xref:Orleans.Transactions.OrleansTransactionAbortedException>, the transaction failed and can be retried. Any other exception thrown indicates that the transaction terminated with an unknown state. Since transactions are distributed operations, a transaction in an unknown state could have succeeded, failed, or still be in progress. For this reason, it's advisable to allow a call timeout period (<xref:Orleans.Configuration.SiloMessagingOptions.SystemResponseTimeout?displayProperty=nameWithType>) to pass, to avoid cascading aborts, before verifying the state or retrying the operation.
