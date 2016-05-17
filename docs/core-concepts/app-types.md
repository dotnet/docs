# Types of portability in .NET Core

## Introduction
There are several ways to think about the "types" of applications you can build. Usually, the types describe 
a certain execution model or are based on what the application can "do"; examples of these are "console application", 
"web application", etc. All of these types of applications (and more) can be created with .NET Core, since it is 
a general purpose development platform.

However, given its unique and cross-platform nature, .NET Core also has another angle through which to observe the type of the application 
and that is the application's *portability*. Portability essentially means where you can run your application and what 
prerequisites you need to satisfy in order for your application to run on a given machine.
This document deals with this angle, portability, and outlines the two main types of portability that .NET Core enables. 

There are two main types that we can observe: 

1. Portable application
    * As a subcategory of this, we have the portable application with native dependencies
2. Self-contained application

## Portable applications
Portable applications are the default type in .NET Core. They require .NET Core to be installed on the targeted machine 
in order for them to run. To you as a developer, this means that your application is portable between installations of 
.NET Core. 

This type of application will only carry its own code and dependencies that are outside of .NET Core libraries. 
As an example, let's say you are making a console application that has the ability to invoke a certain REST API 
and deserialize the returned JSON into a type and then display it. You have everything you need for this small 
application except for a good JSON parser; for this, you add a dependency to your `project.json` to include 
[Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/). Once you publish your application using `dotnet publish`, 
you will see that only your application's code and JSON.net have been published in the output. 
The .NET Core libraries remain outside of your application's dependency closure. 

In order to create a portable application, all you need to do is to target the .NET Core libraries in your `project.json`
and have your frameworks aligned as the below sample shows. 

```json
"dependencies": {
    "Microsoft.NETCore.App": {  
        "version": "1.0.0",
        "type": "platform"
    }
},
"frameworks": {
    "netcoreapp1.0": {}
}
```

The `Microsoft.NETCore.App` is a "metapackage" that states that you are targeting the .NET Core libraries. The `type: platform` 
property on that dependency means that at publish time, the tooling will skip publishing the assemblies for that dependency 
to the published output. You don't need these since they will be installed with .NET Core on the targeted machine. 

### Portable application with native dependencies
A subgroup of the above, this type is a portable application that has native dependencies specified 
somewhere in its dependency chain. This application is as portable as all of its native dependencies 
are portable. You will be able to run the application on any platform that your native dependencies can 
run on. Prime example of this is Kestrel, the ASP.NET Core cross-platform web server. It is built on top of 
[libuv](https://github.com/libuv/libuv) which is its native dependency. 

When you publish a portable application that has a native dependency, the published output will contain 
all the same things as the portable application described in the previous section. For native dependencies, 
the published output will contain a folder for each [Runtime Identifier (RID)](#what-are-rids) that the native dependency supports 
(and that exists in its NuGet package). 

The below `project.json` sample is showing an example of a portable application with a native dependency. 

```json
"dependencies": {
    "Microsoft.NETCore.App": {  
        "version": "1.0.0",
        "type": "platform"
    },
    "Microsoft.AspNetCore.Server.Kestrel": "1.0.0-*"
},
"frameworks": {
    "netcoreapp1.0": {}
}
```

## Self-contained application
Unlike the portable application, a *self-contained application* does not rely on any shared component to 
be present on the machine where you want to deploy the application. As its name implies, it means that 
the entire dependency closure, **including the runtime** is packaged with the application. This makes 
it larger, but also makes it capable of running on any .NET Core supported platforms with the correct 
native dependencies, whether it has .NET Core installed or not. This makes it that much 
easier to deploy to the target machine, since you only deploy your application. 

Since the application carries the runtime within itself, you need to make an explicit choice which platforms your application 
needs to run on. For instance, if you publish a self-contained application for Windows 10, that same application will 
not work on OS X or Linux and vice versa. Of course, you can add or remove platforms during development at any given time. 

There are several steps to get to a self-contained application. The first is to remove any `"type": "platform"` properties 
off of any dependencies you have. Second is to leave the dependency on `Microsoft.NETCore.App` as it will pull in
all of the rest of things that are needed. 

Finally, you need to add a `runtimes` node in your `project.json` that will list out the 
[RIDs](rid-catalog.md#what-are-rids) you wish to use. When restoring a project that has the `runtimes` node in it, NuGet 
will restore the needed runtime for all the RIDs specifies. Then, when you want to publish your application for a given platform,
you publish it using the `--runtime <RID>` argument to `dotnet publish`. The RID specified in the 
command invocation **has to be** an RID that is specified in your `project.json`; otherwise, an error is thrown. 

If you want to publish for the RID that represents the operating system you are using the [.NET Core SDK](core-sdk/index.md) 
on, you don't have to specify anything to `dotnet publish`. However, you still have to specify that RID in your 
`project.json` in order to get a standalone application. 

> One thing that is important to note is that in RC2 timeframe running and publishing a self-contained 
> application will happen from the NuGet packages cache on the machine. This means that the dependencies for the self-
>contained application will not be ready-to-run even if they come from .NET Core libraries, which means that performance 
> will not be the same between these two application types. This is in contrast with the 
> portable application, which, as far as the .NET Core libraries are concerned, runs on ready-to-run images. 

The following `project.json` sample illustrates a simple self-contained application. 

```json
"dependencies": {
    "Microsoft.NETCore.App": "1.0.0"
},
"frameworks": {
    "netcoreapp1.0": {}
},
"runtimes": {
    "win10-x64": {},
    "osx.10.11-x64": {}
}
```

