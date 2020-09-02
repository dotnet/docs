---
title: Single file application
description: Learn what single file application is and why you should consider using this application deployment model.
author: lakshanf
ms.author: lakshanf
ms.date: 08/28/2020
---
# Single file deployment and executable

Bundling all application-dependent files into a single binary provides an application developer with the attractive option to deploy and distribute the application as a single file. This deployment model has been available since .NET Core 3.0 and has been enhanced in .NET 5.0 where the code is directly executed from the single file in the client machine. On the .NET Core 3.0 version, all files were first self-extracted into a temporary location before running.

Single File deployment is available for both [framework-dependent deployment model](index.md#publish-framework-dependent) and [self-contained application](index.md#publish-self-contained). The size of the single file in a self-contained application will be large since it will include the runtime and the framework libraries. The single file deployment option can be combined with [Trim](trim-self-contained.md) and [ReadyToRun](../tools/dotnet-publish.md) publish options.

There are some caveats that you need to be aware for single-file use, chief of which is the use path information to locate a file relative to the location of your application. [Assembly.Location](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.location?view=netcore-3.1) API will return an empty string, which is the default behavior for assemblies loaded from memory. The compiler will give a warning for this API during build time to alert the developer to the specific behavior. If the path to the application directory is needed, [AppContext.BaseDirectory](https://docs.microsoft.com/en-us/dotnet/api/system.appcontext.basedirectory?view=netcore-3.1) API will return the directory where the AppHost (the single-file bundle itself) resides. Managed C++ applications are not well suited for single-file deployment and we recommend that you write applications in C# to be single-file compatible.

[Self-contained application](index.md#publish-self-contained) single-file option will not bundle native libraries on MacOS and Windows machines for .NET 5.0. This is to ensure a good debugging experience and require native files not to be included in the single file. Linux will have all files bundled in .NET 5.0 and will execute the application from single file. Windows and MacOS machines will have an option to set a flag, `IncludeNativeLibrariesForSelfExtract`, to include native libraries in the single file bundle but these files will be extracted to a temporary directory in the client machine when the single file application is run.

## Exclude files being embedded in Single File

Certain files can be explicitly excluded from being embedded in the single-file by setting following meta-data:

```xml
<ExcludeFromSingleFile>true</ExcludeFromSingleFile>
```

For example, to place some files in the publish directory but not bundle them in the single-file:

```xml
<ItemGroup>
    <Content Update="*.xml">
      <CopyToPublishDirectory>PreserveNewest</CopyToPublishDirectory>
      <ExcludeFromSingleFile>true</ExcludeFromSingleFile>
    </Content>
  </ItemGroup>

```

## Publish a Single File app - CLI

Publish a single file application using the [dotnet publish](../tools/dotnet-publish.md) command. When you publish your app, set the following properties:

- Publish as a self-contained app for a specific runtime: `-r win-x64`
- Enable trimming: `/p:PublishSingleFile=true`

The following example publishes an app for Windows as a self-contained single file application.

```xml
<PropertyGroup>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>true</SelfContained>
</PropertyGroup>
```

The following example publishes an app for Linux as a framework dependent single file application..

```xml
<PropertyGroup>
    <RuntimeIdentifier>linux-x64</RuntimeIdentifier>
    <PublishSingleFile>true</PublishSingleFile>
    <SelfContained>false</SelfContained>
</PropertyGroup>
```

For more information, see [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).

## Publish a Single File app - Visual Studio

Visual Studio creates reusable publishing profiles that control how your application is published.

01. On the **Solution Explorer** pane, right-click on the project you want to publish. Select **Publish...**.

    :::image type="content" source="media/trim-self-contained/visual-studio-solution-explorer.png" alt-text="Solution Explorer with a right-click menu highlighting the Publish option.":::

    If you don't already have a publishing profile, follow the instructions to create one and choose the **Folder** target-type.

01. Choose **Edit**.

    :::image type="content" source="media/trim-self-contained/visual-studio-publish-edit-settings.png" alt-text="Visual studio publish profile with edit button.":::

01. In the **Profile settings** dialog, set the following options:

    - Set **Deployment mode** to **Self-contained**.
    - Set **Target runtime** to the platform you want to publish to.
    - Select **Produce single file**.

    Choose **Save** to save the settings and return to the **Publish** dialog.

    :::image type="content" source="media/single-file/visual-studio-publish-single-file-properties.png" alt-text="Profile settings dialog with deployment mode, target runtime, and single file options highlighted.":::

01. Choose **Publish** to publish your app as a single file.

For more information, see [Publish .NET Core apps with Visual Studio](deploy-with-vs.md).

## Publish a Single File app - Visual Studio for Mac

Visual Studio for Mac doesn't provide options to publish your app as a single file. You'll need to publish manually by following the instructions from the [Publish a Single File app - CLI](#publish-a-single-file-app---cli) section. For more information, see [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).

## See also

- [.NET Core application deployment](index.md).
- [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).
- [Publish .NET Core apps with Visual Studio](deploy-with-vs.md).
- [dotnet publish command](../tools/dotnet-publish.md).
