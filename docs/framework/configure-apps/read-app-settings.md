---
title: "How to: Read application settings"
description: Learn how to read application settings from an app.config file in .NET Framework.
ms.author: gewarren
author: gewarren
ms.date: 03/10/2022
ms.topic: how-to
---
# How to: Read application settings

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

This article shows you how to add a simple setting to an *App.config* file in a .NET Framework app, and then read the value programmatically. Instead of just reading a single value, you can read an entire section or the entire file. For more examples and information, see the <xref:System.Configuration.ConfigurationManager> docs.

## Add the App.config file

Visual Studio makes it easy to add an *App.config* file to your project. After creating a .NET Framework project, right-click on your project in **Solution Explorer** and choose **Add** > **New Item**. Choose the **Application Configuration File** item and then select **Add**.

## Add a setting

Open the *App.config* file and add the following XML within the `<configuration>` element.

```xml
  <appSettings>
    <add key="occupation" value="dentist"/>
  </appSettings>
```

## Access the setting programmatically

To access the setting's value in your code, get the value by indexing into the <xref:System.Configuration.ConfigurationManager.AppSettings> property. The <xref:System.Configuration.ConfigurationManager.AppSettings> property makes it easy to obtain data from the `<appSettings>` element of your configuration file.

```csharp
string occupation = ConfigurationManager.AppSettings["occupation"];
```

## Configuration for libraries

While it's straightforward to use configuration files for executable apps, it's a little more complicated for class libraries. Class libraries can access configuration settings in the same way as executable apps, however, the configuration settings must exist in the client app's *App.config* file. Even if you distribute an *App.config* file alongside your library's assembly file, the library code will not read the file. Alternatively, consider the following ways to use configuration settings in a class library:

- Obtain the configuration settings in the client app and pass them to the class you're instantiating from the class library.
- Implement a custom section type that extends the <xref:System.Configuration.ConfigurationSection> class. Keep a separate configuration file for your class library, and then reference the library's configuration file from the client app's configuration file. For more information, see [How to: Create Custom Configuration Sections Using ConfigurationSection](/previous-versions/aspnet/2tw134k3(v=vs.100)).

## See also

- <xref:System.Configuration.ConfigurationManager?displayProperty=fullName>
