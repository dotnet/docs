
# Porting Libraries to .NET Core

By [Phillip Carter](https://github.com/cartermp)

Libraries are some of the most natural projects to port from .NET Framework to .NET Core.  This article will cover all of the steps you'll need to take to get to the point where you can focus on your code.  It will cover the following:

- Picking the correct .NET Platform Standard for your library
- Understanding the basics of the .NET Core project model
- If applicable, retargeting your code to .NET Framework 4.6.1
- Determining the portability of your code
- Picking a the correct project system in Visual Studio based on your needs
- Porting your tests
- Recommended approach for porting your code

It's quite a lot of content, but porting is a complex task that will take some time.  You should also be prepared to adapt the guidance here as needed to best fit your code.  Every code base is different, so this article will attempt to frame things in a flexible way, but you may find yourself needing to diverge from the prescribed guidance.  For example, it may just be easiest for some projects to copy the code over into a .NET Core project and work out the compiler errors.  Such decisions should be made at your discretion.  Let's begin.

## Prerequisites

This article will be using Visual Studio 2015 on Windows, both of which are necessary for building .NET Core projects in Visual Studio.

This article also assumes that you have understood the [overview of the porting process](overview.md) and that you have resolved any issues with [3rd party dependencies](third-party-deps.md).  If you haven't done this already, it's highly recommended that you do that before moving forward.

## Targeting the .NET Platform Standard

The first thing to understand about porting a library to .NET Core us that you must target a version of the [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).  In fact, it's accurate to think that targeting .NET Core means targeting a version of the .NET Platform Standard.

Long story short, this means that you'll have to make a tradeoff between APIs you can use and platforms you can support, and pick the version of the .NET Platform standard that best suites the tradeoff you wish to make.

As of right now, there are 6 different versions to consider: .NET Platform Standard 1.0 through 1.5.  If you pick a higher version, you get access to more APIs at the cost of running on less targets.  If you pick a lower version, your code can run on more targets but at the cost of less APIs.

A key thing to understand is that **a project targeting a lower version cannot reference a project targeting a higher version**.  To put this in concrete terms, a project targeting the .NET Platform Standard version 1.2 cannot reference projects that target .NET Platform Standard version 1.3 or higher.  Projects **can** reference lower versions, though, so a project targeting .NET Platform Standard 1.3 can reference a project targeting .NET Platform Standard 1.2 or lower.

It's recommended that you pick a single .NET Platform Standard version and use that throughout your library.

Read more in [The .NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).

## .NET Core project model overview

.NET Core introduces a new project model that you may wish to spend some time understanding before you begin porting your code.  Rather than provide a comparison with the .NET Framework project model, this section will cover the essential pieces.

### The project file: `project.json`

**TODO** info about `project.json`, how you fit your `netstandard` TFM in, generates `project.lock.json`, etc.

### The solution file: `global.json`

**TODO** info about `global.json` and how you can use it for multiple projects

## Targeting your code for .NET Framework 4.6.1

If your code is not targeting .NET Framework 4.6.1, it's highly recommended that you retarget.  This ensures that you can use API alternatives for cases where .NET Core can't support existing APIs.

For each of your projects in Visual Studio you wish to port, do the following:

1. Right-click on the project and select Properties
2. In the "Target Framework" dropdown, select ".NET Framework 4.6.1".
3. Recompile your projects.

And that's it!  Because your projects now target .NET Framework 4.6.1, you can use that version of .NET Framework as your base for porting code.

## Determining the portability of your code

The next step is to run the API Portability Analyzer to generate a portability report that you can begin to analyze.

You'll need to make sure you [understand the API Portability tool](tooling.md) and can generate portability reports for targeting .NET Core.  How you do this will likely vary based on your needs and personal tastes.  What follows are a few different approaches - you may find yourself mixing each approach depending on how your code is structured.

### Dealing primarily with the compiler

This approach may be the best for small projects or projects which don't use many .NET Framework APIs.  The approach is very simple:

1. Run API Port on your project.
2. Take a quick glance and perhaps use the report as a reference for future errors.
3. Copy all of your code over into a new .NET Core project.
4. Work out compiler errors until it compiles, referring to the portability report if needed.
5. Repeat as needed.

Although this approach is very unstructured, the code-focused approach can lead to resolving any issues quickly, and may be the best approach for smaller projects or libraries.  A project that contains only data models may be an ideal candidate here.

### Staying on .NET Framework until portability issues are resolved

This approach may be the best if you prefer to have code that compiles during the entire process.  The approach is as follows:

1. Run API Port on a project.
2. Address issues by using different APIs which are portable.
3. Keep note of any areas where you can't use a direct alternative.
4. Repeat steps 1-3 for all projects you're porting until you're confident each is ready to be copied over into a .NET Core project.
5. Copy the code into a new .NET Core projects.
6. Work out any issues that you've kept note of.

This approach is a bit more careful and structured than simply working out compiler errors, but it is still relatively code-focused and has the benefit of always having code that can compile.  The way you resolve certain issues that couldn't be addressed by just using another API can vary greatly.  You may find that you need to develop a more comprehensive plan for certain projects, which is covered as the next approach.

### Developing a comprehensive plan of attack

This approach may be best for larger and more complex projects, where restructuring of code or rewriting certain areas may be necessary to support .NET Core.  The approach is as follows:

1. Run API Port on a project.
2. Understand where in your code each non-portable type is being used and how that affects overall portability.

   a.  Understand the nature of those types.  Are they small in number, but used frequently?  Are they large in number, but used infrequently?  Is their use concentrated, or is it spread throughout your code?
   
   b. Is it easy to isolate code that isn't portable so you can deal with it easier?
   
   c. Would you need to refactor your code?
   
   d. For these types which aren't portable, are there alternative APIs that accomplish the same task?  For example, if you're using `WebClient`, you may be able to use `HttpClient` instead.
   
   e. Are there different portable APIs you can use to accomplish a task, even if it's not a drop-in replacement?  For example, if you're using `XmlSchema` to help parse XML but you don't require XML schema discovery, you could use Linq to XML APIs and hand-parse the data.

3. If you have assemblies that are difficult to port, is it worth leaving them on .NET Framework for now?

   a. You may have some functionality in your library that's incompatible with .NET Core because it relies too heavily on .NET Framework- or Windows-specific functionality.  Is it worth leaving that functionality behind for now and releasing a .NET Core version of your library with less features for the time being?
   
   b. Would a refactor help here?
   
4. Is it reasonable to write some code a .NET Framework API was doing yourself?

   a. You could consider copying, modifying, and using code from the [.NET Framework Reference Source](https://github.com/Microsoft/referencesource).  It's licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt) so you have significant freedom in doing this.  Just make sure to properly attribute Microsoft in your code!
   
5. Repeat this process as needed for different projects.
6. Once your have a plan, execute that plan.
 
The analysis phase could take some time depending on how large your codebase is.  But that's okay!  Spending time in this phase to thoroughly understand the scope of changes needed and to develop a plan can save you a lot of time in the long run, particularly if you have a more complex codebase.

Your plan could involve making significant changes to your codebase while still targeting .NET Framework 4.6.1, making this a more structured version of the previous approach.  How you go about executing your plan will be dependent on your codebase.

### Mixing approaches

It's likely that you'll mix the above approaches on a per-project basis.  You should do what feels the most natural to you and your codebase.

## Picking your project system in Visual Studio: xproj or csproj

In addition to a new project model, .NET Core introduces a new project system, xproj, in Visual Studio.  You'll have to pick the correct project system based on your needs.

### When to pick xproj

**TODO**

### When to pick csproj

**TODO** - also mention bait and switch PCLs

## Porting your tests (if applicable)

The best way to make sure everything works when you've ported your code is to *test your code as you port it to .NET Core*.  To do this, you'll need to use a testing framework that will build and run tests for .NET Core.  Currently, you have two options:

* [xUnit](https://xunit.github.io/)
   - [Getting Started](http://xunit.github.io/docs/getting-started-dnx.html)
   - [Tool to convert an MSTest project to xUnit](https://github.com/dotnet/codeformatter/tree/master/src/XUnitConverter)
* [NUnit](http://www.nunit.org/)
  - [Getting Started](https://github.com/nunit/docs/wiki/Installation)
  - [Blog post about migrating from MSTest to NUnit](http://www.florian-rappl.de/News/Page/275/convert-mstest-to-nunit)
  
Currently, MSTest does not run on .NET Core.  If you're using MSTest, you'll have to migrate.  If you've been using Xunit or Nunit to write your tests for your library, great!

## Recommended approach to porting

Finally, porting the code itself!  Ultimately, the actual porting effort will depending heavily on how your .NET Framework code is structured.  That being said, here is a recommended approach which may work well with your codebase.

A good way to port your code is to begin with the "base" of your library.  This may be data models or some other foundational classes and methods that everything else uses directly or indirectly.

1. Copy over the "base" of your library into the new .NET Core project and select the version of the .NET Platform Standard you wish to support.
2. Make any changes needed to get the code to compile.

   a. Much of this may just require adding NuGet package dependencies to your `project.json`.
   
   b. It may helpful to comment out old code as you slowly get things compiling.
   
3. Port over any old tests which consume what you've just ported.

   a. If you're using an aditional testing library that doesn't run on .NET Core, you may have to rewrite some tests or go forward without tests temporarily.
   
   b. Run or rewrite tests as needed.
   
4. Pick the next layer of code to port over and repeat steps 2 and 3!

If you methodically move "out" from the "base" of your library, testing each layer as needed, you shouldn't run into unexpected issues.

## Next Steps

If you want to distribute through NuGet, read about that in [Porting NuGet Packages](nuget-packages.md).
