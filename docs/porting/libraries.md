# Porting Libraries to .NET Core

Libraries are one of the best areas to port code over to .NET Core.  

## Prerequisites

This article will be using Visual Studio on Windows.

It's recommended that you read the [Porting Overview](overview.md) article before you begin.  It will give you an idea of the journey you're about to embark on.

## Getting your dependencies and .NET Framework APIs in check

The two biggest difficulties in porting libraries to .NET Core is resolving issues with 3rd party dependencies and .NET Framework APIs that are unavailable on .NET Core.

If you haven't resolved issues with 3rd party dependencies, [please do so before continuing](overview.md).

Next, make sure you [understand the API Portability tool](tooling.md) and can generate portability reports for targeting .NET Core.  You'll have to spend some time analyzing your assemblies and coming up with a plan for what to do with any unavailable APIs.

Here's a set of guidelines and questions you may find helpful.

1. Understand where in your code each incompatible type is being used.

   a.  Understand the nature of the incompatible types.  Are they small in number, but used frequently?  Are they large in number, but used infrequently?  Is their use concentrated, or is it spread throughout your code?
   
   b. Is it easy to isolate code that's largely incompatible from code that's largely compatible?
   
   c. Would you need to refactor your code so that you can deal with incompatible types better?

2. If you have assemblies that are mostly incompatible, is it worth leaving them on .NET Framework for now?  Note that this will depend heavily on the architecture of your system.

   a. You may have some functionality in your library that's incompatible with .NET Core because it relies too heavily on .NET Framework or Windows-specific functionality.  Is it worth leaving that functionality behind for now and releasing a .NET Core version of your library with less features for the time being?

3. Are there alternative .NET Core APIs for incompatible .NET Framework APIs you're using?

   a. For example, if you're using `WebClient` you may be able to use `HttpClient` instead.
   
   b. You may also consider using a slightly different .NET Core API to do some work even if it's not a drop-in replacement.  For example, if you don't require XML Schema discovery, you could use Linq to Xml to parse XML data instead of using XMLSchema to handle the parsing.
   
