---
title: Build ASP.NET Core 3.1 applications deployed as Linux containers into AKS/Kubernetes clusters
description: Containerized Docker Application Lifecycle with Microsoft Platform and Tools
ms.date: 02/25/2019
---
# Build ASP.NET Core 3.1 applications deployed as Linux containers into an AKS/Kubernetes orchestrator

Azure Kubernetes Services (AKS) is Azure's managed Kubernetes orchestrations services that simplify container deployment and management.

AKS main features are:

- An Azure-hosted control plane
- Automated upgrades
- Self-healing
- User configurable scaling
- A simpler user experience for both developers and cluster operators.

The following examples explore the creation of an ASP.NET Core 3.1 application that runs on Linux and deploys to an AKS Cluster in Azure, while development is done using Visual Studio 2019.

## Creating the ASP.NET Core 3.1 Project using Visual Studio 2019

ASP.NET Core is a general-purpose development platform maintained by Microsoft and the .NET community on GitHub. It's cross-platform, supporting Windows, macOS and Linux, and can be used in device, cloud, and embedded/IoT scenarios.

This example uses a simple project that's based on a Visual Studio Web API template, so you don't need any additional knowledge to create the sample. You only have to create the project using a standard template that includes all the elements to run a small project with a REST API, using ASP.NET Core 3.1 technology.

![Add new project window in Visual Studio, selecting ASP.NET Core Web Application.](media/create-aspnet-core-application.png)

**Figure 4-36**. Creating an ASP.NET Core Web Application in Visual Studio 2019.

To create the sample project in Visual Studio, select **File** > **New** > **Project**, select the **Web** project type and then the **ASP.NET Core Web Application** template. You can also search for the template if you need it.

Then enter the application name and location as shown in the next image.

![Enter the project name and location.](media/enter-project-name-and-location.png)

**Figure 4-37**. Enter the project name and location in Visual Studio 2019.

Verify that you've selected ASP.NET Core 3.1 as the framework. .NET Core 3.1 is included in the latest release of Visual Studio 2019 and is automatically installed and configured for you when you install Visual Studio.

![Visual Studio dialog for selecting the type of an ASP.NET Core Web Application with API option selected.](media/create-web-api-application.png)

**Figure 4-38**. Selecting ASP.NET CORE 3.1 and Web API project type

If you have any previous version of .NET Core, you can download and install the 3.1 version from <https://dotnet.microsoft.com/download>.

You can add Docker support when creating the project or afterwards, so you can "Dockerize" your project at any time. To add Docker support after project creation, right-click on the project node in Solution Explorer and select **Add** > **Docker support** on the context menu.

![Context menu option to add Docker support to an existing project: Right click (on the project) > Add > Docker Support.](media/add-docker-support-to-project.png)

**Figure 4-39**. Adding Docker support to an existing project

To complete adding Docker support, you can choose Windows or Linux. In this case, select **Linux**. AKS support for Windows container is currently in preview (as of early 2020).

![Option dialog to select Target OS for Dockerfile.](media/select-linux-docker-support.png)

**Figure 4-40**. Selecting Linux containers.

With these simple steps, you have your ASP.NET Core 3.1 application running on a Linux container.

As you can see, the integration between Visual Studio 2019 and Docker is completely oriented to the developer’s productivity.

Now you can run your application with the **F5** key or by using the **Play** button.

After running the project, you can list the images using the `docker images` command. You should see the `mssampleaksapplication` image created by the automatic deployment of our project with Visual Studio 2019.

```console
docker images
```

![Console output from the docker images command, shows a list with: Repository, Tag, Image ID, Created (date), and Size.](media/docker-images-command.png)

**Figure 4-41**. View of Docker images

And if you install the [Visual Studio Container Tools Extensions](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vs-containers-tools-extensions) (currently in preview) you can easily explore and manage containers and images, as show in the next figure.

![Visual Studio Container Tools Extensions window](media/visual-studio-container-tools-extensions.png)

**Figure 4-42**. Visual Studio Container Tools Extensions window

## Register the Solution in the Azure Container Registry

