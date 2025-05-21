---
title: System.Resources.ResourceManager constructors
description: Learn about the System.Resources.ResourceManager constructors.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Resources.ResourceManager constructors

[!INCLUDE [context](includes/context.md)]

## <xref:System.Resources.ResourceManager.%23ctor(System.Type)> constructor

This section pertains to the <xref:System.Resources.ResourceManager.%23ctor(System.Type)> constructor overload.

### Desktop apps

In desktop apps, the resource manager uses the `resourceSource` parameter to load a particular resource file as follows:

- If the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute is not used to indicate that the resources of the default culture reside in a satellite assembly, the resource manager assumes that the resource file for the default culture is found in the same assembly as the type specified by the `resourceSource` parameter.
- The resource manager assumes that the default resource file has the same base name as the type specified by the `resourceSource` parameter.
- The resource manager uses the default <xref:System.Resources.ResourceSet> class to manipulate the resource file.

For example, given a type named `MyCompany.MyProduct.MyType`, the resource manager looks for a *.resources* file named *MyCompany.MyProduct.MyType.resources* in the assembly that defines `MyType`.

In Visual Studio, the Resource Designer automatically generates code that defines an `internal` (in C#) or `Friend` (in Visual Basic) class whose name is the same as the base name of the *.resources* file for the default culture. This makes it possible to instantiate a <xref:System.Resources.ResourceManager> object and couple it with a particular set of resources by getting a type object whose name corresponds to the name of the resource, because as long as the class is visible to the compiler, the resources must be as well. For example, if a *.resources* file is named Resource1, the following statement instantiates a <xref:System.Resources.ResourceManager> object to manage the *.resources* file named Resource1:

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/.ctor/csharp/ctor1.cs" id="Snippet2":::

If you're not using Visual Studio, you can create a class with no members whose namespace and name are the same as that of the default *.resources* file. The example provides an illustration.

### Windows 8.x apps

> [!IMPORTANT]
> Although the <xref:System.Resources.ResourceManager> class is supported in Windows 8.x apps, we do not recommend its use. Use this class only when you develop Portable Class Library projects that can be used with Windows 8.x apps. To retrieve resources from Windows 8.x apps, use the [Windows.ApplicationModel.Resources.ResourceLoader](/uwp/api/windows.applicationmodel.resources.resourceloader) class instead.

In Windows 8.x apps, <xref:System.Resources.ResourceManager> uses the `resourceSource` parameter to infer the assembly, base name, and the namespace where the resource items can be located within the app's package resource index (PRI) file. For example, given a type named `MyCompany.MyProduct.MyType` that's defined in `MyAssembly`, the resource manager looks for a resource set identifier named `MyAssembly` and looks for a scope `MyCompany.MyProduct.MyType` within that resource set. The resource manager searches for resource items under the default context (current culture, current high contrast setting, and so on) within this scope.

### Example

The following example uses the <xref:System.Resources.ResourceManager.%23ctor(System.Type)> constructor to instantiate a <xref:System.Resources.ResourceManager> object. It consists of resources compiled from .txt files for the English (en), French (France) (fr-FR), and Russian (Russia) (ru-RU) cultures. The example changes the current culture and current UI culture to English (United States), French (France), Russian (Russia), and Swedish (Sweden). It then calls the <xref:System.Resources.ResourceManager.GetString(System.String)> method to retrieve the localized string, which displays a greeting that depends on the time of day.

The example requires three text-based resource files, as listed in the following table. Each file includes string resources named `Morning`, `Afternoon`, and `Evening`.

| Culture | File name                   | Resource name | Resource value |
|---------|-----------------------------|---------------|----------------|
| en-US   | GreetingResources.txt       | `Morning`     | Good morning   |
| en-US   | GreetingResources.txt       | `Afternoon`   | Good afternoon |
| en-US   | GreetingResources.txt       | `Evening`     | Good evening   |
| fr-FR   | GreetingResources.fr-FR.txt | `Morning`     | Bonjour        |
| fr-FR   | GreetingResources.fr-FR.txt | `Afternoon`   | Bonjour        |
| fr-FR   | GreetingResources.fr-FR.txt | `Evening`     | Bonsoir        |
| ru-RU   | GreetingResources.ru-RU.txt | `Morning`     | Доброе утро    |
| ru-RU   | GreetingResources.ru-RU.txt | `Afternoon`   | Добрый день    |
| ru-RU   | GreetingResources.ru-RU.txt | `Evening`     | Добрый вечер   |

You can use the following batch file to compile the Visual Basic example and create an executable named Greet.exe. To compile with C#, change the compiler name from `vbc` to `csc` and the file extension from `.vb` to `.cs`.

```
resgen GreetingResources.txt
vbc Greet.vb /resource: GreetingResources.resources

md fr-FR
resgen GreetingResources.fr-FR.txt
al /out:fr-FR\Greet.resources.dll /culture:fr-FR /embed: GreetingResources.fr-FR.resources

md ru-RU
resgen GreetingResources.ru-RU.txt
al /out:ru-RU\Greet.resources.dll /culture:ru-RU /embed: GreetingResources.ru-RU.resources
```

Here's the source code for the example (ShowDate.vb for the Visual Basic version or ShowDate.cs for the C# version of the code).

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/.ctor/csharp/greet.cs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/.ctor/vb/greet.vb" id="Snippet3":::

In addition to defining an app class named `Example`, the source code defines an internal class whose name, `GreetingResources`, is the same as the base name of the resource files. This makes it possible to successfully instantiate a <xref:System.Resources.ResourceManager> object by calling the <xref:System.Resources.ResourceManager.%23ctor(System.Type)> constructor.

Notice that the output displays the appropriate localized string except when the current UI culture is Swedish (Sweden), in which case it uses English language resources. Because Swedish language resources are unavailable, the app uses the resources of the default culture, as defined by the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute, instead.

## <xref:System.Resources.ResourceManager.%23ctor(System.String,System.Reflection.Assembly)> constructor

This section pertains to the <xref:System.Resources.ResourceManager.%23ctor(System.String,System.Reflection.Assembly)> constructor overload.

### Desktop apps

In desktop apps, the individual culture-specific resource files should be contained in satellite assemblies, and the default culture's resource file should be contained in the main assembly. A satellite assembly is assumed to contain resources for a single culture specified in that assembly's manifest, and is loaded as necessary.

> [!NOTE]
> To retrieve resources from *.resources* files directly instead of retrieving them from assemblies, you must call the <xref:System.Resources.ResourceManager.CreateFileBasedResourceManager%2A> method instead to instantiate a <xref:System.Resources.ResourceManager> object.

If the resource file identified by `baseName` cannot be found in `assembly`, the method instantiates a <xref:System.Resources.ResourceManager> object, but the attempt to retrieve a specific resource throws an exception, typically <xref:System.Resources.MissingManifestResourceException>. For information about diagnosing the cause of the exception, see the "Handling the MissingManifestResourceException Exception" section of the <xref:System.Resources.ResourceManager> class topic.

### Windows 8.x apps

> [!IMPORTANT]
> Although the <xref:System.Resources.ResourceManager> class is supported in Windows 8.x apps, we do not recommend its use. Use this class only when you develop Portable Class Library projects that can be used with Windows 8.x apps. To retrieve resources from Windows 8.x apps, use the [Windows.ApplicationModel.Resources.ResourceLoader](/uwp/api/windows.applicationmodel.resources.resourceloader) class instead.

In Windows 8.x apps, the resource manager uses the simple name of the `assembly` parameter to look up a matching resource set in the app's package resource index (PRI) file. The `baseName` parameter is used to look up a resource item within the resource set. For example, the root name for PortableLibrary1.Resource1.de-DE.resources is PortableLibrary1.Resource1.

### Example

The following example uses a simple non-localized "Hello World" app to illustrate the <xref:System.Resources.ResourceManager.%23ctor(System.String,System.Reflection.Assembly)> constructor. The contents of a text file named *ExampleResources.txt* is `Greeting=Hello`. When the app is compiled, the resource is embedded in the main app assembly.

The text file can be converted to a binary resource file by using the [Resource File Generator (ResGen.exe)](../../framework/tools/resgen-exe-resource-file-generator.md) at the command prompt as follows:

```cmd
resgen ExampleResources.txt
```

The following example provides the executable code that instantiates a <xref:System.Resources.ResourceManager> object, prompts the user to enter a name, and displays a greeting.

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/.ctor/csharp/example.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/.ctor/vb/example.vb" id="Snippet1":::

It can be compiled by using the following command in C#:

```cmd
csc Example.cs /resource:ExampleResources.resources
```

The example retrieves a reference to the assembly that contains the resource file by passing a type defined in that assembly to the `typeof` function (in C#) or the `GetType` function (in Visual Basic) and retrieving the value of its <xref:System.Type.Assembly%2A?displayProperty=nameWithType> property.
