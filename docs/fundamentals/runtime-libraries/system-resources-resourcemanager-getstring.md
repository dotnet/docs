---
title: System.Resources.ResourceManager.GetString methods
description: Learn about the System.Resources.ResourceManager.GetString methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
ms.topic: concept-article
---
# System.Resources.ResourceManager.GetString methods

[!INCLUDE [context](includes/context.md)]

The <xref:System.Resources.ResourceManager.IgnoreCase> property determines whether the comparison of `name` with the names of resources is case-insensitive (the default) or case-sensitive.

> [!NOTE]
> The <xref:System.Resources.ResourceManager.GetString%2A> methods can throw more exceptions than are listed. One reason this might occur is if a method that this method calls throws an exception. For example, a <xref:System.IO.FileLoadException> exception might be thrown if an error was made deploying or installing a satellite assembly, or a <xref:System.Runtime.Serialization.SerializationException> exception might be thrown if a user-defined type throws a user-defined exception when the type is deserialized.

## <xref:System.Resources.ResourceManager.GetString(System.String)> method

### Desktop apps

In desktop apps, the resource that is returned is localized for the UI culture of the current thread, as defined by the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property. If the resource has not been localized for that culture, the resource manager probes for a resource by following the steps outlined in the "Resource Fallback Process" section of the [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps) article. If no usable set of localized resources is found, the resource manager falls back on the default culture's resources. If the resource manager cannot load the default culture's resource set, the method throws a <xref:System.Resources.MissingManifestResourceException> exception or, if the resource set is expected to reside in a satellite assembly, a <xref:System.Resources.MissingSatelliteAssemblyException> exception. If the resource manager can load an appropriate resource set but cannot find a resource named `name`, the method returns `null`.

### Windows 8.x apps

> [!IMPORTANT]
> Although the <xref:System.Resources.ResourceManager> class is supported in Windows 8.x apps, we do not recommend its use. Use this class only when you develop Portable Class Library projects that can be used with Windows 8.x apps. To retrieve resources from Windows 8.x apps, use the [Windows.ApplicationModel.Resources.ResourceLoader](/uwp/api/windows.applicationmodel.resources.resourceloader) class instead.

In Windows 8.x apps, the <xref:System.Resources.ResourceManager.GetString(System.String)> method returns the value of the `name` string resource, localized for the caller's current UI culture settings. The list of cultures is derived from the operating system's preferred UI language list. If the resource manager cannot match `name`, the method returns `null`.

### Example

The following example uses the <xref:System.Resources.ResourceManager.GetString%2A> method to retrieve culture-specific resources. It consists of resources compiled from .txt files for the English (en), French (France) (fr-FR), and Russian (Russia) (ru-RU) cultures. The example changes the current culture and current UI culture to English (United States), French (France), Russian (Russia), and Swedish (Sweden). It then calls the <xref:System.Resources.ResourceManager.GetString%2A> method to retrieve the localized string, which it displays along with the current day and month. Notice that the output displays the appropriate localized string except when the current UI culture is Swedish (Sweden). Because Swedish language resources are unavailable, the app instead uses the resources of the default culture, which is English. The example requires the text-based resource files listed in following table. Each has a single string resource named `DateStart`.

| Culture | File name             | Resource name | Resource value        |
|---------|-----------------------|---------------|-----------------------|
| en-US   | DateStrings.txt       | `DateStart`   | Today is              |
| fr-FR   | DateStrings.fr-FR.txt | `DateStart`   | Aujourd'hui, c'est le |
| ru-RU   | DateStrings.ru-RU.txt | `DateStart`   | Сегодня               |

You can use the following batch file to compile the C# example. For Visual Basic, change `csc` to `vbc`, and change the extension of the source code file from `.cs` to `.vb`.

```
resgen DateStrings.txt
csc showdate.cs /resource:DateStrings.resources

md fr-FR
resgen DateStrings.fr-FR.txt
al /out:fr-FR\Showdate.resources.dll /culture:fr-FR /embed:DateStrings.fr-FR.resources

md ru-RU
resgen DateStrings.ru-RU.txt
al /out:ru-RU\Showdate.resources.dll /culture:ru-RU /embed:DateStrings.ru-RU.resources
```

Here's the source code for the example (ShowDate.vb for the Visual Basic version or ShowDate.cs for the C# version).

:::code language="csharp" source="./snippets/System.Resources/MissingManifestResourceException/Overview/csharp/showdate1.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetString/vb/showdate.vb" id="Snippet2":::