Upload the image to any Docker registry, like [Azure Container Registry (ACR)](https://azure.microsoft.com/services/container-registry/) or Docker Hub, so the images can be deployed to the AKS cluster from that registry. In this case, we’re uploading the image to Azure Container Registry.

### Create the image in Release mode

We'll now create the image in **Release** mode (ready for production) by changing to **Release**, as shown in Figure 4-43, and running the application as we did before.

![Toolbar option in VS to build in release mode.](media/select-release-mode.png)

**Figure 4-43**. Selecting Release Mode

If you execute the `docker images` command, you'll see both images created, one for `debug` (**dev**) and the other for `release` (**latest**) mode.

### Create a new Tag for the Image

Each container image needs to be tagged with the `loginServer` name of the registry. This tag is used for routing when pushing container images to an image registry.

You can view the `loginServer` name from the Azure portal, taking the information from the Azure Container Registry

![Browser view of the Azure container registry name, on the top right.](media/loginServer-name.png)

**Figure 4-44**. View of the name of the Registry

Or by running the following command:

```console
az acr list --resource-group <resource-group-name> --query "[].{acrLoginServer:loginServer}" --output table
```

![Console output from the above command.](media/az-cli-loginServer-name.png)

**Figure 4-45**. Get the name of the registry using PowerShell

In both cases, you'll obtain the name. In our example, `plainconceptsacr.azurecr.io`.

Now you can tag the image, taking the latest image (the Release image), with the command:

```console
docker tag <image-name>:latest <login-server-name>/<image-name>:v1
```

After running the `docker tag` command, list the images with the `docker images` command, and you should see the image with the new tag.

![Console output from the docker images command.](media/tagged-docker-images-list.png)

**Figure 4-46**. View of tagged images

### Push the image into the Azure ACR

Log in to the Azure Container Registry

```console
az acr login --name <login-server-name>
```

Push the image into the Azure ACR, using the following command:

```console
docker push <login-server-name>/<image-name>:v1
```

This command takes a while uploading the images but gives you feedback in the process.

![Console output from the docker push command: shows a character-based progress bar for each layer.](media/uploading-image-to-acr.png)

**Figure 4-47**. Uploading the image to the ACR

You can see below the result you should get when the process completes:

![Console output from the docker push command, finished, showing all layers or nodes.](media/uploading-docker-images-complete.png)

**Figure 4-48**. View of nodes

The next step is to deploy your container into your AKS Kubernetes cluster. For that, you need a file (**.yml deploy file**) that contains the following:

```yml
apiVersion: apps/v1beta1
kind: Deployment
metadata:
  name: mssamplesbook
spec:
  replicas: 1
  template:
    metadata:
      labels:
        app: mssample-kub-app
    spec:
      containers:
        - name: mssample-services-app
          image: mssampleacr.azurecr.io/mssampleaksapplication:v1
          ports:
            - containerPort: 80
---
apiVersion: v1
kind: Service
metadata:
    name: mssample-kub-app
spec:
  ports:
    - name: http-port
      port: 80
      targetPort: 80
  selector:
    app: mssample-kub-app
  type: LoadBalancer
```

> [!TIP]
> You can see how to create the AKS Cluster for this sample in section [**Deploy to Azure Kubernetes Service (AKS)**](deploy-azure-kubernetes-service.md) on this guide.

Now you're almost ready to deploy using **Kubectl**, but first you must get the credentials to the AKS Cluster with this command:

```console
az aks get-credentials --resource-group MSSampleResourceGroupAKS --name mssampleclusterk801
```

![Console output from the above command: Merged "MSSampleK8Cluster as current context in  /root/.kube/config](media/getting-aks-credentials.png)

**Figure 4-49**. getting credentials

Then, use the `kubectl create` command to launch the deployment.

```console
kubectl create -f mssample-deploy.yml
```

![Console output from the above command: deployment "mssamplesbook" created. service "mssample-kub-app" created.](media/kubectl-create-command.png)

**Figure 4-50**. Deploy to Kubernetes

When the deployment completes, you can access the Kubernetes console with a local proxy that you can temporally access with this command:

```console
az aks browse --resource-group MSSampleResourceGroupAKS --name mssampleclusterk801
```

And accessing the url `http://127.0.0.1:8001`.

![Browser view of the Kubernetes dashboard, showing Deployments, Pods, Replica Sets, and Services.](media/kubernetes-cluster-information.png)

**Figure 4-51**. View Kubernetes cluster information

Now you have your application deployed on Azure, using a Linux Container, and an AKS Kubernetes Cluster. You can access your app browsing to the public IP of your service, which you can get from the Azure portal.

> [!NOTE]
> For more information on deployment with Kubernetes see: <https://kubernetes.io/docs/reference/kubectl/cheatsheet/>

>[!div class="step-by-step"]
>[Previous](set-up-windows-containers-with-powershell.md)
>[Next](../docker-devops-workflow/index.md)
