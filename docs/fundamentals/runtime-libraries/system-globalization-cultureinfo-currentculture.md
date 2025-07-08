---
title: System.Globalization.CultureInfo.CurrentCulture property
description: Learn about the System.Globalization.CultureInfo.CurrentCulture property.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - VB
---
# System.Globalization.CultureInfo.CurrentCulture property

[!INCLUDE [context](includes/context.md)]

The <xref:System.Globalization.CultureInfo> object that's returned by the <xref:System.Globalization.CultureInfo.CurrentCulture> property and its associated objects determines the default format for dates, times, numbers, and currency values, the sorting order of text, casing conventions, and string comparisons.

The current culture is a property of the executing thread. When you set this property to a <xref:System.Globalization.CultureInfo> object that represents a new culture, the value of the `Thread.CurrentThread.CurrentCulture` property also changes. However, we recommend that you always use the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> property to retrieve and set the current culture.

The `CultureInfo` object that this property returns is read-only. That means you can't mutate the existing object, for example, by changing the `DateTimeFormat`. To change the date-time format or some other aspect of the current culture, create a new `CultureInfo` object and assign it to the property.

## How a thread's culture is determined

When a thread is started, its culture is initially determined as follows:

- By retrieving the culture that is specified by the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> property in the application domain in which the thread is executing, if the property value is not `null`.

