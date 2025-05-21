---
title: System.Resources.ResourceManager class
description: Learn more about the System.Resources.ResourceManager class through these supplemental API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Resources.ResourceManager class

[!INCLUDE [context](includes/context.md)]

[!INCLUDE [untrusted-data-class-note](./includes/untrusted-data-class-note.md)]

The <xref:System.Resources.ResourceManager> class retrieves resources from a binary .resources file that is embedded in an assembly or from a standalone .resources file. If an app has been localized and localized resources have been deployed in [satellite assemblies](/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps), it looks up culture-specific resources, provides resource fallback when a localized resource does not exist, and supports resource serialization.

## Desktop apps

For desktop apps, the <xref:System.Resources.ResourceManager> class retrieves resources from binary resource (.resources) files. Typically, a language compiler or the [Assembly Linker (AL.exe)](../../framework/tools/al-exe-assembly-linker.md) embeds these resource files in an assembly. You can also use a <xref:System.Resources.ResourceManager> object to retrieve resources directly from a .resources file that is not embedded in an assembly, by calling the <xref:System.Resources.ResourceManager.CreateFileBasedResourceManager%2A> method.

> [!CAUTION]
> Using standalone .resources files in an ASP.NET app will break XCOPY deployment, because the resources remain locked until they are explicitly released by the <xref:System.Resources.ResourceManager.ReleaseAllResources%2A> method. If you want to deploy resources with your ASP.NET apps, you should compile your .resources files into satellite assemblies.

In a resource-based app, one .resources file contains the resources of the default culture whose resources are used if no culture-specific resources can be found. For example, if an app's default culture is English (en), the English language resources are used whenever localized resources cannot be found for a specific culture, such as English (United States) (en-US) or French (France) (fr-FR). Typically, the resources for the default culture are embedded in the main app assembly, and resources for other localized cultures are embedded in satellite assemblies. Satellite assemblies contain only resources. They have the same root file name as the main assembly and an extension of .resources.dll. For apps whose assemblies are not registered in the global assembly cache, satellite assemblies are stored in an app subdirectory whose name corresponds to the assembly's culture.

### Create resources

When you develop a resource-based app, you store resource information in text files (files that have a .txt or .restext extension) or XML files (files that have a .resx extension). You then compile the text or XML files with the [Resource File Generator (Resgen.exe)](../../framework/tools/resgen-exe-resource-file-generator.md) to create a binary .resources file. You can then embed the resulting .resources file in an executable or library by using a compiler option such as `/resources` for the C# and Visual Basic compilers, or you can embed it in a satellite assembly by using the [Assembly Linker (AI.exe)](../../framework/tools/al-exe-assembly-linker.md). If you include a .resx file in your Visual Studio project, Visual Studio handles the compilation and embedding of default and localized resources automatically as part of the build process.

Ideally, you should create resources for every language your app supports, or at least for a meaningful subset of each language. The binary .resources file names follow the naming convention *basename*.*cultureName*.resources, where *basename* is the name of the app or the name of a class, depending on the level of detail you want. The <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType> property is used to determine *cultureName*. A resource for the app's default culture should be named *basename*.resources.

For example, suppose that an assembly has several resources in a resource file that has the base name MyResources. These resource files should have names such as MyResources.ja-JP.resources for the Japan (Japanese) culture, MyResources.de.resources for the German culture, MyResources.zh-CHS.resources for the simplified Chinese culture, and MyResources.fr-BE.resources for the French (Belgium) culture. The default resource file should be named MyResources.resources. The culture-specific resource files are commonly packaged in satellite assemblies for each culture. The default resource file should be embedded in the app's main assembly.

Note that [Assembly Linker](../../framework/tools/al-exe-assembly-linker.md) allows resources to be marked as private, but you should always mark them as public so they can be accessed by other assemblies. (Because a satellite assembly contains no code, resources that are marked as private are unavailable to your app through any mechanism.)

For more information about creating, packaging, and deploying resources, see the articles [Creating Resource Files](/dotnet/framework/resources/creating-resource-files-for-desktop-apps), [Creating Satellite Assemblies](/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps), and [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps).

### Instantiate a ResourceManager object

