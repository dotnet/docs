---
title: Windows 10 migration
description: Deep dive in Windows 10 features such as packaging and XAML Islands.
ms.date: 12/29/2020
---

# Windows 10 migration

Consider the following situation: You have a working desktop application that was developed in the Windows 7 days. It's using WPF technology available at that time and working fine but it has an outdated UI and behaviors when you run it on Windows 10. It is like when you watch a futuristic movie like Matrix and you see Neo using the Nokia 8110 device. The film works great after 20 years but it would rather benefit from a device modernization.

With the release of Windows 10, Microsoft introduced many innovations to support scenarios like tablets and touch devices and to provide the best experience for users for a Microsoft operating system ever. For example, you can:

- Sign in with your face using Windows Hello.
- Use a pen to draw or handwrite text that is automatically recognized and digitalized.
- Run locally customized AI models built on the cloud using WinML.

All these features are enabled for Windows developers through Windows Runtime (WinRT) libraries. You can take advantage of these features in your existing desktop apps because the libraries are exposed to both the .NET Framework and .NET as well. You can even modernize your UI with the use of XAML Islands and improve the visuals and behavior of your apps according to the times.

One important thing to note here is that you don't need to abandon .NET Framework technology to follow this modernization path. You can safely stay on there and have all the benefits of Windows 10 without the pressure to migrate to .NET. So, you get both the power and the flexibility to choose your modernization path.

## WinRT APIs

WinRT APIs are object-oriented, well-structured application programming interfaces (APIs) that give Windows 10 developers access to everything the operating system has to offer. Through WinRT APIs, you can integrate functionalities like Push Notifications, Device APIs, Microsoft Ink, and WinML, among others on your desktop apps.

In general, WinRT APIs can be called from a classic desktop app. However, two main areas present an exception to this rule:

* APIs that require a package identity.
* APIs that require visualization like XAML or Composition.

### Universal Windows Platform (UWP) packages

#### Application Package Identity

UWP apps have a deployment system where the OS manages the installation and uninstallation of application. That requires the installation to be declarative, meaning that no user code is executed during install. Instead, everything the app wants to integrate with the system, such as protocols, file types, and extensions, is declared in the application manifest. At deployment time, the deployment pipeline configures those integration points. The only way for the OS to manage all this functionality and keep track of it is for each 'package' to have an identity, a unique identifier for the application.

Some WinRT APIs require this package identity to work as expected. However, classic desktop apps like native C++ or .NET apps, use different deployment systems that don't require a package identity. If you want to use these WinRT APIs in your desktop application, you need to provide them a package identity.

One way to proceed is to build an additional packaging project. Inside the packaging project, you point to the original source code project and specify the Identity information you want to provide. If you install the package and run the
installed app, it will automatically get an identify enabling your code to call all WinRT APIs requiring Identity.

```xml
<?xml version="1.0" encoding="utf-8"?>
<Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
         xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10">
    <Identity Name="YOUR-APP-GUID "
              Publisher="CN=YOUR COMPANY"
              Version="1.x.x.x" />
</Package>
```

You can check which APIs need a packaged application identity by inspecting if the type that contains the API is marked with the
[DualApiPartition](xref:Windows.Foundation.Metadata.DualApiPartitionAttribute) attribute. If it is, you can call if from an unpackaged traditional desktop app. Otherwise, you must convert your classic desktop app to a UWP with the help
of a packaging project.

