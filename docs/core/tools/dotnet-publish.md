---
title: dotnet publish command
description: The dotnet publish command publishes a .NET project or solution to a directory.
ms.date: 04/04/2024
---
# dotnet publish

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet publish` - Publishes the application and its dependencies to a folder for deployment to a hosting system.

## Synopsis

```dotnetcli
dotnet publish [<PROJECT>|<SOLUTION>] [-a|--arch <ARCHITECTURE>]
    [--artifacts-path <ARTIFACTS_DIR>]
    [-c|--configuration <CONFIGURATION>] [--disable-build-servers]
    [-f|--framework <FRAMEWORK>] [--force] [--interactive]
    [--manifest <PATH_TO_MANIFEST_FILE>] [--no-build] [--no-dependencies]
    [--no-restore] [--nologo] [-o|--output <OUTPUT_DIRECTORY>]
    [--os <OS>] [-r|--runtime <RUNTIME_IDENTIFIER>]
    [--sc|--self-contained [true|false]] [--no-self-contained]
    [-s|--source <SOURCE>] [--tl:[auto|on|off]]
    [--use-current-runtime, --ucr [true|false]]
    [-v|--verbosity <LEVEL>] [--version-suffix <VERSION_SUFFIX>]

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

### .pubxml files

You can also set publish-related properties by referring to a *.pubxml* file. For example:

```dotnetcli
dotnet publish -p:PublishProfile=FolderProfile
```

The preceding example uses the *FolderProfile.pubxml* file that is found in the *\<project_folder>/Properties/PublishProfiles* folder. If you specify a path and file extension when setting the `PublishProfile` property, they're ignored. MSBuild by default looks in the *Properties/PublishProfiles* folder and assumes the *pubxml* file extension. To specify the path and filename including extension, set the `PublishProfileFullPath` property instead of the `PublishProfile` property.

In the *.pubxml* file:

* `PublishUrl` is used by Visual Studio to denote the Publish target.
* `PublishDir` is used by the CLI to denote the Publish target.

