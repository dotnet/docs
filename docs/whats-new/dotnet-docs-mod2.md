---
title: ".NET docs: What's new for August 2024"
description: "What's new in the .NET docs for August 2024."
ms.custom: August-2024
ms.date: 09/01/2024
---

# .NET docs: What's new for August 2024

Welcome to what's new in the .NET docs for August 2024. This article lists some of the major changes to docs during this period.

## .NET breaking changes

### New articles

- [.NET 9 container images no longer install zlib](../core/compatibility/containers/9.0/no-zlib.md)
- [BigInteger maximum length](../core/compatibility/core-libraries/9.0/biginteger-limit.md)
- [Complex.ToString format changed to `<a; b>`](../core/compatibility/core-libraries/8.0/complex-format.md)
- [Deprecated desktop Windows/macOS/Linux MonoVM runtime packages](../core/compatibility/deployment/9.0/monovm-packages.md)
- [HostBuilder enables ValidateOnBuild/ValidateScopes in development environment](../core/compatibility/aspnet-core/9.0/hostbuilder-validation.md)
- [In-box BinaryFormatter implementation removed and always throws](../core/compatibility/serialization/9.0/binaryformatter-removal.md)
- [SafeEvpPKeyHandle.DuplicateHandle up-refs the handle](../core/compatibility/cryptography/9.0/evp-pkey-handle.md)
- [Some X509Certificate2 and X509Certificate constructors are obsolete](../core/compatibility/cryptography/9.0/x509-certificates.md)

## .NET fundamentals

### New articles

- [.NET Runtime metrics](../core/diagnostics/built-in-metrics-runtime.md)
- [.NET SDK workload sets](../core/tools/dotnet-workload-sets.md)
- [.NET uninstall tool overview](../core/additional-tools/uninstall-tool-overview.md)
- [BinaryFormatter compatibility package](../standard/serialization/binaryformatter-migration-guide/compatibility-package.md)
- [BinaryFormatter functionality reference](../standard/serialization/binaryformatter-migration-guide/functionality-reference.md)
- [BinaryFormatter migration guide](../standard/serialization/binaryformatter-migration-guide/index.md)
- [Choose a serializer](../standard/serialization/binaryformatter-migration-guide/choose-a-serializer.md)
- [dotnet workload config](../core/tools/dotnet-workload-config.md)
- [dotnet-core-uninstall dry-run](../core/additional-tools/uninstall-tool-cli-dry-run.md)
- [dotnet-core-uninstall list](../core/additional-tools/uninstall-tool-cli-list.md)
- [dotnet-core-uninstall remove](../core/additional-tools/uninstall-tool-cli-remove.md)
- [Dynamic adaptation to application sizes (DATAS)](../standard/garbage-collection/datas.md)
- [Example: Use OpenTelemetry with Azure Monitor and Application Insights](../core/diagnostics/observability-applicationinsights.md)
- [Example: Use OpenTelemetry with OTLP and the standalone Aspire Dashboard](../core/diagnostics/observability-otlp-example.md)
- [Example: Use OpenTelemetry with Prometheus, Grafana, and Jaeger](../core/diagnostics/observability-prgrja-example.md)
- [IL2071: 'target generic parameter' generic argument does not satisfy 'DynamicallyAccessedMembersAttribute' in 'target method or type'. The parameter 'source parameter' of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2071.md)
- [IL2076: 'target generic parameter' generic argument does not satisfy 'DynamicallyAccessedMembersAttribute' in 'target method or type'. The return value of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2076.md)
- [IL2081: 'target generic parameter' generic argument does not satisfy 'DynamicallyAccessedMembersAttribute' in 'target method or type'. The field 'source field' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2081.md)
- [IL2122: Type 'type' is not assembly qualified. Type name strings used for dynamically accessing a type should be assembly qualified](../core/deploying/trimming/trim-warnings/il2122.md)
- [Microsoft.Testing.Platform configuration settings](../core/testing/unit-testing-platform-config.md)
- [Migrate to DataContractSerializer (XML)](../standard/serialization/binaryformatter-migration-guide/migrate-to-datacontractserializer.md)
- [Migrate to MessagePack (binary)](../standard/serialization/binaryformatter-migration-guide/migrate-to-messagepack.md)
- [Migrate to protobuf-net (binary)](../standard/serialization/binaryformatter-migration-guide/migrate-to-protobuf-net.md)
- [Migrate to System.Text.Json (JSON)](../standard/serialization/binaryformatter-migration-guide/migrate-to-system-text-json.md)
- [MSTest suppression rules](../core/testing/mstest-analyzers/suppression-rules.md)
- [MSTEST0018: DynamicData should be valid](../core/testing/mstest-analyzers/mstest0018.md)
- [MSTEST0027: Non-nullable reference not initialized suppressor](../core/testing/mstest-analyzers/mstest0027.md)
- [MSTEST0028: Non-nullable reference not initialized suppressor](../core/testing/mstest-analyzers/mstest0028.md)
- [MSTEST0033: Non-nullable reference not initialized suppressor](../core/testing/mstest-analyzers/mstest0033.md)
- [MSTEST0034: Use `ClassCleanupBehavior.EndOfClass` with the `[ClassCleanup]`.](../core/testing/mstest-analyzers/mstest0034.md)
- [MSTEST0035: `[DeploymentItem]` can be specified only on test class or test method.](../core/testing/mstest-analyzers/mstest0035.md)
- [MSTEST0036: Do not use shadowing inside test class.](../core/testing/mstest-analyzers/mstest0036.md)
- [Output extensions](../core/testing/unit-testing-platform-extensions-output.md)
- [Read BinaryFormatter (NRBF) payloads](../standard/serialization/binaryformatter-migration-guide/read-nrbf-payloads.md)
- [SYSLIB0056: Assembly.LoadFrom that takes an AssemblyHashAlgorithm is obsolete](../fundamentals/syslib-diagnostics/syslib0056.md)
- [SYSLIB0057: X509Certificate2 and X509Certificate constructors for binary and file content are obsolete](../fundamentals/syslib-diagnostics/syslib0057.md)
- [Windows Forms and Windows Presentation Foundation BinaryFormatter OLE guidance](../standard/serialization/binaryformatter-migration-guide/winforms-wpf-ole-guidance.md)
- [Windows Forms migration guide for BinaryFormatter](../standard/serialization/binaryformatter-migration-guide/winforms-applications.md)
- [Windows Presentation Foundation(WPF) migration guide for BinaryFormatter](../standard/serialization/binaryformatter-migration-guide/wpf-applications.md)

