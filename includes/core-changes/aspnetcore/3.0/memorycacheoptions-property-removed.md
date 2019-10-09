### Obsolete CompactOnMemoryPressure property removed

This change is a follow-up to https://github.com/aspnet/Caching/issues/221. The ASP.NET Core 3.0 release will remove the [obsolete MemoryCacheOptions APIs](https://github.com/aspnet/Extensions/blob/dc5c593da7b72c82e6fe85abb91d03818f9b700c/src/Caching/Memory/src/MemoryCacheOptions.cs#L17-L18). 

For discussion, see https://github.com/aspnet/Extensions/issues/1062.

#### Version introduced

3.0

#### Old behavior

`MemoryCacheOptions.CompactOnMemoryPressure` property was available.

#### New behavior

The `MemoryCacheOptions.CompactOnMemoryPressure` property has been removed.

#### Reason for change

Automatically compacting the cache caused problems. To avoid unexpected behavior, the cache should only be compacted when needed.

#### Recommended action

To compact the cache, downcast to `MemoryCache` and call `Compact` when needed.

#### Category

ASP.NET Core

#### Affected APIs

[MemoryCacheOptions.CompactOnMemoryPressure](/dotnet/api/microsoft.extensions.caching.memory.memorycacheoptions.compactonmemorypressure?view=aspnetcore-2.2)
