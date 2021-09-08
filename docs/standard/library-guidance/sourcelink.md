---
title: Source Link and .NET libraries
description: Best practice recommendations for using Source Link to improve debugging for .NET libraries.
ms.date: 01/15/2019
---
# Source Link

Source Link is a technology that enables source code debugging of .NET assemblies from NuGet by developers. Source Link executes when creating the NuGet package and embeds source control metadata inside assemblies and the package. Developers who download the package and have Source Link enabled in Visual Studio can step into its source code. Source Link provides source control metadata to create a great debugging experience.

## Source Link demo

<!--markdownlint-disable MD034 -->
> [!VIDEO https://www.youtube.com/embed/gyRGhCQPkB4?start=61]

## Using Source Link

Instructions for using Source Link can be found on the [dotnet/sourcelink](https://github.com/dotnet/sourcelink/blob/main/README.md) GitHub repository.

You can use [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer) to confirm that the Source Link metadata has been successfully embedded in the package. Check the `Repository` metadata is present with a commit identifier and that .pdb files are located with each target's .dll.

![Source Link in NuGet Package Explorer](./media/sourcelink/nuget-package-explorer-sourcelink.png "Source Link in NuGet Package Explorer")

✔️ CONSIDER using Source Link to add source control metadata to your assemblies and NuGet packages.

> [!TIP]
> You can further enhance a developer's debugging experience by adding debugger attributes to your types.
>
> * <xref:System.Diagnostics.DebuggerDisplayAttribute> can customize how a class or field is displayed in the debugger variable windows.
> * <xref:System.Diagnostics.DebuggerStepThroughAttribute> instructs the debugger to step through the code instead of stepping into the code.
> * <xref:System.Diagnostics.DebuggerBrowsableAttribute> controls whether a member is displayed in the debugger variable windows.

✔️ CONSIDER publishing symbol files (`*.pdb`).

> For the best debugging experience your library should publish symbol files as well as use Source Link. For more information about symbol files and symbol packages, see [Symbol packages](./nuget.md#symbol-packages).

✔️ CONSIDER enabling deterministic builds.

> Deterministic builds enable verification that the resulting binary was built from the specified source and provide traceability. For more information about deterministic builds and instructions for enabling them, see [Deterministic Builds](https://github.com/clairernovotny/DeterministicBuilds).

>[!div class="step-by-step"]
>[Previous](dependencies.md)
>[Next](publish-nuget-package.md)
