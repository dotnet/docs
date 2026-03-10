---
title: Tab completion for System.CommandLine
description: "How to enable and customize tab completion for apps built on the System.CommandLine library."
ms.date: 12/05/2025
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---

# Tab completion for System.CommandLine

Apps that use `System.CommandLine` have built-in support for tab completion in certain shells. To enable it, the end user must take a few steps once per shell. Once this is done, tab completion is automatic for static values in your app, such as enum values or values defined by calling <xref:System.CommandLine.Option`1.AcceptOnlyFromAmong(System.String[])>. You can also customize tab completion by providing values dynamically at runtime.

## Enable tab completion

On the machine where you (the end user) want to enable tab completion, follow these steps.

For the .NET CLI:

* See [How to enable tab completion](../../core/tools/enable-tab-autocomplete.md).

For other command-line apps built on `System.CommandLine`:

* Install the [`dotnet-suggest`](https://nuget.org/packages/dotnet-suggest) global tool:

  ```dotnetcli
  dotnet tool install -g dotnet-suggest
  ```

* Add the appropriate shim script to your shell profile. You might need to create a shell profile file. The shim script forwards completion requests from your shell to the `dotnet-suggest` tool, which delegates them to the appropriate `System.CommandLine`-based app.

  * For `bash`, add the contents of [*dotnet-suggest-shim.bash*](https://github.com/dotnet/command-line-api/blob/main/src/System.CommandLine.Suggest/dotnet-suggest-shim.bash) to *~/.bash_profile*.

  * For `zsh`, add the contents of [*dotnet-suggest-shim.zsh*](https://github.com/dotnet/command-line-api/blob/main/src/System.CommandLine.Suggest/dotnet-suggest-shim.zsh) to *~/.zshrc*.

  * For PowerShell, add the contents of [*dotnet-suggest-shim.ps1*](https://github.com/dotnet/command-line-api/blob/main/src/System.CommandLine.Suggest/dotnet-suggest-shim.ps1) to your PowerShell profile, and then restart PowerShell. You can find the expected path to your PowerShell profile with the following command:

    ```console
    echo $profile
    ```

* Register the app by calling  `dotnet-suggest register --command-path $executableFilePath`, where `$executableFilePath` is the path to the app's executable file.

Once the user's shell is set up and the executable is registered, completions will work for all apps that are built by using `System.CommandLine`.

For *cmd.exe* on Windows (the Windows Command Prompt), there is no pluggable tab completion mechanism, so no shim script is available. For other shells, [look for a GitHub issue that's labeled `Area-Completions`](https://github.com/dotnet/command-line-api/issues?q=is%3Aissue+is%3Aopen+label%3A%22Area-Completions%22). If you don't find an issue, you can [open a new one](https://github.com/dotnet/command-line-api/issues).

## Get tab completion values at runtime

The following code shows an app that retrieves values for tab completion dynamically at runtime. The code gets a list of the next week of dates following the current date. The list is provided to the `--date` option by calling `CompletionSources.Add`:

:::code language="csharp" source="snippets/tab-completion/csharp/Program.cs" id="all" :::

The values shown when the <kbd>Tab</kbd> key is pressed are provided as <xref:System.CommandLine.Completions.CompletionItem> instances:

:::code language="csharp" source="snippets/tab-completion/csharp/Program.cs" id="completionitem" :::

The following `CompletionItem` properties are set:

* <xref:System.CommandLine.Completions.CompletionItem.Label> is the completion value to be shown.
* <xref:System.CommandLine.Completions.CompletionItem.SortText> ensures that the values in the list are presented in the correct order. It's set by converting `i` to a two-digit string, so that sorting is based on 01, 02, 03, and so on, through 14. If you don't set this parameter, sorting is based on `Label`, which in this example is in short date format and won't sort correctly.

There are other `CompletionItem` properties, such as `Documentation` and `Detail`, but they aren't yet used in `System.CommandLine`.

The dynamic tab completion list created by this code also appears in help output:

```output
Description:
  Makes an appointment for sometime in the next week.

Usage:
  schedule <subject> [options]

Arguments:
  <subject>  The subject of the appointment.

Options:
  --date                                                                          The day of week to schedule. Should be within one week.
  <12/4/2025|12/5/2025|12/6/2025|12/7/2025|12/8/2025|12/9/2025|12/10/2025>
  --version                                                                       Show version information
  -?, -h, --help
```

## See also

* [System.CommandLine overview](index.md)
* [How to enable tab completion for the .NET CLI](../../core/tools/enable-tab-autocomplete.md)
