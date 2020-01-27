---
title: MSBuild properties for .NET Core SDK projects
description: Reference for the MSBuild properties that are understood by the .NET Core SDK.
ms.date: 01/28/2020
ms.topic: reference
---
# MSBuild properties for .NET Core projects

.NET Core projects are based on the [MSBuild](/visualstudio/msbuild/msbuild) format. Project files are in XML format. Each property in the file can have attributes and subitems.

> [!NOTE]
> This page is a work in progress and does not list all of the MSBuild properties for the .NET Core SDKs.

- .NET Core SDK
- Web SDK
- Targets
- Properties

General:

ItemGroup
PropertyGroup
Sdk attribute (Project)
AssemblyName
RootNamespace (VB, F#)
ApplicationIcon
StartupObject

Version:

VersionPrefix
VersionSuffix
Version

Other top-level props:

<PropertyGroup>
  <Authors>Anne;Bob</Authors>
  <Company>Contoso</Company>
  <NeutralLanguage>en-US</NeutralLanguage>
  <AssemblyTitle>My library</AssemblyTitle>
  <Description>This is my library. And it's really great!</Description>
  <Copyright>Nugetizer 3000</Copyright>
  <UserSecretsId>xyz123</UserSecretsId>
</PropertyGroup>

Frameworks:

TargetFramework
TargetFrameworks

Framework reference resolution:

FrameworkReference
KnownFrameworkReference
TargetFrameworkIdentifier
_TargetFrameworkVersionWithoutV
NetCoreTargetingPackRoot
BundledRuntimeIdentifierGraphFile
SelfContained
RuntimeIdentifier
RuntimeIdentifiers
RuntimeFrameworkVersion
TargetLatestRuntimePatch
_TargetLatestRuntimePatchIsDefault
EnableTargetingPackDownload
AppHostRuntimeIdentifier
DefaultAppHostRuntimeIdentifier
PackAsToolShimRuntimeIdentifiers
_PackAsToolShimRuntimeIdentifiers
_DotNetAppHostExecutableNameWithoutExtension
_DotNetComHostLibraryNameWithoutExtension
_DotNetIjwHostLibraryNameWithoutExtension
BundledRuntimeIdentifierGraphFile
KnownAppHostPack

UserSecretsId
GenerateUserSecretsAttribute
GeneratedUserSecretsAttributeFile
CopyLocalLockFileAssemblies
SelfContained
ResolvedRuntimePack
UnavailableRuntimePack
SatelliteResourceLanguages
DesignTimeBuild
CopyLocalLockFileAssemblies

MicrosoftNETBuildTasksAssembly

GenerateErrorForMissingTargetingPacks
DesignTimeBuild

IjwHostSourcePath
ComHostSourcePath
AppHostSourcePath

UsePackageDownload
MSBuildRuntimeType
PackageDownloadSupported

BundledRuntimeIdentifierGraphFile

EnableComHosting
UseIJWHost

Dependencies:

NetStandardImplicitPackageVersion
PackageReference + attributes
PackageTargetFallback
ProjectReference

Runtimes:

RuntimeIdentifiers

Tools:

DotNetCliToolReference

Build options:

OutputType
AssemblyOriginatorKeyFile
SignAssembly
PublicSign
EnableDefaultCompileItems
EnableDefaultNoneItems
EnableDefaultItems

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

Pack options (NuGet):

<PropertyGroup>
  <PackageTags>machine learning;framework</PackageTags>
  <PackageReleaseNotes>Version 0.9.12-beta</PackageReleaseNotes>
  <PackageIconUrl>http://numl.net/images/ico.png</PackageIconUrl>
  <PackageProjectUrl>http://numl.net</PackageProjectUrl>
  <PackageLicenseUrl>https://raw.githubusercontent.com/sethjuarez/numl/master/LICENSE.md</PackageLicenseUrl>
  <RepositoryType>git</RepositoryType>
  <RepositoryUrl>https://raw.githubusercontent.com/sethjuarez/numl</RepositoryUrl>
</PropertyGroup>
IsPackable
PackageVersion
PackageId
PackageDescription
Title
Authors
PackageRequireLicenseAcceptance
PackageLicenseExpression
PackageLicenseFile
PackageOutputPath
IncludeSymbols
SymbolPackageFormat
IncludeSource
IsTool
RepositoryUrl
RepositoryType
RepositoryBranch
RepositoryCommit
NoPackageAnalysis
MinClientVersion
IncludeBuildOutput
IncludeContentInPack
BuildOutputTargetFolder
ContentTargetFolders
NuspecFile
NuspecBasePath
NuspecProperties

Assembly info:

GenerateAssemblyInfo
GeneratedAssemblyInfoFile
Company
GenerateAssemblyCompanyAttribute
Configuration
GenerateAssemblyConfigurationAttribute
Copyright
GenerateAssemblyCopyrightAttribute
Description
GenerateAssemblyDescriptionAttribute
FileVersion
GenerateAssemblyFileVersionAttribute
InformationalVersion
GenerateAssemblyInformationalVersionAttribute
Product
GenerateAssemblyProductAttribute
AssemblyTitle
GenerateAssemblyTitleAttribute
AssemblyVersion
GenerateAssemblyVersionAttribute
NeutralLanguage
GenerateNeutralResourcesLanguageAttribute

Pre-/post-compile scripts:

<Target Name="MyPreCompileTarget" BeforeTargets="Build">
  <Exec Command="generateCode.cmd" />
</Target>

<Target Name="MyPostCompileTarget" AfterTargets="Publish">
  <Exec Command="obfuscate.cmd" />
  <Exec Command="removeTempFiles.cmd" />
</Target>

Files:

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

Publish:

PublishReadyToRun (and PublishReadyToRunExclude)
RuntimeIdentifier
RuntimeIdentifiers
UseAppHost - see https://github.com/dotnet/docs/issues/16407#issuecomment-571772518

LangVersion
LinkBase
AppendTargetFrameworkToOutputPath
OutputPath
CodeAnalysisRuleSet

## See also

- [.NET Core run-time configuration settings](../run-time-config/index.md)
- [MSBuild properties for ASP.NET Core Razor SDK](/aspnet/core/razor-pages/sdk#properties)
- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
