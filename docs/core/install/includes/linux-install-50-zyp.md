
### Install the SDK

.NET SDK allows you to develop apps with .NET. If you install .NET SDK, you don't need to install the corresponding runtime. To install .NET SDK, run the following command:

```bash
sudo zypper install dotnet-sdk-5.0
```

### Install the runtime

ASP.NET Core Runtime allows you to run apps that were made with .NET and .NET Core that didn't provide the runtime. The following commands install ASP.NET Core Runtime, which is the most compatible runtime for .NET. In your terminal, run the following command:

```bash
sudo zypper install aspnetcore-runtime-5.0
```

As an alternative to ASP.NET Core Runtime, you can install .NET Runtime that doesn't include ASP.NET Core support: replace `aspnetcore-runtime-5.0` in the command above with `dotnet-runtime-5.0`:

```bash
sudo zypper install dotnet-runtime-5.0
```
