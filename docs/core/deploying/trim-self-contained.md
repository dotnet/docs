---
title: Trim self-contained applications
description: Learn how to trim self-contained apps to reduce their size. .NET Core bundles the runtime with an app that is published self-contained and generally includes more of the runtime then is necessary.
author: jamshedd
ms.author: jamshedd
ms.date: 04/03/2020
---
# Trim self-contained deployments and executables

The [framework-dependent deployment model](index.md#publish-framework-dependent) has been the most successful deployment model since the inception of .NET. In this scenario, the application developer bundles only the application and third-party assemblies with the expectation that the .NET runtime and framework libraries will be available in the client machine. This deployment model continues to be the dominant one in .NET Core as well but there are some scenarios where the framework-dependent model is not optimal. The alternative is to publish a [self-contained application](index.md#publish-self-contained), where the .NET Core runtime and framework are bundled together with the application and third-party assemblies.

The trim-self-contained deployment model is a specialized version of the self-contained deployment model that is optimized to reduce deployment size. Minimizing deployment size is a critical requirement for some client-side scenarios like Blazor applications. Depending on the complexity of the application, only a subset of the framework assemblies are required to run the application. These unused parts of the library are unnecessary and can be trimmed from the packaged application. However, there is a risk that the build time analysis of the application can cause failures at runtime, due to not being able to reliably analyze various problematic code patterns (largely centered on reflection use). Because reliability can't be guaranteed, this deployment model is offered as a preview feature. The build time analysis engine provides warnings to the developer of code patterns that are problematic, with the expectation that these code patterns will be fixed. Where possible, we recommend that you move any runtime reflection dependencies in your application to build time by using code that meets the same requirements.

The trim mode for the applications can be configured via the TrimMode and will default (`copyused`) to bundle assemblies that are used in the application. Blazor WebAssembly applications will use a more aggressive mode (`link`) that will trim unused code within assemblies. Trim analysis warnings give information on code patterns where a full dependency analysis was not possible. These warnings are suppressed by default and can be turned on by setting the flag, `SuppressTrimAnalysisWarnings`, to false. More information on the trim options available can be found at the [ILLinker page](https://github.com/mono/linker/blob/master/docs/illink-options.md).


> [!NOTE]
> Trimming is an experimental feature in .NET Core 3.1, 5.0 and is _only_ available to applications that are published self-contained.

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
- Enable trimming: `p:PublishTrimmed=true`

The following example publishes an app for Windows as self-contained and trims the output.

```xml
<ItemGroup>
    <RuntimeIdentifier>win-x64</RuntimeIdentifier>
    <SelfContained>true</SelfContained>
    <PublishTrimmed>true</PublishTrimmed>
</ItemGroup>
```

The following example publishes an app in the aggressive trim mode where unused code withing assemblies will be trimmed and  trimmer warnings enabled.

```xml
<ItemGroup>
    <TrimMode>link</TrimMode>
    <SuppressTrimAnalysisWarnings>false</SuppressTrimAnalysisWarnings>
</ItemGroup>
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
