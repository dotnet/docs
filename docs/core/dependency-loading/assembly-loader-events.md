---
title: Assembly Loader Events
description: Description of assembly loader events emitted by the .NET Core runtime
author: elinor-fung
ms.author: elfung
ms.date: 09/03/2020
---

# Assembly loader events

The assembly loader events contain information relating to how the runtime attempts to load a managed assembly. All events are under the `AssemblyLoader` keyword (`0x4`).

### Basic

These events represent start and stop of each assembly load operation. All other assembly loader events for an assembly load should fall chronologically between the start event and its corresponding stop event. The start/stop events will start/stop an activity such that other events within the operation can be correlated through their [activity IDs](/dotnet/api/system.diagnostics.tracing.eventwritteneventargs.activityid).

| Event             | Event ID | Description            |
| ----------------- | -------: | ---------------------- |
| AssemblyLoadStart |      290 | Assembly load started. |
| AssemblyLoadStop  |      291 | Assebly load stopped.  |

The events have the following data:

| Field                         | Description |
| ----------------------------- | ----------- |
| AssemblyName                  | Name of the assembly being loaded. |
| AssemblyPath                  | Path of the assembly being loaded (if requested by path). |
| RequestingAssembly            | Assembly requesting the load. |
| AssemblyLoadContext           | `AssemblyLoadContext` in which the load was requested. |
| RequestingAssemblyLoadContext | `AssemblyLoadContext` of the assembly that requested the assembly load. |

The following data is only for the `AssemblyLoadStop` event:

| Field                 | Description |
| --------------------- | ----------- |
| Success               | Whether or not the load was successful. |
| ResultAssemblyName    | Full name of the resulting assembly. Empty if load was not successful. |
| ResultAssemblyPath    | Path of the resulting assembly. Empty if load was not successful. |
| Cached                | Whether or not the result was returned from the assembly loader cache. |

### Resolution steps

These events represent each step of the resolution flow during a load and allow the determination of which steps were taken and their results. This resolution flow corresponds to step (2) of the [managed assembly loading algorithm](loading-managed.md#algorithm).

| Event               | Event ID | Description |
| ------------------- | -------: | ----------- |
| ResolutionAttempted |      292 | Resolution of a managed assembly was attempted during a load. |

The event has the following data:

| Field                 | Description |
| --------------------- | ----------- |
| AssemblyName          | Name of the assembly being resolved. |
| Stage                 | Resolution stage:<ul><li>0x0 : `FindInLoadContext` - Find assembly in current load context (cache)</li><li>0x1 : `AssemblyLoadContextLoad` - Call [`AssemblyLoadContext.Load`](/dotnet/api/system.runtime.loader.assemblyloadcontext.load)</li><li>0x2 : `ApplicationAssemblies` - Search application assemblies ([probing logic](default-probing.md#managed-assembly-default-probing))</li><li>0x3 : `DefaultAssemblyLoadContextFallback` - Fall back to resolution using the default `AssemblyLoadContext`</li><li>0x4 : `ResolveSatelliteAssembly` - Search satellite assemblies ([satellite probing logic](default-probing.md#satellite-resource-assembly-probing))</li><li>0x5 : `AssemblyLoadContextResolvingEvent` - Invoke handlers for [`AssemblyLoadContext.Resolving`](/dotnet/api/system.runtime.loader.assemblyloadcontext.resolving)</li><li>0x6 : `AppDomainAssemblyResolveEvent` - Invoke handlers for [`AppDomain.AssemblyResolve`](/dotnet/api/system.appdomain.assemblyresolve)</li></ul> |
| AssemblyLoadContext   | `AssemblyLoadContext` in which the load was requested. |
| Result                | Result of the stage:<ul><li>0x0 : `Success` - Resolution succeeded</li><li>0x1 : `AssemblyNotFound` - Assembly was not found</li><li>0x2 : `MismatchedAssemblyName` - Requested and result assembly names are mismatched</li><li>0x3 : `IncompatibleVersion` - Requested and result assembly versions are incompatible</li><li>0x4 : `Failure` - General failure</li><li>0x5 : `Exception` - Exception was thrown by an extension point</li></ul> |
| ResultAssemblyName    | Full name of the resulting assembly. Empty if resolution was not successful. |
| ResultAssemblyPath    | Path of the resulting assembly. Empty if resolution was not successful. |
| ErrorMessage          | Detailed error message if the resolution failed. |

### Extension points

These events represent the invocation of specific extension points.

| Event                                      | Event ID | Description |
| ------------------------------------------ | -------: | ----------- |
| AssemblyLoadContextResolvingHandlerInvoked |      293 | Handler for [`AssemblyLoadContext.Resolving`](/dotnet/api/system.runtime.loader.assemblyloadcontext.resolving) was invoked. |
| AppDomainAssemblyResolveHandlerInvoked     |      294 | Handler for [`AppDomain.AssemblyResolve`](/dotnet/api/system.appdomain.assemblyresolve) was invoked. |

The events have the following data:

| Field                 | Description |
| --------------------- | ----------- |
| AssemblyName          | Name of the assembly being loaded. |
| HandlerName           | Name of the handler that was invoked. |
| ResultAssemblyName    | Full name of the resulting assembly from the handler. |
| ResultAssemblyPath    | Path of the resulting assembly from the handler. |

The following data is only for the `AssemblyLoadContextResolvingHandlerInvoked` event:

| Field                 | Description |
| --------------------- | ----------- |
| AssemblyLoadContext   | `AssemblyLoadContext` in which the load was requested. |

### Path probing
| Event           | Event ID | Description |
| --------------- | -------: | ----------- |
| KnownPathProbed |      296 | Path was probed as part of the [default probing logic](default-probing.md). |

The event has the following data:

| Field     | Description |
| --------- | ----------- |
| FilePath  | Probed file path. |
| Source    | Source of the probed path:<ul><li>0x0 : `ApplicationAssemblies` - Path specified in the `TRUSTED_PLATFORM_ASSEMBLIES` property</li><li>0x1 : `AppNativeImagePaths` - Path specified in `APP_NI_PATHS` property</li><li>0x2 : `AppPaths` - Path specified in `APP_PATHS` poperty</li><li>0x3 : `PlatformResourceRoots` - Path specified in PLATFORM_RESOURCE_ROOTS poperty (only for satellite assemblies)</li><li>0x4 : `SatelliteSubdirectory` - Culture-specific subdirectory next to the non-culture-specific assembly (only for satellite assemblies)</li></ul> |
| Result    | Result code - 0 on success, error code on failure. |
