---
title: System.Globalization.CultureInfo.CurrentUICulture property
description: Learn about the System.Globalization.CultureInfo.CurrentUICulture property.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Globalization.CultureInfo.CurrentUICulture property

[!INCLUDE [context](includes/context.md)]

The <xref:System.Globalization.CultureInfo.CurrentUICulture> property is a per-thread property. That is, each thread has its own current UI culture. This property is equivalent to retrieving or setting the <xref:System.Globalization.CultureInfo> object assigned to the `System.Threading.Thread.CurrentThread.CurrentUICulture` property. When a thread is started, its UI culture is initially determined as follows:

- By retrieving the culture that is specified by the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> property in the application domain in which the thread is executing, if the property value is not `null`.

- If the thread is a thread pool thread that is executing a task-based asynchronous operation and the app targets the .NET Framework 4.6 or a later version of the .NET Framework, its UI culture is determined by the UI culture of the calling thread. The following example changes the current UI culture to Portuguese (Brazil) and launches six tasks, each of which displays its thread ID, its task ID, and its current UI culture. Each of the tasks (and the threads) has inherited the UI culture of the calling thread.

  :::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentUICulture/csharp/Async1.cs" id="Snippet14":::
  :::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentUICulture/vb/Async1.vb" id="Snippet14":::

  For more information, see the "Culture and task-based asynchronous operations" section in the <xref:System.Globalization.CultureInfo> documentation.

- By calling the Windows `GetUserDefaultUILanguage` function.

To change the user interface culture used by a thread, set the <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=nameWithType> property to the new culture. If you explicitly change a thread's UI culture in this way, that change persists if the thread crosses application domain boundaries.

> [!NOTE]
> If you set the property value to a <xref:System.Globalization.CultureInfo> object that represents a new culture, the value of the `Thread.CurrentThread.CurrentCulture` property also changes.

## Get the current UI culture

The <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property is a per-thread setting; that is, each thread can have its own UI culture. You get the UI culture of the current thread by retrieving the value of the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property, as the following example illustrates.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentUICulture/csharp/Get1.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentUICulture/vb/Get1.vb" id="Snippet5":::

You can also retrieve the value of the current thread's UI culture from the <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=nameWithType> property.

## Explicitly set the current UI culture

Starting with .NET Framework 4.6, you can change the current UI culture by assigning a <xref:System.Globalization.CultureInfo> object that represents the new culture to the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property. The current UI culture can be set to either a specific culture (such as en-US or de-DE) or to a neutral culture (such as en or de). The following example sets the current UI culture to fr-FR or French (France).

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentUICulture/csharp/currentuiculture1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentUICulture/vb/currentuiculture1.vb" id="Snippet1":::

In a multithreaded application, you can explicitly set the UI culture of any thread by assigning a <xref:System.Globalization.CultureInfo> object that represents that culture to the thread's <xref:System.Threading.Thread.CurrentUICulture%2A?displayProperty=nameWithType> property. If the thread whose culture you want to set is the current thread, you can assign the new culture to the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property. When the UI culture of a thread is set explicitly, that thread retains the same culture even if it crosses application domain boundaries and executes code in another application domain.

## Implicitly set the current UI culture

When a thread, including the main application thread, is first created, by default its current UI culture is set as follows:

- By using the culture defined by the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> property for the current application domain if the property value is not `null`.
- By using the system's default culture. On systems that use the Windows operating system, the common language runtime calls the Windows `GetUserDefaultUILanguage` function to set the current  UI culture. `GetUserDefaultUILanguage` returns the default UI culture set by the user. If the user has not set a default UI language, it returns the culture originally installed on the system.

If the thread crosses application boundaries and executes code in another application domain, its culture is determined in the same way as that of a newly created thread.

Note that if you set a specific UI culture that is different from the system-installed UI culture or the user's preferred UI culture, and your application starts multiple threads, the current UI culture of those threads will be the culture returned by the `GetUserDefaultUILanguage` function, unless you assign a culture to the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentUICulture> property in the application domain in which the thread is executing.

## Security considerations

Changing the culture of the current thread requires a <xref:System.Security.Permissions.SecurityPermission> permission with the <xref:System.Security.Permissions.SecurityPermissionFlag.ControlThread> value set.

> [!CAUTION]
> Manipulating threads is dangerous because of the security state associated with threads. Therefore, this permission should be given only to trustworthy code, and then only as necessary. You cannot change thread culture in semi-trusted code.

## The current UI culture and UWP apps

In Universal Windows Platform (UWP) apps, the <xref:System.Globalization.CultureInfo.CurrentUICulture> property is read-write, just as it is in .NET Framework and .NET Core apps; you can use it both to get and to set the current culture. However, UWP apps do not distinguish between the current culture and the current UI culture. The <xref:System.Globalization.CultureInfo.CurrentCulture%2A> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> properties map to the first value in the [Windows.ApplicationModel.Resources.Core.ResourceManager.DefaultContext.Languages](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#properties_) collection.

In .NET Framework and .NET Core apps, the current UI culture is a per-thread setting, and the <xref:System.Globalization.CultureInfo.CurrentUICulture> property reflects the UI culture of the current thread only. In UWP apps, the current culture maps to the [Windows.ApplicationModel.Resources.Core.ResourceManager.DefaultContext.Languages](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#properties_) property, which is a global setting. Setting the <xref:System.Globalization.CultureInfo.CurrentCulture> property changes the culture of the entire app; culture cannot be set on a per-thread basis.
