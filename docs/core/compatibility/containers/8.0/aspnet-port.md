---
title: "Breaking change: Default ASP.NET Core port changed from 80 to 8080"
description: Learn about the breaking change in containers where the default ASP.NET Core port changed from 80 to 8080.
ms.date: 07/12/2023
---
# Default ASP.NET Core port changed from 80 to 8080

The default ASP.NET Core port configured in .NET container images has been updated from port 80 to 8080.

We also added the new `ASPNETCORE_HTTP_PORTS` environment variable as a simpler alternative to `ASPNETCORE_URLS`. The new variable expects a semicolon delimited list of ports numbers, while the older variable expects a more complicated syntax.

Apps build using the older [`WebHost.CreateDefaultBuilder`](https://learn.microsoft.com/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder) API won't respect the new `ASPNETCORE_HTTP_PORTS` environment variable and will therefore switch to using a default port of 5000, which is not accessible outside the container, now that `ASPNETCORE_URLS` is no longer set automatically.

## Previous behavior

Prior to .NET 8, you could run a container expecting port 80 to be the default port and be able to access the running app.

For example, running the following command allowed you to access the app locally at port 8000, which is mapped to port 80 in the container:

`docker run --rm -it -p 8000:80 <my-app>`

## New behavior

Starting with .NET 8, if you map to port 80 in the container without explicitly setting the ASP.NET Core port used in the container to 80, any attempt to connect to that mapped port will fail.

For example, if you run the following command, you'd be _unable_ to connect to the application locally using port 8000.

`docker run --rm -it -p 8000:80 <my-app>`

Instead, change the command to use port 8080 within the container:

`docker run --rm -it -p 8000:8080 <my-app>`

You can see the difference in behavior in the following examples.

Mapping port `80` (failure case):

```bash
$ docker run --rm -d -p 8000:80 mcr.microsoft.com/dotnet/samples:aspnetapp
ba88b746bd7097e503f8ab6e5320c595640e242f6de4f734412944a0e2836acc
$ curl http://localhost:8000/Environment
curl: (56) Recv failure: Connection reset by peer
$ docker kill ba88b746bd7097e503f8ab6e5320c595640e242f6de4f734412944a0e2836acc
ba88b746bd7097e503f8ab6e5320c595640e242f6de4f734412944a0e2836acc
```

Mapping port `8080`:

```bash
$ docker run --rm -d -p 8000:8080 mcr.microsoft.com/dotnet/samples:aspnetapp
74d866bdaa8a5a09e4a347bba17ced321d77a2524a0853294a123640bcc7f21d
$ curl http://localhost:8000/Environment
{"runtimeVersion":".NET 8.0.0-rc.1.23419.4","osVersion":"Alpine Linux v3.18","osArchitecture":"Arm64","user":"root","processorCount":4,"totalAvailableMemoryBytes":4123820032,"memoryLimit":0,"memoryUsage":30081024,"hostName":"74d866bdaa8a"}
$ docker kill 74d866bdaa8a5a09e4a347bba17ced321d77a2524a0853294a123640bcc7f21d
74d866bdaa8a5a09e4a347bba17ced321d77a2524a0853294a123640bcc7f21d
```

Mapping port `80` with `ASPNETCORE_HTTP_PORTS` set to port `80`:

```bash
$ docker run --rm -d -p 8000:80 -e ASPNETCORE_HTTP_PORTS=80 mcr.microsoft.com/dotnet/samples:aspnetapp
3cc86b4b3ea1a7303d83171c132b0645d4adf61d80131152936b01661ae82a09
$ curl http://localhost:8000/Environment
{"runtimeVersion":".NET 8.0.0-rc.1.23419.4","osVersion":"Alpine Linux v3.18","osArchitecture":"Arm64","user":"root","processorCount":4,"totalAvailableMemoryBytes":4123820032,"memoryLimit":0,"memoryUsage":95383552,"hostName":"3cc86b4b3ea1"}
$ docker kill 3cc86b4b3ea1a7303d83171c132b0645d4adf61d80131152936b01661ae82a09
3cc86b4b3ea1a7303d83171c132b0645d4adf61d80131152936b01661ae82a09
```

If you are using [Kubernetes](https://kubernetes.io/docs/tutorials/services/connect-applications-service/) or [Docker Compose](https://docs.docker.com/compose/compose-file/05-services/#ports), you will need to change the port per those schemas. See [Using .NET with Kubernetes](https://github.com/dotnet/dotnet-docker/blob/main/samples/kubernetes/README.md) for examples.

## Version introduced

.NET 8 Preview 1

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change to the port number was made because of the need to provide a good usability experience when switching to a `non-root` user. Running as a `non-root` user requires the use of a non-privileged port in some environments. Since port 80, the previous default port, is a privileged port, the default was updated to port 8080, which is a non-privileged port.

## Recommended action

There are two ways to respond to this breaking change:

- Recommended: Explicitly set the `ASPNETCORE_HTTP_PORTS`, `ASPNETCORE_HTTPS_PORTS`, and `ASPNETCORE_URLS` environment variables to the desired port. Example: `docker run --rm -it -p 9999:80 -e ASPNETCORE_HTTP_PORTS=80 <my-app>`
- Update existing commands and configuration that rely on the expected default port of port 80 to reference port 8080 instead. Example: `docker run --rm -it -p 9999:8080 <my-app>`

If your app was built using the older <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder?displayProperty=nameWithType> method, either set `ASPNETCORE_URLS` (not `ASPNETCORE_HTTP_PORTS`) or update the expected default port of port 80 to reference port 5000 instead.

## Affected APIs

None.

## See also

- [New non-root 'app' user in Linux images](app-user.md)
- [Containerize a .NET app](../../../docker/publish-as-container.md)
- [Blog: Secure your .NET cloud apps with rootless Linux containers](https://devblogs.microsoft.com/dotnet/securing-containers-with-rootless/#switching-to-port-8080)
- [Blog: Running non-root .NET containers with Kubernetes](https://devblogs.microsoft.com/dotnet/running-nonroot-kubernetes-with-dotnet/)
