---
title: Native interoperability - .NET
description: Learn how to interface with native components in .NET.
author: jkoritzinsky
ms.author: jekoritz
ms.date: 01/18/2019
---
# Native interoperability

The following articles show the various ways of doing "native interoperability" in .NET.

There are a few reasons why you'd want to call into native code:

* Operating systems come with a large volume of APIs that aren't present in the managed class libraries. A prime example for this scenario would be access to hardware or operating system management functions.
* Communicating with other components that have or can produce C-style ABIs (native ABIs), such as Java code that is exposed via [Java Native Interface (JNI)](https://docs.oracle.com/javase/8/docs/technotes/guides/jni/) or any other managed language that could produce a native component.
* On Windows, most of the software that gets installed, such as the Microsoft Office suite, registers COM components that represent their programs and allow developers to automate them or use them. This also requires native interoperability.

The previous list doesn't cover all of the potential situations and scenarios in which the developer would want/like/need to interface with native components. .NET class library, for instance, uses the native interoperability support to implement a fair number of its APIs, like console support and manipulation, file system access and others. However, it's important to note that there's an option if needed.

> [!NOTE]
> Most of the examples in this section will be presented for all three supported platforms for .NET Core (Windows, Linux and macOS). However, for some short and illustrative examples, just one sample is shown that uses Windows filenames and extensions (that is, "dll" for libraries). This doesn't mean that those features aren't available on Linux or macOS, it was done merely for convenience sake.

## See also

- [Platform Invoke (P/Invoke)](pinvoke.md)
- [Type marshalling](type-marshalling.md)
