---
title: Self-hosted gRPC applications - gRPC for WCF Developers
description: Deploying ASP.NET Core gRPC applications as self-hosted services.
author: markrendle
ms.date: 09/02/2019
---

# Self-hosted gRPC applications

Although ASP.NET Core 3.0 applications can be hosted in IIS on Windows Server, currently it isn't possible to host a gRPC application in IIS because some of the HTTP/2 functionality isn't yet supported. This functionality is expected in a future update to Windows Server.

You can run your application as a Windows Service, or as a Linux service controlled by [systemd](https://en.wikipedia.org/wiki/Systemd), thanks to some new features in the .NET Core 3.0 hosting extensions.

## Run your app as a Windows service

To configure your ASP.NET Core application to run as a Windows service, install the [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices) package from NuGet. Then add a call to `UseWindowsService` to the `CreateHostBuilder` method in `Program.cs`.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseWindowsService() // Enable running as a Windows service
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

> [!NOTE]
> If the application isn't running as a Windows service, the `UseWindowsService` method doesn't do anything.

Now publish your application, either from Visual Studio by right-clicking the project and choosing *Publish* from the context menu, or from the .NET Core CLI.

When you publish a .NET Core application, you can choose to create a *framework-dependent* deployment or a *self-contained* deployment. Framework-dependent deployments require the .NET Core Shared Runtime to be installed on the host where they are run. Self-contained deployments are published with a complete copy of the .NET Core runtime and framework and can be run on any host. For more information, including the advantages and disadvantages of each approach, refer to the [.NET Core application deployment](https://docs.microsoft.com/dotnet/core/deploying/) documentation.

To publish a self-contained build of the application that does not require the .NET Core 3.0 runtime to be installed on the host, specify the runtime to be included with the application using the `-r` (or `--runtime`) flag.

```console
dotnet publish -c Release -r win-x64 -o ./publish
```

To publish a framework-dependent build, omit the `-r` flag.

```console
dotnet publish -c Release -o ./publish
```

Copy the complete contents of the `publish` directory to an installation folder, and use the [sc utility](https://docs.microsoft.com/windows/desktop/services/controlling-a-service-using-sc) to create a Windows service for the executable.

```console
sc create MyService binPath=C:\MyService\MyService.exe
```

### Log to Windows Event Log

The `UseWindowsService` method automatically adds a [Logging](https://docs.microsoft.com/aspnet/core/fundamentals/logging/?view=aspnetcore-3.0) provider that writes log messages to the Windows Event Log. You can configure logging for this provider by adding an `EventLog` entry to the `Logging` section of `appsettings.json` or other configuration source. The source name used in Event Log can be overridden by setting a `SourceName` property in these settings; if you don't specify a name, the default application name (normally the executable assembly name) will be used.

More information on logging is at the end of this chapter.

## Run your app as a Linux service with systemd

To configure your ASP.NET Core application to run as a Linux service (or *daemon* in Linux parlance), install the [Microsoft.Extensions.Hosting.Systemd](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.Systemd) package from NuGet. Then add a call to `UseSystemd` to the `CreateHostBuilder` method in `Program.cs`.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseSystemd() // Enable running as a Systemd service
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

> [!NOTE]
> If the application isn't running as a Linux service, the `UseSystemd` method doesn't do anything.

Now publish your application (either framework-dependent, or self-contained for the relevant Linux runtime, e.g. `linux-x64`), either from Visual Studio by right-clicking the project and choosing *Publish* from the context menu, or from the .NET Core CLI using the following command.

```console
dotnet publish -c Release -r linux-x64 -o ./publish
```

Copy the complete contents of the `publish` directory to an installation folder on the Linux host. Registering the service requires a special file, called a "unit file", to be added to the `/etc/systemd/system` directory. You'll need root permission to create a file in this folder. Name the file with the identifier you want `systemd` to use and the `.service` extension. For example, `/etc/systemd/system/myapp.service`.

The service file uses INI format, as shown in this example.

```ini
[Unit]
Description=My gRPC Application

[Service]
Type=notify
ExecStart=/usr/sbin/myapp

[Install]
WantedBy=multi-user.target
```

The `Type=notify` property tells `systemd` that the application will notify it on startup and shutdown. The `WantedBy=multi-user.target` setting will cause the service to start when the Linux system reaches "runlevel 2", meaning a non-graphical multi-user shell is active.

Before `systemd` will recognize the service, it needs to reload its configuration. You control `systemd` using the `systemctl` command. After reloading, use the `status` subcommand to confirm the application has registered successfully.

```console
sudo systemctl daemon-reload
sudo systemctl status myapp
```

If you've configured the service correctly, the following output will be shown:

```text
myapp.service - My gRPC Application
 Loaded: loaded (/etc/systemd/system/myapp.service; disabled; vendor preset: enabled)
 Active: inactive (dead)
```

Use the `start` command to start the service.

```console
sudo systemctl start myapp.service
```

> [!TIP]
> The `.service` extension is optional when using `systemctl start`.

To tell `systemd` to start the service automatically on system startup, use the `enable` command.

```console
sudo systemctl enable myapp
```

### Log to journald

The Linux equivalent of the Windows Event Log is `journald`, a structured logging system service that is part of `systemd`. Log messages written to the standard output by a Linux daemon are automatically written to `journald`, so to configure logging levels, use the `Console` section of the logging configuration. The `UseSystemd` host builder method automatically configures the console output format to suit the journal.

Because `journald` is the standard for Linux logs, there are a variety of tools that integrate with it, and you can easily route logs from `journald` to an external logging system. Working locally on the host, you can use the `journalctl` command to view logs from the command line.

```console
sudo journalctl -u myapp
```

> [!TIP]
> If you have a GUI environment available on your host, a few graphical log viewers are available for Linux, such as *QJournalctl* and *gnome-logs*.

To learn more about querying the systemd journal from the command line with `journalctl`, see [the man pages](https://manpages.debian.org/buster/systemd/journalctl.1).

## HTTPS Certificates for self-hosted applications

When running a gRPC application in production, you should use a TLS certificate from a trusted Certificate Authority (CA). This CA could be a public CA, or an internal one for your organization.

On Windows hosts, the certificate may be loaded from a secure [Certificate Store](https://docs.microsoft.com/windows/win32/seccrypto/managing-certificates-with-certificate-stores) using the [X509Store class](https://docs.microsoft.com/dotnet/api/system.security.cryptography.x509certificates.x509store?view=netcore-3.0). The `X509Store` class can also be used with the OpenSSL key-store on some Linux hosts.

Certificates may also be created using one of the [X509Certificate2 constructors](https://docs.microsoft.com/dotnet/api/system.security.cryptography.x509certificates.x509certificate.-ctor?view=netcore-3.0), either from a file (for example a `.pfx` file protected by a strong password), or from binary data retrieved from a secure storage service such as [Azure Key Vault](https://azure.microsoft.com/services/key-vault/).

Kestrel can be configured to use a certificate in two ways: from configuration, or in code.

### Set HTTPS certificates using configuration

The configuration approach requires setting the path to the certificate `.pfx` file and the password in the Kestrel configuration section. In `appsettings.json` that would look like this.

```json
{
  "Kestrel": {
    "Certificates": {
      "Default": {
        "Path": "cert.pfx",
        "Password": "DO NOT STORE PLAINTEXT PASSWORDS IN APPSETTINGS FILES"
      }
    }
  }
}
```

The password should be provided using a secure configuration source such as Azure KeyVault or Hashicorp Vault.

You SHOULD NOT store unencrypted passwords in configuration files.

### Set HTTPS certificates in code

To configure HTTPS on Kestrel in code, use the `ConfigureKestrel` method on `IWebHostBuilder` in the `Program` class.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(kestrel =>
            {
                kestrel.ConfigureHttpsDefaults(https =>
                {
                    https.ServerCertificate = new X509Certificate2("mycert.pfx", "password");
                });
            });
        });
```

Again, the password for the `.pfx` file should be stored in and retrieved from a secure configuration source.

>[!div class="step-by-step"]
>[Previous](grpc-in-production.md)
>[Next](docker.md)
