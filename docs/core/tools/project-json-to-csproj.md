---
title: project.json and csproj comparison - .NET Core | Microsoft Docs
description: See a mapping between project.json and csproj elements.
keywords: project.json, csproj, .NET Core, MSBuild
author: natemcmaster
ms.author: mairaw
ms.date: 02/17/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 79c50621-a24a-4e64-bbb9-b953113e841c
---

# A mapping between project.json and csproj properties

By [Nate McMaster](http://github.com/natemcmaster)

During the development of the .NET Core tooling, an important design change was made to 
no longer support *project.json* files and instead move the .NET Core projects to the MSBuild/csproj 
format.

This article shows how the settings in *project.json* are represented in the MSBuild/csproj format so you
can learn how to use the new format and understand the changes made by the migration tools when you're
upgrading your project to the latest version of the tooling. 
 
## The csproj format

The new format, \*.csproj, is an XML-based format. The following example shows the root node of a 
.NET Core project using the new `Microsoft.NET.Sdk` metapackage. For web projects, the metapackage used is 
`Microsoft.NET.Sdk.Web`.

```xml
<Project Sdk="Microsoft.NET.Sdk">
...
</Project>
```

## Common top-level properties

### name
```json
{
  "name": "MyProjectName"
}
```

No longer supported. In csproj, this is determined by the project filename. For example, `MyProjectName.csproj`.

### version

```json
{
  "version": "1.0.0-alpha-*"
}
```
Use the `VersionPrefix` and `VersionSuffix` properties:

```xml
<PropertyGroup>
  <VersionPrefix>1.0.0</VersionPrefix>
  <VersionSuffix>alpha</VersionSuffix>
</PropertyGroup>
```

You can also use the `Version` property, but this may override version settings during packaging:

```xml
<PropertyGroup>
  <Version>1.0.0-alpha</Version>
</PropertyGroup>
```

### Other common root-level options

```json
{
  "authors": [ "Anne", "Bob" ],
  "company": "Contoso",
  "language": "en-US",
  "title": "My library",
  "description": "This is my library.\r\nAnd it's really great!",
  "copyright": "Nugetizer 3000",
  "userSecretsId": "xyz123"
}
```

```xml
<PropertyGroup>
  <Authors>Anne;Bob<Authors>
  <Company>Contoso<Company>
  <NeutralLanguage>en-US</NeutralLanguage>
  <AssemblyTitle>My library</AssemblyTitle>
  <Description>This is my library.
And it's really great!</Description>
  <Copyright>Nugetizer 3000</Copyright>
  <UserSecretsId>xyz123</UserSecretsId>
</PropertyGroup>
```

## frameworks

```json
{
  "frameworks": {
    "netcoreapp1.0": {},
    "net451": {}
  }
}
```

Use the `TargetFrameworks` property to define your list of target frameworks. Use semi-colon to separate multiple framework values. 

```xml
<PropertyGroup>
  <TargetFrameworks>netcoreapp1.0;net451</TargetFrameworks>
</PropertyGroup>
```

## dependencies

> [!IMPORTANT]
> If the dependency is a **project** and not a package, the format is different. 
> For more information, see the [dependency type](#dependency-type) section.

### .NET Standard metapackage

```json
{
  "dependencies": {
    "NETStandard.Library": "1.6.0"
  }
}
```

```xml
<PropertyGroup>
  <NetStandardImplicitPackageVersion>1.6.0</NetStandardImplicitPackageVersion>
</PropertyGroup>
```

### Top-level dependencies
```json
{
  "dependencies": {
    "Microsoft.AspNetCore": "1.1.0"
  }
}
```

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore" Version="1.1.0" />
</ItemGroup>
```

### Per-framework dependencies
```json
{
  "framework": {
    "net451": {
      "dependencies": {
        "System.Collections.Immutable": "1.3.1"
      }
    },
    "netstandard1.5": {
      "dependencies": {
        "Newtonsoft.Json": "9.0.1"
      }
    }
  }
}
```

```xml
<ItemGroup Condition="'$(TargetFramework)'=='net451'">
  <PackageReference Include="System.Collections.Immutable" Version="1.3.1" />
</ItemGroup>

<ItemGroup Condition="'$(TargetFramework)'=='netstandard1.5'">
  <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
</ItemGroup>
```

### imports

```json
{
  "dependencies": {
    "YamlDotNet": "4.0.1-pre309"
  },
  "frameworks": {
    "netcoreapp1.0": {
      "imports": [
        "dnxcore50",
        "dotnet"
      ]
    }
  }
}
```

```xml
<PropertyGroup>
  <PackageTargetFallback>dnxcore50;dotnet</PackageTargetFallback>
</PropertyGroup>
<ItemGroup>
  <PackageReference Include="YamlDotNet" Version="4.0.1-pre309" />
</ItemGroup>
```

### dependency type

#### type: project
```json
{
  "dependencies": {
    "MyOtherProject": "1.0.0-*",
    "AnotherProject": {
      "type": "project"
    }
  }
}
```

```xml
<ItemGroup>
  <ProjectReference Include="..\MyOtherProject\MyOtherProject.csproj" />
  <ProjectReference Include="..\AnotherProject\AnotherProject.csproj" />
</ItemGroup>
```

> [!NOTE]
> This will break the way that `dotnet pack --version-suffix $suffix` determines the 
dependency version of a project reference.


#### type: build
```json
{
  "dependencies": {
    "Microsoft.EntityFrameworkCore.Design": {
      "version": "1.1.0",
      "type": "build"
    }
  }
}
```

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.0" PrivateAssets="All" />
</ItemGroup>
```

#### type: platform
```json
{
  "dependencies": {
    "Microsoft.NETCore.App": {
      "version": "1.1.0",
      "type": "platform"
    }
  }
}
```

There is no equivalent in csproj. The `Microsoft.NETCore.App` metapackage is implicitly referenced based on the target framework of your app.
For more information, see [Implicit package references](../preview3/tools/csproj.md#implicit-package-references).

## runtimes
```json
{
  "runtimes": {
    "win7-x64": {},
    "osx.10.11-x64": {},
    "ubuntu.16.04-x64": {}
  }
}
```

```xml
<PropertyGroup>
  <RuntimeIdentifiers>win7-x64;osx.10-11-x64;ubuntu.16.04-x64</RuntimeIdentifiers>
</PropertyGroup>
```

### Standalone apps (self-contained deployment)
In project.json, defining a `runtimes` section means the app was standalone during
build and publish.
In MSBuild, all projects are *portable* during build, but can be published as
standalone.

`dotnet publish --framework netcoreapp1.0 --runtime osx.10.11-x64`

For more information, see [Self-contained deployments (SCD)](../preview3/deploying/index.md#self-contained-deployments-scd).

## tools
```json
{
  "tools": {
    "Microsoft.EntityFrameworkCore.Tools.DotNet": "1.0.0-*"
  }
}
```

```xml
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
</ItemGroup>
```

> [!NOTE]
> `imports` on tools are not supported in csproj. Tools that need imports will not work with
the new `Microsoft.NET.Sdk`.

## buildOptions

See also [Files](#files).

### emitEntryPoint

```json
{
  "buildOptions": {
    "emitEntryPoint": true
  }
}
```

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

If `emitEntryPoint` was `false`, the value of `OutputType` is converted to `Library`, which is the default value:

```json
{
  "buildOptions": {
    "emitEntryPoint": false
  }
}
```

```xml
<PropertyGroup>
  <OutputType>Library</OutputType>
  <!-- or, omit altogether. It defaults to 'Library' -->
</PropertyGroup>
```

### keyFile

```json
{
  "buildOptions": {
    "keyFile": "MyKey.snk"
  }
}
```

The `keyFile` element expands to three properties in MSBuild:

```xml
<PropertyGroup>
  <AssemblyOriginatorKeyFile>MyKey.snk</AssemblyOriginatorKeyFile>
  <SignAssembly>true</SignAssembly>
  <PublicSign Condition="'$(OS)' != 'Windows_NT'">true</PublicSign>
</PropertyGroup>
```

### Other common build options

```json
{
  "buildOptions": {
    "warningsAsErrors": true,
    "nowarn": ["CS0168", "CS0219"],
    "xmlDoc": true,
    "preserveCompilationContext": true,
    "outputName": "Different.AssemblyName",
    "debugType": "portable",
    "allowUnsafe": true,
    "define": ["TEST", "OTHERCONDITION"]
  }
}
```

```xml
<PropertyGroup>
  <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
  <NoWarn>$(NoWarn);CS0168;CS0219</NoWarn>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <PreserveCompilationContext>true</PreserveCompilationContext>
  <AssemblyName>Different.AssemblyName</AssemblyName>
  <DebugType>portable</DebugType>
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
  <DefineConstants>$(DefineConstants);TEST;OTHERCONDITION</DefineConstants>
</PropertyGroup>
```

## packOptions

See also [Files](#files).

### Common pack options

```json
{
  "packOptions": {
    "summary": "numl is a machine learning library intended to ease the use of using standard modeling techniques for both prediction and clustering.",
    "tags": ["machine learning", "framework"],
    "releaseNotes": "Version 0.9.12-beta",
    "iconUrl": "http://numl.net/images/ico.png",
    "projectUrl": "http://numl.net",
    "licenseUrl": "https://raw.githubusercontent.com/sethjuarez/numl/master/LICENSE.md",
    "requireLicenseAcceptance": false,
    "repository": {
      "type": "git",
      "url": "https://raw.githubusercontent.com/sethjuarez/numl"
    },
    "owners": ["Seth Juarez"]
  }
}
```

```xml
<PropertyGroup>
  <Title>numl is a machine learning library intended to ease the use of using standard modeling techniques for both prediction and clustering.</Title>
  <PackageTags>machine learning;framework</PackageTags>
  <PackageReleaseNotes>Version 0.9.12-beta</PackageReleaseNotes>
  <PackageIconUrl>http://numl.net/images/ico.png</PackageIconUrl>
  <PackageProjectUrl>http://numl.net</PackageProjectUrl>
  <PackageLicenseUrl>https://raw.githubusercontent.com/sethjuarez/numl/master/LICENSE.md</PackageLicenseUrl>
  <PackageRequireLicenseAcceptance>false</PackageRequireLicenseAcceptance>
  <RepositoryType>git</RepositoryType>
  <RepositoryUrl>https://raw.githubusercontent.com/sethjuarez/numl</RepositoryUrl>
  <!-- owners is not supported in MSBuild -->
</PropertyGroup>
```

There is no equivalent for the `owners` element in MSBuild.

## scripts

```json
{
  "scripts": {
    "precompile": "generateCode.cmd",
    "postpublish": [ "obfuscate.cmd", "removeTempFiles.cmd" ]
  }
}
```

Their equivalent in MSBuild are targets:

```xml
<Target Name="MyPreCompileTarget" BeforeTargets="Build">
  <Exec Command="generateCode.cmd" />
</Target>

<Target Name="MyPostCompileTarget" AfterTargets="Publish">
  <Exec Command="obfuscate.cmd" />
  <Exec Command="removeTempFiles.cmd" />
</Target>
```


## runtimeOptions

```json
{
  "runtimeOptions": {
    "configProperties": {
      "System.GC.Server": true,
      "System.GC.Concurrent": true,
      "System.GC.RetainVM": true,
      "System.Threading.ThreadPool.MinThreads": 4,
      "System.Threading.ThreadPool.MaxThreads": 25
    }
  }
}
```

All settings in this group should be placed in the project folder into a file called
*runtimeconfig.template.json*, with options lifted to the root object, 
like in the following example:

```json
{
  "configProperties": {
    "System.GC.Server": true
  }
}
```

## shared
```json
{
  "shared": "shared/**/*.cs"
}
```

Not supported in csproj. You must instead create include content files in your *.nuspec* file. 
For more information, see [Including content files](https://docs.microsoft.com/nuget/schema/nuspec#including-content-files).

## files

In *project.json*, build and pack could be extended to compile and embed from different folders.
In MSBuild, this is done using items. The following example is a common conversion:

```json
{
  "buildOptions": {
    "compile": {
      "copyToOutput": "notes.txt",
      "include": "../Shared/*.cs",
      "exclude": "../Shared/Not/*.cs"
    },
    "embed": {
      "include": "../Shared/*.resx"
    }
  },
  "packOptions": {
    "include": "Views/",
    "mappings": {
      "some/path/in/project.txt": "in/package.txt"
    }
  },
  "publishOptions": {
    "include": [
      "files/",
      "publishnotes.txt"
    ]
  }
}
```

```xml
<ItemGroup>
  <Compile Include="..\Shared\*.cs" Exclude="..\Shared\Not\*.cs" />
  <EmbeddedResource Include="..\Shared\*.resx" />
  <Content Include="Views\**\*" PackagePath="%(Identity)" />
  <None Include="some/path/in/project.txt" Pack="true" PackagePath="in/package.txt" />
  
  <None Include="notes.txt" CopyToOutputDirectory="Always" />
  <!-- CopyToOutputDirectory = { Always, PreserveNewest, Never } -->

  <Content Include="files\**\*" CopyToPublishDirectory="PreserveNewest" />
  <None Include="publishnotes.txt" CopyToPublishDirectory="Always" />
  <!-- CopyToPublishDirectory = { Always, PreserveNewest, Never } -->
</ItemGroup>
```

> [!NOTE]
> Many of default globbing patterns are added automatically by the .NET Core SDK.
> For more information, see [Default Compile Item Values](https://aka.ms/sdkimplicititems).

All MSBuild `ItemGroup` elements support `Include`, `Exclude`, and `Remove`.

Package layout inside the .nupkg can be modified with `PackagePath="path"`.

Except for `Content`, most item groups require explicitly adding `Pack="true"` to 
be included in the package. By default, this will be put in the *content* folder
in a package. `PackagePath="%(Identity)"` is a short way of setting package path
to the project-relative file path.

## testRunner

### xunit

```json
{
  "testRunner": "xunit",
  "dependencies": {
    "dotnet-test-xunit": "<any>"
  }
}
```

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.0.0-*" />
  <PackageReference Include="xunit" Version="2.2.0-*" />
  <PackageReference Include="xunit.runner.visualstudio" Version="2.2.0-*" />
</ItemGroup>
```

### mstest

```json
{
  "testRunner": "mstest",
  "dependencies": {
    "dotnet-test-mstest": "<any>"
  }
}
```

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.0.0-*" />
  <PackageReference Include="MSTest.TestAdapter" Version="1.1.12" />
  <PackageReference Include="MSTest.TestFramework" Version="1.0.0-*" />
</ItemGroup>
```

## See Also
[project.json reference](project-json.md)

[High-level overview of changes in CLI](../preview3/layering.md)