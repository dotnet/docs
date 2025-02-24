---
title: dotnet-monitor diagnostic tool - .NET
description: Learn how to install and use the dotnet-monitor tool to collect dumps, traces, logs, and metrics from applications in production environments.
ms.date: 06/16/2022
ms.topic: reference
---
# Diagnostic monitoring and collection utility (dotnet-monitor)

**This article applies to:** ✔️ `dotnet-monitor` version 6.0.0 and later versions

## Install

There are two ways to download `dotnet-monitor`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-monitor` [NuGet package](https://www.nuget.org/packages/dotnet-monitor), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-monitor
  ```

- **Docker image:**

  Download a Docker image for use in multi-container environments:

  ```console
  docker pull mcr.microsoft.com/dotnet/monitor
  ```

## Synopsis

```console
dotnet-monitor [-h|--help] [--version] <command>
```

## Description

The `dotnet-monitor` global tool is a way to monitor .NET applications in production environments and to collect diagnostic artifacts (for example, dumps, traces, logs, and metrics) on-demand or using automated rules for collecting under specified conditions.

## Options

- **`--version`**

  Displays the version of the dotnet-monitor utility.

- **`-h|--help`**

  Shows command-line help.

## Commands

| Command                                                   |
| --------------------------------------------------------- |
| [dotnet monitor collect](#dotnet-monitor-collect)         |
| [dotnet monitor config show](#dotnet-monitor-config-show) |
| [dotnet monitor generatekey](#dotnet-monitor-generatekey) |

## dotnet-monitor collect

Monitor .NET applications, allow collecting diagnostic artifacts, and send the results to a chosen destination.

### Synopsis

```console
dotnet-monitor collect [-h|--help] [-u|--urls] [-m|--metrics] [--metricUrls] [--diagnostic-port] [--no-auth] [--temp-apikey] [--no-http-egress]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-u|--urls <urls>`**

  Bindings for the HTTP api. Default is `https://localhost:52323`.

- **`-m|--metrics [true|false]`**

  Enable publishing of metrics to `/metrics` route. Default is `true`

- **`--metricUrls <urls>`**

  Bindings for the metrics HTTP api. Default is `http://localhost:52325`.

- **`--diagnostic-port <path>`**

  The fully qualified path and filename of the diagnostic port to which runtime instances can connect. Specifying this option places `dotnet-monitor` into
  'listen' mode. When not specified, `dotnet-monitor` is in 'connect' mode.
  
  On Windows, this must be a valid named pipe name.
  On Linux and macOS, this must be a valid Unix Domain Socket path.

- **`--no-auth`**

  Disables API key authentication. Default is `false`.

  It is strongly recommended that this option is not used in production environments.
  
- **`--temp-apikey`**

  Generates a temporary API key for the `dotnet-monitor` instance.

- **`--no-http-egress`**

  Disables egress of diagnostic artifacts via the HTTP response. When specified, artifacts must be egressed using an egress provider.

## dotnet-monitor config show

Shows configuration, as if `dotnet-monitor collect` was executed with these parameters.

### Synopsis

```console
dotnet-monitor config show [-h|--help] [-u|--urls] [-m|--metrics] [--metricUrls] [--diagnostic-port] [--no-auth] [--temp-apikey] [--no-http-egress] [--level] [--show-sources]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-u|--urls <urls>`**

  Bindings for the HTTP api. Default is `https://localhost:52323`.

  This value is mapped into configuration as the `urls` key.

- **`-m|--metrics [true|false]`**

  Enable publishing of metrics to `/metrics` route. Default is `true`.

  This value is mapped into configuration as the `Metrics:Enabled` key.

- **`--metricUrls <urls>`**

  Bindings for the metrics HTTP api. Default is `http://localhost:52325`.

  This value is mapped into configuration as the `Metrics:Endpoints` key.

- **`--diagnostic-port <path>`**

  The fully qualified path and filename of the diagnostic port to which runtime instances can connect. Specifying this option places `dotnet-monitor` into
  'listen' mode. When not specified, `dotnet-monitor` is in 'connect' mode.
  
  On Windows, this must be a valid named pipe name.
  On Linux and macOS, this must be a valid Unix Domain Socket path.

  This value is mapped into configuration as the `DiagnosticPort:EndpointName` key.

- **`--no-auth`**

  Disables API key authentication. Default is `false`.

  It is strongly recommended that this option is not used in production environments.

  This value is not mapped into configuration.
  
- **`--temp-apikey`**

  Generates a temporary API key for the `dotnet-monitor` instance.

  This value is mapped into configuration as the `Authentication:MonitorApiKey` key.

- **`--no-http-egress`**

  Disables egress of diagnostic artifacts via the HTTP response. When specified, artifacts must be egressed using an egress provider.

  This value is not mapped into configuration.

- **`--level`**

  Configuration level. `Full` configuration can show sensitive information. There are two levels:

  - `Full` - The full configuration without any redaction of any values.
  - `Redacted` - The full configuration but sensitive information, such as known secrets, is redacted.

- **`--show-sources`**

  Identifies from which configuration source each effective configuration value is provided.

## dotnet-monitor generatekey

 Generate an API key and hash for HTTP authentication.
 
### Synopsis

```console
dotnet-monitor generatekey [-h|--help] [-o|--output] [-e|--expiration]
```

### Options

- **`-h|--help`**

  Shows command-line help.

- **`-o|--output <Cmd|Json|MachineJson|PowerShell|Shell|Text>`**

  The output format in which the API key information is written to standard output.

  The allowable values are:
  - `Cmd` - Outputs in a format usable in Windows Command Prompt or batch files.
  - `Json` - Outputs in a format of a JSON object.
  - `MachineJson` - Outputs in a format of a JSON object without comments and explanation. Useful for automation scenarios.
  - `PowerShell` - Outputs in a format usable in PowerShell prompts and scripts.
  - `Shell` - Outputs in a format usable in Linux shells such as Bash.
  - `Text` - Outputs in a format that is plain text.

- **`-e|--expiration <expiration>`**

  The expiration time after which the generated API key will no longer be accepted. The value must be in TimeSpan format (e.g., "7.00:00:00" for 7 days). Default: "7.00:00:00" (7 days).

## See Also

- [dotnet/dotnet-monitor](https://github.com/dotnet/dotnet-monitor/tree/main/documentation)
