---
title: Containerize an app with Docker tutorial
description: In this tutorial, you'll learn how to containerize a .NET application with Docker.
ms.date: 09/22/2023
ms.topic: tutorial
ms.custom: "mvc"
zone_pivot_groups: dotnet-version-7-8
#Customer intent: As a developer, I want to containerize my .NET app so that I can deploy it to the cloud.
---

# Tutorial: Containerize a .NET app

In this tutorial, you'll learn how to containerize a .NET application with Docker. Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud.

In this tutorial, you:

> [!div class="checklist"]
>
> - Create and publish a simple .NET app
> - Create and configure a Dockerfile for .NET
> - Build a Docker image
> - Create and run a Docker container

You'll understand the Docker container build and deploy tasks for a .NET application. The *Docker platform* uses the *Docker engine* to quickly build and package apps as *Docker images*. These images are written in the *Dockerfile* format to be deployed and run in a layered container.

> [!NOTE]
> This tutorial **is not** for ASP.NET Core apps. If you're using ASP.NET Core, see the [Learn how to containerize an ASP.NET Core application](/aspnet/core/host-and-deploy/docker/building-net-docker-images) tutorial.

## Prerequisites

Install the following prerequisites:

:::zone pivot="dotnet-8-0"

- [.NET 8+ SDK](https://dotnet.microsoft.com/download/dotnet/8.0)\
If you have .NET installed, use the `dotnet --info` command to determine which SDK you're using.
- [Docker Community Edition](https://www.docker.com/products/docker-desktop)
- A temporary working folder for the *Dockerfile* and .NET example app. In this tutorial, the name *docker-working* is used as the working folder.

:::zone-end
:::zone pivot="dotnet-7-0"

- [.NET 7+ SDK](https://dotnet.microsoft.com/download/dotnet/7.0)\
If you have .NET installed, use the `dotnet --info` command to determine which SDK you're using.
- [Docker Community Edition](https://www.docker.com/products/docker-desktop)
- A temporary working folder for the *Dockerfile* and .NET example app. In this tutorial, the name *docker-working* is used as the working folder.

:::zone-end

## Create .NET app

You need a .NET app that the Docker container will run. Open your terminal, create a working folder if you haven't already, and enter it. In the working folder, run the following command to create a new project in a subdirectory named *App*:

```dotnetcli
dotnet new console -o App -n DotNet.Docker
```

Your folder tree will look like the following:

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

The `dotnet new` command creates a new folder named *App* and generates a "Hello World" console application. Change directories and navigate into the *App* folder, from your terminal session. Use the `dotnet run` command to start the app. The application will run, and print `Hello World!` below the command:

```dotnetcli
cd App
dotnet run
Hello World!
```

The default template creates an app that prints to the terminal and then immediately terminates. For this tutorial, you'll use an app that loops indefinitely. Open the *Program.cs* file in a text editor.

> [!TIP]
> If you're using Visual Studio Code, from the previous terminal session type the following command:
>
> ```console
> code .
> ```
>
> This will open the *App* folder that contains the project in Visual Studio Code.

The *Program.cs* should look like the following C# code:

```csharp
Console.WriteLine("Hello World!");
```

Replace the file with the following code that counts numbers every second:

:::zone pivot="dotnet-8-0"

:::code source="snippets/8.0/App/Program.cs":::

:::zone-end
:::zone pivot="dotnet-7-0"

:::code source="snippets/7.0/App/Program.cs":::

:::zone-end

Save the file and test the program again with `dotnet run`. Remember that this app runs indefinitely. Use the cancel command <kbd>Ctrl+C</kbd> to stop it. The following is an example output:

```dotnetcli
dotnet run
Counter: 1
Counter: 2
Counter: 3
Counter: 4
^C
```

If you pass a number on the command line to the app, it will only count up to that amount and then exit. Try it with `dotnet run -- 5` to count to five.

> [!IMPORTANT]
> Any parameters after `--` are not passed to the `dotnet run` command and instead are passed to your application.

## Publish .NET app

Before adding the .NET app to the Docker image, first it must be published. It is best to have the container run the published version of the app. To publish the app, run the following command:

```dotnetcli
dotnet publish -c Release
```

:::zone pivot="dotnet-8-0"

This command compiles your app to the *publish* folder. The path to the *publish* folder from the working folder should be `.\App\bin\Release\net8.0\publish\`.

:::zone-end
:::zone pivot="dotnet-7-0"

This command compiles your app to the *publish* folder. The path to the *publish* folder from the working folder should be `.\App\bin\Release\net7.0\publish\`.

:::zone-end

#### [Windows](#tab/windows)

From the *App* folder, get a directory listing of the publish folder to verify that the *DotNet.Docker.dll* file was created.

:::zone pivot="dotnet-8-0"

```powershell
dir .\bin\Release\net8.0\publish\

    Directory: C:\Users\default\App\bin\Release\net8.0\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           9/22/2023  9:17 AM            431 DotNet.Docker.deps.json
-a---           9/22/2023  9:17 AM           6144 DotNet.Docker.dll
-a---           9/22/2023  9:17 AM         157696 DotNet.Docker.exe
-a---           9/22/2023  9:17 AM          11688 DotNet.Docker.pdb
-a---           9/22/2023  9:17 AM            353 DotNet.Docker.runtimeconfig.json
```

:::zone-end
:::zone pivot="dotnet-7-0"

```powershell
dir .\bin\Release\net7.0\publish\

    Directory: C:\Users\default\App\bin\Release\net7.0\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---           2/13/2023  1:52 PM            431 DotNet.Docker.deps.json
-a---           2/13/2023  1:52 PM           6144 DotNet.Docker.dll
-a---           2/13/2023  1:52 PM         153600 DotNet.Docker.exe
-a---           2/13/2023  1:52 PM          11052 DotNet.Docker.pdb
-a---           2/13/2023  1:52 PM            253 DotNet.Docker.runtimeconfig.json
```

:::zone-end

#### [Linux](#tab/linux)

Use the `ls` command to get a directory listing and verify that the *DotNet.Docker.dll* file was created.

:::zone pivot="dotnet-8-0"

```bash
me@DESKTOP:/docker-working/app$ ls bin/Release/net8.0/publish
DotNet.Docker.deps.json  DotNet.Docker.dll  DotNet.Docker.exe  DotNet.Docker.pdb  DotNet.Docker.runtimeconfig.json
```

:::zone-end
:::zone pivot="dotnet-7-0"

```bash
me@DESKTOP:/docker-working/app$ ls bin/Release/net7.0/publish
DotNet.Docker.deps.json  DotNet.Docker.dll  DotNet.Docker.exe  DotNet.Docker.pdb  DotNet.Docker.runtimeconfig.json
```

:::zone-end

---

## Create the Dockerfile

The *Dockerfile* file is used by the `docker build` command to create a container image. This file is a text file named *Dockerfile* that doesn't have an extension.

Create a file named *Dockerfile* in the directory containing the *.csproj* and open it in a text editor. This tutorial will use the ASP.NET Core runtime image (which contains the .NET runtime image) and corresponds with the .NET console application.

:::zone pivot="dotnet-8-0"

:::code language="docker" source="snippets/8.0/App/Dockerfile":::

> [!NOTE]
> The ASP.NET Core runtime image is used intentionally here, although the `mcr.microsoft.com/dotnet/runtime:8.0` image could have been used.

> [!TIP]
> This _Dockerfile_ uses multi-stage builds, which optimizes the final size of the image by layering the build and leaving only required artifacts. For more information, see [Docker Docs: multi-stage builds](https://docs.docker.com/build/building/multi-stage/).

The `FROM` keyword requires a fully qualified Docker container image name. The Microsoft Container Registry (MCR, mcr.microsoft.com) is a syndicate of Docker Hub—which hosts publicly accessible containers. The `dotnet` segment is the container repository, whereas the `sdk` or `aspnet` segment is the container image name. The image is tagged with `8.0`, which is used for versioning. Thus, `mcr.microsoft.com/dotnet/aspnet:8.0` is the .NET 8.0 runtime. Make sure that you pull the runtime version that matches the runtime targeted by your SDK. For example, the app created in the previous section used the .NET 8.0 SDK and the base image referred to in the *Dockerfile* is tagged with **8.0**.

Save the *Dockerfile* file. The directory structure of the working folder should look like the following. Some of the deeper-level files and folders have been omitted to save space in the article:

```Directory
📁 docker-working
    └──📂 App
        ├── Dockerfile
        ├── DotNet.Docker.csproj
        ├── Program.cs
        ├──📂 bin
        │   └──📂 Release
        │       └──📂 net8.0
        │           └──📂 publish
        │               ├── DotNet.Docker.deps.json
        │               ├── DotNet.Docker.exe
        │               ├── DotNet.Docker.dll
        │               ├── DotNet.Docker.pdb
        │               └── DotNet.Docker.runtimeconfig.json
        └──obj 📁
            └──...
```

:::zone-end
:::zone pivot="dotnet-7-0"

:::code language="docker" source="snippets/7.0/App/Dockerfile":::

> [!NOTE]
> The ASP.NET Core runtime image is used intentionally here, although the `mcr.microsoft.com/dotnet/runtime:7.0` image could have been used.

> [!TIP]
> This _Dockerfile_ uses multi-stage builds, which optimizes the final size of the image by layering the build and leaving only required artifacts. For more information, see [Docker Docs: multi-stage builds](https://docs.docker.com/build/building/multi-stage/).

The `FROM` keyword requires a fully qualified Docker container image name. The Microsoft Container Registry (MCR, mcr.microsoft.com) is a syndicate of Docker Hub—which hosts publicly accessible containers. The `dotnet` segment is the container repository, whereas the `sdk` or `aspnet` segment is the container image name. The image is tagged with `7.0`, which is used for versioning. Thus, `mcr.microsoft.com/dotnet/aspnet:7.0` is the .NET 7.0 runtime. Make sure that you pull the runtime version that matches the runtime targeted by your SDK. For example, the app created in the previous section used the .NET 7.0 SDK and the base image referred to in the *Dockerfile* is tagged with **7.0**.

Save the *Dockerfile* file. The directory structure of the working folder should look like the following. Some of the deeper-level files and folders have been omitted to save space in the article:

```Directory
📁 docker-working
    └──📂 App
        ├── Dockerfile
        ├── DotNet.Docker.csproj
        ├── Program.cs
        ├──📂 bin
        │   └──📂 Release
        │       └──📂 net7.0
        │           └──📂 publish
        │               ├── DotNet.Docker.deps.json
        │               ├── DotNet.Docker.exe
        │               ├── DotNet.Docker.dll
        │               ├── DotNet.Docker.pdb
        │               └── DotNet.Docker.runtimeconfig.json
        └──obj 📁
            └──...
```

:::zone-end

From your terminal, run the following command:

```console
docker build -t counter-image -f Dockerfile .
```

Docker will process each line in the *Dockerfile*. The `.` in the `docker build` command sets the build context of the image. The `-f` switch is the path to the _Dockerfile_. This command builds the image and creates a local repository named **counter-image** that points to that image. After this command finishes, run `docker images` to see a list of images installed:

:::zone pivot="dotnet-8-0"

```console
docker images
REPOSITORY                         TAG       IMAGE ID       CREATED          SIZE
counter-image                      latest    2f15637dc1f6   10 minutes ago   217MB
```

The `counter-image` repository is the name of the image. The `latest` tag is the tag that is used to identify the image. The `2f15637dc1f6` is the image ID. The `10 minutes ago` is the time the image was created. The `217MB` is the size of the image. The final steps of the _Dockerfile_ are to create a container from the image and run the app, copy the published app to the container, and define the entry point.

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
```

:::zone-end
:::zone pivot="dotnet-7-0"

```console
docker images
REPOSITORY                         TAG       IMAGE ID       CREATED          SIZE
counter-image                      latest    2f15637dc1f6   10 minutes ago   208MB
```

The `counter-image` repository is the name of the image. The `latest` tag is the tag that is used to identify the image. The `2f15637dc1f6` is the image ID. The `10 minutes ago` is the time the image was created. The `208MB` is the size of the image. The final steps of the _Dockerfile_ are to create a container from the image and run the app, copy the published app to the container, and define the entry point.

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
```

:::zone-end

The `COPY` command tells Docker to copy the specified folder on your computer to a folder in the container. In this example, the *publish* folder is copied to a folder named *App/out* in the container.

The `WORKDIR` command changes the **current directory** inside of the container to *App*.

The next command, `ENTRYPOINT`, tells Docker to configure the container to run as an executable. When the container starts, the `ENTRYPOINT` command runs. When this command ends, the container will automatically stop.

> [!TIP]
> For added security, you can opt out of the diagnostic pipeline. When you opt-out this allows the container to run as read-only. To do this, specify a `DOTNET_EnableDiagnostics` environment variable as `0` (just before the `ENTRYPOINT` step):
>
> ```dockerfile
> ENV DOTNET_EnableDiagnostics=0
> ```
>
> For more information on various .NET environment variables, see [.NET environment variables](../tools/dotnet-environment-variables.md).

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

## Create a container

Now that you have an image that contains your app, you can create a container. You can create a container in two ways. First, create a new container that is stopped.

```console
docker create --name core-counter counter-image
```

This `docker create` command will create a container based on the **counter-image** image. The output of that command shows you the **CONTAINER ID** (yours will be different) of the created container:

```console
d0be06126f7db6dd1cee369d911262a353c9b7fb4829a0c11b4b2eb7b2d429cf
```

To see a list of *all* containers, use the `docker ps -a` command:

```console
docker ps -a
CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS    PORTS     NAMES
d0be06126f7d   counter-image   "dotnet DotNet.Docke…"   12 seconds ago   Created             core-counter
```

### Manage the container

The container was created with a specific name `core-counter`, this name is used to manage the container. The following example uses the `docker start` command to start the container, and then uses the `docker ps` command to only show containers that are running:

```console
docker start core-counter
core-counter

docker ps
CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS          PORTS     NAMES
cf01364df453   counter-image   "dotnet DotNet.Docke…"   53 seconds ago   Up 10 seconds             core-counter
```

Similarly, the `docker stop` command will stop the container. The following example uses the `docker stop` command to stop the container, and then uses the `docker ps` command to show that no containers are running:

```console
docker stop core-counter
core-counter

docker ps
CONTAINER ID    IMAGE    COMMAND    CREATED    STATUS    PORTS    NAMES
```

### Connect to a container

After a container is running, you can connect to it to see the output. Use the `docker start` and `docker attach` commands to start the container and peek at the output stream. In this example, the <kbd>Ctrl+C</kbd> keystroke is used to detach from the running container. This keystroke will end the process in the container unless otherwise specified, which would stop the container. The `--sig-proxy=false` parameter ensures that <kbd>Ctrl+C</kbd> will not stop the process in the container.

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

With `docker run -it`, the <kbd>Ctrl+C</kbd> command will stop process that is running in the container, which in turn, stops the container. Since the `--rm` parameter was provided, the container is automatically deleted when the process is stopped. Verify that it doesn't exist:

```console
docker ps -a
CONTAINER ID    IMAGE    COMMAND    CREATED    STATUS    PORTS    NAMES
```

### Change the ENTRYPOINT

The `docker run` command also lets you modify the `ENTRYPOINT` command from the *Dockerfile* and run something else, but only for that container. For example, use the following command to run `bash` or `cmd.exe`. Edit the command as necessary.

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

During this tutorial, you created containers and images. If you want, delete these resources. Use the following commands to

01. List all containers

    ```console
    docker ps -a
    ```

02. Stop containers that are running by their name.

    ```console
    docker stop core-counter
    ```

03. Delete the container

    ```console
    docker rm core-counter
    ```

Next, delete any images that you no longer want on your machine. Delete the image created by your *Dockerfile* and then delete the .NET image the *Dockerfile* was based on. You can use the **IMAGE ID** or the **REPOSITORY:TAG** formatted string.

:::zone pivot="dotnet-8-0"

```console
docker rmi counter-image:latest
docker rmi mcr.microsoft.com/dotnet/aspnet:8.0
```

:::zone-end
:::zone pivot="dotnet-7-0"

```console
docker rmi counter-image:latest
docker rmi mcr.microsoft.com/dotnet/aspnet:7.0
```

:::zone-end

Use the `docker images` command to see a list of images installed.

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

:::zone pivot="dotnet-8-0"

## Next steps

- [Containerize a .NET app with dotnet publish](publish-as-container.md)
- [.NET container images](container-images.md)
- [Containerize an ASP.NET Core application](/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Azure services that support containers](https://azure.microsoft.com/overview/containers/)
- [Dockerfile commands](https://docs.docker.com/engine/reference/builder/)
- [Container Tools for Visual Studio](/visualstudio/containers/overview)
