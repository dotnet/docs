# Transport Layer Security (TLS) Code Samples

This directory contains code samples demonstrating how to configure Transport Layer Security (TLS) in Orleans applications.

## Projects

- **SiloExample**: Demonstrates TLS configuration for Orleans silos
- **ClientExample**: Demonstrates TLS configuration for Orleans clients

## Building the Samples

To build all samples:

```bash
dotnet build transport-layer-security.sln
```

To build individual projects:

```bash
dotnet build SiloExample/SiloExample.csproj
dotnet build ClientExample/ClientExample.csproj
```

## Note

These samples are intended for documentation purposes and demonstrate various TLS configuration scenarios including basic setup, development environments, certificate files, and advanced configurations.
