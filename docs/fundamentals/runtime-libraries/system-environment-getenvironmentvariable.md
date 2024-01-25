---
title: System.Environment.GetEnvironmentVariable methods
description: Learn about the System.Environment.GetEnvironmentVariable methods.
ms.date: 01/24/2024
---
# System.Environment.GetEnvironmentVariable methods

[!INCLUDE [context](includes/context.md)]

The <xref:System.Environment.GetEnvironmentVariable%2A> method retrieves the value of an environment variable from the current process.

## <xref:System.Environment.GetEnvironmentVariable(System.String)> method

The <xref:System.Environment.GetEnvironmentVariable(System.String)> method retrieves an environment variable from the environment block of the current process only. It's equivalent to calling the <xref:System.Environment.GetEnvironmentVariable(System.String,System.EnvironmentVariableTarget)> method with a `target` value of <xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType>.

To retrieve all environment variables along with their values, call the <xref:System.Environment.GetEnvironmentVariables%2A> method.

Environment variable names are case-sensitive on non-Windows systems but are not case-sensitive on Windows.

### On Windows systems

On Windows systems, the environment block of the current process includes:

- All environment variables that are provided to it by the parent process that created it. For example, a .NET application launched from a console window inherits all of the console window's environment variables.

  If there is no parent process, per-machine and per-user environment variables are used instead. For example, a new console window has all per-machine and per-user environment variables defined at the time it was launched.

- Any variables added to the process block while the process is running by calling either the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String)> method or the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String,System.EnvironmentVariableTarget)> method with a `target` value of <xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType>. These environment variables persist until the .NET application terminates.

If environment variables are created after the process has started, you can use this method to retrieve only those variables that were created by calling the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String)> method or the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String,System.EnvironmentVariableTarget)> method with a `target` value of .<xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType>.

### On non-Windows systems

On non-Windows systems, the environment block of the current process includes the following environment variables:

- All environment variables that are provided to it by the parent process that created it. For .NET applications launched from a shell, this includes all environment variables defined in the shell.

- Any variables added to the process block while the process is running by calling either the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String)> method or the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String,System.EnvironmentVariableTarget)> method with a `target` value of <xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType>. These environment variables persist until the .NET application terminates.

.NET on non-Windows systems does not support per-machine or per-user environment variables.

## <xref:System.Environment.GetEnvironmentVariable(System.String,System.EnvironmentVariableTarget)> method

To retrieve all environment variables along with their values, call the <xref:System.Environment.GetEnvironmentVariables%2A> method.

Environment variable names are case-sensitive on non-Windows systems but are not case-sensitive on Windows.

### On Windows systems

On Windows, the `target` parameter specifies whether the environment variable is retrieved from the current process or from the Windows operating system registry key for the current user or local machine. All per-user and per-machine environment variables are automatically copied into the environment block of the current process, as are any other environment variables that are available to the parent process that created the .NET process. However, environment variables added only to the environment block of the current process by calling either the <xref:System.Environment.SetEnvironmentVariable%28System.String%2CSystem.String%29> method or the <xref:System.Environment.SetEnvironmentVariable%28System.String%2CSystem.String%2CSystem.EnvironmentVariableTarget%29> method with a `target` value of <xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType> persist only for the duration of the process.

### On non-Windows systems

On non-Windows systems, the `GetEnvironmentVariable(String, EnvironmentVariableTarget)` method supports a `target` value of <xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType> only. Calls with a `target` value of <xref:System.EnvironmentVariableTarget.Machine?displayProperty=nameWithType> or <xref:System.EnvironmentVariableTarget.User?displayProperty=nameWithType> are not supported and return `null`.

Per-process environment variables are:

- Those inherited from the parent process, typically the shell used to invoke `dotnet.exe` or to launch the .NET application.

- Those defined by calling either the <xref:System.Environment.SetEnvironmentVariable%28System.String%2CSystem.String%29> method or the <xref:System.Environment.SetEnvironmentVariable%28System.String%2CSystem.String%2CSystem.EnvironmentVariableTarget%29> method with a `target` value of <xref:System.EnvironmentVariableTarget.Process?displayProperty=nameWithType>. These environment variables persist only until the `dotnet` process or the .NET application terminates.
