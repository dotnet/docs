---
title: "IActionContextAccessor and ActionContextAccessor are obsolete"
description: "Learn about the breaking change in ASP.NET Core 10 where IActionContextAccessor and ActionContextAccessor are marked as obsolete."
ms.date: 01/08/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/520
---

# IActionContextAccessor and ActionContextAccessor are obsolete

`IActionContextAccessor` and `ActionContextAccessor` have been marked as obsolete in ASP.NET Core 10 with diagnostic ID `ASPDEPR006`. With the introduction of endpoint routing, `IActionContextAccessor` is no longer necessary as developers can access action descriptor and metadata information directly through `HttpContext.GetEndpoint()`.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Developers could use `IActionContextAccessor` to access the current `ActionContext`:

```csharp
public class MyService
{
   private readonly IActionContextAccessor _actionContextAccessor;
   
   public MyService(IActionContextAccessor actionContextAccessor)
   {
       _actionContextAccessor = actionContextAccessor;
   }
   
   public void DoSomething()
   {
       var actionContext = _actionContextAccessor.ActionContext;
       var actionDescriptor = actionContext?.ActionDescriptor;
       // Use action descriptor metadata
   }
}
```

## New behavior

Using `IActionContextAccessor` and `ActionContextAccessor` produces a compiler warning with diagnostic ID `ASPDEPR006`:

```
warning ASPDEPR006: ActionContextAccessor is obsolete and will be removed in a future version. For more information, visit https://aka.ms/aspnet/deprecate/006.
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

With the introduction of endpoint routing in ASP.NET Core, `IActionContextAccessor` is no longer necessary. The endpoint routing infrastructure provides a cleaner, more direct way to access endpoint metadata through `HttpContext.GetEndpoint()`, aligning with ASP.NET Core's architectural evolution toward endpoint routing.

## Recommended action

Migrate from `IActionContextAccessor` to `IHttpContextAccessor` and use `HttpContext.GetEndpoint()`:

**Before:**

```csharp
public class MyService
{
   private readonly IActionContextAccessor _actionContextAccessor;
   
   public MyService(IActionContextAccessor actionContextAccessor)
   {
       _actionContextAccessor = actionContextAccessor;
   }
   
   public void DoSomething()
   {
       var actionContext = _actionContextAccessor.ActionContext;
       var actionDescriptor = actionContext?.ActionDescriptor;
       // Use action descriptor metadata
   }
}
```

**After:**

```csharp
public class MyService
{
   private readonly IHttpContextAccessor _httpContextAccessor;
   
   public MyService(IHttpContextAccessor httpContextAccessor)
   {
       _httpContextAccessor = httpContextAccessor;
   }
   
   public void DoSomething()
   {
       var httpContext = _httpContextAccessor.HttpContext;
       var endpoint = httpContext?.GetEndpoint();
       var actionDescriptor = endpoint?.Metadata.GetMetadata<ActionDescriptor>();
       // Use action descriptor metadata
   }
}
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Mvc.Infrastructure.IActionContextAccessor?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Infrastructure.ActionContextAccessor?displayProperty=fullName>
