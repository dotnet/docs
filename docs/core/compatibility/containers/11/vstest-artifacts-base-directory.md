---
title: "Breaking change: dotnet test needs a writable VSTest artifacts base directory in containers"
description: "Learn about the breaking change in .NET 8, .NET 9, .NET 10, and .NET 11 where dotnet test with VSTest shows warnings in Linux containers and fails on Nano Server."
ms.date: 11/10/2026
ai-usage: ai-assisted
---

# dotnet test needs a writable VSTest artifacts base directory in containers

When you run `dotnet test` with VSTest in a container, the SDK now needs a writable base directory for private test-session files. In Linux containers, test runs can show warnings about the artifacts directory. On Nano Server, test runs can fail. This change affects the .NET 8, .NET 9, .NET 10, and .NET 11 SDKs.

## Version introduced

.NET SDK 11.0.100, 10.0.404, 10.0.115, 9.0.321, 9.0.124, 8.0.428, and 8.0.134

## Previous behavior

Previously, `dotnet test` with VSTest didn't print artifacts-directory warnings in Linux containers. On Nano Server, test runs didn't depend on the current user's Local AppData directory.

## New behavior

Starting in the SDK versions listed in [Version introduced](#version-introduced), the SDK creates a new private directory for each test run. VSTest stores the test-session files that attachment post-processing needs in that directory. The default base directory is `/run/user/<uid>` on Linux and Local AppData on Windows, where `<uid>` is the effective user ID of the process. Containers often don't have these locations.

### Linux containers

On Linux, the SDK doesn't create the base directory, and it doesn't fall back to `/tmp`. Instead, it runs VSTest without an artifacts directory, and VSTest tries the same missing base directory.

If the test run produces no attachments, `dotnet test` prints the following warning:

> VSTEST_ARTIFACTS_DIRECTORY environment variable was not found, falling back to a user-private temporary directory. This is most likely caused by an outdated Microsoft.NET.Test.Sdk package reference in the test project.

The advice about the `Microsoft.NET.Test.Sdk` package can be misleading. A missing `/run/user/<uid>` directory causes this warning even when the SDK and the package are up to date.

If the test run produces attachments, for example a coverage report from `--collect:"XPlat Code Coverage"`, `dotnet test` prints the following warning instead:

> The test session artifacts were not saved: The user-private temporary directory '/run/user/0' does not exist.

The path contains the current user ID. Other directory verification failures use the same `The test session artifacts were not saved:` prefix, followed by the reason.

In both cases, the tests continue to run, and a passing run can exit with code `0`. If VSTest can't save the session files, the SDK skips attachment post-processing. The original output files from the data collector aren't deleted.

### Nano Server containers

On Windows, if the SDK can't resolve the Local AppData directory, the test run stops. This failure can occur with or without a data collector. The SDK prints the following error:

> Could not determine a private base directory for the test run: the current user's local application data folder does not exist or could not be resolved. Set the VSTEST_ARTIFACTS_BASE_DIRECTORY environment variable to the directory the artifacts directory should be created under.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To improve security, the SDK stores test-session files in a private directory that only the current user can access. For more information, see [dotnet/sdk issue #57029](https://github.com/dotnet/sdk/issues/57029).

## Recommended action

To fix the warnings and the Nano Server failures, set the `VSTEST_ARTIFACTS_BASE_DIRECTORY` environment variable before you run `dotnet test`. Use `/tmp` on Linux and `C:\Windows\Temp` on Nano Server. Set this variable in the container image or in the CI step that runs the tests.

The official .NET SDK container images set this variable. If your image is based on `mcr.microsoft.com/dotnet/sdk`, you don't need to set it yourself.

Linux shell:

```bash
export VSTEST_ARTIFACTS_BASE_DIRECTORY=/tmp
dotnet test
```

PowerShell on Nano Server:

```powershell
$env:VSTEST_ARTIFACTS_BASE_DIRECTORY = 'C:\Windows\Temp'
dotnet test
```

Linux Dockerfile:

```dockerfile
ENV VSTEST_ARTIFACTS_BASE_DIRECTORY=/tmp
```

Nano Server Dockerfile, with the default backslash escape character:

```dockerfile
ENV VSTEST_ARTIFACTS_BASE_DIRECTORY="C:\\Windows\\Temp"
```

For a `docker run` command, add `-e VSTEST_ARTIFACTS_BASE_DIRECTORY=/tmp` on Linux or `-e "VSTEST_ARTIFACTS_BASE_DIRECTORY=C:\Windows\Temp"` on Windows.

Keep the following points in mind:

- The test process must be able to write to the base directory. The directory doesn't need to exist. The SDK creates missing parent directories if the test process has permission to create them.
- Set `VSTEST_ARTIFACTS_BASE_DIRECTORY`, not `VSTEST_ARTIFACTS_DIRECTORY`. The SDK sets `VSTEST_ARTIFACTS_DIRECTORY` and passes it to VSTest.
- On Linux, `TMPDIR` and `XDG_RUNTIME_DIR` don't change the default base directory.

A shared base directory such as `/tmp` is safe because the SDK doesn't write session files to it directly. For each run, the SDK creates a subdirectory with a random name:

- On Linux, the SDK creates the subdirectory with mode `0700`, so only its owner can access it. The sticky bit on `/tmp` prevents other users from deleting or renaming it.
- On Windows, the SDK creates the subdirectory with an access control list (ACL) that grants access only to the owner and doesn't inherit permissions from the base directory.

These protections isolate different users. They don't isolate processes that run as the same user, and they don't block root or administrators. Don't remove the normal protections of the base directory.

## Affected APIs

None.
