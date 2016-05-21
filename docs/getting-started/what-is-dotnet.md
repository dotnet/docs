# What is the .NET Core Platform?

.NET Core is a modular, cross-platform, open source implementation of the .NET Framework that runs on Windows devices, as well as on Linux and OS X. Unlike the .NET Framework, which is a monolithic, system-wide, Windows-only runtime environment, .NET Core can be used to create componentized libraries and applications that can target multiple platforms and that can be deployed along with the application itself. 

# .NET Core Features #

Let's take a high-level view of some of the features that .NET Core makes available. 

## Cross-Platform Support ##

.NET Core apps can run on both the 32-bit and 64-bit Windows platforms, as well as on OS X and Linux.

In contrast, apps that target the full .NET Framework can run only on Windows. And UWP apps, which use an implementation of .NET Core, can run only on Windows desktop and tablets, and Windows Phone.

## Open Source ##
 
.NET Core -- both its runtime and its class libraries -- are open source. In addition to making the source code for .NET Core freely available, this means that:

- Design notes, feature specifications, and implementation-specific documentation is publicly available. 

- Code reviews of .NET Core features are public.

- By using GitHub's pull request model, you can open bugs, suggest modifications to source code, and submit new feature requests and source code.

- You can download all of the source code and build it on your own system. The .NET Framework libraries, the runtime, and .NET Framework tools can be built on any of the supported platforms (that is, on Windows x86/x64, OS X, and Linux). 

## Console Apps ##

The .NET Framework on the Windows desktop allows you to create console apps, and so does .NET Core. But .NET Core reinvigorates the console application:

- Cross-platform: Console apps can run on Windows, OS X, and Linux.

- Native compilation. This combines the benefits of a managed app with the performance of a native C/C++ app. 

## Ease of Installation ##

Because .NET Core is not an operating system component, installation:   

- Does not require administrator privileges.

- Does not touch system components like operating system directories or, on Windows systems, the Windows Registry.

- Is as simple as copying some files to a directory on the target computer or compiling the framework natively into the app.

