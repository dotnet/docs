# .NET Core Application Deployment concepts
.NET Core applications can be deployed in one of two ways:

1. As a portable shared framework application.
2. As a platform specific standalone application.

##  Shared framework applications
Shared framework applications take a dependency on the .NET Core shared framework being pre-installed on a machine.  As such they are deemed *portable* since the same application binaries can run on any machine that has the correct version of the shared framework installed.  Shared framework applications are `.dll` files that can be launched by calling `dotnet app.dll`.  Shared framework applications are the default type of application produced by `dotnet new`.

### Sample project
```
{
  "version": "1.0.0-*",
  "buildOptions": {
    "emitEntryPoint": true
  },
  "dependencies": {
    "Microsoft.NETCore.App": {
      "type": "platform",
      "version": "1.0.0"
    }
  },
  "frameworks": {
    "netcoreapp1.0": { }
  }
}
```
The part of this project that distinguishes it from a standalone application is the inclusion of `"type": "platform"` for the `Microsoft.NETCore.App` meta-package.  This tells NuGet that the `Microsoft.NETCore.App` is a platform package that will be provided by the system.  Another distinguishing factor is the lack of the `"runtimes"` section in the project.json.  This will cause NuGet to evaluate all platform specific bits in other packages and include them inside the application in platform specific subfolders.  At runtime the .NET Core host will choose the correct platform specific bits for the platform the app is running on.

## Standalone applications
Standalone applications take no dependency on .NET Core being preinstalled on a machine.  Instead they carry .NET Core with them as part of the application.  Since .NET Core contains platform specific native binaries standalone applications are platform specific themselves, though they may be published for multiple platforms.  Standalone applications consist of `app.exe`, a renamed version of the platform specific .NET Core host, and `app.dll` the actual application.

### Sample project
```
{
  "version": "1.0.0-*",
  "buildOptions": {
    "emitEntryPoint": true
  },
  "dependencies": {
    "Microsoft.NETCore.App": "1.0.0"
  },
  "frameworks": {
    "netcoreapp1.0": { }
  },
  "runtimes": {
    "win10-x64": {},
    "osx.10.10-x64": {}
  }
}
```
This project distinguishes itself from a shared framework application in that it does not reference any package with `"type": "platform"`.  Additionally, it can reference any combination of packages, so long as those include `Microsoft.NETCore.Runtime.CoreCLR` and `Microsoft.NETCore.DotNetHostPolicy`, the .NET Core runtime and .NET Core host respectively.  For example a minimal set of dependencies for "Hello World" is as follows:
```
  "dependencies": {
    "System.Console": "4.0.0",
    "Microsoft.NETCore.Runtime.CoreCLR": "1.0.2",
    "Microsoft.NETCore.DotNetHostPolicy":  "1.0.1"
  }
```
Another distinction between a standalone application and a shared framework application is that the standalone application lists the set of `runtimes` that it intends to publish for.  This instructs NuGet to download and resolve the platform specific packages that are part of .NET Core to include with the application.

# Publishing
Publishing a .NET Core application produces a file layout for the application that can be used to run the application on another machine.  Typically you will do this step as part the build process before building an installer for your application or deploying your application to production.

## Publishing a Shared Framework application
To publish a shared framework application use the following command: `dotnet publish -f netcoreapp1.0 -c release`.  This will publish the release build of the application to a subdirectory under the output folder named `bin/release/netcoreapp1.0/publish`.  You can control the output path using the `-o` parameter.  To deploy the debug configuration use `-c debug` or simply omit the `-c` option.  The `-f netcoreapp1.0` may be omitted if that is the only entry in your project's `"frameworks"` section.

## Publishing a standalone application
To publish a standalone application use the following command: `dotnet publish -f netcoreapp1.0 -r osx.10.10-x64 -c release`.  This will pulbish the release build of the application to a subdirectory under the output folder named `bin/release/netcoreapp1.0/osx.10.10-x64/publish`.  Similarly, options may be omitted to choose the defaults.

# Deploying


# Execution
