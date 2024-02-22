---
title: Create satellite assemblies
description: Get started with creating satellite assemblies for .NET apps. A satellite assembly can be easily updated or replaced to provide localized resources.
ms.date: 03/13/2023
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "deploying applications [.NET Framework], resources"
  - "resource files, deploying"
  - "hub-and-spoke resource deployment model"
  - "resource files, packaging"
  - "application resources, packaging"
  - "public keys, obtaining"
  - "satellite assemblies"
  - "assemblies [.NET Framework], signing"
  - "application resources, deploying"
  - "Al.exe"
  - "GAC (global assembly cache), satellite assemblies"
  - "Assembly Linker"
  - "directory locations for satellite assemblies"
  - "global assembly cache, satellite assemblies"
  - "packaging application resources"
  - "compiling satellite assemblies"
  - "re-signing assemblies"
ms.assetid: 8d5c6044-2919-41d2-8321-274706b295ac
---

# Create satellite assemblies for .NET apps

Resource files play a central role in localized applications. They enable an application to display strings, images, and other data in the user's language and culture, and provide alternate data if resources for the user's language or culture are unavailable. .NET uses a hub-and-spoke model to locate and retrieve localized resources. The hub is the main assembly that contains the non-localizable executable code and the resources for a single culture, which is called the neutral or default culture. The default culture is the fallback culture for the application; it's used when no localized resources are available. You use the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute to designate the culture of the application's default culture. Each spoke connects to a satellite assembly that contains the resources for a single localized culture but does not contain any code. Because the satellite assemblies aren't part of the main assembly, you can easily update or replace resources that correspond to a specific culture without replacing the main assembly for the application.

> [!NOTE]
> The resources of an application's default culture can also be stored in a satellite assembly. To do this, you assign the <xref:System.Resources.NeutralResourcesLanguageAttribute> attribute a value of <xref:System.Resources.UltimateResourceFallbackLocation.Satellite?displayProperty=nameWithType>.

## Satellite assembly name and location

The hub-and-spoke model requires that you place resources in specific locations so that they can be easily located and used. If you don't compile and name resources as expected, or if you don't place them in the correct locations, the common language runtime won't be able to locate them and will use the resources of the default culture instead. The .NET resource manager is represented by the <xref:System.Resources.ResourceManager> type, and it's used to automatically access localized resources. The resource manager requires the following:

- A single satellite assembly must include all the resources for a particular culture. In other words, you should compile multiple *.txt* or *.resx* files into a single binary *.resources* file.

