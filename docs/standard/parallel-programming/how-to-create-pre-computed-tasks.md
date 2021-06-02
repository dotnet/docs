---
title: "Create pre-computed Task objects"
description: "In this article, you'll learn how to create pre-computed tasks."
ms.date: 05/04/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "tasks, creating pre-computed"
ms.assetid: a73eafa2-1f49-4106-a19e-997186029b58
---

# Create pre-computed tasks

In this article, you'll learn how to use the <xref:System.Threading.Tasks.Task.FromResult%2A?displayProperty=nameWithType> method to retrieve the results of asynchronous download operations that are held in a cache. The <xref:System.Threading.Tasks.Task.FromResult%2A> method returns a finished <xref:System.Threading.Tasks.Task%601> object that holds the provided value as its <xref:System.Threading.Tasks.Task%601.Result%2A> property. This method is useful when you perform an asynchronous operation that returns a <xref:System.Threading.Tasks.Task%601> object, and the result of that <xref:System.Threading.Tasks.Task%601> object is already computed.

## Example

The following example downloads strings from the web. It defines the `DownloadStringAsync` method. This method downloads strings from the web asynchronously. This example also uses a <xref:System.Collections.Concurrent.ConcurrentDictionary%602> object to cache the results of previous operations. If the input address is held in this cache, `DownloadStringAsync` uses the <xref:System.Threading.Tasks.Task.FromResult%2A> method to produce a <xref:System.Threading.Tasks.Task%601> object that holds the content at that address. Otherwise, `DownloadStringAsync` downloads the file from the web and adds the result to the cache.

:::code language="csharp" source="snippets/cs/DownloadCache.cs":::
:::code language="vb" source="snippets/vb/DownloadCache.vb":::

In the preceding example, the first time each url is downloaded, its value is stored in the cache. The <xref:System.Threading.Tasks.Task.FromResult%2A> method enables the `DownloadStringAsync` method to create <xref:System.Threading.Tasks.Task%601> objects that hold these pre-computed results. Subsequent calls to download the string return the cached values, and is much faster.

## See also

- [Task-based asynchronous programming](task-based-asynchronous-programming.md)
