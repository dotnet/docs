---
title: Telemetry collection by ML.NET CLI
description: Learn about ML.NET CLI telemetry features that collect usage information for analysis, which data is collected, and how to disable it. Also, find links to the .NET license agreement and information about Microsoft GDPR compliance.
ms.topic: conceptual
ms.date: 05/05/2019
ms.custom: ""
---

# Telemetry collection by the ML.NET CLI

The [ML.NET CLI](https://aka.ms/mlnet-cli) includes a telemetry feature that collects anonymous usage data that is aggregated for use by Microsoft.

## How Microsoft uses the data

The product team uses ML.NET CLI telemetry data to help understand how to improve the tools. For example, if customers infrequently use a particular machine learning task, the product team investigates why and uses findings to prioritize feature development. ML.NET CLI telemetry also helps with debugging of issues such as crashes and code anomalies. 

While the product team appreciates this insight, we also know that not everyone wants to send this data. [Find out how to disable telemetry.](#opt-out-of-data-collection)

## Scope

The `mlnet` command launches the ML.NET CLI, but the command itself doesn't collect telemetry.

Telemetry *isn't enabled* when you run the `mlnet` command with no other command attached. For example:

- `mlnet`
- `mlnet --help`

Telemetry *is enabled* when you run an [ML.NET CLI command](../reference/ml-net-cli-reference.md), such as `mlnet auto-train`.

## Opt out of data collection

The ML.NET CLI telemetry feature is enabled by default.

Opt out of the telemetry feature by setting the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1` or `true`. This environment variable applies globally to the .NET CLI tool.

## Data points collected

The feature collects the following data:

- What command was invoked, such as `auto-train`
- Command-line parameter names used (i.e. "dataset-name, label-column-name, ml-task, output-path, max-exploration-time, verbosity")
- Hashed MAC address: a cryptographically (SHA256) anonymous and unique ID for a machine
- Timestamp of an invocation
- Three octet IP address (not full IP address) used only to determine geographical location
- Name of all arguments/parameters used. Not the customer's values, such as strings
- Hashed dataset filename
- Dataset file-size bucket
- Operating system and version
- Value of --task parameter: Categorical values, such as `regression`, `binary-classification`, and `multiclass-classification`
- ML.NET CLI version (i.e. 0.3.27703.4)

The data is sent securely to Microsoft servers using [Azure Application Insights](https://azure.microsoft.com/services/application-insights/) technology, held under restricted access, and used under strict security controls from secure [Azure Storage](https://azure.microsoft.com/services/storage/) systems.

### Data points not collected
The telemetry feature *doesn't* collect:
- personal data, such as usernames
- dataset filenames
- data from dataset files

If you suspect that the ML.NET CLI telemetry is collecting sensitive data or that the data is being insecurely or inappropriately handled, file an issue in the [ML.NET](https://github.com/dotnet/machinelearning) repository for investigation.

## License

The Microsoft distribution of ML.NET CLI is licensed with the [Microsoft Software License Terms: Microsoft .NET Library](https://aka.ms/dotnet-core-eula). For details on data collection and processing, see the section entitled "Data."

## Disclosure

When you first run a [ML.NET CLI command](../reference/ml-net-cli-reference.md) such as `mlnet auto-train`, the ML.NET CLI tool displays disclosure text that tells you how to opt out of telemetry. Text may vary slightly depending on the version of the CLI you're running.

## See also
- [ML.NET CLI reference](../reference/ml-net-cli-reference.md)
- [Microsoft Software License Terms: Microsoft .NET Library](https://aka.ms/dotnet-core-eula)
- [Privacy at Microsoft](https://www.microsoft.com/trustcenter/privacy/)
- [Microsoft Privacy Statement](https://privacy.microsoft.com/privacystatement)
