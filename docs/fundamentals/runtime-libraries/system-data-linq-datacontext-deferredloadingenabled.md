---
title: System.Data.Linq.DataContext.DeferredLoadingEnabled property
description: Learn about the System.Data.Linq.DataContext.DeferredLoadingEnabled property.
ms.date: 01/24/2024
---
# System.Data.Linq.DataContext.DeferredLoadingEnabled property

[!INCLUDE [context](includes/context.md)]

When the code accesses a delay-load one-to-many or one-to-one relationship, the <xref:System.Data.Linq.DataContext.DeferredLoadingEnabled> property returns `null` if the relationship is one-to-one, and an empty collection if it's one-to-many. The relationships can still be filled by setting the <xref:System.Data.Linq.DataContext.LoadOptions> property.

The main scenario for this property is to enable you to extract a piece of the object model and send it out (for example, to a web service).

> [!NOTE]
> If this property is set to `false` after a query has been executed, an exception is thrown. For more information, see [Valid modes](#valid-modes).

## Valid modes

Deferred loading requires object tracking. Only the following three modes are valid:

- <xref:System.Data.Linq.DataContext.ObjectTrackingEnabled%2A> = `false`. <xref:System.Data.Linq.DataContext.DeferredLoadingEnabled%2A> is ignored and inferred to be `false`. This behavior corresponds to a read-only <xref:System.Data.Linq.DataContext>.

- <xref:System.Data.Linq.DataContext.ObjectTrackingEnabled%2A> = `true`. <xref:System.Data.Linq.DataContext.DeferredLoadingEnabled%2A> = `false`. This situation corresponds to a <xref:System.Data.Linq.DataContext> that allows users to load an object graph by using <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> directives, but it does not enable deferred loading.

- Both are set to `true`. This is the default.

The flags may not be changed after a query has been executed. Any change after the execution of the first query that uses that <xref:System.Data.Linq.DataContext> throws an exception.
