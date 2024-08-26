---
title: Generate Self-Signed Certificates Overview
description: An overview of the dotnet dev-certs tool that adds functionality for .NET and ASP.NET Core projects, and other options for using self-signed certificates.
author: angee
ms.date: 12/06/2021
---

# Generate self-signed certificates with the .NET CLI

There are different ways to create and use self-signed certificates for development and testing scenarios. This article covers using self-signed certificates with `dotnet dev-certs`, and other options like `PowerShell` and `OpenSSL`.

You can then validate that the certificate will load using an example such as an [ASP.NET Core app](https://github.com/dotnet/dotnet-docker/blob/main/samples/run-aspnetcore-https-development.md) hosted in a container.

## Prerequisites

For `dotnet dev-certs`, be sure to have the appropriate version of .NET installed:

* [Install .NET on Windows](../install/windows.md)
* [Install .NET on Linux](../install/linux.md)
* [Install .NET on macOS](../install/macos.md)

This sample requires [Docker 17.06](https://docs.docker.com/release-notes/docker-ce) or later of the [Docker client](https://www.docker.com/products/docker).

## Prepare sample app

For this guide, you'll use a [sample app](https://hub.docker.com/_/microsoft-dotnet-samples) and make changes where appropriate.

Check that the sample app [Dockerfile](https://github.com/dotnet/dotnet-docker/blob/main/samples/aspnetapp/Dockerfile) is using .NET 8.

Depending on the host OS, you might need to update the ASP.NET runtime. For example, to target the appropriate Windows runtime, change `mcr.microsoft.com/dotnet/aspnet:8.0-nanoservercore-2009 AS runtime` to `mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022 AS runtime` in the Dockerfile.

For example, this will help with testing the certificates on Windows:

```Dockerfile
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY aspnetapp/*.csproj ./aspnetapp/
RUN dotnet restore -r win-x64

# copy everything else and build app
COPY aspnetapp/. ./aspnetapp/
WORKDIR /source/aspnetapp
RUN dotnet publish -c release -o /app -r win-x64 --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-windowsservercore-ltsc2022 AS runtime
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["aspnetapp"]
```

If you're testing the certificates on Linux, you can use the existing Dockerfile.

Make sure the `aspnetapp.csproj` includes the appropriate target framework:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <!--Other Properties-->
  </PropertyGroup>

</Project>
```

> [!NOTE]
> If you want to use `dotnet publish` parameters to *trim* the deployment, make sure that the appropriate dependencies are included for supporting SSL certificates. Update the [dotnet-docker\samples\aspnetapp\aspnetapp.csproj](https://github.com/dotnet/dotnet-docker/blob/main/samples/aspnetapp/aspnetapp/aspnetapp.csproj) file to ensure that the appropriate assemblies are included in the container. For reference, check how to update the .csproj file to [support SSL certificates](../deploying/trimming/trim-self-contained.md) when using trimming for self-contained deployments.

Make sure you're pointing to the sample app.

```console
cd .\dotnet-docker\samples\aspnetapp
```

Build the container for testing locally.

```console
docker build -t aspnetapp:my-sample -f Dockerfile .
```

## Create a self-signed certificate

You can create a self-signed certificate:

- [With dotnet dev-certs](#with-dotnet-dev-certs)
- [With PowerShell](#with-powershell)
- [With OpenSSL](#with-openssl)

### With dotnet dev-certs

You can use `dotnet dev-certs` to work with self-signed certificates.

```powershell
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p crypticpassword
dotnet dev-certs https --trust
```

> [!NOTE]
> The certificate name, in this case *aspnetapp*.pfx, must match the project assembly name. `crypticpassword` is used as a stand-in for a password of your own choosing. If console returns "A valid HTTPS certificate is already present.", a trusted certificate already exists in your store. It can be exported using MMC Console.

Configure application secrets, for the certificate:

```console
dotnet user-secrets -p aspnetapp\aspnetapp.csproj init
dotnet user-secrets -p aspnetapp\aspnetapp.csproj set "Kestrel:Certificates:Development:Password" "crypticpassword"
```

> [!NOTE]
> Note: The password must match the password used for the certificate.

Run the container image with ASP.NET Core configured for HTTPS:

```powershell
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_ENVIRONMENT=Development -v $env:APPDATA\microsoft\UserSecrets\:C:\Users\ContainerUser\AppData\Roaming\microsoft\UserSecrets -v $env:USERPROFILE\.aspnet\https:C:\Users\ContainerUser\AppData\Roaming\ASP.NET\Https mcr.microsoft.com/dotnet/samples:aspnetapp
```

Once the application starts, navigate to `https://localhost:8001` in your web browser.

#### Clean up

If the secrets and certificates aren't in use, be sure to clean them up.

```console
dotnet user-secrets remove "Kestrel:Certificates:Development:Password" -p aspnetapp\aspnetapp.csproj
dotnet dev-certs https --clean
```

### With PowerShell

You can use PowerShell to generate self-signed certificates. The [PKI Client](/powershell/module/pki/new-selfsignedcertificate) can be used to generate a self-signed certificate.

```powershell
$cert = New-SelfSignedCertificate -DnsName @("contoso.com", "www.contoso.com") -CertStoreLocation "cert:\LocalMachine\My"
```

The certificate will be generated, but for the purposes of testing, should be placed in a cert store for testing in a browser.

```powershell
$certKeyPath = "c:\certs\contoso.com.pfx"
$password = ConvertTo-SecureString 'password' -AsPlainText -Force
$cert | Export-PfxCertificate -FilePath $certKeyPath -Password $password
$rootCert = $(Import-PfxCertificate -FilePath $certKeyPath -CertStoreLocation 'Cert:\LocalMachine\Root' -Password $password)
```

At this point, the certificates should be viewable from an [MMC snap-in](../../framework/wcf/feature-details/how-to-view-certificates-with-the-mmc-snap-in.md).

You can run the sample container in Windows Subsystem for Linux (WSL):

```console
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_Kestrel__Certificates__Default__Password="password" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/contoso.com.pfx -v /c/certs:/https/ mcr.microsoft.com/dotnet/samples:aspnetapp
```

> [!NOTE]
> Note that with the volume mount, the file path could be handled differently based on host. For example, in WSL you might replace */c/certs* with */mnt/c/certs*.

If you're using the container built earlier for Windows, the run command would look like the following:

```console
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_Kestrel__Certificates__Default__Password="password" -e ASPNETCORE_Kestrel__Certificates__Default__Path=c:\https\contoso.com.pfx -v c:\certs:C:\https aspnetapp:my-sample
```

Once the application is up, navigate to contoso.com:8001 in a browser.

Be sure that the host entries are updated for `contoso.com` to answer on the appropriate IP address (for example 127.0.0.1). If the certificate isn't recognized, make sure that the certificate that is loaded with the container is also trusted on the host, and that there's appropriate SAN / DNS entries for `contoso.com`.

#### Clean up

```powershell
$cert | Remove-Item
Get-ChildItem $certKeyPath | Remove-Item
$rootCert | Remove-item
```

### With OpenSSL

You can use [OpenSSL](https://www.openssl.org/) to create self-signed certificates. This example uses WSL / Ubuntu and a bash shell with `OpenSSL`.

This command generates a .crt and a .key.

```bash
PARENT="contoso.com"
openssl req \
-x509 \
-newkey rsa:4096 \
-sha256 \
-days 365 \
-nodes \
-keyout $PARENT.key \
-out $PARENT.crt \
-subj "/CN=${PARENT}" \
-extensions v3_ca \
-extensions v3_req \
-config <( \
  echo '[req]'; \
  echo 'default_bits= 4096'; \
  echo 'distinguished_name=req'; \
  echo 'x509_extension = v3_ca'; \
  echo 'req_extensions = v3_req'; \
  echo '[v3_req]'; \
  echo 'basicConstraints = CA:FALSE'; \
  echo 'keyUsage = nonRepudiation, digitalSignature, keyEncipherment'; \
  echo 'subjectAltName = @alt_names'; \
  echo '[ alt_names ]'; \
  echo "DNS.1 = www.${PARENT}"; \
  echo "DNS.2 = ${PARENT}"; \
  echo '[ v3_ca ]'; \
  echo 'subjectKeyIdentifier=hash'; \
  echo 'authorityKeyIdentifier=keyid:always,issuer'; \
  echo 'basicConstraints = critical, CA:TRUE, pathlen:0'; \
  echo 'keyUsage = critical, cRLSign, keyCertSign'; \
  echo 'extendedKeyUsage = serverAuth, clientAuth')

openssl x509 -noout -text -in $PARENT.crt
```

To get a .pfx, use the following command:

```bash
openssl pkcs12 -export -out $PARENT.pfx -inkey $PARENT.key -in $PARENT.crt
```

> [!NOTE]
> Starting in .NET 5, Kestrel can take *.crt* and PEM-encoded *.key* files in addition to *.pfx* files with a password.

Depending on the host OS, the certificate needs to be trusted. On a Linux host, 'trusting' the certificate is different and distro dependent.

For the purposes of this guide, here's an example in Windows using PowerShell:

```powershell
Import-Certificate -FilePath $certKeyPath -CertStoreLocation 'Cert:\LocalMachine\Root'
```

Run the sample using the following command in WSL:

```bash
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/contoso.com.crt -e ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/https/contoso.com.key -v /c/path/to/certs:/https/ mcr.microsoft.com/dotnet/samples:aspnetapp
```

> [!NOTE]
> In WSL, the volume mount path might change depending on the configuration.

Run the following command in PowerShell:

```powershell
docker run --rm -it -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_ENVIRONMENT=Development -e ASPNETCORE_Kestrel__Certificates__Default__Path=c:\https\contoso.com.crt -e ASPNETCORE_Kestrel__Certificates__Default__KeyPath=c:\https\contoso.com.key -v c:\certs:C:\https aspnetapp:my-sample
```

Once the application is up, navigate to contoso.com:8001 in a browser.

Be sure that the host entries are updated for `contoso.com` to answer on the appropriate IP address (for example 127.0.0.1). If the certificate isn't recognized, make sure that the certificate that is loaded with the container is also trusted on the host, and that there's appropriate SAN / DNS entries for `contoso.com`.

#### Clean up

Be sure to clean up the self-signed certificates once done testing.

```powershell
Get-ChildItem $certKeyPath | Remove-Item
```

## See also

* [dotnet dev-certs](../tools/dotnet-dev-certs.md)
