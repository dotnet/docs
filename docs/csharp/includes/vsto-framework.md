---
author: BillWagner
ms.author: wiwagn
ms.topic: include
ms.date: 02/28/2023
---

> [!IMPORTANT]
> VSTO relies on the [.NET Framework](/dotnet/framework/get-started/overview). COM add-ins can also be written with the .NET Framework. Office Add-ins cannot be created with [.NET Core and .NET 5+](/dotnet/core/dotnet-five), the latest versions of .NET. This is because .NET Core/.NET 5+ cannot work together with .NET Framework in the same process and may lead to add-in load failures. You can continue to use .NET Framework to write VSTO and COM add-ins for Office. Microsoft will not be updating VSTO or the COM add-in platform to use .NET Core or .NET 5+. You can take advantage of .NET Core and .NET 5+, including ASP.NET Core, to create the server side of [Office Web Add-ins](/office/dev/add-ins/overview/office-add-ins).
