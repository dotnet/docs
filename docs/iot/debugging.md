---
title: Debug .NET apps on Raspberry Pi 
description: Learn how to debug .NET apps on Raspberry Pi and similar devices.
author: camsoper
ms.author: casoper
ms.date: 11/13/2020
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

SSH is required for remote debugging. To enable SSH, [refer to *Enable SSH* in the Raspberry Pi documentation](https://www.raspberrypi.org/documentation/remote-access/ssh/).

### Install the Visual Studio Remote Debugger on the Raspberry Pi

Within a Bash console on the Raspberry Pi (either locally or via SSH), complete the following steps:

1. Execute the following command to download and install the Visual Studio Remote Debugger on the Raspberry Pi:

    ```bash
    curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg
    ```

1. The debugger requires running as `root`. By default, `root` has no password on Raspberry Pi. Set a password for `root` by executing the following command and following the prompts.

    ```bash
    sudo passwd root
    ```

1. Visual Studio Code uses the SSH protocol to debug remotely. For security purposes, `root` is not permitted to log on via SSH by default. To enable `root` to log on via SSH, complete the following steps:

    1. Execute the following command to open */etc/ssh/sshd_config* in [nano](https://www.nano-editor.org/docs.php).

        ```bash
        sudo nano /etc/ssh/sshd_config
        ```

    1. Press <kbd>Ctrl+W</kbd> and search for **PermitRootLogin**.
    1. Uncomment the line with **PermitRootLogin** if needed.
    1. Change the line to read as follows:

        ```console
        PermitRootLogin yes
        ```

        > [!NOTE]
        > If there is no **PermitRootLogin** line in */etc/ssh/sshd_config*, add a new line with the value shown above.

    1. Press <kbd>Ctrl+X</kbd> to exit and save your chances. When prompted **Save modified buffer?**, press <kbd>Y</kbd> to confirm. Press <kbd>Enter</kbd> to confirm overwriting the original file.
    1. Reboot the Raspberry Pi by executing the following command:

        ```bash
        sudo reboot
        ```

### Setup launch.json in Visual Studio Code

Add a launch configuration to the project's *launch.json*. If the project doesn't have a *launch.json* file, add one by switching to the **Run** tab, selecting **create a launch.json file**, and selecting **.NET** or **.NET Core** in the dialog.

The new configuration in *launch.json* should look similar to this:

```json
"configurations": [
    {
        "name": ".NET Core Launch (remote console)",
        "type": "coreclr",
        "request": "launch",
        "preLaunchTask": "build",
        "program": "/home/pi/.dotnet/dotnet",
        "args": ["/home/pi/sample/Sample.dll"],
        "cwd": "/home/pi/sample",
        "stopAtEntry": false,
        "console": "internalConsole",
        "pipeTransport": {
            "pipeCwd": "${workspaceFolder}",
            "pipeProgram": "C:\\Program Files\\PuTTY\\PLINK.EXE",
            "pipeArgs": [
                "-pw",
                "P@ssw0rd",
                "root@raspberrypi"
            ],
            "debuggerPath": "/home/pi/vsdbg/vsdbg"
        }
    },
```

Notice the following:

- `program` is the path to the .NET runtime on the Pi.
- `args` is the path to the assembly to debug on the Pi.
- `cwd` is the working directory to use when launching the app on the Pi.
- `pipeProgram` is the path to an SSH client on the local machine.
- `pipeArgs` are the parameters to be passed to the SSH client. Be sure to specify the password parameter, as well as the `root` user in the format `<user>@<hostname>`.

> [!IMPORTANT]
> The above example uses *plink*, a component of the [PuTTY](https://www.ssh.com/ssh/putty/)<span class="docon docon-navigate-external x-hidden-focus"></span> SSH client. [OpenSSH](https://www.openssh.com/)<span class="docon docon-navigate-external x-hidden-focus"></span>, which is included in recent versions of Windows and Linux, may be used instead. However, OpenSSH doesn't support sending passwords as a command-line parameter. To use OpenSSH, [configure your Raspberry Pi for passwordless SSH access](https://www.raspberrypi.org/documentation/remote-access/ssh/passwordless.md).

### Deploy the app

Deploy the app as described in [Deploy .NET apps to Raspberry Pi](deployment.md). Ensure the deployment path is the same path specified in the `cwd` parameter in the *launch.json* configuration.

### Launch the debugger

On the **Run** tab, select the **.NET Core Launch (remote console)** configuration and select **Start Debugging**. The app launches on the Raspberry Pi. The debugger may be used to set breakpoints, inspect locals, and more.

## References

[Remote debugging with VS Code on Windows to a Raspberry Pi using .NET Core on ARM](https://www.hanselman.com/blog/remote-debugging-with-vs-code-on-windows-to-a-raspberry-pi-using-net-core-on-arm)

::: zone-end

::: zone pivot="visualstudio"

## Debug from Visual Studio on Windows

Visual Studio can debug .NET apps on remote devices via SSH. No specialized configuration is required on the device. For details on using Visual Studio to debug .NET remotely, see [Remote debug .NET on Linux using SSH](/visualstudio/debugger/remote-debugging-dotnet-core-linux-with-ssh?view=vs-2019).

::: zone-end