- There must be a separate subdirectory in the application directory for each localized culture that stores that culture's resources. The subdirectory name must be the same as the culture name. Alternately, you can store your satellite assemblies in the global assembly cache. In this case, the culture information component of the assembly's strong name must indicate its culture. For more information, see [Install satellite assemblies in the Global Assembly Cache](#SN).

  > [!NOTE]
  > If your application includes resources for subcultures, place each subculture in a separate subdirectory under the application directory. Do not place subcultures in subdirectories under their main culture's directory.

- The satellite assembly must have the same name as the application, and must use the file name extension ".resources.dll". For example, if an application is named *Example.exe*, the name of each satellite assembly should be *Example.resources.dll*. The satellite assembly name doesn't indicate the culture of its resource files. However, the satellite assembly appears in a directory that does specify the culture.

- Information about the culture of the satellite assembly must be included in the assembly's metadata. To store the culture name in the satellite assembly's metadata, you specify the `/culture` option when you use [Assembly Linker](../../framework/tools/al-exe-assembly-linker.md) to embed resources in the satellite assembly.

The following illustration shows a sample directory structure and location requirements for applications that you aren't installing in the [global assembly cache](../../framework/app-domains/gac.md). The items with *.txt* and *.resources* extensions won't ship with the final application. These are the intermediate resource files used to create the final satellite resource assemblies. In this example, you could substitute *.resx* files for the *.txt* files. For more information, see [Package and deploy resources](package-and-deploy-resources.md).

The following image shows the satellite assembly directory:

:::image type="content" source="media/create-satellite-assemblies/satellite-assembly-directory.gif" alt-text="A satellite assembly directory with localized cultures subdirectories.":::

## Compile satellite assemblies

You use [Resource File Generator (*resgen.exe*)](../../framework/tools/resgen-exe-resource-file-generator.md) to compile text files or XML (*.resx*) files that contain resources to binary *.resources* files. You then use [Assembly Linker (*al.exe*)](../../framework/tools/al-exe-assembly-linker.md) to compile *.resources* files into satellite assemblies. *al.exe* creates an assembly from the *.resources* files that you specify. Satellite assemblies can contain only resources; they can't contain any executable code.

The following *al.exe* command creates a satellite assembly for the application `Example` from the German resources file *strings.de.resources*.

```console
al -target:lib -embed:strings.de.resources -culture:de -out:Example.resources.dll
```

The following *al.exe* command also creates a satellite assembly for the application `Example` from the file *strings.de.resources*. The **/template** option causes the satellite assembly to inherit all assembly metadata except for its culture information from the parent assembly (*Example.dll*).

```console
al -target:lib -embed:strings.de.resources -culture:de -out:Example.resources.dll -template:Example.dll
```

The following table describes the *al.exe* options used in these commands in more detail:

| Option | Description |
|--|--|
| `-target:lib` | Specifies that your satellite assembly is compiled to a library (.dll) file. Because a satellite assembly doesn't contain executable code and is not an application's main assembly, you must save satellite assemblies as DLLs. |
| `-embed:strings.de.resources` | Specifies the name of the resource file to embed when *al.exe* compiles the assembly. You can embed multiple .resources files in a satellite assembly, but if you are following the hub-and-spoke model, you must compile one satellite assembly for each culture. However, you can create separate .resources files for strings and objects. |
| `-culture:de` | Specifies the culture of the resource to compile. The common language runtime uses this information when it searches for the resources for a specified culture. If you omit this option, *al.exe* will still compile the resource, but the runtime won't be able to find it when a user requests it. |
| `-out:Example.resources.dll` | Specifies the name of the output file. The name must follow the naming standard *baseName*.resources.*extension*, where *baseName* is the name of the main assembly and *extension* is a valid file name extension (such as .dll). The runtime is not able to determine the culture of a satellite assembly based on its output file name; you must use the **/culture** option to specify it. |
| `-template:Example.dll` | Specifies an assembly from which the satellite assembly will inherit all assembly metadata except the culture field. This option affects satellite assemblies only if you specify an assembly that has a [strong name](../../standard/assembly/strong-named.md). |

For a complete list of options available with *al.exe*, see [Assembly Linker (*al.exe*)](../../framework/tools/al-exe-assembly-linker.md).

> [!NOTE]
> There may be times when you want to use the .NET Core MSBuild task to compile satellite assemblies, even though you're targeting .NET Framework. For example, you may want to use the C# compiler [deterministic](../../csharp/language-reference/compiler-options/code-generation.md#deterministic) option to be able to compare assemblies from different builds. In this case, set [GenerateSatelliteAssembliesForCore](../project-sdk/msbuild-props.md#generatesatelliteassembliesforcore) to `true` in the *.csproj* file to generate satellite assemblies using *csc.exe* instead of [Al.exe (Assembly Linker)](../../framework/tools/al-exe-assembly-linker.md).
>
> ```xml
> <Project>
>     <PropertyGroup>
>         <GenerateSatelliteAssembliesForCore>true</GenerateSatelliteAssembliesForCore>
>     </PropertyGroup>
> </Project>
> ```
>
> The .NET Core MSBuild task uses *csc.exe* instead of *al.exe* to generate satellite assemblies, by default. For more information, see [Make it easier to opt into "Core" satellite assembly generation](https://github.com/dotnet/msbuild/pull/2726).

## Satellite assemblies example

The following is a simple "Hello world" example that displays a message box containing a localized greeting. The example includes resources for the English (United States), French (France), and Russian (Russia) cultures, and its fallback culture is English. To create the example, do the following:

1. Create a resource file named *Greeting.resx* or *Greeting.txt* to contain the resource for the default culture. Store a single string named `HelloString` whose value is "Hello world!" in this file.

2. To indicate that English (en) is the application's default culture, add the following <xref:System.Resources.NeutralResourcesLanguageAttribute?displayProperty=nameWithType> attribute to the application's AssemblyInfo file or to the main source code file that will be compiled into the application's main assembly.

    [!code-csharp[Conceptual.Resources.Locating#2](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.locating/cs/assemblyinfo.cs#2)]
    [!code-vb[Conceptual.Resources.Locating#2](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.locating/vb/assemblyinfo.vb#2)]

3. Add support for additional cultures (`en-US`, `fr-FR`, and `ru-RU`) to the application as follows:

    - To support the `en-US` or English (United States) culture, create a resource file named *Greeting.en-US.resx* or *Greeting.en-US.txt*, and store in it a single string named `HelloString` whose value is "Hi world!".

    - To support the `fr-FR` or French (France) culture, create a resource file named *Greeting.fr-FR.resx* or *Greeting.fr-FR.txt*, and store in it a single string named `HelloString` whose value is "Salut tout le monde!".

    - To support the `ru-RU` or Russian (Russia) culture, create a resource file named *Greeting.ru-RU.resx* or *Greeting.ru-RU.txt*, and store in it a single string named `HelloString` whose value is "Всем привет!".

4. Use [*resgen.exe*](../../framework/tools/resgen-exe-resource-file-generator.md) to compile each text or XML resource file to a binary *.resources* file. The output is a set of files that have the same root file name as the *.resx* or *.txt* files, but a *.resources* extension. If you create the example with Visual Studio, the compilation process is handled automatically. If you aren't using Visual Studio, run the following commands to compile the *.resx* files into *.resources* files:

    ```console
    resgen Greeting.resx
    resgen Greeting.en-us.resx
    resgen Greeting.fr-FR.resx
    resgen Greeting.ru-RU.resx
    ```

    If your resources are in text files instead of XML files, replace the *.resx* extension with *.txt*.

5. Compile the following source code along with the resources for the default culture into the application's main assembly:

    > [!IMPORTANT]
    > If you are using the command line rather than Visual Studio to create the example, you should modify the call to the <xref:System.Resources.ResourceManager> class constructor to the following: `ResourceManager rm = new ResourceManager("Greeting", typeof(Example).Assembly);`

    [!code-csharp[Conceptual.Resources.Locating#1](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.locating/cs/program.cs#1)]
    [!code-vb[Conceptual.Resources.Locating#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.locating/vb/module1.vb#1)]

    If the application is named **Example** and you're compiling from the command line, the command for the C# compiler is:

    ```console
    csc Example.cs -res:Greeting.resources
    ```

    The corresponding Visual Basic compiler command is:

    ```console
    vbc Example.vb -res:Greeting.resources
    ```

6. Create a subdirectory in the main application directory for each localized culture supported by the application. You should create an *en-US*, an *fr-FR*, and an *ru-RU* subdirectory. Visual Studio creates these subdirectories automatically as part of the compilation process.

7. Embed the individual culture-specific *.resources* files into satellite assemblies and save them to the appropriate directory. The command to do this for each *.resources* file is:

    ```console
    al -target:lib -embed:Greeting.culture.resources -culture:culture -out:culture\Example.resources.dll
    ```

     where *culture* is the name of the culture whose resources the satellite assembly contains. Visual Studio handles this process automatically.

You can then run the example. It will randomly make one of the supported cultures the current culture and display a localized greeting.

<a name="SN"></a>

## Install satellite assemblies in the Global Assembly Cache

Instead of installing assemblies in a local application subdirectory, you can install them in the global assembly cache. This is particularly useful if you have class libraries and class library resource assemblies that are used by multiple applications.

Installing assemblies in the global assembly cache requires that they have strong names. Strong-named assemblies are signed with a valid public/private key pair. They contain version information that the runtime uses to determine which assembly to use to satisfy a binding request. For more information about strong names and versioning, see [Assembly versioning](../../standard/assembly/versioning.md). For more information about strong names, see [Strong-named assemblies](../../standard/assembly/strong-named.md).

When you're developing an application, it's unlikely that you'll have access to the final public/private key pair. To install a satellite assembly in the global assembly cache and ensure that it works as expected, you can use a technique called delayed signing. When you delay sign an assembly, at build time you reserve space in the file for the strong name signature. The actual signing is delayed until later, when the final public/private key pair is available. For more information about delayed signing, see [Delay signing an assembly](../../standard/assembly/delay-sign.md).

### Obtain the public key

To delay sign an assembly, you must have access to the public key. You can either obtain the real public key from the organization in your company that will do the eventual signing, or create a public key by using the [Strong Name tool (*sn.exe*)](../../framework/tools/sn-exe-strong-name-tool.md).

The following *Sn.exe* command creates a test public/private key pair. The **–k** option specifies that *Sn.exe* should create a new key pair and save it in a file named *TestKeyPair.snk*.

```console
sn –k TestKeyPair.snk
```

You can extract the public key from the file that contains the test key pair. The following command extracts the public key from *TestKeyPair.snk* and saves it in *PublicKey.snk*:

```console
sn –p TestKeyPair.snk PublicKey.snk
```

### Delay signing an Assembly

After you obtain or create the public key, you use the [Assembly Linker (*al.exe*)](../../framework/tools/al-exe-assembly-linker.md) to compile the assembly and specify delayed signing.

The following *al.exe* command creates a strong-named satellite assembly for the application StringLibrary from the *strings.ja.resources* file:

```console
al -target:lib -embed:strings.ja.resources -culture:ja -out:StringLibrary.resources.dll -delay+ -keyfile:PublicKey.snk
```

The **-delay+** option specifies that the Assembly Linker should delay sign the assembly. The **-keyfile** option specifies the name of the key file that contains the public key to use to delay sign the assembly.

### Re-signing an Assembly

Before you deploy your application, you must re-sign the delay signed satellite assembly with the real key pair. You can do this by using *Sn.exe*.

The following *Sn.exe* command signs *StringLibrary.resources.dll* with the key pair stored in the file *RealKeyPair.snk*. The **–R** option specifies that a previously signed or delay signed assembly is to be re-signed.

```console
sn –R StringLibrary.resources.dll RealKeyPair.snk
```

### Install a satellite assembly in the Global Assembly Cache

When the runtime searches for resources in the resource fallback process, it looks in the [global assembly cache](../../framework/app-domains/gac.md) first. (For more information, see the "Resource Fallback Process" section of [Package and deploy resources](package-and-deploy-resources.md).) As soon as a satellite assembly is signed with a strong name, it can be installed in the global assembly cache by using the [Global Assembly Cache tool (*gacutil.exe*)](../../framework/tools/gacutil-exe-gac-tool.md).

The following *Gacutil.exe* command installs *StringLibrary.resources.dll** in the global assembly cache:

```console
gacutil -i:StringLibrary.resources.dll
```

The **/i** option specifies that *Gacutil.exe* should install the specified assembly into the global assembly cache. After the satellite assembly is installed in the cache, the resources it contains become available to all applications that are designed to use the satellite assembly.

### Resources in the Global Assembly Cache: An Example

The following example uses a method in a .NET class library to extract and return a localized greeting from a resource file. The library and its resources are registered in the global assembly cache. The example includes resources for the English (United States), French (France), Russian (Russia), and English cultures. English is the default culture; its resources are stored in the main assembly. The example initially delay-signs the library and its satellite assemblies with a public key, then re-signs them with a public/private key pair. To create the example, do the following:

1. If you aren't using Visual Studio, use the following [Strong Name Tool (Sn.exe)](../../framework/tools/sn-exe-strong-name-tool.md) command to create a public/private key pair named *ResKey.snk*:

    ```console
    sn –k ResKey.snk
    ```

    If you're using Visual Studio, use the **Signing** tab of the project **Properties** dialog box to generate the key file.

2. Use the following [Strong Name Tool (Sn.exe)](../../framework/tools/sn-exe-strong-name-tool.md) command to create a public key file named *PublicKey.snk*:

    ```console
    sn –p ResKey.snk PublicKey.snk
    ```

3. Create a resource file named *Strings.resx* to contain the resource for the default culture. Store a single string named `Greeting` whose value is "How do you do?" in that file.

4. To indicate that "en" is the application's default culture, add the following <xref:System.Resources.NeutralResourcesLanguageAttribute?displayProperty=nameWithType> attribute to the application's AssemblyInfo file or to the main source code file that will be compiled into the application's main assembly:

    [!code-csharp[Conceptual.Resources.Satellites#2](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.satellites/cs/stringlibrary.cs#2)]
    [!code-vb[Conceptual.Resources.Satellites#2](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.satellites/vb/stringlibrary.vb#2)]

5. Add support for additional cultures (the en-US, fr-FR, and ru-RU cultures) to the application as follows:

    - To support the "en-US" or English (United States) culture, create a resource file named *Strings.en-US.resx* or *Strings.en-US.txt*, and store in it a single string named `Greeting` whose value is "Hello!".

    - To support the "fr-FR" or French (France) culture, create a resource file named *Strings.fr-FR.resx* or *Strings.fr-FR.txt* and store in it a single string named `Greeting` whose value is "Bon jour!".

    - To support the "ru-RU" or Russian (Russia) culture, create a resource file named *Strings.ru-RU.resx* or *Strings.ru-RU.txt* and store in it a single string named `Greeting` whose value is "Привет!".

6. Use [*resgen.exe*](../../framework/tools/resgen-exe-resource-file-generator.md) to compile each text or XML resource file to a binary .resources file. The output is a set of files that have the same root file name as the *.resx* or *.txt* files, but a *.resources* extension. If you create the example with Visual Studio, the compilation process is handled automatically. If you aren't using Visual Studio, run the following command to compile the *.resx* files into *.resources* files:

    ```console
    resgen filename
    ```

    Where *filename* is the optional path, file name, and extension of the *.resx* or text file.

7. Compile the following source code for *StringLibrary.vb* or *StringLibrary.cs* along with the resources for the default culture into a delay signed library assembly named *StringLibrary.dll*:

    > [!IMPORTANT]
    > If you are using the command line rather than Visual Studio to create the example, you should modify the call to the <xref:System.Resources.ResourceManager> class constructor to `ResourceManager rm = new ResourceManager("Strings",` `typeof(Example).Assembly);`.

    [!code-csharp[Conceptual.Resources.Satellites#1](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.satellites/cs/stringlibrary.cs#1)]
    [!code-vb[Conceptual.Resources.Satellites#1](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.satellites/vb/stringlibrary.vb#1)]

    The command for the C# compiler is:

    ```console
    csc -t:library -resource:Strings.resources -delaysign+ -keyfile:publickey.snk StringLibrary.cs
    ```

    The corresponding Visual Basic compiler command is:

    ```console
    vbc -t:library -resource:Strings.resources -delaysign+ -keyfile:publickey.snk StringLibrary.vb
    ```

8. Create a subdirectory in the main application directory for each localized culture supported by the application. You should create an *en-US*, an *fr-FR*, and an *ru-RU* subdirectory. Visual Studio creates these subdirectories automatically as part of the compilation process. Because all satellite assemblies have the same file name, the subdirectories are used to store individual culture-specific satellite assemblies until they're signed with a public/private key pair.

9. Embed the individual culture-specific *.resources* files into delay signed satellite assemblies and save them to the appropriate directory. The command to do this for each *.resources* file is:

    ```console
    al -target:lib -embed:Strings.culture.resources -culture:culture -out:culture\StringLibrary.resources.dll -delay+ -keyfile:publickey.snk
    ```

    where *culture* is the name of a culture. In this example, the culture names are en-US, fr-FR, and ru-RU.

10. Re-sign *StringLibrary.dll* by using the [Strong Name tool (*sn.exe*)](../../framework/tools/sn-exe-strong-name-tool.md) as follows:

    ```console
    sn –R StringLibrary.dll RealKeyPair.snk
    ```

11. Re-sign the individual satellite assemblies. To do this, use the [Strong Name tool (*sn.exe*)](../../framework/tools/sn-exe-strong-name-tool.md) as follows for each satellite assembly:

    ```console
    sn –R StringLibrary.resources.dll RealKeyPair.snk
    ```

12. Register *StringLibrary.dll* and each of its satellite assemblies in the global assembly cache by using the following command:

    ```console
    gacutil -i filename
    ```

    where *filename* is the name of the file to register.

13. If you're using Visual Studio, create a new **Console Application** project named `Example`, add a reference to *StringLibrary.dll* and the following source code to it, and compile.

    [!code-csharp[Conceptual.Resources.Satellites#3](~/samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.satellites/cs/example.cs#3)]
    [!code-vb[Conceptual.Resources.Satellites#3](~/samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.satellites/vb/example.vb#3)]

    To compile from the command line, use the following command for the C# compiler:

    ```console
    csc Example.cs -r:StringLibrary.dll
    ```

    The command line for the Visual Basic compiler is:

    ```console
    vbc Example.vb -r:StringLibrary.dll
    ```

14. Run *Example.exe*.

## See also

- [Package and deploy resources](package-and-deploy-resources.md)
- [Delay signing an assembly](../../standard/assembly/delay-sign.md)
- [*al.exe* (Assembly Linker)](../../framework/tools/al-exe-assembly-linker.md)
- [*sn.exe* (Strong Name tool)](../../framework/tools/sn-exe-strong-name-tool.md)
- [*gacutil.exe* (Global Assembly Cache tool)](../../framework/tools/gacutil-exe-gac-tool.md)
- [Resources in .NET](resources.md)