[https://docs.microsoft.com/windows/desktop/apiindex/uwp-apis-callable-from-a-classic-desktop-app](/windows/desktop/apiindex/uwp-apis-callable-from-a-classic-desktop-app)

#### Benefits of packaging

Besides giving you access to these APIs, you get some additional benefits by creating a Windows App package for your desktop application including:

* **Streamlined deployment**. Apps have a great deployment experience ensuring that users can confidently install an application and update it. If a user chooses to uninstall the app, it's removed completely with no trace left behind preventing the Windows rot problem.

* **Automatic updates and licensing**. Your application can participate in the Microsoft Store's built-in licensing and automatic update facilities. Automatic update is a highly reliable and efficient mechanism, because only the changed parts of files are downloaded.

* **Increased reach and simplified monetization**. Maybe not your case but if you choose to distribute your application through the Microsoft Store you reach millions of Windows 10 users.

* **Add UWP features**. You can add UWP features to your app's package at your own pace.

#### Prepare for packaging

Before proceeding to package your desktop application, there are some points you have to address before starting the process. Your application must respect any of the Microsoft Store rules and policies and run in the UWP application model. For example, it has to run on the .NET Framework 4.6.2 or later and writes to the `HKEY_CURRENT_USER` registry hive and the AppData folders will be virtualized to a user-specific app-local location.

The design goal for packaging is to separate the application state from system state while maintaining compatibility with other apps. Windows 10 accomplishes this goal by placing the application inside a UWP package. It detects and redirects some changes to the file system and registry at run time to fulfill the promise of a trusted and clean install and uninstall
behavior of an application provided by packaging.

Packages that you create for your desktop application are desktop-only, full-trust applications that aren't sandboxed, although there's lightweight virtualization applied to the app for writes to `HKCU` and `AppData`. This virtualization allows
them to interact with other apps the same way classic desktop applications do.

##### Installation

App packages are installed under *%ProgramFiles%\\WindowsApps\\package_name*, with the executable titled `app_name.exe`. Each package folder contains a manifest (named `AppxManifest.xml`) that contains a special XML namespace for
packaged apps. Inside that manifest file is an `<EntryPoint>` element, which references the full-trust app. When that application is launched, it doesn't run inside an app container, but instead it runs as the user as it normally
would.

After deployment, package files are marked read-only and heavily locked down by the operating system. Windows prevents apps from launching if these files are tampered with.

##### File system

The OS supports different levels of file system operations for packaged desktop applications, depending on the folder location.

When trying to access the user's *AppData* folder, the system creates a private per-user, per-app location behind the scenes. This creates the illusion that the packaged application is editing the real *AppData* when it's actually modifying a
private copy. By redirecting writes this way, the system can track all file modifications made by the app. It can then clean all those files when uninstalling reducing system "rot" and providing a better application removal experience for the user.

##### Registry

App packages contain a registry.dat file, which serves as the logical equivalent of `HKLM\Software` in the real registry. At run time, this virtual registry merges the contents of this hive into the native system hive to provide a singular view of both.

All writes are kept during package upgrade and only deleted when the application is uninstalled.

##### Uninstallation

When the user uninstalls a package, all files and folders located under `C:\Program Files\WindowsApps\package_name` are removed, as well as any redirected writes to AppData or the registry that were captured during the process.

For details about how a packaged application handles installation, file access, registry, and uninstallation, see
[https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-behind-the-scenes](/windows/msix/desktop/desktop-to-uwp-behind-the-scenes).

You can get a complete list of things to check on [https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-prepare](/windows/msix/desktop/desktop-to-uwp-prepare).

## How to add WinRT APIs to your desktop project

In this section, you can find a walkthrough on how to integrate Toast Notifications in an existing WPF application. Although it's simple from the code perspective, it helps illustrate the whole process. Notifications are one of the many available WinRT APIs available that you can use in .NET app. In this case, the API requires a Package Identity. This process is more straightforward if the APIs don't require Package Identity.

Let's take an existing WPF sample app that reads files and shows its contents on the screen. The goal is to display a Toast Notification when the application starts.

![Screenshot of the sample application running](./media/windows-migration/sample-application.png)

First, you should check in the following link whether the Windows 10 API that you'll use requires a Package Identity:

[https://docs.microsoft.com/windows/apps/desktop/modernize/desktop-to-uwp-supported-api](/windows/apps/desktop/modernize/desktop-to-uwp-supported-api)

Our sample will use the <xref:Windows.UI.Notifications.Notification?displayProperty=nameWithType> API that requires a packaged identity:

![Notification class in Microsoft documentation](./media/windows-migration/notification-class-documentation.png)

To access the WinRT API, add a reference to the `Microsoft.Windows.SDK.Contracts` NuGet package and this package will do the
magic behind the scenes (see details at <https://blogs.windows.com/windowsdeveloper/2019/04/30/calling-windows-10-apis-from-a-desktop-application-just-got-easier/>).

You're now prepared to start adding some code.

Create a `ShowToastNotification` method that will be called on application startup. It just builds a toast notification from an XML pattern:

```csharp
private void ShowNotification(string title, string content, string image)
{
    string xmlString = $@"<toast><visual><binding template = 'ToastGeneric'><text>{title}</text><text>{content}</text><image src=>'{image}'</image></binding></visual></toast>";
    XmlDocument toastXml = new XmlDocument();
    toastXml.LoadXml(xmlString);
    ToastNotification toast = new ToastNotification(toastXml);
    ToastNotificationManager.CreateToastNotifier().Show(toast);
}
```

Although the project builds, there are errors because the Notifications API requires a Package Identity and you didn't provide it. Adding a Windows Packaging Project to the solution will fix the issue:

![Screenshot of the Add New Project dialog in Visual Studio](./media/windows-migration/add-packaging-project.png)

Select the minimum Windows version you want to support and the version you're targeting. Not all the WinRT APIs are supported in all Windows 10 versions. Each Windows 10 update adds new APIs that are only available from this version; down-level support isn't available.

![Selecting minimum Windows version](./media/windows-migration/select-versions.png)

Next step is to add the WPF application to the Windows Packaging Project by adding a project reference:

![Adding WPF application to the Windows Packaging Project](./media/windows-migration/add-application.png)

![Reference Manager](./media/windows-migration/reference-manager.png)

A Windows Packaging Project can package several apps so you should set which one is the Entry Point:

![Setting entry point](./media/windows-migration/set-entry-point.png)

Next step is to set the WPF Project as the startup Project in the solution configuration. You can press F5 to compile and build and see the results.

![Sample application running and showing results](./media/windows-migration/sample-app-result.png)

Let's generate the package so you can install your app. Right click on **Store** > **Create App Packages**.

![Create App Packages dialog](./media/windows-migration/create-app-packages.png)

Select the sideloading option to deploy the app from your machine:

![Selecting sideloading option](./media/windows-migration/select-sideloading-option.png)

Select the application architecture of your app:

![Selecting the application architecture](./media/windows-migration/select-app-architecture.png)

Finally, create the package by clicking on **Create**.

## XAML Islands

XAML Islands are a set of components that enable Windows desktop developers to use UWP XAML controls on their existing Win32 applications, including Windows Forms and WPF.

![Structure of XAML Islands](./media/windows-migration/xaml-islands.png)

You can image your Win32 app with your standard controls and among them an "island" of UWP UI containing controls from the modern world. The concept is similar as having an iFrame inside a web page that shows content from a `different page.`

Besides adding functionality from the Windows 10 APIs, you can add pieces of UWP XAML inside of your app using XAML Islands.

Windows 10 1903 update introduces a set of APIs that allows hosting UWP XAML content in Win32 windows. Only apps running on Windows 10 1903 can use XAML Islands.

### The road to XAML Islands

The road to XAML Islands started in 2012 when Microsoft introduced the WinRT APIs as a framework to modernize the Win32 apps (Windows Forms, WPF, and native Win32 apps). However, the new UI controls inside WinRT were available for new
applications but not for existing ones.

In 2015, along with Windows 10, UWP was born. UWP allows you to create apps that work across Windows devices like XBox, Mobile, and Desktop. One year later, Microsoft announced Desktop Bridge (formerly known as Project Centennial). Desktop Bridge is a set of tools that allowed developers to bring their existing Win32 apps to the Microsoft Store. More capabilities were added in 2017,
allowing developers to enhance their Win32 apps leveraging some of the new Windows 10 APIs, like live tiles and notifications on the action center. But still, no new UI controls.

At Build 2018, Microsoft announced a way for developers to use the new Windows 10 XAML controls into their current Win32 apps, without fully migrating their apps to UWP. It was branded as UWP XAML Islands.

### How it works

The Windows 10 1903 update introduces several XAML hosting APIs. Two of them are `WindowsXamlManager` and `DesktopWindowXamlSource`.

The `WindowsXamlManager` class handles the UWP XAML Framework. Its `InitializeForCurrentThread` method loads the UWP XAML Framework inside the current thread of the Win32 app.

The `DesktopWindowXamlSource` is the instance of your XAML Island content. It has the `Content` property, which you're responsible for instantiating and setting. The `DesktopWindowXamlSource` renders and gets its input from an HWND. It needs to
know to which other HWND it will attach the XAML Island's one, and you're responsible for sizing and positioning the parent's HWND.

WPF or Windows Forms developers don't usually deal with HWND inside their code, so it may be hard to understand and handle HWND pointers and the underlying wiring stuff to communicate Win32 and UWP worlds.

#### The XAML Islands .NET Wrappers

The Windows Community Toolkit has a set the XAML Islands .NET wrappers for WPF or Windows Forms that make easier to use XAML Islands. These wrappers manage the HWNDs, the focus management, among other things. Windows Forms and WPF developers should use these wrappers.

The Windows Community Toolkit offers two types of controls: Wrapped Controls and Hosting Controls.

##### Wrapped Controls

These wrapped controls wrap some UWP controls into Windows Forms or WPF controls, hiding UWP concepts for those developers. These controls are:

* WebView and WebViewCompatible
* InkCanvas and InkToolbar
* MediaPlayerElement
* MapControl

Add the `Microsoft.Toolkit.Wpf.UI.Controls` package to your project, include the reference to the namespace, and start using them.

```xml
<Window
        ...
        xmlns:uwpControls="clr-namespace:Microsoft.Toolkit.Wpf.UI.Controls;assembly=Microsoft.Toolkit.Wpf.UI.Controls">
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="\*"/>
    </Grid.RowDefinitions>
    <uwpControls:InkToolbar TargetInkCanvas="{x:Reference Name=inkCanvas}"/>
    <uwpControls:InkCanvas Grid.Row="1" x:Name="inkCanvas" />
</Grid>
```

##### Hosting controls

The power of XAML Islands extends to most first-party controls, third-party controls, and custom controls developed for UWP, which can be integrated into Windows Forms and WPF as "Islands" with fully functional UI. The `WindowsXamlHost` control
for WPF and Windows Forms allows doing this.

For example, to use the `WindowsXamlHost` control in WPF, add a reference to the `Microsoft.Toolkit.Wpf.UI.XamlHost` package provided by the Windows Community Toolkit.

Once you've placed your `WindowsXamlHost` into your UI code, specify which UWP type you want to load. You can choose to use a wrapped control like a `Button` or a more complex one composed by several different controls, which are a custom UWP control.

The following example shows how to add a UWP `Button`:

```xml
<Window
        ...
        xmlns:xamlhost="clr-namespace:Microsoft.Toolkit.Wpf.UI.XamlHost;assembly=Microsoft.Toolkit.Wpf.UI.XamlHost">

<xamlhost:WindowsXamlHost x:Name="myUwpButton"
                          InitialTypeName="Windows.UI.Xaml.Controls.Button" />
```

There's a clear recommendation on how to approach this and it's better to have one single and bigger XAML Island containing a custom composite control than to have several islands with one control on each.

One of the core features of XAML is binding and it works between your Win32 code and the island. So, you can bind, for instance, a Win32 `Textbox` with a UWP `Textbox`. One important thing to consider is that these bindings are one-way bindings, from UWP to Win32, so if you update the `Textbox` inside the XAML Island the Win32 Textbox will be updated, but not the other way around.

To see a walkthrough about how to use XAML Islands, see:

[https://docs.microsoft.com/windows/apps/desktop/modernize/host-standard-control-with-xaml-islands](/windows/apps/desktop/modernize/host-standard-control-with-xaml-islands)

#### Adding UWP XAML custom controls

A XAML custom control is a control (or user control) created by you or by third parties (including WinUI 2.x controls). To host a custom UWP control in a Windows Forms or WPF app, you'll need:

- To use the `WindowsXamlHost` UWP control in your .NET app.
- To create a UWP app project that defines a `XamlApplication` object.

Your WPF or Windows Forms project must have access to an instance of the `Microsoft.Toolkit.Win32.UI.XamlHost.XamlApplication` class provided by the Windows Community Toolkit. This object acts as a root metadata provider for loading metadata for custom UWP XAML types in assemblies in the current directory of your application. The recommended way to do this is to add a Blank
App (Universal Windows) project to the same solution as your WPF or Windows Forms project and revise the default App class in this project.

The custom UWP XAML control can be included on this UWP app or in an independent UWP Class Library project that you reference in the same solution as your WPF or Windows Forms project.

You can check a detailed step-by-step process description at:

[https://docs.microsoft.com/windows/apps/desktop/modernize/host-custom-control-with-xaml-islands](/windows/apps/desktop/modernize/host-custom-control-with-xaml-islands)

#### The Windows UI Library (WinUI 2)

Besides the inbox Windows 10 controls that comes with the OS, the same UWP XAML team also deliver additional controls in the Windows UI Library (**WinUI 2**). WinUI 2 provides official native Microsoft UI controls and features for Windows UWP apps and these controls can be used inside of XAML Islands.

WinUI 2 is open source and you can find information at <https://github.com/microsoft/microsoft-ui-xaml>.

The following article demonstrates how to host a UWP XAML control from the WinUI 2 library: [https://docs.microsoft.com/windows/apps/desktop/modernize/host-custom-control-with-xaml-islands](/windows/apps/desktop/modernize/host-custom-control-with-xaml-islands)

### Do you need XAML Islands

XAML Islands are intended for existing Win32 apps that want to improve their user experience by leveraging new UWP controls and behaviors without a full rewrite of the app. You could already [leverage Windows 10 APIs](/windows/uwp/porting/desktop-to-uwp-enhance), but up until XAML Islands, only non-UI related APIs.

If you're developing a new Windows App, a [UWP App](/windows/uwp/get-started/universal-application-platform-guide) is probably the right approach.

### The road ahead XAML Islands: WinUI 3.0

Since Windows 8, the Windows UI platform, including the XAML UI framework, visual composition layer, and input processing has been shipped as an integral part of Windows. This means that to benefit from the latest improvements on UI technologies, you must upgrade to the latest version of the UI, slowing down the pace of innovation when you develop your apps. To decouple these two evolution cycles and foster innovation, Microsoft is actively working on the WinUI project.

Starting with WinUI 2 in 2018, Microsoft started shipping some new XAML UI controls and features as separate NuGet packages that build on top of the UWP SDK.

![Structure of WinUI 2.0](./media/windows-migration/winui2.png)

WinUI 3 is under active development and will greatly expand the scope of WinUI to include the full UI platform, which will be fully decoupled from the UWP SDK:

![Structure of WinUI 3.0](./media/windows-migration/winui3.png)

XAML framework will now be developed on GitHub and shipped out of band as [NuGet](/nuget/what-is-nuget) packages.

The existing UWP XAML APIs that ship as part of the OS will no longer receive new feature updates. They will still receive security updates and critical fixes according to the Windows 10 support lifecycle.

The Universal Windows Platform contains more than just the XAML framework (for example, application and security model, media pipeline, Xbox and Windows 10 shell integrations, broad device support) and will continue to evolve. All new XAML
features will just be developed and ship as part of WinUI instead.

#### WinUI 3 in desktop app and WinUI XAML Islands

As you can see, WinUI 3 is the evolution of UWP XAML and it works naturally within the UWP app model and all its requirements (MSIX packaged ID, sandbox, CoreWindow, and so on. To use just WinUI 3 in a Win32 app model, the WinUI content should be hosted by another UI Framework (Windows Forms, WPF, and so on) using **WinUI XAML Islands**. This is the right path if you want to evolve your app and mix technologies. However, if you want to replace your entire old UI for WinUI, your app shouldn't load UI Frameworks for just hosting WinUI.

WinUI 3 will address this critical feedback adding **WinUI in desktop apps**. This will allow that Win32 apps can use WinUI 3 as standalone UI Framework; no need to load Windows Forms or WPF.

Within this aggregation, WinUI 3 will let developers easily mix and match the right combination of:

* App model: UWP, Win32
* Platform: .NET or Native
* Language: .NET (C\#, Visual Basic), standard C++
* Packaging: MSIX, AppX for the Microsoft Store, unpackaged
* Interop: use WinUI 3 to extend existing WPF, WinForms, and MFC apps using WinUI XAML Islands.

If you want to know more details, Microsoft is sharing this roadmap in <https://github.com/microsoft/microsoft-ui-xaml/blob/main/docs/roadmap.md>.

>[!div class="step-by-step"]
>[Previous](migrate-modern-applications.md)
>[Next](example-migration.md)
