---
title: What OS to target with .NET containers
description: .NET Microservices Architecture for Containerized .NET Applications | What OS to target with .NET containers
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 09/11/2018
---
# What OS to target with .NET containers

Given the diversity of operating systems supported by Docker and the differences between .NET Framework and .NET Core, you should target a specific OS and specific versions depending on the framework you are using.

For Windows, you can use Windows Server Core or Windows Nano Server. These Windows versions provide different characteristics (IIS in Windows Server Core versus a self-hosted web server like Kestrel in Nano Server) that might be needed by .NET Framework or .NET Core, respectively.

For Linux, multiple distros are available and supported in official .NET Docker images (like Debian).

In Figure 3-1 you can see the possible OS version depending on the .NET framework used.

![When deploying legacy .NET Framework applications you have to targe Windows Server Core, compatible with legacy apps and IIS, has a larger image. When deploying .NET Core applications, you can target Windows Nano Server, which is cloud optimized, uses Kestrel and is smaller and starts faster. You can also target Linux, supporting Debian, Alpine and others. Also uses Kestrel and is smaller and starts faster.](./media/image1.png)

**Figure 3-1.** Operating systems to target depending on versions of the .NET framework

You can also create your own Docker image in cases where you want to use a different Linux distro or where you want an image with versions not provided by Microsoft. For example, you might create an image with ASP.NET Core running on the traditional .NET Framework and Windows Server Core, which is a not-so-common scenario for Docker.

When you add the image name to your Dockerfile file, you can select the operating system and version depending on the tag you use, as in the following examples:

<table>
<thead>
<tr class="header">
<th>Image</th>
<th>Comments</th>
</tr>
</thead>
<tbody>
<tr>
<td>microsoft/dotnet:2.1-runtime</td>
<td>.NET Core 2.1 multi-architecture: Supports Linux and Windows Nano Server depending on the Docker host.</td>
</tr>
<tr class="odd">
<td>microsoft/dotnet:2.1-aspnetcore-runtime</td>
<td><p>ASP.NET Core 2.1 multi-architecture: Supports Linux and Windows Nano Server depending on the Docker host.</p>
<p>The aspnetcore image has a few optimizations for ASP.NET Core.</p></td>
</tr>
<tr class="even">
<td>microsoft/dotnet:2.1-aspnetcore-runtime-alpine</td>
<td>.NET Core 2.1 runtime-only on Linux Alpine distro</td>
</tr>
<tr class="odd">
<td>microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803</td>
<td>.NET Core 2.1 runtime-only on Windows Nano Server (Windows Server version 1803)</td>
</tr>
</tbody>
</table>

>[!div class="step-by-step"]
[Previous](container-framework-choice-factors.md)
[Next](official-net-docker-images.md)
