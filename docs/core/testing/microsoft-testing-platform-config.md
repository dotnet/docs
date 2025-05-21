---
title: Microsoft.Testing.Platform config options
description: Learn how to configure Microsoft.Testing.Platform using configuration settings.
author: Evangelink
ms.author: amauryleve
ms.date: 08/15/2024
ms.topic: article
---

# Microsoft.Testing.Platform configuration settings

Microsoft.Testing.Platform supports the use of configuration files and environment variables to configure the behavior of the test platform. This article describes the configuration settings that you can use to configure the test platform.

## testconfig.json

The test platform uses a configuration file named *[appname].testconfig.json* to configure the behavior of the test platform. The *testconfig.json* file is a JSON file that contains configuration settings for the test platform.

The *testconfig.json* file has the following structure:

```json
{
    "platformOptions": {
        "config-property-name1": "config-value1",
        "config-property-name2": "config-value2"
    }
}
```

The platform will automatically detect and load the *[appname].testconfig.json* file located in the output directory of the test project (close to the executable).

When using [Microsoft.Testing.Platform.MSBuild](https://www.nuget.org/packages/Microsoft.Testing.Platform.MSBuild), you can simply create a *testconfig.json* file that will be automatically renamed to *[appname].testconfig.json* and moved to the output directory of the test project.

Starting with Microsoft.Testing.Platform 1.5, you can use the command-line argument `--config-file` to specify the path to the *testconfig.json*. This file takes precedence over the *[appname].testconfig.json* file.

> [!NOTE]
> The *[appname].testconfig.json* file will get overwritten on subsequent builds.

## Environment variables

Environment variables can be used to supply some runtime configuration information.

> [!NOTE]
> Environment variables take precedence over configuration settings in the *testconfig.json* file.

### `TESTINGPLATFORM_UI_LANGUAGE` environment variable

Starting with Microsoft.Testing.Platform 1.5, this environment variable sets the language of the platform for displaying messages and logs using a locale value such as `en-us`. This language takes precedence over the Visual Studio and .NET SDK languages. The supported values are the same as for Visual Studio. For more information, see the section on changing the installer language in the [Visual Studio installation documentation](/visualstudio/install/install-visual-studio).
