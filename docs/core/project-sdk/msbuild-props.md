---
title: MSBuild properties for Microsoft.NET.Sdk
description: Reference for the MSBuild properties that are understood by the .NET Core SDK.
ms.date: 01/28/2020
ms.topic: reference
---
# MSBuild properties for .NET Core SDK projects

> [!NOTE]
> This page is a work in progress and does not list all of the MSBuild properties for the .NET Core SDK.

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

Pack options - link to NuGet docs.

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
RuntimeIdentifier - see https://docs.microsoft.com/dotnet/core/rid-catalog
RuntimeIdentifiers
UseAppHost - see https://github.com/dotnet/docs/issues/16407#issuecomment-571772518

LangVersion
LinkBase
AppendTargetFrameworkToOutputPath
OutputPath
CodeAnalysisRuleSet

EnableDynamicLoading, EnableComHosting - see https://github.com/dotnet/sdk/pull/3305#issuecomment-504549489

AssetTargetFallback

## See also

- [MSBuild schema reference](/visualstudio/msbuild/msbuild-project-file-schema-reference)
- [Common MSBuild properties](/visualstudio/msbuild/common-msbuild-project-properties)
- [MSBuild properties for NuGet pack](/nuget/reference/msbuild-targets#pack-target)
- [MSBuild properties for NuGet restore](/nuget/reference/msbuild-targets#restore-properties)
- [.NET Core run-time configuration settings](../run-time-config/index.md)
