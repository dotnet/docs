---
title: Enable tab completion .NET Core CLI
description: This article teaches you how to enable tab completion for the .NET Core CLI in v2.0 and above for PowerShell, Bash, and zsh.
author: thraka
ms.author: adegeo
ms.date: 12/17/2018
---

# How to enable TAB completion for the .NET Core CLI

Starting with .NET Core CLI v2.0, support for tab completion is included but disabled by default. This article describes how to enable tab completion for your terminal of choice.

[!INCLUDE topic-appliesto-net-core-2plus]

Tab completion for .NET Core is triggered by typing a `dotnet ` command in the terminal, and then hitting the TAB key. The current command line is sent to the `dotnet complete` command, and the results are processed by your terminal. You can test the results without enabling tab completion by sending something directly to the `dotnet complete` command. For example:

```
> dotnet complete "dotnet a"
add
clean
--diagnostics
migrate
pack
```

If that command doesn't work, make sure that .NET Core 2.0 or above is installed. If it's installed, but that command still doesn't work, make sure that the `dotnet` command resolves to a version of .NET Core 2.0 and above.

> [!TIP]
> Use the `dotnet --version` command to see what version of `dotnet` your current path is resolving to. For more information, see [Select the .NET Core version to use](../versions/selection.md).


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

To add tab completion to **PowerShell** for the .NET Core CLI, add the following code to your PowerShell profile stored in `$PROFILE`:

```powershell
# PowerShell parameter completion shim for the dotnet CLI 
Register-ArgumentCompleter -Native -CommandName dotnet -ScriptBlock {
     param($commandName, $wordToComplete, $cursorPosition)
         dotnet complete --position $cursorPosition "$wordToComplete" | ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
         }
 }
```

## Bash

To add tab completion to your **bash** terminal for the .NET Core CLI, add the following code to your `.bashrc` file:

```bash
# bash parameter completion for the dotnet CLI

_dotnet_bash_complete()
{
  local word=${COMP_WORDS[COMP_CWORD]}

  local completions
  completions="$(dotnet complete --position "${COMP_POINT}" "${COMP_LINE}")"

  COMPREPLY=( $(compgen -W "$completions" -- "$word") )
}

complete -f -F _dotnet_bash_complete dotnet
```

## Zsh

To add tab completion to your **zsh** terminal for the .NET Core CLI, add the following code to your `.zshrc` file:

```zsh
# zsh parameter completion for the dotnet CLI

_dotnet_zsh_complete() 
{
  local completions=("$(dotnet complete "$words")")

  reply=( "${(ps:\n:)completions}" )
}

compctl -K _dotnet_zsh_complete dotnet
```

