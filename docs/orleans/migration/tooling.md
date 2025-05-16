# Migration Tooling

> [!NOTE]
> If your app is already running on Orleans 7.0 or later (referred to as 7.x+ throughout), you don't need this tooling.

[Migrate from Orleans 3.x to 7.0](./guide.md) outlines the key changes introduced in Orleans 7.x+ and how to migrate from 3.x. One of the most significant breaking changes involves [serialization](./guide.md#serialization) and [grain identity representation](./guide.md#grain-identities). The migration tooling provides advanced APIs to convert persisted data to the Orleans 7.x+ format.

This guide explains how to use the tooling. If you're currently running Orleans 3.x, this will help you upgrade to 7.x+ while preserving data integrity.

**Prerequisites:**
- Orleans 3.x app
- .NET 6.0 or higher

## Data Store Differences

Orleans 7.x+ introduces a new grain identity format that changes how grain-related data is stored—for example, in Azure Table Storage. The table below compares a sample grain entry from Orleans 3.x and 7.x+, as stored in Azure Table Storage:

| Version        | PartitionKey                                 | GrainReference                                                              |
|----------------|-----------------------------------------------|------------------------------------------------------------------------------|
| **Orleans 3.x** | 3787bc57a0a1459388a8a5ecb9dcd843_1C2B3D8D     | GrainReference=0000000000000000000000000000012f03fffffffcd9142b             |
| **Orleans 7.x+**| 3787bc57a0a1459388a8a5ecb9dcd843_1C2B3D8D     | simplepersistent_12F                                                        |

In Orleans 7.x+, `GrainReference` is a structured, human-readable string. This schema change **breaks** direct storage compatibility between Orleans 3.x and 7.x+.

## Migration Plan

Your Orleans 3.x application uses persistent storage to store grain state using the older format. This storage may be Azure Table Storage, but the tooling is not limited to that. The migration plan involves pre-creating a new storage system where the same grain data will be saved using the Orleans 7.x+ format. This new storage can be of a different type—for example, you can migrate from Azure Table Storage to Cosmos DB.

Throughout this guide:
- The **source storage** refers to the existing storage used by Orleans 3.x.
- The **destination storage** refers to the new storage compatible with Orleans 7.x+.

The migration tooling supports two modes of migration: **runtime** and **offline**.

At runtime Orleans reads and writes grain state during execution via [`Grain<TGrainState>.ReadStateAsync()`](https://learn.microsoft.com/dotnet/api/orleans.grain-1.readstateasync) and [`Grain<TGrainState>.WriteStateAsync()`](https://learn.microsoft.com/dotnet/api/orleans.grain-1.writestateasync). The migration tooling can intercept these calls to replicate data into the destination storage.

Reminder data is also stored differently in Orleans 7.x+, and its migration follows a similar pattern. Specific APIs for reminder migration will be covered later.

> [!NOTE]
> Migration does not require application downtime. It is designed to be run over an extended period—potentially hours, days, or weeks — depending on your system’s scale. A gradual rollout is recommended, with careful monitoring to avoid disruptions and validate the correctness of migrated state.

### Migration Steps

1. **Prepare destination storage** to hold migrated data.
2. **Register migration components** so Orleans knows which storage is the source and which is the destination.
3. **Wire up source/destination pairs** by registering `MigrationGrainStorage` or `MigrationReminderTable`, and select the appropriate migration mode.
4. **Run the application** for a prolonged period of time to ensure grains are accessed and migrated.
5. **Adjust migration mode** to reduce or eliminate dependency on source storage. Repeat as needed until you are ready to transition fully to Orleans 7.x+.

### How to connect Migration Tooling to your app

Migration tooling is distributed as a set of NuGet packages:

- [Microsoft.Orleans.Persistence.Migration](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Migration) - main package containing core types for the migration functionality. 
- [Microsoft.Orleans.Persistence.AzureStorage.Migration](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.AzureStorage.Migration) - implements migration to azure storage (both blob or table).
- [Microsoft.Orleans.Persistence.Cosmos](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Cosmos) or [Microsoft.Orleans.Persistence.Cosmos.Migration](https://www.nuget.org/packages/Microsoft.Orleans.Persistence.Cosmos.Migration) implement migration to CosmosDB. Since there was no cosmosDb storage support in Orleans 3.x, we introduce both here.

After choosing and installing a needed package (lets say we are performing migration to AzureStorage), you should do the following. Imagine you had such a storage connection registration:
```csharp
.AddAzureBlobGrainStorage(options =>
{
    ...
})
```

Below is step-by-step explanation of how to define migration tooling behavior for migrating azure blob storage to another blob storage (in Orleans7.x+ format). After registrations are in place, a new deployment of application is needed to start migrating the data.

1) Add `AddMigrationTools()`. This registers core components of the migration tooling.
2) Make your initial (source) registration named. For example - `source-storage`:
```csharp
    .AddAzureBlobGrainStorage("source-storage", options =>
    {
        ...
    })
```
3) Register the destination storage - for example `destination-storage`. Note - it has `Migration` in the name explicitly defining the **destination** storage:
```csharp
    .AddMigrationAzureBlobGrainStorage("destination-storage", options =>
    {
        ...
    })
```
4) Now you need to connect a pair of source-destination storage. That can be done via `AddMigrationGrainStorageAsDefault` or `AddMigrationGrainStorage`:
```csharp
.AddMigrationGrainStorageAsDefault(options =>
{
    options.SourceStorageName = "source-storage";
    options.DestinationStorageName = "destination-storage";

    // mode selection
    options.Mode = GrainMigrationMode.ReadDestinationWithFallback_WriteBoth;
})
```

