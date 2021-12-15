---
title: Self-hosted gRPC applications - gRPC for WCF developers
description: Deploying ASP.NET Core gRPC applications as self-hosted services.
ms.date: 12/14/2021
---

# Self-hosted gRPC applications

Although ASP.NET Core 6.0 applications can be hosted in IIS on Windows Server, currently it isn't possible to host a gRPC application in IIS because some of the HTTP/2 functionality isn't supported. This functionality is a goal for a future update to Windows Server.

You can run your application as a Windows service. Or you can run it as a Linux service controlled by [systemd](https://en.wikipedia.org/wiki/Systemd), because of new features in the .NET 6 hosting extensions.

## Run your app as a Windows service

To configure your ASP.NET Core application to run as a Windows service, install the [Microsoft.Extensions.Hosting.WindowsServices](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.WindowsServices) package from NuGet. Then add a call to `UseWindowsService` to the `CreateHostBuilder` method in `Program.cs`.

```csharp
Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    ...
```

> [!NOTE]
> If the application isn't running as a Windows service, the `UseWindowsService` method doesn't do anything.

Now publish your application by using one of these methods:

* From Visual Studio by right-clicking the project and selecting **Publish** on the shortcut menu.
* From the .NET CLI.

When you publish a .NET application, you can choose to create a *framework-dependent* deployment or a *self-contained* deployment. Framework-dependent deployments require the .NET Shared Runtime to be installed on the host where they are run. Self-contained deployments are published with a complete copy of the .NET runtime and framework and can be run on any host. For more information, including the advantages and disadvantages of each approach, see the [.NET application deployment](../../core/deploying/index.md) documentation.

To publish a self-contained build of the application that does not require the .NET 5 runtime to be installed on the host, specify the runtime to be included with the application. Use the `-r` (or `--runtime`) flag.

```dotnetcli
dotnet publish -c Release -r win-x64 -o ./publish
```

To publish a framework-dependent build, omit the `-r` flag.

```dotnetcli
dotnet publish -c Release -o ./publish
```

Copy the complete contents of the `publish` directory to an installation folder. Then, use the [sc tool](/windows/desktop/services/controlling-a-service-using-sc) to create a Windows service for the executable file.

```console
sc create MyService binPath=C:\MyService\MyService.exe
```

### Log to the Windows event log

The `UseWindowsService` method automatically adds a [logging](/aspnet/core/fundamentals/logging/) provider that writes log messages to the Windows event log. You can configure logging for this provider by adding an `EventLog` entry to the `Logging` section of `appsettings.json` or another configuration source.

You can override the source name used in the event log by setting a `SourceName` property in these settings. If you don't specify a name, the default application name (normally the executable assembly name) will be used.

More information on logging is at the end of this chapter.

## Run your app as a Linux service with systemd

To configure your ASP.NET Core application to run as a Linux service (or *daemon* in Linux parlance), install the [Microsoft.Extensions.Hosting.Systemd](https://www.nuget.org/packages/Microsoft.Extensions.Hosting.Systemd) package from NuGet. Then add a call to `UseSystemd` to the `CreateHostBuilder` method in `Program.cs`.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseSystemd() // Enable running as a Systemd service
        .ConfigureServices((hostContext, services) =>
        {
           ...
        });
```

> [!NOTE]
> If the application isn't running as a Linux service, the `UseSystemd` method doesn't do anything.

Now publish your application. The application can be either framework dependent or self-contained for the relevant Linux runtime (for example, `linux-x64`). You can publish by using one of these methods:

* From Visual Studio by right-clicking the project and selecting **Publish** on the shortcut menu.
* From the .NET CLI, by using the following command:

  ```dotnetcli
  dotnet publish -c Release -r linux-x64 -o ./publish
  ```
  
Copy the complete contents of the `publish` directory to an installation folder on the Linux host. Registering the service requires a special file, called a *unit file*, to be added to the `/etc/systemd/system` directory. You'll need root permission to create a file in this folder. Name the file with the identifier that you want `systemd` to use and the `.service` extension. For example, use `/etc/systemd/system/myapp.service`.

The service file uses INI format, as shown in this example:

```ini
[Unit]
Description=My gRPC Application

[Service]
Type=notify
ExecStart=/usr/sbin/myapp

[Install]
WantedBy=multi-user.target
```

The `Type=notify` property tells `systemd` that the application will notify it on startup and shutdown. The `WantedBy=multi-user.target` setting will cause the service to start when the Linux system reaches "runlevel 2," which means a non-graphical, multi-user shell is active.

Before `systemd` will recognize the service, it needs to reload its configuration. You control `systemd` by using the `systemctl` command. After reloading, use the `status` subcommand to confirm that the application has registered successfully.

```console
sudo systemctl daemon-reload
sudo systemctl status myapp
```

If you've configured the service correctly, you'll get the following output:

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
> The `.service` extension is optional when you're using `systemctl start`.

To tell `systemd` to start the service automatically on system startup, use the `enable` command.

```console
sudo systemctl enable myapp
```

### Log to journald

The Linux equivalent of the Windows event log is `journald`, a structured logging system service that's part of `systemd`. Log messages written to the standard output by a Linux daemon are automatically written to `journald`. To configure logging levels, use the `Console` section of the logging configuration. The `UseSystemd` host builder method automatically configures the console output format to suit the journal.

Because `journald` is the standard for Linux logs, a variety of tools integrate with it. You can easily route logs from `journald` to an external logging system. Working locally on the host, you can use the `journalctl` command to view logs from the command line.

```console
sudo journalctl -u myapp
```

> [!TIP]
> If you have a GUI environment available on your host, a few graphical log viewers are available for Linux, such as *QJournalctl* and *gnome-logs*.

To learn more about querying the `systemd` journal from the command line by using `journalctl`, see [the manpages](https://manpages.debian.org/buster/systemd/journalctl.1).

## HTTPS certificates for self-hosted applications

When you're running a gRPC application in production, you should use a TLS certificate from a trusted certificate authority (CA). This CA might be a public CA, or an internal one for your organization.

On Windows hosts, you can load the certificate from a secure [certificate store](/windows/win32/seccrypto/managing-certificates-with-certificate-stores) by using the <xref:System.Security.Cryptography.X509Certificates.X509Store> class. You can also use the `X509Store` class with the OpenSSL key store on some Linux hosts.

You can also create certificates by using one of the [X509Certificate2 constructors](xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor%2A), from either:

* A file, such as a `.pfx` file protected by a strong password
* Binary data retrieved from a secure storage service such as [Azure Key Vault](https://azure.microsoft.com/services/key-vault/)

You can configure Kestrel to use a certificate in two ways: from configuration or in code.

### Set HTTPS certificates by using configuration

The configuration approach requires setting the path to the certificate `.pfx` file and the password in the Kestrel configuration section. In `appsettings.json`, that would look like this:

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

Provide the password by using a secure configuration source such as Azure Key Vault or Hashicorp Vault.

> [!IMPORTANT]
> Don't store unencrypted passwords in configuration files.

### Set HTTPS certificates in code

To configure HTTPS on Kestrel in code, use the `ConfigureKestrel` method on `IWebHostBuilder` in the `Program` class.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(kestrel =>
            {
                kestrel.ConfigureHttpsDefaults(https =>
                {
                    https.ServerCertificate = new X509Certificate2("mycert.pfx", "password");
                });
            });
        });
```

Again, be sure to store the password for the `.pfx` file in, and retrieve it from, a secure configuration source.

>[!div class="step-by-step"]
>[Previous](grpc-in-production.md)
>[Next](docker.md)
