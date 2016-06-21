.NET Products
=============

.NET is a very flexible and cross-platform [specification](https://github.com/dotnet/coreclr/blob/master/Documentation/project-docs/dotnet-standards.md) for building developer products. It is used for all of the most popular app categories: desktop, mobile, cloud, gaming and IoT.

Desktop
-------

You can build desktop apps with .NET Framework for Windows or Mono for macOS, using the following APIs:

- Windows Presentation Framework (WPF) for Windows with the [.NET Framework](#net-framework)
- Windows Forms for Windows with the [.NET Framework](net-framework)
- Cocoa for macOS with [Xamarin](#xamarin)
- Electron for cross-platform desktop with [electron-edge](https://github.com/kexplo/electron-edge)

Mobile
------

You can build 

Major commercial and open source .NET products are listed below, in order of introduction.

.NET Framework
--------------

The .NET Framework is Microsoft's primary development platform for Windows and Windows Server developers. It is a powerful and mature framework, with a large class library that supports a wide variety of applications and solutions on Windows.

[Windows Forms](https://msdn.microsoft.com/library/dd30h2yb.aspx) enables you to build a "forms over data" desktop UI more rapidly than any other technology. It uses a designer that enables drag-and-drop of UI and non-UI controls, reducing most development tasks into a single gesture and conceptual model.

[Windows Presentation Foundation (WPF)](https://msdn.microsoft.com/library/ms754130.aspx) separates code and UI concerns by describing UI with the [XAML](https://msdn.microsoft.com/library/ms752059.aspx) markup language. WPF is very flexible and is often used for UIs that require a more complex user model or a more elegant appearance.

[Windows Communication Foundation (WCF)](https://msdn.microsoft.com/library/ms731082.aspx) is a set of libraries for SOAP Web Services. It allows you to create services that can communicate through various supported protocols using various data formats, and that can be hosted in any process you choose. This leads to one of the major features of WCF: your services are not tied to any particular hosting strategy or approach.

[ASP.NET](http://www.asp.net/) is a web framework. It has several distinct pieces which are used to produce modern and high-performance web applications. 

- [ASP.NET Web Forms](http://www.asp.net/web-forms) enables you to build a "forms over data" UI more radidly than most other Web technologies, with a designer that enables drag-and-drop of web controls. 
- [ASP.NET MVC](http://www.asp.net/mvc) gives you greater control over the entire web pipeline, from the HTTP layer to the user interface. 
- [ASP.NET WebAPI](http://www.asp.net/web-api) is a convention-based framework for creating REST services. [SignalR](http://www.asp.net/signalr) allows you to provide push-based communication to your web applications using the 
- [WebSocket](https://en.wikipedia.org/wiki/WebSocket) protocol.

Mono
----

[Mono](http://www.mono-project.com/docs/about-mono/) is the original open source and cross-platform implementation of .NET, from the community [Mono Project](http://mono-project.com). It is now sponsored by Microsoft. It can be thought of as an open and cross-platform version of the .NET Framework. Its APIs follow the progress of the .NET Framework, not .NET Core.

There are several components that make up Mono:

**C# Compiler** - Mono’s C# compiler is feature complete for C# 6.

**Mono Runtime** - The runtime implements the ECMA Common Language Infrastructure (CLI). The runtime provides a Just-in-Time (JIT) compiler, an Ahead-of-Time compiler (AOT), a library loader, the garbage collector, a threading system and interoperability functionality.

**Base Class Library** - The Mono platform provides a comprehensive set of classes that provide a solid foundation to build applications on. These classes are compatible with Microsoft’s .Net Framework classes.

**Mono Class Library** - Mono also provides many classes that go above and beyond the Base Class Library provided by the .NET Framework. These provide additional functionality that are useful, especially in building Linux applications. Some examples are classes for Gtk+, Zip files, LDAP, OpenGL, Cairo, POSIX, etc.

Unity
-----

[Unity](http://unity3d.com) is a [popular](http://unity3d.com/public-relations) cross-platform 2D + 3D game engine that uses C# for scripting game play and logic. Unity has several graphics API back-ends including DirectX for Windows and OpenGL for any Operating System (OS) that supports it. A major benefit of Unity is its broad platform support. You can build a single game and publish it to the more than [25 platforms that Unity supports](http://unity3d.com/unity/multiplatform). These platforms include all the popular targets in desktop, console, mobile, VR and AR gaming.

The [Made with Unity](http://madewith.unity.com) site showcases published Unity games. These games demonstrate the breadth of possibility using Unity.

Unity has traditionally used the Mono runtime to execute "C# scripts". More recently, Unity has been adopting its [IL2CPP](http://blogs.unity3d.com/2014/05/20/the-future-of-scripting-in-unity/) technology.

Xamarin
-------

[Xamarin](https://xamarin.com) provides and end-to-end development experience for building Android and iOS apps. 

.NET Native
-----------

.NET Native is a set of native build tools for .NET Core. .NET Native is an Ahead-of-Time (AOT) toolchain that produces native applications by compiling IL byte code to native machine code. This means that the resulting binary is what the OS executes; there is no JIT-ing, no runtime compilation. This leads to better startup performance, as well as some security benefits.

.NET Native is primarily used by .NET [Universal Windows Platform (UWP)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx) applications.

Windows 10 IoT Core
-------------------

[Windows 10 IoT Core](https://developer.microsoft.com/windows/iot) is a version of Windows 10 that is optimized for smaller devices with or without a display, and that runs on the Raspberry Pi 2 and 3, Arrow DragonBoard 410c & MinnowBoard MAX. Windows 10 IoT Core utilizes the rich, extensible Universal Windows Platform (UWP) API for building great solutions.

You can build IoT apps in C# using .NET APIs using Visual Studio, with rich debugging of your app running on-device. You can see [examples of IoT apps](https://www.hackster.io/windowsiot) that have been built.

.NET Core
---------

.NET Core is a general purpose and cross-platform implementation of the .NET Platform. [ASP.NET Core](https://github.com/aspnet/home) is the primary workload that runs on .NET Core.

The following are the main characteristics of .NET Core:

**Cross-platform** - .NET Core supports three operating systems families: Linux, Windows and macOS. .NET Core apps are cross-platform by default. You need to build and publish a version per OS you want to target. The app host and the runtime are the primary OS-specific native dependencies. .NET Core libraries can run unmodified across supported OSes.

**Open Source** - [.NET Core](https://github.com/dotnet/core) is available on GitHub, licensed with the [MIT](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT) and [Apache 2](https://github.com/dotnet/roslyn/blob/master/License.txt) licenses (licensing is per component). It also makes use of a significant set of open source industry [dependencies](https://github.com/dotnet/core/releases) (see release notes). 

**Natural acquisition** - .NET Core is distributed as a set of packages that developers can pick and choose from. The runtime and base framework can be acquired from [NuGet](http://www.nuget.org/) and OS-specific package managers, such as APT, Homebrew and Yum. Docker images are available on docker hub. The higher-level framework libraries and the larger .NET library ecosystem are available on NuGet. 

**Modular platform** - .NET Core is built with a modular design, enabling applications to include only the .NET Core libraries and dependencies that are needed. Each application makes its own .NET Core versioning choices, avoiding conflicts with shared components. This approach aligns with the trend of developing software using container technologies like Docker.
