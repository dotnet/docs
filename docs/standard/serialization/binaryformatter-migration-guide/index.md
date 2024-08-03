---
title: "BinaryFormatter migration guide"
description: "This guide covers the deprecation and removal of BinaryFormatter from .NET and recommends migration paths."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# BinaryFormatter migration guide

Any deserializer, binary or text, that allows its input to carry information about the objects to be created is a security problem waiting to happen. There is a common weakness enumeration (CWE) that describes the issue: [CWE-502 “Deserialization of Untrusted Data”](https://cwe.mitre.org/data/definitions/502.html). BinaryFormatter, included in the the initial release of .NET Framework in 2002, is such a deserializer.

Due to the known risks of using BinaryFormatter, the functionality was excluded from .NET Core 1.0. But without a clear migration path to using something safer, customer demand led to BinaryFormatter being included in .NET Core 1.1. Since then, the .NET team has been on the path to removing BinaryFormatter, slowly turning it off by default in multiple project types but letting consumers opt-in via flags if still needed for backward compatibility. .NET 9 sees the culmination of this effort with the removal of BinaryFormatter. In .NET 9, the backwards compatibility flags no longer exist and the in-box implementation of BinaryFormatter throws exceptions in any project type when you try to use it.

For more details about the decision, see the [BinaryFormatter is being removed in .NET 9](https://github.com/dotnet/announcements/issues/293) announcement. If you want to share feedback, leave a comment in [the discussion issue](https://github.com/dotnet/runtime/issues/98245).

## Migration topics

### Choose a serializer

The first step of migrating from `BinaryFormatter` is to [choose a serializer](./choose-a-serializer.md) to use in its place. Depending on your specific needs, the .NET team recommends migrations to four different serializers.

* [Migrate to System.Text.Json](./migrate-to-system-text-json.md)
* [Migrate to DataContractSerializer](./migrate-to-datacontractserializer.md)
* [Migrate to MessagePack](./migrate-to-messagepack.md)
* [Migrate to protobuf-net](./migrate-to-protobuf-net.md)

### Read BinaryFormatter (NRBF) payloads

Many applications load and deserialize payloads that have been persisted to storage and it's not always possible to transform all persisted payloads upfront. Other scenarios may involve systems or services that receive data produced by BinaryFormatter, where these systems need to be migrated independently.

In these scenarios and others, it becomes necessary to retain support for reading the supplied payloads and transition to a new format over time. To meet these needs, it is now possible to securely [read NRBF payloads](./read-nrbf-payloads.md) created with `BinaryFormatter` without performing general-purpose and vulnerable deserialization.

### Migration Windows Forms and WPF Applications

Windows Forms and WPF applications might require additional changes. See [WinForms applications](./winforms-applications.md) and [WinForms/WPF clipboard and drag/drop guidance](./winforms-wpf-ole-guidance.md) for further guidance.

### Using the compatibility package

For scenarios where a migration away from BinaryFormatter cannot be accomplished, an **unsupported** compatibility package is available. The [System.Runtime.Serialization.Formatters](https://www.nuget.org/packages/System.Runtime.Serialization.Formatters) NuGet package contains the functioning implementation of BinaryFormatter, including its vulnerabilities and risks.

While **unsupported and not recommended**, the guide for [using the compatibility package](./compatibility-package.md) includes the details for installing the package and enabling the functionality.
