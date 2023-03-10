---
title: Create a single file for application deployment
description: Learn what single file application is and why you should consider using this application deployment model.
author: lakshanf
ms.author: lakshanf
ms.date: 06/21/2022
ms.custom: kr2b-contr-experiment
---

# Single-file deployment

Bundling all application-dependent files into a single binary provides an application developer with the attractive option to deploy and distribute the application as a single file. Single-file deployment is available for both the [framework-dependent deployment model](../index.md#publish-framework-dependent) and [self-contained applications](../index.md#publish-self-contained).

The size of the single file in a self-contained application is large since it includes the runtime and the framework libraries. In .NET 6, you can [publish trimmed](../trimming/trim-self-contained.md) to reduce the total size of trim-compatible applications. The single file deployment option can be combined with [ReadyToRun](../ready-to-run.md) and [Trim](../trimming/trim-self-contained.md) publish options.

Single file deployment isn't compatible with Windows 7.

## Sample project file

Here's a sample project file that specifies single file publishing:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>true</SelfContained>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
  </PropertyGroup>

</Project>
```

These properties have the following functions:

- `PublishSingleFile`. Enables single file publishing. Also enables single file warnings during `dotnet build`.
- `SelfContained`. Determines whether the app is self-contained or framework-dependent.
- `RuntimeIdentifier`. Specifies the [OS and CPU type](../../rid-catalog.md) you're targeting. Also sets `<SelfContained>true</SelfContained>` by default.

Single file apps are always OS and architecture specific. You need to publish for each configuration, such as Linux x64, Linux Arm64, Windows x64, and so forth.

Runtime configuration files, such as _\*.runtimeconfig.json_ and _\*.deps.json_, are included in the single file. If an extra configuration file is needed, you can place it beside the single file.

## Publish a single-file app

# [CLI](#tab/cli)

Publish a single file application using the [dotnet publish](../../tools/dotnet-publish.md) command.

1. Add `<PublishSingleFile>true</PublishSingleFile>` to your project file.

   This change produces a single file app on self-contained publish. It also shows single file compatibility warnings during build.

   ```xml
   <PropertyGroup>
       <PublishSingleFile>true</PublishSingleFile>
   </PropertyGroup>
    ```

1. Publish the app for a specific runtime identifier using `dotnet publish -r <RID>`

   The following example publishes the app for Windows as a self-contained single file application.

   `dotnet publish -r win-x64`

   The following example publishes the app for Linux as a framework dependent single file application.

   `dotnet publish -r linux-x64 --self-contained false`

`<PublishSingleFile>` should be set in the project file to enable file analysis during build, but it's also possible to pass these options as `dotnet publish` arguments:

```dotnetcli
dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false
```

For more information, see [Publish .NET Core apps with .NET CLI](../deploy-with-cli.md).

# [Visual Studio](#tab/vs)

Visual Studio creates reusable publishing profiles that control how your application is published.

1. Add `<PublishSingleFile>true</PublishSingleFile>` to your project file.

1. On the **Solution Explorer** pane, right-click on the project you want to publish. Select **Publish**.

   :::image type="content" source="../media/single-file/visual-studio-solution-explorer.png" alt-text="Screenshot shows Solution Explorer with a context menu highlighting the Publish option.":::

   If you don't already have a publishing profile, follow the instructions to create one and choose the **Folder** target-type.

1. Choose **Edit**.

   :::image type="content" source="../media/single-file/visual-studio-publish-edit-settings.png" alt-text="Screenshot shows Visual Studio Publish profile with Edit button highlighted.":::

1. In the **Profile settings** dialog, set the following options:

   - Set **Deployment mode** to **Self-contained** or **Framework-dependent**.
   - Set **Target runtime** to the platform you want to publish to. Must be something other than **Portable**.
   - Select **Produce single file**.

   Choose **Save** to save the settings and return to the **Publish** dialog.

   :::image type="content" source="../media/single-file/visual-studio-publish-single-file-properties.png" alt-text="Screenshot shows Profile settings dialog with Deployment mode, Target runtime, and Produce single file options highlighted.":::

1. Choose **Publish** to publish your app as a single file.

For more information, see [Publish .NET Core apps with Visual Studio](../deploy-with-vs.md).

# [Visual Studio for Mac](#tab/vsmac)

Visual Studio for Mac doesn't provide options to publish your app as a single file. You'll need to publish manually by following the instructions from the CLI tab. For more information, see [Publish .NET apps with .NET CLI](../deploy-with-cli.md).

---

## Exclude files from being embedded

Certain files can be explicitly excluded from being embedded in the single file by setting following metadata:

```xml
<ExcludeFromSingleFile>true</ExcludeFromSingleFile>
```

For example, to place some files in the publish directory but not bundle them in the file:

```xml
<ItemGroup>
  <Content Update="Plugin.dll">
    <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
    <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
  </Content>
</ItemGroup>
```

## Include PDB files inside the bundle

The PDB file for an assembly can be embedded into the assembly itself (the `.dll`) using the setting below. Since the symbols are part of the assembly, they're part of the application as well:

```xml
<DebugType>embedded</DebugType>
```

For example, add the following property to the project file of an assembly to embed the PDB file to that assembly:

```xml
<PropertyGroup>
  <DebugType>embedded</DebugType>
</PropertyGroup>
```

## Other considerations

Single file applications have all related PDB files alongside the application, not bundled by default. If you want to include PDBs inside the assembly for projects you build, set the `DebugType` to `embedded`. See [Include PDB files inside the bundle](#include-pdb-files-inside-the-bundle).

Managed C++ components aren't well suited for single file deployment. We recommend that you write applications in C# or another non-managed C++ language to be single file compatible.

### Native libraries

Only managed DLLs are bundled with the app into a single executable. When the app starts, the managed DLLs are extracted and loaded in memory, avoiding the extraction to a folder. This approach means that the managed binaries are embedded in the single file bundle, but the native binaries of the core runtime itself are separate files.

To embed those files for extraction and get one output file, set the property `IncludeNativeLibrariesForSelfExtract` to `true`. For more information about extraction, see [Including native libraries](#include-native-libraries).

Specifying `IncludeAllContentForSelfExtract` extracts all files, including the managed assemblies, before running the executable. This may be helpful for rare application compatibility problems.

 [!NOTE]
> If extraction is used, the files are extracted to disk before the app starts:
>
> - If environment variable `DOTNET_BUNDLE_EXTRACT_BASE_DIR` is set to a path, the files are extracted to a directory under that path.
> - Otherwise, if running on Linux or MacOS, the files are extracted to a directory under `$HOME/.net`.
> - If running on Windows, the files are extracted to a directory under `%TEMP%/.net`.
>
> To prevent tampering, these directories should not be writable by users or services with different privileges. Don't use _/tmp_ or _/var/tmp_ on most Linux and MacOS systems.

> [!NOTE]
> In some Linux environments, such as under `systemd`, the default extraction does not work because `$HOME` is not defined. In such cases, we recommend that you set `$DOTNET_BUNDLE_EXTRACT_BASE_DIR` explicitly.
>
> For `systemd`, a good alternative seems to be defining `DOTNET_BUNDLE_EXTRACT_BASE_DIR` in your service's unit file as `%h/.net`, which `systemd` expands correctly to `$HOME/.net` for the account running the service.
>
> ```text
> [Service]
> Environment="DOTNET_BUNDLE_EXTRACT_BASE_DIR=%h/.net"
> ```
>

### API incompatibility

Some APIs aren't compatible with single file deployment. Applications might require modification if they use these APIs. If you use a third-party framework or package, it's possible that they might use one of these APIs and need modification. The most common cause of problems is dependence on file paths for files or DLLs shipped with the application.

The table below has the relevant runtime library API details for single file use.

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
| `Marshal.GetHINSTANCE`         | Returns -1.                                                            |
| `Module.Name`                  | Returns a string with the value of `<Unknown>`.                        |

We have some recommendations for fixing common scenarios:

- To access files next to the executable, use <xref:System.AppContext.BaseDirectory?displayProperty=nameWithType>.

- To find the file name of the executable, use the first element of <xref:System.Environment.GetCommandLineArgs?displayProperty=nameWithType>, or starting with .NET 6, use the file name from <xref:System.Environment.ProcessPath>.

- To avoid shipping loose files entirely, consider using [embedded resources](../../extensions/create-resource-files.md).

### Post-processing binaries before bundling

Some workflows require post-processing of binaries before bundling. A common example is signing. The dotnet SDK provides MSBuild extension points to allow processing binaries just before single-file bundling. The available APIs are:

* A target `PrepareForBundle` that will be called before `GenerateSingleFileBundle`
* An ItemGroup `FilesToBundle` containing all files that will be bundled
* A Property `AppHostFile` that will specify the apphost template. Post-processing might want to exclude the apphost from processing.

The way to plug into this would typically involve creating a target that will be executed between PrepareForBundle and GenerateSingleFileBundle

Example:

```xml
<Target Name="MySignedBundledFile" BeforeTargets="GenerateSingleFileBundle" DependsOnTargets="PrepareForBundle">
```

It is possible that tooling will need to copy files in the process of signing. That could happen if the original file is a shared item not owned by the build, for example the file comes from a nuget cache. In such case it is expected that the tool will modify the path of the corresponding FilesToBundle item to point to the modified copy.

### Compress assemblies in single-file apps

Single file apps can be created with compression enabled on the embedded assemblies. Set the `EnableCompressionInSingleFile` property to `true`. The single file that's produced will have all of the embedded assemblies compressed, which can significantly reduce the size of the executable.

Compression comes with a performance cost. On application start, the assemblies must be decompressed into memory, which takes some time. We recommend that you measure both the size change and startup cost of enabling compression before using it. The impact can vary significantly between different applications.

## See also

- [.NET Core application deployment](../index.md)
- [Publish .NET apps with .NET CLI](../deploy-with-cli.md)
- [Publish .NET Core apps with Visual Studio](../deploy-with-vs.md)
- [`dotnet publish` command](../../tools/dotnet-publish.md)
