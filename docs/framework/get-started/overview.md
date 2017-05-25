---
title: "Overview of the .NET Framework | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "application development [.NET Framework]"
  - "common language runtime"
  - "common language runtime, about"
  - "common language runtime, overview"
ms.assetid: 29848c96-fc36-462d-8072-ba223a40b697
caps.latest.revision: 34
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Overview of the .NET Framework
The .NET Framework is a technology that supports building and running the next generation of applications and XML Web services. The .NET Framework is designed to fulfill the following objectives:  
  
-   To provide a consistent object-oriented programming environment whether object code is stored and executed locally, executed locally but Internet-distributed, or executed remotely.  
  
-   To provide a code-execution environment that minimizes software deployment and versioning conflicts.  
  
-   To provide a code-execution environment that promotes safe execution of code, including code created by an unknown or semi-trusted third party.  
  
-   To provide a code-execution environment that eliminates the performance problems of scripted or interpreted environments.  
  
-   To make the developer experience consistent across widely varying types of applications, such as Windows-based applications and Web-based applications.  
  
-   To build all communication on industry standards to ensure that code based on the .NET Framework can integrate with any other code.  
  
> [!NOTE]
>  For a general introduction to the .NET Framework for both users and developers, see [Getting Started](../../../docs/framework/get-started/index.md).  
  
 The .NET Framework consists of the common language runtime and the .NET Framework class library. The common language runtime is the foundation of the .NET Framework. You can think of the runtime as an agent that manages code at execution time, providing core services such as memory management, thread management, and remoting, while also enforcing strict type safety and other forms of code accuracy that promote security and robustness. In fact, the concept of code management is a fundamental principle of the runtime. Code that targets the runtime is known as managed code, while code that does not target the runtime is known as unmanaged code. The class library is a comprehensive, object-oriented collection of reusable types that you can use to develop applications ranging from traditional command-line or graphical user interface (GUI) applications to applications based on the latest innovations provided by ASP.NET, such as Web Forms and XML Web services.  
  
 The .NET Framework can be hosted by unmanaged components that load the common language runtime into their processes and initiate the execution of managed code, thereby creating a software environment that can exploit both managed and unmanaged features. The .NET Framework not only provides several runtime hosts, but also supports the development of third-party runtime hosts.  
  
 For example, ASP.NET hosts the runtime to provide a scalable, server-side environment for managed code. ASP.NET works directly with the runtime to enable ASP.NET applications and XML Web services, both of which are discussed later in this topic.  
  
 Internet Explorer is an example of an unmanaged application that hosts the runtime (in the form of a MIME type extension). Using Internet Explorer to host the runtime enables you to embed managed components or Windows Forms controls in HTML documents. Hosting the runtime in this way makes managed mobile code possible, but with significant improvements that only managed code can offer, such as semi-trusted execution and isolated file storage.  
  
 The following illustration shows the relationship of the common language runtime and the class library to your applications and to the overall system. The illustration also shows how managed code operates within a larger architecture.  
  
 ![Managed code within a larger architecture](../../../docs/framework/get-started/media/circle.gif "circle")  
.NET Framework in context  
  
 The following sections describe the main features of the .NET Framework in greater detail.  
  
