---
title: Modernize your upgraded .NET Framework apps
description: This article demonstrates some of the ways you can modernize your .NET Framework app after you've upgraded to .NET
author: adegeo
ms.date: 05/25/2023
dev_langs: ["csharp", "vb"]
no-loc: ["package.config", PackageReference]
---

# Modernize after upgrading to .NET from .NET Framework

In this article, you'll learn about different ways you can modernize your app after it's been upgraded from .NET Framework to .NET. Use the [.NET Upgrade Assistant](upgrade-assistant-overview.md) tool to upgrade your app to .NET.

## Missing APIs

When upgrading a .NET Framework app, you'll most likely have some incompatibilities. This is because .NET Framework is a Windows-only technology and .NET is a cross-platform technology. Some libraries aren't. For example, .NET doesn't provide out-of-the-box APIs to access the Windows Registry like .NET Framework did. Support for the Windows Registry is provided by the `Microsoft.Win32.Registry` NuGet package. Many the .NET Framework-specific libraries have been ported to .NET or .NET Standard, and are hosted on NuGet. If you find a missing reference in your project, search NuGet.

### Windows Compatibility Pack

If after migration you have some dependencies on .NET Framework APIs that are not supported on your new version of .NET, you might find them in the [`Microsoft.Windows.Compatibility` NuGet package](https://www.nuget.org/packages/Microsoft.Windows.Compatibility). It adds around 20,000 APIs to your .NET project, significantly increasing the API set available to your project. These APIs include Windows-only APIs such as those related to Windows Management Instrumentation (WMI) and the Windows EventLog. For more information, see [Use the Windows Compatibility Pack to port code to .NET](windows-compat-pack.md)

## Web browser control

Projects that target a Windows desktop technology, such as Windows Presentation Foundation or Windows Forms, may include a web browser control. The web browser control provided was most likely designed prior to HTML5 and other modern web technologies and is considered obsolete. Microsoft publishes the [`Microsoft.Web.WebView2` NuGet package](https://www.nuget.org/packages/Microsoft.Web.WebView2) as modern web browser control replacement.

## App.config

.NET Framework uses the _App.config_ file to load settings for your app, such as connection strings and log provider configuration. Modern .NET uses the _appsettings.json_ file for app settings. The CLI version of the Upgrade Assistant handles converting _App.config_ files to _appsettings.json_, but the Visual Studio extension doesn't.

> [!TIP]
> If you don't want to use the _appsettings.json_ file, you can add the `System.Configuration.ConfigurationManager` NuGet package to your app and your code will compile and use the _App.config_ file.

Even though _appsettings.json_ is the modern way to store and retrieve settings and connection strings, your app still has code that uses the _App.config_ file. When your app was migrated, the `System.Configuration.ConfigurationManager` NuGet package was added to the project so that your code using the _App.config_ file continues to compile.

As libraries upgrade to .NET, they modernize by supporting _appsettings.json_ instead of _App.config_. For example, logging providers in .NET Framework that have been upgraded for .NET 6+ no longer use _App.config_ for settings. It's good for you to follow their direction and also move away from using _App.config_.

Support for _appsettings.json_ is provided by the `Microsoft.Extensions.Configuration` NuGet package.

Perform the following steps to use the _appsettings.json_ file as your configuration provider:

01. Remove the `System.Configuration.ConfigurationManager` NuGet package or library if referenced by your upgraded app.
01. Add the `Microsoft.Extensions.Configuration.Json` NuGet package.
01. Create a file named _appsettings.json_.

    01. Right-click on the project file in the **Solution Explorer** window and select **Add** > **New Item...**.
    01. In the search box, enter `json`.
    01. Select the **JavaScript JSON Configuration File** template and set the **Name** to _appsettings.json_.
    01. Press **Add** to add the new file to the project.

01. Set the _appsettings.json_ file to copy to the output directory.

    In the **Solution Explorer** window, find the _appsettings.json_ file and set the following **Properties**:

    - **Build Action**: Content
    - **Copy to Output Directory**: Copy always

01. In the startup code of your app, you need to load the settings file.

    The startup code for your app varies based on your project type. For example, a WPF app uses the `App.xaml.cs` file for global setup and a Windows Forms app uses the `Program.Main` method for startup. Regardless, you need to do two things at startup:

    - Create an `internal static` (`Friend Shared` in Visual Basic) member that can be accessed from anywhere in your app.
    - During startup, assign an instance to that member.

    The following example creates a member named `Config`, assigns it an instance in the `Main` method, and loads a connection string:

    ```csharp
    using Microsoft.Extensions.Configuration;
    
    internal class Program
    {
        internal static IConfiguration Config { get; private set; }
    
        private static void Main(string[] args)
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
    
            // Use the config file to get a connection string
            string? myConnectionString = Config.GetConnectionString("database");
    
            // Run the rest of your app
        }
    }
    ```

    ```vb
    Imports Microsoft.Extensions.Configuration
    
    Module Program
    
        Private _config As IConfiguration
    
        ' Shared not required since Program is a Module
        Friend Property Config As IConfiguration
    
            Get
                Return _config
            End Get
            Private Set(value As IConfiguration)
                _config = value
            End Set
    
        End Property
    
        Sub Main(args As String())
    
            Config = New ConfigurationBuilder() _
                .AddJsonFile("appsettings.json") _
                .Build()
    
            ' Use the config file to get a connection string
            Dim myConnectionString As String = Config.GetConnectionString("database")
    
            ' Run the rest of your app
        End Sub
    End Module
    ```

01. Update the rest of your code to use the new configuration APIs.
01. Delete the _App.config_ file from the project.

    > [!CAUTION]
    > Make sure that your app runs correctly without the _App.config_ file. Back up the _App.config_ file through source control or by copying the file elsewhere. After you've thohroughly tested your app, delete the _App.config_file.
