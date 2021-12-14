---
title: dotnet publish command
description: The dotnet publish command publishes a .NET project or solution to a directory.
ms.date: 12/02/2021
---
# dotnet publish

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Name

`dotnet publish` - Publishes the application and its dependencies to a folder for deployment to a hosting system.

## Synopsis

```dotnetcli
dotnet publish [<PROJECT>|<SOLUTION>] [-a|--arch <ARCHITECTURE>]
    [-c|--configuration <CONFIGURATION>]
    [-f|--framework <FRAMEWORK>] [--force] [--interactive]
    [--manifest <PATH_TO_MANIFEST_FILE>] [--no-build] [--no-dependencies]
    [--no-restore] [--nologo] [-o|--output <OUTPUT_DIRECTORY>]
    [--os <OS>] [-r|--runtime <RUNTIME_IDENTIFIER>]
    [--self-contained [true|false]] [--no-self-contained]
     [-s|--source <SOURCE>] [-v|--verbosity <LEVEL>]
    [--version-suffix <VERSION_SUFFIX>]

dotnet publish -h|--help
```

## Description

`dotnet publish` compiles the application, reads through its dependencies specified in the project file, and publishes the resulting set of files to a directory. The output includes the following assets:

- Intermediate Language (IL) code in an assembly with a *dll* extension.
- A *.deps.json* file that includes all of the dependencies of the project.
- A *.runtimeconfig.json* file that specifies the shared runtime that the application expects, as well as other configuration options for the runtime (for example, garbage collection type).
- The application's dependencies, which are copied from the NuGet cache into the output folder.

The `dotnet publish` command's output is ready for deployment to a hosting system (for example, a server, PC, Mac, laptop) for execution. It's the only officially supported way to prepare the application for deployment. Depending on the type of deployment that the project specifies, the hosting system may or may not have the .NET shared runtime installed on it. For more information, see [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md).

### Implicit restore

[!INCLUDE[dotnet restore note](../../../includes/dotnet-restore-note.md)]

### MSBuild

The `dotnet publish` command calls MSBuild, which invokes the `Publish` target. If the [`IsPublishable` property](../project-sdk/msbuild-props.md#ispublishable) is set to `false` for a particular project, the `Publish` target can't be invoked, and the `dotnet publish` command only runs the implicit [dotnet restore](dotnet-restore.md) on the project.

Any parameters passed to `dotnet publish` are passed to MSBuild. The `-c` and `-o` parameters map to MSBuild's `Configuration` and `PublishDir` properties, respectively.

The `dotnet publish` command accepts MSBuild options, such as `-p` for setting properties and `-l` to define a logger. For example, you can set an MSBuild property by using the format: `-p:<NAME>=<VALUE>`.

You can also set publish-related properties by referring to a *.pubxml* file (available since .NET Core 3.1 SDK). For example:

```dotnetcli
dotnet publish -p:PublishProfile=FolderProfile
```

The preceding example uses the *FolderProfile.pubxml* file that is found in the *\<project_folder>/Properties/PublishProfiles* folder. If you specify a path and file extension when setting the `PublishProfile` property, they are ignored. MSBuild by default looks in the *Properties/PublishProfiles* folder and assumes the *pubxml* file extension. To specify the path and filename including extension, set the `PublishProfileFullPath` property instead of the `PublishProfile` property.

The following MSBuild properties change the output of `dotnet publish`.

- `PublishReadyToRun`

  Compiles application assemblies as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation. For more information, see [ReadyToRun images](../deploying/ready-to-run.md). Available since .NET Core 3.0 SDK.

  To see warnings about missing dependencies that could cause runtime failures, use `PublishReadyToRunShowWarnings=true`.

  We recommend that you specify `PublishReadyToRun` in a publish profile rather than on the command line.

- `PublishSingleFile`

  Packages the app into a platform-specific single-file executable. For more information about single-file publishing, see the [single-file bundler design document](https://github.com/dotnet/designs/blob/main/accepted/2020/single-file/design.md). Available since .NET Core 3.0 SDK.

  We recommend that you specify this option in the project file rather than on the command line.

- `PublishTrimmed`

  Trims unused libraries to reduce the deployment size of an app when publishing a self-contained executable. For more information, see [Trim self-contained deployments and executables](../deploying/trimming/trim-self-contained.md). Available since .NET 6 SDK.

  We recommend that you specify this option in the project file rather than on the command line.

For more information, see the following resources:

- [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference)
- [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](/aspnet/core/host-and-deploy/visual-studio-publish-profiles)
- [dotnet msbuild](dotnet-msbuild.md)

[!INCLUDE [cli-advertising-manifests](../../../includes/cli-advertising-manifests.md)]

## Arguments

- **`PROJECT|SOLUTION`**

  The project or solution to publish.

  * `PROJECT` is the path and filename of a C#, F#, or Visual Basic project file, or the path to a directory that contains a C#, F#, or Visual Basic project file. If the directory is not specified, it defaults to the current directory.

  * `SOLUTION` is the path and filename of a solution file (*.sln* extension), or the path to a directory that contains a solution file. If the directory is not specified, it defaults to the current directory. Available since .NET Core 3.0 SDK.

## Options

<!-- markdownlint-disable MD012 -->

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration.md)]

- **`-f|--framework <FRAMEWORK>`**

  Publishes the application for the specified [target framework](../../standard/frameworks.md). You must specify the target framework in the project file.

- **`--force`**

  Forces all dependencies to be resolved even if the last restore was successful. Specifying this flag is the same as deleting the *project.assets.json* file.

