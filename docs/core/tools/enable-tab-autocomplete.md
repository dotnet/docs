---
title: Enable tab completion
description: This article teaches you how to enable tab completion for the .NET CLI for PowerShell, Bash, zsh, fish, and nushell.
author: adegeo
ms.author: adegeo
ms.topic: how-to
ms.date: 07/06/2023
---

# How to enable tab completion for the .NET CLI

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

This article describes how to configure tab completion for five shells: PowerShell, Bash, zsh, fish, and nushell. For other shells, refer to their documentation on how to configure tab completion.

Once set up, tab completion for the .NET CLI is triggered by entering a `dotnet` command in the shell and then pressing the <kbd>Tab</kbd> key. The current command line is sent to the `dotnet complete` command, and the results are processed by the shell. You can test the results without enabling tab completion by sending something directly to the `dotnet complete` command. For example:

```console
> dotnet complete "dotnet a"
add
clean
--diagnostics
migrate
pack
```

If that command doesn't work, make sure that .NET Core 2.0 SDK or later is installed. If it's installed but that command still doesn't work, make sure that the `dotnet` command resolves to a version of .NET Core 2.0 SDK or later. Use the `dotnet --version` command to see what version of `dotnet` your current path is resolving to. For more information, see [Select the .NET version to use](../versions/selection.md).

## Examples

Here are some examples of what tab completion provides:

| Input           | Becomes             | Because                                        |
|:----------------|:--------------------|:-----------------------------------------------|
| `dotnet a⇥`    | `dotnet add`        | `add` is the first subcommand, alphabetically. |
| `dotnet add p⇥` | `dotnet add --help` | Tab completion matches substrings, and `--help` comes first alphabetically. |
| `dotnet add p⇥⇥` | `dotnet add package` | Pressing tab a second time brings up the next suggestion. |
| `dotnet package add Microsoft⇥` | `dotnet package add Microsoft.ApplicationInsights.Web` | Results are returned alphabetically. |
| `dotnet reference remove ⇥` | `dotnet reference remove ..\..\src\OmniSharp.DotNet\OmniSharp.DotNet.csproj` | Tab completion is project file aware. |

## PowerShell

To add tab completion to **PowerShell** for the .NET CLI, create or edit the profile stored in the variable `$PROFILE`. For more information, see [How to create your profile](/powershell/module/microsoft.powershell.core/about/about_profiles#how-to-create-a-profile) and [Profiles and execution policy](/powershell/module/microsoft.powershell.core/about/about_profiles#profiles-and-execution-policy).

Add the following code to your profile:

```powershell
# PowerShell parameter completion shim for the dotnet CLI
Register-ArgumentCompleter -Native -CommandName dotnet -ScriptBlock {
    param($wordToComplete, $commandAst, $cursorPosition)
        dotnet complete --position $cursorPosition "$commandAst" | ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
        }
}
```

## bash

To add tab completion to your **bash** shell for the .NET CLI, add the following code to your `.bashrc` file:

```bash
# bash parameter completion for the dotnet CLI

function _dotnet_bash_complete()
{
  local cur="${COMP_WORDS[COMP_CWORD]}" IFS=$'\n' # On Windows you may need to use use IFS=$'\r\n'
  local candidates

  read -d '' -ra candidates < <(dotnet complete --position "${COMP_POINT}" "${COMP_LINE}" 2>/dev/null)

  read -d '' -ra COMPREPLY < <(compgen -W "${candidates[*]:-}" -- "$cur")
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

  # If the completion list is empty, just continue with filename selection
  if [ -z "$completions" ]
  then
    _arguments '*::arguments: _normal'
    return
  fi

  # This is not a variable assignment, don't remove spaces!
  _values = "${(ps:\n:)completions}"
}

compdef _dotnet_zsh_complete dotnet
```

## fish

To add tab completion to your **fish** shell for the .NET CLI, add the following code to your `config.fish` file:

```fish
complete -f -c dotnet -a "(dotnet complete (commandline -cp))"
```

## nushell

To add tab completion to your **nushell** for .NET CLI, add the following to the beginning of your `config.nu` file:

```nu
let external_completer = { |spans|
    {
        dotnet: { ||
            dotnet complete (
                $spans | skip 1 | str join " "
            ) | lines
        }
    } | get $spans.0 | each { || do $in }
}
```

And then in the `config` record, find the `completions` section and add the `external_completer` that was defined earlier to `external`:

```nu
let-env config = {
    # your options here
    completions: {
        # your options here
        external: {
            # your options here
            completer: $external_completer # add it here
        }
    }
}
```
