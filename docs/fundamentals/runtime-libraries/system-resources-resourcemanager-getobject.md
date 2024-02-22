---
title: System.Resources.ResourceManager.GetObject methods
description: Learn about the System.Resources.ResourceManager.GetObject methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
---
# System.Resources.ResourceManager.GetObject methods

[!INCLUDE [context](includes/context.md)]

The <xref:System.Resources.ResourceManager.GetObject%2A> method is used to retrieve non-string resources. These include values that belong to primitive data types such as <xref:System.Int32> or <xref:System.Double>, bitmaps (such as a <xref:System.Drawing.Bitmap?displayProperty=nameWithType> object), or custom serialized objects. Typically, the returned object must be cast (in C#) or converted (in Visual Basic) to an object of the appropriate type.

The <xref:System.Resources.ResourceManager.IgnoreCase> property determines whether the comparison of `name` with the names of resources is case-insensitive or case-sensitive (the default).

> [!NOTE]
> These methods can throw more exceptions than are listed. One reason this might occur is if a method that this method calls throws an exception. For example, a <xref:System.IO.FileLoadException> exception might be thrown if an error was made deploying or installing a satellite assembly, or a <xref:System.Runtime.Serialization.SerializationException> exception might be thrown if a user-defined type throws a user-defined exception when the type is deserialized.

## <xref:System.Resources.ResourceManager.GetObject(System.String)> method

The returned resource is localized for the UI culture of the current thread, which is defined by the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property. If the resource is not localized for that culture, the resource manager uses fallback rules to load an appropriate resource. If no usable set of localized resources is found, the <xref:System.Resources.ResourceManager> falls back on the default culture's resources. If a resource set for the default culture is not found, the method throws a <xref:System.Resources.MissingManifestResourceException> exception or, if the resource set is expected to reside in a satellite assembly, a <xref:System.Resources.MissingSatelliteAssemblyException> exception. If the resource manager can load an appropriate resource set but cannot find a resource named `name`, the method returns `null`.

### Example

The following example uses the <xref:System.Resources.ResourceManager.GetObject(System.String)> method to deserialize a custom object. The example includes a source code file named UIElements.cs (UIElements.vb if you're using Visual Basic) that defines the following structure named `PersonTable`. This structure is intended to be used by a general table display routine that displays the localized names of table columns. Note that the `PersonTable` structure is marked with the <xref:System.SerializableAttribute> attribute.

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/example1.cs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetObject/vb/example.vb" id="Snippet6":::

The following code from a file named CreateResources.cs (or CreateResources.vb for Visual Basic) creates an XML resource file named UIResources.resx that stores a table title and a `PersonTable` object that contains information for an app that is localized for the English language.

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/example11.cs" id="Snippet7":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetObject/vb/example.vb" id="Snippet7":::

The following code in a source code file named GetObject.cs (or GetObject.vb) then retrieves the resources and displays them to the console.

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/example2.cs" id="Snippet8":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetObject/vb/example2.vb" id="Snippet8":::

You can build the necessary resource file and assemblies and run the app by executing the following batch file. You must use the `/r` option to supply Resgen.exe with a reference to UIElements.dll so that it can access information about the `PersonTable` structure. If you're using C#, replace the `vbc` compiler name with `csc`, and replace the `.vb` extension with `.cs`.

```
vbc /t:library UIElements.vb
vbc CreateResources.vb /r:UIElements.dll
CreateResources

resgen UIResources.resx  /r:UIElements.dll
vbc GetObject.vb /r:UIElements.dll /resource:UIResources.resources

GetObject.exe
```

## <xref:System.Resources.ResourceManager.GetObject(System.String,System.Globalization.CultureInfo)> method

The returned resource is localized for the culture that is specified by `culture`, or for the culture that is specified by the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property if `culture` is `null`. If the resource is not localized for that culture, the resource manager uses fallback rules to load an appropriate resource. If no usable set of localized resources is found, the resource manager falls back on the default culture's resources. If a resource set for the default culture is not found, the method throws a <xref:System.Resources.MissingManifestResourceException> exception or, if the resource set is expected to reside in a satellite assembly, a <xref:System.Resources.MissingSatelliteAssemblyException> exception. If the resource manager can load an appropriate resource set but cannot find a resource named `name`, the method returns `null`.

### Example

The following example uses the <xref:System.Resources.ResourceManager.GetObject(System.String,System.Globalization.CultureInfo)> method to deserialize a custom object. The example includes a source code file named NumberInfo.cs (NumberInfo.vb if you're using Visual Basic) that defines the following structure named `Numbers`. This structure is intended to be used by a simple educational app that teaches non-English speaking students to count to ten in English. Note that the `Numbers` class is marked with the <xref:System.SerializableAttribute> attribute.

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/GetObject/csharp/numberinfo.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetObject/vb/numberinfo.vb" id="Snippet1":::

The following source code from a file named CreateResources.cs (CreateResources.vb for Visual Basic) creates XML resource files for the default English language, as well as for the French, Portuguese, and Russian languages.

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/GetObject/csharp/createresources.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetObject/vb/createresources.vb" id="Snippet2":::

The resources are consumed by the following app, which sets the current UI culture to French (France), Portuguese (Brazil), or Russian (Russia). It calls the <xref:System.Resources.ResourceManager.GetObject(System.String)> method to get a `Numbers` object that contains localized numbers and the <xref:System.Resources.ResourceManager.GetObject(System.String,System.Globalization.CultureInfo)> method to get a `Numbers` object that contains English language numbers. It then displays odd numbers using the current UI culture and the English language. The source code file is named ShowNumbers.cs (ShowNumbers.vb).

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/GetObject/csharp/shownumbers.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/GetObject/vb/shownumbers.vb" id="Snippet3":::

You can use the following batch file to build and execute the Visual Basic version of the example. If you're using C#, replace `vbc` with `csc`, and replace the `.vb` extension with `.cs`.

```
vbc /t:library NumberInfo.vb

vbc CreateResources.vb /r:NumberInfo.dll
CreateResources

resgen NumberResources.resx /r:NumberInfo.dll

resgen NumberResources.fr.resx /r:Numberinfo.dll
Md fr
al /embed:NumberResources.fr.resources /culture:fr /t:lib /out:fr\ShowNumbers.resources.dll

resgen NumberResources.pt.resx  /r:Numberinfo.dll
Md pt
al /embed:NumberResources.pt.resources /culture:pt /t:lib /out:pt\ShowNumbers.resources.dll

resgen NumberResources.ru.resx /r:Numberinfo.dll
Md ru
al /embed:NumberResources.ru.resources /culture:ru /t:lib /out:ru\ShowNumbers.resources.dll

vbc ShowNumbers.vb /r:NumberInfo.dll /resource:NumberResources.resources
ShowNumbers.exe
```

## Performance considerations

If you call the <xref:System.Resources.ResourceManager.GetObject%2A> method multiple times with the same `name` parameter, do not depend on the method returning a reference to the same object with each call. This is because the <xref:System.Resources.ResourceManager.GetObject%2A> method can return a reference to an existing resource object in a cache, or it can reload the resource and return a reference to a new resource object.