[!INCLUDE [help](../../../includes/cli-help.md)]

[!INCLUDE [interactive](../../../includes/cli-interactive-3-0.md)]

- **`--manifest <PATH_TO_MANIFEST_FILE>`**

  Specifies one or several [target manifests](../deploying/runtime-store.md) to use to trim the set of packages published with the app. The manifest file is part of the output of the [`dotnet store` command](dotnet-store.md). To specify multiple manifests, add a `--manifest` option for each manifest.

- **`--no-build`**

  Doesn't build the project before publishing. It also implicitly sets the `--no-restore` flag.

- **`--no-dependencies`**

  Ignores project-to-project references and only restores the root project.

- **`--nologo`**

  Doesn't display the startup banner or the copyright message. Available since .NET Core 3.0 SDK.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Specifies the path for the output directory.

  If not specified, it defaults to *[project_file_folder]/bin/[configuration]/[framework]/publish/* for a framework-dependent executable and cross-platform binaries. It defaults to *[project_file_folder]/bin/[configuration]/[framework]/[runtime]/publish/* for a self-contained executable.

  In a web project, if the output folder is in the project folder, successive `dotnet publish` commands result in nested output folders. For example, if the project folder is *myproject*, and the publish output folder is *myproject/publish*, and you run `dotnet publish` twice, the second run puts content files such as *.config* and *.json* files in *myproject/publish/publish*. To avoid nesting publish folders, specify a publish folder that is not **directly** under the project folder, or exclude the publish folder from the project. To exclude a publish folder named *publishoutput*, add the following element to a `PropertyGroup` element in the *.csproj* file:

  ```xml
  <DefaultItemExcludes>$(DefaultItemExcludes);publishoutput**</DefaultItemExcludes>
  ```

  - .NET Core 3.x SDK and later

    If you specify a relative path when publishing a project, the generated output directory is relative to the current working directory, not to the project file location.

    If you specify a relative path when publishing a solution, all output for all projects goes into the specified folder relative to the current working directory. To make publish output go to separate folders for each project, specify a relative path by using the msbuild `PublishDir` property instead of the `--output` option. For example, `dotnet publish -p:PublishDir=.\publish` sends publish output for each project to a `publish` folder under the folder that contains the project file.

  - .NET Core 2.x SDK

    If you specify a relative path when publishing a project, the generated output directory is relative to the project file location, not to the current working directory.

    If you specify a relative path when publishing a solution, each project's output goes into a separate folder relative to the project file location. If you specify an absolute path when publishing a solution, all publish output for all projects goes into the specified folder.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`--self-contained [true|false]`**

  Publishes the .NET runtime with your application so the runtime doesn't need to be installed on the target machine. Default is `true` if a runtime identifier is specified and the project is an executable project (not a library project). For more information, see [.NET application publishing](../deploying/index.md) and [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md).

  If this option is used without specifying `true` or `false`, the default is `true`. In that case, don't put the solution or project argument immediately after `--self-contained`, because `true` or `false` is expected in that position.

- **`--no-self-contained`**

  Equivalent to `--self-contained false`. Available since .NET Core 3.0 SDK.

- **`--source <SOURCE>`**

  The URI of the NuGet package source to use during the restore operation.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Publishes the application for a given runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). For more information, see [.NET application publishing](../deploying/index.md) and [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md). If you use this option, use `--self-contained` or `--no-self-contained` also.

[!INCLUDE [verbosity](../../../includes/cli-verbosity-minimal.md)]

- **`--version-suffix <VERSION_SUFFIX>`**

  Defines the version suffix to replace the asterisk (`*`) in the version field of the project file.

## Examples

- Create a [framework-dependent cross-platform binary](../deploying/index.md#produce-a-cross-platform-binary) for the project in the current directory:

  ```dotnetcli
  dotnet publish
  ```

  Starting with .NET Core 3.0 SDK, this example also creates a [framework-dependent executable](../deploying/index.md#publish-framework-dependent) for the current platform.

- Create a [self-contained executable](../deploying/index.md#publish-self-contained) for the project in the current directory, for a specific runtime:

  ```dotnetcli
  dotnet publish --runtime osx.10.11-x64
  ```

  The RID must be in the project file.

- Create a [framework-dependent executable](../deploying/index.md#publish-framework-dependent) for the project in the current directory, for a specific platform:

  ```dotnetcli
  dotnet publish --runtime osx.10.11-x64 --self-contained false
  ```

  The RID must be in the project file. This example applies to .NET Core 3.0 SDK and later versions.

- Publish the project in the current directory, for a specific runtime and target framework:

  ```dotnetcli
  dotnet publish --framework netcoreapp3.1 --runtime osx.10.11-x64
  ```

- Publish the specified project file:

  ```dotnetcli
  dotnet publish ~/projects/app1/app1.csproj
  ```

- Publish the current application but don't restore project-to-project (P2P) references, just the root project during the restore operation:

  ```dotnetcli
  dotnet publish --no-dependencies
  ```

## See also

- [.NET application publishing overview](../deploying/index.md)
- [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md)
- [Target frameworks](../../standard/frameworks.md)
- [Runtime Identifier (RID) catalog](../rid-catalog.md)
- [Working with macOS Catalina Notarization](../install/macos-notarization-issues.md)
- [Directory structure of a published application](/aspnet/core/hosting/directory-structure)
- [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference)
- [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](/aspnet/core/host-and-deploy/visual-studio-publish-profiles)
- [dotnet msbuild](dotnet-msbuild.md)
- [ILLInk.Tasks](../deploying/trimming/trim-self-contained.md)
