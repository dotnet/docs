---
title: Containerize an app with Docker tutorial
description: In this tutorial, you learn how to containerize a .NET application with Docker.
ms.date: 11/17/2026
ms.topic: tutorial
ms.custom: "mvc"
zone_pivot_groups: dotnet-supported-version
ai-usage: ai-assisted
#Customer intent: As a developer, I want to containerize my .NET app so that I can deploy it to the cloud.
---

# Tutorial: Containerize a .NET app

In this tutorial, you learn how to containerize a .NET application with Docker. Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud.

In this tutorial, you:

> [!div class="checklist"]
>
> - Create and publish a simple .NET app
> - Create and configure a Dockerfile for .NET
> - Build a Docker image
> - Create and run a Docker container

You explore the Docker container build and deploy tasks for a .NET application. The _Docker platform_ uses the _Docker engine_ to quickly build and package apps as _Docker images_. These images are written in the _Dockerfile_ format to be deployed and run in a layered container.

> [!TIP]
> If you're interested in publishing your .NET app as a container without the need for Docker or Podman, see [Containerize a .NET app with dotnet publish](../containers/sdk-publish.md).

> [!NOTE]
> This tutorial **is not** for ASP.NET Core apps. If you're using ASP.NET Core, see the [Learn how to containerize an ASP.NET Core application](/aspnet/core/host-and-deploy/docker/building-net-docker-images) tutorial.

## Prerequisites

Install the following prerequisites:

:::zone pivot="dotnet-11-0"

- [.NET 11 SDK](https://dotnet.microsoft.com/download/dotnet/11.0).\
If you have .NET installed, run `dotnet --list-sdks` to check which SDKs you have installed.

:::zone-end

:::zone pivot="dotnet-10-0"

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).\
If you have .NET installed, run `dotnet --list-sdks` to check which SDKs you have installed.

:::zone-end