## Features of the Common Language Runtime  
 The common language runtime manages memory, thread execution, code execution, code safety verification, compilation, and other system services. These features are intrinsic to the managed code that runs on the common language runtime.  
  
 With regards to security, managed components are awarded varying degrees of trust, depending on a number of factors that include their origin (such as the Internet, enterprise network, or local computer). This means that a managed component might or might not be able to perform file-access operations, registry-access operations, or other sensitive functions, even if it is being used in the same active application.  
  
 The runtime enforces code access security. For example, users can trust that an executable embedded in a Web page can play an animation on screen or sing a song, but cannot access their personal data, file system, or network. The security features of the runtime thus enable legitimate Internet-deployed software to be exceptionally feature rich.  
  
 The runtime also enforces code robustness by implementing a strict type-and-code-verification infrastructure called the common type system (CTS). The CTS ensures that all managed code is self-describing. The various Microsoft and third-party language compilers generate managed code that conforms to the CTS. This means that managed code can consume other managed types and instances, while strictly enforcing type fidelity and type safety.  
  
 In addition, the managed environment of the runtime eliminates many common software issues. For example, the runtime automatically handles object layout and manages references to objects, releasing them when they are no longer being used. This automatic memory management resolves the two most common application errors, memory leaks and invalid memory references.  
  
 The runtime also accelerates developer productivity. For example, programmers can write applications in their development language of choice, yet take full advantage of the runtime, the class library, and components written in other languages by other developers. Any compiler vendor who chooses to target the runtime can do so. Language compilers that target the .NET Framework make the features of the .NET Framework available to existing code written in that language, greatly easing the migration process for existing applications.  
  
 While the runtime is designed for the software of the future, it also supports software of today and yesterday. Interoperability between managed and unmanaged code enables developers to continue to use necessary COM components and DLLs.  
  
 The runtime is designed to enhance performance. Although the common language runtime provides many standard runtime services, managed code is never interpreted. A feature called just-in-time (JIT) compiling enables all managed code to run in the native machine language of the system on which it is executing. Meanwhile, the memory manager removes the possibilities of fragmented memory and increases memory locality-of-reference to further increase performance.  
  
 Finally, the runtime can be hosted by high-performance, server-side applications, such as Microsoft SQL Server and Internet Information Services (IIS). This infrastructure enables you to use managed code to write your business logic, while still enjoying the superior performance of the industry's best enterprise servers that support runtime hosting.  
  
## .NET Framework Class Library  
 The .NET Framework class library is a collection of reusable types that tightly integrate with the common language runtime. The class library is object oriented, providing types from which your own managed code can derive functionality. This not only makes the .NET Framework types easy to use, but also reduces the time associated with learning new features of the .NET Framework. In addition, third-party components can integrate seamlessly with classes in the .NET Framework.  
  
 For example, the .NET Framework collection classes implement a set of interfaces that you can use to develop your own collection classes. Your collection classes will blend seamlessly with the classes in the .NET Framework.  
  
 As you would expect from an object-oriented class library, the .NET Framework types enable you to accomplish a range of common programming tasks, including tasks such as string management, data collection, database connectivity, and file access. In addition to these common tasks, the class library includes types that support a variety of specialized development scenarios. For example, you can use the .NET Framework to develop the following types of applications and services:  
  
-   Console applications. See [Building Console Applications](../../../docs/standard/building-console-apps.md).  
  
-   Windows GUI applications (Windows Forms). See [Windows Forms](../../../docs/framework/winforms/index.md).  
  
-   Windows Presentation Foundation (WPF) applications. See [Windows Presentation Foundation](../../../docs/framework/wpf/index.md).  
  
-   ASP.NET applications. See [Web Applications with ASP.NET](../../../docs/framework/develop-web-apps-with-aspnet.md).  
  
-   Windows services. See [Introduction to Windows Service Applications](../../../docs/framework/windows-services/introduction-to-windows-service-applications.md).  
  
-   Service-oriented applications using Windows Communication Foundation (WCF). See [Service-Oriented Applications with WCF](../../../docs/framework/wcf/index.md).  
  
-   Workflow-enabled applications using Windows Workflow Foundation (WF). See [Building Workflows in the .NET Framework](http://msdn.microsoft.com/en-us/cbf3880f-dc7b-466d-b808-1109b1223f4a).  
  
 For example, the Windows Forms classes are a comprehensive set of reusable types that vastly simplify Windows GUI development. If you write an ASP.NET Web Form application, you can use the Web Forms classes.  
  
## See Also  
 [System Requirements](../../../docs/framework/get-started/system-requirements.md)   
 [Installation guide](../../../docs/framework/install/index.md)   
 [Development Guide](../../../docs/framework/development-guide.md)   
 [Tools](../../../docs/framework/tools/index.md)   
 [.NET Framework Samples](http://msdn.microsoft.com/en-us/177055f8-4a1f-43e7-aee6-995c196079b1)   
 [.NET Framework Class Library](http://go.microsoft.com/fwlink/?LinkID=227195)