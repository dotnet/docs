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
ms.topic: upgrade-and-migration-article
---

# BinaryFormatter migration guide

> [!CAUTION]
> We strongly recommend against using BinaryFormatter due to the [associated security risks](#whats-the-risk-in-using-binaryformatter). Existing users [should migrate away from BinaryFormatter](#migration-topics).

Starting with .NET 9, we no longer include an implementation of BinaryFormatter in the runtime. The APIs are still present, but their implementation always throws a <xref:System.PlatformNotSupportedException>, regardless of project type. Hence, setting the existing backwards compatibility flag is no longer sufficient to use BinaryFormatter.

You have two options to address that:

* **Migrate away from BinaryFormatter**. We strongly recommend you to investigate options to stop using BinaryFormatter due to the associated [security risks](#whats-the-risk-in-using-binaryformatter). We list [several options](#migration-topics) below.

* **Keep using BinaryFormatter**. If you need to continue using BinaryFormatter in .NET 9, you need to depend on the [unsupported System.Runtime.Serialization.Formatters NuGet package](./compatibility-package.md), which replaces the throwing implementation.

## What's the risk in using BinaryFormatter?

Any deserializer, binary or text, that allows its input to carry information about the objects to be created is a security problem waiting to happen. There is a common weakness enumeration (CWE) that describes the issue: [CWE-502 "Deserialization of Untrusted Data"](https://cwe.mitre.org/data/definitions/502.html). BinaryFormatter, included in the the initial release of .NET Framework in 2002, is such a deserializer. We also cover this in the [BinaryFormater security guide](../binaryformatter-security-guide.md).

Due to the known risks of using BinaryFormatter, the functionality was excluded from .NET Core 1.0. But without a clear migration path to using something safer, customer demand led to BinaryFormatter being included in .NET Core 2.0. Since then, the .NET team has been on the path to removing BinaryFormatter, slowly turning it off by default in multiple project types but letting consumers opt-in via flags if still needed for backward compatibility.

For more details about the decision, see the [BinaryFormatter is being removed in .NET 9](https://github.com/dotnet/announcements/issues/293) announcement.

If you experience issues related to BinaryFormatter's removal not addressed in this migration guide, please file an issue at [github.com/dotnet/runtime](https://github.com/dotnet/runtime/issues) and indicate that the issue is related to the removal of BinaryFormatter.

## Migration topics

Migrating away from BinaryFormatter usually means [choosing a different serializer](#choose-a-serializer). However, that's usually only doable if you control both the producer and consumer of the encoded data. In case you don't control the producer, you can also move to our [new API for reading BinaryFormatter payloads](#read-binaryformatter-nrbf-payloads) without instantiating any of the encoded types.

Both options are explored below.

### Choose a serializer

The first step of migrating from `BinaryFormatter` is to [choose a serializer](./choose-a-serializer.md) to use in its place. Depending on your specific needs, the .NET team recommends migrations to four different serializers.

* [Migrate to System.Text.Json (JSON)](./migrate-to-system-text-json.md)
* [Migrate to DataContractSerializer (XML)](./migrate-to-datacontractserializer.md)
* [Migrate to MessagePack (binary)](./migrate-to-messagepack.md)
* [Migrate to protobuf-net (binary)](./migrate-to-protobuf-net.md)

### Read BinaryFormatter (NRBF) payloads

Many applications load and deserialize payloads that have been persisted to storage and it's not always possible to transform all persisted payloads upfront. Other scenarios may involve systems or services that receive data produced by BinaryFormatter, where these systems need to be migrated independently.

In these scenarios and others, it becomes necessary to retain support for reading the supplied payloads and transition to a new format over time. To meet these needs, it is now possible to securely [read NRBF payloads](./read-nrbf-payloads.md) created with `BinaryFormatter` without performing general-purpose and vulnerable deserialization.

### Migrate Windows Forms and WPF applications

Windows Forms and WPF applications might require additional changes. See [Windows Forms apps](./winforms-applications.md), [WPF apps](./wpf-applications.md), and [WinForms/WPF clipboard and drag-and-drop guidance](./winforms-wpf-ole-guidance.md) for further migration guidance.

### Migrate managed resources (ResX)

The most common resource types (such as strings and icons) will work without BinaryFormatter. For custom types, you need to bring in BinaryFormatter and enable a compatibility switch, see [Loading resource during runtime](./winforms-applications.md#loading-resource-during-runtime).

### Use the compatibility package

For scenarios where a migration away from BinaryFormatter cannot be accomplished at the time of upgrading to .NET 9, an unsupported compatibility package is available. The [System.Runtime.Serialization.Formatters](https://www.nuget.org/packages/System.Runtime.Serialization.Formatters) NuGet package contains the functioning implementation of BinaryFormatter, including its vulnerabilities and risks.

While **unsupported and not recommended**, the guide for [using the compatibility package](./compatibility-package.md) includes the details for installing the package and enabling the functionality.

> [!CAUTION]
> We strongly recommend against using BinaryFormatter due to the [associated security risks](#whats-the-risk-in-using-binaryformatter). Existing users [should migrate away from BinaryFormatter](#migration-topics).
