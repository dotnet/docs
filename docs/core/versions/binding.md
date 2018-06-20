# .NET Core 2+ Version Binding

.NET Core applies a set of policies that determine which versions of the .NET Core runtime and SDK are used in various scenarios. These scenarios and policies are defined in this document. 

One can think of these policies performing the following roles:

- Providing an implicit "version manager" experience.
- Enabling easy and efficient deployment of .NET Core, including security and reliability updates.
- Enabling developers to use the latest tools and commands independent of target runtime.

## Experience

.NET Core provides a single entry-point for operating on projects and built applications, specifically with the `dotnet` command. This experience relies on an installation structure that can include multiple runtime and SDK versions. This structure is machine global and in the path by default, enabling a developer to access all .NET Core versions from any command prompt. It also enables updating all apps to use a new .NET Core patch version by installing it in this central structure/location. This differs from other development platforms that require re-setting the path or setting an environmental value to use different platform versions.

There is allowance for other scenarios, for example, for private .NET Core installations without use of the path. This document focusses more on the default behavior, but does call out opportunities to override this behavior.

The `dotnet` command must select a version in the following cases:

- Select an SDK to use to run an SDK command (for example, with `dotnet new`).
- Select a runtime to target an application (for example, with `dotnet build`).
- Select a runtime to run an application (for example, with `dotnet run`).
- Select a runtime to publish an application (with `dotnet publish`).

## Selecting an SDK

The first developer experience with .NET Core is typically with an SDK command, for example `dotnet new`, `dotnet build` or `dotnet run`. The `dotnet` command must select a version of the SDK to use to satisfy these commands. .NET Core has a "use the latest SDK" policy. This means that you will use the .NET Core 99.9 SDK if you install it on a machine, even if you are using the SDK command to do .NET Core 2.0 development.

The advantage of this policy is that you can take advantage of the latest SDK features and improvements while continuing to target earlier .NET Core versions. This is logically similar to using C# 7 with .NET Framework 4.5 (which also works). It is quite likely many developers will target multiple versions of .NET Core across a set of projects. It's nice that you can use the same tools for all of them.

