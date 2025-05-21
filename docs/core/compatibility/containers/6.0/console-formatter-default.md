---
title: ".NET 6 breaking change: Default console logger formatting in container images"
description: Learn about the .NET 6 breaking change in .NET containers where the default formatting for the console logger in aspnet container images is no longer JSON.
ms.date: 05/02/2022
ms.topic: how-to
---
# Default console logger formatting in container images

The default console formatter that's configured in `aspnet` containers has changed.

## Previous behavior

In previous servicing releases of .NET 6, `aspnet` container images were configured with the `Logging__Console__FormatterName` environment variable set to `Json`. This resulted in console output formatted similarly to the following:

```txt
{"EventId":0,"LogLevel":"Information","Category":"Microsoft.Hosting.Lifetime","Message":"Now listening on: http://localhost:7000/","State":{"Message":"Now listening on: http://localhost:7000/","address":"http://localhost:7000/","{OriginalFormat}":"Now listening on: {address}"}}
{"EventId":0,"LogLevel":"Information","Category":"Microsoft.Hosting.Lifetime","Message":"Now listening on: http://localhost:7001/","State":{"Message":"Now listening on: http://localhost:7001/","address":"http://localhost:7001/","{OriginalFormat}":"Now listening on: {address}"}}
{"EventId":0,"LogLevel":"Information","Category":"Microsoft.Hosting.Lifetime","Message":"Now listening on: http://localhost:7002/","State":{"Message":"Now listening on: http://localhost:7002/","address":"http://localhost:7002/","{OriginalFormat}":"Now listening on: {address}"}}
{"EventId":0,"LogLevel":"Information","Category":"Microsoft.Hosting.Lifetime","Message":"Application started. Press Ctrl\u002BC to shut down.","State":{"Message":"Application started. Press Ctrl\u002BC to shut down.","{OriginalFormat}":"Application started. Press Ctrl\u002BC to shut down."}}
{"EventId":0,"LogLevel":"Information","Category":"Microsoft.Hosting.Lifetime","Message":"Hosting environment: Development","State":{"Message":"Hosting environment: Development","envName":"Development","{OriginalFormat}":"Hosting environment: {envName}"}}
{"EventId":0,"LogLevel":"Information","Category":"Microsoft.Hosting.Lifetime","Message":"Content root path: C:\\source\\temp\\web50","State":{"Message":"Content root path: C:\\source\\temp\\web50","contentRoot":"C:\\source\\temp\\web50","{OriginalFormat}":"Content root path: {contentRoot}"}}
```

## New behavior

Starting in .NET 6.0.5, `aspnet` container images have the `Logging__Console__FormatterName` environment variable unset by default. This results in simple, multiline, human-readable console output similar to the following:

```txt
warn: Microsoft.AspNetCore.Server.HttpSys.MessagePump[37]
      Overriding address(es) ''. Binding to endpoints added to UrlPrefixes instead.
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:7000/
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:7001/
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:7002/
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\source\temp\web50
```

## Version introduced

.NET 6.0.5 (May 2022 servicing)

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

When the change to use JSON formatting was introduced in the .NET 6 GA release, it broke many scenarios that relied on the original, simple formatting as described in [dotnet/dotnet-docker#2725](https://github.com/dotnet/dotnet-docker#2725).

## Recommended action

If you want to continue using the JSON formatting, you can configure your container to use it by setting the `Logging__Console__FormatterName` environment variable value to `Json`.

## Affected APIs

None.

## See also

- [dotnet/dotnet-docker#3706](https://github.com/dotnet/dotnet-docker#3706)
