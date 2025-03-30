---
title: Docker deployment
description: Learn how to deploy Orleans apps with Docker.
ms.date: 05/23/2025
ms.topic: how-to
ms.service: orleans
ms.custom: devops
---

# Docker deployment

> [!TIP]
> Even if familiar with Docker or Orleans, reading this article to the end is recommended to avoid potential problems with known workarounds.

This article and its sample are a work in progress. Feedback, PRs, or suggestions are welcome.

## Deploy Orleans solutions to Docker

Deploying Orleans to Docker can be tricky due to the design of Docker orchestrators and clustering stacks. The most complicated part is understanding the concept of _Overlay Network_ from Docker Swarm and the Kubernetes networking model.

Docker containers and networking models were primarily designed for running stateless and immutable containers. Spinning up a cluster running Node.js or Nginx applications is fairly easy. However, using something more elaborate, like a truly clustered or distributed application (such as one based on Orleans), might present setup difficulties. It's possible, but not as straightforward as deploying web-based applications.

Docker clustering involves grouping multiple hosts to work as a single resource pool, managed using a _Container Orchestrator_. _Docker Inc._ provides **Swarm** as their option, while _Google_ offers **Kubernetes** (also known as **K8s**). Other orchestrators like **DC/OS** and **Mesos** exist, but this document focuses on Swarm and K8s as they are more widely used.

The same grain interfaces and implementations that run anywhere Orleans is supported also run on Docker containers. No special considerations are needed to run an Orleans application in Docker containers.

The concepts discussed here apply to both .NET Core and .NET Framework 4.6.1 versions of Orleans. However, to illustrate the cross-platform nature of Docker and .NET Core, examples using .NET Core are focused on. Platform-specific details (Windows/Linux/macOS) might be provided where necessary.

## Prerequisites

This article assumes the following prerequisites are installed:

