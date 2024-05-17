---
title: Microsoft.Testing.Platform telemetry
description: Learn about the telemetry data collected by Microsoft.Testing.Platform and how to disable it.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
ms.custom: 
---

# Microsoft.Testing.Platform telemetry

`Microsoft.Testing.Platform` collects telemetry data, which is used to help understand how to improve the product. For example, this usage data helps to debug issues, such as slow start-up times, and to prioritize new features. While these insights are appreciated, you're free to [disable telemetry](#disable-telemetry-reporting). For more information on telemetry, see [privacy statement](https://go.microsoft.com/fwlink/?LinkID=528096&clcid=0x409).

## Types of telemetry data

`Microsoft.Testing.Platform` only collects telemetry of type **Usage Data**. The usage data is used to understand how features are consumed and where time is spent when executing the test app. This helps prioritize product improvements.

## Disable telemetry reporting

To disable telemetry, set either `TESTINGPLATFORM_TELEMETRY_OPTOUT` or `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1`.

## Disclosure

`Microsoft.Testing.Platform` displays text similar to the following when you first run your executable. The output text might vary slightly depending on the version `Microsoft.Testing.Platform` you're running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Telemetry
---------
Microsoft.Testing.Platform collects usage data in order to help us improve your experience.
The data is collected by Microsoft and are not shared.
You can opt-out of telemetry by setting the TESTINGPLATFORM_TELEMETRY_OPTOUT
or DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about Microsoft.Testing.Platform telemetry: https://aka.ms/testingplatform-telemetry
```

## Data points

The telemetry feature doesn't collect personal data, such as usernames or email addresses. It doesn't scan your code and doesn't extract project-level data, such as repository, or author, it extracts the name of your executable and sends it in hashed form.

It doesn't extract the contents of any data files accessed or created by your apps, dumps of any memory occupied by your apps' objects, or the contents of the clipboard.

The data is sent securely to Microsoft servers using Azure Monitor technology, held under restricted access, and published under strict security controls from secure Azure Storage systems.

Protecting your privacy is important to Microsoft! If you suspect the telemetry is collecting sensitive data or the data is being insecurely or inappropriately handled, file an issue in the [microsoft/testfx](https://github.com/microsoft/testfx) GitHub repository or send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

The telemetry feature collects the following data points:

| Version | Data |
|--|--|
| All | .NET Runtime version. |
| All | Application mode, such as 'server'. |
| All | Count of test retries that failed. |
| All | Count of test retries that passed. |
| All | Count of tests that failed. |
| All | Count of tests that passed. |
| All | Count of tests that ran. |
| All | The `DisplayName` of the extensions you're using, as a hashed value. |
| All | If debug build of platform is used. |
| All | If debugger was attached to the process. |
| All | If filter of tests was used. |
| All | If Hot reload is enabled. |
| All | If the application crashed. |
| All | If the application is running as NativeAOT. |
| All | If the repository is our own repository. Based on the `telemetry:isDevelopmentRepository` setting in _testingplatformconfig.json_. |
| All | Name of the test framework you're using, as a hashed value. |
| All | Name of your executable (which is usually the same as the name of the project), as a hashed value. |
| All | Operating system, version and architecture. |
| All | Process architecture. |
| All | Runtime ID (RID). For more information, see [.NET RID Catalog](../rid-catalog.md). |
| All | The exit code of the application. |
| All | Three octet IP address used to determine the geographical location. |
| All | Timestamp of invocation, timestamp of start and end of various steps in the execution. |
| All | Version of the platform. |
| All | Version of your extensions. |
| All | Version of your test adapter. |
| All | Guid to correlate events from a single runner. |
| 1.0.3 | Guid to correlate events from a single test run. |

## Continuous integration detection

In order to detect if the .NET CLI is running in a continuous integration environment, the .NET CLI probes for the presence and values of several well-known environment variables that common CI providers set.

The full list of environment variables, and what is done with their values, is detailed in the following table:

| Environment variable(s) | Provider | Action |
|--|--|--|
| `APPVEYOR` | Appveyor | Parse boolean value. |
| `BUILD_ID`, `BUILD_URL` | Jenkins | Check if all are present and non-null. |
| `BUILD_ID`, `PROJECT_ID` | Google Cloud Build | Check if all are present and non-null. |
| `CI` | Many/Most | Parse boolean value. |
| `CIRCLECI` | Circle CI | Parse boolean value. |
| `CODEBUILD_BUILD_ID`, `AWS_REGION` | Amazon Web Services CodeBuild | Check if all are present and non-null. |
| `GITHUB_ACTIONS` | GitHub Actions | Parse boolean value. |
| `JB_SPACE_API_URL` | JetBrains Space | Check if present and non-null. |
| `TEAMCITY_VERSION` | TeamCity | Check if present and non-null. |
| `TF_BUILD` | Azure Pipelines | Parse boolean value. |
| `TRAVIS` | Travis CI | Parse boolean value. |
