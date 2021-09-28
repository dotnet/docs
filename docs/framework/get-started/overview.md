---
title: "Overview of .NET Framework"
description: Read an overview about .NET Framework, which is a technology that supports building and running Windows apps and web services.
ms.date: 10/21/2020
helpviewer_keywords:
  - "application development [.NET Framework]"
  - "common language runtime"
  - "common language runtime, about"
  - "common language runtime, overview"
ms.assetid: 29848c96-fc36-462d-8072-ba223a40b697
---
# Overview of .NET Framework

.NET Framework is a technology that supports building and running Windows apps and web services. .NET Framework is designed to fulfill the following objectives:

- Provide a consistent, object-oriented programming environment whether object code is stored and executed locally, executed locally but web-distributed, or executed remotely.

- Provide a code-execution environment that:

  - Minimizes software deployment and versioning conflicts.

  - Promotes safe execution of code, including code created by an unknown or semi-trusted third party.

  - Eliminates the performance problems of scripted or interpreted environments.

- Make the developer experience consistent across widely varying types of apps, such as Windows-based apps and Web-based apps.

- Build all communication on industry standards to ensure that code based on .NET Framework integrates with any other code.

[!INCLUDE [net-framework-future](../../../includes/net-framework-future.md)]

.NET Framework consists of the common language runtime (CLR) and the .NET Framework class library. The common language runtime is the foundation of .NET Framework. Think of the runtime as an agent that manages code at execution time, providing core services such as memory management, thread management, and remoting, while also enforcing strict type safety and other forms of code accuracy that promote security and robustness. In fact, the concept of code management is a fundamental principle of the runtime. Code that targets the runtime is known as managed code, while code that doesn't target the runtime is known as unmanaged code. The class library is a comprehensive, object-oriented collection of reusable types that you use to develop apps ranging from traditional command-line or graphical user interface (GUI) apps to apps based on the latest innovations provided by ASP.NET, such as Web Forms and XML web services.

.NET Framework can be hosted by unmanaged components that load the common language runtime into their processes and initiate the execution of managed code, thereby creating a software environment that exploits both managed and unmanaged features. .NET Framework not only provides several runtime hosts but also supports the development of third-party runtime hosts.

For example, ASP.NET hosts the runtime to provide a scalable, server-side environment for managed code. ASP.NET works directly with the runtime to enable ASP.NET apps and XML web services, both of which are discussed later in this article.

Internet Explorer is an example of an unmanaged app that hosts the runtime (in the form of a MIME type extension). Using Internet Explorer to host the runtime enables you to embed managed components or Windows Forms controls in HTML documents. Hosting the runtime in this way makes managed mobile code possible, but with significant improvements that only managed code offers, such as semi-trusted execution and isolated file storage.

The following illustration shows the relationship of the common language runtime and the class library to your apps and to the overall system. The illustration also shows how managed code operates within a larger architecture.

![Screenshot that shows how managed code operates within a larger architecture.](./media/overview/language-runtime-class-library-relationship.gif)

The following sections describe the main features of .NET Framework in greater detail.

## Features of the common language runtime

The common language runtime manages memory, thread execution, code execution, code safety verification, compilation, and other system services. These features are intrinsic to the managed code that runs on the common language runtime.

Regarding security, managed components are awarded varying degrees of trust, depending on a number of factors that include their origin (such as the Internet, enterprise network, or local computer). This means that a managed component might or might not be able to perform file-access operations, registry-access operations, or other sensitive functions, even if it's used in the same active app.

The runtime also enforces code robustness by implementing a strict type-and-code-verification infrastructure called the common type system (CTS). The CTS ensures that all managed code is self-describing. The various Microsoft and third-party language compilers generate managed code that conforms to the CTS. This means that managed code can consume other managed types and instances, while strictly enforcing type fidelity and type safety.

In addition, the managed environment of the runtime eliminates many common software issues. For example, the runtime automatically handles object layout and manages references to objects, releasing them when they are no longer being used. This automatic memory management resolves the two most common app errors, memory leaks and invalid memory references.

The runtime also accelerates developer productivity. For example, programmers write apps in their development language of choice yet take full advantage of the runtime, the class library, and components written in other languages by other developers. Any compiler vendor who chooses to target the runtime can do so. Language compilers that target the .NET Framework make the features of the .NET Framework available to existing code written in that language, greatly easing the migration process for existing apps.

While the runtime is designed for the software of the future, it also supports software of today and yesterday. Interoperability between managed and unmanaged code enables developers to continue to use necessary COM components and DLLs.

The runtime is designed to enhance performance. Although the common language runtime provides many standard runtime services, managed code is never interpreted. A feature called just-in-time (JIT) compiling enables all managed code to run in the native machine language of the system on which it's executing. Meanwhile, the memory manager removes the possibilities of fragmented memory and increases memory locality-of-reference to further increase performance.

Finally, the runtime can be hosted by high-performance, server-side apps, such as Microsoft SQL Server and Internet Information Services (IIS). This infrastructure enables you to use managed code to write your business logic, while still enjoying the superior performance of the industry's best enterprise servers that support runtime hosting.

## .NET Framework class library

The .NET Framework class library is a collection of reusable types that tightly integrate with the common language runtime. The class library is object oriented, providing types from which your own managed code derives functionality. This not only makes the .NET Framework types easy to use but also reduces the time associated with learning new features of the .NET Framework. In addition, third-party components integrate seamlessly with classes in the .NET Framework.

For example, the .NET Framework collection classes implement a set of interfaces for developing your own collection classes. Your collection classes blend seamlessly with the classes in the .NET Framework.

As you would expect from an object-oriented class library, the .NET Framework types enable you to accomplish a range of common programming tasks, including string management, data collection, database connectivity, and file access. In addition to these common tasks, the class library includes types that support a variety of specialized development scenarios. You can use .NET Framework to develop the following types of apps and services:

- Console apps. See [Building Console Applications](../../standard/building-console-apps.md).

- Windows GUI apps (Windows Forms). See [Windows Forms](/dotnet/desktop/winforms/).

- Windows Presentation Foundation (WPF) apps. See [Windows Presentation Foundation](/dotnet/desktop/wpf/).

- ASP.NET apps. See [Web Applications with ASP.NET](../develop-web-apps-with-aspnet.md).

- Windows services. See [Introduction to Windows Service Applications](../windows-services/introduction-to-windows-service-applications.md).

- Service-oriented apps using Windows Communication Foundation (WCF). See [Service-Oriented Applications with WCF](../wcf/index.md).

- Workflow-enabled apps using Windows Workflow Foundation (WF). See [Windows Workflow Foundation](../windows-workflow-foundation/index.md).

The Windows Forms classes are a comprehensive set of reusable types that vastly simplify Windows GUI development. If you write an ASP.NET Web Form app, you can use the Web Forms classes.

## See also

- [System Requirements](system-requirements.md)
- [Installation guide](../install/index.md)
- [Development guide](../development-guide.md)
- [Tools](../tools/index.md)
- [.NET samples and tutorials](../../samples-and-tutorials/index.md)
- [.NET API browser](../../../api/index.md)
