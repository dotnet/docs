---
title: Assembly validation
description: Learn how assembly validation can be used to develop consistent and well-formed multi-targeting assemblies.
ms.date: 02/29/2024
ms.topic: overview
---

# Assembly validation

Similar to [package validation](package-validation/overview.md), assembly validation tooling allows you, as a library developer, to validate that your assemblies are consistent and well formed. Use assembly validation instead of package validation when your app isn't packable.

Assembly validation provides the following checks:

- Validates that there are no breaking changes across versions.
- Validates that the assembly has the same set of public APIs for all the different runtime-specific implementations.
- Catches any applicability holes.

You can run assembly validation either as an [MSBuild task](#enable-msbuild-task) or using the [Microsoft.DotNet.ApiCompat.Tool global tool](global-tool.md).

## Enable MSBuild task

You enable assembly validation in your .NET project by setting the [`ApiCompatValidateAssemblies`](../../core/project-sdk/msbuild-props.md#apicompatvalidateassemblies) property to `true` and specifying the path to the *contract* (baseline) assembly. You must also add a package reference to [Microsoft.DotNet.ApiCompat.Task](https://www.nuget.org/packages/Microsoft.DotNet.ApiCompat.Task). (The `targets` files in that package aren't part of the .NET SDK.)

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>net8.0</TargetFrameworks>
    <ApiCompatValidateAssemblies>true</ApiCompatValidateAssemblies>
    <ApiCompatContractAssembly>[Path to contract assembly]</ApiCompatContractAssembly>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup Condition="'$(ApiCompatValidateAssemblies)' == 'true'">
    <PackageReference Include="Microsoft.DotNet.ApiCompat.Task" Version="8.0.100" PrivateAssets="all" IsImplicitlyDefined="true" />
  </ItemGroup>

</Project>
```

Assembly validation runs either in the outer build for multi-targeting projects (after the `DispatchToInnerBuilds` target) or in the inner build for a single-targeting project (as part of the `PrepareForRun` target). It's also fully incremental, meaning the comparison is only triggered if the inputs or outputs have changed.

### Example

1. Create and build a C# class library named "ValidateMe" that contains the following simple interface:

   ```csharp
   namespace ValidateMe;
   
   public interface IAnimal
   {
       string Name { get; }
       //string Sound { get; }
   }
   ```

1. Rename the output assembly to "ValidateMeV1.dll".
1. Add the `Sound` property to the interface by uncommenting that line of code.
1. Add the `ApiCompatValidateAssemblies` and `ApiCompatContractAssembly` properties and the "Microsoft.DotNet.ApiCompat.Task" package reference to your project file. Also increment the version of your assembly to "2.0.0".

   ```xml
   <PropertyGroup>
     <OutputType>Library</OutputType>
     <TargetFrameworks>net8.0</TargetFrameworks>
     <ApiCompatValidateAssemblies>true</ApiCompatValidateAssemblies>
     <ApiCompatContractAssembly>$(OutDir)bin\Release\net8.0\ValidateMeV1.dll</ApiCompatContractAssembly>
     <IsPackable>false</IsPackable>
     <Version>2.0.0</Version>
   </PropertyGroup>

   <ItemGroup Condition="'$(ApiCompatValidateAssemblies)' == 'true'">
      <PackageReference Include="Microsoft.DotNet.ApiCompat.Task" Version="8.0.100" PrivateAssets="all" IsImplicitlyDefined="true" />
   </ItemGroup>
   ```

1. Rebuild your class library.

   The build fails with the following errors:

   ```output
   C:\Users\me\.nuget\packages\microsoft.dotnet.apicompat.task\8.0.100\build\Microsoft.DotNet.ApiCompat.ValidateAssemblies.Common.targets(16,5): error : API compatibility errors between 'bin\Release\net8.0\ValidateMeV1.dll' (left) and 'C:\Users\me\source\repos\ValidateMe\bin\Release\net8.0\ValidateMe.dll' (right):
   1>C:\Users\me\.nuget\packages\microsoft.dotnet.apicompat.task\8.0.100\build\Microsoft.DotNet.ApiCompat.ValidateAssemblies.Common.targets(16,5): error CP0006: Cannot add interface member 'string ValidateMe.IAnimal.Sound' to C:\Users\me\source\repos\ValidateMe\bin\Release\net8.0\ValidateMe.dll because it does not exist on bin\Release\net8.0\ValidateMeV1.dll
   1>C:\Users\me\.nuget\packages\microsoft.dotnet.apicompat.task\8.0.100\build\Microsoft.DotNet.ApiCompat.ValidateAssemblies.Common.targets(16,5): error : API breaking changes found. If those are intentional, the APICompat suppression file can be updated by rebuilding with '/p:ApiCompatGenerateSuppressionFile=true'
   ```

## Suppress compatibility warnings

For information about suppressing compatibility warnings, see [How to suppress](diagnostic-ids.md#how-to-suppress).
