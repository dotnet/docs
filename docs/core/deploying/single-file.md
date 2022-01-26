---
title: Single file application
description: Learn what single file application is and why you should consider using this application deployment model.
author: lakshanf
ms.author: lakshanf
ms.date: 08/10/2021
---
# Single file deployment and executable

Bundling all application-dependent files into a single binary provides an application developer with the attractive option to deploy and distribute the application as a single file. This deployment model has been available since .NET Core 3.0 and has been enhanced in .NET 5. Previously in .NET Core 3.0, when a user runs your single-file app, .NET Core host first extracts all files to a directory before running the application. .NET 5 improves this experience by directly running the code without the need to extract the files from the app.

Single File deployment is available for both the [framework-dependent deployment model](index.md#publish-framework-dependent) and [self-contained applications](index.md#publish-self-contained). The size of the single file in a self-contained application will be large since it will include the runtime and the framework libraries. The single file deployment option can be combined with [ReadyToRun](ready-to-run.md) and [Trim](trimming/trim-self-contained.md) publish options.

Single file deployment isn't compatible with Windows 7.

## Output differences from .NET 3.x

In .NET Core 3.x, publishing as a single file produced exactly one file, consisting of the app itself, dependencies, and any other files in the folder during publish. When the app starts, the single file app was extracted to a folder and run from there. Starting with .NET 5, only managed DLLs are bundled with the app into a single executable. When the app starts, the managed DLLs are extracted and loaded in memory, avoiding the extraction to a folder. On Windows, this means that the managed binaries are embedded in the single-file bundle, but the native binaries of the core runtime itself are separate files. To embed those files for extraction and get exactly one output file, like in .NET Core 3.x, set the property `IncludeNativeLibrariesForSelfExtract` to `true`. For more information about extraction, see [Including native libraries](#including-native-libraries).

## API incompatibility

Some APIs are not compatible with single-file deployment and applications may require modification if they use these APIs. If you use a third-party framework or package, it's possible that they may also use one of these APIs and need modification. The most common cause of problems is dependence on file paths for files or DLLs shipped with the application.

The table below has the relevant runtime library API details for single-file use.

| API                            | Note                                                                   |
|--------------------------------|------------------------------------------------------------------------|
| `Assembly.CodeBase`            | Throws <xref:System.PlatformNotSupportedException>.                    |
| `Assembly.EscapedCodeBase`     | Throws <xref:System.PlatformNotSupportedException>.                    |
| `Assembly.GetFile`             | Throws <xref:System.IO.IOException>.                                   |
| `Assembly.GetFiles`            | Throws <xref:System.IO.IOException>.                                   |
| `Assembly.Location`            | Returns an empty string.                                               |
| `AssemblyName.CodeBase`        | Returns `null`.                                                        |
| `AssemblyName.EscapedCodeBase` | Returns `null`.                                                        |
| `Module.FullyQualifiedName`    | Returns a string with the value of `<Unknown>` or throws an exception. |
| `Module.Name`                  | Returns a string with the value of `<Unknown>`.                        |

We have some recommendations for fixing common scenarios:

* To access files next to the executable, use <xref:System.AppContext.BaseDirectory?displayProperty=nameWithType>.

* To find the file name of the executable, use the first element of <xref:System.Environment.GetCommandLineArgs?displayProperty=nameWithType>, or starting with .NET 6 use the file name from <xref:System.Environment.ProcessPath>.

* To avoid shipping loose files entirely, consider using [embedded resources](../extensions/create-resource-files.md).

## Attaching a debugger

On Linux, the only debugger which can attach to self-contained single-file processes or debug crash dumps is [SOS with LLDB](../diagnostics/dotnet-sos.md).

On Windows and Mac, Visual Studio and VS Code can be used to debug crash dumps. Attaching to a running self-contained single-file executable requires an extra file: _mscordbi.{dll,so}_.

Without this file Visual Studio may produce the error "Unable to attach to the process. A debug component is not installed." and VS Code may produce the error "Failed to attach to process: Unknown Error: 0x80131c3c."

To fix these errors, _mscordbi_ needs to be copied next to the executable. _mscordbi_ is `publish`ed by default in the subdirectory with the application's runtime ID. So, for example, if one were to publish a self-contained single-file executable using the `dotnet` CLI for Windows using the parameters `-r win-x64`, the executable would be placed in _bin/Debug/net5.0/win-x64/publish_. A copy of _mscordbi.dll_ would be present in _bin/Debug/net5.0/win-x64_.

## Including native libraries

Single-file doesn't bundle native libraries by default. On Linux, we prelink the runtime into the bundle and only application native libraries are deployed to the same directory as the single-file app. On Windows, we prelink only the hosting code and both the runtime and application native libraries are deployed to the same directory as the single-file app. This is to ensure a good debugging experience, which requires native files to be excluded from the single file.

Starting with .NET 6 the runtime is prelinked into the bundle on all platforms.

There is an option to set a flag, `IncludeNativeLibrariesForSelfExtract`, to include native libraries in the single file bundle, but these files will be extracted to a directory in the client machine when the single file application is run.

Specifying `IncludeAllContentForSelfExtract` will extract all files (even the managed assemblies) before running the executable. This preserves the original .NET Core single-file deployment behavior.

> [!NOTE]
> If extraction is used the files are extracted to disk before the app starts:
>
> * If environment variable `DOTNET_BUNDLE_EXTRACT_BASE_DIR` is set to a path, the files will be extracted to a directory under that path.
> * Otherwise if running on Linux or MacOS, the files will be extracted to a directory under `$HOME/.net`.
> * If running on Windows, the files will be extracted to a directory under `%TEMP%/.net`.
>
> To prevent tampering, these directories should not be writable by users or services with different privileges, (so **not** _/tmp_ or _/var/tmp_ on most Linux and MacOS systems).

> [!NOTE]
> In some Linux environments (for example under *systemd*) the default extraction will not work because `$HOME` is not defined. In such cases it's recommended to set `$DOTNET_BUNDLE_EXTRACT_BASE_DIR` explicitly.
>
> For *systemd* a good alternative seems to be defining DOTNET_BUNDLE_EXTRACT_BASE_DIR in your service's unit file as `%h/.net`, which systemd expands correctly to `$HOME/.net` for the account running the service.
>
> ```
> [Service]
> Environment="DOTNET_BUNDLE_EXTRACT_BASE_DIR=%h/.net"
> ```

## Other considerations

Single-file application will have all related PDB files alongside it and will not be bundled by default. If you want to include PDBs inside the assembly for projects you build, set the `DebugType` to `embedded` as described [below](#include-pdb-files-inside-the-bundle) in detail.

Managed C++ components aren't well suited for single-file deployment and we recommend that you write applications in C# or another non-managed C++ language to be single-file compatible.

## Exclude files from being embedded

Certain files can be explicitly excluded from being embedded in the single-file by setting following metadata:

```xml
<ExcludeFromSingleFile>true</ExcludeFromSingleFile>
```

For example, to place some files in the publish directory but not bundle them in the single-file:

```xml
<ItemGroup>
  <Content Update="Plugin.dll">
    <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
    <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
  </Content>
</ItemGroup>
```

## Include PDB files inside the bundle

The PDB file for an assembly can be embedded into the assembly itself (the `.dll`) using the setting below. Since the symbols are part of the assembly, they will be part of the single-file application as well:

```xml
<DebugType>embedded</DebugType>
```

For example, add the following property to the project file of an assembly to embed the PDB file to that assembly:

```xml
<PropertyGroup>
  <DebugType>embedded</DebugType>
</PropertyGroup>
```

## Compress assemblies in single file app

Starting with .NET 6, single file apps can be created with compression enabled on the embedded assemblies. Set `EnableCompressionInSingleFile` property to `true` to achieve this. The produced single-file will have all of the embedded assemblies compressed which can significantly reduce the size of the executable. Compression comes with a performance cost. On application start, the assemblies must be decompressed into memory, which takes some time. It's recommended to measure both the size impact and startup cost impact of enabling compression before using it as the impact varies a lot between different applications.

## Publish a single file app - sample project file

Here's a sample project file that specifies single-file publishing:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>true</SelfContained>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PublishReadyToRun>true</PublishReadyToRun>
  </PropertyGroup>

</Project>
```

These properties have the following functions:

* `PublishSingleFile` - Enables single-file publishing. Also enables single-file warnings during `dotnet build`.
* `SelfContained` - Determines whether the app will be self-contained or framework-dependent.
* `RuntimeIdentifier` - Specifies the [OS and CPU type](../rid-catalog.md) you are targeting. Also sets `<SelfContained>true</SelfContained>` by default.
* `PublishReadyToRun` - Enables [ahead-of-time (AOT) compilation](ready-to-run.md).

**Notes:**

* Single-file apps are always OS and architecture-specific. You need to publish for each configuration, such as Linux x64, Linux ARM64, Windows x64, and so forth.
* Runtime configuration files, such as *\*.runtimeconfig.json* and *\*.deps.json*, are included in the single file. If an additional configuration file is needed, you can place it beside the single file.

## Publish a single file app - CLI

Publish a single file application using the [dotnet publish](../tools/dotnet-publish.md) command.

01. Add `<PublishSingleFile>true</PublishSingleFile>` to your project file.

    This will produce a single-file app on self-contained publish. It also shows single-file compatibility warnings during build.

    ```xml
    <PropertyGroup>
        <PublishSingleFile>true</PublishSingleFile>
    </PropertyGroup>
    ```

01. Publish the app as for a specific runtime identifier using `dotnet publish -r <RID>`

    The following example publishes the app for Windows as a self-contained single file application.

    `dotnet publish -r win-x64`

    The following example publishes the app for Linux as a framework dependent single file application.

    `dotnet publish -r linux-x64 --self-contained false`

`<PublishSingleFile>` should be set in the project file to enable single-file analysis during build, but it is also possible to pass these options as `dotnet publish` arguments:

```dotnetcli
dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false
```

For more information, see [Publish .NET Core apps with .NET CLI](deploy-with-cli.md).

## Publish a single file app - Visual Studio

Visual Studio creates reusable publishing profiles that control how your application is published.

01. Add `<PublishSingleFile>true</PublishSingleFile>` to your project file.

01. On the **Solution Explorer** pane, right-click on the project you want to publish. Select **Publish**.

    :::image type="content" source="media/single-file/visual-studio-solution-explorer.png" alt-text="Solution Explorer with a right-click menu highlighting the Publish option.":::

    If you don't already have a publishing profile, follow the instructions to create one and choose the **Folder** target-type.

01. Choose **Edit**.

    :::image type="content" source="media/single-file/visual-studio-publish-edit-settings.png" alt-text="Visual studio publish profile with edit button.":::

01. In the **Profile settings** dialog, set the following options:

    - Set **Deployment mode** to **Self-contained** or **Framework-dependent**.
    - Set **Target runtime** to the platform you want to publish to. (Must be something other than **Portable**.)
    - Select **Produce single file**.

    Choose **Save** to save the settings and return to the **Publish** dialog.

    :::image type="content" source="media/single-file/visual-studio-publish-single-file-properties.png" alt-text="Profile settings dialog with deployment mode, target runtime, and single file options highlighted.":::

01. Choose **Publish** to publish your app as a single file.

For more information, see [Publish .NET Core apps with Visual Studio](deploy-with-vs.md).

## Publish a single file app - Visual Studio for Mac

Visual Studio for Mac doesn't provide options to publish your app as a single file. You'll need to publish manually by following the instructions from the [Publish a single file app - CLI](#publish-a-single-file-app---cli) section. For more information, see [Publish .NET apps with .NET CLI](deploy-with-cli.md).

## See also

- [.NET Core application deployment](index.md).
- [Publish .NET apps with .NET CLI](deploy-with-cli.md).
- [Publish .NET Core apps with Visual Studio](deploy-with-vs.md).
- [`dotnet publish` command](../tools/dotnet-publish.md).