- If the thread is a thread pool thread that is executing a task-based asynchronous operation, its culture is determined by the culture of the calling thread. The following example changes the current culture to Portuguese (Brazil) and launches six tasks, each of which displays its thread ID, its task ID, and its current culture. Each of the tasks (and the threads) has inherited the culture of the calling thread.

  :::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/csharp/Async1.cs" id="Snippet14":::
  :::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/vb/Async1.vb" id="Snippet14":::

  For more information, see [Culture and task-based asynchronous operations](system-globalization-cultureinfo.md#culture-and-task-based-asynchronous-operations).

- By calling the `GetUserDefaultLocaleName` function on Windows or the `uloc_getDefault` function from [ICU](https://icu-project.org/), which currently calls the POSIX `setlocale` function with category `LC_MESSAGES`, on Unix-like systems.

Note that if you set a specific culture that is different from the system-installed culture or the user's preferred culture, and your application starts multiple threads, the current culture of those threads will be the culture that is returned by the `GetUserDefaultLocaleName` function, unless you assign a culture to the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> property in the application domain in which the thread is executing.

For more information about how the culture of a thread is determined, see the "Culture and threads" section in the <xref:System.Globalization.CultureInfo> reference page.

## Get the current culture

The <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property is a per-thread setting; that is, each thread can have its own culture. You get the culture of the current thread by retrieving the value of the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property, as the following example illustrates.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/csharp/Get1.cs" id="Snippet5":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/vb/Get1.vb" id="Snippet5":::

## Set the CurrentCulture property explicitly

To change the culture that's used by an existing thread, you set the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property to the new culture. If you explicitly change a thread's culture in this way, that change persists if the thread crosses application domain boundaries. The following example changes the current thread culture to Dutch (Netherlands). It also shows that, when the current thread crosses application domain boundaries, its current culture remains changed.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/csharp/changeculture11.cs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/vb/changeculture11.vb" id="Snippet11":::

> [!NOTE]
> Changing the culture by using the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property requires a <xref:System.Security.Permissions.SecurityPermission> permission with the <xref:System.Security.Permissions.SecurityPermissionFlag.ControlThread> value set. Manipulating threads is dangerous because of the security state associated with threads. Therefore, this permission should be given only to trustworthy code, and then only as necessary. You cannot change thread culture in semi-trusted code.

Starting with .NET Framework 4, you can explicitly change the current thread culture to either a specific culture (such as French (Canada)) or a neutral culture (such as French). When a <xref:System.Globalization.CultureInfo> object represents a neutral culture, the values of <xref:System.Globalization.CultureInfo> properties such as <xref:System.Globalization.CultureInfo.Calendar%2A>, <xref:System.Globalization.CultureInfo.CompareInfo%2A>, <xref:System.Globalization.CultureInfo.DateTimeFormat%2A>, <xref:System.Globalization.CultureInfo.NumberFormat%2A>, and <xref:System.Globalization.CultureInfo.TextInfo%2A> reflect the specific culture that is associated with the neutral culture. For example, the dominant culture for the English neutral culture is English (United States); the dominant culture for the German culture is German (Germany). The following example illustrates the difference in formatting when the current culture is set to a specific culture, French (Canada), and a neutral culture, French.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/csharp/specific12.cs" id="Snippet12":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/vb/specific12.vb" id="Snippet12":::

You can also use the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property along with the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property to set the <xref:System.Globalization.CultureInfo.CurrentCulture> property of an ASP.NET application to the user's preferred culture, as the following example illustrates.

:::code language="csharp" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/csharp/aspculture13.cs" id="Snippet13":::
:::code language="vb" source="./snippets/System.Globalization/CultureInfo/CurrentCulture/vb/aspculture13.vb" id="Snippet13":::

## The current culture and user overrides

Windows allows users to override the standard property values of the <xref:System.Globalization.CultureInfo> object and its associated objects by using **Regional and Language Options** in Control Panel. The <xref:System.Globalization.CultureInfo> object returned by the <xref:System.Globalization.CultureInfo.CurrentCulture> property reflects these user overrides in the following cases:

- If the current thread culture is set implicitly by the Windows `GetUserDefaultLocaleName` function.

- If the current thread culture defined by the <xref:System.Globalization.CultureInfo.DefaultThreadCurrentCulture> property corresponds to the current Windows system culture.

- If the current thread culture is set explicitly to a culture returned by the <xref:System.Globalization.CultureInfo.CreateSpecificCulture%2A> method, and that culture corresponds to the current Windows system culture.

- If the current thread culture is set explicitly to a culture instantiated by the <xref:System.Globalization.CultureInfo.%23ctor(System.String)> constructor, and that culture corresponds to the current Windows system culture.

In some cases, particularly for server applications, setting the current culture to a <xref:System.Globalization.CultureInfo> object that reflects user overrides may be undesirable. Instead, you can set the current culture to a <xref:System.Globalization.CultureInfo> object that does not reflect user overrides in the following ways:

- By calling the <xref:System.Globalization.CultureInfo.%23ctor(System.String,System.Boolean)> constructor with a value of `false` for the `useUserOverride` argument.

- By calling the <xref:System.Globalization.CultureInfo.GetCultureInfo%2A> method, which returns a cached, read-only <xref:System.Globalization.CultureInfo> object.

## The current culture and UWP apps

In Universal Windows Platform (UWP) apps, the <xref:System.Globalization.CultureInfo.CurrentCulture> property is read-write, just as it is in .NET Framework and .NET Core apps; you can use it both to get and to set the current culture. However, UWP apps do not distinguish between the current culture and the current UI culture. The <xref:System.Globalization.CultureInfo.CurrentCulture%2A> and <xref:System.Globalization.CultureInfo.CurrentUICulture%2A> properties map to the first value in the [Windows.ApplicationModel.Resources.Core.ResourceManager.DefaultContext.Languages](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#properties_) collection.

In .NET Framework and .NET Core apps, the current culture is a per-thread setting, and the <xref:System.Globalization.CultureInfo.CurrentCulture> property reflects the culture of the current thread only. In UWP apps, the current culture maps to the [Windows.ApplicationModel.Resources.Core.ResourceManager.DefaultContext.Languages](/uwp/api/windows.applicationmodel.resources.core.resourcecontext#properties_) property, which is a global setting. Setting the <xref:System.Globalization.CultureInfo.CurrentCulture> property changes the culture of the entire app; culture cannot be set on a per-thread basis.