### Updated articles

- [What's new in .NET libraries for .NET 9](../core/whats-new/dotnet-9/libraries.md) - Update What's new in .NET 9 for Preview 7
- [What's new in the .NET 9 runtime](../core/whats-new/dotnet-9/runtime.md) - Update What's new in .NET 9 for Preview 7

## C# language

### New articles

- [Errors and warnings related to `partial` type and `partial` member declarations](../csharp/language-reference/compiler-messages/partial-declarations.md)
- [Partial member (C# Reference)](../csharp/language-reference/keywords/partial-member.md)

## Azure SDK for .NET

### New articles

- [Credential chains in the Azure Identity library for .NET](../azure/sdk/authentication/credential-chains.md)
- [How to customize analysis with run config](../azure/migration/appcat/custom-configuration.md)

### Updated articles

- [Additional methods to authenticate to Azure resources from .NET apps](../azure/sdk/authentication/additional-methods.md) - Add Interactive brokered authentication and wam content

## ML.NET

### Updated articles

- [Tutorial: Automated visual inspection using transfer learning with the ML.NET Image Classification API](../machine-learning/tutorials/image-classification-api-transfer-learning.md) - Update image classification tutorial

## .NET Framework

### New articles

- [August 2024 security and quality rollup](../framework/release-notes/2024/08-13-august-security-and-quality-rollup.md)
- [July 2024 cumulative update preview](../framework/release-notes/2024/07-25-july-preview-cumulative-update.md)

### Updated articles

- [.NET Framework data providers](../framework/data/adonet/data-providers.md) - SFI - ROPC: Clean up adonet files
- [\<system.serviceModel> of workflow](../framework/configure-apps/file-schema/windows-workflow-foundation/system-servicemodel-of-workflow.md) - SFI - ROPC: First group of updates
- [Caching support for WCF web HTTP services](../framework/wcf/feature-details/caching-support-for-wcf-web-http-services.md) - SFI: ROPC - Fix up WCF docs
- [Code access security and ADO.NET](../framework/data/adonet/code-access-security.md) - SFI - ROPC: Clean up adonet files
- [Code generation in LINQ to SQL](../framework/data/adonet/sql/linq/code-generation-in-linq-to-sql.md) - SFI - ROPC: Clean up adonet/sql files
- [Configuring Discovery in a Configuration File](../framework/wcf/feature-details/configuring-discovery-in-a-configuration-file.md) - Code fence entire element (WCF docs)
- [Configuring Services Using Configuration Files](../framework/wcf/configuring-services-using-configuration-files.md) - Code fence entire element (WCF docs)
- [Connection string syntax](../framework/data/adonet/connection-string-syntax.md) - SFI - ROPC: Clean up adonet files
- [Connection strings and configuration files](../framework/data/adonet/connection-strings-and-configuration-files.md) - SFI - ROPC: Clean up adonet files
- [Create a DataTable from a DataView](../framework/data/adonet/dataset-datatable-dataview/creating-a-datatable-from-a-dataview.md) - SFI - ROPC: Clean up adonet files
- [Data retrieval and CUD operations in n-tier applications (LINQ to SQL)](../framework/data/adonet/sql/linq/data-retrieval-and-cud-operations-in-n-tier-applications.md) - SFI - ROPC: Clean up adonet/sql files
- [Date and time data](../framework/data/adonet/sql/date-and-time-data.md) - SFI - ROPC: Clean up adonet/sql files
- [Enable multiple active result sets](../framework/data/adonet/sql/enabling-multiple-active-result-sets.md) - SFI - ROPC: Clean up adonet/sql files
- [GetSchema and Schema Collections](../framework/data/adonet/getschema-and-schema-collections.md) - SFI - ROPC: Clean up adonet files
- [How to: Create a Federated Client](../framework/wcf/feature-details/how-to-create-a-federated-client.md) - Code fence entire element (WCF docs)
- [How to: Deserialize instance data properties](../framework/windows-workflow-foundation/how-to-deserialize-instance-data-properties.md) - SFI - ROPC: First group of updates
- [How to: Use Transport Security and Message Credentials](../framework/wcf/feature-details/how-to-use-transport-security-and-message-credentials.md) - Code fence entire element (WCF docs)
- [Insert an image from a file](../framework/data/adonet/sql/inserting-an-image-from-a-file.md) - SFI - ROPC: Clean up adonet/sql files
- [Integrating with COM+ Applications Overview](../framework/wcf/feature-details/integrating-with-com-plus-applications-overview.md) - Code fence entire element (WCF docs)
- [Large UDTs](../framework/data/adonet/sql/large-udts.md) - SFI - ROPC: Clean up adonet/sql files
- [Manipulate data](../framework/data/adonet/sql/manipulating-data.md) - SFI - ROPC: Clean up adonet/sql files
- [Message Security with a Certificate Client](../framework/wcf/feature-details/message-security-with-a-certificate-client.md) - Code fence entire element (WCF docs)
- [Message Security with Mutual Certificates](../framework/wcf/feature-details/message-security-with-mutual-certificates.md) - SFI: ROPC - Fix up WCF docs
- [Obtaining a DbProviderFactory](../framework/data/adonet/obtaining-a-dbproviderfactory.md) - SFI - ROPC: Clean up adonet files
- [Oracle Sequences](../framework/data/adonet/oracle-sequences.md) - SFI - ROPC: Clean up adonet files
- [OracleTypes](../framework/data/adonet/oracletypes.md) - SFI - ROPC: Clean up adonet files
- [Partial Trust Feature Compatibility](../framework/wcf/feature-details/partial-trust-feature-compatibility.md) - Code fence entire element (WCF docs)
- [Pause and Resume a workflow](../framework/windows-workflow-foundation/pausing-and-resuming-a-workflow.md) - SFI - ROPC: First group of updates
- [Perform batch operations using DataAdapters](../framework/data/adonet/performing-batch-operations-using-dataadapters.md) - SFI - ROPC: Clean up adonet files
- [Polling in console applications](../framework/data/adonet/sql/polling-in-console-applications.md) - SFI - ROPC: Clean up adonet/sql files
- [Provider statistics for SQL Server](../framework/data/adonet/sql/provider-statistics-for-sql-server.md) - SFI - ROPC: Clean up adonet/sql files
- [Required arguments and overload groups](../framework/windows-workflow-foundation/required-arguments-and-overload-groups.md) - SFI - ROPC: First group of updates
- [Schema restrictions](../framework/data/adonet/schema-restrictions.md) - SFI - ROPC: Clean up adonet files
- [Security Behaviors in WCF](../framework/wcf/feature-details/security-behaviors-in-wcf.md) - SFI: ROPC - Fix up WCF docs
- [SecurityBindingElement Authentication Modes](../framework/wcf/feature-details/securitybindingelement-authentication-modes.md) - Code fence entire element (WCF docs)
- [Specify XML values as parameters](../framework/data/adonet/sql/specifying-xml-values-as-parameters.md) - SFI - ROPC: Clean up adonet/sql files
- [Specifying a Custom Crypto Algorithm](../framework/wcf/extending/specifying-a-custom-crypto-algorithm.md) - Code fence entire element (WCF docs)
- [SQL Server Connection Pooling (ADO.NET)](../framework/data/adonet/sql-server-connection-pooling.md) - SFI - ROPC: Clean up adonet files
- [SQL Server Express user instances](../framework/data/adonet/sql/sql-server-express-user-instances.md) - SFI - ROPC: Clean up adonet/sql files
- [SqlClient streaming support](../framework/data/adonet/sqlclient-streaming-support.md) - SFI - ROPC: Clean up adonet files
- [SqlClient Support for high availability and disaster recovery](../framework/data/adonet/sql/sqlclient-support-for-high-availability-disaster-recovery.md) - SFI - ROPC: Clean up adonet/sql files
- [Standard Endpoints](../framework/wcf/feature-details/standard-endpoints.md) - Code fence entire element (WCF docs)
- [Synchronous and Asynchronous Operations](../framework/wcf/synchronous-and-asynchronous-operations.md) - Code fence entire element (WCF docs)
- [System.Transactions integration with SQL Server](../framework/data/adonet/system-transactions-integration-with-sql-server.md) - SFI - ROPC: Clean up adonet files
- [Tracking Events Reference](../framework/windows-workflow-foundation/tracking-events-reference.md) - SFI - ROPC: First group of updates
- [Tracking Participants](../framework/windows-workflow-foundation/tracking-participants.md) - SFI - ROPC: First group of updates
- [Using the Message Class](../framework/wcf/feature-details/using-the-message-class.md) - Code fence entire element (WCF docs)
- [Windows applications using callbacks](../framework/data/adonet/sql/windows-applications-using-callbacks.md) - SFI - ROPC: Clean up adonet/sql files

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [BartoszKlonowski](https://github.com/BartoszKlonowski) - Bartosz Klonowski ![4 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-4-green)
- [samwherever](https://github.com/samwherever) - Sam Allen ![4 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-4-green)
- [Rageking8](https://github.com/Rageking8) -  ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [udidahan](https://github.com/udidahan) - Udi Dahan ![2 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-2-green)
- [8chan-co](https://github.com/8chan-co) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [alkampfergit](https://github.com/alkampfergit) - Gian Maria ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [baonguyen2310](https://github.com/baonguyen2310) - Bao Nguyen Chi ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [bigboybamo](https://github.com/bigboybamo) - Olabamiji Oyetubo ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [boggye](https://github.com/boggye) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [ChinoUkaegbu](https://github.com/ChinoUkaegbu) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [daverayment](https://github.com/daverayment) - Dave Rayment ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [dkroderos](https://github.com/dkroderos) - David King Roderos ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [GeRRy1337](https://github.com/GeRRy1337) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [jbrekle](https://github.com/jbrekle) - Jonas Brekle ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [Progman2002](https://github.com/Progman2002) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [rmunn](https://github.com/rmunn) - Robin Munn ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [samibinsami](https://github.com/samibinsami) - Saad Bin Sami ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [warrenZY](https://github.com/warrenZY) - Xiao.ZY ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [xtqqczze](https://github.com/xtqqczze) -  ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
- [YoshiRulz](https://github.com/YoshiRulz) - James Groom ![1 pull requests.](https://img.shields.io/badge/Merged%20Pull%20Requests-1-green)
