### Caching: CompactOnMemoryPressure property removed

The ASP.NET Core 3.0 release removed the [obsolete MemoryCacheOptions APIs](https://github.com/aspnet/Extensions/blob/dc5c593da7b72c82e6fe85abb91d03818f9b700c/src/Caching/Memory/src/MemoryCacheOptions.cs#L17-L18).

#### Change description

This change is a follow-up to [aspnet/Caching#221](https://github.com/aspnet/Caching/issues/221). For discussion, see [aspnet/Extensions#1062](https://github.com/aspnet/Extensions/issues/1062).

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

<xref:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.CompactOnMemoryPressure%2A?displayProperty=nameWithType>

<!--

#### Affected APIs

`Overload:Microsoft.Extensions.Caching.Memory.MemoryCacheOptions.CompactOnMemoryPressure`

-->
