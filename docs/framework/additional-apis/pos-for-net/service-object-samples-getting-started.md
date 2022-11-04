---
title: "Service Object Samples: Getting Started"
description: "Service Object Samples: Getting Started (POS for .NET v1.14 SDK Documentation)"
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: pos-restored-from-archive
---

# Service Object Samples: Getting Started (POS for .NET v1.14 SDK Documentation)

Microsoft Point of Service for .NET (POS for .NET) provides a class tree which implements most of the functionality required by the Unified Point Of Service (UnifiedPOS) specification. In many cases, the Service Object developer only needs to implement the methods and properties required to operate the specific piece of hardware, for which the Service Object is being written.

This section provides a step-by-step guide to creating a simple, but functional sample Service Object for a Magnetic Strip Reader (MSR) device.

## In This Section

- [Setting up a Service Object Project](setting-up-a-service-object-project.md)
    Explains how to use Visual Studio to create a class library project with references to the appropriate POS for .NET assemblies.

- [Creating a Basic Service Object Code Template](creating-a-basic-service-object-code-template.md)
    Continues adding to the sample by modifying the code to create the necessary references, attributes, and methods to create a fundamental Service Object template.

- [Adding Plug and Play Support](adding-plug-and-play-support.md)
    Adds to the sample template by integrating Plug and Play support.

- [Creating a Service Object Sample](creating-a-service-object-sample.md)
    Describes how the sample code implements the methods needed to compile the sample. The Service Object will now be recognized by POS for .NET applications, but has no functionality.

- [Introducing Service Object Reader Threads](introducing-service-object-reader-threads.md)
    Introduces the concept of multithreaded programming in Service Objects. A sample thread helper class is included upon which other multithreaded Service Object samples are built.

- [Creating a Working, Multithreaded Service Object](creating-a-working-multithreaded-service-object.md)
    Implements a complete Magnetic Strip Reader (MSR) Service Object. It expands the appropriate methods from the earlier sample so that it returns data to the application. In addition, it uses the thread helper class from the previous section to start and stop a separate read thread.

## Related Sections

- [System Configuration](system-configuration.md)
    Describes how to configure POS for .NET to meet the needs of your installation.

- [Developing a POS Application](developing-a-pos-application.md)
    Explains how to create POS for .NET applications, the ultimate consumers of POS for .NET Service Objects.