- [Docker](https://www.docker.com/community-edition#/download): Docker4X has an easy-to-use installer for major supported platforms. It contains the Docker engine and Docker Swarm.
- [Kubernetes (K8s)](https://kubernetes.io/docs/tutorials/stateless-application/hello-minikube/): Google's container orchestration offering. It includes guidance for installing _Minikube_ (a local K8s deployment) and _kubectl_ along with dependencies.
- [.NET](https://dotnet.microsoft.com/download): Cross-platform flavor of .NET.
- [Visual Studio Code (VSCode)](https://code.visualstudio.com/): Any preferred IDE can be used. VSCode is used here because it's cross-platform, ensuring examples work on all platforms. After installing VSCode, install the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

> [!IMPORTANT]
> Kubernetes installation isn't required if not using it. The Docker4X installer already includes Swarm, so no extra installation is needed for Swarm.

> [!NOTE]
> On Windows, the Docker installer enables Hyper-V during installation. Since this article and its examples use .NET Core, the container images used are based on **Windows Server NanoServer**. If planning to use .NET Framework 4.6.1 instead, use images based on **Windows Server Core** and Orleans version 1.4+ (which supports only .NET Framework).

## Create an Orleans solution

The following instructions show how to create a standard Orleans solution using the `dotnet` tooling.

Adapt the commands as appropriate for the platform. The directory structure is just a suggestion; adapt it as needed.

```bash
mkdir Orleans-Docker
cd Orleans-Docker
dotnet new sln
mkdir -p src/OrleansSilo
mkdir -p src/OrleansClient
mkdir -p src/OrleansGrains
mkdir -p src/OrleansGrainInterfaces
dotnet new console -o src/OrleansSilo --framework netcoreapp1.1
dotnet new console -o src/OrleansClient --framework netcoreapp1.1
dotnet new classlib -o src/OrleansGrains --framework netstandard1.5
dotnet new classlib -o src/OrleansGrainInterfaces --framework netstandard1.5
dotnet sln add src/OrleansSilo/OrleansSilo.csproj
dotnet sln add src/OrleansClient/OrleansClient.csproj
dotnet sln add src/OrleansGrains/OrleansGrains.csproj
dotnet sln add src/OrleansGrainInterfaces/OrleansGrainInterfaces.csproj
dotnet add src/OrleansClient/OrleansClient.csproj reference src/OrleansGrainInterfaces/OrleansGrainInterfaces.csproj
dotnet add src/OrleansSilo/OrleansSilo.csproj reference src/OrleansGrainInterfaces/OrleansGrainInterfaces.csproj
dotnet add src/OrleansGrains/OrleansGrains.csproj reference src/OrleansGrainInterfaces/OrleansGrainInterfaces.csproj
dotnet add src/OrleansSilo/OrleansSilo.csproj reference src/OrleansGrains/OrleansGrains.csproj
```

So far, only boilerplate code for the solution structure and projects has been created, and references added between them. This is no different from setting up a regular Orleans project.

At the time this article was written, Orleans 2.0 (supporting .NET Core and cross-platform development) was in Technology Preview. Its NuGet packages were hosted on a MyGet feed, not the official NuGet.org feed. To install the preview NuGet packages, use the `dotnet` CLI, forcing the source feed and version from MyGet:

```bash
dotnet add src/OrleansClient/OrleansClient.csproj package Microsoft.Orleans.Core -s https://dotnet.myget.org/F/orleans-prerelease/api/v3/index.json -v 2.0.0-preview2-201705020000
dotnet add src/OrleansGrainInterfaces/OrleansGrainInterfaces.csproj package Microsoft.Orleans.Core -s https://dotnet.myget.org/F/orleans-prerelease/api/v3/index.json -v 2.0.0-preview2-201705020000
dotnet add src/OrleansGrains/OrleansGrains.csproj package Microsoft.Orleans.Core -s https://dotnet.myget.org/F/orleans-prerelease/api/v3/index.json -v 2.0.0-preview2-201705020000
dotnet add src/OrleansSilo/OrleansSilo.csproj package Microsoft.Orleans.Core -s https://dotnet.myget.org/F/orleans-prerelease/api/v3/index.json -v 2.0.0-preview2-201705020000
dotnet add src/OrleansSilo/OrleansSilo.csproj package Microsoft.Orleans.OrleansRuntime -s https://dotnet.myget.org/F/orleans-prerelease/api/v3/index.json -v 2.0.0-preview2-201705020000
dotnet restore
```

Okay, all basic dependencies to run a simple Orleans application are now in place. Note that nothing has changed from a regular Orleans application setup up to this point. Now, let's add some code to make it functional.

## Implement the Orleans application

Assuming **VSCode** is used, run `code .` from the solution directory. This command opens the directory in **VSCode** and loads the solution.

This is the solution structure created previously.

![Visual Studio Code: Explorer with Program.cs selected.](docker-orleans-solution.png)

_Program.cs_, _OrleansHostWrapper.cs_, _IGreetingGrain.cs_, and _GreetingGrain.cs_ files were also added to the interfaces and grain projects, respectively. Here is the code for those files:

_IGreetingGrain.cs_:

```csharp
using System;
using System.Threading.Tasks;
using Orleans;

namespace OrleansGrainInterfaces
{
    public interface IGreetingGrain : IGrainWithGuidKey
    {
        Task<string> SayHello(string name);
    }
}
```

_GreetingGrain.cs_:

```csharp
using System;
using System.Threading.Tasks;
using OrleansGrainInterfaces;

namespace OrleansGrains
{
    public class GreetingGrain : Grain, IGreetingGrain
    {
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"Hello from Orleans, {name}");
        }
    }
}
```

_OrleansHostWrapper.cs_:

```csharp
using System;
using System.NET;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;
using Orleans.Runtime.Host;

namespace OrleansSilo;

public class OrleansHostWrapper
{
    private readonly SiloHost _siloHost;

    public OrleansHostWrapper(ClusterConfiguration config)
    {
        _siloHost = new SiloHost(Dns.GetHostName(), config);
        _siloHost.LoadOrleansConfig();
    }

    public int Run()
    {
        if (_siloHost is null)
        {
            return 1;
        }

        try
        {
            _siloHost.InitializeOrleansSilo();

            if (_siloHost.StartOrleansSilo())
            {
                Console.WriteLine(
                    $"Successfully started Orleans silo '{_siloHost.Name}' as a {_siloHost.Type} node.");
                return 0;
            }
            else
            {
                throw new OrleansException(
                    $"Failed to start Orleans silo '{_siloHost.Name}' as a {_siloHost.Type} node.");
            }
        }
        catch (Exception exc)
        {
            _siloHost.ReportStartupError(exc);
            Console.Error.WriteLine(exc);

            return 1;
        }
    }

    public int Stop()
    {
        if (_siloHost is not null)
        {
            try
            {
                _siloHost.StopOrleansSilo();
                _siloHost.Dispose();
                Console.WriteLine($"Orleans silo '{_siloHost.Name}' shutdown.");
            }
            catch (Exception exc)
            {
                siloHost.ReportStartupError(exc);
                Console.Error.WriteLine(exc);

                return 1;
            }
        }
        return 0;
    }
}
```

_Program.cs_ (Silo):

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.NET;
using System.Threading.Tasks;
using Orleans.Runtime.Configuration;

namespace OrleansSilo
{
    public class Program
    {
        private static OrleansHostWrapper s_hostWrapper;

        static async Task<int> Main(string[] args)
        {
            int exitCode = await InitializeOrleansAsync();

            Console.WriteLine("Press Enter to terminate...");
            Console.ReadLine();

            exitCode += ShutdownSilo();

            return exitCode;
        }

        private static int InitializeOrleansAsync()
        {
            var config = new ClusterConfiguration();
            config.Globals.DataConnectionString =
                "[AZURE STORAGE CONNECTION STRING HERE]";
            config.Globals.DeploymentId = "Orleans-Docker";
            config.Globals.LivenessType =
                GlobalConfiguration.LivenessProviderType.AzureTable;
            config.Globals.ReminderServiceType =
                GlobalConfiguration.ReminderServiceProviderType.AzureTable;
            config.Defaults.PropagateActivityId = true;
            config.Defaults.ProxyGatewayEndpoint =
                new IPEndPoint(IPAddress.Any, 10400);
            config.Defaults.Port = 10300;
            var ips = await Dns.GetHostAddressesAsync(Dns.GetHostName());
            config.Defaults.HostNameOrIPAddress =
                ips.FirstOrDefault()?.ToString();

            s_hostWrapper = new OrleansHostWrapper(config);
            return hostWrapper.Run();
        }

        static int ShutdownSilo() =>
            s_hostWrapper?.Stop() ?? 0;
    }
}
```

_Program.cs_ (client):

```csharp
using System;
using System.NET;
using System.Threading;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime.Configuration;
using OrleansGrainInterfaces;

namespace OrleansClient
{
    class Program
    {
        private static IClusterClient s_client;
        private static bool s_running;

        static async Task Main(string[] args)
        {
            await InitializeOrleansAsync();

            Console.ReadLine();

            s_running = false;
        }

        static async Task InitializeOrleansAsync()
        {
            var config = new ClientConfiguration
            {
                DeploymentId = "Orleans-Docker";
                PropagateActivityId = true;
            };
            var hostEntry =
                await Dns.GetHostEntryAsync("orleans-silo");
            var ip = hostEntry.AddressList[0];
            config.Gateways.Add(new IPEndPoint(ip, 10400));

            Console.WriteLine("Initializing...");

            using client = new ClientBuilder().UseConfiguration(config).Build();
            await client.Connect();
            s_running = true;
            Console.WriteLine("Initialized!");

            var grain = client.GetGrain<IGreetingGrain>(Guid.Empty);

            while (s_running)
            {
                var response = await grain.SayHello("Gutemberg");
                Console.WriteLine($"[{DateTime.UtcNow}] - {response}");

                await Task.Delay(1000);
            }
        }
    }
}
```

The grain implementation details aren't covered here, as it's outside the scope of this article. Refer to other relevant documents for more information. These files represent a minimal Orleans application, serving as the starting point for the rest of this article.

This article uses the `OrleansAzureUtils` membership provider, but any other Orleans-supported provider can be used.

## The Dockerfile

Docker uses images to create containers. For more details on creating custom images, check the [Docker documentation](https://docs.docker.com/engine/userguide/). This article uses official [Microsoft images](https://hub.docker.com/r/microsoft/dotnet/). Based on the target and development platforms, pick the appropriate image. `microsoft/dotnet:1.1.2-sdk`, a Linux-based image, is used here. For Windows, `microsoft/dotnet:1.1.2-sdk-nanoserver` could be used, for example. Choose the one that suits the needs.

> **Note for Windows users**: As mentioned earlier, to maintain cross-platform compatibility, .NET Core and Orleans Technical Preview 2.0 are used in this article. To use Docker on Windows with the fully released Orleans 1.4+, use images based on Windows Server Core, since NanoServer and Linux-based images only support .NET Core.

_Dockerfile.debug_:

```dockerfile
FROM microsoft/dotnet:1.1.2-sdk
ENV NUGET_XMLDOC_MODE skip
WORKDIR /vsdbg
RUN apt-get update \
    && apt-get install -y --no-install-recommends \
        unzip \
    && rm -rf /var/lib/apt/lists/* \
    && curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg
WORKDIR /app
ENTRYPOINT ["tail", "-f", "/dev/null"]
```

This _Dockerfile_ essentially downloads and installs the VSdbg debugger and starts an empty container, keeping it alive indefinitely so it doesn't need tearing down and bringing up repeatedly during debugging.

Now, for production, the image is smaller because it contains only the .NET Core runtime, not the entire SDK. The Dockerfile is also simpler:

_Dockerfile_:

```dockerfile
FROM microsoft/dotnet:1.1.2-runtime
WORKDIR /app
ENTRYPOINT ["dotnet", "OrleansSilo.dll"]
COPY . /app
```

## The docker-compose file

The `docker-compose.yml` file defines a set of services and their dependencies within a project at the service level. Each service contains one or more instances of a given container, based on the images selected in the Dockerfile. Find more details about `docker-compose` in the [docker-compose documentation](https://docs.docker.com/compose/).

For an Orleans deployment, a common use case involves a `docker-compose.yml` file containing two services: one for the Orleans Silo and another for the Orleans Client. The Client service depends on the Silo service, meaning it only starts after the Silo service runs. Another scenario might involve adding a storage or database service/container (like SQL Server), which should start before both the client and the silo. In this case, both client and silo services would depend on the database service.

> [!NOTE]
> Before reading further, note that _indentation_ **matters** in `docker-compose` files. Pay attention to it if problems arise.

Here's how the services are described for this article:

_docker-compose.override.yml_ (Debug):

```yml
version: '3.1'

services:
  orleans-client:
    image: orleans-client:debug
    build:
      context: ./src/OrleansClient/bin/PublishOutput/
      dockerfile: Dockerfile.Debug
    volumes:
      - ./src/OrleansClient/bin/PublishOutput/:/app
      - ~/.nuget/packages:/root/.nuget/packages:ro
    depends_on:
      - orleans-silo
  orleans-silo:
    image: orleans-silo:debug
    build:
      context: ./src/OrleansSilo/bin/PublishOutput/
      dockerfile: Dockerfile.Debug
    volumes:
      - ./src/OrleansSilo/bin/PublishOutput/:/app
      - ~/.nuget/packages:/root/.nuget/packages:ro
```

_docker-compose.yml_ (production):

```yml
version: '3.1'

services:
  orleans-client:
    image: orleans-client
    depends_on:
      - orleans-silo
  orleans-silo:
    image: orleans-silo
```

In production, the local directory isn't mapped, nor is the `build:` action included. The reason is that in a production environment, images should be built and pushed to a private Docker Registry.

## Put everything together

Now that all necessary components are ready, let's put them together to run the Orleans solution inside Docker.

> [!IMPORTANT]
> The following commands should be performed from the solution directory.

First, ensure all NuGet packages for the solution are restored. This typically needs doing only once, unless package dependencies change.

```dotnetcli
dotnet restore
```

Now, build the solution using the `dotnet` CLI as usual and publish it to an output directory:

```dotnetcli
dotnet publish -o ./bin/PublishOutput
```

> [!TIP]
> `publish` is used here instead of `build` to avoid problems with dynamically loaded assemblies in Orleans. A better solution is still being sought.

With the application built and published, build the Docker images using the Dockerfiles. This step typically needs performing only once per project. It should only be needed again if the Dockerfile or docker-compose file changes, or if the local image registry is cleaned up for any reason.

```shell
docker-compose build
```

All base images used in both `Dockerfile` and `docker-compose.yml` are pulled from the registry and cached on the development machine. The application images are built, and everything is ready to run.

Now, let's run the application!

```shell
# docker-compose up -d
Creating network "orleansdocker_default" with the default driver
Creating orleansdocker_orleans-silo_1 ...
Creating orleansdocker_orleans-silo_1 ... done
Creating orleansdocker_orleans-client_1 ...
Creating orleansdocker_orleans-client_1 ... done
#
```

Now, running `docker-compose ps` shows two containers running for the `orleansdocker` project:

```shell
# docker-compose ps
             Name                     Command        State   Ports
------------------------------------------------------------------
orleansdocker_orleans-client_1   tail -f /dev/null   Up
orleansdocker_orleans-silo_1     tail -f /dev/null   Up
```

> [!NOTE]
> If on Windows and the container uses a Windows base image, the **Command** column shows the PowerShell equivalent command to `tail` on *NIX systems, keeping the container running similarly.

Now that the containers are running, stopping them isn't necessary every time the Orleans application needs starting. Just integrate the IDE to debug the application inside the container, which was previously mapped in `docker-compose.yml`.

## Scaling

Once the compose project runs, easily scale the application up or down using the `docker-compose scale` command:

```shell
# docker-compose scale orleans-silo=15
Starting orleansdocker_orleans-silo_1 ... done
Creating orleansdocker_orleans-silo_2 ...
Creating orleansdocker_orleans-silo_3 ...
Creating orleansdocker_orleans-silo_4 ...
Creating orleansdocker_orleans-silo_5 ...
Creating orleansdocker_orleans-silo_6 ...
Creating orleansdocker_orleans-silo_7 ...
Creating orleansdocker_orleans-silo_8 ...
Creating orleansdocker_orleans-silo_9 ...
Creating orleansdocker_orleans-silo_10 ...
Creating orleansdocker_orleans-silo_11 ...
Creating orleansdocker_orleans-silo_12 ...
Creating orleansdocker_orleans-silo_13 ...
Creating orleansdocker_orleans-silo_14 ...
Creating orleansdocker_orleans-silo_15 ...
Creating orleansdocker_orleans-silo_6
Creating orleansdocker_orleans-silo_5
Creating orleansdocker_orleans-silo_3
Creating orleansdocker_orleans-silo_2
Creating orleansdocker_orleans-silo_4
Creating orleansdocker_orleans-silo_9
Creating orleansdocker_orleans-silo_7
Creating orleansdocker_orleans-silo_8
Creating orleansdocker_orleans-silo_10
Creating orleansdocker_orleans-silo_11
Creating orleansdocker_orleans-silo_15
Creating orleansdocker_orleans-silo_12
Creating orleansdocker_orleans-silo_14
Creating orleansdocker_orleans-silo_13
```

After a few seconds, the services scale to the specific number of instances requested.

```shell
# docker-compose ps
             Name                     Command        State   Ports
------------------------------------------------------------------
orleansdocker_orleans-client_1   tail -f /dev/null   Up
orleansdocker_orleans-silo_1     tail -f /dev/null   Up
orleansdocker_orleans-silo_10    tail -f /dev/null   Up
orleansdocker_orleans-silo_11    tail -f /dev/null   Up
orleansdocker_orleans-silo_12    tail -f /dev/null   Up
orleansdocker_orleans-silo_13    tail -f /dev/null   Up
orleansdocker_orleans-silo_14    tail -f /dev/null   Up
orleansdocker_orleans-silo_15    tail -f /dev/null   Up
orleansdocker_orleans-silo_2     tail -f /dev/null   Up
orleansdocker_orleans-silo_3     tail -f /dev/null   Up
orleansdocker_orleans-silo_4     tail -f /dev/null   Up
orleansdocker_orleans-silo_5     tail -f /dev/null   Up
orleansdocker_orleans-silo_6     tail -f /dev/null   Up
orleansdocker_orleans-silo_7     tail -f /dev/null   Up
orleansdocker_orleans-silo_8     tail -f /dev/null   Up
orleansdocker_orleans-silo_9     tail -f /dev/null   Up
```

> [!IMPORTANT]
> The `Command` column in these examples shows the `tail` command because the debugger container is used. In production, it would show `dotnet OrleansSilo.dll`, for example.

## Docker Swarm

Docker's clustering stack is called **Swarm**. For more information, see [Docker Swarm](https://docs.docker.com/engine/swarm).

To run the application described in this article in a `Swarm` cluster, no extra work is needed. Running `docker-compose up -d` on a `Swarm` node schedules containers based on configured rules. The same applies to other Swarm-based services like [Azure Kubernetes Service (AKS)](/azure/aks) (in Swarm mode) and [AWS Elastic Container Service (ECS)](https://aws.amazon.com/ecs/). Just deploy the `Swarm` cluster before deploying the **dockerized** Orleans application.

> [!NOTE]
> If using a Docker engine with Swarm mode supporting `stack`, `deploy`, and `compose` v3, a better approach to deploy the solution is `docker stack deploy -c docker-compose.yml <name>`. Keep in mind this requires a v3 compose file compatible with the Docker engine. Many hosted services like Azure and AWS still use v2 and older engines.

## Google Kubernetes (K8s)

If planning to use [Kubernetes](https://kubernetes.io/) to host Orleans, a community-maintained clustering provider is available at [OrleansContrib\Orleans.Clustering.Kubernetes](https://github.com/OrleansContrib/Orleans.Clustering.Kubernetes). There, find documentation and samples on hosting Orleans in Kubernetes seamlessly using the provider.

## Debug Orleans inside containers

Now that running Orleans in a container from scratch is understood, it's beneficial to leverage one of Docker's most important principles: immutability. Containers should have (almost) the same image, dependencies, and runtime in development as in production. This practice helps prevent the classic _"It works on my machine!"_ problem. To make this possible, a way to develop _inside_ the container is needed, including attaching a debugger to the application running inside it.

Multiple ways exist to achieve this using various tools. After evaluating several options at the time of writing, one that seems simpler and less intrusive to the application was chosen.

As mentioned earlier, `VSCode` is used to develop the sample. Here's how to attach the debugger to the Orleans application inside the container:

First, modify two files inside the `.vscode` directory in the solution:

_tasks.json_:

```json
{
    "version": "0.1.0",
    "command": "dotnet",
    "isShellCommand": true,
    "args": [],
    "tasks": [
        {
            "taskName": "publish",
            "args": [
                "${workspaceRoot}/Orleans-Docker.sln", "-c", "Debug", "-o", "./bin/PublishOutput"
            ],
            "isBuildCommand": true,
            "problemMatcher": "$msCompile"
        }
    ]
}
```

This file essentially tells `VSCode` that whenever the project builds, it executes the `publish` command, similar to how it was done manually earlier.

_launch.json_:

```json
{
   "version": "0.2.0",
   "configurations": [
        {
            "name": "Silo",
            "type": "coreclr",
            "request": "launch",
            "cwd": "/app",
            "program": "/app/OrleansSilo.dll",
            "sourceFileMap": {
                "/app": "${workspaceRoot}/src/OrleansSilo"
            },
            "pipeTransport": {
                "debuggerPath": "/vsdbg/vsdbg",
                "pipeProgram": "/bin/bash",
                "pipeCwd": "${workspaceRoot}",
                "pipeArgs": [
                    "-c",
                    "docker exec -i orleansdocker_orleans-silo_1 /vsdbg/vsdbg --interpreter=vscode"
                ]
            }
        },
        {
            "name": "Client",
            "type": "coreclr",
            "request": "launch",
            "cwd": "/app",
            "program": "/app/OrleansClient.dll",
            "sourceFileMap": {
                "/app": "${workspaceRoot}/src/OrleansClient"
            },
            "pipeTransport": {
                "debuggerPath": "/vsdbg/vsdbg",
                "pipeProgram": "/bin/bash",
                "pipeCwd": "${workspaceRoot}",
                "pipeArgs": [
                    "-c",
                    "docker exec -i orleansdocker_orleans-client_1 /vsdbg/vsdbg --interpreter=vscode"
                ]
            }
        }
    ]
}
```

Now build the solution from `VSCode` (which also publishes) and start both the Silo and Client configurations. VSCode sends a `docker exec` command to the running `docker-compose` service instance/container to start the debugger attached to the application. That's it! The debugger is attached to the container and can be used just like debugging a locally running Orleans application. The key difference is the application runs inside the container. Once development is done, publish the container image to the registry and pull it onto Docker hosts in production.
