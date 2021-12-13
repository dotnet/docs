---
title: Docker - gRPC for WCF Developers
description: Creating Docker images for ASP.NET Core gRPC applications
ms.date: 12/14/2021
---

# Create Docker images

This section covers the creation of Docker images for ASP.NET Core gRPC applications, ready to run in Docker, Kubernetes, or other container environments. The sample application used, with an ASP.NET Core MVC web app and a gRPC service, is available on the [dotnet-architecture/grpc-for-wcf-developers](https://github.com/dotnet-architecture/grpc-for-wcf-developers/tree/main/KubernetesSample) repository on GitHub.

## Microsoft base images for ASP.NET Core applications

Microsoft provides a range of base images for building and running .NET applications. To create an ASP.NET Core 6.0 image, you use two base images:

- An SDK image to build and publish the application.
- A runtime image for deployment.

| Image | Description |
| ----- | ----------- |
| [mcr.microsoft.com/dotnet/sdk](https://hub.docker.com/_/microsoft-dotnet-sdk/) | For building applications with `docker build`. Not to be used in production. |
| [mcr.microsoft.com/dotnet/aspnet](https://hub.docker.com/_/microsoft-dotnet-aspnet/) | Contains the runtime and ASP.NET Core dependencies. For production. |

For each image, there are four variants based on different Linux distributions, distinguished by tags.

| Image tag(s) | Linux | Notes |
| --------- | ----- | ----- |
| 6.0-bullseye-slim, 6.0 | Debian 11 | The default image if no OS variant is specified. |
| 6.0-alpine | Alpine 3.14 | Alpine base images are much smaller than Debian or Ubuntu ones. |
| 6.0-focal| Ubuntu 20.04 | |

The Alpine base image is around 100 MB, compared to 200 MB for the Debian and Ubuntu images. Some software packages or libraries might not be available in Alpine's package management. If you're not sure which image to use, you should probably choose the default Debian.

> [!IMPORTANT]
> Make sure you use the same variant of Linux for the build and the runtime. Applications built and published on one variant might not work on another.

## Create a Docker image

A Docker image is defined by a *Dockerfile*. This *Dockerfile* is a text file that contains all the commands needed to build the application and install any dependencies that are required for either building or running the application. The following example shows the simplest Dockerfile for an ASP.NET Core 6.0 application:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src

COPY ./StockKube.sln .
COPY ./src/StockData/StockData.csproj ./src/StockData/
COPY ./src/StockWeb/StockWeb.csproj ./src/StockWeb/

RUN dotnet restore

COPY . .

RUN dotnet publish --no-restore -c Release -o /published src/StockData/StockData.csproj

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

# Uncomment the line below if running with HTTPS
# ENV ASPNETCORE_URLS=https://+:443

WORKDIR /app

COPY --from=build /published .

ENTRYPOINT [ "dotnet", "StockData.dll" ]
```

The Dockerfile has two parts: the first uses the `sdk` base image to build and publish the application; the second creates a runtime image from the `aspnet` base. This is because the `sdk` image is around 900 MB, compared to around 200 MB for the runtime image, and most of its contents are unnecessary at run time.

### The build steps

| Step | Description |
| ---- | ----------- |
| `FROM ...` | Declares the base image and assigns the `builder` alias. |
| `WORKDIR /src` | Creates the `/src` directory and sets it as the current working directory. |
| `COPY . .` | Copies everything below the current directory on the host into the current directory on the image. |
| `RUN dotnet restore` | Restores any external packages (ASP.NET Core 3.0 framework is pre-installed with the SDK). |
| `RUN dotnet publish ...` | Builds and publishes a Release build. Note that the `--runtime` flag isn't required. |

### The runtime image steps

| Step | Description |
| ---- | ----------- |
| `FROM ...` | Declares a new base image. |
| `WORKDIR /app` | Creates the `/app` directory and sets it as the current working directory. |
| `COPY --from=builder ...` | Copies the published application from the previous image, by using the `builder` alias from the first `FROM` line. |
| `ENTRYPOINT [ ... ]` | Sets the command to run when the container starts. The `dotnet` command in the runtime image can only run DLL files. |

### HTTPS in Docker

Microsoft base images for Docker set the `ASPNETCORE_URLS` environment variable to `http://+:80`, meaning that Kestrel runs without HTTPS on that port. If you're using HTTPS with a custom certificate (as described in [Self-hosted gRPC applications](self-hosted.md)), you should override this configuration. Set the environment variable in the runtime image creation part of your Dockerfile.

```dockerfile
# Runtime image creation
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=https://+:443
```

### The .dockerignore file

Much like `.gitignore` files that exclude certain files and directories from source control, the `.dockerignore` file can be used to exclude files and directories from being copied to the image during build. This file not only saves time copying, but can also avoid some errors that arise from having the `obj` directory from your PC copied into the image. At a minimum, you should add entries for `bin` and `obj` to your `.dockerignore` file.

```console
bin/
obj/
```

## Build the image

For a `StockKube.sln` solution containing two different applications `StockData` and `StockWeb`, it's simplest to put the Dockerfile for each one of them in the base directory. In that case, to build the image, use the following `docker build` command from the same directory where `.sln` file resides.

```console
docker build -t stockdata:1.0.0 -f ./src/StockData/Dockerfile .
```

The confusingly named `--tag` flag (which can be shortened to `-t`) specifies the whole name of the image, including the actual tag if specified. The `.` at the end specifies the context in which the build will be run; the current working directory for the `COPY` commands in the Dockerfile.

If you have multiple applications within a single solution, you can keep the Dockerfile for each application in its own folder, beside the `.csproj` file. You should still run the `docker build` command from the base directory to ensure that the solution and all the projects are copied into the image. You can specify a Dockerfile below the current directory by using the `--file` (or `-f`) flag.

```console
docker build -t stockdata:1.0.0 -f ./src/StockData/Dockerfile .
```

## Run the image in a container on your machine

To run the image in your local Docker instance, use the `docker run` command.

```console
docker run -ti -p 5000:80 stockdata:1.0.0
```

The `-ti` flag connects your current terminal to the container's terminal, and runs in interactive mode. The `-p 5000:80` publishes (links) port 80 on the container to port 5000 on the localhost network interface.

## Push the image to a registry

After you've verified that the image works, push it to a Docker registry to make it available on other systems. Internal networks will need to provision a Docker registry. This activity can be as simple as running [Docker's own `registry` image](https://docs.docker.com/registry/deploying/) (the Docker registry runs in a Docker container), but there are various more comprehensive solutions available. For external sharing and cloud use, there are various managed registries available, such as [Azure Container Registry](/azure/container-registry/) or [Docker Hub](https://docs.docker.com/docker-hub/repos/).

To push to Docker Hub, prefix the image name with your user or organization name.

```console
docker tag stockdata:1.0.0 <myorg>/stockdata:1.0.0
docker push <myorg>/stockdata:1.0.0
```

To push to a private registry, prefix the image name with the registry host name and the organization name.

```console
docker tag stockdata <internal-registry:5000>/<myorg>/stockdata:1.0.0
docker push <internal-registry:5000>/<myorg>/stockdata:1.0.0
```

After the image is in a registry, you can deploy it to individual Docker hosts, or to a container orchestration engine like Kubernetes.

>[!div class="step-by-step"]
>[Previous](self-hosted.md)
>[Next](kubernetes.md)
