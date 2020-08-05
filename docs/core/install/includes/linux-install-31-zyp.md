
### Install the SDK

The .NET Core SDK allows you to develop apps with .NET Core. To install the .NET Core SDK, run the following commands.

```bash
sudo zypper install dotnet-sdk-3.1
```

### Install the runtime

The .NET Core Runtime allows you to run apps that were made with .NET Core that didn't include the runtime. The commands below install the ASP.NET Core Runtime, which is the most compatible runtime for .NET Core. In your terminal, run the following commands.

```bash
sudo zypper install aspnetcore-runtime-3.1
```

As an alternative to the ASP.NET Core Runtime, you can install the .NET Core Runtime that doesn't include ASP.NET Core support: replace `aspnetcore-runtime-2.1` in the command above with `dotnet-runtime-3.1`.

```bash
sudo zypper install dotnet-runtime-3.1
```
