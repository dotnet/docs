---
title: "High DPI support in Windows Forms"
ms.custom: ""
ms.date: "05/16/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "High DPI in Windows Forms"
  - "Dynamic rescaling in Windows Forms"
  - "Windows Forms layout"
  - "Windows Forms dynamic resizing"
ms.assetid: 075ea4c3-900c-4f8a-9dd2-13ea6804346b
caps.latest.revision: 3
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# High DPI support in Windows Forms

Starting with the .NET Framework 4.7, Windows Forms includes enhancements for common high DPI and dynamic DPI scenarios. These include: 

- Improvements in the scaling and layout of a number of Windows Forms controls, such as the <xref:System.Windows.Forms.MonthCalendar> control and the <xref:System.Windows.Forms.CheckedListBox> control. 

- Single-pass scaling.  In the .NET Framework 4.6 and earlier versions, scaling was performed through multiple passes, which caused some controls to be scaled more than was necessary.

- Support for dynamic DPI scenarios in which the user changes the DPI or scale factor after a Windows Forms application has been launched.

In versions of the .NET Framework starting with the .NET Framework 4.7, enhanced high DPI support is an opt-in feature. You must configure your application to take advantage of it.

## Configuring your Windows Forms app for high DPI support

The new Windows Forms features that support high DPI awareness are available only in applications that target the .NET Framework 4.7 and are running on Windows operating systems starting with the Windows 10 Creators Update. 

In addition, to configure high DPI support in your Windows Forms application, you must do the following:

- Declare compatibility with Windows 10.

  To do this, add the following to your manifest file:

  ```xml
  <compatibility xmlns="urn:schemas-microsoft.comn:compatibility.v1">
    <application>
      <!-- Windows 10 compatibility -->
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
    </application>
  </compatibility>
  ```

- Enable per-monitor DPI awareness in the *app.config* file.

  Windows Forms introduces a new [`<System.Windows.Forms.ApplicationConfigurationSection>`](../../../docs/framework/configure-apps/file-schema/winforms/index.md) element to support new features and customizations added starting with the .NET Framework 4.7. To take advantage of the new features that support high DPI, add the following to your application configuration file.   

  ```xml
  <System.Windows.Forms.ApplicationConfigurationSection>
    <add key="DpiAwareness" value="PerMonitorV2" />
  </System.Windows.Forms.ApplicationConfigurationSection>	   
  ```
   
  > [!IMPORTANT]
  > In previous versions of the .NET Framework, you used the manifest to add high DPI support. This approach is no longer recommended, since it overrides settings defined on the app.config file.
   
- Call the static <xref:System.Windows.Forms.Application.EnableVisualStyles%2A> method.
   
  This should be the first method call in your application entry point. For example:
   
  ```csharp
  static void Main()
  {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form2());   
  }
  ```

## Opting out of individual high DPI features

Setting the `DpiAwareness` value to `PerMonitorV2` enables all high DPI awareness features supported by .NET Framework versions starting with the .NET Framework 4.7. Typically, this is adequate for most Windows Forms applications. However, you may want to opt out of one or more individual features. The most important reason for doing this is that your existing application code already handles that feature.  For example, if your application handles auto scaling, you might want to disable the auto-resizing feature as follows:

```xml
<System.Windows.Forms.ApplicationConfigurationSection>
  <add key="DpiAwareness" value="PerMonitorV2" />
  <add key="EnableWindowsFormsHighDpiAutoResizing" value="false" /> 
</System.Windows.Forms.ApplicationConfigurationSection>	   
```

For a list of individual keys and their values, see [Windows Forms Add Configuration Element](../../../docs/framework/configure-apps/file-schema/winforms/windows-forms-add-configuration-element.md).

## New DPI change events

Starting with the .NET Framework 4.7, three new events allow you to programmatically handle dynamic DPI changes:

- <xref:System.Windows.Forms.Control.DpiChangedAfterParent>, which is fired when the DPI setting for a control is changed programmatically after a DPI change event for it's parent control or form has occurred.
- <xref:System.Windows.Forms.Control.DpiChangedBeforeParent>, which is fired when the DPI setting for a control is changed programmatically before a DPI change event for its parent control or form has occurred.
- <xref:System.Windows.Forms.Form.DpiChanged>, which is fired when the DPI setting changes on the display device where the form is currently displayed.

## New helper methods and properties

The .NET Framework 4.7 also adds a number of new helper methods and properties that provide information about DPI scaling and allow you to perform DPI scaling. These include:

- <xref:System.Windows.Forms.Control.LogicalToDeviceUnits%2A>, which converts a value from logical to device pixels.

- <xref:System.Windows.Forms.Control.ScaleBitmapLogicalToDevice%2A>, which scales a bitmap image to the logical DPI for a device.

- <xref:System.Windows.Forms.Control.DeviceDpi%2A>, which returns the DPI for the current device.

## Versioning considerations

In addition to running on .NET Framework 4.7 and Windows 10 Creators Update, your application may also run in an environment in which it isn't compatible with high DPI improvements. In this case, you'll need to develop a fallback for your application. You can do this to perform [custom drawing](./controls/user-drawn-controls.md) to handle scaling.

To do this, you also need to determine the operating system on which your app is running. You can do that with code like the following:

```csharp
// Create a reference to the OS version of Windows 10 Creators Update.
Version OsMinVersion = new Version(10, 0, 15063, 0);

// Access the platform/version of the current OS.
Console.WriteLine(Environment.OSVersion.Platform.ToString());
Console.WriteLine(Environment.OSVersion.VersionString);

// Compare the current version to the minimum required version.
Console.WriteLine(Environment.OSVersion.Version.CompareTo(OsMinVersion));
```

Note that your application won't successfully detect Windows 10 if it wasn't listed as a supported operating system in the application manifest.

You can also check the version of the .NET Framework that the application was built against:

```csharp
Console.WriteLine(AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName);
```

## See also

[Windows Forms Add Configuration Element](../../../docs/framework/configure-apps/file-schema/winforms/windows-forms-add-configuration-element.md)  
[Adjusting the Size and Scale of Windows Forms](../../../docs/framework/winforms/adjusting-the-size-and-scale-of-windows-forms.md)
