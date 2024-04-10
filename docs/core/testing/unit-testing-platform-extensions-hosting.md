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

With Hot Reload you can now modify your apps managed source code while the application is running, without the need to manually pause or hit a breakpoint. Simply make a supported change while your app is running and in our new Visual Studio experience use the `apply code changes` button to apply your edits.

> [!NOTE]
> Current version is limited to supporting hot reload in "console mode" only. There is currently no support for Hot Reload in Test Explorer for Visual Studio or Visual Studio Code.

This extension is shipped as part of [Microsoft.Testing.Extensions.HotReload](https://nuget.org/packages/Microsoft.Testing.Extensions.HotReload) package.

> [!NOTE]
> The package is shipped with the restrictive Microsoft Testing Platform Tools license.
> Full license available at <https://www.nuget.org/packages/Microsoft.Testing.Extensions.HotReload/1.0.0/License>.

You can easily enable Hot Reload support by setting the `TESTINGPLATFORM_HOTRELOAD_ENABLED` environment variable to `"1"`.

For SDK-style projects, this is usually achieved by adding `"TESTINGPLATFORM_HOTRELOAD_ENABLED": "1"` in the `environmentVariables` section of the `launchSettings.json` file. You can find a full example of this file below:

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
