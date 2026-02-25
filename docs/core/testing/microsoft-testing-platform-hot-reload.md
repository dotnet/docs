---
title: Microsoft.Testing.Platform Hot Reload
description: Learn about the Microsoft.Testing.Platform Hot Reload extension for running tests with hot reload.
author: evangelink
ms.author: amauryleve
ms.date: 02/25/2026
ai-usage: ai-assisted
---

# Hot Reload

This feature requires the [Microsoft.Testing.Extensions.HotReload](https://nuget.org/packages/Microsoft.Testing.Extensions.HotReload) NuGet package.

> [!TIP]
> When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild) (included transitively by MSTest, NUnit, and xUnit runners), this extension is auto-registered when you install its NuGet package — no code changes needed. The manual registration below is only required if you disabled the auto-generated entry point by setting `<GenerateTestingPlatformEntryPoint>false</GenerateTestingPlatformEntryPoint>`.

### Manual registration

```csharp
var builder = await TestApplication.CreateBuilderAsync(args);
builder.TestHost.AddHotReloadProvider();
```

## Hot reload

Hot reload lets you modify your app's managed source code while the application is running, without the need to manually pause or hit a breakpoint. Simply make a supported change while the app is running and select the **Apply code changes** button in Visual Studio to apply your edits.

> [!NOTE]
> The current version is limited to supporting hot reload in "console mode" only. There is currently no support for hot reload in Test Explorer for Visual Studio or Visual Studio Code.

> [!NOTE]
> The package is shipped with the restrictive Microsoft.Testing.Platform Tools license.
> The full license is available at <https://www.nuget.org/packages/Microsoft.Testing.Extensions.HotReload/1.0.0/License>.

You can easily enable hot reload support by setting the `TESTINGPLATFORM_HOTRELOAD_ENABLED` environment variable to `"1"`.

For SDK-style projects, you can add `"TESTINGPLATFORM_HOTRELOAD_ENABLED": "1"` in the `environmentVariables` section of the `launchSettings.json` file. The following snippet shows an example file:

```json
{
  "profiles": {
    "Contoso.MyTests": {
      "commandName": "Project",
      "environmentVariables": {
        "TESTINGPLATFORM_HOTRELOAD_ENABLED": "1"
      }
    }
  }
}
```
