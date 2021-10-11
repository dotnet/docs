---
title: Debug .NET apps on Raspberry Pi 
description: Learn how to debug .NET apps on Raspberry Pi and similar devices.
author: camsoper
ms.author: casoper
ms.date: 10/06/2021
ms.topic: how-to
ms.prod: dotnet
zone_pivot_groups: ide-set-one
---

# Debug .NET apps on Raspberry Pi

Debugging .NET apps running on ARM-based IoT devices like Raspberry Pi presents a unique challenge. It is possible to develop .NET apps on ARM devices. However, OmniSharp, which is required for debugging .NET apps outside of Visual Studio, is not compatible with ARM devices. As a result, apps must be debugged remotely from a compatible platform.

::: zone pivot="vscode"

## Debug from Visual Studio Code (cross-platform)

Debugging .NET on Raspberry Pi from Visual Studio Code requires configuration steps on the Raspberry Pi and in the project's *launch.json* file.

### Enable SSH on the Raspberry Pi

SSH is required for remote debugging. To enable SSH, [refer to *Enable SSH* in the Raspberry Pi documentation](https://www.raspberrypi.com/documentation/computers/remote-access.html#setting-up-an-ssh-server).

### Install the Visual Studio Remote Debugger on the Raspberry Pi

Within a Bash console on the Raspberry Pi (either locally or via SSH), execute the following command. This command downloads and installs the Visual Studio Remote Debugger on the Raspberry Pi:

```bash
curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg
```

### Set up launch.json in Visual Studio Code

On the development computer, add a launch configuration to the project's *launch.json*. If the project doesn't have a *launch.json* file, add one by switching to the **Run** tab, selecting **create a launch.json file**, and selecting **.NET** or **.NET Core** in the dialog.

The new configuration in *launch.json* should look similar to one of the following:

### [Self-contained](#tab/self-contained)

```json
"configurations": [
    {
        "name": ".NET Remote Launch - Self-contained",
        "type": "coreclr",
        "request": "launch",
        "program": "~/sample/sample",
        "args": [],
        "cwd": "~/sample",
        "stopAtEntry": false,
        "console": "internalConsole",
        "pipeTransport": {
            "pipeCwd": "${workspaceRoot}",
            "pipeProgram": "C:\\Program Files\\PuTTY\\PLINK.EXE",
            "pipeArgs": [
                "-pw", "raspberry",
                "pi@raspberrypi"
            ],
            "debuggerPath": "~/vsdbg/vsdbg"
            }
        },
```

Notice the following:

- `program` is the executable file created by `dotnet publish`.
- `cwd` is the working directory to use when launching the app on the Pi.
- `pipeProgram` is the path to an SSH client on the local machine.
- `pipeArgs` are the parameters to be passed to the SSH client. Be sure to specify the password parameter, as well as the `pi` user in the format `<user>@<hostname>`.

### [Framework-dependent](#tab/framework-dependent)

```json
"configurations": [
    {
        "name": ".NET Remote Launch - Framework-dependent",
        "type": "coreclr",
        "request": "launch",
        "program": "~/dotnet/dotnet",
        "args": ["~/sample/sample.dll"],
        "cwd": "~/sample",
        "stopAtEntry": false,
        "console": "internalConsole",
        "pipeTransport": {
            "pipeCwd": "${workspaceRoot}",
            "pipeProgram": "C:\\Program Files\\PuTTY\\PLINK.EXE",
            "pipeArgs": [
                "-pw", "raspberry",
                "pi@raspberrypi"
            ],
            "debuggerPath": "~/vsdbg/vsdbg"
            }
        },
```

Notice the following:

- `program` is the path to the .NET runtime on the Pi.
- `args` is the path to the assembly to debug on the Pi.
- `cwd` is the working directory to use when launching the app on the Pi.
- `pipeProgram` is the path to an SSH client on the local machine.
- `pipeArgs` are the parameters to be passed to the SSH client. Be sure to specify the password parameter, as well as the `pi` user in the format `<user>@<hostname>`.

---

> [!IMPORTANT]
> The previous examples use *plink*, a component of the [PuTTY](https://www.ssh.com/ssh/putty/)<span class="docon docon-navigate-external x-hidden-focus"></span> SSH client. [OpenSSH](https://www.openssh.com/)<span class="docon docon-navigate-external x-hidden-focus"></span>, which is included in recent versions of Windows and Linux, may be used instead. However, OpenSSH doesn't support sending passwords as a command-line parameter. To use OpenSSH, [configure your Raspberry Pi for passwordless SSH access](https://www.raspberrypi.com/documentation/remote-access/ssh/passwordless.md).

### Deploy the app

Deploy the app as described in [Deploy .NET apps to Raspberry Pi](deployment.md). Ensure the deployment path is the same path specified in the `cwd` parameter in the *launch.json* configuration.

### Launch the debugger

On the **Run** tab, select the configuration you added to *launch.json* and select **Start Debugging**. The app launches on the Raspberry Pi. The debugger may be used to set breakpoints, inspect locals, and more.

### References

[Remote Debugging on Linux ARM](https://github.com/OmniSharp/omnisharp-vscode/wiki/Remote-Debugging-On-Linux-Arm) (OmniSharp documentation)

::: zone-end

::: zone pivot="visualstudio"

## Debug from Visual Studio on Windows

Visual Studio can debug .NET apps on remote devices via SSH. No specialized configuration is required on the device. For details on using Visual Studio to debug .NET remotely, see [Remote debug .NET on Linux using SSH](/visualstudio/debugger/remote-debugging-dotnet-core-linux-with-ssh).

::: zone-end