You instantiate a <xref:System.Resources.ResourceManager> object that retrieves resources from an embedded .resources file by calling one of its class constructor overloads. This tightly couples a <xref:System.Resources.ResourceManager> object with a particular .resources file and with any associated localized .resources files in satellite assemblies.

The two most commonly called constructors are:

- <xref:System.Resources.ResourceManager.%23ctor%28System.String%2CSystem.Reflection.Assembly%29> looks up resources based on two pieces of information that you supply: the base name of the .resources file, and the assembly in which the default .resources file resides. The base name includes the namespace and root name of the .resources file, without its culture or extension. Note that .resources files that are compiled from the command line typically do not include a namespace name, whereas .resources files that are created in the Visual Studio environment do. For example, if a resource file is named MyCompany.StringResources.resources and the <xref:System.Resources.ResourceManager> constructor is called from a static method named `Example.Main`, the following code instantiates a <xref:System.Resources.ResourceManager> object that can retrieve resources from the .resources file:

  :::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/ctor1.cs" id="Snippet1":::
  :::code language="vb" source="./snippets/System.Resources/ResourceManager/Overview/vb/ctor1.vb" id="Snippet1":::

- <xref:System.Resources.ResourceManager.%23ctor%28System.Type%29> looks up resources in satellite assemblies based on information from a type object. The type's fully qualified name corresponds to the base name of the .resources file without its file name extension. In desktop apps that are created by using the Visual Studio Resource Designer, Visual Studio creates a wrapper class whose fully qualified name is the same as the root name of the .resources file. For example, if a resource file is named MyCompany.StringResources.resources and there is a wrapper class named `MyCompany.StringResources`, the following code instantiates a <xref:System.Resources.ResourceManager> object that can retrieve resources from the .resources file:

  :::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/ctor1.cs" id="Snippet2":::
  :::code language="vb" source="./snippets/System.Resources/ResourceManager/Overview/vb/ctor1.vb" id="Snippet2":::

If the appropriate resources cannot be found, the constructor call creates a valid <xref:System.Resources.ResourceManager> object. However, the attempt to retrieve a resource throws a <xref:System.Resources.MissingManifestResourceException> exception. For information about dealing with the exception, see the [Handle MissingManifestResourceException and MissingSatelliteAssemblyException Exceptions](#handle-missingmanifestresourceexception-and-missingsatelliteassemblyexception-exceptions) section later in this article.

The following example shows how to instantiate a <xref:System.Resources.ResourceManager> object. It contains the source code for an executable named ShowTime.exe. It also includes the following text file named Strings.txt that contains a single string resource, `TimeHeader`:

```
TimeHeader=The current time is
```

You can use a batch file to generate the resource file and embed it into the executable. Here's the batch file to generate an executable by using the C# compiler:

```
resgen strings.txt
csc ShowTime.cs /resource:strings.resources
```

For the Visual Basic compiler, you can use the following batch file:

```
resgen strings.txt
vbc ShowTime.vb /resource:strings.resources
```

:::code language="csharp" source="./snippets/System.Resources/MissingManifestResourceException/Overview/csharp/showtime.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/Overview/vb/showtime.vb" id="Snippet1":::

### ResourceManager and culture-specific resources

A localized app requires resources to be deployed, as discussed in the article [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps). If the assemblies are properly configured, the resource manager determines which resources to retrieve based on the current thread's <xref:System.Threading.Thread.CurrentUICulture?displayProperty=nameWithType> property. (That property also returns the current thread's UI culture.) For example, if an app is compiled with default English language resources in the main assembly and with French and Russian language resources in two satellite assemblies, and the <xref:System.Threading.Thread.CurrentUICulture?displayProperty=nameWithType> property is set to fr-FR, the resource manager retrieves the French resources.

You can set the <xref:System.Globalization.CultureInfo.CurrentUICulture> property explicitly or implicitly. The way you set it determines how the <xref:System.Resources.ResourceManager> object retrieves resources based on culture:

