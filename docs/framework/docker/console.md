---
title: Running Console applications in Docker
description: Running Console applications in Docker
keywords: .NET, container, Console, Applications, Docker
author: spboyer
manager: wpickett
ms.date: 09/28/2016
ms.topic: article
ms.prod: .net-framework-4.6
ms.technology: vs-ide-deployment
ms.devlang: dotnet
ms.assetid: 85cca1d5-c9a4-4eb2-93e6-4f878de07fd7
---

# Running console applications in Windows containers

Console applications are used for many purposes; from simple querying of a status to long running document image processing tasks. In either case, the ability to start up and scale these applications are met with limitations of hardware acquisitions, startup times or running multiple instances.

Moving your console applications to use Docker and Windows containers allows for starting these applications from clean state, perform the operation and then shutdown cleanly. This topic will show the steps needed to move a console application to a Windows based container and start it using a PowerShell script.

The sample console application is a simple example which takes an argument, a question in this case, and returns a random answer. This could take a `customer_id` and process their taxes, or create a thumbnail for an `image_url` argument.

In addition to the answer, the `Environment.MachineName` has been added to the end of the answer to show when running the application locally, your local machine name should be returned and when running in a Windows Container; the container session id is returned.

The completed example is available in the [dotnet/core-docs repository on GitHub](https://github.com/dotnet/core-docs/tree/master/samples/framework/docker/ConsoleRandomAnswerGenerator).

## Getting started
You'll need to have Docker for Windows, version 1.12 Beta 26 or higher to support Windows containers. By default, Docker enables Linux based containers; switch to Windows containers by right clicking the Docker icon in the system tray and select "Switch to Windows Containers...". Docker will run the process to change and a restart may be required.

Moving your console application is a matter of a few steps.

1. Writing a PowerShell script to build the application
1. Creating a Dockerfile for the image
1. Process to build and run the Docker container

## Building the application
Typically console applications are distributed through an installer, FTP, or File Share deployment. Here the assets need to be compiled and staged to a location that can be used when the Docker image is created.

In **build.ps1** the script uses MSBuild to compile the application with a configuration of *Release* and publishes the assets to the *publish* folder.

```
function Invoke-MSBuild ([string]$MSBuildPath, [string]$MSBuildParameters) {
    Invoke-Expression "$MSBuildPath $MSBuildParameters"
}

Invoke-MSBuild -MSBuildPath "MSBuild.exe" -MSBuildParameters ".\ConsoleRandomAnswerGenerator.csproj /p:OutputPath=.\publish /p:Configuration=Release"
```

## Creating the Dockerfile
The base image used for a Console .NET Framework applications is `microsoft/windowsservercore`, publically available on [Docker Hub](https://hub.docker.com/r/microsoft/windowsservercore/). The image is the minimal installation of Windows Server 2016 and serves as the base OS image for Windows containers.

```
FROM microsoft/windowsservercore
```

The next line in the file copies the application assets from the **publish** folder to root folder of the container.

```
ADD publish/ /
```

Last, setting the ENTRYPOINT of the image states that this is the command or application that will run when the container starts. 
```
ENTRYPOINT ConsoleRandomAnswerGenerator.exe
```

## Creating the image
Adding the following code to the **build.ps1** script, when run the Docker image called `console-random-answer-generator` is created after the compilation is complete.

```
$ImageName="console-random-answer-generator"

function Invoke-Docker-Build ([string]$ImageName, [string]$ImagePath, [string]$DockerBuildArgs = "") {
    echo "docker build -t $ImageName $ImagePath $DockerBuildArgs"
    Invoke-Expression "docker build -t $ImageName $ImagePath $DockerBuildArgs"
}

Invoke-Docker-Build -ImageName $ImageName -ImagePath "."
```

When the build is complete, using the `docker images` command from a command line or PowerShell prompt; you'll see that the image is created and ready to be run.

```
REPOSITORY                        TAG                 IMAGE ID            CREATED             SIZE
console-random-answer-generator   latest              8f7c807db1b5        8 seconds ago       7.33 GB
```

## Running the container
You can start the container from the command line using the Docker commands.

```
docker run console-random-answer-generator "Are you a square container?"
```

The output is

```
The answer to your question: 'Are you a square container?' is Concentrate and ask again on (70C3D48F4343)
```

If you run the `docker ps -a` command from PowerShell, you can see that the container is still running.

```
CONTAINER ID        IMAGE                             COMMAND                  CREATED             STATUS                          
70c3d48f4343        console-random-answer-generator   "cmd /S /C ConsoleRan"   2 minutes ago       Exited (0) About a minute ago      
```

The STATUS column shows at "About a minute ago", the application was complete and could be shut down. If the command was run a hundred times, there would be a hundred containers left static with no work to do. In the beginning scenario the ideal operation was to do the work and shutdown or cleanup. To accomplish that workflow, adding the `--rm` option to the `docker run` command will remove the container as soon as the `Exited` signal is received.

```
docker run --rm console-random-answer-generator "Are you a square container?"
```

Running the command with this option and then looking at the output of `docker ps -a` command; notice that the container id (the `Environment.MachineName`) is not in the list.

### Running the container using PowerShell
In the sample project files there is also a **run.ps1** which is an example of how to use PowerShell to run the application accepting the arguments.

To run, open PowerShell and use the following command

```
.\run.ps1 "Is this easy or what?"
```

## Summary
Just by adding a Dockerfile and publishing the application, you can containerize your .NET Framework Console applications and now take the advantage of running multiple instances, clean start and stop and more Windows Server 2016 capabilities without making any changes to the application code at all.
