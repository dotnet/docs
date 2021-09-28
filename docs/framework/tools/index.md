---
title: .NET Framework tools
description: See a list of .NET tools that make it easier for you to create, deploy, and manage applications and components that target .NET.
ms.date: 03/30/2017
helpviewer_keywords:
  - "command line, .NET Framework tools"
  - ".NET Framework, tools"
  - "tools [.NET Framework]"
  - "running .NET Framework tools"
ms.assetid: a2ca532d-91f7-426a-9303-417c2ee1247c
---
# .NET Framework tools

The .NET Framework tools make it easier for you to create, deploy, and manage applications and components that target the .NET Framework.

Most of the .NET Framework tools described in this section are automatically installed with Visual Studio. To download Visual Studio, visit the [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) page.

You can run all the tools from the command line, with the exception of the Assembly Cache Viewer (*Shfusion.dll*). You must access *Shfusion.dll* from File Explorer.

The best way to run the command-line tools is by using one of the developer shells that Visual Studio installs. These utilities enable you to run the tools easily, without having to navigate to the installation folder. For more information, see [Developer Command Prompt and Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell).

> [!NOTE]
> Some tools are specific to either 32-bit computers or 64-bit computers. Be sure to run the appropriate version of the tool for your computer.

## In this section

[Al.exe (Assembly Linker)](al-exe-assembly-linker.md)\
Generates a file that has an assembly manifest from modules or resource files.

[Aximp.exe (Windows Forms ActiveX Control Importer)](aximp-exe-windows-forms-activex-control-importer.md)\
Converts type definitions in a COM type library for an ActiveX control into a Windows Forms control.

[Caspol.exe (Code Access Security Policy Tool)](caspol-exe-code-access-security-policy-tool.md)\
Enables you to view and configure security policy for the machine policy level, the user policy level, and the enterprise policy level. In .NET Framework 4 and later, this tool does not affect code access security (CAS) policy unless the [\<legacyCasPolicy> element](../configure-apps/file-schema/runtime/netfx40-legacysecuritypolicy-element.md)\ is set to `true`.

[Cert2spc.exe (Software Publisher Certificate Test Tool)](cert2spc-exe-software-publisher-certificate-test-tool.md)\
Creates a Software Publisher's Certificate (SPC) from one or more X.509 certificates. This tool is for testing purposes only.

[Certmgr.exe (Certificate Manager Tool)](certmgr-exe-certificate-manager-tool.md)\
Manages certificates, certificate trust lists (CTLs), and certificate revocation lists (CRLs).

[Clrver.exe (CLR Version Tool)](clrver-exe-clr-version-tool.md)\
Reports all the installed versions of the common language runtime (CLR) on the computer.

[CorFlags.exe (CorFlags Conversion Tool)](corflags-exe-corflags-conversion-tool.md)\
Lets you configure the CorFlags section of the header of a portable executable (PE) image.

[Fuslogvw.exe (Assembly Binding Log Viewer)](fuslogvw-exe-assembly-binding-log-viewer.md)\
Displays information about assembly binds to help you diagnose why the .NET Framework cannot locate an assembly at run time.

[Gacutil.exe (Global Assembly Cache Tool)](gacutil-exe-gac-tool.md)\
Lets you view and manipulate the contents of the global assembly cache and download cache.

[Ilasm.exe (IL Assembler)](ilasm-exe-il-assembler.md)\
Generates a portable executable (PE) file from intermediate language (IL). You can run the resulting executable to determine whether the IL performs as expected.

[Ildasm.exe (IL Disassembler)](ildasm-exe-il-disassembler.md)\
Takes a portable executable (PE) file that contains intermediate language (IL) code and creates a text file that can be input to the IL Assembler (Ilasm.exe).

[Installutil.exe (Installer Tool)](installutil-exe-installer-tool.md)\
Enables you to install and uninstall server resources by executing the installer components in a specified assembly. (Works with classes in the <xref:System.Configuration.Install> namespace.)

[Lc.exe (License Compiler)](lc-exe-license-compiler.md)\
Reads text files that contain licensing information and produces a *.licenses* file that can be embedded in a common language runtime executable as a resource.

[Mage.exe (Manifest Generation and Editing Tool)](mage-exe-manifest-generation-and-editing-tool.md)\
Lets you create, edit, and sign application and deployment manifests. As a command-line tool, *Mage.exe* can be run from both batch scripts and other Windows-based applications, including ASP.NET applications.

[MageUI.exe (Manifest Generation and Editing Tool, Graphical Client)](mageui-exe-manifest-generation-and-editing-tool-graphical-client.md)\
Supports the same functionality as the command-line tool Mage.exe, but uses a Windows-based user interface (UI). Supports the same functionality as the command-line tool *Mage.exe*, but uses a Windows-based user interface (UI).

