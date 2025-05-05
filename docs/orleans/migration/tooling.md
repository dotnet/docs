# Migration Tooling

> [!NOTE]
> If your app is already running on Orleans 7.0 or later (referred to as 7.x+ throughout), you don't need to use this tooling.

[Migrate from Orleans 3.x to 7.0](./guide.md) outlines key changes introduced in Orleans 7.x+ and how to migrate from 3.x. One of the most significant breaking changes is in [serialization](./guide.md#serialization) and [grain identity representation](./guide.md#grain-identities). Migration tooling provides advanced APIs to help convert data to the Orleans 7.x+ format.

This guide explains how to use the tooling. If you're running Orleans 3.x, this will help you migrate to 7.x+ and take advantage of its improvements.

**Prerequisites:**
- Orleans 3.x app
- .NET 6.0 or higher

## Data Store Differences

Orleans 7.x+ introduces a new grain identity format that changes how grain-related data is stored—for example, in Azure Table Storage. The tables below compare the same reminder entry across Orleans 3.x and Orleans 7.x+ taken out from the underlying Azure Table Storage.

| Version          | PartitionKey                                 | GrainReference                                                                                                   |
| -------------    | ------------------------------------------   | --------------------------------------------------------------- |
| **Orleans 3.x**  | 3787bc57a0a1459388a8a5ecb9dcd843_1C2B3D8D    | GrainReference=0000000000000000000000000000012f03fffffffcd9142b |
| **Orleans 7.x+** | 3787bc57a0a1459388a8a5ecb9dcd843_1C2B3D8D    | simplepersistent_12F                                            |

`GrainReference` is now a structured, human-readable string and this schema change **breaks** direct storage compatibility between Orleans 3.x and 7.x+.

## Migration Plan

Your Orleans 3.x application uses some persistent storage to save grains in Orleans 3.x format. It can be any - in example Azure Table Storage. Migration plan proposes to pre-create another storage where same grains will be saved in Orleans7.x+ compatible format. It can be of another type - in example not necesserally migration has to occur from Azure Table Storage to Azure Table Storage; it can be performed from Azure Table Storage to CosmosDb. Further in the article existing storage (3.x format) will be called "source storage", and storage for migrated data (7.x+ format) will be called "destination storage". 

Migration tooling provides 2 different types of migration: "runtime" and "offline". During the app runtime grain states are written into the storage every time [`Grain<TGrainState>.WriteStateAsync()`](https://learn.microsoft.com/dotnet/api/orleans.grain-1.writestateasync) is being invoked, and read from the storage every time [`Grain<TGrainState>.ReadStateAsync()`](https://learn.microsoft.com/dotnet/api/orleans.grain-1.readstateasync). Migration tooling can intercept communication with the storage and duplicate/replicate data in the destination storage.

Reminders are also stored differently in Orleans7.x+ compared to Orleans3.x, and their migration plan is similar to grain migration. Specific APIs will be discussed later.

> [!NOTE]
>  Migration does not require application downtimes and is recommended to be performed for some prolonged periods of time (it can be hours / days / weeks depending on the scale). It is also recommended to rollout step-by-step without making too drastical changes in the migration behavior and keeping a close eye on the application state to ensure no problems caused by migration.

The migration plan consists of several steps:
- Prepare a new storage for keeping migrated data.
- Register migration components. Orleans needs to be aware of what storages are "source" and "destination".
- Connect pairs of "source" and "destination" storages by registering `MigrationGrainStorage` or `MigrationReminderTable` and choosing a mode of grain/reminder migration. 
- Run application for _some_ time to ensure full grain set coverage and migration
- Change mode of migration to less dependent on the "source" storage. Repeat this and previous step until you are ready to run your Orleans7.x+ app.

### Runtime Migration