You can configure `dotnet` to use a different version of the SDK by specifying that version in a [global.json file](https://docs.microsoft.com/dotnet/articles/core/tools/global-json). As a consequence of the "use latest" policy, you would only ever use `global.json` to specify a .NET Core version that is earlier than the latest installed version.

You can use `global.json` at a variety of scopes:

- Per project, placed beside the project file.
- For a set of projects, placed at a common [grand-]parent for all of the projects. This location can be as high in the directory structure as the root of a drive.

You can see the `global.json` syntax in the following example:

``` json
{
  "sdk": {
    "version": "1.0.0"
  }
}
```

The `global.json` file is an existing format and associated concept that is part of the .NET Core 1.0 tools. It is not new with .NET Core 2.0. The file fulfills a critical role, to enable developers to lock a specific app or set of apps to an earlier SDK than the latest on the machine. The need for this capability is most obvious for developers that need to continue using the preview2 sdk to use project.json-based applications. We will revisit the design of this file in a later release. We will also want to understand how often it is even used to better understand how important the scenario is. The less it is used, the more likely the file will stay as-is.

Implementer notes: 

- `dotnet` binds to latest SDK by default.
- This behavior can be overridden by global.json.
- The first global.json file found is selected, iteratively reverse-navigating the path from the current working directory.

## Building an application

You can build an application from source with `dotnet build` or `dotnet run` (the latter does more than is covered in this section). 

There are multiple points of version binding to consider:

- Selecting an SDK.
- Defining the target framework for the application.
- Defining a minimum runtime version.

The process of selecting an SDK is described earlier in the document.

The target framework is defined in the project file by setting a property in the following form:

``` xml
<TargetFramework>netcoreapp2.0</TargetFramework>
```

Multiple target frameworks can also be set if you need to build different code for different targets. This scenario is more common for libraries, but can be done with applications as well. You can do this by using a `TargetFrameworks` property (plural of TargetFramework). The target frameworks will be semicolon-delimited as you can see the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
```

A given SDK will support a fixed set of frameworks, typically capped to the target framework of the runtime(s) it includes. For example, the .NET Core 2.0 SDK includes the .NET Core 2.0 runtime, which is an implementation of the `netcoreapp2.0` target framework. The .NET Core 2.0 SDK will support `netcoreapp1.0`, `netcoreapp1.1` and `netcoreapp2.0` but not `netcoreapp2.1` (or higher). You will need to install the .NET Core 2.1 SDK in order to build for `netcoreapp2.1`. 

.NET Standard target frameworks are also capped in the same way. The .NET Core 2.0 SDK will be capped to `netstandard2.0`.

A given SDK will define a fixed minimum runtime patch version for each target framework that it supports. The minimum runtime patch version will be maintained at the `.0` version (for example, `2.0.0`) for the lifetime of a major/minor runtime version family. This policy makes deploying patches a web hoster concern and not a developer concern.

Hosters and other users have reported challenges with the .NET Core 1.x behavior, where the minimum patch version increases with each .NET Core SDK release. See: [Reconsider implicitly using the latest patch version of the targeted version of .NET Core in the SDK](https://github.com/dotnet/sdk/issues/983). This proposal is intended to resolve their feedback.

The SDK stores the minimum patch version for each supported target framework in the `~\dotnet\sdk\1.0.0\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.DefaultItems.targets` file.

The minimum runtime patch version is stored in the application directory in the `*.runtimeconfig.json` file. This value is used as part of runtime selection. You are not intended to edit this file.

You can override the minimum runtime patch version (to higher or lower versions) in the project file, as you can see in the following example:

``` xml
<RuntimeFrameworkVersion>2.0.4</RuntimeFrameworkVersion>
```

In the case that you target multiple target frameworks, you need to condition the minimum runtime patch version to the specific .NET Core target framework, as you can see in the following example:

``` xml
<TargetFrameworks>netcoreapp2.0;net47</TargetFrameworks>
<RuntimeFrameworkVersion Condition="'$(TargetFramework)' == 'netcoreapp2.0'">2.0.4</RuntimeFrameworkVersion> 
```

Implementer notes: 

- A given SDK supports a fixed set of target frameworks. 
- It is an error to target a framework outside that set.
- The SDK defines the minimum runtime patch version (set at the .0 patch) for a given target framework.
- This version can be overridden in a project file.

## Run from Source with dotnet run

You can run an application from source with `dotnet run`. `dotnet run` both builds and runs an application. 

There are multiple points of version binding to consider:

- Selecting an SDK
- Defining a target framework for the appliction
- Defining a minimum runtime patch version
- Selecting a runtime to run on

The process of selecting an SDK and building an application is described earlier in the document.

The built application will be run on machines that satisfy the minimum required runtime patch version, stored in the `*.runtimeconfig.json` file. The highest patch version will be selected. For example, the `2.0.4` runtime will be selected in the case that the minimum runtime version is `2.0.0` while `2.0.0`, `2.0.1` and `2.0.4` are all resident on the machine. Higher minor or major versions (for example, `2.1.1` or `3.0.1`) will not be considered. Lower versions will also not be considered.

Implementer notes: 

- It is an error if the minimum version specified for an application is not satisfied.
- `dotnet` binds to latest runtime patch version (within a given major.minor version family).

## Run from bin directory with dotnet myapp.dll

You can build and then run an application, essentially performing `dotnet run` as two separate steps, as seen in the following example:

``` console
dotnet build
dotnet bin\Debug\netcorapp2.0\myapp.dll
```

This scenario is an equivalence class for `dotnet run`.

## Run a published application with dotnet myapp.dll

You can publish an application to prepare it for distribution to other runtime environments, as seen in the following example:

``` console
dotnet publish -c release -o app
dotnet .\app\app.dll
```

This scenario is an equivalence class for `dotnet run`.

## Run a published application with the required runtime missing

You may run an application on a machine that is missing the runtime required by the application. If the required runtime is missing and a higher minor version is installed, the minor version should be used instead of failing to load the application. Higher major versions will not be used to load applications. This behavior shall be called "minor version roll-forward."

To illustrate this behavior, for an application requiring 2.0.4, `dotnet` would search and bind to a runtime in this order (picking the first it finds or showing error):

- 2.0.* (highest patch version; ensure that it satisfies 2.0.4 as a lower bound)
- 2.* (highest minor version)
- A helpful error message appears (see the message that follows)

> This application requires .NET Core 2.0.4. Please install .NET Core 2.0.4 or a higher compatible version.
> Please see https://aka.ms/install-dotnet-core to learn about .NET Core installation and runtime versioning.

A few usage examples may help to demonstrate the desired behavior:

- 2.0.4 is required. 2.0.5 is the highest patch version available. 2.0.5 is used.
- 2.0.4 is required. No 2.0.* versions are installed. 1.1.1 is the highest runtime installed. An error with a helpful error message is printed.
- 2.0.4 is required. No 2.0.* versions are installed. 2.2.2 is the highest 2.x runtime version installed. 2.2.2 is used.
- 2.0.4 is required. No 2.x versions are installed. 3.0.0 is installed. An error with a helpful error message is printed.

There is a trade-off for this behavior between compatibility and convenience. .NET Core minor versions are intended to be very compatible. It is therefore reasonable to choose the convenience experience without significant concern for compatibility breaks.

The following example is a somewhat unfortunate side-effect behavior of the algorithm that is important to realize:

- 2.0.4 is required. No 2.0.* versions are installed. 2.2.2 is installed. It is used.
- 2.0.5 is later installed. 2.0.5 will be used for subsequent application launches, not 2.2.2.
- It is possible that 2.0.5 and 2.2.2 might behave differently, particularly for scenarios like serializing binary data.

The treatment of NuGet dependencies needs to be understood as well. A given application might be built for .NET Core 2.0 but run on .NET Core 2.1 due to this algorithm. There may be later versions of an application's NuGet dependencies that target .NET Core 2.1. These later versions will not be considered or consulted. All NuGet dependencies should be already resolved as part of the published application layout, residing as assemblies (.dlls) in a flat directory structure. These assemblies should run on .NET Core 2.1 due to its compatibility promise for existing applications and binaries.

There are some scenarios where ASP.NET packages will be deployed via a web host rather than with a published application. In those cases, it is recommended that web hosters correctly configure their environments based on published guidance such that all supported ASP.NET applications run correctly.

Implementer notes: 

- Runtimes are searched for in the following order (the first found is loaded):
   - Highest patch version (check that the minimum runtime path version is satisfied, otherwise error)
   - Highest minor version 
- If an acceptable runtime is not found, then error.

## Publish a self-contained application

You can publish an application as a self-contained distribution. The advantage of this approach is that it includes .NET Core so does not require it is a dependency in runtime environments. As a result, runtime binding occurs at publishing time not run-time. 

There are multiple points of version binding to consider:

- Selecting an SDK
- Defining a target framework for the application
- Selecting a runtime to publish

The process of selecting an SDK and building an application is described earlier in the document.

The publishing process will select the latest patch version of the given runtime family. For example, `dotnet publish` will select .NET Core 2.0.4 if it is the latest patch version in the .NET Core 2.0 runtime family, independent of the existence of earlier patch versions or minimum runtime patch version values. This differs from `dotnet build` runtime selection for two reasons:

- The application doesn't need to align with a hosting environment.
- The developer is generating a final configuration for the application (that cannot be practically modified). The best runtime choice is the latest installed runtime patch version, both because that is the same version as was used for development and because it will have the latest (per the machine) security and reliability fixes.

Note that the runtimeframeworkversion element will override the default version policy if that element is present in the project file.

Implementer Notes:

- It is an error if the minimum version specified for an application is not satisfied.
- `dotnet publish` binds to latest runtime patch version (within a given major.minor version family).
- `dotnet publish` does not support the roll-forward semantics of `dotnet run`

## Publish an application with a specific .NET Core version

Developers can specify a .NET Core runtime version within a project file. That's convenient for developers because they typically work on one project at a time and typically edit project files, but not for CI/CD flows or human software deployers who manage many projects and who do not typically edit project files. Instead `dotnet publish` accepts a version to use for publishing for both self-contained and framework-dependent apps. One can imagine Visual Studio Team Systems offering a setting to specify a runtime version within a build configuration UI that affects publish without needing to update source code.

You can publish with the latest runtime patch version for the given target framework, by specifying `--latest`. This argument has the same default runtime binding behavior for publishing self-contained applications. You can see this usage in the following example:

``` console
dotnet publish -c release -o app --latest
```

You can publish with a specific runtime patch version for the given target framework, by specifying `--version=[version]`. It is an error if this version is missing. It is an error if the given version doesn't support the target framework (as a lower bound). It is acceptable to specify higher versions (even major versions), provided they exist on the machine. You can see this usage in the following example:

``` console
dotnet publish -c release -o app --version=3.1.0
```

Implementer notes:

- Runtime selection is overridden by the specific version provided.
- It is an error if this version is unavailable.
- It is an error if this version doesn't support the given target framework (as a lower bound).

## Determine latest Patch Versions

You may want to learn the latest patch version for a given target framework that is available (independent of what is installed on the machine). This command will make a network call and simply print a version, must like `dotnet --version` does today.

``` console
dotnet version --framework netcoreapp2.0 --latest
```

There are likely other changes that are coming for printing .NET Core versions. This command should align with these plans. The syntax above provides the general idea of the user experience.

Forward-looking: It should be easy to write scripts that determine if the latest patch version is installed, then installs it at the command-line if it is not.

## Open Issues

These issues are related but will be covered in another design document.

- Assembly loading
- Script loading, for example fsx and csx files. See [Runtime code generation using Roslyn compilations in .NET Core App](https://github.com/dotnet/roslyn/wiki/Runtime-code-generation-using-Roslyn-compilations-in-.NET-Core-App).

## Technical Details

This document takes some liberties, referring to `dotnet` as the version manager. From a user experience standpoint, this is true. From a technical standpoint, it is not. The version manager is implement in the following location, dependent on operating system:

```
~/dotnet/host/fxr/[version]/libhostfxr.dylib
```
