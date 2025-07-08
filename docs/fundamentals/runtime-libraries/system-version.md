---
title: System.Version class
description: Learn about the System.Version class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Version class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Version> class represents the version number of an assembly, operating system, or the common language runtime. Version numbers consist of two to four components: major, minor, build, and revision. The major and minor components are required; the build and revision components are optional, but the build component is required if the revision component is defined. All defined components must be integers greater than or equal to 0. The format of the version number is as follows (optional components are shown in square brackets):

*major*.*minor*[.*build*[.*revision*]]

The components are used by convention as follows:

- *Major*: Assemblies with the same name but different major versions are not interchangeable. A higher version number might indicate a major rewrite of a product where backward compatibility cannot be assumed.

- *Minor*: If the name and major version number on two assemblies are the same, but the minor version number is different, this indicates significant enhancement with the intention of backward compatibility. This higher minor version number might indicate a point release of a product or a fully backward-compatible new version of a product.

- *Build*: A difference in build number represents a recompilation of the same source. Different build numbers might be used when the processor, platform, or compiler changes.

- *Revision*: Assemblies with the same name, major, and minor version numbers but different revisions are intended to be fully interchangeable. A higher revision number might be used in a build that fixes a security hole in a previously released assembly.

Subsequent versions of an assembly that differ only by build or revision numbers are considered to be Hotfix updates of the prior version.

> [!IMPORTANT]
> The value of <xref:System.Version> properties that have not been explicitly assigned a value is undefined (-1).

The <xref:System.Version.MajorRevision%2A> and <xref:System.Version.MinorRevision%2A> properties enable you to identify a temporary version of your application that, for example, corrects a problem until you can release a permanent solution. Furthermore, the Windows NT operating system uses the <xref:System.Version.MajorRevision> property to encode the service pack number.

## Assign version information to assemblies

Ordinarily, the <xref:System.Version> class is not used to assign a version number to an assembly. Instead, the <xref:System.Reflection.AssemblyVersionAttribute> class is used to define an assembly's version, as illustrated by the example in this article.

## Retrieve version information

<xref:System.Version> objects are most frequently used to store version information about some system or application component (such as the operating system), the common language runtime, the current application's executable, or a particular assembly. The following examples illustrate some of the most common scenarios:

- Retrieving the operating system version. The following example uses the <xref:System.OperatingSystem.Version?displayProperty=nameWithType> property to retrieve the version number of the operating system.

  :::code language="csharp" source="./snippets/System/Version/Overview/csharp/GettingVersions1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/GettingVersions1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/TypeInitializationException/Overview/vb/GettingVersions1.vb" id="Snippet1":::

- Retrieving the version of the common language runtime. The following example uses the <xref:System.Environment.Version?displayProperty=nameWithType> property to retrieve version information about the common language runtime.

  :::code language="csharp" source="./snippets/System/Version/Overview/csharp/GettingVersions1.cs" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/GettingVersions1.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/TypeInitializationException/Overview/vb/GettingVersions1.vb" id="Snippet2":::

- Retrieving the current application's assembly version. The following example uses the <xref:System.Reflection.Assembly.GetEntryAssembly%2A?displayProperty=nameWithType> method to obtain a reference to an <xref:System.Reflection.Assembly> object that represents the application executable and then retrieves its assembly version number.

  :::code language="csharp" source="./snippets/System/Version/Overview/csharp/currentapp.cs" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/currentapp.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System/Version/Overview/vb/currentapp.vb" id="Snippet5":::

- Retrieving the current assembly's assembly version. The following example uses the <xref:System.Type.Assembly?displayProperty=nameWithType> property to obtain a reference to an <xref:System.Reflection.Assembly> object that represents the assembly that contains the application entry point, and then retrieves its version information.

  :::code language="csharp" source="./snippets/System/Version/Overview/csharp/currentassem.cs" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/currentassem.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/Version/Overview/vb/currentassem.vb" id="Snippet4":::

- Retrieving the version of a specific assembly. The following example uses the <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom%2A?displayProperty=nameWithType> method to obtain a reference to an <xref:System.Reflection.Assembly> object that has a particular file name, and then retrieves its version information. Note that several other methods also exist to instantiate an <xref:System.Reflection.Assembly> object by file name or by strong name.

  :::code language="csharp" source="./snippets/System/Version/Overview/csharp/specificassem.cs" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/specificassem.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/Version/Overview/vb/specificassem.vb" id="Snippet3":::

- Retrieving the Publish Version of a ClickOnce application. The following example uses the <xref:System.Deployment.Application.ApplicationDeployment.CurrentVersion?displayProperty=nameWithType> property to display an application's Publish Version. Note that its successful execution requires the example's application identity to be set. This is handled automatically by the Visual Studio Publish Wizard.

  :::code language="csharp" source="./snippets/System/Version/Overview/csharp/clickonce.cs" id="Snippet7":::
  :::code language="vb" source="./snippets/System/Version/Overview/vb/clickonce.vb" id="Snippet7":::

  > [!IMPORTANT]
  > The Publish Version of an application for ClickOnce deployment is completely independent of its assembly version.

## Compare version objects

You can use the <xref:System.Version.CompareTo%2A> method to determine whether one <xref:System.Version> object is earlier than, the same as, or later than a second <xref:System.Version> object. The following example indicates that Version 2.1 is later than Version 2.0.

:::code language="csharp" source="./snippets/System/Version/Overview/csharp/comparisons1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/comparisons1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Version/Overview/vb/comparisons1.vb" id="Snippet1":::

For two versions to be equal, the major, minor, build, and revision numbers of the first <xref:System.Version> object must be identical to those of the second <xref:System.Version> object. If the build or revision number of a <xref:System.Version> object is undefined, that <xref:System.Version> object is considered to be earlier than a <xref:System.Version> object whose build or revision number is equal to zero. The following example illustrates this by comparing three <xref:System.Version> objects that have undefined version components.

:::code language="csharp" source="./snippets/System/Version/Overview/csharp/comparisons2.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Version/Overview/fsharp/comparisons2.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Version/Overview/vb/comparisons2.vb" id="Snippet2":::
