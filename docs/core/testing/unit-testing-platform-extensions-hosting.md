---
title: Microsoft.Testing.Platform hosting extensions
description: Learn about the various Microsoft.Testing.Platform hosting extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
---

# Hosting extensions

This article list and explains all `Microsoft Testing Platform` extensions related to the hosting capability.

## Hot reload

Hot reload lets you modify your app's managed source code while the application is running, without the need to manually pause or hit a breakpoint. Simply make a supported change while the app is running and select the **Apply code changes** button in Visual Studio to apply your edits.

> [!NOTE]
> The current version is limited to supporting hot reload in "console mode" only. There is currently no support for hot reload in Test Explorer for Visual Studio or Visual Studio Code.

This extension is shipped as part of the [Microsoft.Testing.Extensions.HotReload](https://nuget.org/packages/Microsoft.Testing.Extensions.HotReload) package.

> [!NOTE]
> The package is shipped with the restrictive Microsoft Testing Platform Tools license.
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
