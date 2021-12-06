---
title: Create a Windows Service using BackgroundService
description: Learn how to create a Windows Service using the BackgroundService in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 12/03/2021
ms.topic: tutorial
---

# Create a Windows Service using `BackgroundService`

.NET Framework developers are probably familiar with Windows Service apps. Before .NET Core and .NET 5+, developers who relied on .NET Framework could create Windows Services to perform background tasks or execute long-running processes. This functionality is still available and you can create Worker Services that run as a Windows Service.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Publish a .NET worker app as a single file executable.
> - Create a Windows Service.
> - Create the `BackgroundService` app as a Windows Service.
> - Start and stop the Windows Service.
> - View event logs.
> - Delete the Windows Service.

[!INCLUDE [workers-samples-browser](includes/workers-samples-browser.md)]

## Prerequisites

- The [.NET 5.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A Windows OS
- A .NET integrated development environment (IDE)
  - Feel free to use [Visual Studio](https://visualstudio.microsoft.com)

<!-- ## Create a new project -->
[!INCLUDE [file-new-worker](includes/file-new-worker.md)]

## Install NuGet package

In order to interop with native Windows Services from .NET <xref:Microsoft.Extensions.Hosting.IHostedService> implementations, you'll need to install the [`Microsoft.Extensions.Hosting.WindowsServices` NuGet package](https://nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices).

To install this from Visual Studio, use the **Manage NuGet Packages...** dialog. Search for "Microsoft.Extensions.Hosting.WindowsServices", and install it. If you'd rather use the .NET CLI, run the `dotnet add package` command:

```dotnetcli
dotnet add package Microsoft.Extensions.Hosting.WindowsServices
```

As part of the example source code for this tutorial, you'll need to also install the [`Microsoft.Extensions.Http` NuGet package](https://nuget.org/packages/Microsoft.Extensions.Http).

```dotnetcli
dotnet add package Microsoft.Extensions.Http
```

For more information on the .NET CLI add package command, see [`dotnet add package`](../tools/dotnet-add-package.md).

After successfully adding the packages, your project file should now contain the following package references:

:::code language="xml" source="snippets/workers/windows-service/App.WindowsService.csproj" range="14-18" highlight="2-4":::

## Update project file

This worker project makes use of C#'s [nullable reference types](../../csharp/nullable-references.md). To enable them for the entire project, update the project file accordingly:

:::code language="xml" source="snippets/workers/windows-service/App.WindowsService.csproj" range="1-7,12-20" highlight="5":::

The preceding project file changes add the `<Nullable>enable<Nullable>` node. For more information, see [Setting the nullable context](../../csharp/language-reference/builtin-types/nullable-reference-types.md#setting-the-nullable-context).

## Create the service

Add a new class to the project named *JokeService.cs*, and replace its contents with the following C# code:

:::code source="snippets/workers/windows-service/JokeService.cs":::

The preceding joke service source code exposes a single functionality, the `GetJokeAsync` method. This is a <xref:System.Threading.Tasks.Task%601> returning method where `T` is a `string`, and it represents a random programming joke. The <xref:System.Net.Http.HttpClient> is injected into the constructor and assigned to a class-scope `_httpClient` variable.

> [!TIP]
> The joke API is from an [open source project on GitHub](https://github.com/eklavyadev/karljoke). It is used for demonstration purposes, and we make no guarantee that it will be available in the future. To quickly test the API, open the following URL in a browser:
>
> ```http
> https://karljoke.herokuapp.com/jokes/programming/random.
> ```

## Rewrite the `Worker` class

Replace the existing `Worker` from the template with the following C# code, and rename the file to *WindowsBackgroundService.cs*:

:::code source="snippets/workers/windows-service/WindowsBackgroundService.cs":::

In the preceding code, the `JokeService` is injected along with an `ILogger`. Both are made available to the class as `private readonly` fields. In the `ExecuteAsync` method, the joke service requests a joke and writes it to the logger. In this case, the logger is implemented by the Windows Event Log - <xref:Microsoft.Extensions.Logging.EventLog.EventLogLogger?displayProperty=nameWithType>. Logs are written to, and available for viewing in the **Event Viewer**.

> [!NOTE]
> By default, the *Event Log* severity is <xref:Microsoft.Extensions.Logging.LogLevel.Warning>. This can be configured, but for demonstration purposes the `WindowsBackgroundService` logs with the <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> extension method. To specifically target the `EventLog` level, add an entry in the **appsettings.{Environment}.json**, or provide an <xref:Microsoft.Extensions.Logging.EventLog.EventLogSettings.Filter?displayProperty=nameWithType> value.
>
> ```json
> "Logging": {
>   "EventLog": {
>     "LogLevel": {
>       "Default": "Information"
>     }
>   }
> }
> ```
>
> For more information on configuring log levels, see [Logging providers in .NET: Configure Windows EventLog](logging-providers.md#windows-eventlog).

## Rewrite the `Program` class

Replace the template *Program.cs* file contents with the following C# code:

:::code source="snippets/workers/windows-service/Program.cs" highlight="4-7,10-11":::

The <xref:Microsoft.Extensions.Hosting.WindowsServiceLifetimeHostBuilderExtensions.UseWindowsService%2A> extension method configures the app to work as a Windows Service. The service name is set to `".NET Joke Service"`. The hosted service is registered, and the `HttpClient` is registered to the `JokeService` for dependency injection.

For more information on registering services, see [Dependency injection in .NET](dependency-injection.md).

## Publish the app

To create the .NET Worker Service app as a Windows Service, it's recommended that you publish the app as a single file executable. It's less error-prone to have a self-contained executable, as there aren't any dependent files lying around the file system. But you may choose a different publishing modality, which is perfectly acceptable, so long as you create an _*.exe_ file that can be targeted by the Windows Service Control Manager.

> [!IMPORTANT]
> An alternative publishing approach is to build the _*.dll_ (instead of an _*.exe_), and when you install the published app using the Windows Service Control Manager you delegate to the .NET CLI and pass the DLL. For more information, see [.NET CLI: dotnet command](../tools/dotnet.md).
>
> ```powershell
> sc.exe create ".NET Joke Service" binpath="C:\Path\To\dotnet.exe C:\Path\To\App.WindowsService.dll"
> ```

:::code language="xml" source="snippets/workers/windows-service/App.WindowsService.csproj" highlight="8-11":::

The preceding highlighted lines of the project file define the following behaviors:

- `<OutputType>exe</OutputType>`: Creates a console application.
- `<PublishSingleFile>true</PublishSingleFile>`: Enables single-file publishing.
- `<RuntimeIdentifier>win-x64</RuntimeIdentifier>`: Specifies the [RID](../rid-catalog.md) of `win-x64`.
- `<PlatformTarget>x64</PlatformTarget>`: Specify the target platform CPU of 64-bit.

To publish the app from Visual Studio, you can create a publish profile that is persisted. The publish profile is XML-based, and has the *.pubxml* file extension. Visual Studio uses this profile to publish the app implicitly, whereas if you're using the .NET CLI &mdash; you must explicitly specify the publish profile for it to be used.

Right-click on the project in the **Solution Explorer**, and select **Publish...**. Then, select **Add a publish profile** to create a profile. From the **Publish** dialog, select **Folder** as your **Target**.

:::image type="content" source="media/publish-dialog.png" lightbox="media/publish-dialog.png" alt-text="The Visual Studio Publish dialog":::

Leave the default **Location**, and then select **Finish**. Once the profile is created, select **Show all settings**, and verify your **Profile settings**.

:::image type="content" source="media/profile-settings.png" lightbox="media/profile-settings.png" alt-text="The Visual Studio Profile settings":::

Ensure that the following settings are specified:

- **Deployment mode**: Self-contained
- **Produce single file**: checked
- **Enable ReadyToRun compilation**: checked
- **Trim unused assemblies (in preview)**: unchecked

Finally, select **Publish**. The app is compiled, and the resulting .exe file is published to the */publish* output directory.

Alternatively, you could use the .NET CLI to publish the app:

```dotnetcli
dotnet publish --output "C:\custom\publish\directory"
```

For more information, see [`dotnet publish`](../tools/dotnet-publish.md).

## Create the Windows Service

To create the Windows Service, use the native Windows Service Control Manager's (sc.exe) create command. Run PowerShell as an Administrator.

```powershell
sc.exe create ".NET Joke Service" binpath="C:\Path\To\App.WindowsService.exe"
```

> [!TIP]
> If you need to change the content root of the [host configuration](./generic-host.md#host-configuration), you can pass it as a command-line argument when specifying the `binpath`:
>
> ```powershell
> sc.exe create "Svc Name" binpath="C:\Path\To\App.exe --contentRoot C:\Other\Path"
> ```

You'll see an output message:

```powershell
[SC] CreateService SUCCESS
```

For more information, see [sc.exe create](/windows-server/administration/windows-commands/sc-create).

### Configure the Windows Service

After the service is created, you can optionally configure it. If you're fine with the service defaults, skip to the [Verify service functionality](#verify-service-functionality) section.

Windows Services provide recovery configuration options. You can query the current configuration using the `sc.exe qfailure "<Service Name>"` (where `<Service Name>` is your services' name) command to read the current recovery configuration values:

```powershell
sc qfailure ".NET Joke Service"
[SC] QueryServiceConfig2 SUCCESS

SERVICE_NAME: .NET Joke Service
        RESET_PERIOD (in seconds)    : 0
        REBOOT_MESSAGE               :
        COMMAND_LINE                 :
```

The command will output the recovery configuration, which are the default values&mdash;since they've not yet been configured.

:::image type="content" source="media/windows-service-recovery-properties.png" alt-text="The Windows Service recovery configuration properties dialog.":::

To configure recovery, use the `sc.exe failure "<Service Name>"` where `<Service Name>` is the name of your service:

```powershell
sc.exe failure ".NET Joke Service" reset=0 actions=restart/60000/restart/60000/run/1000
[SC] ChangeServiceConfig2 SUCCESS
```

> [!TIP]
> To configure the recovery options, your terminal session needs to run as an Administrator.

After it's been successfully configured, you can query the values once again using the `sc.exe qfailure "<Service Name>"` command:

```powershell
sc qfailure ".NET Joke Service"
[SC] QueryServiceConfig2 SUCCESS

SERVICE_NAME: .NET Joke Service
        RESET_PERIOD (in seconds)    : 0
        REBOOT_MESSAGE               :
        COMMAND_LINE                 :
        FAILURE_ACTIONS              : RESTART -- Delay = 60000 milliseconds.
                                       RESTART -- Delay = 60000 milliseconds.
                                       RUN PROCESS -- Delay = 1000 milliseconds.
```

You will see the configured restart values.

:::image type="content" source="media/windows-service-recovery-properties-configured.png" alt-text="The Windows Service recovery configuration properties dialog with restart enabled.":::

## Verify service functionality

To see the app created as a Windows Service, open **Services**. Select the Windows key (or <kbd>Ctrl</kbd> + <kbd>Esc</kbd>), and search from "Services". From the **Services** app, you should be able to find your service by its name.

:::image type="content" source="media/windows-service.png" lightbox="media/windows-service.png" alt-text="The Services user interface.":::

To verify that the service is functioning as expected, you need to:

- Start the service
- View the logs
- Stop the service

> [!IMPORTANT]
> To debug the application, ensure that you're _not_ attempting to debug the executable that is actively running within the Windows Services process.
>
> :::image type="content" source="media/unable-to-debug-service.png" alt-text="Unable to start program.":::

### Start the Windows Service

To start the Windows Service, use the `sc.exe start` command:

```powershell
sc.exe start ".NET Joke Service"
```

You'll see output similar to the following:

```powershell
SERVICE_NAME: .NET Joke Service
    TYPE               : 10  WIN32_OWN_PROCESS
    STATE              : 2  START_PENDING
                            (NOT_STOPPABLE, NOT_PAUSABLE, IGNORES_SHUTDOWN)
    WIN32_EXIT_CODE    : 0  (0x0)
    SERVICE_EXIT_CODE  : 0  (0x0)
    CHECKPOINT         : 0x0
    WAIT_HINT          : 0x7d0
    PID                : 37636
    FLAGS
```

The service **Status** will transition out of `START_PENDING` to **Running**.

### View logs

To view logs, open the **Event Viewer**. Select the Windows key (or <kbd>Ctrl</kbd> + <kbd>Esc</kbd>), and search for `"Event Viewer"`. Select the **Event Viewer (Local)** > **Windows Logs** > **Application** node. You should see a **Warning** level entry with a **Source** matching the apps namespace. Double-click the entry, or right-click and select **Event Properties** to view the details.

:::image type="content" source="media/event-properties.png" lightbox="media/event-properties.png" alt-text="The Event Properties dialog, with details logged from the service":::

After seeing logs in the **Event Log**, you should stop the service. It's designed to log a random joke once per minute. This is intentional behavior but is _not_ practical for production services.

### Stop the Windows Service

To stop the Windows Service, use the `sc.exe stop` command:

```powershell
sc.exe stop ".NET Joke Service"
```

You'll see output similar to the following:

```powershell
SERVICE_NAME: .NET Joke Service
    TYPE               : 10  WIN32_OWN_PROCESS
    STATE              : 3  STOP_PENDING
                            (STOPPABLE, NOT_PAUSABLE, ACCEPTS_SHUTDOWN)
    WIN32_EXIT_CODE    : 0  (0x0)
    SERVICE_EXIT_CODE  : 0  (0x0)
    CHECKPOINT         : 0x0
    WAIT_HINT          : 0x0
```

The service **Status** will transition out of `STOP_PENDING` to **Stopped**.

## Delete the Windows Service

To delete the Windows Service, use the native Windows Service Control Manager's (sc.exe) delete command. Run PowerShell as an Administrator.

> [!IMPORTANT]
> If the service is not in the **Stopped** state, it will not be immediately deleted. Ensure that the service is stopped before issuing the delete command.

```powershell
sc.exe delete ".NET Joke Service"
```

You'll see an output message:

```powershell
[SC] DeleteService SUCCESS
```

For more information, see [sc.exe delete](/windows-server/administration/windows-commands/sc-delete).

## See also

- [Worker Services in .NET](workers.md)
- [Create a Queue Service](queue-service.md)
- [Use scoped services within a `BackgroundService`](scoped-service.md)
- [Implement the `IHostedService` interface](timer-service.md)
