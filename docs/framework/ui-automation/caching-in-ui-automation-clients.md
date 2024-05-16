---
title: "Caching in UI Automation Clients"
description: Get details about caching in UI Automation clients in .NET. Caching is defined as the pre-fetching of data.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation caching in clients"
  - "caching, UI Automation clients"
ms.assetid: 94c15031-4975-43cc-bcd5-c9439ed21c9c
---
# Caching in UI Automation Clients

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces caching of UI Automation properties and control patterns.

 In UI Automation, caching means pre-fetching of data. The data can then be accessed without further cross-process communication. Caching is typically used by UI Automation client applications to retrieve properties and control patterns in bulk. Information is then retrieved from the cache as needed. The application updates the cache periodically, usually in response to events signifying that something in the user interface (UI) has changed.

 The benefits of caching are most noticeable with Windows Presentation Foundation (WPF) controls and custom controls that have server-side UI Automation providers. There is less benefit when accessing client-side providers such as the default providers for Win32 controls.

 Caching occurs when the application activates a <xref:System.Windows.Automation.CacheRequest> and then uses any method or property that returns an <xref:System.Windows.Automation.AutomationElement>; for example, <xref:System.Windows.Automation.AutomationElement.FindFirst%2A>, <xref:System.Windows.Automation.AutomationElement.FindAll%2A>. The methods of the <xref:System.Windows.Automation.TreeWalker> class are an exception; caching is only done if a <xref:System.Windows.Automation.CacheRequest> is specified as a parameter (for example, <xref:System.Windows.Automation.TreeWalker.GetFirstChild%28System.Windows.Automation.AutomationElement%2CSystem.Windows.Automation.CacheRequest%29?displayProperty=nameWithType>.

 Caching also occurs when you subscribe to an event while a <xref:System.Windows.Automation.CacheRequest> is active. The <xref:System.Windows.Automation.AutomationElement> passed to your event handler as the source of an event contains the cached properties and patterns specified by the original <xref:System.Windows.Automation.CacheRequest>. Any changes made to the <xref:System.Windows.Automation.CacheRequest> after you subscribe to the event have no effect.

 The UI Automation properties and control patterns of an element can be cached.

## Options for Caching

 The <xref:System.Windows.Automation.CacheRequest> specifies the following options for caching.

### Properties to Cache

 You can specify properties to cache by calling <xref:System.Windows.Automation.CacheRequest.Add%28System.Windows.Automation.AutomationProperty%29> for each property before activating the request.

### Control Patterns to Cache

 You can specify control patterns to cache by calling <xref:System.Windows.Automation.CacheRequest.Add%28System.Windows.Automation.AutomationPattern%29> for each pattern before activating the request. When a pattern is cached, its properties are not automatically cached; you must specify the properties you want cached by using <xref:System.Windows.Automation.CacheRequest.Add%2A?displayProperty=nameWithType>.

### Scope and Filtering of Caching

 You can specify the elements whose properties and patterns you want to cache by setting the <xref:System.Windows.Automation.CacheRequest.TreeScope%2A?displayProperty=nameWithType> property before activating the request. The scope is relative to the elements that are retrieved while the request is active. For example, if you set only <xref:System.Windows.Automation.TreeScope.Children>, and then retrieve an <xref:System.Windows.Automation.AutomationElement>, the properties and patterns of children of that element are cached, but not those of the element itself. To ensure that caching is done for the retrieved element itself, you must include <xref:System.Windows.Automation.TreeScope.Element> in the <xref:System.Windows.Automation.CacheRequest.TreeScope%2A> property. It is not possible to set the scope to <xref:System.Windows.Automation.TreeScope.Parent> or <xref:System.Windows.Automation.TreeScope.Ancestors>. However, a parent element can be cached when a child element is cached. For more information, see [Retrieving Cached Children and Parents](#retrieving-cached-children-and-parents).

 The extent of caching is also affected by the <xref:System.Windows.Automation.CacheRequest.TreeFilter%2A?displayProperty=nameWithType> property. By default, caching is performed only for elements that appear in the control view of the UI Automation tree. However, you can change this property to apply caching to all elements, or only to elements that appear in the content view.

### Strength of the Element References

 When you retrieve an <xref:System.Windows.Automation.AutomationElement>, by default you have access to all properties and patterns of that element, including those that were not cached. However, for greater efficiency you can specify that the reference to the element refers to cached data only, by setting the <xref:System.Windows.Automation.CacheRequest.AutomationElementMode%2A> property of the <xref:System.Windows.Automation.CacheRequest> to <xref:System.Windows.Automation.AutomationElementMode.None>. In this case, you do not have access to any non-cached properties and patterns of retrieved elements. This means that you cannot access any properties through <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A> or the `Current` property of <xref:System.Windows.Automation.AutomationElement> or any control pattern; nor can you retrieve a pattern by using <xref:System.Windows.Automation.AutomationElement.GetCurrentPattern%2A> or <xref:System.Windows.Automation.AutomationElement.TryGetCurrentPattern%2A>. On cached patterns, you can call methods that retrieve array properties, such as <xref:System.Windows.Automation.SelectionPattern.SelectionPatternInformation.GetSelection%2A?displayProperty=nameWithType>, but not any that perform actions on the control, such as <xref:System.Windows.Automation.InvokePattern.Invoke%2A?displayProperty=nameWithType>.

 An example of an application that might not need full references to objects is a screen reader, which would prefetch the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name%2A> and <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.ControlType%2A> properties of elements in a window but would not need the <xref:System.Windows.Automation.AutomationElement> objects themselves.

## Activating the CacheRequest

 Caching is performed only when <xref:System.Windows.Automation.AutomationElement> objects are retrieved while a <xref:System.Windows.Automation.CacheRequest> is active for the current thread. There are two ways to activate a <xref:System.Windows.Automation.CacheRequest>.

 The usual way is to call <xref:System.Windows.Automation.CacheRequest.Activate%2A>. This method returns an object that implements <xref:System.IDisposable>. The request remains active as long as the <xref:System.IDisposable> object exists. The easiest way to control the lifetime of the object is to enclose the call within a `using` (C#) or `Using` (Visual Basic) block. This ensures that the request will be popped from the stack even if an exception is raised.

 Another way, which is useful when you wish to nest cache requests, is to call <xref:System.Windows.Automation.CacheRequest.Push%2A>. This puts the request on a stack and activates it. The request remains active until it is removed from the stack by <xref:System.Windows.Automation.CacheRequest.Pop%2A>. The request becomes temporarily inactive if another request is pushed onto the stack; only the top request on the stack is active.

## Retrieving Cached Properties

 You can retrieve the cached properties of an element through the following methods and properties.

- <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A>

- <xref:System.Windows.Automation.AutomationElement.Cached%2A>

 An exception is raised if the requested property is not in the cache.

 <xref:System.Windows.Automation.AutomationElement.Cached%2A>, like <xref:System.Windows.Automation.AutomationElement.Current%2A>, exposes individual properties as members of a structure. However, you do not need to retrieve this structure; you can access the individual properties directly. For example, the <xref:System.Windows.Automation.AutomationElement.AutomationElementInformation.Name%2A> property can be obtained from `element.Cached.Name`, where `element` is an <xref:System.Windows.Automation.AutomationElement>.

## Retrieving Cached Control Patterns

 You can retrieve the cached control patterns of an element through the following methods.

- <xref:System.Windows.Automation.AutomationElement.GetCachedPattern%2A>

- <xref:System.Windows.Automation.AutomationElement.TryGetCachedPattern%2A>

 If the pattern is not in the cache, <xref:System.Windows.Automation.AutomationElement.GetCachedPattern%2A> raises an exception, and <xref:System.Windows.Automation.AutomationElement.TryGetCachedPattern%2A> returns `false`.

 You can retrieve the cached properties of a control pattern by using the `Cached` property of the pattern object. You can also retrieve the current values through the `Current` property, but only if <xref:System.Windows.Automation.AutomationElementMode.None> was not specified when the <xref:System.Windows.Automation.AutomationElement> was retrieved. (<xref:System.Windows.Automation.AutomationElementMode.Full> is the default value, and this permits access to the current values.)

## Retrieving Cached Children and Parents

 When you retrieve an <xref:System.Windows.Automation.AutomationElement> and request caching for children of that element through the <xref:System.Windows.Automation.CacheRequest.TreeScope%2A> property of the request, it is subsequently possible to get the child elements from the <xref:System.Windows.Automation.AutomationElement.CachedChildren%2A> property of the element you retrieved.

 If <xref:System.Windows.Automation.TreeScope.Element> was included in the scope of the cache request, the root element of the request is subsequently available from the <xref:System.Windows.Automation.AutomationElement.CachedParent%2A> property of any of the child elements.

> [!NOTE]
> You cannot cache parents or ancestors of the root element of the request.

## Updating the Cache

 The cache is valid only as long as nothing changes in the UI. Your application is responsible for updating the cache, typically in response to events.

 If you subscribe to an event while a <xref:System.Windows.Automation.CacheRequest> is active, you obtain an <xref:System.Windows.Automation.AutomationElement> with an updated cache as the source of the event whenever your event-handler delegate is called. You can also update cached information for an element by calling <xref:System.Windows.Automation.AutomationElement.GetUpdatedCache%2A>. You can pass in the original <xref:System.Windows.Automation.CacheRequest> to update all information that was previously cached.

 Updating the cache does not alter the properties of any existing <xref:System.Windows.Automation.AutomationElement> references.

## See also

- [UI Automation Events for Clients](ui-automation-events-for-clients.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
- [FetchTimer Sample](/previous-versions/dotnet/netframework-3.5/ms771456(v=vs.90))
