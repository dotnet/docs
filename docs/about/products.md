.NET Products
=============

.NET is a very flexible, general purpose and inherently cross-platform [specification](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) for building developer products. It is used for all of the most popular app categories: desktop, mobile, cloud, gaming and IoT.

There are two subtly different terms used in this document:

- ".NET product" - Enables you to build an app for one or more target platforms.
- ".NET implementation" - Some combination of a runtime, framework and tools that can execute ".NET code" on which products are based.

Product Categories
------------------

.NET products are available for each of the following product categories.

### Desktop

You can build desktop apps with for Windows and macOS.

- [Universal Windows Apps](https://developer.microsoft.com/windows) with [.NET Native](#net-native)
- [Windows Presentation Framework (WPF)](https://msdn.microsoft.com/library/ms754130.aspx) for Windows with the [.NET Framework](#net-framework)
- [Windows Forms](https://msdn.microsoft.com/library/dd30h2yb.aspx) for Windows with the [.NET Framework](#net-framework)
- Cocoa for macOS with [Xamarin](#xamarin-sdk)
- [Electron](http://electron.atom.io/) for cross-platform desktop with [electron-edge](https://github.com/kexplo/electron-edge)

### Games

You can build games for many desktop, mobile, console and virtual/agumented reality devices.

- [Unity](http://docs.unity3d.com/Manual/index.html) with [Mono](#mono)
- [MonoGame](http://www.monogame.net/documentation/?page=main) with [Mono](#mono)

### IoT

You can build IoT apps for Windows 10 IoT Core, including Raspberry Pi 2/3.

- [Windows 10 IoT Core](https://developer.microsoft.com/windows/iot) with [.NET Native](#net-native)

### Mobile

You can build Mobile apps for iOS, Android and Windows.

- iOS app with [Xamarin](#xamarin-sdk)
- Android app with [Xamarin](#xamarin-sdk)
- [Universal Windows App](https://developer.microsoft.com/windows) with [.NET Native](#net-native)

### Web and Cloud

You can build Web and Cloud apps for Windows and Linux.

- [ASP.NET] for Windows with the [.NET Framework](#net-framework)
- [ASP.NET Core] for Windows, macOS and Linux with [.NET Core](#net-core)

.NET Implementations
--------------------

Major commercial and open source .NET implementations are listed below, in alphabetical order.

### .NET Core

.NET Core is used to build device, web, cloud and embedded/IoT apps. It is [open source](https://github.com/dotnet/core) and cross-platform, supporting Windows, macOS and Linux. [ASP.NET Core](http://docs.asp.net/) is the most popular workload for .NET Core. You can use it to build web apps and services, for on-premises and cloud deployment. You can also use .NET Core to build tools, utilities and cloud worker apps.

- Learn about [.NET Core](../core)
- Learn about [ASP.NET Core](http://docs.asp.net/)
- [Download .NET Core](http://dot.net/core)

The following are the main characteristics of .NET Core:

**Cross-platform** - .NET Core supports three operating systems families: Linux, Windows and macOS. .NET Core apps are cross-platform by default. You need to build and publish a version per OS you want to target. The app host and the runtime are the primary OS-specific native dependencies. .NET Core libraries can run unmodified across supported OSes.

**Open Source** - [.NET Core](https://github.com/dotnet/core) is available on GitHub, licensed with the [MIT](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT) and [Apache 2](https://github.com/dotnet/roslyn/blob/master/License.txt) licenses (licensing is per component). Documentation is [CC-BY](https://github.com/dotnet/core-docs/blob/master/license.txt). .NET Core also makes use of a significant set of open source industry dependencies, listed in the [.NET Core release notes](https://github.com/dotnet/core/releases). 

**Natural acquisition** - NET Core is distributed in several forms, aligning with specific developer needs. You can acquire .NET Core with the [.NET Core SDK](https://dot.net/core) installer (or zips) or via OS-specific package managers, such as APT and Yum. [Official .NET Core Docker images](https://hub.docker.com/r/microsoft/dotnet/) are available on Docker Hub. Higher-level framework libraries and the larger .NET library ecosystem are available on [NuGet](http://www.nuget.org/). 

**Modular platform** - .NET Core is built with a modular design, enabling applications to include only the .NET Core libraries and dependencies that are needed. Each application makes its own .NET Core versioning choices, avoiding conflicts with shared components. This approach aligns with the trend of developing software using container technologies like Docker.

.NET Framework
--------------

The .NET Framework is used to build apps for Windows and Windows Server. You can use it to build rich user interfaces with Windows Presentation Framework (WPF) and Windows Forms. You quickly build server apps with ASP.NET Web Forms, ASP.NET MVC and Windows Communication Framework (WCF). It is integrated into Visual Studio, which provides many rich designer experiences for building both client and server apps. It is the best choice for writing apps for Windows.

- Learn about the [.NET Framework](https://msdn.microsoft.com/library/w0x726c2.aspx)
- [Download .NET Framework](https://dot.net)

[Windows Forms](https://msdn.microsoft.com/library/dd30h2yb.aspx) enables you to build a "forms over data" desktop UI more rapidly than any other technology. It uses a designer that enables drag-and-drop of UI and non-UI controls, reducing most development tasks into a single gesture and conceptual model.

[Windows Presentation Foundation (WPF)](https://msdn.microsoft.com/library/ms754130.aspx) separates code and UI concerns by describing UI with the [XAML](https://msdn.microsoft.com/library/ms752059.aspx) markup language. WPF is very flexible and is often used for UIs that require a more complex user model or a more elegant appearance.

[Windows Communication Foundation (WCF)](https://msdn.microsoft.com/library/ms731082.aspx) is a set of libraries for SOAP Web Services. It allows you to create services that can communicate through various supported protocols using various data formats, and that can be hosted in any process you choose. This leads to one of the major features of WCF: your services are not tied to any particular hosting strategy or approach.

[ASP.NET](http://www.asp.net/) is a web framework. It has several distinct pieces which are used to produce modern and high-performance web applications. 

- [ASP.NET Web Forms](http://www.asp.net/web-forms) enables you to build a "forms over data" UI more radidly than most other Web technologies, with a designer that enables drag-and-drop of web controls. 
- [ASP.NET MVC](http://www.asp.net/mvc) gives you greater control over the entire web pipeline, from the HTTP layer to the user interface. 
- [ASP.NET WebAPI](http://www.asp.net/web-api) is a convention-based framework for creating REST services. 
- [SignalR](http://www.asp.net/signalr) allows you to provide push-based communication to your web applications using the [WebSocket](https://en.wikipedia.org/wiki/WebSocket) protocol.

.NET Native
-----------

.NET Native is a set of native build tools for .NET Core. .NET Native is an Ahead-of-Time (AOT) toolchain that produces native applications by compiling IL byte code to native machine code. This means that the resulting binary is what the OS executes; there is no JIT-ing, no runtime compilation. This leads to better startup performance, as well as some security benefits.

.NET Native is primarily used by .NET [Universal Windows Platform (UWP)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx) applications.

Mono
----

[Mono](http://www.mono-project.com/docs/about-mono/) is the original open source and cross-platform implementation of .NET, from the community [Mono Project](http://mono-project.com). It is now sponsored by Microsoft. It can be thought of as an open and cross-platform version of the .NET Framework. Its APIs follow the progress of the .NET Framework, not .NET Core.

There are several components that make up Mono:

**C# Compiler** - Mono’s C# compiler is feature complete for C# 6.

**Mono Runtime** - The runtime implements the ECMA Common Language Infrastructure (CLI). The runtime provides a Just-in-Time (JIT) compiler, an Ahead-of-Time compiler (AOT), a library loader, the garbage collector, a threading system and interoperability functionality.

**Base Class Library** - The Mono platform provides a comprehensive set of classes that provide a solid foundation to build applications on. These classes are compatible with Microsoft’s .Net Framework classes.

**Mono Class Library** - Mono also provides many classes that go above and beyond the Base Class Library provided by the .NET Framework. These provide additional functionality that are useful, especially in building Linux applications. Some examples are classes for Gtk+, Zip files, LDAP, OpenGL, Cairo, POSIX, etc.

Xamarin SDK
-----------

The [Xamarin SDK](https://open.xamarin.com) is used to build native mobile and device apps, primarily for Apple and Google ecosystems. It is based on Mono and is open source using the MIT license. You can use it to build iOS and Android apps for phones, tablets and watches. [Xamarin.Forms](https://www.xamarin.com/forms) is a popular way to write reusable UIs across Apple, Google and Windows apps.

- Learn about the [Xamarin SDK](https://developer.xamarin.com/)
- [Download Xamarin](https://www.xamarin.com/platform)