New developers can get started developing for .NET in under one minute, including downloading the frameworks and tools. You can install .NET Core from the [.NET Core getting started page](https://dotnet.github.io/getting-started/#/windows ".NET Core getting started page"). 

## Ease of Deployment ##

Ordinarily, when you install an app that targets the .NET Framework on the desktop, you also should check which version of the .NET Framework is installed and, if the base version that your app requires is not present, chain to a .NET Framework installation routine. 

In contrast, .NET Core has two deployment models:

### Portable Apps ###
  
When deploying a portable app, you deploy only your app and any of its dependencies other than the .NET Core libraries. A portable app requires that .NET Core is installed on the target machine in order for it to run. Because .NET Core is an independent component, you do not need to determine in advance which platforms your app supports. Portable apps are the default app type in .NET Core. 

### Self-contained Apps ###

Self-contained apps include all of their dependencies, including the .NET Core runtime, as part of the app. Because .NET Core is local to your app, it can run on any supported platform whether .NET Core is installed on it or not, and the .NET libraries that your app uses are isolated from .NET Core libraries used by other apps. This requires, however, that you determine the target platforms that your app supports in advance.

# .NET Core Components #

Very much like the .NET Framework on the Windows desktop, .NET Core consists of a common language runtime, which in .NET Core is named CoreCLR. .NET Core also features an extensive class library. Rather than a single .NET Framework Class Library, however, .NET Core features CoreFX, a modular collection of libraries. This allows you to include the libraries that your app needs without the overhead of including those that you don't need.
   
## The Common Language Runtime ##

CoreCLR, or the common language runtime found in .NET Core, is a lightweight runtime that offers many of the same services as the .NET Framework's common language runtime on the Windows desktop. These include:

- A garbage collector, which provides automatic memory management. The garbage collector allocates and frees memory as needed; you do not have to do it programmatically. .NET Core uses the same garbage collector as the .NET Framework. For more information, see [Garbage Collection](https://msdn.microsoft.com/en-us/library/0xy59wtx(v=vs.110).aspx "Garbage Collection"). 

- A just-in-time (JIT) compiler, which compiles IL, or .NET intermediate language, to native machine code at runtime. On some architectures, the JIT compiler includes support for SIMD hardware acceleration.

- An exception handling mechanism, which allows you to handle exceptions with try/catch statements.   

##The Class Library 

The class library available in .NET Core is very much like the .NET Framework Class Library for the Windows desktop, with one major difference. On the Windows desktop, it is a monolithic library that is part of the operating system and is maintained by Windows Update. On .NET Core it is a modular and factored collection of individual libraries organized by functionality. 

Microsoft.NetCore.App is included with the runtime and contains the basic types needed for all app development. Some of these include:

-  Primitives, such as the Boolean type, signed and unsigned integral types, floating-point types, and the Char structure.

- The String type. A string in .NET Core is a sequence of UTF-16 code units. .NET Core also includes a number of encoding types that let you convert UTF-16 encoded strings to an array of bytes in other encodings. For example, you can use the [UTF8Encoding class](https://dotnet.github.io/api/System.Text.UTF8Encoding.html "UTF8Encoding class") to convert a .NET Core string to a UTF-8 encoded byte array that represents a string on Linux.  
  
-  General-purpose exception classes, such as the ArgumentException, ArgumentNullException, and NullReferenceException types.

- The task types, such as [Task](https://dotnet.github.io/api/System.Threading.Tasks.Task.html "Task") and [Task&lt;T&gt;](https://dotnet.github.io/api/System.Threading.Tasks.Task%601.html "Task&lt;T&gt;"), to support asynchronous programming.

- Basic threading types.

- The [Console class](https://dotnet.github.io/api/System.Console.html "Console class"), to support the development of console apps. 

Other libraries are installed as [NuGet](http://www.nuget.org/ "NuGet") packages

## .NET Core Tools ##

.NET Core includes a new cross-platform command-line SDK known as the .NET Core CLI (for Command-Line Interface). The CLI is a UNIX-friendly set of tools for building .NET Core app that abstracts the C# compiler and the NuGet package manager. It can also integrate with the .NET Native tool chain to produce high-performance native apps and libraries. The CLI allows developers to build and test apps with a minimal installation on developer, lab, or production machines. Since some IDEs, such as Visual Studio Code and Visual Studio, use the CLI under the covers, you can now choose the level of interaction with the tool chain. For example, you can work with the CLI directly by using an editor that uses the CLI; or you can develop with an IDE that uses the CLI internally.  

For the most part, you use the .NET Core CLI directly by providing a command-line argument to  `dotnet.exe`. The following are some of the commands supported by `dotnet.exe`:

- `dotnet --help` : Displays information about .NET Core CLI commands

- `dotnet new` : Initializes a new C# project

- `dotnet new --lang F#` : Initializes a new F# project.
 
- `dotnet restore` : Restores the dependencies for an app.

- `dotnet build` : Builds a .NET Core app.

- `dotnet publish` : Publishes a .NET portable or self-contained app. (See the "Ease of Deployment" section below. 

- `dotnet run` : Runs the app from its source code. 

- `dotnet pack` : Creates a NuGet package of your code.    

`dotnet.exe` also has an extensibility model that lets you add additional commands. 

## Language Support and Development Environments ##

.NET Core is language agnostic: any programming language that targets .NET Core can be used to develop .NET Core apps, and an app that targets .NET Core and is written in one programming language can seamlessly access types and members in .NET Core libraries that were developed by using a different programming language. 
 
You can currently develop .NET Core apps in either of two languages:

- C#, which is based on the [.NET Compiler Platform](https://github.com/dotnet/roslyn "Roslyn Compiler Platform"), also known as Roslyn. 

- [F#](https://channel9.msdn.com/Events/Build/2016/T661 "F#").
 
We plan to support additional languages in the future. 

You have a wide choice of development environments for writing your app, including:

- A simple text editor, such as Notepad or WordPad on Windows. 

- A programmer's editor, such as [Visual Studio Code](https://code.visualstudio.com/ "Visual Studio Code") with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp "C# Extension").

- An integrated development, debugging, and testing environment, such as [Visual Studio 2015 Update 2](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx "Visual Studio 2015 Update 2").   


# .NET Core and the .NET Framework #

To get a better sense of what .NET Core is, let’s compare it to the .NET Framework 4.x:

<table>
<col style="width:50%">
<col style="width:50%">
<thead>
   <tr>
      <th>.NET Core</th>
      <th>.NET Framework 4.x</th>
   </tr>
</thead>
<tr>
<td>Includes CoreCLR, a more lightweight runtime that provides basic services to your app, particularly automatic memory management and garbage collection, along with a basic type library.</td>
<td>Includes the common language runtime (CLR), a sizeable runtime that provides memory management, isolation by application domain, and a host of other application services. </td>
</tr>
<tr>
<td>Includes CoreFx, a set of individual modular assemblies that you can add to your app as needed. Unlike the .NET Framework 4.x, which always makes the entire .NET Framework Class Library available, you can select only the assemblies that you need. For example, if you are developing a vector-based app, you can download the System.Numerics.Vectors package without the overhead of a large class library. This significantly reduces the size of your app and its dependencies.
</td>
<td>Includes the .NET Framework Class Library, a large, monolithic library with thousands of classes and many thousands of members. Whether or not your app uses individual types and their members (and most apps take advantage of only a small portion of the .NET Framework's functionality), they are always present and accessible. 
</td>
</tr>
<tr>
<td>Is suitable for a full range of modern apps, including apps that operate on small devices with constrained memory and storage.
</td>
<td>Is suitable for developing traditional Windows desktop apps, including Windows Forms (WinForms) and Windows Presentation Foundation (WPF) apps.
</td>
</tr>
<tr>
<td>Can be used to develop apps that take advantage of a number of technologies, such as ASP .NET Core, for building web apps; Windows Communication Foundation (WCF), for building apps that communicate with existing WCF services; and Workflow Foundation (WF), for building workflows. 
</td>
<td>Can be used to develop apps that take advantage of a number of technologies, such as ASP .NET and ASP.NET Web Forms, for building web apps; Windows Communication Foundation (WCF), for building services, including SOAP; and Workflow Foundation (WF), for building workflows. 
</td>
</tr>
<tr>
<td>Can be app local. That is, the .NET Core implementation that your app relies is tightly bound to your app. This mitigates versioning problems.
</td>
<td>Is globally available on a given system. That is, although an app can include a chain installer that installs a particular version of the .NET Framework if the installation routine finds that it is not present, the full .NET Framework can also be installed and is always maintained independently of the app. This can create versioning problems, particularly when an app encounters a version of the .NET Framework that it is not expecting or when an app runs on a version of the .NET Framework against which it was not developed.</p>
Starting with Windows 8, a version of the .NET Framework is installed as an operating system component and is serviced by Windows Update. For information on the .NET Framework versions installed with specific versions of Windows, see [.NET Framework System Requirements](https://msdn.microsoft.com/library/8z6watww.aspx).  
</td>
</tr>
</table>

Although the .NET Framework 4.6.2 Preview and .NET Core target different platforms and represent different approaches to app development and deployment, they both conform to the [.NET Standard 1.5](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md ".NET Standard 1.5"). This means that they offer a high degree of compatibility and identical behavior to one another. In particular:
    
- Experienced .NET Framework developers can easily adapt to developing with .NET Core when whey want to target different platforms and devices.
- .NET Core developers can easily transition to developing apps with the .NET Framework that target Windows desktop, tablet, and phone.
- Libraries written for the .NET Framework or .NET Core can easily be made to work on the other platform. 


# .NET Core implementations #

A number of development technologies depend on customized implementations of .NET Core. When you develop apps using these technologies, you may not be aware that you are taking advantage of .NET Core:

- ASP.NET Core.  ASP.NET Core is a modular version of ASP.NET that combines ASP.NET MVC and the ASP.NET Web API. It runs on both the .NET Framework and .NET Core and is designed for building high-performance cloud and microservice apps; it is not intended as a replacement to ASP.NET in the .NET Framework. For information on ASP.NET Core, see [Introduction to ASP.NET Core](https://docs.asp.net/en/dev/conceptual-overview/aspnet.html "Introduction to ASP.NET Core").

- .NET Native. .NET Native is a compilation and deployment technology for Universal Windows Platform (UWP) apps written in C# and Visual Basic. .NET Native compiles apps to native code, and statically links into an application's assemblies only those code elements from .NET Core libraries and other third-party libraries that are actually used. For information on .NET Native, see [Compiling Apps with .NET Native](https://msdn.microsoft.com/library/dn584397.aspx).

- Universal Windows Platform (UWP) apps. The Universal Windows Platform allows you to build a single app that can run on the Windows desktop, Windows tablet devices, and Windows Phone. These apps can also be placed in the Windows Store. UWP apps are compiled to native code for their target platforms by .NET Native. For more information, see [Get started with Windows apps](https://developer.microsoft.com/en-us/windows/getstarted "Get started with Windows apps").   


