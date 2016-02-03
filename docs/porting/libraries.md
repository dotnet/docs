# Porting Libraries to .NET Core

blah blah some intro

## Prerequisites

Before you begin, understand that this article assumes that you are using Windows and Visual Studio.

It's recommended that you read the [Porting Overview](overview.md) article before you begin.  It will give you an idea of the journey you're about to embark on.

TODO: maybe some more prereqs?

## Getting your dependencies and .NET Framework APIs in check

The two biggest difficulties in porting libraries to .NET Core is resolving issues with 3rd party dependencies and .NET Framework APIs that aren't compatible with .NET Core.

If you haven't resolved issues with 3rd party dependencies, [please do so before continuing](LINK).

Next, make sure you [understand the API Portability tool](tooling.md) and can generate portability reports for targeting .NET Core.  You'll have to spend some time analyzing your assemblies and coming up with a plan for what to do with any incompatible types used.

Here's a set of guidelines for doing exactly that.

1. Understand where in the code each incompatible type is being used.

   a.  Understand the nature of the incompatible types.  Are they small in number, but used frequently?  Are they large in number, but used infrequently?  Is their use concentrated, or is it spread throughout your code?
   b. Is it easy to isolate code that's largely incompatible from code that's large compatible?
   c. Would you need to refactor your code so that you can deal with incompatible types better?

2. If you have assemblies that are mostly incompatible, is it worth leaving them on .NET Framework for now?  Note that this will depend heavily on the architecture of your system.

   a. You may have some functionality in your library that's incompatible with .NET Core because it relies too heavily on .NET Framework or Windows-specific functionality.  Is it worth leaving that functionality behind for now and releasing a .NET Core verson of your library with less features?
   b. WORK ON THIS WRITING

3. Are there alternative .NET Core APIs for incompatible .NET Framework APIs you're using?

   a. For example, if you're using `WebClient` you may be able to use `HttpClient` instead.
   b. You may also consider using a slightly different .NET Core API to do some work even if it isn't directly related.  For example, if you didn't require XML Schema discovery, you could use Linq to Xml to parse XML data instead of using XMLSchema to handle the parsing.
   
4. Is it reasonable to write some code a .NET Framework API was doing yourself?

   a. Consider modifying and using code from the [.NET Framework Reference Source](referencesource.microsoft.com).  It's licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt) so you have significant freedom in how to do this.
   
This analysis phase could take some time.  You may find that you'll have to refactor your code or make significant changes to how you perform certain tasks.  You may even come to the conlcusion that porting to .NET Core isn't feasible at this time.

## Choosing the project system and getting a basis for compilation

Once you have analyzed the ApiPort report and your codebase, the next step is to actually begin porting your code!

### Making a choice: xproj or Portable Class Library?

GAWD IT FEELS SO PAINFUL WRITING THIS

The first thing you'll need to do is decide on the project system you want to use.  You have two choices: `xproj` or `csproj` via a Portable Class Library (PCL).  Deciding which to pick comes down to one simple question:

Do you have any need to support anything more (e.g. localized resource strings)than just having Visual Studio recognize your project?

If yes, you will need to create a new PCL and select .NET Core as the target.  If you have no needs other than running your code in Visual Studio, you can select an xproj project type.

### Getting a basis for compilation

Once you've picked your project type and created a new Class Library, you'll notice that there's a new file: `project.json`.  This is the file that handles many things about your project - stating dependencies, configurations, supported target frameworks, etc. - and is used to generate a `project.lock.json` file that is used by the compiler and build system to build your project.  You can read more about `project.json` LINK_HERE.

You can see what it looks like by opening it up:

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

The most important thing to note is the version number for `NETStandard`.  This actually corresponds to a version number for the [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md), which is a standard by which you can make a clean tradeoff between API availability and target availability.  For example, if you wanted your .NET Core library to support Windows Phone targets, you would have to use `netstandard1.2`, which would cut off access to APIs available only in higher versions.

You should evaluate the API availability vs Target availability tradeoff you'd like to make and pick the version of `netstandard` that fits your needs the best.  You may find that the default version picked by the template is best for your needs!

The basic workflow with `project.json` is as follows:

TODO - make this make sense for both CLI and VS

1. You need to run `dotnet restore` to generate a `project.lock.json` the first time you create the project.
2. Any further changes to the `project.json` will require running a `dotnet restore` to generate a new `project.lock.json` file.
3. The `project.lock.json` file is what the compiler reads when you build your project.

Once you can build your .NET Core project(s) successfully, you can begin porting code over!

## Actually porting your code

Finally, porting the code itself!  Depending on how your .NET Framework code is structured, this could actually be the easiest part of porting over to .NET Core.  How you actually go about doing this will depend highly on the way your code is structured.

### Getting a testing framework for testing as you port

The best way to make sure everything works when you've ported your code is to *test your code as you port it to .NET Core*.  To do this, you'll need to use a testing framework that will build and run tests for .NET Core.  Currently, you have two options:

* Xunit
   - TODO: Instructions for Visual Studio
   - TODO: Instructions for .NET CLI
* Nunit
  - TODO: Instructions for Visual Studio
  - TODO: Instructions for .NET CLI

If you've been using Xunit or Nunit to write your tests for your library, great!  This shouldn't be much work.  However, if you've been using the built-in testing framework that ships with Visual Studio, you'll need to migrate your existing tests or write new tests in either Xunit or Nunit.

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

## Distributing via Nuget

TODO