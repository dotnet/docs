---
title: "Resources in .NET apps"
description: Understand resources in .NET apps. A resource is any non-executable data that's logically deployed with an app.
ms.date: 08/09/2021
helpviewer_keywords:
  - "deploying applications [.NET Framework], resources"
  - "deploying applications [.NET Core], resources"
  - "deploying applications [.NET], resources"
  - "application resources"
  - "resource files"
  - "satellite assemblies"
  - "localization"
  - "packaging application resources"
  - "localizing resources"
ms.assetid: 8ad495d4-2941-40cf-bf64-e82e85825890
---

# Resources in .NET apps

Nearly every production-quality app has to use resources. A resource is any non-executable data that is logically deployed with an app. A resource might be displayed in an app as error messages or as part of the user interface. Resources can contain data in a number of forms, including strings, images, and persisted objects. (To write persisted objects to a resource file, the objects must be serializable.) Storing your data in a resource file enables you to change the data without recompiling your entire app. It also enables you to store data in a single location, and eliminates the need to rely on hard-coded data that is stored in multiple locations.

.NET provides comprehensive support for the creation and [localization](localization.md) of resources. In addition, .NET supports a simple model for packaging and deploying localized resources.

## Create and localize resources

In a non-localized app, you can use resource files as a repository for app data, particularly for strings that might otherwise be hard-coded in multiple locations in source code. Most commonly, you create resources as either text (.txt) or XML (.resx) files, and use [Resgen.exe (Resource File Generator)](../../framework/tools/resgen-exe-resource-file-generator.md) to compile them into binary .resources files. These files can then be embedded in the app's executable file by a language compiler. For more information about creating resources, see [Create resource files](create-resource-files.md).

You can also localize your app's resources for specific cultures. This enables you to build localized (translated) versions of your apps. When you develop an app that uses localized resources, you designate a culture that serves as the neutral or fallback culture whose resources are used if no suitable resources are available. Typically, the resources of the neutral culture are stored in the app's executable. The remaining resources for individual localized cultures are stored in standalone satellite assemblies. For more information, see [Create satellite assemblies](create-satellite-assemblies.md).

## Package and deploy resources

You deploy localized app resources in [satellite assemblies](package-and-deploy-resources.md). A satellite assembly contains the resources of a single culture; it does not contain any app code. In the satellite assembly deployment model, you create an app with one default assembly (which is typically the main assembly) and one satellite assembly for each culture that the app supports. Because the satellite assemblies are not part of the main assembly, you can easily replace or update resources corresponding to a specific culture without replacing the app's main assembly.

Carefully determine which resources will make up your app's default resource assembly. Because it is a part of the main assembly, any changes to it will require you to replace the main assembly. If you do not provide a default resource, an exception will be thrown when the [resource fallback process](package-and-deploy-resources.md) attempts to find it. In a well-designed app, using resources should never throw an exception.

For more information, see the [Packaging and Deploying Resources](package-and-deploy-resources.md) article.

## Retrieve resources

At run time, an app loads the appropriate localized resources on a per-thread basis, based on the culture specified by the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property. This property value is derived as follows:

- By directly assigning a <xref:System.Globalization.CultureInfo> object that represents the localized culture to the <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=nameWithType> property.

- If a culture is not explicitly assigned, by retrieving the default thread UI culture from the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture%2A?displayProperty=nameWithType> property.

- If a default thread UI culture is not explicitly assigned, by retrieving the culture for the current user on the local computer. .NET implementations running on Windows do this  by calling the Windows [`GetUserDefaultUILanguage`](/windows/desktop/api/winnls/nf-winnls-getuserdefaultuilanguage) function.

For more information about how the current UI culture is set, see the <xref:System.Globalization.CultureInfo> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> reference pages.

You can then retrieve resources for the current UI culture or for a specific culture by using the <xref:System.Resources.ResourceManager?displayProperty=nameWithType> class. Although the <xref:System.Resources.ResourceManager> class is most commonly used for retrieving resources, the <xref:System.Resources?displayProperty=nameWithType> namespace contains additional types that you can use to retrieve resources. These include:

- The <xref:System.Resources.ResourceReader> class, which enables you to enumerate resources embedded in an assembly or stored in a standalone binary .resources file. It is useful when you don't know the precise names of the resources that are available at run time.

- The <xref:System.Resources.ResXResourceReader> class, which enables you to retrieve resources from an XML (.resx) file.

- The <xref:System.Resources.ResourceSet> class, which enables you to retrieve the resources of a specific culture without observing fallback rules. The resources can be stored in an assembly or a standalone binary .resources file. You can also develop an <xref:System.Resources.IResourceReader> implementation that enables you to use the <xref:System.Resources.ResourceSet> class to retrieve resources from some other source.

- The <xref:System.Resources.ResXResourceSet> class, which enables you to retrieve all the items in an XML resource file into memory.

## See also

- <xref:System.Globalization.CultureInfo>
- <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType>
- [Create resource files](create-resource-files.md)
- [Package and deploy resources](package-and-deploy-resources.md)
- [Create satellite assemblies](create-satellite-assemblies.md)
- [Retrieve resources](retrieve-resources.md)
- [Localization in .NET](localization.md)
