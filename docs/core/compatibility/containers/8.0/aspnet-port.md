---
title: "Breaking change: Default ASP.NET Core port changed to 8080"
description: Learn about the breaking change in containers where the default ASP.NET Core port changed to 8080.
ms.date: 07/12/2023
---
# Default ASP.NET Core port changed to 8080

The default ASP.NET Core port configured in .NET container images has been updated from port 80 to 8080.

We also added the new `ASPNETCORE_HTTP_PORTS` environment variable instead of `ASPNETCORE_URLS`.

## Previous behavior

Prior to .NET 8, you could run a container expecting port 80 to be the default port and be able to access the running app.

For example, running the following command allowed you to access the app locally at port 9999, which is mapped to port 80 in the container:

`docker run --rm -it -p 9999:80 <my-app>`

## New behavior

Starting with .NET 8, if you map to port 80 in the container without explicitly setting the ASP.NET Core port used in the container, any attempt to connect to that mapped port will fail.

For example, if you run the following command, you'd be unable to connect to the application locally using port 9999.

`docker run --rm -it -p 9999:80 <my-app>`

Instead, change the command to use port 8080 within the container:

`docker run --rm -it -p 9999:8080 <my-app>`

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

## Affected APIs

None.

## See also

- [Port switch blog post](https://devblogs.microsoft.com/dotnet/securing-containers-with-rootless/#switching-to-port-8080)
