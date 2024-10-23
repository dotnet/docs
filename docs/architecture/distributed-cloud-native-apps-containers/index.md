---
title: Architecture for Distributed Cloud-Native Apps with .NET & Containers
description: Learn how to build distributed cloud-native applications with .NET and containers.
ms.date: 10/23/2024
---

# Architecture for Distributed Cloud-Native Apps with .NET & Containers

![cover image Architecture for Distributed Cloud-Native Apps with .NET & Containers](https://placehold.co/613x793/cyan/magenta.png?text=James,%20we%20need%20this!&font=roboto)

DOWNLOAD available at: <https://aka.ms/aspireebook>

**EDITION v1.0**

PUBLISHED BY

Microsoft Developer Division, .NET, and Visual Studio product teams

A division of Microsoft Corporation

One Microsoft Way

Redmond, Washington 98052-6399

Copyright &copy; 2024 by Microsoft Corporation

All rights reserved. No part of the contents of this book may be reproduced or transmitted in any form or by any means without the written permission of the publisher.

This book is provided "as-is" and expresses the author's views and opinions. The views, opinions, and information expressed in this book, including URL and other Internet website references, may change without notice.

Some examples depicted herein are provided for illustration only and are fictitious. No real association or connection is intended or should be inferred.

Microsoft and the trademarks listed at <https://www.microsoft.com> on the "Trademarks" webpage are trademarks of the Microsoft group of companies.

All other marks and logos are property of their respective owners.

Authors:

<!-- TODO: James to fill in... -->

Participants and Reviewers:

<!-- TODO: James to fill in... -->

> **[David Pine](https://github.com/IEvangelist)**, Senior Content Developer, .NET Aspire, Microsoft

Editors:

> **[David Pine](https://github.com/IEvangelist)**, Senior Content Developer, .NET Aspire, Microsoft

## Acknowledgments

This book was inspired by the [.NET Microservices: Architecture for Containerized .NET Applications](https://dotnet.microsoft.com/download/e-book/microservices-architecture/pdf) and [Architecting Cloud Native .NET Applications for Azure](https://dotnet.microsoft.com/download/e-book/cloud-native-azure/pdf) eBooks. Some chapters were adapted from these eBooks to provide a more focused and in-depth look at building enterprise applications using .NET Aspire.

## Introduction

With the advent of .NET Aspire, it's never been a better time to be a .NET developer who builds distributed cloud-native apps. .NET Aspire is an opinionated, cloud ready stack for building observable, production ready, distributed applications.​ .NET Aspire is delivered through a collection of NuGet packages that handle specific cloud-native concerns. Cloud-native apps often consist of small, interconnected pieces or microservices rather than a single, monolithic code base. Cloud-native apps generally consume a large number of services, such as databases, messaging, and caching.

## Who should use the book

This book is for .NET developers that want to learn how to architect and build distributed cloud-native applications using .NET Aspire. The book assumes that you have a basic understanding of .NET and .NET Aspire. If you are new to .NET Aspire, you can learn more about it in the [Building your first app](/dotnet/aspire/get-started/build-your-first-aspire-app) guide in the .NET Aspire documentation.

## How to use the book

<!-- TODO: James to fill in... -->

## What this book doesn't cover

<!-- TODO: James to fill in... -->

### Additional resources

For official .NET Aspire content, see [.NET Aspire docs](/dotnet/aspire). .NET Aspire is developed as an open-source project and is available on GitHub at [dotnet/aspire](https://github.com/dotnet/aspire). For code samples developed with .NET Aspire, see the [dotnet/aspire-samples](https://github.com/dotnet/aspire-samples) repo.

[!INCLUDE [feedback](../includes/feedback.md)]

>[!div class="step-by-step"]
>[Next](introduction-to-cloud-native-development/introduction-to-cloud-native-applications.md)