If you want the scenario to work in all places, you can initialize both these properties to the same value in the *.pubxml* file. When GitHub issue [dotnet/sdk#20931](https://github.com/dotnet/sdk/issues/20931) is resolved, only one of these properties will need to be set.

Some properties in the *.pubxml* file are honored only by Visual Studio and have no effect on `dotnet publish`. We're working to bring the CLI more into alignment with Visual Studio's behavior. But some properties will never be used by the CLI. The CLI and Visual Studio both do the packaging aspect of publishing, and [dotnet/sdk#29817](https://github.com/dotnet/sdk/pull/29817) plans to add support for more properties related to that. But the CLI doesn't do the deployment automation aspect of publishing, and properties related to that aren't supported. The most notable *.pubxml* properties that aren't supported by `dotnet publish` are the following ones that impact the build:

* `LastUsedBuildConfiguration`
* `Configuration`
* `Platform`
* `LastUsedPlatform`
* `TargetFramework`
* `TargetFrameworks`
* `RuntimeIdentifier`
* `RuntimeIdentifiers`

### MSBuild properties

The following MSBuild properties change the output of `dotnet publish`.

- `PublishReadyToRun`

  Compiles application assemblies as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation. For more information, see [ReadyToRun images](../deploying/ready-to-run.md).

  To see warnings about missing dependencies that could cause runtime failures, use `PublishReadyToRunShowWarnings=true`.

  We recommend that you specify `PublishReadyToRun` in a publish profile rather than on the command line.

- `PublishSingleFile`

  Packages the app into a platform-specific single-file executable. For more information about single-file publishing, see the [single-file bundler design document](https://github.com/dotnet/designs/blob/main/accepted/2020/single-file/design.md).

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

  * `SOLUTION` is the path and filename of a solution file (*.sln* extension), or the path to a directory that contains a solution file. If the directory is not specified, it defaults to the current directory.

## Options

[!INCLUDE [arch](../../../includes/cli-arch.md)]

[!INCLUDE [artifacts-path](../../../includes/cli-artifacts-path.md)]

[!INCLUDE [configuration](../../../includes/cli-configuration-publish-pack.md)]

[!INCLUDE [disable-build-servers](../../../includes/cli-disable-build-servers.md)]

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

  Doesn't display the startup banner or the copyright message.

- **`--no-restore`**

  Doesn't execute an implicit restore when running the command.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Specifies the path for the output directory.

  If not specified, it defaults to *[project_file_folder]/bin/[configuration]/[framework]/publish/* for a framework-dependent executable and cross-platform binaries. It defaults to *[project_file_folder]/bin/[configuration]/[framework]/[runtime]/publish/* for a self-contained executable.

  In a web project, if the output folder is in the project folder, successive `dotnet publish` commands result in nested output folders. For example, if the project folder is *myproject*, and the publish output folder is *myproject/publish*, and you run `dotnet publish` twice, the second run puts content files such as *.config* and *.json* files in *myproject/publish/publish*. To avoid nesting publish folders, specify a publish folder that isn't **directly** under the project folder, or exclude the publish folder from the project. To exclude a publish folder named *publishoutput*, add the following element to a `PropertyGroup` element in the *.csproj* file:

  ```xml
  <DefaultItemExcludes>$(DefaultItemExcludes);publishoutput**</DefaultItemExcludes>
  ```

  - .NET 7.0.200 SDK and later

    If you specify the `--output` option when running this command on a solution, the CLI will emit a warning (an error in 7.0.200) due to the unclear semantics of the output path. The `--output` option is disallowed because all outputs of all built projects would be copied into the specified directory, which isn't compatible with multi-targeted projects, as well as projects that have different versions of direct and transitive dependencies. For more information, see [Solution-level `--output` option no longer valid for build-related commands](../compatibility/sdk/7.0/solution-level-output-no-longer-valid.md).

  - .NET Core 3.x SDK and later

    If you specify a relative path when publishing a project, the generated output directory is relative to the current working directory, not to the project file location.

    If you specify a relative path when publishing a solution, all output for all projects goes into the specified folder relative to the current working directory. To make publish output go to separate folders for each project, specify a relative path by using the msbuild `PublishDir` property instead of the `--output` option. For example, `dotnet publish -p:PublishDir=.\publish` sends publish output for each project to a `publish` folder under the folder that contains the project file.

  - .NET Core 2.x SDK

    If you specify a relative path when publishing a project, the generated output directory is relative to the project file location, not to the current working directory.

    If you specify a relative path when publishing a solution, each project's output goes into a separate folder relative to the project file location. If you specify an absolute path when publishing a solution, all publish output for all projects goes into the specified folder.

[!INCLUDE [os](../../../includes/cli-os.md)]

- **`--sc|--self-contained [true|false]`**

  Publishes the .NET runtime with your application so the runtime doesn't need to be installed on the target machine. Default is `true` if a runtime identifier is specified and the project is an executable project (not a library project). For more information, see [.NET application publishing](../deploying/index.md) and [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md).

  If this option is used without specifying `true` or `false`, the default is `true`. In that case, don't put the solution or project argument immediately after `--self-contained`, because `true` or `false` is expected in that position.

- **`--no-self-contained`**

  Equivalent to `--self-contained false`.

- **`--source <SOURCE>`**

  The URI of the NuGet package source to use during the restore operation.

- **`-r|--runtime <RUNTIME_IDENTIFIER>`**

  Publishes the application for a given runtime. For a list of Runtime Identifiers (RIDs), see the [RID catalog](../rid-catalog.md). For more information, see [.NET application publishing](../deploying/index.md) and [Publish .NET apps with the .NET CLI](../deploying/deploy-with-cli.md). If you use this option, use `--self-contained` or `--no-self-contained` also.

[!INCLUDE [tl](../../../includes/cli-tl.md)]

- **`--use-current-runtime, --ucr [true|false]`**

  Sets the `RuntimeIdentifier` to a platform portable `RuntimeIdentifier` based on the one of your machine. This happens implicitly with properties that require a `RuntimeIdentifier`, such as `SelfContained`, `PublishAot`, `PublishSelfContained`, `PublishSingleFile`, and `PublishReadyToRun`. If the property is set to false, that implicit resolution will no longer occur.

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
  dotnet publish --runtime osx-x64
  ```

  The RID must be in the project file.

- Create a [framework-dependent executable](../deploying/index.md#publish-framework-dependent) for the project in the current directory, for a specific platform:

  ```dotnetcli
  dotnet publish --runtime osx-x64 --self-contained false
  ```

  The RID must be in the project file. This example applies to .NET Core 3.0 SDK and later versions.

- Publish the project in the current directory, for a specific runtime and target framework:

  ```dotnetcli
  dotnet publish --framework net8.0 --runtime osx-x64
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
- [Containerize a .NET app with dotnet publish](../docker/publish-as-container.md)
- [Working with macOS Catalina Notarization](../install/macos-notarization-issues.md)
- [Directory structure of a published application](/aspnet/core/hosting/directory-structure)
- [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference)
- [Visual Studio publish profiles (.pubxml) for ASP.NET Core app deployment](/aspnet/core/host-and-deploy/visual-studio-publish-profiles)
- [dotnet msbuild](dotnet-msbuild.md)
- [Trim self-contained deployments](../deploying/trimming/trim-self-contained.md)
