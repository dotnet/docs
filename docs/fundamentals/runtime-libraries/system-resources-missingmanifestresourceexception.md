---
title: System.Resources.MissingManifestResourceException class
description: Learn about the System.Resources.MissingManifestResourceException class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Resources.MissingManifestResourceException class

[!INCLUDE [context](includes/context.md)]

A <xref:System.Resources.MissingManifestResourceException> exception is thrown for different reasons in .NET versus UWP apps.

## .NET apps

In .NET apps, <xref:System.Resources.MissingManifestResourceException> is thrown when the attempt to retrieve a resource fails because the resource set for the neutral culture could not be loaded from a particular assembly. Although the exception is thrown when you try to retrieve a particular resource, it is caused by the failure to load the resource set rather than the failure to find the resource.

> [!NOTE]
> For additional information, see the "Handling a MissingManifestResourceException Exception" section in the <xref:System.Resources.ResourceManager> class topic.

The main causes of the exception include the following:

- The resource set is not identified by its fully qualified name. For example, if the `baseName` parameter in the call to the <xref:System.Resources.ResourceManager.%23ctor%28System.String%2CSystem.Reflection.Assembly%29?displayProperty=nameWithType> method specifies the root name of the resource set without a namespace, but the resource set is assigned a namespace when it is stored in its assembly, the call to the <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType> method throws this exception.

  If you've embedded the .resources file that contains the default culture's resources in your executable and your app is throwing a <xref:System.Resources.MissingManifestResourceException>, you can use a reflection tool such as the [IL Disassembler (Ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) to determine the fully qualified name of the resource. In ILDasm, double click the executable's **MANIFEST** label to open the **MANIFEST** window. Resources appear as `.mresource` items and are listed after external assembly references and custom assembly-level attributes. You can also compile the following simple utility, which lists the fully qualified names of embedded resources in the assembly whose name is passed to it as a command-line parameter.

  :::code language="csharp" source="./snippets/System.Resources/MissingManifestResourceException/Overview/csharp/resourcenames.cs" id="Snippet4":::
  :::code language="vb" source="./snippets/System.Resources/ResourceManager/Overview/vb/resourcenames.vb" id="Snippet4":::

- You identify the resource set by its resource file name (along with its optional namespace) and its file extension rather than by its namespace and root file name alone. For example, this exception is thrown if the neutral culture's resource set is named `GlobalResources` and you supply a value of `GlobalResources.resources` (instead of `GlobalResources`) to the `baseName` parameter of the <xref:System.Resources.ResourceManager.%23ctor%28System.String%2CSystem.Reflection.Assembly%29?displayProperty=nameWithType> constructor.

- The culture-specific resource set that is identified in a method call cannot be found, and the fallback resource set cannot be loaded. For example, if you create satellite assemblies for the English (United States) and Russia (Russian) cultures but you fail to provide a resource set for the neutral culture, this exception is thrown if your app's current culture is English (United Kingdom).

<xref:System.Resources.MissingManifestResourceException> uses the HRESULT `COR_E_MISSINGMANIFESTRESOURCE`, which has the value 0x80131532.

<xref:System.Resources.MissingManifestResourceException> uses the default <xref:System.Object.Equals%2A> implementation, which supports reference equality.

For a list of initial property values for an instance of <xref:System.Resources.MissingManifestResourceException>, see the <xref:System.Resources.MissingManifestResourceException.%23ctor%2A> constructors.

> [!NOTE]
> We recommend that you include a neutral set of resources in your main assembly, so your app won't fail if a satellite assembly is unavailable.

## Universal Windows Platform (UWP) apps

UWP apps deploy resources for multiple cultures, including the neutral culture, in a single package resource index (.pri) file. As a result, in a UWP app, if resources for the preferred culture cannot be found, the <xref:System.Resources.MissingManifestResourceException> is thrown under either of the following conditions:

- The app does not include a .pri file, or the .pri file could not be opened.
- The app's .pri file does not contain a resource set for the given root name.