4. Is it reasonable to write some code a .NET Framework API was doing yourself?

   a. Consider modifying and using code from the [.NET Framework Reference Source](https://github.com/Microsoft/referencesource).  It's licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt) so you have significant freedom in doing this.
   
This analysis phase could take some time depending on how large your codebase is.  But that's okay!  Spending time in this phase to understand the scope of changes and develop a plan will save you a lot of time in the long run.

## Choosing the project system and getting a basis for compilation

Once you have analyzed the ApiPort report and your codebase, the next step is to actually begin porting your code!

### Making a choice: xproj or Portable Class Library?

**TODO** change this section entirely.  There also needs to be a mention of bait and switch PCLs for people who have the need for a `csproj` and want to use target-specific APIs for some of their targets.  Include how you can use the command line if you don't want to use Visual Studio to generate the files you need (or not?).

The first thing you'll need to do is decide on the project system you want to use.  You have two choices: `xproj` or `csproj` via a Portable Class Library (PCL).  Deciding which to pick comes down to one simple question:

Do you have any need to support anything more than just having Visual Studio recognize your project?  Examples of this may be localized resources in a `.resx` folder, working seamlessly with a custom build process, and others.

If yes, you should create a new PCL and select .NET Core as the target.  If you have no needs other than building and running your code in Visual Studio, you can select an xproj project type.

### Getting a basis for compilation

Once you've picked your project type and created a new Class Library, you'll notice that there's a new file: `project.json`.  Here's the essentials you need to know about `project.json`:

1. It is the place where you state your dependencies, set configuration settings, specify each target to compile against, and more.

   In Visual Studio, you can right-click the project and select "Restore Packages".
   
   If you're using the .NET CLI, you'll need to navigate to the project folder and type:
   
   `> dotnet restore`
   
   Any time you change your `project.json` file, you'll have to restore again.
   
2. When you restore, it downloads packages (or grabs them from a cache) and generates a new file: `project.lock.json`.

   This file is what's used by the compiler and build system to build your project.  It contains details such as the exact location of each package used, among other things.

To learn more details about `project.json` and `project.lock.json`, please refer to [the documentation] on the topic.

When you create a new class library, you can see what the `project.json` looks like by opening it up:

```javascript
{
    "version":"1.0.0-*",
    
    "dependencies":{
        "NETStandard.Library":"1.0.0-rc2-23728"
    },
    
    "frameworks":{
        "netstandard1.4"
    }
}
```

The most important thing to note is the version number for `netstandard` under the `frameworks` section.  This actually corresponds to a version number for the [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md), which is a standard by which you can make a clean tradeoff between API availability and target availability.  For example, if you wanted your .NET Core library to support Windows Phone targets, you would have to use `netstandard1.2`, which would cut off access to APIs available only in higher versions.

**TODO** Put some better explanation here about making the tradeoff?

You should evaluate the API availability vs Target availability tradeoff you'd like to make and pick the version of `netstandard` that fits your needs the best.  You may find that the default version picked by the template is best for your needs!

Once you can build your .NET Core project(s) successfully, you can begin porting code over!

## Actually porting your code

Finally, porting the code itself!  Here are some recommended approaches that will be covered next.  Ultimately, the actual porting effort will depending heavily on how your .NET Framework code is structured.  

### Getting a testing framework for testing as you port

**TODO** Get the story straight about MSTEST!

The best way to make sure everything works when you've ported your code is to *test your code as you port it to .NET Core*.  To do this, you'll need to use a testing framework that will build and run tests for .NET Core.  Currently, you have two options:

* xUnit
   - TODO: Instructions for Visual Studio
   - TODO: Instructions for .NET CLI
* NUnit
  - TODO: Instructions for Visual Studio
  - TODO: Instructions for .NET CLI

**TODO** mention xUnit porting tool

If you've been using Xunit or Nunit to write your tests for your library, great!  This shouldn't be much work.  However, if you've been using the MSTest framework that ships with Visual Studio, you'll need to migrate your existing tests or write new tests in either Xunit or Nunit.

### Recommended Approach

A good way to port your code is to begin with the "base" of your library.  This may be data models or some other foundational classes and methods that everything else uses directly or indirectly.

1. Copy over the "base" of your library into the new .NET Core project.
   a. Rename the namespaces if you wish to have both .NET Core and .NET Framework projects.
2. Make any changes needed to get the code to compile.
   a. Much of this may just require adding NuGet package dependencies to your `project.json`.
   b. It may helpful to comment out old code as you slowly get things compiling.
3. Port over any old tests which consume what you've just ported.
   a. If you're using an aditional testing library that doesn't run on .NET Core, you may have to rewrite some tests or go forward without tests temporarily.
   b. Run or rewrite tests as needed.
4. Pick the next layer of code to port over and repeat steps 2 and 3!

If you methodically move "up" from the "base" of your library, testing each layer as needed, you shouldn't run into unexpected issues.

## Creating and Distributing a NuGet Package

Creating a NuGet package from your library is fairly simple to do!  You have three options:

- .NET CLI tooling across all platforms
- NuGet command line client on Windows
- NuGet Package Explorer GUI on Windows

### Creating a package using CLI Tooling

First, you'll need to generate release assemblies and a `nuspec` folder.  Navigate to the root of your project and type the following into your command line of choice:

```> dotnet pack --release```

And that's it!  You'll now have a `/Release` folder created, which will contain a `nuspec` file and any assemblies you need.  There may also be assemblies placed in different subfolders if you are multitargeting.

You may have more complex needs for your `nuspec` file.  Refer to the [NuSpec reference](http://docs.nuget.org/create/nuspec-reference) for what you may need to change.

### Creating a package using NuGet command line client

**TODO** Show basic usage and refer to other docs for advanced stuff.  Reiterate that this works only on Windows.

### Creating a package using Nuget Package Explorer

**TODO** Show basic usage and refer to other docs for advanced stuff.  call out that you can't automate this

### Distributing

**TODO**  discuss any distribution info as it pertains to a library