- [Docker Community Edition](https://www.docker.com/products/docker-desktop).
- A temporary working folder for the _Dockerfile_ and .NET example app. In this tutorial, the name _docker-working_ is used as the working folder.

## Create .NET app

You need a .NET app that the Docker container runs. Open your terminal, create a working folder if you haven't already, and enter it. In the working folder, run the following command to create a new project in a subdirectory named _App_:

:::zone pivot="dotnet-11-0"

```dotnetcli
dotnet new console -o App -n DotNet.Docker --framework net11.0
```

:::zone-end

:::zone pivot="dotnet-10-0"

```dotnetcli
dotnet new console -o App -n DotNet.Docker --framework net10.0
```

:::zone-end

To match the .NET version of the container images that you use later in this tutorial, the command includes the `--framework` option. Without this option, `dotnet new` targets the version of the active SDK, which is typically the newest SDK installed on your machine.

Your folder tree looks similar to the following directory structure:

```Directory
📁 docker-working
    └──📂 App
        ├──DotNet.Docker.csproj
        ├──Program.cs
        └──📂 obj
            ├── DotNet.Docker.csproj.nuget.dgspec.json
            ├── DotNet.Docker.csproj.nuget.g.props
            ├── DotNet.Docker.csproj.nuget.g.targets
            ├── project.assets.json
            └── project.nuget.cache
```

The `dotnet new` command creates a folder named _App_ and generates a "Hello, World" console application. In your terminal, change to the _App_ folder and run `dotnet run` to start the app. The application runs and prints `Hello, World!` below the command:

```dotnetcli
cd App
dotnet run
Hello, World!
```

The default template creates an app that prints to the terminal and then immediately terminates. For this tutorial, you use an app that loops indefinitely. Open the _Program.cs_ file in a text editor.

> [!TIP]
> If you're using Visual Studio Code, from the previous terminal session type the following command:
>
> ```console
> code .
> ```
>
> This command opens the _App_ folder that contains the project in Visual Studio Code.

The _Program.cs_ should look like the following C# code:

```csharp
Console.WriteLine("Hello, World!");
```

Replace the file with the following code that counts numbers every second:

:::zone pivot="dotnet-11-0"

:::code language="csharp" source="snippets/net11.0/App/Program.cs":::

:::zone-end

:::zone pivot="dotnet-10-0"

:::code language="csharp" source="snippets/net10.0/App/Program.cs":::

:::zone-end

Save the file and test the program again with `dotnet run`. Remember that this app runs indefinitely. Use the cancel command <kbd>Ctrl+C</kbd> to stop it. Consider the following example output:

```dotnetcli
dotnet run
Counter: 1
Counter: 2
Counter: 3
Counter: 4
^C
```

If you pass a number on the command line to the app, it limits the count to that amount and then exits. Try it with `dotnet run -- 5` to count to five.

> [!IMPORTANT]
> Any parameters after `--` aren't passed to the `dotnet run` command and instead are passed to your application.

## Publish .NET app

In order for the app to be suitable for an image creation it has to compile. The `dotnet publish` command is most apt for this, as it builds and publishes the app. For an in-depth reference, see [dotnet build](../tools/dotnet-build.md) and [dotnet publish](../tools/dotnet-publish.md) commands documentation.

```dotnetcli
dotnet publish -c Release
```

> [!TIP]
> If you're interested in publishing your .NET app as a container without the need for Docker, see [Containerize a .NET app with dotnet publish](../containers/sdk-publish.md).

The `dotnet publish` command compiles your app to the _publish_ folder. The path to the _publish_ folder from the working folder is _./App/bin/Release/\<TFM\>/publish/_, where _\<TFM\>_ is your app's target framework moniker:

:::zone pivot="dotnet-11-0"

#### [Windows](#tab/windows)

From the _App_ folder, get a directory listing of the publish folder to verify that the _DotNet.Docker.dll_ file was created.

```powershell
dir .\bin\Release\net11.0\publish\

    Directory: C:\Users\default\docker-working\App\bin\Release\net11.0\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---          11/17/2026 10:03 AM            433 DotNet.Docker.deps.json
-a---          11/17/2026 10:04 AM           6144 DotNet.Docker.dll
-a---          11/17/2026 10:04 AM          73728 DotNet.Docker.exe
-a---          11/17/2026 10:04 AM          11792 DotNet.Docker.pdb
-a---          11/17/2026 10:03 AM            342 DotNet.Docker.runtimeconfig.json
```

#### [Linux](#tab/linux)

Use the `ls` command to get a directory listing and verify that the _DotNet.Docker.dll_ file was created.

```bash
me@DESKTOP:/docker-working/App$ ls bin/Release/net11.0/publish
DotNet.Docker  DotNet.Docker.deps.json  DotNet.Docker.dll  DotNet.Docker.pdb  DotNet.Docker.runtimeconfig.json
```

---

:::zone-end

:::zone pivot="dotnet-10-0"

#### [Windows](#tab/windows)

From the _App_ folder, get a directory listing of the publish folder to verify that the _DotNet.Docker.dll_ file was created.

```powershell
dir .\bin\Release\net10.0\publish\

    Directory: C:\Users\default\docker-working\App\bin\Release\net10.0\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---          11/17/2026 10:03 AM            433 DotNet.Docker.deps.json
-a---          11/17/2026 10:04 AM           6144 DotNet.Docker.dll
-a---          11/17/2026 10:04 AM         162304 DotNet.Docker.exe
-a---          11/17/2026 10:04 AM          11096 DotNet.Docker.pdb
-a---          11/17/2026 10:03 AM            342 DotNet.Docker.runtimeconfig.json
```

#### [Linux](#tab/linux)

Use the `ls` command to get a directory listing and verify that the _DotNet.Docker.dll_ file was created.

```bash
me@DESKTOP:/docker-working/App$ ls bin/Release/net10.0/publish
DotNet.Docker  DotNet.Docker.deps.json  DotNet.Docker.dll  DotNet.Docker.pdb  DotNet.Docker.runtimeconfig.json
```

---

:::zone-end

## Create the Dockerfile

The _Dockerfile_ file is used by the `docker build` command to create a container image. This file is a text file named _Dockerfile_ that doesn't have an extension.

Create a file named _Dockerfile_ in the directory containing the _.csproj_ and open it in a text editor. This tutorial uses the ASP.NET Core runtime image (which contains the .NET runtime image) and corresponds with the .NET console application.

:::zone pivot="dotnet-11-0"

:::code language="docker" source="snippets/net11.0/App/Dockerfile":::

:::zone-end

:::zone pivot="dotnet-10-0"

:::code language="docker" source="snippets/net10.0/App/Dockerfile":::

:::zone-end

> [!NOTE]
> This tutorial intentionally uses the ASP.NET Core runtime image, although you can also use the .NET runtime image (`mcr.microsoft.com/dotnet/runtime`) for a console app.

> [!IMPORTANT]
> Including a secure hash algorithm (SHA) after the image tag in a _Dockerfile_ is a best practice. This ensures that the image is not tampered with and that the image is the same as the one you expect. The SHA is a unique identifier for the image. For more information, see [Docker Docs: Pull an image by digest](https://docs.docker.com/reference/cli/docker/image/pull/#pull-an-image-by-digest-immutable-identifier).

> [!TIP]
> This _Dockerfile_ uses multi-stage builds, which optimize the final size of the image by layering the build and leaving only required artifacts. For more information, see [Docker Docs: multi-stage builds](https://docs.docker.com/build/building/multi-stage/).

The `FROM` instructions in this _Dockerfile_ use fully qualified image names that include the registry, repository, and tag (plus an image digest). Microsoft Artifact Registry (`mcr.microsoft.com`, formerly Microsoft Container Registry) hosts publicly accessible Microsoft container images, which are listed on Docker Hub. In these image names, `dotnet/sdk` and `dotnet/aspnet` are the repositories for the .NET SDK and ASP.NET Core runtime images.

:::zone pivot="dotnet-11-0"

The `11.0` tag specifies the .NET version, so `mcr.microsoft.com/dotnet/aspnet:11.0` selects the ASP.NET Core runtime image for .NET 11. Make sure that the image tags match your app's target framework. For example, the app from the previous section targets .NET 11 (`net11.0`), so the base images in the _Dockerfile_ use the `11.0` tag.

> [!IMPORTANT]
> When you use Windows-based container images, specify an image tag more specific than `11.0`, such as `mcr.microsoft.com/dotnet/aspnet:11.0-nanoserver-ltsc2025` instead of `mcr.microsoft.com/dotnet/aspnet:11.0`. Select an image tag based on whether you use Nano Server or Windows Server Core and which OS version you target. For a full list of supported tags, see the [Microsoft .NET](https://hub.docker.com/_/microsoft-dotnet) page on Docker Hub.

:::zone-end

:::zone pivot="dotnet-10-0"

The `10.0` tag specifies the .NET version, so `mcr.microsoft.com/dotnet/aspnet:10.0` selects the ASP.NET Core runtime image for .NET 10. Make sure that the image tags match your app's target framework. For example, the app from the previous section targets .NET 10 (`net10.0`), so the base images in the _Dockerfile_ use the `10.0` tag.

> [!IMPORTANT]
> When you use Windows-based container images, specify an image tag more specific than `10.0`, such as `mcr.microsoft.com/dotnet/aspnet:10.0-nanoserver-ltsc2025` instead of `mcr.microsoft.com/dotnet/aspnet:10.0`. Select an image tag based on whether you use Nano Server or Windows Server Core and which OS version you target. For a full list of supported tags, see the [Microsoft .NET](https://hub.docker.com/_/microsoft-dotnet) page on Docker Hub.

:::zone-end

Save the _Dockerfile_ file. The directory structure of the working folder should look like the following. Some of the deeper-level files and folders are omitted to save space in the article:

:::zone pivot="dotnet-11-0"

```Directory
📁 docker-working
    └──📂 App
        ├── Dockerfile
        ├── DotNet.Docker.csproj
        ├── Program.cs
        ├──📂 bin
        │   └───📂 Release
        │        └───📂 net11.0
        │             ├───📂 publish
        │             │    ├─── DotNet.Docker.deps.json
        │             │    ├─── DotNet.Docker.dll
        │             │    ├─── DotNet.Docker.exe
        │             │    ├─── DotNet.Docker.pdb
        │             │    └─── DotNet.Docker.runtimeconfig.json
        │             ├─── DotNet.Docker.deps.json
        │             ├─── DotNet.Docker.dll
        │             ├─── DotNet.Docker.exe
        │             ├─── DotNet.Docker.pdb
        │             └─── DotNet.Docker.runtimeconfig.json
        └──📁 obj
            └──...
```

:::zone-end

:::zone pivot="dotnet-10-0"

```Directory
📁 docker-working
    └──📂 App
        ├── Dockerfile
        ├── DotNet.Docker.csproj
        ├── Program.cs
        ├──📂 bin
        │   └───📂 Release
        │        └───📂 net10.0
        │             ├───📂 publish
        │             │    ├─── DotNet.Docker.deps.json
        │             │    ├─── DotNet.Docker.dll
        │             │    ├─── DotNet.Docker.exe
        │             │    ├─── DotNet.Docker.pdb
        │             │    └─── DotNet.Docker.runtimeconfig.json
        │             ├─── DotNet.Docker.deps.json
        │             ├─── DotNet.Docker.dll
        │             ├─── DotNet.Docker.exe
        │             ├─── DotNet.Docker.pdb
        │             └─── DotNet.Docker.runtimeconfig.json
        └──📁 obj
            └──...
```

:::zone-end

On Linux, the app host file is named _DotNet.Docker_ instead of _DotNet.Docker.exe_.

The `ENTRYPOINT` instruction sets `dotnet` as the host for the `DotNet.Docker.dll`. However, it's possible to instead define the `ENTRYPOINT` as the app executable itself, relying on the OS as the app host:

```dockerfile
ENTRYPOINT ["./DotNet.Docker"]
```

This causes the app to be executed directly, without `dotnet`, and instead relies on the app host and the underlying OS. For more information on publishing cross-platform binaries, see [Cross-platform DLL deployment](../deploying/index.md#cross-platform-dll-deployment).

To build the container, from your terminal, run the following command:

```console
docker build -t counter-image -f Dockerfile .
```

Docker processes each line in the _Dockerfile_. The `.` in the `docker build` command sets the build context of the image. The `-f` switch is the path to the _Dockerfile_. This command builds the image and creates a local repository named **counter-image** that points to that image. After this command finishes, run `docker images counter-image` to list the image:

```console
docker images counter-image
IMAGE                  ID             DISK USAGE   CONTENT SIZE   EXTRA
counter-image:latest   e8cfbe5b0d98        342MB         97.7MB
```

The output shows the image name and tag (`counter-image:latest`), the image identifier, and the image size. The output format depends on your Docker version. For example, older versions of Docker display `REPOSITORY`, `TAG`, `IMAGE ID`, `CREATED`, and `SIZE` columns.

The final stage of the _Dockerfile_ defines the runtime image. It starts from the ASP.NET Core runtime image, sets the working directory, copies the published app into the image, and configures the entry point:

:::zone pivot="dotnet-11-0"

:::code language="docker" source="snippets/net11.0/App/Dockerfile" range="12-15":::

:::zone-end

:::zone pivot="dotnet-10-0"

:::code language="docker" source="snippets/net10.0/App/Dockerfile" range="12-15":::

:::zone-end

The `FROM` command specifies the base image, tag, and digest to use. The `WORKDIR` command sets the working directory inside the image to _App_.

The `COPY` command tells Docker to copy the specified source directory to a destination folder. In this example, the _publish_ contents in the `build` layer are output into the folder named _App/out_, so it's the source to copy from. All of the published contents in the _App/out_ directory are copied into current working directory (_App_).

The next command, `ENTRYPOINT`, tells Docker to configure the container to run as an executable. When the container starts, the `ENTRYPOINT` command runs. When this command ends, the container automatically stops.

> [!TIP]
> Before .NET 8, containers configured to run as read-only might fail with `Failed to create CoreCLR, HRESULT: 0x8007000E`. To address this issue, specify a `DOTNET_EnableDiagnostics` environment variable as `0` (just before the `ENTRYPOINT` step):
>
> ```dockerfile
> ENV DOTNET_EnableDiagnostics=0
> ```
>
> For more information on various .NET environment variables, see [.NET environment variables](../tools/dotnet-environment-variables.md).

## Create a container

Now that you have an image that contains your app, you can create a container. You can create a container in two ways. First, create a new container that is stopped.

```console
docker create --name core-counter counter-image
```

This `docker create` command creates a container based on the **counter-image** image. The output of the `docker create` command shows you the **CONTAINER ID** of the container (your identifier will be different):

```console
d0be06126f7db6dd1cee369d911262a353c9b7fb4829a0c11b4b2eb7b2d429cf
```

To see a list of _all_ containers, use the `docker ps -a` command:

```console
docker ps -a
CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS    PORTS     NAMES
d0be06126f7d   counter-image   "dotnet DotNet.Docke…"   12 seconds ago   Created             core-counter
```

### Manage the container

The container was created with a specific name `core-counter`. This name is used to manage the container. The following example uses the `docker start` command to start the container, and then uses the `docker ps` command to only show containers that are running:

```console
docker start core-counter
core-counter

docker ps
CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS          PORTS     NAMES
cf01364df453   counter-image   "dotnet DotNet.Docke…"   53 seconds ago   Up 10 seconds             core-counter
```

Similarly, the `docker stop` command stops the container. The following example uses the `docker stop` command to stop the container, and then uses the `docker ps` command to show that no containers are running:

```console
docker stop core-counter
core-counter

docker ps
CONTAINER ID    IMAGE    COMMAND    CREATED    STATUS    PORTS    NAMES
```

### Connect to a container

After a container is running, you can connect to it to see the output. Use the `docker start` and `docker attach` commands to start the container and peek at the output stream. In this example, the <kbd>Ctrl+C</kbd> keystroke is used to detach from the running container. This keystroke ends the process in the container unless otherwise specified, which would stop the container. The `--sig-proxy=false` parameter ensures that <kbd>Ctrl+C</kbd> doesn't stop the process in the container.

After you detach from the container, reattach to verify that it's still running and counting.

```console
docker start core-counter
core-counter

docker attach --sig-proxy=false core-counter
Counter: 7
Counter: 8
Counter: 9
^C

docker attach --sig-proxy=false core-counter
Counter: 17
Counter: 18
Counter: 19
^C
```

### Delete a container

For this article, you don't want containers hanging around that don't do anything. Delete the container you previously created. If the container is running, stop it.

```console
docker stop core-counter
```

The following example lists all containers. It then uses the `docker rm` command to delete the container and then checks a second time for any running containers.

```console
docker ps -a
CONTAINER ID    IMAGE            COMMAND                   CREATED          STATUS                        PORTS    NAMES
2f6424a7ddce    counter-image    "dotnet DotNet.Dock…"    7 minutes ago    Exited (143) 20 seconds ago            core-counter

docker rm core-counter
core-counter

docker ps -a
CONTAINER ID    IMAGE    COMMAND    CREATED    STATUS    PORTS    NAMES
```

### Single run

Docker provides the `docker run` command to create and run the container as a single command. This command eliminates the need to run `docker create` and then `docker start`. You can also set this command to automatically delete the container when the container stops. For example, use `docker run -it --rm` to do two things, first, automatically use the current terminal to connect to the container, and then when the container finishes, remove it:

```console
docker run -it --rm counter-image
Counter: 1
Counter: 2
Counter: 3
Counter: 4
Counter: 5
^C
```

The container also passes parameters into the execution of the .NET app. To instruct the .NET app to count only to three, pass in 3.

```console
docker run -it --rm counter-image 3
Counter: 1
Counter: 2
Counter: 3
```

With `docker run -it`, the <kbd>Ctrl+C</kbd> command stops the process that's running in the container, which in turn, stops the container. Since the `--rm` parameter was provided, the container is automatically deleted when the process is stopped. Verify that it doesn't exist:

```console
docker ps -a
CONTAINER ID    IMAGE    COMMAND    CREATED    STATUS    PORTS    NAMES
```

### Change the ENTRYPOINT

The `docker run` command also lets you modify the `ENTRYPOINT` command from the _Dockerfile_ and run something else, but only for that container. For example, use the following command to run `bash` or `cmd.exe`. Edit the command as necessary.

#### [Windows](#tab/windows)

In this example, `ENTRYPOINT` is changed to `cmd.exe`. <kbd>Ctrl+C</kbd> is pressed to end the process and stop the container.

```console
docker run -it --rm --entrypoint "cmd.exe" counter-image

Microsoft Windows [Version 10.0.17763.379]
(c) 2018 Microsoft Corporation. All rights reserved.

C:\>dir
 Volume in drive C has no label.
 Volume Serial Number is 3005-1E84

 Directory of C:\

04/09/2019  08:46 AM    <DIR>          app
03/07/2019  10:25 AM             5,510 License.txt
04/02/2019  01:35 PM    <DIR>          Program Files
04/09/2019  01:06 PM    <DIR>          Users
04/02/2019  01:35 PM    <DIR>          Windows
               1 File(s)          5,510 bytes
               4 Dir(s)  21,246,517,248 bytes free

C:\>^C
```

> [!NOTE]
> This example only works on Windows containers. Linux containers don't have `cmd.exe`.

#### [Linux](#tab/linux)

In this example, `ENTRYPOINT` is changed to `bash`. The `exit` command is run which ends the process and stop the container.

```bash
docker run -it --rm --entrypoint "bash" counter-image
root@9f8de8fbd4a8:/App# ls
DotNet.Docker  DotNet.Docker.deps.json  DotNet.Docker.dll  DotNet.Docker.pdb  DotNet.Docker.runtimeconfig.json
root@9f8de8fbd4a8:/App# dotnet DotNet.Docker.dll 7
Counter: 1
Counter: 2
Counter: 3
^C
root@9f8de8fbd4a8:/App# exit
exit
```

> [!NOTE]
> This example only works on Linux containers. Windows containers don't have `bash`.

---

## Essential commands

Docker has many different commands that create, manage, and interact with containers and images. These Docker commands are essential to managing your containers:

- [docker build](https://docs.docker.com/engine/reference/commandline/build/)
- [docker run](https://docs.docker.com/engine/reference/commandline/run/)
- [docker ps](https://docs.docker.com/engine/reference/commandline/ps/)
- [docker stop](https://docs.docker.com/engine/reference/commandline/stop/)
- [docker rm](https://docs.docker.com/engine/reference/commandline/rm/)
- [docker rmi](https://docs.docker.com/engine/reference/commandline/rmi/)
- [docker image](https://docs.docker.com/engine/reference/commandline/image/)

## Clean up resources

During this tutorial, you created containers and images. If you no longer need these resources, follow these steps to delete them:

1. List all containers:

    ```console
    docker ps -a
    ```

1. If the list still includes the `core-counter` container (for example, because you skipped [Delete a container](#delete-a-container)), stop and delete it:

    ```console
    docker stop core-counter
    docker rm core-counter
    ```

    You don't need to delete the containers that you started with `docker run --rm`. Docker deleted them automatically when they stopped.

1. Delete the image that you built from your _Dockerfile_ by specifying its image ID or its name and tag:

    ```console
    docker rmi counter-image:latest
    ```

Use the `docker images` command to see a list of images installed.

You don't need to delete the .NET base images from your _Dockerfile_. If `docker images` lists base images that you no longer want, such as `mcr.microsoft.com/dotnet/sdk` or `mcr.microsoft.com/dotnet/aspnet`, delete them with `docker rmi`. Docker also stores data from image builds in a build cache. To remove unused build cache data, run `docker builder prune`.

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

## Next steps

- [Containerize a .NET app with dotnet publish](../containers/sdk-publish.md)
- [.NET container images](container-images.md)
- [Containerize an ASP.NET Core application](/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Azure services that support containers](https://azure.microsoft.com/overview/containers/)
- [Dockerfile commands](https://docs.docker.com/engine/reference/builder/)
- [Container Tools for Visual Studio](/visualstudio/containers/overview)
