# Overview of the Porting Process

If you're coming from .NET Framework you may be interested in running your code on .NET Core.  Before any process is outlined, it's helpful to take a step back and evaluate your reasons for wanting to port code to run on .NET Core.

## Should you port?

The first thing you need to do is evaluate if it makes sense to port .NET Framework code over to .NET Core in the first place.  .NET Core offers some attractive capabilities, such as:

- The ability to write a UWP app that will run on multiple Windows 10 devices
- Using ASP.NET Core to write great web apps and services which you can write and deploy on your OS of choice
- Console applications that can be Ahead-of-time compiled into native code with minimal dependencies

Your code could be a good candidate for porting to .NET Core if...

- Your code is a library and you want to expand its reach
- You have a business need to run code on more than just Windows
- You want to take advantage of app-local deployment and build self-contained console applications
- You have expertise on non-Windows platforms, such as great Linux sysadmins
- You're looking for an opportunity to implement an architectural change for your services (e.g. a monolithic service to microservices deployed to containers) or otherwise improve your codebase
- You love new technology and want to cut your teeth on .NET Core

Your code may not be a good candidate for porting if...

- Your code is heavily tied to a Windows GUI or depends entirely on Windows-specific features
- You have no business needs or expertise which would warrant running on more than Windows
- You don't have a need for app-local deployment or self-contained console apps at this time
- You're happy with your code running on .NET Framework as it is today

If it makes sense to port at this time, then read on!

## Analyze your 3rd party dependencies

The next step in porting any code over is to analyze your 3rd party dependencies for compatibility with .NET Core.  You'll need to have a contingency plan for any 3rd party dependency you have that doesn't run on .NET Core.

### Finding out if dependencies run on .NET Core (NuGet Packages)

If your 3rd party dependencies are NuGet packages, you can use the [NuGet Package Explorer](https://npe.codeplex.com) to inspect your packages.

1. Identify the names of all your NuGet dependencies.
2. Open the Nuget Package Explorer.
3. Click "Open a package from online feed". (screenshot)
4. Search for the name of a package in the search field and hit enter. (screenshot of result)
5. Expand the "lib" folder and look for a target subfolder that is compatible with .NET Core. (screenshot)

   **TODO**: Something with `dnxcore50`, `dotnet`, `netstandardlib`, ... is what you're looking for.
   
   If there isn't a target subfolder compatible with .NET Core, the dependency will not run on .NET Core.

6. Click `File > Open from Feed...` to search for another package.

Repeat steps 4-6 for each NuGet dependency you have, keeping note of any dependencies which will not run on .NET Core.

### Finding out if dependencies run on .NET Core (non-Nuget Packages)

TODO

### Dealing with dependencies which won't run on .NET Core

You may find yourself depending on a 3rd party code which won't run on .NET Core.  There are a few things you can do at this point.

1. Contact the author(s) and ask if they're planning to port to .NET Core or are already porting.  Perhaps you could help with the effort!

   TODO: NuGet contact form, Github, etc
   
2. Look for another library which accomplishes the same goal that does run on .NET Core.
3. Determine if it's feasible to write code that the library was doing yourself.

If you have incompatible 3rd party dependencies that you cannot resolve at this time, then you may have to port to .NET Core at a later date when those dependencies will also run on .NET Core.

## Next steps for porting

If you have determined that porting to .NET Core is a good idea and you don't have issues with incompatible 3rd party dependencies, you can begin the next step, which is running the API Portability Analyzer!

Find out about how to analyze your .NET Framework dependencies with the [API Portability Analyzer guide](apiport-guide.md).