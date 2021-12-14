---
title: Trim self-contained applications
description: Learn how to trim self-contained apps to reduce their size. .NET Core bundles the runtime with an app that is published self-contained and generally includes more of the runtime then is necessary.
author: jamshedd
ms.author: jamshedd
ms.date: 04/03/2020
---
# Trim self-contained deployments and executables

The [framework-dependent deployment model](../index.md#publish-framework-dependent) has been the most successful deployment model since the inception of .NET. In this scenario, the application developer bundles only the application and third-party assemblies with the expectation that the .NET runtime and runtime libraries will be available in the client machine. This deployment model continues to be the dominant one in the latest .NET release, however, there are some scenarios where the framework-dependent model is not the best choice. The alternative is to publish a [self-contained application](../index.md#publish-self-contained), where the .NET runtime and runtime libraries are bundled together with the application and third-party assemblies.

The trim-self-contained deployment model is a specialized version of the self-contained deployment model that is optimized to reduce deployment size. Minimizing deployment size is a critical requirement for some client-side scenarios like Blazor applications. Depending on the complexity of the application, only a subset of the framework assemblies are referenced, and a subset of the code within each assembly is required to run the application. The unused parts of the libraries are unnecessary and can be trimmed from the packaged application.

However, there is a risk that the build-time analysis of the application can cause failures at run time, due to not being able to reliably analyze various problematic code patterns (largely centered on reflection use). To mitigate these problems, warnings are produced whenever the trimmer cannot fully analyze a code pattern. For information on what the trim warnings mean and how to resolve them, see [Introduction to trim warnings](fixing-warnings.md).

> [!NOTE]
> Trimming is only supported in .NET 6+.

## Components that cause trimming problems

> [!WARNING]
> Not all project types can be trimmed. For more information, see [Known trimming incompatibilities](incompatibilities.md).

Any code that causes build time analysis challenges isn't suitable for trimming. Some common coding patterns that are problematic when used by an application originate from unbounded reflection usage and external dependencies that aren't visible at build time. An example of unbounded reflection is a legacy serializer, such as [XML serialization](../../../standard/serialization/introducing-xml-serialization.md) and an example of invisible external dependencies is [built-in COM](../../../standard/native-interop/cominterop.md). To address trim warnings in your application, see [Introduction to trim warnings](fixing-warnings.md), and to make your library compatible with trimming, see [Prepare .NET libraries for trimming](prepare-libraries-for-trimming.md).

## Enabling trimming

01. Add `<PublishTrimmed>true</PublishTrimmed>` to your project file.

    This will produce a trimmed app on self-contained publish. It also turns off trim-incompatible features and shows trim compatibility warnings during build.

    ```xml
    <PropertyGroup>
        <PublishTrimmed>true</PublishTrimmed>
    </PropertyGroup>
    ```

02. Then publish your app using either the [dotnet publish](../../tools/dotnet-publish.md) command or Visual Studio.

### Publishing with the CLI

The following example publishes the app for Windows as a trimmed self-contained application.

`dotnet publish -r win-x64`

Trimming is only supported for self-contained apps.

`<PublishTrimmed>` should be set in the project file so that trim-incompatible features are disabled during `dotnet build`, but it is also possible to pass these options as `dotnet publish` arguments:

`dotnet publish -r win-x64 -p:PublishTrimmed=true`

For more information, see [Publish .NET apps with .NET CLI](../deploy-with-cli.md).

### Publishing with Visual Studio

01. On the **Solution Explorer** pane, right-click on the project you want to publish. Select **Publish...**.

    :::image type="content" source="../media/trim-self-contained/visual-studio-solution-explorer.png" alt-text="Solution Explorer with a right-click menu highlighting the Publish option.":::

    If you don't already have a publishing profile, follow the instructions to create one and choose the **Folder** target-type.

01. Choose **Edit**.

    :::image type="content" source="../media/trim-self-contained/visual-studio-publish-edit-settings.png" alt-text="Visual studio publish profile with edit button.":::

01. In the **Profile settings** dialog, set the following options:

    - Set **Deployment mode** to **Self-contained**.
    - Set **Target runtime** to the platform you want to publish to.
    - Select **Trim unused assemblies (in preview)**.

    Choose **Save** to save the settings and return to the **Publish** dialog.

    :::image type="content" source="../media/trim-self-contained/visual-studio-publish-properties.png" alt-text="Profile settings dialog with deployment mode, target runtime, and trim unused assemblies options highlighted.":::

01. Choose **Publish** to publish your app trimmed.

For more information, see [Publish .NET Core apps with Visual Studio](../deploy-with-vs.md).

### Publishing with Visual Studio for Mac

Visual Studio for Mac doesn't provide options to publish your app. You'll need to publish manually by following the instructions from the [Publishing with the CLI](#publishing-with-the-cli) section. For more information, see [Publish .NET apps with .NET CLI](../deploy-with-cli.md).

## See also

- [.NET Core application deployment](../index.md).
- [Publish .NET apps with .NET CLI](../deploy-with-cli.md).
- [Publish .NET Core apps with Visual Studio](../deploy-with-vs.md).
- [dotnet publish command](../../tools/dotnet-publish.md).
