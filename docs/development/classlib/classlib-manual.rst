.NET Core Class Library Manual
==============================

.NET Core is a modern implementation of .NET. It includes many familiar .NET APIs, which are supported on Linux, OS X, Windows and other operating systems. It is both an implementation but also a standard API definition that can (and is) supported by other versions of .NET. 

.NET Core can be reasonably thought of as the next version of Portable Class Libraries (PCL). This means that code compiled for .NET Core can run on both .NET Core and other .NET versions that support the .NET Core API, such as the .NET Framework. For library developers, it can be a compelling API to target for supporting multiple platforms. 

This document will describe how to create .NET Core class libraries, both from the commandline and with Visual Studio. It will also explain how to create NuGet packages that support one or more platforms.

Targeting .NET Platforms
========================

Library developers often target one of more .NET platforms. The following table lists the set of platforms that you can target with .NET Core and/or PCL. There is an assumed column missing, which is explicitly targeting a platform. That choice is always available, and is the only choice in the case of the .NET Framework 3.5, as listed below.

+----------------------+------+-----+
| Platform             | Core | PCL |
+======================+======+=====+
| .NET Core            | x    | x   |
+----------------------+------+-----+
| .NET Framework 3.5   |      |     |
+----------------------+------+-----+
| .NET Framework 4.0   |      | x   |
+----------------------+------+-----+
| .NET Framework 4.5.x | x    | x   |
+----------------------+------+-----+
| .NET Framework 4.6.x | x    | x   |
+----------------------+------+-----+
| DNX Core 50          | x    |     |
+----------------------+------+-----+
| Silverlight          |      | x   |
+----------------------+------+-----+
| UWP 10               | x    | x   |
+----------------------+------+-----+
| WPS 8.x              | x    | x   |
+----------------------+------+-----+
| WP 8.1               | x    | x   |
+----------------------+------+-----+
| Xamarin.*            |      | x   |
+----------------------+------+-----+

You can target .NET Core or PCL if they support all of the platforms that you intend to target. .NET Core potentially exposes more APIs, so if you have the option of targeting it, it is a better choice. If you cannot target .NET Core or PCL for the platforms you need, you'll need to cross-compile with #ifdefs, which is an advanced option that will be described in more detail later.

Creating a .NET Core Library
============================

Brief explanation of .NET Core API versions + a link to an in-depth discussion.

Detailed explanation of how to target a .NET Core API version and a link to a documented example on GitHub.

How to find out which .NET Core API versions exist and which platforms they suppport.

Creating a PCL Library
======================

Brief explanation of how PCL is split into profiles and that this is somewhat similar to what .NET Core API versions model/describe. 

Detailed explanation of how to target a PCL profile and a link to a documented example on GitHub. 

Statement that you can alternately use Visual Studio to target PCL.

Packaging a Library within a NuGet Package
==========================================

Brief explanation of the structure of NuGet packages including cross-compilation (AKA having more than one folder).

Link to table of platforms (including PCL) and folder names.

More content here and likely broken into multiple sections.

Cross-compiling Strategies
==========================

Discussion of how you cross-compile (compile-time and package-time). There are likely a few good strategies. We should outline those.