## <xref:System.Resources.ResourceManager.GetString(System.String,System.Globalization.CultureInfo)> method

### Desktop apps

In desktop apps, if `culture` is `null`, the <xref:System.Resources.ResourceManager.GetString(System.String,System.Globalization.CultureInfo)> method uses the current UI culture obtained from the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property.

The resource that is returned is localized for the culture specified by the `culture` parameter. If the resource has not been localized for `culture`, the resource manager probes for a resource by following the steps outlined in the "Resource Fallback Process" section of the [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps) topic. If no usable set of resources is found, the resource manager falls back on the default culture's resources. If the resource manager cannot load the default culture's resource set, the method throws a <xref:System.Resources.MissingManifestResourceException> exception or, if the resource set is expected to reside in a satellite assembly, a <xref:System.Resources.MissingSatelliteAssemblyException> exception. If the resource manager can load an appropriate resource set but cannot find a resource named `name`, the method returns `null`.

### Windows 8.x apps

> [!IMPORTANT]
> Although the <xref:System.Resources.ResourceManager> class is supported in Windows 8.x apps, we do not recommend its use. Use this class only when you develop Portable Class Library projects that can be used with Windows 8.x apps. To retrieve resources from Windows 8.x apps, use the [Windows.ApplicationModel.Resources.ResourceLoader](/uwp/api/windows.applicationmodel.resources.resourceloader) class instead.

In Windows 8.x apps, the <xref:System.Resources.ResourceManager.GetString(System.String,System.Globalization.CultureInfo)> method returns the value of the `name` string resource, localized for the culture specified by the `culture` parameter. If the resource is not localized for the `culture` culture, the lookup uses the entire Windows 8 language fallback list, and stops after looking in the default culture. If the resource manager cannot match `name`, the method returns `null`.

### Example

The following example uses the <xref:System.Resources.ResourceManager.GetString(System.String,System.Globalization.CultureInfo)> method to retrieve culture-specific resources. The example's default culture is English (en), and it includes satellite assemblies for the French (France) (fr-FR) and Russian (Russia) (ru-RU) cultures. The example changes the current culture and current UI culture to Russian (Russia) before calling <xref:System.Resources.ResourceManager.GetString(System.String,System.Globalization.CultureInfo)>. It then calls the <xref:System.Resources.ResourceManager.GetString%2A> method and the <xref:System.DateTime.ToString(System.String,System.IFormatProvider)?displayProperty=nameWithType> method and passes <xref:System.Globalization.CultureInfo> objects that represent the French (France) and Swedish (Sweden) cultures to each method. In the output, the month and day of the month as well as the string that precedes them appear in French, because the <xref:System.Resources.ResourceManager.GetString%2A> method is able to retrieve the French language resource. However, when the Swedish (Sweden) culture is used, the month and day of the month appear in Swedish, although the string that precedes them is in English. This is because the resource manager cannot find localized Swedish language resources, so it returns a resource for the default English culture instead.

The example requires the text-based resource files listed in following table. Each has a single string resource named `DateStart`.

| Culture | File name             | Resource name | Resource value        |
|---------|-----------------------|---------------|-----------------------|
| en-US   | DateStrings.txt       | `DateStart`   | Today is              |
| fr-FR   | DateStrings.fr-FR.txt | `DateStart`   | Aujourd'hui, c'est le |
| ru-RU   | DateStrings.ru-RU.txt | `DateStart`   | Сегодня               |

You can use the following batch file to compile the Visual Basic example. To compile in C#, change `vbc` to `csc`, and change the extension of the source code file from `.vb` to `.cs`.

```
resgen DateStrings.txt
vbc showdate.vb /resource:DateStrings.resources

md fr-FR
resgen DateStrings.fr-FR.txt
al /out:fr-FR\Showdate.resources.dll /culture:fr-FR /embed:DateStrings.fr-FR.resources

md ru-RU
resgen DateStrings.ru-RU.txt
al /out:ru-RU\Showdate.resources.dll /culture:ru-RU /embed:DateStrings.ru-RU.resources
```

Here's the source code for the example (ShowDate.vb for the Visual Basic version or ShowDate.cs for the C# version).

:::code language="csharp" source="./snippets/System.Resources/MissingManifestResourceException/Overview/csharp/showdate2.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetString/vb/showdate2.vb" id="Snippet3":::