[MDbg.exe (.NET Framework Command-Line Debugger)](mdbg-exe.md)\
Helps tools vendors and application developers find and fix bugs in programs that target the .NET Framework common language runtime. This tool uses the runtime debugging API to provide debugging services.

[Mgmtclassgen.exe (Management Strongly Typed Class Generator)](mgmtclassgen-exe.md)\
Enables you to generate an early-bound managed class for a specified Windows Management Instrumentation (WMI) class.

[Mpgo.exe (Managed Profile Guided Optimization Tool)](mpgo-exe-managed-profile-guided-optimization-tool.md)\
Enables you to tune native image assemblies using common end-user scenarios. Mpgo.exe allows the generation and consumption of profile data for native image application assemblies (not the .NET Framework assemblies) using training scenarios selected by the application developer.

[Ngen.exe (Native Image Generator)](ngen-exe-native-image-generator.md)\
Improves the performance of managed applications through the use of native images (files containing compiled processor-specific machine code). The runtime can use native images from the cache instead of using the just-in-time (JIT) compiler to compile the original assembly.

[Peverify.exe (PEVerify Tool)](peverify-exe-peverify-tool.md)\
Helps you verify whether your Microsoft intermediate language (MSIL) code and associated metadata meet type safety requirements.

[Regasm.exe (Assembly Registration Tool)](regasm-exe-assembly-registration-tool.md)\
Reads the metadata within an assembly and adds the necessary entries to the registry. This enables COM clients to appear as .NET Framework classes.

[Regsvcs.exe (.NET Services Installation Tool)](regsvcs-exe-net-services-installation-tool.md)\
Loads and registers an assembly, generates and installs a type library into a specified COM+ version 1.0 application, and configures services that you have added programmatically to a class.

[Resgen.exe (Resource File Generator)](resgen-exe-resource-file-generator.md)\
Converts text (*.txt* or *.restext*) files and XML-based resource format (*.resx*) files to common language runtime binary (*.resources*) files that can be embedded in a runtime binary executable or compiled into satellite assemblies.

[SecAnnotate.exe (.NET Security Annotator Tool)](secannotate-exe-net-security-annotator-tool.md)\
Identifies the `SecurityCritical` and `SecuritySafeCritical` portions of an assembly.

[SignTool.exe (Sign Tool)](signtool-exe.md)\
Digitally signs files, verifies signatures in files, and time-stamps files.

[Sn.exe (Strong Name Tool)](sn-exe-strong-name-tool.md)\
Helps create assemblies with strong names. This tool provides options for key management, signature generation, and signature verification.

[SOS.dll (SOS Debugging Extension)](sos-dll-sos-debugging-extension.md)\
Helps you debug managed programs in the WinDbg.exe debugger and in Visual Studio by providing information about the internal common language runtime environment.

[SqlMetal.exe (Code Generation Tool)](sqlmetal-exe-code-generation-tool.md)\
Generates code and mapping for the LINQ to SQL component of the .NET Framework.

[Storeadm.exe (Isolated Storage Tool)](storeadm-exe-isolated-storage-tool.md)\
Manages isolated storage; provides options for listing the user's stores and deleting them.

[Tlbexp.exe (Type Library Exporter)](tlbexp-exe-type-library-exporter.md)\
Generates a type library that describes the types that are defined in a common language runtime assembly.

[Tlbimp.exe (Type Library Importer)](tlbimp-exe-type-library-importer.md)\
Converts the type definitions found in a COM type library into equivalent definitions in a common language runtime assembly.

[Winmdexp.exe (Windows Runtime Metadata Export Tool)](winmdexp-exe-windows-runtime-metadata-export-tool.md)\
Exports a .NET Framework assembly that is compiled as a *.winmdobj* file into a Windows Runtime component, which is packaged as a *.winmd* file that contains both Windows Runtime metadata and implementation information.

[Winres.exe (Windows Forms Resource Editor)](winres-exe-windows-forms-resource-editor.md)\
Helps you localize user interface (UI) resources (*.resx* or *.resources* files) that are used by Windows Forms. You can translate strings, and then size, move, and hide controls to accommodate the localized strings.

## Related sections

[WPF Tools](/previous-versions/ms742404(v=vs.110))
Includes tools such as the isXPS Conformance tool (isXPS.exe) and performance profiling tools.

[Windows Communication Foundation Tools](../wcf/tools.md)\
Includes tools that make it easier for you to create, deploy, and manage Windows Communication Foundation (WCF) applications.
