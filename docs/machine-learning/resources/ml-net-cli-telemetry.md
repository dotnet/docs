---
title: ML.NET CLI telemetry
description: Discover the ML.NET CLI telemetry features that collect usage information for analysis, which data is collected and how to disable it.
ms.date: 04/16/2019
ms.custom: ""
---


# ML.NET CLI telemetry

> [!NOTE]
> This topic refers to ML.NET CLI and ML.NET AutoML, which are currently in Preview, and material may be subject to change. 

The [ML.NET CLI](http://aka.ms/mlnet-cli) includes a feature that collects usage information. It's important that the ML.NET CLI team understands how the tools are used so they can be improved. 

The collected data is anonymous and published in an aggregated form for use by Microsoft in order to improve the tool.

## Scope

The `dotnet ml` global tool is used to launch the ML.NET CLI. The `dotnet ml` command itself doesn't collect telemetry. The commands run by the `dotnet ml` command collect the telemetry (for instance, the command `auto-train`).

Telemetry *isn't enabled* when using the `dotnet ml` command itself, with no command attached:

- `mlnet`
- `mlnet --help`

Telemetry *is enabled* when using an [ML.NET CLI command](http://aka.ms/mlnet-cli-reference), such as:

- `mlnet auto-train`


## How to opt out

The ML.NET CLI telemetry feature is enabled by default. Opt out of the telemetry feature by setting the `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1` or `true`.

This setting environment variable also applies to the whole .NET CLI tool.

## Data points

The feature collects the following data:

- Command invoked (for example, "auto-train").
- Hashed MAC address: a cryptographically (SHA256) anonymous and unique ID for a machine.
- Timestamp of invocation.
- Three octet IP address only used to determine geographical location.
- Name of all arguments/parameters used (Not user's values such as arbitrary strings).
- Operating system and version.
- Value of --ml-task parameter (Categorical value such as `regression`, `binary-classification` and `multiclass-classification`).
- Hashed dataset file size.
- `ExitCode` of the command.


The feature doesn't collect personal data, such as usernames, dataset filenames or data from dataset files. The data is sent securely to Microsoft servers using [Microsoft Azure Application Insights](https://azure.microsoft.com/services/application-insights/) technology, held under restricted access, and used under strict security controls from secure [Azure Storage](https://azure.microsoft.com/services/storage/) systems.

The ML.NET CLI team wants to know how the tools are used and if they're working well. If you suspect that the telemetry is collecting sensitive data or that the data is being insecurely or inappropriately handled, file an issue in the [ML.NET](https://github.com/dotnet/machinelearning) repository for investigation.

## GDPR and ML.NET CLI

The ML.NET CLI takes privacy very seriously being compliant with General Data Protection Regulation (GDPR). That's both for Microsoft as a company and specifically within the ML.NET CLI team.

The ML.NET CLI does collect telemetry data which we use to help understand how to improve the product. For example, if users don’t use a particular ML task very often compared to other task we’ll need to research why and prioritize features. Our telemetry can also help debug issues like crashes and improve the quality. While we appreciate this insight, we also know that not everyone wants to send this data, so we offer the ability to disable telemetry.

In compliance with GDPR, features supported include:

- Making it easy to opt-out of telemetry collection by letting the user know the ability to disable this feature by placing a notification message when using the CLI tool *(TBD if when installing the Global Tool package or in the first usage or both: Comparable to dotnet command, opt-out changing an env-var like dotnet CLI)*.

- Reviewing and classifying the telemetry that we send.
Ensuring that we have valid data retention policies in place for any data we do collect, for example crash dumps.

In short, we are working hard to do the right thing, for all users, as these practices apply to all geographies, not just Europe (GDPR).

In conclusion, we expect our approach to evolve as we learn from the expectations of our users. We greatly appreciate the data users do send to us, as it is very valuable to improve the ML.NET CLI. And again, if you are worried about privacy, we offer the ability to disable sending telemetry as previously described in this document.

## License

The Microsoft distribution of ML.NET CLI is licensed with the [MICROSOFT .NET LIBRARY EULA](https://aka.ms/dotnet-core-eula). 

> 6. DATA.

> a. Data Collection. The software may collect information about you and your use of the software and send that to Microsoft. Microsoft may use this information to provide services and improve Microsoft’s products and services. Your opt-out rights, if any, are described in the product documentation. Some features in the software may enable collection of data from users of your applications that access or use the software. If you use these features to enable data collection in your applications, you must comply with applicable law, including getting any required user consent, and maintain a prominent privacy policy that accurately informs users about how you use, collect, and share their data. You can learn more about Microsoft’s data collection and use in the product documentation and the Microsoft Privacy Statement at https://go.microsoft.com/fwlink/?LinkId=512132. You agree to comply with all applicable provisions of the Microsoft Privacy Statement.

> b. Processing of Personal Data. To the extent Microsoft is a processor or subprocessor of personal data in connection with the software, Microsoft makes the commitments in the European Union General Data Protection Regulation Terms of the Online Services Terms to all customers effective May 25, 2018, at http://go.microsoft.com/?linkid=9840733.


## Disclosure

The ML.NET CLI tool displays the following text when you first run one of the [ML.NET CLI commands](index.md) (for example, `dotnet ml auto-train`). Text may vary slightly depending on the version of the CLI you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
> dotnet ml auto-train

Welcome to the ML.NET CLI!
--------------------------
Learn more about ML.NET CLI: https://aka.ms/mlnet-cli
Use 'mlnet --help' to see available commands or visit: https://aka.ms/mlnet-cli-docs

Telemetry
---------
The ML.NET CLI tool collect usage data in order to help us improve your experience.
The data is anonymous and doesn't include personal information or data from your datasets.
You can opt-out of telemetry by setting the DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about ML.NET CLI Tool telemetry: https://aka.ms/mlnet-cli-telemetry

...
```


