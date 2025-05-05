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

In runtime mode, Orleans reads and writes grain state during execution via [`Grain<TGrainState>.ReadStateAsync()`](https://learn.microsoft.com/dotnet/api/orleans.grain-1.readstateasync) and [`Grain<TGrainState>.WriteStateAsync()`](https://learn.microsoft.com/dotnet/api/orleans.grain-1.writestateasync). The migration tooling can intercept these calls to replicate data into the destination storage.

Reminder data is also stored differently in Orleans 7.x+, and its migration follows a similar pattern. Specific APIs for reminder migration will be covered later.

> [!NOTE]
> Migration does not require application downtime. It is designed to be run over an extended period—potentially hours, days, or weeks—depending on your system’s scale. A gradual rollout is recommended, with careful monitoring to avoid disruptions and validate the correctness of migrated state.

### Migration Steps

1. **Prepare destination storage** to hold migrated data.
2. **Register migration components** so Orleans knows which storage is the source and which is the destination.
3. **Wire up source/destination pairs** by registering `MigrationGrainStorage` or `MigrationReminderTable`, and select the appropriate migration mode.
4. **Run the application** for a prolonged period of time to ensure grains are accessed and migrated.
5. **Adjust migration mode** to reduce or eliminate dependency on source storage. Repeat as needed until you are ready to transition fully to Orleans 7.x+.

### Runtime Migration
_(To be continued...)_