- If you explicitly set the <xref:System.Threading.Thread.CurrentUICulture?displayProperty=nameWithType> property to a specific culture, the resource manager always retrieves the resources for that culture, regardless of the user's browser or operating system language. Consider an app that is compiled with default English language resources and three satellite assemblies that contain resources for English (United States), French (France), and Russian (Russia). If the <xref:System.Globalization.CultureInfo.CurrentUICulture> property is set to fr-FR, the <xref:System.Resources.ResourceManager> object always retrieves the French (France) resources, even if the user's operating system language is not French. Make sure that this is the desired behavior before you set the property explicitly.

  In ASP.NET apps, you must set the <xref:System.Threading.Thread.CurrentUICulture?displayProperty=nameWithType> property explicitly, because it is unlikely that the setting on the server will match incoming client requests. An ASP.NET app can set the <xref:System.Threading.Thread.CurrentUICulture?displayProperty=nameWithType> property explicitly to the user's browser accept language.

  Explicitly setting the <xref:System.Threading.Thread.CurrentUICulture?displayProperty=nameWithType> property defines the current UI culture for that thread. It does not affect the current UI culture of any other threads in an app.

- You can set the UI culture of all threads in an app domain by assigning a <xref:System.Globalization.CultureInfo> object that represents that culture to the static <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture?displayProperty=nameWithType> property.

- If you do not explicitly set the current UI culture and you do not define a default culture for the current app domain, the <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=nameWithType> property is set implicitly by the Windows `GetUserDefaultUILanguage` function. This function is provided by the Multilingual User Interface (MUI), which enables the user to set the default language. If the UI language is not set by the user, it defaults to the system-installed language, which is the language of operating system resources.

The following simple "Hello world" example sets the current UI culture explicitly. It contains resources for three cultures: English (United States) or en-US, French (France) or fr-FR, and Russian (Russia) or ru-RU. The en-US resources are contained in a text file named Greetings.txt:

```
HelloString=Hello world!
```

The fr-FR resources are contained in a text file named Greetings.fr-FR.txt:

```
HelloString=Salut tout le monde!
```

The ru-RU resources are contained in a text file named Greetings.ru-RU.txt:

```
HelloString=Всем привет!
```

Here's the source code for the example (Example.vb for the Visual Basic version or Example.cs for the C# version):

:::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/example.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Resources/CurrentCulture/Overview/vb/example.vb" id="Snippet1":::

To compile this example, create a batch (.bat) file that contains the following commands and run it from the command prompt. If you're using C#, specify `csc` instead of `vbc` and `Example.cs` instead of `Example.vb`.

```
resgen Greetings.txt
vbc Example.vb /resource:Greetings.resources

resgen Greetings.fr-FR.txt
Md fr-FR
al /embed:Greetings.fr-FR.resources /culture:fr-FR /out:fr-FR\Example.resources.dll

resgen Greetings.ru-RU.txt
Md ru-RU
al /embed:Greetings.ru-RU.resources /culture:ru-RU /out:ru-RU\Example.resources.dll
```

### Retrieve resources

