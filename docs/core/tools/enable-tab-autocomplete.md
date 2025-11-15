---
title: Enable tab completion
description: This article teaches you how to enable tab completion for the .NET CLI for PowerShell (pwsh), Bash, zsh, fish, and nushell.
author: adegeo
ms.author: adegeo
ms.topic: how-to
ms.date: 11/14/2025
ai-usage: ai-assisted
---

# How to enable tab completion for the .NET CLI

**This article applies to:** ✔️ .NET 6 SDK and later versions

This article describes how to configure tab completion for five shells: PowerShell (pwsh), Bash, zsh, fish, and nushell. For other shells, refer to their documentation on how to configure tab completion.

## Native shell completion scripts (.NET 10+)

Starting with .NET 10, the .NET CLI includes native shell completion scripts that run much faster than the dynamic completions available in earlier versions. Native completions generate shell-specific scripts that handle the static parts of the CLI grammar directly in the shell, providing a significant performance improvement.

### Generate completion scripts

Use the `dotnet completions generate` command to generate a completion script for your shell:

```console
dotnet completions generate [SHELL]
```

The `[SHELL]` parameter accepts one of the following values:

- `bash`
- `fish`
- `nushell`
- `pwsh`
- `zsh`

If you don't specify a shell, the command infers the correct shell from your environment. On Windows, it defaults to PowerShell (`pwsh`). On other systems, it checks if the file name of the `SHELL` environment variable matches any of the supported shell values.

### Completion capabilities

Native completions provide different levels of support depending on the shell:

| Shell      | Completion type | Descriptions in tab completions |
|------------|-----------------|-------------------------------------|
| bash       | hybrid          | No                                  |
| fish       | dynamic         | No                                  |
| nushell    | dynamic         | No                                  |
| PowerShell | hybrid          | Yes                                 |
| zsh        | hybrid          | Yes                                 |

**Completion types:**

- **Hybrid**: Generates shell-specific code that handles static parts of the CLI grammar quickly, but falls back to the `dotnet complete` command for dynamic content (such as NuGet package IDs).
- **Dynamic**: All completions go through the `dotnet complete` command, which might be slower but ensures comprehensive coverage.

### Configure shells to use native completions

Add the appropriate command to your shell's profile to enable native completions:

#### PowerShell

Add the following line to your PowerShell profile (`$PROFILE`):

```powershell
dotnet completions generate pwsh | Out-String | Invoke-Expression
```

#### Bash

Add the following line to your `.bashrc` file:

```bash
eval "$(dotnet completions generate bash)"
```

#### Zsh

Add the following line to your `.zshrc` file:

```zsh
eval "$(dotnet completions generate zsh)"
```

#### Fish

Add the following line to your `config.fish` file:

```fish
dotnet completions generate fish | source
```

#### Nushell

Add the following to the beginning of your `config.nu` file:

```nu
dotnet completions generate nushell | save -f ~/.local/share/nushell/completions/dotnet.nu
use ~/.local/share/nushell/completions/dotnet.nu *
```

## Dynamic completion scripts (all versions)

For .NET versions prior to .NET 10, or if you prefer to use dynamic completions, you can configure your shell to use the `dotnet complete` command. Dynamic completions work by sending the current command line to the `dotnet complete` command and processing the results in the shell.

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

### Examples

Here are some examples of what tab completion provides:

| Input                           | Becomes                                                                      | Because                                                                      |
|---------------------------------|------------------------------------------------------------------------------|------------------------------------------------------------------------------|
| `dotnet a⇥`                     | `dotnet add`                                                                 | `add` is the first subcommand, alphabetically.                               |
| `dotnet add p⇥`                 | `dotnet add --help`                                                          | Tab completion matches substrings, and `--help` comes first alphabetically. |
| `dotnet add p⇥⇥`                | `dotnet add package`                                                         | Pressing tab a second time brings up the next suggestion.                    |
| `dotnet package add Microsoft⇥` | `dotnet package add Microsoft.ApplicationInsights.Web`                       | Results are returned alphabetically.                                         |
| `dotnet reference remove ⇥`     | `dotnet reference remove ..\..\src\OmniSharp.DotNet\OmniSharp.DotNet.csproj` | Tab completion is project file aware.                                        |

### PowerShell

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

### bash

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

### zsh

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

### fish

To add tab completion to your **fish** shell for the .NET CLI, add the following code to your `config.fish` file:

```fish
complete -f -c dotnet -a "(dotnet complete (commandline -cp))"
```

### nushell

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
