---
title: Enable tab completion
description: This article teaches you how to enable tab completion for the .NET CLI for PowerShell, Bash, zsh, and fish.
author: adegeo
ms.author: adegeo
ms.topic: how-to
ms.date: 11/03/2019
---

# How to enable TAB completion for the .NET CLI

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

This article describes how to configure tab completion for four shells, PowerShell, Bash, zsh, and fish. For other shells, refer to their documentation on how to configure tab completion.

Once set up, tab completion for the .NET CLI is triggered by typing a `dotnet` command in the shell, and then pressing the TAB key. The current command line is sent to the `dotnet complete` command, and the results are processed by your shell. You can test the results without enabling tab completion by sending something directly to the `dotnet complete` command. For example:

```console
> dotnet complete "dotnet a"
add
clean
--diagnostics
migrate
pack
```

If that command doesn't work, make sure that .NET Core 2.0 SDK or above is installed. If it's installed, but that command still doesn't work, make sure that the `dotnet` command resolves to a version of .NET Core 2.0 SDK and above. Use the `dotnet --version` command to see what version of `dotnet` your current path is resolving to. For more information, see [Select the .NET version to use](../versions/selection.md).

### Examples

Here are some examples of what tab completion provides:

Input                                | becomes                                                                     | because
:------------------------------------|:----------------------------------------------------------------------------|:--------------------------------
`dotnet a⇥`                          | `dotnet add`                                                                 | `add` is the first subcommand, alphabetically.
`dotnet add p⇥`                      | `dotnet add --help`                                                          | Tab completion matches substrings and `--help` comes first alphabetically.
`dotnet add p⇥⇥`                    | `dotnet add package`                                                          | Pressing tab a second time brings up the next suggestion.
`dotnet add package Microsoft⇥`      | `dotnet add package Microsoft.ApplicationInsights.Web`                      | Results are returned alphabetically.
`dotnet remove reference ⇥`          | `dotnet remove reference ..\..\src\OmniSharp.DotNet\OmniSharp.DotNet.csproj` | Tab completion is project file aware.

## PowerShell

To add tab completion to **PowerShell** for the .NET CLI, create or edit the profile stored in the variable `$PROFILE`. For more information, see [How to create your profile](/powershell/module/microsoft.powershell.core/about/about_profiles#how-to-create-a-profile) and [Profiles and execution policy](/powershell/module/microsoft.powershell.core/about/about_profiles#profiles-and-execution-policy).

Add the following code to your profile:

```powershell
# PowerShell parameter completion shim for the dotnet CLI
Register-ArgumentCompleter -Native -CommandName dotnet -ScriptBlock {
     param($commandName, $wordToComplete, $cursorPosition)
         dotnet complete --position $cursorPosition "$wordToComplete" | ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
         }
 }
```

## bash

To add tab completion to your **bash** shell for the .NET CLI, add the following code to your `.bashrc` file:

```bash
# bash parameter completion for the dotnet CLI

_dotnet_bash_complete()
{
  local word=${COMP_WORDS[COMP_CWORD]}

  local completions
  completions="$(dotnet complete --position "${COMP_POINT}" "${COMP_LINE}" 2>/dev/null)"
  if [ $? -ne 0 ]; then
    completions=""
  fi

  COMPREPLY=( $(compgen -W "$completions" -- "$word") )
}

complete -f -F _dotnet_bash_complete dotnet
```

## zsh

To add tab completion to your **zsh** shell for the .NET CLI, add the following code to your `.zshrc` file:

```zsh
# zsh parameter completion for the dotnet CLI

_dotnet_zsh_complete()
{
  local completions=("$(dotnet complete "$words")")

  reply=( "${(ps:\n:)completions}" )
}

compctl -K _dotnet_zsh_complete dotnet
```

## fish

To add tab completion to your **fish** shell for the .NET CLI, add the following code to your `config.fish` file:

```fish
complete -f -c dotnet -a "(dotnet complete)"
```