Reminders follow a similar pattern. Snippet below shows registration of azure table storage as source reminder storage, and azure table storage as destination storage for migration connecting them via `UseMigrationReminderTable` registration:
```csharp
.UseAzureTableReminderService("source", options =>
{
    ...
})
.UseMigrationAzureTableReminderStorage("destination", options =>
{
    ...
})
.UseMigrationReminderTable(options =>
{
    options.SourceReminderTable = "source";
    options.DestinationReminderTable = "destination";
    options.Mode = ReminderMigrationMode.ReadDestinationWithFallback_WriteBoth;
})
```

### Runtime Migration

Most of the grains are imagined to be accessed during the application runtime, and they will be written into the destination storage in Orleans7.x+ format. 

Registering components as described [above](#how-to-connect-migration-tooling-to-your-app) will make your Orleans application perform a runtime-migration of data. Every time grain state is being written or read from the persistent storage, it will decide to do it against both source and destination storage or a single one depending on the mode.

Choose an appropriate mode carefully - it controls the behavior and how dependent application behavior is on the source storage (or on the destination storage). Here are possible `Orleans.Persistence.Migration.GrainMigrationMode` values you can choose:

- `Disabled` goes through the migration components, but only communicates with the source storage. You will not see migrated data in destination storage if using such a mode.
- `ReadSource_WriteBoth` will replicate data to destination storage, but reads will be done only from the source storage. It is the safest option to actually perform migration, but still be sure application behavior remains robust.
- `ReadDestinationWithFallback_WriteBoth` is similar to previous one, but read will be done from destination storage firstly, and then in case data is not found will fallback to reading from source storage. Should be used for later stages of the migration
- `ReadDestinationWithFallback_WriteDestination` is a mode which will not write grain states into the source storage. If you are running in this mode without problems, then you are ready to migrate to Orleans7.x+ app
- `ReadWriteDestination` is a mode to only use destination storage.

Reminders follows the similar pattern but using `Orleans.Persistence.AzureStorage.Migration.Reminders.ReminderMigrationMode`.

### Offline Migration

However, not all of the grains are expected to be updated during the runtime of Orleans application. Offline migration helps in such a case by providing a way to run a background work in migrating the data.

Offline migration capabilities is added via another registration: `AddDataMigrator(source, destination)`. That registers `DataMigrator`, which you can resolve and invoke explicitly, or choose an appropriate option to configure it as a background worker.

`DataMigrator` does loop through all the grains or reminders in the source storage, and performs a write of the same data in the destination storage in Orleans7x+ format.

`DataMigrator` only works on a single (primary) silo (eliminating conflicts accross different nodes), has an option to control operations per second. View `Orleans.Persistence.Migration.DataMigratorOptions` for details.

### Notes

At the moment of writing this guideline migration tooling is in active development phase and is already available in preview. If you encounter any issues please submit a [new issue](https://github.com/dotnet/orleans/issues/new) and hopefully we will help you migrate to the latest Orleans
