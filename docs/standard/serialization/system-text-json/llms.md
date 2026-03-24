# System.Text.Json

> High-performance JSON serialization and deserialization for .NET applications.

## What's New in .NET 10

### New APIs

- `JsonSerializerOptions.Strict` / `JsonSerializerDefaults.Strict` — best-practice preset that disallows unmapped members, duplicate properties, and enforces nullable annotations.
- `JsonSerializerOptions.AllowDuplicateProperties` — option to reject duplicate JSON keys (disabled in Strict).
- `JsonSerializer.DeserializeAsync<T>(PipeReader)` — direct PipeReader deserialization without Stream conversion.
- `JsonSourceGenerationOptionsAttribute.ReferenceHandler` — specify ReferenceHandler in source-generated contexts to handle circular references.

For full details and code examples, see: [.NET 10 Serialization update](https://github.com/dotnet/docs/blob/main/docs/core/whats-new/dotnet-10/libraries.md#serialization).

### Breaking Changes

- **Property name conflict validation** — System.Text.Json now validates that user-defined property names don't conflict with metadata property names (`$type`, `$id`, `$ref`, or custom `TypeDiscriminatorPropertyName`). Previously, conflicts silently produced invalid JSON with duplicate properties; now an `InvalidOperationException` is thrown. Rename the conflicting property or apply `[JsonIgnore]` to resolve.

For details, see: [System.Text.Json checks for property name conflicts](https://github.com/dotnet/docs/blob/main/docs/core/compatibility/serialization/10/property-name-validation.md).

## Best Practices

- **Reuse `JsonSerializerOptions` instances.** Creating a new instance per call is expensive — the metadata cache is rebuilt each time. Use a shared static instance or the built-in singletons (`JsonSerializerOptions.Default`, `.Web`, `.Strict`).
- **Use source generation for AOT/trimming.** Reflection-based serialization is incompatible with Native AOT. Use `[JsonSerializable]` attribute to the context classes for AOT-safe serialization. See the source generation topic below.
- **Prefer `Strict` for new projects.** The `Strict` preset catches common mistakes (unmapped members, duplicate keys, null violations) at deserialization time rather than silently ignoring them.
- **Serialize to UTF-8 when possible.** `SerializeToUtf8Bytes()` is 5–10% faster than string-based serialization because it avoids UTF-16 conversion.
