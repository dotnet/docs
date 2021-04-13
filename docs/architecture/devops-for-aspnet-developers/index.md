---
title: DevOps for ASP.NET Core Developers
author: CamSoper
description: A guide that provides end-to-end guidance on building a DevOps pipeline for an ASP.NET Core app hosted in Azure.
ms.author: casoper
ms.date: 04/13/2021
ms.custom: "devx-track-csharp, mvc, seodec18"
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: azure/devops/index
---
# DevOps for ASP.NET Core Developers

[![Cover Image](./media/cover-large.png)](https://aka.ms/devopsbook)

**EDITION v1.1.0**

Refer [changelog](https://aka.ms/devops-ebook-changelog) for the book updates and community contributions.

This guide is available as a [downloadable PDF e-book](https://aka.ms/devopsbook).

PUBLISHED BY

Microsoft Developer Division, .NET, and Visual Studio product teams

A division of Microsoft Corporation

One Microsoft Way

Redmond, Washington 98052-6399

Copyright &copy; 2021 by Microsoft Corporation

All rights reserved. No part of the contents of this book may be reproduced or transmitted in any form or by any means without the written permission of the publisher.

This book is provided "as-is" and expresses the author's views and opinions. The views, opinions, and information expressed in this book, including URL and other Internet website references, may change without notice.

Some examples depicted herein are provided for illustration only and are fictitious. No real association or connection is intended or should be inferred.

Microsoft and the trademarks listed at <https://www.microsoft.com> on the "Trademarks" webpage are trademarks of the Microsoft group of companies.

Mac and macOS are trademarks of Apple Inc.

The Docker whale logo is a registered trademark of Docker, Inc. Used by permission.

All other marks and logos are property of their respective owners.

## Credits

Authors:

> [Cam Soper](https://twitter.com/camsoper)
>
> [Scott Addie](https://twitter.com/scottaddie)
>
> [Colin Dembovsky](https://twitter.com/colindembovsky)

## Welcome

Welcome to the Azure Development Lifecycle guide for .NET! This guide introduces the basic concepts of building a development lifecycle around Azure using .NET tools and processes. After finishing this guide, you'll reap the benefits of a mature DevOps toolchain.

## Who this guide is for

You should be an experienced ASP.NET Core developer (200-300 level). You don't need to know anything about Azure, as we'll cover that in this introduction. This guide may also be useful for DevOps engineers who are more focused on operations than development.

This guide targets Windows developers. However, Linux and macOS are fully supported by .NET Core. To adapt this guide for Linux/macOS, watch for callouts for Linux/macOS differences.

## What this guide doesn't cover

This guide is focused on an end-to-end continuous deployment experience for .NET developers. It's not an exhaustive guide to all things Azure, and it doesn't focus extensively on .NET APIs for Azure services. The emphasis is all around continuous integration, deployment, monitoring, and debugging. Near the end of the guide, recommendations for next steps are offered. Included in the suggestions are Azure platform services that are useful to ASP.NET Core developers.

## What's in this guide

### [Tools and downloads](xref:azure/devops/tools-and-downloads)

Learn where to acquire the tools used in this guide.

### [Deploy to App Service](xref:azure/devops/deploy-to-app-service)

Learn the various methods for deploying an ASP.NET Core app to Azure App Service.

### [Continuous integration and deployment with Azure DevOps](xref:azure/devops/cicd)

Build an end-to-end continuous integration and deployment solution for your ASP.NET Core app with GitHub, Azure DevOps Services, and Azure.

### [Continuous integration and deployment with GitHub Actions](xref:azure/devops/github-actions)

Build an end-to-end continuous integration and deployment solution for your ASP.NET Core app with GitHub, GitHub Actions, and Azure, including code scanning for security and quality using CodeQL.

### [Monitor and debug](xref:azure/devops/monitor)

Use Azure's tools to monitor, troubleshoot, and tune your application.

### [Next steps](xref:azure/devops/next-steps)

Other learning paths for the ASP.NET Core developer learning Azure.

## Additional introductory reading

If this is your first exposure to cloud computing, these articles explain the basics.

* [What is Cloud Computing?](https://azure.microsoft.com/overview/what-is-cloud-computing/)
* [Examples of Cloud Computing](https://azure.microsoft.com/overview/examples-of-cloud-computing/)
* [What is IaaS?](https://azure.microsoft.com/overview/what-is-iaas/)
* [What is PaaS?](https://azure.microsoft.com/overview/what-is-paas/)

>[!div class="step-by-step"]
>[Next](tools-and-downloads.md)
