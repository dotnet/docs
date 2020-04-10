---
title: Trim self-contained applications
description: Learn how to trim self-contained apps to reduce their size. .NET Core bundles the runtime with an app that is published self-contained and generally includes more of the runtime then is necessary.
author: jamshedd
ms.author: jamshedd
ms.date: 04/03/2020
---
# Trim self-contained deployments and executables

When publishing an application self-contained, the .NET Core runtime is bundled together with the application. This bundling adds a significant amount of content to your packaged application. When it comes to deploying your application, size is often an important factor. Keeping the size of the package application as small as possible is typically a goal for application developers.

Depending on the complexity of the application, only a subset of the runtime is required to run the application. These unused parts of the runtime are unnecessary and can be trimmed from the packaged application.

The trimming feature works by examining the application binaries to discover and build a graph of the required runtime assemblies. The remaining runtime assemblies that aren't referenced are excluded.

> [!NOTE]
> Trimming is an experimental feature in .NET Core 3.1 and is _only_ available to applications that are published self-contained.

## Prevent assemblies from being trimmed

There are scenarios in which the trimming functionality will fail to detect references. For example, when reflection is used on a runtime assembly, either by your application or a library that is referenced by your application, the assembly isn't directly referenced. Trimming is unaware of these indirect references and would exclude the library from the published folder.

When the code is indirectly referencing an assembly through reflection, you can prevent the assembly from being trimmed with the `<TrimmerRootAssembly>` setting. The following example shows how to prevent an assembly called `System.Security` assembly from being trimmed:

```xml
<ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```

## Trim your app - CLI

Trim your application using the [dotnet publish](../tools/dotnet-publish.md) command. When you publish your app, set the following three settings:

- Publish as self-contained: `--self-contained true`
- Disable single-file publishing: `-p:PublishSingleFile=false`
- Enable trimming: `p:PublishTrimmed=true`

The following example publishes an app for Windows 10 as self-contained and trims the output.

```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true -p:PublishSingleFile=false -p:PublishTrimmed=true
```

For more information, see [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).

## Trim your app - Visual Studio

Visual Studio creates reusable publishing profiles that control how your application is published.

01. On the **Solution Explorer** pane, right-click on the project you want to publish. Select **Publish...**.

    :::image type="content" source="media/trim-self-contained/visual-studio-solution-explorer.png" alt-text="Solution Explorer with a right-click menu highlighting the Publish option.":::

    If you don't already have a publishing profile, follow the instructions to create one and choose the **Folder** target-type.

01. Choose **Edit**.

    :::image type="content" source="media/trim-self-contained/visual-studio-publish-edit-settings.png" alt-text="Visual studio publish profile with edit button.":::

01. In the **Profile settings** dialog, set the following options:

    - Set **Deployment mode** to **Self-contained**.
    - Set **Target runtime** to the platform you want to publish to.
    - Select **Trim unused assemblies (in preview)**.

    Choose **Save** to save the settings and return to the **Publish** dialog.

    :::image type="content" source="media/trim-self-contained/visual-studio-publish-properties.png" alt-text="Profile settings dialog with deployment mode, target runtime, and trim unused assemblies options highlighted.":::

01. Choose **Publish** to publish your app trimmed.

For more information, see [Publish .NET Core apps with Visual Studio](deploy-with-vs.md).

## Trim your app - Visual Studio for Mac

Visual Studio for Mac doesn't provide options to trim your app during publish. You'll need to publish manually by following the instructions from the [Trim your app - CLI](#trim-your-app---cli) section. For more information, see [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).

## See also

- [.NET Core application deployment](index.md).
- [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).
- [Publish .NET Core apps with Visual Studio](deploy-with-vs.md).
- [dotnet publish command](../tools/dotnet-publish.md).
