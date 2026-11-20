---
title: "Breaking change - CLI path options preserve literal MSBuild-special characters"
description: "Learn about the breaking change in .NET 12 where CLI path options preserve literal characters instead of interpreting them as MSBuild syntax."
ms.date: 11/16/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56926
---

# CLI path options preserve literal MSBuild-special characters

In .NET 12, the .NET CLI escapes certain path option values before it forwards them to MSBuild. These options treat characters such as `%`, `;`, `$`, and `@` as literal path characters rather than MSBuild syntax. If your scripts pre-escape paths for MSBuild or intentionally use MSBuild syntax in these options, the commands can select different paths.

## Version introduced

.NET 12 (planned)

> [!NOTE]
> The implementation is under review in [dotnet/sdk#56972](https://github.com/dotnet/sdk/pull/56972). The first SDK build and public preview that include this change haven't been confirmed.

## Previous behavior

The CLI resolved path option values to full paths and forwarded them to MSBuild without escaping MSBuild-special characters. MSBuild could decode percent escape sequences or interpret other syntax in those paths.

For example, the following command wrote build output to a directory named `out dir`, because MSBuild interpreted `%20` as a space:

```dotnetcli
dotnet build --output out%20dir
```

Valid filesystem paths that contained semicolons could cause an `MSB1006` error. Even a relative path without special characters could fail if the CLI resolved it against a current directory that contained a semicolon.

## New behavior

The CLI escapes the full path before it forwards the value to MSBuild. For example, `dotnet build --output out%20dir` selects a directory literally named `out%20dir`, not `out dir`. MSBuild escape sequences and property or item syntax in the affected option values remain literal text.

The change applies to the following options:

| Option | Commands |
| --- | --- |
| `--output` / `-o` | `dotnet build`, `dotnet publish`, `dotnet clean`, `dotnet pack`, `dotnet store`, and `dotnet test` in VSTest mode. |
| `--artifacts-path` | `dotnet build`, `dotnet publish`, `dotnet clean`, `dotnet pack`, `dotnet restore`, `dotnet run`, and `dotnet test` in both VSTest and Microsoft.Testing.Platform modes. |
| `--packages` and `--configfile` | Restore-option forwarding in `dotnet restore`, `dotnet build`, `dotnet publish`, and `dotnet pack`. |
| `--working-dir` | `dotnet store`. |
| `--settings`, `--diag`, and `--results-directory` | `dotnet test` in VSTest mode. |

Relative-path resolution and existing quote requirements remain unchanged. The change doesn't alter explicit MSBuild property arguments, such as `-p:OutputPath=...`, or add literal-path escaping to `dotnet watch`. Filesystem restrictions and shell argument rules still apply.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To support valid filesystem paths that contain MSBuild-special characters, the CLI must escape paths before it forwards them to MSBuild. The change fixes failures with semicolons in output paths and prevents unintended MSBuild interpretation of path values.

For background, see [dotnet/sdk#49671](https://github.com/dotnet/sdk/issues/49671).

## Recommended action

Pass the desired filesystem path literally instead of pre-escaping it for MSBuild. For example, if you intend to write to `out dir`, pass the space rather than `%20`:

```dotnetcli
dotnet build --output "out dir"
```

To preserve intentional MSBuild escape interpretation, use the corresponding MSBuild property instead of the CLI path option. For example, the following command continues to select `out dir`:

```dotnetcli
dotnet build -p:OutputPath=out%20dir/
```

Use the property that corresponds to the command and option. For example, publish output uses `PublishDir`, package output uses `PackageOutputPath`, and the artifacts path uses `ArtifactsPath`. Explicit `-p:` values retain their existing MSBuild syntax and escaping requirements.

Continue to quote or escape arguments as required by your shell. CLI path escaping protects values from MSBuild interpretation, not from shell expansion.

## Affected APIs

None.

## See also

- [dotnet build](../../../tools/dotnet-build.md)
- [dotnet publish](../../../tools/dotnet-publish.md)
- [Escape special characters in MSBuild](/visualstudio/msbuild/how-to-escape-special-characters-in-msbuild)
