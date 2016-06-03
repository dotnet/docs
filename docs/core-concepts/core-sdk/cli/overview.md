# .NET Core Command Line Tools (CLI)

## What is the .NET CLI?
.NET Core Command Line Interface is a new foundational cross-platform toolchain for developing 
.NET Core applications. It is "foundational" because it is the primary layer on which other, 
higher-level tools, such as Integrated Development Environments (IDEs), editors and 
build orchestrators can build on. 

It is also cross-platform by default and has the same surface area on each of the supported platforms. This means that
when you learn how to use the tooling, you can use it the same way from any of the supported platforms. 

## Installation
As with any tooling, the first thing is to get the tools to your machine. Depending on your scenario, you can either 
use the native installers to install the CLI or use the installation shell script.

The native installers are primarily meant for developer's machines. The CLI is distributed using each supported platform's 
native install mechanism, for instance DEB packages on Ubuntu or MSI bundles on Windows. These installers will install 
and set up the environment as needed for the user to use the CLI immediately after the install. However, they also 
require administrative privileges on the machine. You can view the installation instructions on the
[.NET Core getting started page](https://aka.ms/dotnetcoregs).

Install scripts, on the other hand, do not require administrative privileges. However, they will also not install any 
prerequisites on the machine; you need to install all of the prerequisites manually. The scripts are meant mostly for 
setting up build servers or when you wish to install the tools without administrative privileges (do note the prerequisites 
caveat above). You can find more information on the [install script reference topic](dotnet-install-script.md). If you are 
interested in how to set up CLI on your continuous integration (CI) build server you can take a look at the 
[CLI with CI servers](using-ci-with-cli.md) document. 

By default, the CLI will install in a side-by-side (SxS) manner. This means that multiple versions of the CLI tools 
can coexist at any given time on a single machine. How the correct version gets used is explained in more detail in 
the [driver section](#driver) below. 

### What commands come in the box?
The following commands are installed by default:

* [new](dotnet-new.md)
* [restore](dotnet-restore.md)
* [run](dotnet-run.md)
* [build](dotnet-build.md)
* [test](dotnet-test.md)
* [publish](dotnet-publish.md)
* [pack](dotnet-pack.md)

There is also a way to import more commands on a per-project basis as well as to add your own commands. This is 
explained in greater detail in the [extensibility section](#extensibility). 

## Working with the CLI

### A short sample
Before we go into any more details, let's see how working with the CLI looks like from a 10,000-foot view. 
The sample below utilizes several commands from the CLI standard install to initialize a new simple console application, 
restore the dependencies, build the application and then run it. 

```console
dotnet new
dotnet restore
dotnet build --output /stuff
dotnet /stuff/new.dll
```

### How does it work?
As we saw in the short sample [above](#a-short-sample), there is a pattern in the way you use the CLI tools. Within that pattern, we can 
identify three main pieces of each command:

1. The driver ("dotnet")
2. The command, or "verb"
3. Command arguments

Let's dig into more details on each of the above.

### Driver
The driver is named `dotnet`. It is the first part of what you invoke. The driver has two responsibilities:

1. Executing IL code
2. Executing the verb

Which of the two things it does is dependent on what is specified on the command line. In the first case, you would 
specify an IL assembly that `dotnet` would run similar to this: `dotnet /path/to/your.dll`. 

In the second case, the driver attempts to invoke the specified command. This will start the CLI command execution 
process. First, the driver will determine the version of the tooling that you want. You can specify the version in the 
`global.json` file using the `sdkVersion` property. If that is not available, the driver will find the latest version
of the tools that is installed on disk and will use that version. Once the version is determined, it will execute the 
command. 

### The "verb"
The verb is simply a command that performs an action. `dotnet build` will build your code. `dotnet publish` will publish 
your code. The verb is implemented as a console application that is named per convention: `dotnet-{verb}`. All of the 
logic is implemented in the console application that represents the verb. 

### The arguments
The arguments that you pass on the command line are the arguments to the actual verb/command being invoked. 
For example, when you type `dotnet publish --output publishedapp` the `--output` argument is passed to the 
`publish` command. 

## Types of application portability
CLI enables applications to be portable in two main ways:

1. Completely portable application that can run anywhere .NET Core is installed
2. Self-contained applications

You can learn more about both of these in the [application types overview](../../app-types.md) topic. 

## Migration from DNX
If you used DNX in RC1 of .NET Core, you may be wondering what happened to it and how do these new tools
relate to the DNX tools. In short, the DNX tools have been replaced with the .NET Core CLI tools in RC2. 
If you have existing projects or are just wondering how the commands map, you
can use the [DNX to CLI migration document](../../dnx-migration.md) to get all of the details. 

## Extensibility
Of course, not every tool that you could use in your workflow will be a part of the core CLI tools. However, .NET Core 
CLI has an extensibility model that allows you to specify additional tools for your projects. You can find out more 
in the [extensibility document](extensibility.md). 

## More resources
This was a short overview of the most important features of the CLI. You can find out more by using the reference and 
conceptual topics on this site. There are also other resources you can use:

* [GitHub repo](https://github.com/dotnet/cli/)
* [Getting Started instructions](https://aka.ms/dotnetcoregs/)

