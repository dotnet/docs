---
title: Debug .NET apps on Raspberry Pi 
description: Learn how to debug .NET apps on Raspberry Pi and similar devices.
author: camsoper
ms.author: casoper
ms.date: 10/07/2022
ms.topic: how-to
ms.prod: dotnet
zone_pivot_groups: ide-set-one
---

# Debug .NET apps on Raspberry Pi

Debugging .NET apps running on ARM-based IoT devices like Raspberry Pi presents a unique challenge. If desired, you can install Visual Studio Code and the .NET SDK on the device and develop locally. However, the device's performance is such that coding and debugging locally is not recommended. Additionally, the Visual Studio Code extension for C# is not compatible with 32-bit operating systems. Consequently, functionality like IntelliSense and debugging in Visual Studio Code on these devices is only supported in 64-bit systems.

For these reasons, it's strongly recommended that you develop your app on a development computer and then deploy the app to the device for remote debugging. If you wish to develop and debug locally on the device, the following is required:

 - A 64-bit OS, such as Raspberry Pi OS (64-bit).
 - [Visual Studio Code](https://code.visualstudio.com/docs/setup/raspberry-pi) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).
   - Disable the [hardware acceleration](https://code.visualstudio.com/docs/setup/raspberry-pi#_workaround-for-poor-performance).
 - .NET SDK 6.0 or later.
   - Install using the *dotnet-install* script [as in a framework-dependent deployment](deployment.md#deploying-a-framework-dependent-app). Be sure to add a `DOTNET_ROOT` environment variable and add the *.dotnet* directory to `$PATH`.

The rest of this article describes how to debug .NET apps on Raspberry Pi and similar devices remotely from a development computer.

> [!IMPORTANT]
> As of this writing, remotely debugging .NET 7 apps in `linux-arm` environments is unreliable and may cause the process to exit prematurely. This issue is under investigation. .NET 6 apps that target `linux-arm` and .NET 7 apps that target `linux-arm64` remain unaffected by this issue.


::: zone pivot="vscode"

## Debug from Visual Studio Code (cross-platform)

Debugging .NET on Raspberry Pi from Visual Studio Code requires configuration steps on the Raspberry Pi and in the project's *launch.json* file.

### Enable SSH on the Raspberry Pi

SSH is required for remote debugging. To enable SSH, [refer to *Enable SSH* in the Raspberry Pi documentation](https://www.raspberrypi.com/documentation/computers/remote-access.html#setting-up-an-ssh-server). Ensure that you have configured [passwordless SSH](https://www.raspberrypi.com/documentation/computers/remote-access.html#passwordless-ssh-access).

> [!IMPORTANT]
> This example requires you to configure [passwordless SSH](https://www.raspberrypi.com/documentation/computers/remote-access.html#passwordless-ssh-access) on your Raspberry Pi, as OpenSSH doesn't support passing passwords on the command line. If you need to use a password, consider substituting the *plink* tool included with [PuTTY](https://www.putty.org/) for *ssh*.

### Install the Visual Studio Remote Debugger on the Raspberry Pi

Within a Bash console on the Raspberry Pi (either in a local session or via SSH), execute the following command. This command downloads and installs the Visual Studio Remote Debugger on the Raspberry Pi:

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
            "pipeProgram": "ssh",
            "pipeArgs": [
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
### Deploy the app

Deploy the app as described in [Deploy .NET apps to Raspberry Pi](deployment.md). Ensure the deployment path is the same path specified in the `cwd` parameter in the *launch.json* configuration.

### Launch the debugger

On the **Run** tab, select the configuration you added to *launch.json* and select **Start Debugging**. The app launches on the Raspberry Pi. The debugger may be used to set breakpoints, inspect locals, and more.

### Attach the debugger

In Visual Studio Code, on the **Run and Debug** tab, select the configuration you added to *launch.json* and select **Start Debugging**. The app launches on the Raspberry Pi. The debugger may be used to set breakpoints, inspect locals, and more.

::: zone-end

::: zone pivot="visualstudio"

## Debug from Visual Studio on Windows

Visual Studio can debug .NET apps on remote devices via SSH. No specialized configuration is required on the device. For details on using Visual Studio to debug .NET remotely, see [Remote debug .NET on Linux using SSH](/visualstudio/debugger/remote-debugging-dotnet-core-linux-with-ssh).

Be sure to select the `dotnet` process if you're debugging a framework-dependent deployment. Otherwise, the process will be named the same as the app's executable.

::: zone-end
