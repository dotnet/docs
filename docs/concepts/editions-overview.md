# Overview of .NET Implementations

The .NET Platform is described by a set of [open standards](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) that define its architecture and semantic behavior. The [ECMA 335](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md#ecma-335---cli) standard, in particular, must be implemented to be considered a compliant .NET runtime. There are multiple implementations of these standards, provided by Microsoft and other companies, some of which are described below.

The architecture defined in ECMA 335 enables CPU- and OS-agnostic programming models, resulting in portable .NET binaries. A given .NET implementation may support multiple operating systems and CPUs and make it possible to run unmodified libraries and apps on multiple of those configurations. Portable Class Libraries and the [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/standard-platform.md) define portable API sets that are supported by multiple .NET implementations, making it possible to run unmodified libraries across multiple .NET implementations.

## .NET Core

.NET Core is a general purpose and cross-platform implementation of the .NET Platform. [ASP.NET Core](https://github.com/aspnet/home) is the primary workload that runs on .NET Core.

The following are the main characteristics of .NET Core:

**Cross-platform** - .NET Core currently supports three main operating systems: Linux, Windows and OS X. There are other OS ports in progress such as FreeBSD and Alpine. .NET Core libraries can run unmodified across supported OSes. The apps must be re-compiled per environment, given that apps use a native host. Users select the .NET Core supported environment that works best for their situation.

**Open Source** - [.NET Core](https://github.com/dotnet/core) is available on GitHub, licensed with the [MIT](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT) and [Apache 2](https://github.com/dotnet/roslyn/blob/master/License.txt) licenses (licensing is per component). It also makes use of a significant set of open source industry [dependencies](https://github.com/dotnet/core/releases) (see release notes). 

**Natural acquisition** - .NET Core is distributed as a set of packages that developers can pick and choose from. The runtime and base framework can be acquired from [NuGet](http://www.nuget.org/) and OS-specific package managers, such as APT, Homebrew and Yum. Docker images are available on docker hub. The higher-level framework libraries and the larger .NET library ecosystem are available on NuGet. 

**A-la-Carte platform** - .NET Core is built with a modular design, enabling applications to include only the .NET Core libraries and dependencies that are needed. Each application makes its own .NET Core versioning choices, avoiding conflicts with shared components. This approach aligns with the trend of developing software using container technologies like Docker.

## .NET Native

.NET Native is not so much an "edition" of the .NET platform as it is a set of native build tools for .NET Core. .NET Native is an Ahead-of-Time (AOT) toolchain that compiles IL byte code to native machine code, so that when the code is executed, there is only “native” code running. This means that the resulting binary is what the OS executes; there is no JIT-ing, no runtime compilation. This leads to better performance, as well as some security benefits.

.NET Native is primarily used by .NET **[Universal Windows Platform (UWP)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx)** applications.

## .NET Framework

The .NET Framework is Microsoft's primary develop platform for Windows server and client developers. It is a very powerful and mature framework, with a huge class library (known as the **.NET Framework Class Library**) that supports a wide variety of applications and solutions on Windows.

There are multiple application stacks built on top of the .NET Framework that allow developers to build applications ranging from console applications, across rich client (WPF) applications to scalable web applications.

[Windows Forms](https://msdn.microsoft.com/library/dd30h2yb.aspx) and [Windows Presentation Foundation (WPF)](https://msdn.microsoft.com/library/ms754130.aspx) are User Interface (UI) stacks that enable you to build desktop applications for Windows. The strength of Windows Forms lies in its rich support for common databinding scenarios as well as access to Windows’ native user interface controls. WPF, on the other hand, allows you to exercise much more control over the look and feel of your application. 

[Windows Communication Foundation (WCF)](https://msdn.microsoft.com/library/ms731082.aspx) is a set of libraries for SOAP Web Services. It allows you to create services that can communicate through various supported protocols using various data formats, and that can be hosted in any process you choose. This leads to one of the major features of WCF: your services are not tied to any particular hosting strategy or approach.

[ASP.NET](http://www.asp.net/) is a web framework. Being a very rich framework, it has several distinct pieces which are used to produce modern and high-performance web applications. [ASP.NET Web Forms](http://www.asp.net/web-forms) is a set of tools geared primarily towards developer productivity, allowing quick turnaround on web applications with a drag-and-drop surface reusing web controls for everything from logging to data binding. [ASP.NET MVC](http://www.asp.net/mvc) gives you greater control over the entire web pipeline, from the HTTP layer to the user interface. [ASP.NET WebAPI](http://www.asp.net/web-api) is a convention-based framework for creating REST services. It allows you to set-up a REST endpoint extremely fast. Finally, [SignalR](http://www.asp.net/signalr) allows you to provide push-based communication to your web applications using the [WebSocket](https://en.wikipedia.org/wiki/WebSocket) protocol.

## Mono

[Mono](http://www.mono-project.com/docs/about-mono/) is the original open source and cross-platform implementation of .NET, from the community [Mono Project](http://mono-project.com). It is now sponsored by [Xamarin](http://xamarin.com) It can be thought of as an open and cross-platform version of the .NET Framework. It's APIs follow the progress of the .NET Framework, not .NET Core.

There are several components that make up Mono:

**C# Compiler** - Mono’s C# compiler is feature complete for C# 6 (ECMA). A good description of the feature of the various versions is available on Wikipedia.

**Mono Runtime** - The runtime implements the ECMA Common Language Infrastructure (CLI). The runtime provides a Just-in-Time (JIT) compiler, an Ahead-of-Time compiler (AOT), a library loader, the garbage collector, a threading system and interoperability functionality.

**Base Class Library** - The Mono platform provides a comprehensive set of classes that provide a solid foundation to build applications on. These classes are compatible with Microsoft’s .Net Framework classes.

**Mono Class Library** - Mono also provides many classes that go above and beyond the Base Class Library provided by Microsoft. These provide additional functionality that are useful, especially in building Linux applications. Some examples are classes for Gtk+, Zip files, LDAP, OpenGL, Cairo, POSIX, etc.