You call the <xref:System.Resources.ResourceManager.GetObject%28System.String%29> and <xref:System.Resources.ResourceManager.GetString%28System.String%29> methods to access a specific resource. You can also call the <xref:System.Resources.ResourceManager.GetStream%28System.String%29> method to retrieve non-string resources as a byte array. By default, in an app that has localized resources, these methods return the resource for the culture determined by the current UI culture of the thread that made the call. See the previous section, [ResourceManager and culture-specific resources](#resourcemanager-and-culture-specific-resources), for more information about how the current UI culture of a thread is defined. If the resource manager cannot find the resource for the current thread's UI culture, it uses a fallback process to retrieve the specified resource. If the resource manager cannot find any localized resources, it uses the resources of the default culture. For more information about resource fallback rules, see the "Resource Fallback Process" section of the article [Packaging and Deploying Resources](/dotnet/framework/resources/packaging-and-deploying-resources-in-desktop-apps).

> [!NOTE]
> If the .resources file specified in the <xref:System.Resources.ResourceManager> class constructor cannot be found, the attempt to retrieve a resource throws a <xref:System.Resources.MissingManifestResourceException> or <xref:System.Resources.MissingSatelliteAssemblyException> exception. For information about dealing with the exception, see the [Handle MissingManifestResourceException and MissingSatelliteAssemblyException Exceptions](#handle-missingmanifestresourceexception-and-missingsatelliteassemblyexception-exceptions) section later in this article.

The following example uses the <xref:System.Resources.ResourceManager.GetString%2A> method to retrieve culture-specific resources. It consists of resources compiled from .txt files for the English (en), French (France) (fr-FR), and Russian (Russia) (ru-RU) cultures. The example changes the current culture and current UI culture to English (United States), French (France), Russian (Russia), and Swedish (Sweden). It then calls the <xref:System.Resources.ResourceManager.GetString%2A> method to retrieve the localized string, which it displays along with the current day and month. Notice that the output displays the appropriate localized string except when the current UI culture is Swedish (Sweden). Because Swedish language resources are unavailable, the app instead uses the resources of the default culture, which is English.

The example requires the text-based resource files listed in following table. Each has a single string resource named `DateStart`.

| Culture | File name             | Resource name | Resource value        |
|---------|-----------------------|---------------|-----------------------|
| en-US   | DateStrings.txt       | `DateStart`   | Today is              |
| fr-FR   | DateStrings.fr-FR.txt | `DateStart`   | Aujourd'hui, c'est le |
| ru-RU   | DateStrings.ru-RU.txt | `DateStart`   | Сегодня               |

Here's the source code for the example (ShowDate.vb for the Visual Basic version or ShowDate.cs for the C# version of the code).

:::code language="csharp" source="./snippets/System.Resources/MissingManifestResourceException/Overview/csharp/showdate.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Resources/ResourceManager/Overview/vb/showdate.vb" id="Snippet2":::

To compile this example, create a batch file that contains the following commands and run it from the command prompt. If you're using C#, specify `csc` instead of `vbc` and `showdate.cs` instead of `showdate.vb`.

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

There are two ways to retrieve the resources of a specific culture other than the current UI culture:

- You can call the <xref:System.Resources.ResourceManager.GetString%28System.String%2CSystem.Globalization.CultureInfo%29>,  <xref:System.Resources.ResourceManager.GetObject%28System.String%2CSystem.Globalization.CultureInfo%29>, or <xref:System.Resources.ResourceManager.GetStream%28System.String%2CSystem.Globalization.CultureInfo%29> method to retrieve a resource for a specific culture. If a localized resource cannot be found, the resource manager uses the resource fallback process to locate an appropriate resource.
- You can call the <xref:System.Resources.ResourceManager.GetResourceSet%2A> method to obtain a <xref:System.Resources.ResourceSet> object that represents the resources for a particular culture. In the method call, you can determine whether the resource manager probes for parent cultures if it is unable to find localized resources, or whether it simply falls back to the resources of the default culture. You can then use the <xref:System.Resources.ResourceSet> methods to access the resources (localized for that culture) by name, or to enumerate the resources in the set.

### Handle MissingManifestResourceException and MissingSatelliteAssemblyException exceptions

If you try to retrieve a specific resource, but the resource manager cannot find that resource and either no default culture has been defined or the resources of the default culture cannot be located, the resource manager throws a <xref:System.Resources.MissingManifestResourceException> exception if it expects to find the resources in the main assembly or a <xref:System.Resources.MissingSatelliteAssemblyException> if it expects to find the resources in a satellite assembly. Note that the exception is thrown when you call a resource retrieval method such as <xref:System.Resources.ResourceManager.GetString%2A> or <xref:System.Resources.ResourceManager.GetObject%2A>, and not when you instantiate a <xref:System.Resources.ResourceManager> object.

The exception is typically thrown under the following conditions:

- The appropriate resource file or satellite assembly does not exist. If the resource manager expects the app's default resources to be embedded in the main app assembly, they are absent. If the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute indicates that the app's default resources reside in a satellite assembly, that assembly cannot be found. When you compile your app, make sure that resources are embedded in the main assembly or that the necessary satellite assembly is generated and is named appropriately. Its name should take the form *appName*.resources.dll, and it should be located in a directory named after the culture whose resources it contains.

- Your app doesn't have a default or neutral culture defined. Add the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to a source code file or to the project information file (AssemblyInfo.vb for a Visual Basic app or AssemblyInfo.cs for a C# app) file.

- The `baseName` parameter in the <xref:System.Resources.ResourceManager.%23ctor%28System.String%2CSystem.Reflection.Assembly%29> constructor does not specify the name of a .resources file. The name should include the resource file's fully qualified namespace but not its file name extension. Typically, resource files that are created in Visual Studio include namespace names, but resource files that are created and compiled at the command prompt do not. You can determine the names of embedded .resources files by compiling and running the following utility. This is a console app that accepts the name of a main assembly or satellite assembly as a command-line parameter. It displays the strings that should be provided as the `baseName` parameter so that the resource manager can correctly identify the resource.

  :::code language="csharp" source="./snippets/System.Resources/MissingManifestResourceException/Overview/csharp/resourcenames.cs" id="Snippet4":::
  :::code language="vb" source="./snippets/System.Resources/MissingManifestResourceException/Overview/vb/resourcenames.vb" id="Snippet4":::

If you are changing the current culture of your application explicitly, you should also remember that the resource manager retrieves a resource set based on the value of the <xref:System.Globalization.CultureInfo.CurrentUICulture?displayProperty=nameWithType> property, and not the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> property. Typically, if you change one value, you should also change the other.

### Resource versioning

Because the main assembly that contains an app's default resources is separate from the app's satellite assemblies, you can release a new version of your main assembly without redeploying the satellite assemblies. You use the <xref:System.Resources.SatelliteContractVersionAttribute> attribute to use existing satellite assemblies and instruct the resource manager not to redeploy them with a new version of your main assembly,

For more information about versioning support for satellite assemblies, see the article [Retrieving Resources](/dotnet/framework/resources/retrieving-resources-in-desktop-apps).

### \<satelliteassemblies> configuration file node

> [!NOTE]
> This section is specific to .NET Framework apps.

For executables that are deployed and run from a website (HREF .exe files), the <xref:System.Resources.ResourceManager> object may probe for satellite assemblies over the web, which can hurt your app's performance. To eliminate the performance problem, you can limit this probing to the satellite assemblies that you have deployed with your app. To do this, you create a `<satelliteassemblies>` node in your app's configuration file to specify that you have deployed a specific set of cultures for your app, and that the <xref:System.Resources.ResourceManager> object should not try to probe for any culture that is not listed in that node.

> [!NOTE]
> The preferred alternative to creating a `<satelliteassemblies>` node is to use the [ClickOnce Deployment Manifest](/visualstudio/deployment/clickonce-deployment-manifest) feature.

In your app's configuration file, create a section similar to the following:

```xml
<?xml version ="1.0"?>
<configuration>
  <satelliteassemblies>
    <assembly name="MainAssemblyName, Version=versionNumber, Culture=neutral, PublicKeyToken=null|yourPublicKeyToken">
      <culture>cultureName1</culture>
      <culture>cultureName2</culture>
      <culture>cultureName3</culture>
    </assembly>
  </satelliteassemblies>
</configuration>
```

Edit this configuration information as follows:

- Specify one or more `<assembly>` nodes for each main assembly that you deploy, where each node specifies a fully qualified assembly name. Specify the name of your main assembly in place of *MainAssemblyName*, and specify the `Version`, `PublicKeyToken`, and `Culture` attribute values that correspond to your main assembly.

  For the `Version` attribute, specify the version number of your assembly. For example, the first release of your assembly might be version number 1.0.0.0.

  For the `PublicKeyToken` attribute, specify the keyword `null` if you have not signed your assembly with a strong name, or specify your public key token if you have signed your assembly.

  For the `Culture` attribute, specify the keyword `neutral` to designate the main assembly and cause the <xref:System.Resources.ResourceManager> class to probe only for the cultures listed in the `<culture>` nodes.

  For more information about fully qualified assembly names, see the article [Assembly Names](../../standard/assembly/names.md). For more information about strong-named assemblies, see the article [Create and use strong-named assemblies](../../standard/assembly/create-use-strong-named.md).

- Specify one or more `<culture>` nodes with a specific culture name, such as "fr-FR", or a neutral culture name, such as "fr".

If resources are needed for any assembly not listed under the `<satelliteassemblies>` node, the <xref:System.Resources.ResourceManager> class probes for cultures using standard probing rules.

## Windows 8.x apps

> [!IMPORTANT]
> Although the <xref:System.Resources.ResourceManager> class is supported in Windows 8.x apps, we do not recommend its use. Use this class only when you develop Portable Class Library projects that can be used with Windows 8.x apps. To retrieve resources from Windows 8.x apps, use the [Windows.ApplicationModel.Resources.ResourceLoader](/uwp/api/Windows.ApplicationModel.Resources.ResourceLoader) class instead.

For Windows 8.x apps, the <xref:System.Resources.ResourceManager> class retrieves resources from package resource index (PRI) files. A single PRI file (the application package PRI file) contains the resources for both the default culture and any localized cultures. You use the MakePRI utility to create a PRI file from one or more resource files that are in XML resource (.resw) format. For resources that are included in a Visual Studio project, Visual Studio handles the process of creating and packaging the PRI file automatically. You can then use the .NET <xref:System.Resources.ResourceManager> class to access the app's or library's resources.

You can instantiate a <xref:System.Resources.ResourceManager> object for a Windows 8.x app in the same way that you do for a desktop app.

You can then access the resources for a particular culture by passing the name of the resource to be retrieved to the <xref:System.Resources.ResourceManager.GetString%28System.String%29> method. By default, this method returns the resource for the culture determined by the current UI culture of the thread that made the call. You can also retrieve the resources for a specific culture by passing the name of the resource and a <xref:System.Globalization.CultureInfo> object that represents the culture whose resource is to be retrieved to the <xref:System.Resources.ResourceManager.GetString%28System.String%2CSystem.Globalization.CultureInfo%29> method. If the resource for the current UI culture or the specified culture cannot be found, the resource manager uses a UI language fallback list to locate a suitable resource.

## Examples

The following example demonstrates how to use an explicit culture and the implicit current UI culture to obtain string resources from a main assembly and a satellite assembly. For more information, see the "Directory Locations for Satellite Assemblies Not Installed in the Global Assembly Cache" section of the [Creating Satellite Assemblies](/dotnet/framework/resources/creating-satellite-assemblies-for-desktop-apps) topic.

To run this example:

1. In the app directory, create a file named rmc.txt that contains the following resource strings:

   ```
   day=Friday
   year=2006
   holiday="Cinco de Mayo"
   ```

2. Use the [Resource File Generator](../../framework/tools/resgen-exe-resource-file-generator.md) to generate the rmc.resources resource file from the rmc.txt input file as follows:

   ```
   resgen rmc.txt
   ```

3. Create a subdirectory of the app directory and name it "es-MX". This is the culture name of the satellite assembly that you will create in the next three steps.

4. Create a file named rmc.es-MX.txt in the es-MX directory that contains the following resource strings:

   ```
   day=Viernes
   year=2006
   holiday="Cinco de Mayo"
   ```

5. Use the [Resource File Generator](../../framework/tools/resgen-exe-resource-file-generator.md) to generate the rmc.es-MX.resources resource file from the rmc.es-MX.txt input file as follows:

   ```
   resgen rmc.es-MX.txt
   ```

6. Assume that the filename for this example is rmc.vb or rmc.cs. Copy the following source code into a file. Then compile it and embed the main assembly resource file, rmc.resources, in the executable assembly. If you are using the Visual Basic compiler, the syntax is:

   ```
   vbc rmc.vb /resource:rmc.resources
   ```

   The corresponding syntax for the C# compiler is:

   ```
   csc /resource:rmc.resources rmc.cs
   ```

7. Use the [Assembly Linker](../../framework/tools/al-exe-assembly-linker.md) to create a satellite assembly. If the base name of the app is rmc, the satellite assembly name must be rmc.resources.dll. The satellite assembly should be created in the es-MX directory. If es-MX is the current directory, use this command:

   ```
   al /embed:rmc.es-MX.resources /c:es-MX /out:rmc.resources.dll
   ```

8. Run rmc.exe to obtain and display the embedded resource strings.

   :::code language="csharp" source="./snippets/System.Resources/ResourceManager/Overview/csharp/rmc.cs" id="Snippet1":::
   :::code language="vb" source="./snippets/System.Resources/ResourceManager/Overview/vb/rmc.vb" id="Snippet1":::
