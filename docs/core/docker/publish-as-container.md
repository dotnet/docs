---
title: Containerize an app with dotnet publish
description: In this tutorial, you'll learn how to containerize a .NET application with dotnet publish.
ms.date: 10/18/2022
ms.topic: tutorial
---

# Containerize a .NET app with dotnet publish

Containers have many features and benefits, such as being an immutable infrastructure, providing a portable architecture, and enabling scalability. The image can be used to create containers for your local development environment, private cloud, or public cloud. In this tutorial, you'll learn how to containerize a .NET application using the [dotnet publish](../tools/dotnet-publish.md) command.

## Prerequisites

Install the following prerequisites:

- [.NET SDK](https://dotnet.microsoft.com/download)\
If you have .NET installed, use the `dotnet --info` command to determine which SDK you're using.
- [Docker Community Edition](https://www.docker.com/products/docker-desktop)
- Familiarity with [Worker Services in .NET](../extensions/workers.md)

## Create .NET app

You need a .NET app to containerize, so you'll start by creating a new app from a template. Open your terminal, create a working folder (*sample-directory*) if you haven't already, and change directories so that you're in it. In the working folder, run the following command to create a new project in a subdirectory named *Worker*:

```dotnetcli
dotnet new worker -o Worker -n DotNet.ContainerImage
```

Your folder tree will look like the following:

```Directory
📁 sample-directory
    └──📂 Worker
        ├──appsettings.Development.json
        ├──appsettings.json
        ├──DotNet.ContainerImage.csproj
        ├──Program.cs
        ├──Worker.cs
        └──📂 obj
            ├── DotNet.ContainerImage.csproj.nuget.dgspec.json
            ├── DotNet.ContainerImage.csproj.nuget.g.props
            ├── DotNet.ContainerImage.csproj.nuget.g.targets
            ├── project.assets.json
            └── project.nuget.cache
```

The `dotnet new` command creates a new folder named *Worker* and generates a worker service that when ran will log a message every second. Change directories and navigate into the *Worker* folder, from your terminal session. Use the `dotnet run` command to start the app. The application will run, and print `Hello World!` below the command:

```dotnetcli
dotnet run
Building...
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:00 -05:00
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\David Pine\source\repos\docs\docs\core\docker\snippets\Worker
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:01 -05:00
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:02 -05:00
info: DotNet.ContainerImage.Worker[0]
      Worker running at: 10/18/2022 08:56:03 -05:00
info: Microsoft.Hosting.Lifetime[0]
      Application is shutting down...
Attempting to cancel the build...
```

The worker template loops indefinitely. Use the cancel command <kbd>Ctrl+C</kbd> to stop it.

## Add NuGet package

The .NET 7 SDK will eventually be capable of publishing .NET apps as containers without the use of the [Microsoft.NET.Build.Containers NuGet package](https://libraries.io/nuget/Microsoft.NET.Build.Containers). Until that time, this package is required. To add the `Microsoft.NET.Build.Containers` NuGet package to the worker template, run the following [dotnet add package](../tools/dotnet-add-package.md) command:

```dotnetcli
dotnet add package Microsoft.NET.Build.Containers
```

## Set the container image name

There are various configuration options available when publishing an app as a container. For more information, see [Configure container image](#configure-container-image).

By default, the container image name is the `AssemblyName` of the project. If that name is invalid as a container image name, you can override it by specifying a `ContainerImageName` as shown in the following:

:::code language="xml" source="snippets/Worker/DotNet.ContainerImage.csproj" highlight="8":::

## Publish .NET app

To publish the .NET app as a container, use the following `dotnet publish` command:

```dotnetcli
dotnet publish --os linux --arch x64 /t:PublishContainer
```

> [!IMPORTANT]
> To build the container locally, you must have the Docker daemon running. If it isn't running when you attempt to publish the app as a container, you'll experience an error similar to the following:
>
> ```console
> ..\.nuget\packages\microsoft.net.build.containers\0.1.8\build\Microsoft.NET.Build.Containers.targets(66,9): error MSB4018: The "CreateNewImage" task failed unexpectedly. [..\Worker\DotNet.ContainerImage.csproj]
> ```

> [!TIP]
> Depending on the type of app you're containerizing, the command-line switches (options) might vary. For example, the `/t:PublishContainer` argument is only required for non-web .NET apps, such as `console` and `worker` templates. For web templates, replace the `/t:PublishContainer` argument with `-p:PublishProfile=DefaultContainer`.

This command compiles your app to the *publish* folder. The path to the *publish* folder from the working folder should be `.\Worker\bin\Release\net6.0\publish\`

#### [Windows](#tab/windows)

From the *Worker* folder, get a directory listing of the publish folder to verify that the *DotNet.Docker.dll* file was created.

```powershell
dir .\bin\Release\net6.0\publish\

    Directory: C:\Users\dapine\Worker\bin\Release\net6.0\publish

Mode                 LastWriteTime         Length Name
----                 -------------         ------ ----
-a---            3/8/2022 10:43 AM            431 DotNet.Docker.deps.json
-a---            3/8/2022 10:43 AM           6144 DotNet.Docker.dll
-a---            3/8/2022 10:43 AM         149504 DotNet.Docker.exe
-a---            3/8/2022 10:43 AM          10516 DotNet.Docker.pdb
-a---            3/8/2022 10:43 AM            253 DotNet.Docker.runtimeconfig.json
```

#### [Linux](#tab/linux)

Use the `ls` command to get a directory listing and verify that the *DotNet.Docker.dll* file was created.

```bash
me@DESKTOP:/docker-working/app$ ls bin/Release/net6.0/publish
DotNet.Docker.deps.json  DotNet.Docker.dll  DotNet.Docker.exe  DotNet.Docker.pdb  DotNet.Docker.runtimeconfig.json
```

---

## Configure container image

Now that you have an image that contains your app, you can create a container. You can create a container in two ways. First, create a new container that is stopped.

```console
docker create --name core-counter counter-image
```

The `docker create` command from above will create a container based on the **counter-image** image. The output of that command shows you the **CONTAINER ID** (yours will be different) of the created container:

```console
cf01364df4539812684c64277f5363a8fb354ef4c90785dc0845769a6c5b0f8e
```

To see a list of *all* containers, use the `docker ps -a` command:

```console
docker ps -a
CONTAINER ID   IMAGE           COMMAND                  CREATED          STATUS    PORTS     NAMES
cf01364df453   counter-image   "dotnet DotNet.Docke…"   18 seconds ago   Created             core-counter
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

The container also passes parameters into the execution of the .NET app. To instruct the .NET app to count only to 3 pass in 3.

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
    docker stop counter-image
    ```

03. Delete the container

    ```console
    docker rm counter-image
    ```

Next, delete any images that you no longer want on your machine. Delete the image created by your *Dockerfile* and then delete the .NET image the *Dockerfile* was based on. You can use the **IMAGE ID** or the **REPOSITORY:TAG** formatted string.

```console
docker rmi counter-image:latest
docker rmi mcr.microsoft.com/dotnet/aspnet:6.0
```

Use the `docker images` command to see a list of images installed.

> [!TIP]
> Image files can be large. Typically, you would remove temporary containers you created while testing and developing your app. You usually keep the base images with the runtime installed if you plan on building other images based on that runtime.

## Next steps

- [Learn how to containerize an ASP.NET Core application.](/aspnet/core/host-and-deploy/docker/building-net-docker-images)
- [Try the ASP.NET Core Microservice Tutorial.](https://dotnet.microsoft.com/learn/web/aspnet-microservice-tutorial/intro)
- [Review the Azure services that support containers.](https://azure.microsoft.com/overview/containers/)
- [Read about Dockerfile commands.](https://docs.docker.com/engine/reference/builder/)
- [Explore the Container Tools for Visual Studio](/visualstudio/containers/overview)
