---
title: ASP.NET Core gRPC for WCF Developers - gRPC for WCF Developers
description: A WCF developer's guide to building gRPC applications with ASP.NET Core
author: markrendle
ms.date: 09/23/2019
---

# ASP.NET Core gRPC for WCF Developers

![cover image](./media/cover.png)

PUBLISHED BY

Microsoft Developer Division, .NET, and Visual Studio product teams

A division of Microsoft Corporation

One Microsoft Way

Redmond, Washington 98052-6399

Copyright © 2019 by Microsoft Corporation

All rights reserved. No part of the contents of this book may be reproduced or transmitted in any form or by any means without the written permission of the publisher.

This book is provided “as-is” and expresses the author’s views and opinions. The views, opinions and information expressed in this book, including URL and other Internet website references, may change without notice.

Some examples depicted herein are provided for illustration only and are fictitious. No real association or connection is intended or should be inferred.

Microsoft and the trademarks listed at https://www.microsoft.com on the “Trademarks” webpage are trademarks of the Microsoft group of companies.

The Docker whale logo is a registered trademark of Docker, Inc. Used by permission.

All other marks and logos are property of their respective owners.

Author:

> **Mark Rendle** - Chief Technical Officer - [Visual Recode](https://visualrecode.com)
>
> **Miranda Steiner** - Technical Author

Editors:

> **Maira Wenzel** - Sr Content Developer - Microsoft

## Introduction

Helping machines communicate with each other has been one of the primary preoccupations of the digital age. In particular, there is an ongoing effort to determine the optimal remote communication mechanism that will suit the interoperability demands of the current infrastructure. As you can imagine, that mechanism changes as either the demands or the infrastructure evolves.

The release of .NET Core 3.0 marks a shift in the way that Microsoft delivers remote communication solutions to developers who want to deliver services across a range of platforms. .NET Core doesn't offer Windows Communication Foundation (WCF) out of the box but, with the release of version ASP.NET Core 3.0, it does provide built-in gRPC functionality.

gRPC is a popular framework in the wider software community, used by developers across many programming languages for modern RPC scenarios. The community and the ecosystem are vibrant and active, with support for the gRPC protocol being added to infrastructure components like Kubernetes, service meshes, load balancers and more. These factors, as well as its performance, efficiency and cross-platform compatibility, make gRPC a natural choice for new apps and WCF apps moving to .NET Core.

## Purpose

TODO

## Who should use this guide

**UPDATE THIS**

The audience for this guide is WCF developers, development leads, and architects who are interested in migrating WCF solutions on .NET 4 and earlier to ASP.NET Core 3.0 using gRPC services.

This guide was written for developers working in .NET Framework or .NET Core who have previously used WCF and who are seeking to migrate their applications to a modern RPC environment for .NET Core 3.0 and later versions. The guide may also be of use more generally for developers upgrading or considering upgrading to .NET Core 3.0 who want to use the built-in gRPC tools.

## How you can use this guide

**UPDATE THIS**

This is a short introduction to building gRPC Services in ASP.NET Core 3.0 with particular reference to WCF as an analogous platform. It explains the principles of gRPC, relating each concept to the equivalent features of WCF, and offers guidance for migrating an existing WCF application to gRPC. It is also useful for developers who have experience of WCF and are looking to learn gRPC to build new services. The sample application can be used as a template or reference for your own projects, and you are free to copy and reuse code from the book or its samples.

Feel free to forward this guide to your team to help ensure a common understanding of these considerations and opportunities. Having everybody working from a common set of terminology and underlying principles helps ensure consistent application of architectural patterns and practices.

## References

- **gRPC web site**  
  <https://grpc.io>
- **Choosing between .NET Core and .NET Framework for server apps**  
  <https://docs.microsoft.com/dotnet/standard/choosing-core-framework-server>

>[!div class="step-by-step"]
>[Next](introduction.md)
