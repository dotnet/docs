---
title: System.Resources.NeutralResourcesLanguageAttribute class
description: Learn about the System.Resources.NeutralResourcesLanguageAttribute class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Resources.NeutralResourcesLanguageAttribute class

[!INCLUDE [context](includes/context.md)]

In desktop apps, the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute informs the resource manager of an app's default culture and the location of its resources. By default, resources are embedded in the main app assembly, and you can use the attribute as follows. This statement specifies that the English (United States) is the app's default culture.

```csharp
[assembly: NeutralResourcesLanguage("en-US")]
```

```vb
<Assembly:NeutralResourcesLanguage("en-US")>
```

You can also use the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to indicate where <xref:System.Resources.ResourceManager> can find the resources of the default culture by providing an <xref:System.Resources.UltimateResourceFallbackLocation> enumeration value in the attribute statement. This is most commonly done to indicate that the resources reside in a satellite assembly. For example, the following statement specifies that English (United States) is the app's default or neutral culture and that its resources reside in a satellite assembly. The <xref:System.Resources.ResourceManager> object will look for them in a subdirectory named en-US.

```csharp
[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]
```

```vb
<Assembly:NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)>
```

> [!TIP]
> We recommend that you always use the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to define the default culture of your app.

The attribute performs two roles:

- If the default culture's resources are embedded in the app's main assembly and <xref:System.Resources.ResourceManager> has to retrieve resources that belong to the same culture as the default culture, the <xref:System.Resources.ResourceManager> automatically uses the resources located in the main assembly instead of searching for a satellite assembly. This bypasses the usual assembly probe, improves lookup performance for the first resource you load, and can reduce your working set. See [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps) for the process <xref:System.Resources.ResourceManager> uses to probe for resource files.

- If the default culture's resources are located in a satellite assembly rather than in the main app assembly, the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute specifies the culture and the directory from which the runtime can load the resources.

## Windows 8.x Store apps

In Windows 8.x Store apps whose resources are loaded and retrieved by using the <xref:System.Resources.ResourceManager> class, the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute defines the neutral culture whose resources are used in the event of a failed probe. It does not specify the location of the resources. By default, <xref:System.Resources.ResourceManager> uses the app's package resource index (PRI) file to locate the resources of the default culture. The neutral culture that is defined by the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute is added to the end of the UI language list to simulate this effect.

If you load and retrieve resources by using the Windows Runtime[Windows.ApplicationModel.Resources.ResourceLoader](https://go.microsoft.com/fwlink/p/?LinkId=238182) class or the types in the [Windows.ApplicationModel.Resources.Core](https://go.microsoft.com/fwlink/p/?LinkId=238194) namespace, the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute is ignored.

## Examples

The following example uses a simple "Hello World" app to illustrate the use of the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to define a default or fallback culture. It requires the creation of separate resource files for the English (en), English (United States) (en-US), and French (France) (fr-FR) cultures. The following shows the contents of a text file named ExampleResources.txt for the English culture.

```
# Resources for the default (en) culture.
Greeting=Hello
```

To use the resource file in an app, you must use the [Resource File Generator (Resgen.exe)](../../framework/tools/resgen-exe-resource-file-generator.md) to convert the file from its text (.txt) format to a binary (.resources) format as follows:

```
resgen ExampleResources.txt
```

When the app is compiled, the binary resource file will be embedded in the main app assembly.

The following shows the contents of a text file named ExampleResources.en-US.txt that provides resources for the English (United States) culture.

```
# Resources for the en-US culture.
Greeting=Hi
```

The text file can be converted to a binary resources file by using the [Resource File Generator (ResGen.exe)](../../framework/tools/resgen-exe-resource-file-generator.md) at the command line as follows:

```
resgen ExampleResources.en-US.txt ExampleResources.en-US.resources
```

The binary resource file should then be compiled into an assembly by using [Assembly Linker (Al.exe)](../../framework/tools/al-exe-assembly-linker.md) and placed in the en-US subdirectory of the app directory by issuing the following command:

```
al /t:lib /embed:ExampleResources.en-US.resources /culture:en-US /out:en-us\Example.resources.dll
```

The following shows the contents of a text file named ExampleResources.fr-FR.txt that provides resources for the French (France) culture.

```
# Resources for the fr-FR culture.
Greeting=Bonjour
```

The text file can be converted to a binary resource file by using ResGen.exe at the command line as follows:

```
resgen ExampleResources.fr-FR.txt ExampleResources.fr-FR.resources
```

The binary resources file should then be compiled into an assembly by using Assembly Linker and placed in the fr-FR subdirectory of the app directory by issuing the following command:

```
al /t:lib /embed:ExampleResources.fr-FR.resources /culture:fr-FR /out:fr-FR\Example.resources.dll
```

The following example provides the executable code that sets the current culture, prompts for the user's name, and displays a localized string.

:::code language="csharp" source="./snippets/System.Resources/NeutralResourcesLanguageAttribute/Overview/csharp/example.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Resources/NeutralResourcesLanguageAttribute/Overview/vb/example.vb" id="Snippet1":::

It can be compiled by using the following command in Visual Basic:

```
vbc Example.vb /resource:ExampleResources.resources
```

or by using the following command in C#:

```
csc Example.cs /resource:ExampleResources.resources
```
