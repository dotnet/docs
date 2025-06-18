---
title: Tab completion for System.CommandLine
description: "How to enable and customize tab completion for apps built on the System.CommandLine library."
ms.date: 02/22/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---

# Tab completion for System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

Apps that use `System.CommandLine` have built-in support for tab completion in certain shells. To enable it, the end user must take a few steps once per shell. Once this is done, tab completion is automatic for static values in your app, such as enum values or values defined by calling <xref:System.CommandLine.Option%601.AcceptOnlyFromAmong>. You can also customize tab completion by providing values dynamically at runtime.

## Enable tab completion

On the machine where you want to enable tab completion, follow these steps.

For the .NET CLI:

* See [How to enable tab completion](../../core/tools/enable-tab-autocomplete.md).

For other command-line apps built on `System.CommandLine`:

* Install the [`dotnet-suggest`](https://nuget.org/packages/dotnet-suggest) global tool.

* Add the appropriate shim script to your shell profile. You might need to create a shell profile file. The shim script forwards completion requests from your shell to the `dotnet-suggest` tool, which delegates them to the appropriate `System.CommandLine`-based app.

  * For `bash`, add the contents of [*dotnet-suggest-shim.bash*](https://github.com/dotnet/command-line-api/blob/main/src/System.CommandLine.Suggest/dotnet-suggest-shim.bash) to *~/.bash_profile*.

  * For `zsh`, add the contents of [dotnet-suggest-shim.zsh](https://github.com/dotnet/command-line-api/blob/main/src/System.CommandLine.Suggest/dotnet-suggest-shim.zsh) to *~/.zshrc*.

  * For PowerShell, add the contents of [*dotnet-suggest-shim.ps1*](https://github.com/dotnet/command-line-api/blob/main/src/System.CommandLine.Suggest/dotnet-suggest-shim.ps1) to your PowerShell profile. You can find the expected path to your PowerShell profile by running the following command in your console:

    ```console
    echo $profile
    ```

* Register the app by calling  `dotnet-suggest register --command-path $executableFilePath`, where `$executableFilePath` is the path to the app's executable file.

Once the user's shell is set up and the executable is registered, completions will work for all apps that are built by using `System.CommandLine`.

For *cmd.exe* on Windows (the Windows Command Prompt) there is no pluggable tab completion mechanism, so no shim script is available. For other shells, [look for a GitHub issue that is labeled `Area-Completions`](https://github.com/dotnet/command-line-api/issues?q=is%3Aissue+is%3Aopen+label%3A%22Area-Completions%22). If you don't find an issue, you can [open a new one](https://github.com/dotnet/command-line-api/issues).

## Get tab completion values at run-time

The following code shows an app that retrieves values for tab completion dynamically at runtime. The code gets a list of the next two weeks of dates following the current date. The list is provided to the `--date` option by calling `CompletionSources.Add`:

:::code language="csharp" source="snippets/tab-completion/csharp/Program.cs" id="all" :::

The values shown when the Tab key is pressed are provided as `CompletionItem` instances:

:::code language="csharp" source="snippets/tab-completion/csharp/Program.cs" id="completionitem" :::

The following `CompletionItem` properties are set:

* `Label` is the completion value to be shown.
* `SortText` ensures that the values in the list are presented in the correct order. It is set by converting `i` to a two-digit string, so that sorting is based on 01, 02, 03, and so on, through 14. If you do not set this parameter, sorting is based on the `Label`, which in this example is in short date format and will not sort correctly.

There are other `CompletionItem` properties, such as `Documentation` and `Detail`, but they are not yet used in `System.CommandLine`.

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
  <2/4/2022|2/5/2022|2/6/2022|2/7/2022|2/8/2022|2/9/2022|2/10/2022>
  --version                                                                       Show version information
  -?, -h, --help
```

## See also

[System.CommandLine overview](index.md)
