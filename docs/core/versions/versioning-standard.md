---
Your magic stuff
---

# Versioning .NET Standard

.NET Standard consists of a reference library and implementations specific to each platform. The reference library contains the definition of .NET Standard. Each implementation fulfills the .NET Standard contract on the specific platform. .NET Standard usually refers to the reference library, and the implementation is detail of the corresponding runtime.

The .NET Standard reference implementation uses a `MAJOR.MINOR` versioning scheme. `PATCH` level isn't useful for .NET Standard because if exposes only an API (no implementation) and by definition any change to the API would represent a change in the feature set, and thus a minor version bump.

The implementations on each runtime may version, but this would normally be part of the runtime release, and thus not evident to the programmers using .NET Standard on that platform.

There is no real coupling between .NET Standard versions and .NET Core versions: .NET Core 2.0 happens to implement .NET Standard 2.0, but .NET Core 2.1 also implements .NET Standard 2.0. .NET Core will ship new  APIs not yet included in .NET Standard. .NET Standard is also a concept that applies to other targets, such as .NET Framework or Mono, even if its inception happened to coincide with that of .NET Core. If .NET Standard 2.1 ships, .NET Core 2.1 will not support it.

| .NET Core | .NET Standard |
|-----------|---------------|
| 1.0       | up to 1.6     |
| 2.0       | up to 2.0     |
| 2.1       | up to 2.1     |

## See also
