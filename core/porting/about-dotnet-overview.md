---
title: About .NET Overview
description: An overview of .NET with links to more detailed information.
author: stebon
ms.date: 3/4/2022
---
# Overview

.NET is a free, cross-platform, open-source developer platform for building many different types of applications.

- [What is .NET?](https://dotnet.microsoft.com/en-us/learn/dotnet/what-is-dotnet)
- [Why choose .NET?](https://dotnet.microsoft.com/en-us/platform/why-choose-dotnet)
- [Who uses.NET?](https://dotnet.microsoft.com/en-us/platform/customers)

## Naming convention

Since the last major version number for the .NET Framework is 4, .NET Core skipped version 4 and beginning with .NET 5 dropped ‘Core’ from the name since there will not be any versioning confusion between the two frameworks going forward.

## .NET Components

The .NET SDK contains several things such as tools needed for building .NET apps as well as the ASP.NET Core, .NET Desktop and .NET runtimes, these are all separate runtimes that are part of ‘.NET’.
See [SDK and runtimes](https://docs.microsoft.com/en-us/dotnet/core/introduction#sdk-and-runtimes)-to learn more.

## Cross platform

.NET (formerly known as .NET Core) is designed to be cross-platform. If your code doesn't depend on Windows-specific technologies, it may run on other platforms such as macOS, Linux, and Android. This includes project types like:

- Libraries
- Console-based tools
- Automation
- ASP.NET sites

.NET Framework is a Windows-only component. When your code uses Windows-specific technologies or APIs, such as Windows Forms and Windows Presentation Foundation (WPF), the code can still run on .NET but it won't run on other operating systems.

It's possible that your library or console-based application can be used cross-platform without changing much. When porting to .NET, you may want to take this into consideration and test your application on other platforms.

## The future of .NET Standard

.NET Standard is a formal specification of .NET APIs that are available on multiple .NET implementations. The motivation behind .NET Standard was to establish greater uniformity in the .NET ecosystem. Starting with .NET 5, a different approach to establishing uniformity has been adopted, and this new approach eliminates the need for .NET Standard in many scenarios. For more information, see [.NET 5 and .NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-5-and-net-standard).
.NET Standard 2.0 was the last version to support .NET Framework.

# See also

- [.NET Glossary](https://docs.microsoft.com/en-us/dotnet/standard/glossary)
