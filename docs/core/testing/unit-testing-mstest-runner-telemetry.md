# Telemetry

MSTest Runner collects telemetry data, which is used to help understand how to improve the product. For example, this usage data helps to debug issues, such as slow start-up times, and to prioritize new features. While we appreciate the insights this data provides, we also know that not everyone wants to send usage data and you can [disable telemetry](#disable-telemetry-reporting) as described in disable telemetry reporting. You can also read our [privacy statement](https://go.microsoft.com/fwlink/?LinkID=528096&clcid=0x409) to learn more.

## Types of telemetry data

MSTest Runner collects only telemetry of type **Usage Data**. These data are used to understand how features are used and where time is spent when executing the test application. This is helping us to prioritize product improvements.

## Disable telemetry reporting

You can fully disable telemetry by setting `TESTINGPLATFORM_TELEMETRY_OPTOUT` or `DOTNET_CLI_TELEMETRY_OPTOUT` environment variable to `1`.

## Disclosure

Test Anywhere displays text similar to the following when you first run your executable. Text may vary slightly depending on the version MSTest Runner you are running. This "first run" experience is how Microsoft notifies you about data collection.

```console
Telemetry
---------
MSTest Runner collects usage data in order to help us improve your experience.
The data is collected by Microsoft and are not shared.
You can opt-out of telemetry by setting the TESTINGPLATFORM_TELEMETRY_OPTOUT
or DOTNET_CLI_TELEMETRY_OPTOUT environment variable to '1' or 'true' using your favorite shell.

Read more about MSTest Runner telemetry: https://aka.ms/testingplatform-telemetry
```

## Data points

The telemetry feature doesn't collect personal data, such as usernames or email addresses. It doesn't scan your code and doesn't extract project-level data, such as repository, or author, **it extracts the name of your executable and sends it in hashed form.**

It doesn't extract the contents of any data files accessed or created by your apps, dumps of any memory occupied by your apps' objects, or the contents of the clipboard.

The data is sent securely to Microsoft servers using Azure Monitor technology, held under restricted access, and published under strict security controls from secure Azure Storage systems.

Protecting your privacy is important to us. If you suspect the telemetry is collecting sensitive data or the data is being insecurely or inappropriately handled, file an issue in the [microsoft/testfx](https://github.com/microsoft/testfx) or send an email to [dotnet@microsoft.com](mailto:dotnet@microsoft.com) for investigation.

The telemetry feature collects the following data:

---
| Version | Data|
|-|-|
| All | Timestamp of invocation, timestamp of start and end of various steps in the execution. |
| All | Three octet IP address used to determine the geographical location. |
| All | Operating system, version and architecture. |
| All | Process architecture. |
| All | Runtime ID (RID). |
| All | .NET Runtime version. |
| All | Name of your executable (which is usually the same as the name of the project), **hashed**. |
| All | DisplayName of the extensions you are using, **hashed**. |
| All | Version of your extensions. |
| All | Name of the test framework you are using, **hashed**. |
| All | Version of your test adapter. |
| All | Version of the platform. |
| All | Application mode, such as 'server'. |
| All | If the application is running as NativeAOT. |
| All | If Hot reload is enabled.  |
| All | If the repository is our own repository. Based on telemetry:isDevelopmentRepository setting in testingplatformconfig.json. |
| All | The exit code of the application. |
| All | If the application crashed. |
| All | If debug build of platform is used. |
| All | If debugger was attached to the process. |
| All | If filter of tests was used. |
| All | Count of tests that ran. |
| All | Count of tests that passed. |
| All | Count of tests that failed. |
| All | Count of test retries that passed. |
| All | Count of test retries that failed. |

## Continuous Integration Detection

In order to detect if the .NET CLI is running in a Continuous Integration environment, the .NET CLI probes for the presence and values of several well-known environment variables that common CI providers set.

The full list of environment variables, and what is done with their values, is shown below.  Note that in every case, the value of the environment variable is never collected, only used to set a boolean flag.

| Variable(s) | Provider | Action |
| ----------- | -------- | ------ |
| TF_BUILD    | Azure Pipelines | Parse boolean value |
| GITHUB_ACTIONS | GitHub Actions | Parse boolean value |
| APPVEYOR | Appveyor | Parse boolean value |
| CI | Many/Most | Parse boolean value |
| TRAVIS | Travis CI | Parse boolean value |
| CIRCLECI | Circle CI | Parse boolean value |
| CODEBUILD_BUILD_ID, AWS_REGION | Amazon Web Services CodeBuild | Check if all are present and non-null |
| BUILD_ID, BUILD_URL | Jenkins | Check if all are present and non-null |
| BUILD_ID, PROJECT_ID | Google Cloud Build | Check if all are present and non-null |
| TEAMCITY_VERSION | TeamCity | Check if present and non-null |
| JB_SPACE_API_URL | JetBrains Space | Check if present and non-null |
