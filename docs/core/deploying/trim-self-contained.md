---
title: Trim self-contained applications
description: Learn how to trim self-contained apps to reduce their size. .NET Core bundles the runtime with an app that is published self-contained and generally includes more of the runtime then is necessary.
author: jamshedd
ms.author: jamshedd
ms.date: 04/03/2020
---
# Trim self-contained deployments and executables

The [framework-dependent deployment model](index.md#publish-framework-dependent) has been the most successful deployment model since the inception of .NET. In this scenario, the application developer bundles only the application and third-party assemblies with the expectation that the .NET runtime and runtime libraries will be available in the client machine. This deployment model continues to be the dominant one in the latest .NET release, however, there are some scenarios where the framework-dependent model is not the best choice. The alternative is to publish a [self-contained application](index.md#publish-self-contained), where the .NET runtime and runtime libraries are bundled together with the application and third-party assemblies.

The trim-self-contained deployment model is a specialized version of the self-contained deployment model that is optimized to reduce deployment size. Minimizing deployment size is a critical requirement for some client-side scenarios like Blazor applications. Depending on the complexity of the application, only a subset of the framework assemblies are referenced, and a subset of the code within each assembly is required to run the application. The unused parts of the libraries are unnecessary and can be trimmed from the packaged application.

However, there is a risk that the build time analysis of the application can cause failures at runtime, due to not being able to reliably analyze various problematic code patterns (largely centered on reflection use). Because reliability can't be guaranteed, this deployment model is offered as a preview feature.

The build time analysis engine provides warnings to the developer of code patterns that are problematic to detect which other code is required. Code can be annotated with attributes to tell the trimmer what else to include. Many reflection patterns can be replaced with build-time code generation using [Source Generators](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.md).

The trim mode for the applications is configured with the `TrimMode` setting. The default value is `copyused` and bundles referenced assemblies with the application. The `link` value is used with Blazor WebAssembly applications and trims unused code within assemblies. Trim analysis warnings give information on code patterns where a full dependency analysis was not possible. These warnings are suppressed by default and can be turned on by setting the flag `SuppressTrimAnalysisWarnings` to `false`. For more information about the trim options available, see [Trimming options](trimming-options.md).

> [!NOTE]
> Trimming is an experimental feature in .NET Core 3.1 and .NET 5.0. Trimming is _only_ available to applications that are published self-contained.

## Components that cause trimming problems

Any code that causes build time analysis challenges, isn't suitable for trimming. Some common coding patterns that are problematic when used by an application, originate from unbounded reflection usage and external dependencies that aren't visible at build time. An example of unbounded reflection is a legacy serializer, such as [XML serialization](../../standard/serialization/introducing-xml-serialization.md) and example of invisible external dependencies is [built-in COM](../../standard/native-interop/cominterop.md). Any Windows desktop applications that depend on built-in COM support might have challenges with trimming. This includes Windows Forms and Windows Presentation Foundation (WPF) applications. The trimming engine generates warnings during build time when it detects code in an application that uses problematic coding patterns. For more information, see [Prepare .NET libraries for trimming](prepare-libraries-for-trimming.md).

## Prevent assemblies from being trimmed

There are scenarios in which the trimming functionality will fail to detect references. For example, when reflection is used on a runtime assembly, either by your application or a library that is referenced by your application, the assembly isn't directly referenced. Trimming is unaware of these indirect references and would exclude the library from the published folder.

When the code is indirectly referencing an assembly through reflection, you can prevent the assembly from being trimmed with the `<TrimmerRootAssembly>` setting. The following example shows how to prevent an assembly called `System.Security` assembly from being trimmed:

```xml
<ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```

## Trim your app - CLI

Trim your application using the [dotnet publish](../tools/dotnet-publish.md) command.

01. Add `<PublishTrimmed>true</PublishTrimmed>` to your project file.

    This will produce a trimmed app on self-contained publish. It also turns off trim-incompatible features and shows trim compatibility warnings during build.

    ```xml
    <PropertyGroup>
        <PublishTrimmed>true</PublishTrimmed>
    </PropertyGroup>
    ```

01. Publish a self-contained app for a specific runtime identifier using `dotnet publish -r <RID>`

    The following example publishes the app for Windows as trimmed self-contained application.

    `dotnet publish -r win-x64`

    Note that trimming is only supported for self-contained apps.

The following example configures an app in the aggressive trim mode where unused code within assemblies will be trimmed and trimmer warnings enabled.

```xml
<PropertyGroup>
    <PublishTrimmed>true</PublishTrimmed>
    <SuppressTrimAnalysisWarnings>false</SuppressTrimAnalysisWarnings>
    
    <!--
        Enable aggressive trimming for assemblies marked as trimmable.
        This is the default behavior for .NET 6 and above.
        The line is only needed when targeting < .NET 6.
    -->
    <TrimMode>link</TrimMode>
    
    <!--
        Enable aggressive trimming for all assemblies.
        This setting is new in .NET 6.
    -->
    <TrimmerDefaultAction>link</TrimmerDefaultAction>
</PropertyGroup>
```

`<PublishTrimmed>` should be set in the project file so that trim-incompatible features are disabled during `dotnet build`, but it is also possible to pass these options as `dotnet publish` arguments:

`dotnet publish -r win-x64 -p:PublishTrimmed=true`

For more information, see [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md).

## Trim your app - Visual Studio

Visual Studio creates reusable publishing profiles that control how your application is published.

01. Add `<PublishTrimmed>true</PublishTrimmed>` to your project file.

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
