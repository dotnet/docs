---
title: Native interoperability
description: Learn how to interface with native components in .NET.
author: blackdwarf
ms.author: ronpet
ms.date: 06/20/2016
ms.technology: dotnet-standard
---
# Native Interoperability

In this section, we will dive a little bit deeper into all three ways of doing "native interoperability" that are available using .NET.

There are a few of reasons why you would want to call into native code:

*   Operating Systems come with a large volume of APIs that are not present in the managed class libraries. A prime example for this would be access to hardware or operating system management functions.
*   Communicating with other components that have or can produce C-style ABIs (native ABIs). This covers, for example, Java code that is exposed via [Java Native Interface (JNI)](https://docs.oracle.com/javase/8/docs/technotes/guides/jni/) or any other managed language that could produce a native component.
*   On Windows, most of the software that gets installed, such as Microsoft Office suite, registers COM components that represent their programs and allow developers to automate them or use them. This also requires native interoperability.

Of course, the list above does not cover all of the potential situations and scenarios in which the developer would want/like/need to interface with native components. .NET class library, for instance, uses the native interoperability support to implement a fair number of its APIs, like console support and manipulation, file system access and others. However, it is important to note that there is an option, should one need it.

> [!NOTE]
> Most of the examples in this section will be presented for all three supported platforms for .NET Core (Windows, Linux and macOS). However, for some short and illustrative examples, just one sample is shown that uses Windows filenames and extensions (that is, "dll" for libraries). This does not mean that those features are not available on Linux or macOS, it was done merely for convenience sake.

Take a look at the pages below to see how you can use these .NET features to interop with native libraries.

- [Using Platform Invoke (P/Invoke) to call native functions.](./pinvoke.md)
- [How .NET marshals your managed types a native representation](./type-marshalling.md)
