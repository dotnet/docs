
### Install the SDK

.NET SDK allows you to develop apps with .NET. If you install the .NET SDK, you don't need to install the corresponding runtime. To install the .NET SDK, run the following commands:

```bash
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package dotnet-sdk-5.0**, see the [APT troubleshooting](#apt-troubleshooting) section.

### Install the runtime

ASP.NET Core Runtime allows you to run apps that were made with .NET and .NET Core that didn't provide the runtime. The commands below install ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following commands:

```bash
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-5.0
```

> [!IMPORTANT]
> If you receive an error message similar to **Unable to locate package aspnetcore-runtime-5.0**, see the [APT troubleshooting](#apt-troubleshooting) section.

As an alternative to ASP.NET Core Runtime, you can install .NET Runtime that doesn't include ASP.NET Core support: replace `aspnetcore-runtime-5.0` in the command above with `dotnet-runtime-5.0`:

```bash
sudo apt-get install -y dotnet-runtime-5.0
```
