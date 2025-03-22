---
title: Silo metadata
description: Learn about silo metadata in .NET Orleans.
ms.date: 01/08/2025
---

# Silo Metadata

Silo Metadata is a new feature in Orleans that allows developers to assign custom metadata to silos within a cluster. This metadata provides a flexible mechanism for annotating silos with descriptive information or specific capabilities.

This feature is particularly useful in scenarios where different silos have distinct roles, hardware configurations, or other unique characteristics. For example, silos can be tagged based on their region, compute power, or specialized responsibilities within the system.

Silo Metadata lays the groundwork for additional Orleans features, such as Placement Filtering.

## Key Concepts

Silo Metadata introduces a way to attach key-value pairs to silos within an Orleans cluster. This feature allows developers to configure silo-specific characteristics that can be leveraged by Orleans components.

Silo Metadata is represented as an **immutable** dictionary of key-value pairs:

- **Keys**: Strings that identify the metadata (e.g., `"cloud.region"`, `"compute.reservation.type"`).
- **Values**: Strings that describe the corresponding property (e.g., `"us-east1"`, `"spot"`).

## Configuration

Silo Metadata in Orleans can be configured using two methods: via .NET Configuration or directly in code.

### **Configuring Silo Metadata via .NET Configuration**

Silo Metadata can be defined in the application’s Configuration, such as `appsettings.json`, environment variables, or any other Configuration source.

#### Example: `appsettings.json` Configuration

```json
{
  "Orleans": {
    "Metadata": {
      "cloud.region": "us-east1",
      "compute.reservation.type": "spot",
      "role": "worker"
    }
  }
}
```

The above configuration defines metadata for a silo, tagging it with:

- `cloud.region`: `"us-east1"`
- `compute.reservation.type`: `"spot"`
- `role`: `"worker"`

To apply this configuration, use the following setup in your silo host builder:

```csharp
var siloBuilder = new SiloHostBuilder()
    // Configuration section Orleans:Metadata is used by default
    .UseSiloMetadata();
```

Alternatively, an explicit `IConfiguration` or `IConfigurationSection` can be passed in to control where in configuration the metadata is pulled from.

---

### **Configuring Silo Metadata Directly in Code**

For scenarios requiring programmatic metadata configuration, developers can add metadata directly in the silo host builder.

#### Example: Direct Code Configuration

```csharp
var siloBuilder = new SiloHostBuilder()
    .UseSiloMetadata(new Dictionary<string, string>
        {
            {"cloud.region", "us-east1"},
            {"compute.reservation.type", "spot"},
            {"role", "worker"}
        });
```

This example achieves the same result as the JSON configuration but allows metadata values to be computed or loaded dynamically during silo initialization.

---

### **Merging Configurations**

If both .NET Configuration and direct code configuration are used, the direct configuration overrides any conflicting metadata values from the .NET Configuration. This allows developers to set defaults via configuration files and dynamically adjust specific metadata during runtime.

## Usage

Developers can retrieve metadata through the `ISiloMetadataCache` interface. This interface allows for querying metadata for individual silos across the cluster. Metadata will always be returned from a local cache of metadata that gets updated in the background as cluster membership changes.

### **Accessing Metadata for a Specific Silo**

The `ISiloMetadataCache` provides a method to retrieve the metadata for a specific silo by its unique identifier (`SiloAddress`). The `ISoloMetadataCache` implementation is registered in the `UseSiloMetadata` method and can be injected as a dependency.

#### Example: Accessing Metadata for a Silo

```csharp
var siloMetadata = siloMetadataCache.GetSiloMetadata(siloAddress);

if (siloMetadata.Metadata.TryGetValue("role", out var role))
{
    Console.WriteLine($"Silo Role for {siloAddress}: {role}");
    // Execute role-specific logic
}
```

In this example:

- `GetSiloMetadata(siloAddress)` retrieves the metadata for the specified silo.
- Metadata keys like `"role"` can be used to influence application logic.

---

## Internal Implementation

Internally, the `SiloMetadataCache` monitors changes in cluster membership on `MembershipTableManager` and will keep the local cache of metadata in sync with membership changes. Metadata is immutable for a given Silo so it will be retreived once and cached until that Silo leaves the cluster. Cached metadata for clusters that are `Dead` or have left the membership table will be cleared out of the local cache.

Each silo hosts an ISystemTarget that provides that silo's metadata. Calls to `SiloMetadataCache : ISiloMetadataCache` then return a result from this local cache.
