---
title: "Retrieve resources in .NET apps"
description: Retrieve resources in .NET apps. Package resources for the default (neutral) culture with the main assembly and create a satellite assembly for each culture.
ms.date: 08/09/2021
dev_langs: 
 - "csharp"
 - "vb"
helpviewer_keywords: 
 - "deploying applications [.NET Framework], resources"
 - "resource files, deploying"
 - "resource files, packaging"
 - "application resources, packaging"
 - "localization"
 - "versioning satellite assemblies"
 - "retrieving localized resources"
 - "application resources, deploying"
 - "packaging application resources"
 - "versioning resources"
 - "translating resources into languages"
 - "localizing resources"
ms.assetid: eca16922-1c46-4f68-aefe-e7a12283641f
---

# Retrieve resources in .NET apps

When you work with localized resources in .NET apps, you should ideally package the resources for the default or neutral culture with the main assembly and create a separate satellite assembly for each language or culture that your app supports. You can then use the <xref:System.Resources.ResourceManager> class as described in the next section to access named resources. If you choose not to embed your resources in the main assembly and satellite assemblies, you can also access binary *.resources* files directly, as discussed in the section [Retrieve resources from .resources files](#from_file) later in this article.

<a name="from_assembly"></a>

## Retrieve resources from assemblies

The <xref:System.Resources.ResourceManager> class provides access to resources at run time. You use the <xref:System.Resources.ResourceManager.GetString%2A?displayProperty=nameWithType> method to retrieve string resources and the <xref:System.Resources.ResourceManager.GetObject%2A?displayProperty=nameWithType> or <xref:System.Resources.ResourceManager.GetStream%2A?displayProperty=nameWithType> method to retrieve non-string resources. Each method has two overloads:

- An overload whose single parameter is a string that contains the name of the resource. The method attempts to retrieve that resource for the current culture. For more information, see the <xref:System.Resources.ResourceManager.GetString%28System.String%29>, <xref:System.Resources.ResourceManager.GetObject%28System.String%29>, and <xref:System.Resources.ResourceManager.GetStream%28System.String%29> methods.

- An overload that has two parameters: a string containing the name of the resource, and a <xref:System.Globalization.CultureInfo> object that represents the culture whose resource is to be retrieved. If a resource set for that culture cannot be found, the resource manager uses fallback rules to retrieve an appropriate resource. For more information, see the <xref:System.Resources.ResourceManager.GetString%28System.String%2CSystem.Globalization.CultureInfo%29>, <xref:System.Resources.ResourceManager.GetObject%28System.String%2CSystem.Globalization.CultureInfo%29>, and <xref:System.Resources.ResourceManager.GetStream%28System.String%2CSystem.Globalization.CultureInfo%29> methods.

The resource manager uses the resource fallback process to control how the app retrieves culture-specific resources. For more information, see the "Resource Fallback Process" section in [Package and deploy resources](package-and-deploy-resources.md). For information about instantiating a <xref:System.Resources.ResourceManager> object, see the "Instantiating a ResourceManager Object" section in the <xref:System.Resources.ResourceManager> class topic.

### Retrieve string data example

The following example calls the <xref:System.Resources.ResourceManager.GetString%28System.String%29> method to retrieve the string resources of the current UI culture. It includes a neutral string resource for the English (United States) culture and localized resources for the French (France) and Russian (Russia) cultures. The following English (United States) resource is in a file named Strings.txt:

```text
TimeHeader=The current time is
```

The French (France) resource is in a file named Strings.fr-FR.txt:

```text
TimeHeader=L'heure actuelle est
```

The Russian (Russia) resource is in a file named Strings.ru-RU-txt:

```text
TimeHeader=Текущее время —
```

The source code for this example, which is in a file named GetString.cs for the C# version of the code and GetString.vb for the Visual Basic version, defines a string array that contains the name of four cultures: the three cultures for which resources are available and the Spanish (Spain) culture. A loop that executes five times randomly selects one of these cultures and assigns it to the <xref:System.Threading.Thread.CurrentCulture%2A?displayProperty=nameWithType> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> properties. It then calls the <xref:System.Resources.ResourceManager.GetString%28System.String%29> method to retrieve the localized string, which it displays along with the time of day.

[!code-csharp[Conceptual.Resources.Retrieving#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/getstring.cs#3)]
[!code-vb[Conceptual.Resources.Retrieving#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/getstring.vb#3)]

The following batch (*.bat*) file compiles the example and generates satellite assemblies in the appropriate directories. The commands are provided for the C# language and compiler. For Visual Basic, change `csc` to `vbc`, and change `GetString.cs` to `GetString.vb`.

```console
resgen strings.txt
csc GetString.cs -resource:strings.resources

resgen strings.fr-FR.txt
md fr-FR
al -embed:strings.fr-FR.resources -culture:fr-FR -out:fr-FR\GetString.resources.dll

resgen strings.ru-RU.txt
md ru-RU
al -embed:strings.ru-RU.resources -culture:ru-RU -out:ru-RU\GetString.resources.dll
```

When the current UI culture is Spanish (Spain), note that the example displays English language resources, because Spanish language resources are unavailable, and English is the example's default culture.

### Retrieve object data examples

You can use the <xref:System.Resources.ResourceManager.GetObject%2A> and <xref:System.Resources.ResourceManager.GetStream%2A> methods to retrieve object data. This includes primitive data types, serializable objects, and objects that are stored in binary format (such as images).

The following example uses the <xref:System.Resources.ResourceManager.GetStream%28System.String%29> method to retrieve a bitmap that is used in an app's opening splash window. The following source code in a file named CreateResources.cs (for C#) or CreateResources.vb (for Visual Basic) generates a .resx file that contains the serialized image. In this case, the image is loaded from a file named SplashScreen.jpg; you can modify the file name to substitute your own image.

[!code-csharp[Conceptual.Resources.Retrieving#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/createresources.cs#4)]
[!code-vb[Conceptual.Resources.Retrieving#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/createresources.vb#4)]

The following code retrieves the resource and displays the image in a <xref:System.Windows.Forms.PictureBox> control.

[!code-csharp[Conceptual.Resources.Retrieving#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/getstream.cs#5)]
[!code-vb[Conceptual.Resources.Retrieving#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/getstream.vb#5)]

You can use the following batch file to build the C# example. For Visual Basic, change `csc` to `vbc`, and change the extension of the source code file from `.cs` to `.vb`.

```console
csc CreateResources.cs
CreateResources

resgen AppResources.resx

csc GetStream.cs -resource:AppResources.resources
```

The following example uses the <xref:System.Resources.ResourceManager.GetObject%28System.String%29?displayProperty=nameWithType> method to deserialize a custom object. The example includes a source code file named UIElements.cs (UIElements.vb for Visual Basic) that defines the following structure named `PersonTable`. This structure is intended to be used by a general table display routine that displays the localized names of table columns. Note that the `PersonTable` structure is marked with the <xref:System.SerializableAttribute> attribute.

[!code-csharp[Conceptual.Resources.Retrieving#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/example.cs#6)]
[!code-vb[Conceptual.Resources.Retrieving#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/example.vb#6)]

The following code from a file named CreateResources.cs (CreateResources.vb for Visual Basic) creates an XML resource file named UIResources.resx that stores a table title and a `PersonTable` object that contains information for an app that is localized for the English language.

[!code-csharp[Conceptual.Resources.Retrieving#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/example1.cs#7)]
[!code-vb[Conceptual.Resources.Retrieving#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/example.vb#7)]

The following code in a source code file named GetObject.cs (GetObject.vb) then retrieves the resources and displays them to the console.

[!code-csharp[Conceptual.Resources.Retrieving#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/example2.cs#8)]
[!code-vb[Conceptual.Resources.Retrieving#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/example2.vb#8)]

You can build the necessary resource file and assemblies and run the app by executing the following batch file. You must use the `/r` option to supply Resgen.exe with a reference to UIElements.dll so that it can access information about the `PersonTable` structure. If you're using C#, replace the `vbc` compiler name with `csc`, and replace the `.vb` extension with `.cs`.

```console
vbc -t:library UIElements.vb
vbc CreateResources.vb -r:UIElements.dll
CreateResources

resgen UIResources.resx  -r:UIElements.dll
vbc GetObject.vb -r:UIElements.dll -resource:UIResources.resources

GetObject.exe
```

## Version support for satellite assemblies

By default, when the <xref:System.Resources.ResourceManager> object retrieves requested resources, it looks for satellite assemblies that have version numbers that match the version number of the main assembly. After you have deployed an app, you might want to update the main assembly or specific resource satellite assemblies. The .NET Framework provides support for versioning the main assembly and satellite assemblies.

The <xref:System.Resources.SatelliteContractVersionAttribute> attribute  provides versioning support for a main assembly. Specifying this attribute on an app's main assembly enables you to update and redeploy a main assembly without updating its satellite assemblies. After you update the main assembly, increment the main assembly's version number but leave the satellite contract version number unchanged. When the resource manager retrieves requested resources, it loads the satellite assembly version specified by this attribute.

Publisher policy assemblies provide support for versioning satellite assemblies. You can update and redeploy a satellite assembly without updating the main assembly. After you update a satellite assembly, increment its version number and ship it with a publisher policy assembly. In the publisher policy assembly, specify that your new satellite assembly is backward-compatible with its previous version. The resource manager will use the <xref:System.Resources.SatelliteContractVersionAttribute> attribute to determine the version of the satellite assembly, but the assembly loader will bind to the satellite assembly version specified by the publisher policy. For more information about publisher policy assemblies, see [Create a publisher policy file](../../framework/configure-apps/how-to-create-a-publisher-policy.md).

To enable full assembly versioning support, we recommend that you deploy strong-named assemblies in the [global assembly cache](../../framework/app-domains/gac.md) and deploy assemblies that don't have strong names in the application directory. If you want to deploy strong-named assemblies in the application directory, you will not be able to increment a satellite assembly's version number when you update the assembly. Instead, you must perform an in-place update where you replace the existing code with the updated code and maintain the same version number. For example, if you want to update version 1.0.0.0 of a satellite assembly with the fully specified assembly name "myApp.resources, Version=1.0.0.0, Culture=de, PublicKeyToken=b03f5f11d50a3a", overwrite it with the updated myApp.resources.dll that has been compiled with the same, fully specified assembly name "myApp.resources, Version=1.0.0.0, Culture=de, PublicKeyToken=b03f5f11d50a3a". Note that using in-place updates on satellite assembly files makes it difficult for an app to accurately determine the version of a satellite assembly.

For more information about assembly versioning, see [Assembly versioning](../../standard/assembly/versioning.md) and [How the Runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md).

<a name="from_file"></a>

## Retrieve resources from .resources Files

If you choose not to deploy resources in satellite assemblies, you can still use a <xref:System.Resources.ResourceManager> object to access resources from .resources files directly. To do this, you must deploy the .resources files correctly. Then you use the <xref:System.Resources.ResourceManager.CreateFileBasedResourceManager%2A?displayProperty=nameWithType> method to instantiate a <xref:System.Resources.ResourceManager> object and specify the directory that contains the standalone .resources files.

### Deploy .resources Files

When you embed .resources files in an application assembly and satellite assemblies, each satellite assembly has the same file name, but is placed in a subdirectory that reflects the satellite assembly's culture. In contrast, when you access resources from .resources files directly, you can place all the .resources files in a single directory, usually a subdirectory of the application directory. The name of the app's default .resources file consists of a root name only, with no indication of its culture (for example, strings.resources). The resources for each localized culture are stored in a file whose name consists of the root name followed by the culture (for example, strings.ja.resources or strings.de-DE.resources).

The following illustration shows where resource files should be located in the directory structure. It also gives the naming conventions for .resource files.

:::image type="content" source="media/retrieve-resources/resource-application-directory.gif" alt-text="Illustration that shows the main directory for your application.":::

### Use the resource manager

After you have created your resources and placed them in the appropriate directory, you create a <xref:System.Resources.ResourceManager> object to use the resources by calling the <xref:System.Resources.ResourceManager.CreateFileBasedResourceManager%28System.String%2CSystem.String%2CSystem.Type%29> method. The first parameter specifies the root name of the app's default .resources file (this would be "strings" for the example in the previous section). The second parameter specifies the location of the resources ("Resources" for the previous example). The third parameter specifies the <xref:System.Resources.ResourceSet> implementation to use. If the third parameter is `null`, the default runtime <xref:System.Resources.ResourceSet> is used.

> [!NOTE]
> Do not deploy ASP.NET apps using standalone .resources files. This can cause locking issues and breaks XCOPY deployment. We recommend that you deploy ASP.NET resources in satellite assemblies. For more information, see [ASP.NET Web Page Resources Overview](/previous-versions/aspnet/ms227427(v=vs.100)).

After you instantiate the <xref:System.Resources.ResourceManager> object, you use the <xref:System.Resources.ResourceManager.GetString%2A>, <xref:System.Resources.ResourceManager.GetObject%2A>, and <xref:System.Resources.ResourceManager.GetStream%2A> methods as discussed earlier to retrieve the resources. However, the retrieval of resources directly from .resources files differs from the retrieval of embedded resources from assemblies. When you retrieve resources from .resources files, the <xref:System.Resources.ResourceManager.GetString%28System.String%29>, <xref:System.Resources.ResourceManager.GetObject%28System.String%29>, and <xref:System.Resources.ResourceManager.GetStream%28System.String%29> methods always retrieve the default culture's resources regardless of the current culture. To retrieve the resources of either the app's current culture or a specific culture, you must call the <xref:System.Resources.ResourceManager.GetString%28System.String%2CSystem.Globalization.CultureInfo%29>, <xref:System.Resources.ResourceManager.GetObject%28System.String%2CSystem.Globalization.CultureInfo%29>, or <xref:System.Resources.ResourceManager.GetStream%28System.String%2CSystem.Globalization.CultureInfo%29> method and specify the culture whose resources are to be retrieved. To retrieve the resources of the current culture, specify the value of the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property as the `culture` argument. If the resource manager cannot retrieve the resources of `culture`, it uses the standard resource fallback rules to retrieve the appropriate resources.

### An example

The following example illustrates how the resource manager retrieves resources directly from .resources files. The example consists of three text-based resource files for the English (United States), French (France), and Russian (Russia) cultures. English (United States) is the example's default culture. Its resources are stored in the following file named *Strings.txt*:

```text
Greeting=Hello
Prompt=What is your name?
```

Resources for the French (France) culture are stored in the following file, which is named Strings.fr-FR.txt:

```text
Greeting=Bon jour
Prompt=Comment vous appelez-vous?
```

Resources for the Russian (Russia) culture are stored in the following file, which is named Strings.ru-RU.txt:

```text
Greeting=Здравствуйте
Prompt=Как вас зовут?
```

The following is the source code for the example. The example instantiates <xref:System.Globalization.CultureInfo> objects for the English (United States), English (Canada), French (France), and Russian (Russia) cultures, and makes each the current culture. The <xref:System.Resources.ResourceManager.GetString%28System.String%2CSystem.Globalization.CultureInfo%29?displayProperty=nameWithType> method then supplies the value of the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property as the `culture` argument to retrieve the appropriate culture-specific resources.

[!code-csharp[Conceptual.Resources.Retrieving#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.retrieving/cs/example3.cs#9)]
[!code-vb[Conceptual.Resources.Retrieving#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.retrieving/vb/example3.vb#9)]

You can compile the C# version of the example by running the following batch file. If you're using Visual Basic, replace `csc` with `vbc`, and replace the `.cs` extension with `.vb`.

```console
md Resources
resgen Strings.txt Resources\Strings.resources
resgen Strings.fr-FR.txt Resources\Strings.fr-FR.resources
resgen Strings.ru-RU.txt Resources\Strings.ru-RU.resources

csc Example.cs
```

## See also

- <xref:System.Resources.ResourceManager>
- [Resources in .NET apps](resources.md)
- [Package and deploy resources](package-and-deploy-resources.md)
- [How the Runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md)
