---
title: "Unable to emit assembly: <error message>"
ms.date: 08/14/2018
f1_keywords:
  - "vbc30145"
  - "bc30145"
helpviewer_keywords:
  - "BC30145"
ms.assetid: 2e7eb2b9-eda6-4bdb-95cc-72c7f0be7528
---
# Unable to emit assembly: \<error message>

The Visual Basic compiler calls the Assembly Linker (*Al.exe*, also known as Alink) to generate an assembly with a manifest, and the linker reports an error in the emission stage of creating the assembly.

**Error ID:** BC30145

## To correct this error

1. Examine the quoted error message and consult the topic [Al.exe](../../../framework/tools/al-exe-assembly-linker.md) for further explanation and advice.

2. Try signing the assembly manually, using either the [Al.exe](../../../framework/tools/al-exe-assembly-linker.md) or the [Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md).

3. If the error persists, gather information about the circumstances and notify Microsoft Product Support Services.

### To sign the assembly manually

1. Use the [Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md)) to create a public/private key pair file.

   This file has an *.snk* extension.

2. Delete the COM reference that is generating the error from your project.

3. Open the [Developer Command Prompt for Visual Studio](../../../framework/tools/developer-command-prompt-for-vs.md).

   In Windows 10, enter **Developer command prompt** into the search box on the task bar. Then, select **Developer Command Prompt for VS 2017** from the results list.

4. Change the directory to the directory where you want to place your assembly wrapper.

5. Enter the following command:

    ```cmd
    tlbimp <path to COM reference file> /out:<output assembly name> /keyfile:<path to .snk file>
    ```

   An example of the actual command you might enter is:

    ```cmd
    tlbimp c:\windows\system32\msi.dll /out:Interop.WindowsInstaller.dll /keyfile:"c:\documents and settings\mykey.snk"
    ```

   > [!TIP]
   > Use double quotation marks if a path or file contains spaces.

6. In Visual Studio, add a .NET Assembly reference to the file you just created.

## See also

- [Al.exe](../../../framework/tools/al-exe-assembly-linker.md)
- [Sn.exe (Strong Name Tool)](../../../framework/tools/sn-exe-strong-name-tool.md)
- [How to: Create a Public-Private Key Pair](../../../standard/assembly/how-to-create-a-public-private-key-pair.md)
- [Talk to Us](/visualstudio/ide/talk-to-us)
