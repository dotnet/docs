---
title: "How to: Sign an assembly with a strong name"
ms.date: "08/20/2019"
helpviewer_keywords: 
  - "strong-named assemblies, signing with strong names"
  - "signing assemblies"
  - "assemblies [.NET Framework], signing"
  - "assemblies [.NET Framework], strong-named"
ms.assetid: 2c30799a-a826-46b4-a25d-c584027a6c67
author: "rpetrusha"
ms.author: "ronpet"
---
# How to: Sign an assembly with a strong name
There are a number of ways to sign an assembly with a strong name:  
  
- By using the **Signing** tab in a project's **Properties** dialog box in Visual Studio. This is the easiest and most convenient way to sign an assembly with a strong name.  
  
- By using the [Assembly Linker (Al.exe)](../../framework/tools/al-exe-assembly-linker.md) to link a .NET Framework code module (a *.netmodule* file) with a key file.  
  
- By using assembly attributes to insert the strong name information into your code. You can use either the <xref:System.Reflection.AssemblyKeyFileAttribute> or the <xref:System.Reflection.AssemblyKeyNameAttribute> attribute, depending on where the key file to be used is located.  
  
- By using compiler options.  
  
 You must have a cryptographic key pair to sign an assembly with a strong name. For more information about creating a key pair, see [How to: Create a public-private key pair](create-public-private-key-pair.md).  
  
## Create and sign an assembly with a strong name by using Visual Studio  
  
1. In **Solution Explorer**, open the shortcut menu for the project, and then choose **Properties**.  
  
2. Choose the **Signing** tab.  
  
3. Select the **Sign the assembly** box.  
  
4. In the **Choose a strong name key file** box, choose **Browse**, and then navigate to the key file. To create a new key file, choose **New** and enter its name in the **Create Strong Name Key** dialog box.  
  
> [!NOTE]
> In order to [delay sign an assembly](delay-sign.md), choose a public key file.  
  
### Create and sign an assembly with a strong name by using the Assembly Linker  
  
At the [Developer Command Prompt for Visual Studio](../../framework/tools/developer-command-prompt-for-vs.md), enter the following command:  

**al** **/out:**\<*assemblyName*> *\<moduleName>* **/keyfile:**\<*keyfileName*>  

Where:  

- *assemblyName* is the name of the strongly signed assembly (a *.dll* or *.exe* file) that Assembly Linker will emit.  
  
- *moduleName* is the name of a .NET Framework code module (a *.netmodule* file) that includes one or more types. You can create a *.netmodule* file by compiling your code with the `/target:module` switch in C# or Visual Basic.
  
- *keyfileName* is the name of the container or file that contains the key pair. Assembly Linker interprets a relative path in relation to the current directory.  

The following example signs the assembly *MyAssembly.dll* with a strong name by using the key file *sgKey.snk*.  

```  
al /out:MyAssembly.dll MyModule.netmodule /keyfile:sgKey.snk  
```  
  
For more information about this tool, see [Assembly Linker](../../framework/tools/al-exe-assembly-linker.md).  
  
## Sign an assembly with a strong name by using attributes  
  
1. Add the <xref:System.Reflection.AssemblyKeyFileAttribute?displayProperty=nameWithType> or <xref:System.Reflection.AssemblyKeyNameAttribute> attribute to your source code file, and specify the name of the file or container that contains the key pair to use when signing the assembly with a strong name.  
   
2. Compile the source code file normally.  
   
   > [!NOTE]
   > The C# and Visual Basic compilers issue compiler warnings (CS1699 and BC41008, respectively) when they encounter the <xref:System.Reflection.AssemblyKeyFileAttribute> or <xref:System.Reflection.AssemblyKeyNameAttribute> attribute in source code. You can ignore the warnings.  

The following example uses the <xref:System.Reflection.AssemblyKeyFileAttribute> attribute with a key file called *keyfile.snk*, which is located in the directory where the assembly is compiled.  

# [C++](#tab/cpp)
```cpp
[assembly:AssemblyKeyFileAttribute("keyfile.snk")];
```
# [C#](#tab/csharp)
```csharp
[assembly:AssemblyKeyFileAttribute("keyfile.snk")]
```
# [Visual Basic](#tab/vb)
```vb
<Assembly:AssemblyKeyFileAttribute("keyfile.snk")>
```
---

You can also delay sign an assembly when compiling your source file. For more information, see [Delay-sign an assembly](delay-sign.md).  

## Sign an assembly with a strong name by using the compiler  

Compile your source code file or files with the `/keyfile` or `/delaysign` compiler option in C# and Visual Basic, or the `/KEYFILE` or `/DELAYSIGN` linker option in C++. After the option name, add a colon and the name of the key file. When using command-line compilers, you can copy the key file to the directory that contains your source code files.  

For information on delay signing, see [Delay-sign an assembly](delay-sign.md).  

The following example uses the C# compiler and signs the assembly *UtilityLibrary.dll* with a strong name by using the key file *sgKey.snk*.  

```  
csc /t:library UtilityLibrary.cs /keyfile:sgKey.snk  
```  
  
## See also

- [Create and use strong-named assemblies](create-use-strong-named.md)
- [How to: Create a public-private key pair](create-public-private-key-pair.md)
- [Al.exe (Assembly Linker)](../../framework/tools/al-exe-assembly-linker.md)
- [Delay-sign an assembly](delay-sign.md)
- [Manage assembly and manifest signing](/visualstudio/ide/managing-assembly-and-manifest-signing)
- [Signing page, Project Designer](/visualstudio/ide/reference/signing-page-project-designer)
