Overview of .NET implementations
================================

.NET Platform is, at its very core, a set of standards that can be implemented. There are 
various implementations, some coming from Microsoft, some coming from other companies and 
groups. 

.NET Core
---------
.NET Core is a cloud-optimized, cross-platform implementation of the .NET Platform. It currently 
supports three main operating systems: Linux, Windows and OS X. 

There are several characteristics of .NET Core:

**Cross-platform support** is the first important feature. For applications, it 
is important to use those platforms that will provide the best environment for 
their execution. Thus, having an application platform that can enable the app 
to be ran on different operating systems with minimal or no changes provides a 
significant boon. 

**Open Source** because it is proven to be a great way to enable a larger set of 
platforms, supported by community contribution.

**Better packaging story** - the framework is distributed as a set of packages 
that developers can pick and choose from, rather than a single, 
monolithic platform. .NET Core is the first implementation of .NET Platform that is 
distributed via `NuGet <http://www.nuget.org/>`_ package manager. 

**Better application isolation** as one of the scenarios for .NET Core is to 
enable applications to "take" the needed runtime for their execution and deploy 
it with the application, not depending on shared components on the targeted 
machine. This plays well with the current trends of developing software 
and using container technologies like Docker for consolidation. 

.NET Framework
--------------

The .NET Framework is the premier implementation of the .NET Platform available for 
Windows server and client developers. It is a very powerful, very mature framework, with 
a huge class library (known as the **Framework Class Libraries**) that supports 
a wide variety of applications and solutions on Windows. 

There are additional stacks built on top the .NET Framework that allow developers 
to build applications ranging from console applications, across rich client (WPF) 
applications to scalable web applications. 

`Windows Forms <https://msdn.microsoft.com/en-us/library/dd30h2yb(v=vs.110).aspx>`_ 
and `Windows Presentation Foundation (WPF) <https://msdn.microsoft.com/en-us/library/ms754130(v=vs.110).aspx>`_ 
are User Interface (UI) stacks that enable you to build desktop applications for Windows.
Windows Forms' strength is in its rich support for common databinding scenarios as well as 
access to Windows' native user interface controls. WPF, on the other hand, allows you to exercise 
much more control over the look and feel of your application. Both of them allow for building very 
rich desktop applications that run on Windows, and you should pick the one that is suited for your 
use case. 

`Windows Communication Foundation (WCF) <https://msdn.microsoft.com/en-us/library/ms731082(v=vs.110).aspx>`_ 
is a set of libraries that comprise the middleware services stack on .NET Framework. 
It allows you to create services that can communicate through various supported 
protocols using various data formats, and that can be hosted in any process 
you choose. This leads to one of the major features of WCF: your services are 
not tied to any particular hosting strategy or approach.

`ASP.NET <http://www.asp.net/>`_ is a web framework. Being a very rich framework, 
it has several distinct pieces which are used to produce modern and high-performance 
web applications. `ASP.NET Web Forms <http://www.asp.net/web-forms>`_ is a set 
of tools geared primarily towards developer productivity, allowing quick 
turnaround on web applications with a drag-and-drop surface 
reusing web controls for everything from loging in to data binding. 
`ASP.NET MVC <http://www.asp.net/mvc>`_ allows for a different approach, one that gives you greater 
control over the entire pipeline, from the HTTP layer to the user interface. 
`ASP.NET WebAPI <http://www.asp.net/web-api>`_ is a convention-based framework for creating REST 
services. It allows you to set-up a REST endpoint extremely fast. Finally, 
`SignalR <http://www.asp.net/signalr>`_ allows you to provide push-based communication to your web 
applications using `WebSocket <https://en.wikipedia.org/wiki/WebSocket>`_ protocol. 
Finally, `ASP.NET v5 <http://www.asp.net/vnext/>`_ is a new version of MVC and 
WebAPI frameworks that is built to run on top of .NET Core.

.NET Native
-----------

.NET Native is not so much an "edition" of the .NET platform as it is a set of tools that 
allow developers to have different build outputs. The normal .NET source compilation process takes 
the source code written in one of the .NET languages (such as C#, Visual Basic, F# etc.) and 
produces something called "Intermediate Language". IL is then picked up by the runtime, 
and Just-In-Time compiled at run-time to machine code. 

.NET Native NET Native is an Ahead-of-Time (AOT) toolchain that compiles IL 
byte code to native machine code, so that when the code is executed, there is 
only "native" code running. This means that the resulting binary is what the OS executes; 
there is no JIT-ing, no runtime compilation. This leads to better performance, as well as 
some security benefits. 

.NET Native is the set of tools used to build .NET **Universal Windows Platform (UWP)** 
applications. 

Supported operating systems
---------------------------

.NET Core is supported on Windows, Linux and OS X. 

.NET Framework is supported on Windows operating system. .NET Native is, 
at this time, supported on Windows. 






