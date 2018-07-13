---
Your magic stuff
---

# Versioning .NET Standard

.NET Standard consists of a .net reference assembly and implementations specific to each platform. The reference assembly contains the definition of .NET Standard. Each implementation fulfills the .NET Standard contract on the specific platform. .NET Standard usually refers to the reference library, and the implementation is detail of the corresponding runtime.

The .NET Standard reference implementation uses a `MAJOR.MINOR` versioning scheme. `PATCH` level isn't useful for .NET Standard because if exposes only an API (no implementation) and by definition any change to the API would represent a change in the feature set, and thus a minor version bump.

The implementations on each runtime may version, but this would normally be part of the runtime release, and thus not evident to the programmers using .NET Standard on that platform.

Each version of .NET Core implements a version of .NET standard. .NET Standard and .NET Core version independently. It's a coincidence that .NET Core 2.0 implements .NET Standard 2.0. .NET Core 2.1 also implements .NET Standard 2.0. .NET Core will support future versions of .NET Standard as they become available.

| .NET Core | .NET Standard |
|-----------|---------------|
| 1.0       | up to 1.6     |
| 2.0       | up to 2.0     |
| 2.1       | up to 2.0     |

## See also
