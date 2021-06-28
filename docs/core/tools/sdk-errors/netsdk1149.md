---
title: "NETSDK1149: Built-in WinRT support not provided in .NET 5+"
description: How to reference a component with built-in WinRT support from an app that targets .NET 5 or later.
author: tdykstra
ms.author: tdykstra
ms.topic: error-reference
ms.date: 06/28/2021
f1_keywords:
- NETSDK1149
---
# NETSDK1149: Built-in WinRT support not provided in .NET 5+"

You're trying to reference a component that requires WinRT in an application that targets .NET 5 or a later version. These .NET versions don't have built-in support for WinRT. The full error message is similar to the following example:

> *\<Component name>* cannot be referenced because it uses built-in support for WinRT, which is no longer supported in .NET 5 and higher.  An updated version of the component supporting .NET 5 is needed.

You can resolve this error by changing the application's Target Framework Moniker (TFM). For more information, see [Call Windows Runtime APIs in desktop apps](/windows/apps/desktop/modernize/desktop-to-uwp-enhance).
