---
title: Decision table. .NET frameworks to use for Docker
description: .NET Microservices Architecture for Containerized .NET Applications | Decision table, .NET frameworks to use for Docker
ms.date: 09/11/2018
---
# Decision table: .NET frameworks to use for Docker

The following decision table summarizes whether to use .NET Framework or .NET Core. Remember that for Linux containers, you need Linux-based Docker hosts (VMs or servers) and that for Windows Containers you need Windows Server based Docker hosts (VMs or servers).

> [!IMPORTANT]
> Your development machines will run one Docker host, either Linux or Windows. Related microservices that you want to run and test together in one solution will all need to run on the same container platform.

<table>
<thead>
<tr class="header">
<th><strong>Architecture / App Type</strong></th>
<th><strong>Linux containers</strong></th>
<th><strong>Windows Containers</strong></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td>Microservices on containers</td>
<td>.NET Core</td>
<td>.NET Core</td>
</tr>
<tr class="even">
<td>Monolithic app</td>
<td>.NET Core</td>
<td><p>.NET Framework</p>
<p>.NET Core</p></td>
</tr>
<tr class="odd">
<td>Best-in-class performance and scalability</td>
<td>.NET Core</td>
<td>.NET Core</td>
</tr>
<tr class="even">
<td>Windows Server legacy app ("brown-field") migration to containers</td>
<td>--</td>
<td>.NET Framework</td>
</tr>
<tr class="odd">
<td>New container-based development ("green-field")</td>
<td>.NET Core</td>
<td>.NET Core</td>
</tr>
<tr class="even">
<td>ASP.NET Core</td>
<td>.NET Core</td>
<td><p>.NET Core (recommended)</p>
<p>.NET Framework</p></td>
</tr>
<tr class="odd">
<td>ASP.NET 4 (MVC 5, Web API 2, and Web Forms)</td>
<td>--</td>
<td>.NET Framework</td>
</tr>
<tr class="even">
<td>SignalR services</td>
<td>.NET Core 2.1 or higher version</td>
<td><p>.NET Framework</p>
<p>.NET Core 2.1 or higher version</p></td>
</tr>
<tr class="odd">
<td>WCF, WF, and other legacy frameworks</td>
<td>WCF in .NET Core (only the WCF client library)</td>
<td><p>.NET Framework</p>
<p>WCF in .NET Core (only the WCF client library)</p></td>
</tr>
<tr class="even">
<td>Consumption of Azure services</td>
<td><p>.NET Core</p>
<p>(eventually all Azure services will provide client SDKs for .NET Core)</p></td>
<td><p>.NET Framework</p>
<p>.NET Core</p>
<p>(eventually all Azure services will provide client SDKs for .NET Core)</p></td>
</tr>
</tbody>
</table>

>[!div class="step-by-step"]
>[Previous](net-framework-container-scenarios.md)
>[Next](net-container-os-targets.md)
