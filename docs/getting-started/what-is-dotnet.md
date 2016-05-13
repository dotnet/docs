# What is the .NET Core Platform?

.NET Core is a modular, cross-platform, open source implementation of the .NET Framework that runs on Windows devices, as well as on Linux and Mac OSX. Unlike the .NET Framework, .NET Core consists of a set of runtime and library components that can be used in various configurations, depending on the needs of your application.

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
<td>Includes CoreFx, a set of individual modular assemblies that you can add to your application as needed. Unlike the .NET Framework 4.x, which always makes the entire .NET Framework Class Library available, you can select only the assemblies that you need. For example, if you are developing a vector-based application, you can download the System.Numerics.Vectors package without the overhead of a large class library. This significantly reduces the size of your application and its dependencies.
</td>
<td>Includes the .NET Framework Class Library, a large, monolithic library with thousands of classes and many thousands of members. Whether or not your application uses individual types and their members (and most applications take advantage of only a small portion of the .NET Framework's functionality), they are always present and accessible. 
</td>
</tr>
<tr>
<td>Is suitable for a full range of modern applications, including applications that operate on small devices with constrained memory and storage.
</td>
<td>Is suitable for developing traditional Windows desktop applications, including Windows Forms (WinForms) and Windows Presentation Foundation (WPF) applications.
</td>
</tr>
<tr>
<td>Can be used to develop apps that take advantage of a number of technologies, such as ASP .NET Core, for building web applications; Windows Communication Foundation (WCF), for building applications that communicate with existing WCF services; and Workflow Foundation (WF), for building workflows. 
</td>
<td>Can be used to develop apps that take advantage of a number of technologies, such as ASP .NET and ASP.NET Web Forms, for building web applications; Windows Communication Foundation (WCF), for building services, including SOAP; and Workflow Foundation (WF), for building workflows. 
</td>
</tr>
<tr>
<td>Can be app local. That is, the .NET Core implementation that your app relies is tightly bound to your application. This mitigates versioning problems.
</td>
<td>Is globally available on a single system. That is, although an app can include a chain installer that installs a particular version of the .NET Framework if the installation routine finds that it is not present, the full .NET Framework can also be installed and is maintained independently of the app. This can create versioning problems, particularly when an app encounters a version of the .NET Framework that it is not expecting or when an app runs on a version of the .NET Framework against which it was not developed.</p>
Starting with Windows 8, a version of the .NET Framework is installed as an operating system component and is serviced by Windows Update. For information on the .NET Framework versions installed with specific versions of Windows, see [.NET Framework System Requirements](https://msdn.microsoft.com/library/8z6watww.aspx).  
</td>
</tr>
</table>

Although the .NET Framework and .NET Core target different platforms and represent different approaches to application development and deployment, they both conform to the [.NET Standard 1.3](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md ".NET Standard 1.3"). This means that they offer a high degree of compatibility and identical behavior between one another. In particular:
    
- Their high degree of compatibility makes it easy for .NET Framework developers to develop applications with .NET Core that target different platforms and devices.
- Their high degree of compatibility also makes it easy for .NET Core developers to develop applications with the .NET Framework that target Windows desktop, tablet, and phone.
- Libraries written for the .NET Framework or .NET Core can easily be made to work on the other platform. 


# .NET Core implementations #

A number of development technologies depend on customized implementations of .NET Core. When you develop apps using these technologies, you may not be aware that you are taking advantage of .NET Core:

- ASP.NET Core.  ASP.NET Core is a modular version of ASP.NET that combines ASP.NET MVC and the ASP.NET web API. It runs on both the .NET Framework and .NET Core and is designed for building high-performance cloud and microservice-style applications; it is not intended as a replacement to ASP.NET in the .NET Framework. For information on ASP.NET Core, see [Introduction to ASP.NET 5](http://docs.asp.net/en/latest/conceptual-overview/aspnet.html "Introduction to ASP.NET 5").

- .NET Native. .NET Native is a compilation and deployment technology for Universal Windows Platform (UWP) apps written in C# and Visual Basic. .NET Native compiles apps to native code, and statically links into an application's assemblies only those code elements from .NET Core libraries and other third-party libraries that are actually used. For information on .NET Native, see [Compiling Apps with .NET Native](https://msdn.microsoft.com/library/dn584397.aspx).

- Universal Windows Platform (UWP) applications. The Universal Windows Platform allows you to build a single application that can run on the Windows desktop, Windows tablet devices, and Windows Phone. These applications can also be placed in the Windows Store. UWP applications are compiled to native code for their target platforms by .NET Native. For more information, see [Get started with Windows apps](https://developer.microsoft.com/en-us/windows/getstarted "Get started with Windows apps").   

# .NET Core Components #

Very much like the .NET Framework on the Windows desktop, .NET Core consists of a common language runtime, which in .NET Core is named CoreCLR. .NET Core also features an extensive class library. Rather than a single .NET Framework Class Library, however, .NET Core features CoreFX, a modular collection of libraries. This allows you to include the libraries that your application needs without the overhead of including those that you don't need.
   
## The Common Language Runtime ##

CoreCLR, or the common language runtime found in .NET Core, is a lightweight runtime that offers many of the same services as the .NET Framework's common language runtime on the Windows desktop. These include:

- A garbage collector, which provides automatic memory management. The garbage collector allocates and frees memory as needed; you do not have do not it programmatically. .NET Core uses the same garbage collector as the .NET Framework. For more information, see [Garbage Collection](https://msdn.microsoft.com/en-us/library/0xy59wtx(v=vs.110).aspx "Garbage Collection"). 

- A just-in-time (JIT) compiler. which compiles IL, or .NET intermediate language, to native machine code at runtime. On some architectures, the JIT compiler includes support for SIMD hardware acceleration.

- An exception handling mechanism, which allows you to handle exceptions with try/catch statements.   

##The Class Library. 

The class library available in .NET Core is very much like the .NET Framework Class Library for the Windows desktop, with one major difference. On the Windows desktop, it is a monolithic library that is part of the operating system and is maintained by Windows Update. On .NET Core it is a modular and factored collection of individual libraries organized by functionality. 

One library, the Microsoft.NetCore.App, is included with the runtime and contains the basic types needed for all application development. Some of these include:

-  Primitives, such as the Boolean type, signed and unsigned integral types, floating-point types, the Char structure.
  
-  General-purpose exception classes, such as the ArgumentException, ArgumentNullException, and NullReferenceException types.

- The task types, such as Task and Task&lt;T&gt;, to support asynchronous programming.

- Basic threading types, to support multithreaded application development.

- The Console class, to support the development of console applications. 

Other libraries are installed as [NuGet](http://www.nuget.org/ "NuGet") packages

## .NET Core CLI ##

.NET Core includes a new cross-platform command-line SDK known as the CLI (for Command-Line Interface). The CLI is a UNIX-friendly set of tools for building .NET Core applications. It abstracts the C# compiler, the NuGet package manager, and includes incremental build logic. It can also integrate with the .NET Native tool chain to produce high-performance native apps and libraries. The CLI allows developers to build and test applications with a minimal installation on developer, lab, or production machines. Since some IDEs, such as Visual Studio Code and Visual Studio, use the CLI under the covers, developers can now choose the level they want to interact with the tool chain by working with the CLI directly, using an editor that uses the CLI, or developing with an IDE that uses the CLI internally.  

## Language Support and Development Environments ##

.NET Core provides a runtime environment for your app, as well as a collection of libraries whose types and members your application can use. .NET Core itself is language agnostic: it is not a programming language, but any programming language that targets .NET Core can be used to develop .NET Core applications, and an application written in one programming language can seamlessly access types and members in libraries developed by using a different programming language. 
 
You develop and compile .NET Core apps in either of two languages:

- C#, which is based on the [.NET Compiler Platform](https://github.com/dotnet/roslyn "Roslyn Compiler Platform"), also known as Roslyn. 

- [F#](https://channel9.msdn.com/Events/Build/2016/T661 "F#").
 
(At the moment, other languages are not supported, though that will change going forward.) 

You have a wide choice of development environments for writing your app, ranging from a simple text editor or programmer's editor of your choice to [Visual Studio Code](https://code.visualstudio.com/ "Visual Studio Code"), to [Visual Studio 2015](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx "Visual Studio 2015").   

# What's Different about .NET Core?  #

Let's take a high-level view of some of the components and features that .NET Core makes available. 

## Cross-Platform Support ##

.NET Core apps can run on both the 32-bit and 64-bit Windows platforms, as well as on Mac OSX and Linux.

In contrast, apps that target the full .NET Framework can run only on Windows. And UWP apps, which use an implementation of .NET Core, can run only on Windows desktop and tablets, as well as on Windows Phone.

## Open Source ##
 
.NET Core -- both its runtime and its class libraries -- are open source. In addition to making the source code for .NET Core freely available, this means that:

- Design notes, feature specifications, and implementation-specific documentation is publicly available. 

- Code reviews of .NET Core features are public.

- By using GitHub's pull request model, you can open bugs, suggest modifications to source code, and submit new feature requests and source code.

- You can download all of the source code and build it on your own system. The .NET Framework libraries, the runtime, and .NET Framework tools can be built on any of the supported platforms (that is, on Windows x86/x64, Max OS/X, and Linux). 

## Console Applications ##

The .NET Framework on the Windows desktop allows you to create console applications, and so does .NET Core. But .NET Core reinvigorates the console application:

- Console applications can be compiled to run cross-platform on Windows, the Macintosh, and Linux.

- Console applications can be compiled natively. This combines the benefits of a managed application with the performance of a native C/C++ application. 

## Ease of Installation ##

Because .NET Core is not an operating system component, installation does not require administrator privileges, and it does not touch system components like operating system directories or, on Windows systems, the Windows Registry. Installation is as simple as copying some files to a directory on the target computer or compiling the framework natively into the application. 

New developers can get started developing for .NET in under one minute, including downloading the frameworks and tools. You can install .NET Core from the [.NET Core getting started page](https://dotnet.github.io/getting-started/#/windows ".NET Core getting started page"). 

## Ease of Deployment ##

Ordinarily, when you install an application that targets the .NET Framework on the desktop, you also should check which version of the .NET Framework is installed and, if the base version that your application requires is not present, chain to a .NET Framework installation routine. 

In contrast, you can deploy your .NET Core application by copying it to the target system. Along with your application itself, you can either copy the required .NET Framework libraries to the application folder, or you can include needed libraries in your application. In either case, the .NET libraries against which your application was developed are local to your application and are isolated from .NET Core libraries used by other applications.

