# Orleans transport layer security snippets

This folder contains the runnable snippet projects used by `docs/orleans/host/transport-layer-security.md`.

## Run the sample locally

1. Open a terminal in `docs/orleans/host/snippets/transport-layer-security/csharp/SiloExample`.
2. Run `dotnet run`.
3. Open a second terminal in `docs/orleans/host/snippets/transport-layer-security/csharp/ClientExample`.
4. Run `dotnet run`.

The executable entry points create temporary self-signed certificates in memory and configure Orleans for development-only certificate validation so the sample can run locally without any certificate store setup.

The inline snippets in each `Program.cs` file remain focused on the certificate store and certificate file configuration patterns described in the article.
