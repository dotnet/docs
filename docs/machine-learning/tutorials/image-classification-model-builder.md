---
title: 'Tutorial: Train an image classification model in Azure using Model Builder'
description: Learn how to train an image classification model to recognize land use from satellite images in Azure using Model Builder
author: luisquintanilla
ms.author: luquinta
ms.date: 04/13/2020
ms.topic: tutorial
ms.custom: mvc,mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically train a model in Azure to classify images using Model Builder.
---

# Train an image classification model in Azure using Model Builder

Learn how to train an image classification model in Azure using Model Builder to categorize land use from satellite images.

This tutorial shows you how to create a Universal Windows Platform (UWP) application that uses model hosted in an ASP.NET Core Web API to categorize land use based on satellite images.

In this tutorial you:

> [!div class="checklist"]
>
> - Create an ASP.NET Core Web API
> - Prepare and understand the data
> - Choose a scenario
> - Load the data
> - Create an experiment in Azure
> - Train the model
> - Evaluate the model
> - Use the model for predictions
> - Consume the model in UWP application

> [!NOTE]
> Model Builder is currently in Preview.

## Prerequisites

- For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](https://docs.microsoft.com/dotnet/machine-learning/how-to-guides/install-model-builder).
- Azure account. If you don't have one, [create a free Azure account](https://aka.ms/AMLFree) today.
- ASP.NET and web development workload.
- Universal Windows Platform development workload.

## Model Builder image classification overview

This sample creates a UWP application that categorizes land use using map satellite imagery using a machine learning model trained on Azure with Model Builder. The model itself is hosted as a web service in an ASP.NET Core Web API. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples) Github repository

## Create solution

1. In Visual Studio, select **File > New > Project** from the menu bar.
1. In the New Project dialog, type **Solution** into the search box.
1. Select the **Blank Solution** template, then select the **Next** button.
1. In the **Name** text box, type "LandUse".
1. Select **Create**.

## Create ASP.NET Core Web API

1. In Solution Explorer, right-click the **LandUse** solution, and select **Add > New Project**.
1. In the New Project dialog, type **ASP.NET Core Web Application** into the search box.
1. Select the **ASP.NET Core Web Application** C# project template, then select the **Next** button.
1. In the **Name** text box, type "LandUseAPI".
1. Select **Create**.
1. Choose **API** in the window that displays the different types of ASP.NET Core Projects, and then select the **Create** button.

## Prepare and understand the data

The data used for this tutorial is from:

- Eurosat: A novel dataset and deep learning benchmark for land use and land cover classification. Patrick Helber, Benjamin Bischke, Andreas Dengel, Damian Borth. IEEE Journal of Selected Topics in Applied Earth Observations and Remote Sensing, 2019.
- Eurosat: A novel dataset and deep learning benchmark for land use and land cover classification. Patrick Helber, Benjamin Bischke, Andreas Dengel, Damian Borth. IEEE Journal of Selected Topics in Applied Earth Observations and Remote Sensing, 2019.

It contains images a collection of satellite images divided into ten categories (rural, industrial, river, etc). The original dataset contains 27,000 images. For convenience, this tutorial only uses 2,000 of those images.

1. Download the subset of the [EuroSAT dataset](http://madm.dfki.de/files/sentinel/EuroSAT.zip) and save it anywhere on your computer.
1. Unzip it.

## Choose a scenario

![Model Builder Scenario Screen](media/sentiment-analysis-model-builder/model-builder-screen.png)

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder.

1. In Solution Explorer, right-click the **LandUseAPI** project, and select **Add > Machine Learning**.
1. For this sample, the scenario is image classification. In the scenario step of the Model Builder tool, select the **Image Classification** scenario.

## Load the data

1. In the data step of the Model Builder tool, select the button next to the **Select a folder** text box and use File Explorer to browse and select the unzipped directory containing the images.
1. Select the **Train** button to move to the next step in the Model Builder tool.

## Train the model

Training on Azure is only available for the Model Builder image classification scenario. The algorithm used to train these models is a Deep Neural Network based on the ResNet50 architecture. During the model training process, Model Builder trains separate models using ResNet50 algorithm and settings to find the best performing model for your dataset.

### Create experiment in Azure

An Azure Machine Learning experiment is a resource that needs to be created before running Model Builder training on Azure.

The experiment encapsulates the configuration and results for one or more machine learning training runs. Experiments belong to a specific workspace. The first time an experiment is created, its name is registered in the workspace. Any subsequent runs - if the same experiment name is used - are logged as part of the same experiment. Otherwise, a new experiment is created.

1. From the Choose Your Training Environment set of options, select **Azure**.
1. Then, select *Create Experiment**.
1. In the Create New Experiment dialog, choose your subscription from the **Subscription** dropdown.

### Create workspace

A workspace is an Azure Machine Learning resource that provides a central place for all Azure Machine Learning resources and artifacts created as part of training run.

1. In the Create New Experiment dialog, select the **New** link next to the **Machine Learning Workspace name** dropdown.
1. In the Create A New Workspace dialog, type "landuse-wkspc" in the **Machine Learning Workspace name** text box.
1. Choose **East US** from the **Regions** dropdown. A region is the geographic location of the data center where your workspace and resources are deployed to. It is recommended that you choose a location close to where you or your customers are.
1. Select the **New** next to the **Resource Groups** dropdown.
    1. In the Create New Resource Group dialog, type "landuse-rg" in the **Resource Group name** text box.
    1. Select **OK**.
1. Choose your newly created resource group form the **Resource Groups** dropdown.
1. Select **Create**.

    The provisioning process takes a few minutes. A request is made to Azure to provision the following cloud resources:

    - Enterprise Azure Machine Learning workspace
    - Azure storage account
    - Azure Application Insights
    - Azure Container Registry
    - Azure Key Vault

1. Once the provisioning process is complete, choose your newly created workspace from the **Machine Learning Workspace name** dropdown in the Create New Experiment dialog.

### Create compute

An Azure Machine Learning compute is a cloud-based Linux VM used for training.

1. In the Create New Experiment dialog, select the **New** link next to the **Compute name** dropdown.
1. In the Create New Compute dialog, type "landuse-cpt" in the **Compute name** text box.
1. Choose **Standard_NC24** from the **Compute size** dropdown. Model Builder uses GPU-optimized compute types. Visit the [NC-series Linux VM documentation](https://docs.microsoft.com/azure/virtual-machines/nc-series?toc=/azure/virtual-machines/linux/toc.json&bc=/azure/virtual-machines/linux/breadcrumb/toc.json) for more details on GPU optimized compute types.
1. Select **Create**. The compute resources may take a few minutes to provision.
1. Once the provisioning process is complete, choose your newly created workspace from the **Compute name** dropdown in the Create New Experiment dialog.

### Start training

Now it's time to finish creating the experiment and start training.

1. In the Create New Experiment dialog, leave the default value in the **Experiment name** text box.
1. Select **Create**. Once created, your experiment details appears in the Model Builder train step.
1. Select **Start Training**.

    The training process takes some time and the amount of time may vary depending on the size of compute selected as well as amount of data. The first time a model is trained, you can expect a slightly longer training time because resources have to be provisioned. You can track the progress of your runs by selecting the "Monitor current run in Azure portal" link in Visual Studio.

    Throughout the training process, progress data is displayed in the Progress section of the train step.

    - Status displays the completion status of the training process.
    - Best accuracy displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
    - Algorithm displays the name of the best performing algorithm performed found by Model Builder so far.

1. Once training is complete, select the **Evaluate** button to move to the next step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, the **Details** tab in the output section, will contain the algorithm used by the best performing model in the **Algorithm** entry along with metrics in **Best model Accuracy** entry.

If you're not satisfied with your accuracy metrics, some easy ways to try and improve model accuracy are to use more data or augment the existing data. Otherwise, select the **Code** button to move to the final step in the Model Builder tool.

## Add the code to make predictions

Two projects are created as a result of the training process.

### Reference the trained model

1. In the code step of the Model Builder tool, select **Add Projects** to add the autogenerated projects to the solution.

    Two projects are added to your solution with the following suffixes:

    - *ConsoleApp*: A C# .NET Core console application that provides starter code to build the prediction pipeline and make predictions.
    - *Model*: A C# .NET Standard application that contains the data models that define the schema of input and output model data as well as the following assets:

      - bestModel.onnx: A serialized version of the model in Open Neural Network Exchange (ONNX) format. ONNX is an open source format for AI models that supports interoperability between frameworks like ML.NET, PyTorch and TensorFlow.
      - bestModelMap.json: A list of categories used when making predictions to map the model output to a text category.
      - MLModel.zip: A serialized version of the ML.NET prediction pipeline that uses the serialized version of the model *bestModel.onnx* to make predictions and maps outputs using the `bestModelMap.json` file.

    The `ModelInput` and `ModelOutput` classes in the *Model* project define the schema of the model's expected input and output respectively.

    In an image classification scenario, the `ModelInput` contains two columns:

    - `ImageSource`: The string path of the image location.
    - `Label`: The actual category the image belongs to. `Label` is only used as an input when training and does not need to be provided when making predictions.

    The `ModelOutput` contains two columns:

    - `Prediction`: The image's predicted category.
    - `Score`: The list of probabilities for all categories (the highest belongs to the `Prediction`).

### Install NuGet packages

To work with images in this application, install the **System.Drawing.Common** NuGet package.

1. In Solution Explorer, right-click the `LandUseAPI` project and select **Manage NuGet Packages**.
Choose "nuget.org" as the Package source.
1. Select the **Browse** tab and search for **System.Drawing.Common**.
1. Select the package in the list, and select the **Install** button.
1. Select the **OK** button on the Preview Changes dialog
1. Select the **I Accept** button on the License Acceptance dialog if you agree with the license terms for the packages listed.

### Configure the prediction engine

The [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is a convenience API, makes predictions on a single data instance. To use it in your application, you have to create aan instance of it everywhere it's needed. As your application grows, this process can become unmanageable. By configuring the [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) in the *Startup.cs* class, you leverage dependency injection to make it easier to create instances of it throughout your application.

1. Open the *Startup.cs* file.
1. Add the following using statements to the top of the file.

    ```csharp
    using System.IO;
    using Microsoft.ML;
    using LandUseML.Model;
    ```

1. Add the following code inside the `ConfigureService` method.

    ```csharp
    services.AddSingleton<PredictionEngine<ModelInput, ModelOutput>>(sp =>
    {
        MLContext ctx = new MLContext();

        // Register NormalizeMapping
        ctx.ComponentCatalog.RegisterAssembly(typeof(NormalizeMapping).Assembly);

        // Register LabelMapping
        ctx.ComponentCatalog.RegisterAssembly(typeof(LabelMapping).Assembly);

        // Define model path
        var modelPath = Path.Join("bin/Debug/netcoreapp3.1/","MLModel.zip");

        //Load model
        ITransformer mlModel = ctx.Model.Load(modelPath, out var modelInputSchema);

        // Create prediction engine
        var predEngine = ctx.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

        return predEngine;
    });
    ```

### Create image classification handler

To process your incoming HTTP requests, create a controller.

1. In Solution Explorer, right-click the *Controllers* directory in the `LandUseAPI` project, and then select **Add > Controller**.
1. In the Add New Item dialog box, select **API Controller Empty** and select Add.
1. In the prompt change the Controller Name field to *ClassificationController.cs*. Then, select the **Add** button. The *ClassificationController.cs* file opens in the code editor. Add the following using statement to the top of *ClassificationController.cs*:

    ```csharp
    using System.IO;
    using System.Drawing;
    using Microsoft.ML;
    using LandUseML.Model;
    ```

1. Add the following inside the `ClassificationController` class.

    ```csharp
    private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;
    private readonly object _predictionEngineLock = new object();
    ```

1. Create a constructor for the controller and initialize the `_predictionEngine`.

    ```csharp
    public ClassificationController(PredictionEngine<ModelInput,ModelOutput> predictionEngine)
    {
        _predictionEngine = predictionEngine;
    }
    ```

1. Create a new method called `ClassifyImage` to handle POST requests.

    ```csharp
    [HttpPost]
    public async Task<string> ClassifyImage([FromBody] Dictionary<string,string> input)
    {

    }
    ```

1. Inside the `ClassifyImage` method, add the following code

    ```csharp
    string prediction;
    string imagePath = "inputimage.jpeg";
    ```

1. Then, convert the base64 string representation of the image in the request body to a `byte[]`.

    ```csharp
    var imageBytes = Convert.FromBase64String(input["data"]);
    ```

1. Create a new [`MemoryStream`](xref:System.IO.MemoryStream) from the `imageBytes`.

    ```csharp
    using(var ms = new MemoryStream(imageBytes))
    {

    }
    ```

1. Inside the `using` statement, save the image.

    ```csharp
    using (var img = await Task.Run(() => Image.FromStream(ms)))
        await Task.Run(() => img.Save(imagePath));
    ```

1. Outside the using statement, use the prediction engine to classify the input image.

    ```csharp
    lock (_predictionEngineLock)
    {
        ModelOutput output = _predictionEngine.Predict(new ModelInput { ImageSource = imagePath });
        prediction = output.Prediction;
    }
    ```

    Because [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread safe, make sure to use the [`lock`](https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/lock-statement) statement to safely make predictions.

1. Finally, return the prediction.

    ```csharp
    return prediction;
    ```

## Consume the model in UWP application

The UWP application is the interface users interact with. When a user searches for an address, a satellite image of the location renders and is categorized by the model hosted in the ASP.NET Core Web API.

### Create UWP Application

1. In Solution Explorer, right-click the **LandUse** solution, and select **Add > New Project**.
1. In the New Project dialog, type "Universal Windows" into the search box.
1. Select the **Blank App (Universal Windows)** C# project template, then select the **Next** button.
1. In the **Name** text box, type "LandUseUWP".
1. Select **Create**.
1. The target version/minimum version dialog appears. Keep the default settings and select **OK**.

### Design the layout of the main page

This application only contains a single page.

1. Open the *MainPage.xaml* file and replace the contents of the file with the following.

    ```xaml
    <Page
        x:Class="LandUseUWP.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:LandUseUWP"
        xmlns:Custom="using:Windows.UI.Xaml.Controls.Maps"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="2*"/>
                <ColumnDefinition Width="Auto"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition />
                <RowDefinition Height="7*"/>
                <RowDefinition Height="1*"/>
            </Grid.RowDefinitions>
            <TextBox 
                x:Name="AddressBar" 
                Text="Address Bar" 
                VerticalAlignment="Top"
                Margin="10" 
                FontSize="20"/>
            <Button 
                x:Name="QueryLocation"
                Content="Query Location"
                VerticalAlignment="Top"
                Margin="10"
                Grid.Column="1"
                FontSize="20"
                Click="QueryLocation_Click"/>
            <Custom:MapControl 
                x:Name="SatelliteMap"
                Margin="10"
                Style="Aerial"
                Grid.Row="1"
                Grid.Column="0"
                Grid.ColumnSpan="2"
                ZoomLevel="19"
                Loaded="SatelliteMap_Loaded"/>
            <TextBlock
                x:Name="PredictionText"
                HorizontalAlignment="Center"
                Grid.Row="2"
                Grid.ColumnSpan="2"
                FontSize="24"/>
        </Grid>
    </Page>
    ```

### Add interactivity to the application

1. Open the *MainPage.xaml.cs* file.
1. Add the following using statements at the top of the page.

    ```csharp
    using Windows.Devices.Geolocation;
    using Windows.UI.Xaml.Controls.Maps;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Text.Json;
    using Windows.UI.Popups;
    using System.Text;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.Storage.Streams;
    using Windows.Graphics.Imaging;
    ```

1. Start by setting a starting point for the the map control. Create a new method called `SatelliteMap_Loaded` inside the `MainPage` class.

    ```csharp
    private async void SatelliteMap_Loaded(object sender, RoutedEventArgs e)
    {
        BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
        Geopoint cityCenter = new Geopoint(cityPosition);

        await (sender as MapControl).TrySetViewAsync(cityCenter);
    }
    ```

1. Under the `SatelliteMap_Loaded` method, add a new method called `QueryLocation_Click`. This method performs a series of actions when the user clicks the `QueryLocation` button in the application.

    ```csharp
    private async void QueryLocation_Click(object sender, RoutedEventArgs e)
    {

    }
    ```

1. When the `QueryLocation` button is clicked, the first thing that happens is, the address is reverse geo-coded using the [Nominatim API](https://nominatim.org/) to get the latitude and longitude of the location the user provides. Install the **System.Text.Json** NuGet package.

    1. In Solution Explorer, right-click the `LandUseUWP` project and select **Manage NuGet Packages**.
    Choose "nuget.org" as the Package source.
    1. Select the **Browse** tab and search for **System.Text.Json**.
    1. Select the package in the list, and select the **Install** button.
    1. Select the **OK** button on the Preview Changes dialog
    1. Select the **I Accept** button on the License Acceptance dialog if you agree with the license terms for the packages listed.

1. Next, define a class to store the geo-coded coordinates.

    1. In Solution Explorer, right-click the **LandUseUWP** project, and select **Add > Class**.
    1. In the **Name** text box, type "Coordinates".
    1. Select **Add**. The *Coordinates.cs* file opens in the editor.

    Add the following using statements

    ```csharp
    using System.Text.Json.Serialization;
    ```

    Replace the contents of the class with the following

    ```csharp
    class Coordinates
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }

        [JsonPropertyName("lon")]
        public string Longitude { get; set; }
    }
    ```

1. In the *MainPage.xaml.cs* file, create a new method called `GetCoordinatesAsync` below the `QueryLocation_Click` method and add the following code.

    ```csharp
    private async Task<Coordinates> GetCoordinatesAsync(string address)
    {
        Coordinates result;

        using (HttpClient client = new HttpClient())
        {
            //Generate URL
            string urlEncodedAddress = HttpUtility.UrlEncode(address);
            var uri = new Uri($"https://nominatim.openstreetmap.org/search?q={urlEncodedAddress}&format=json");

            // Build request
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("User-Agent", "LandUseUWP/1.0");

            // Get coordinates
            var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            //Parse results
            var coordinates = JsonSerializer.Deserialize<IEnumerable<Coordinates>>(body).FirstOrDefault();

            //Return results
            if (coordinates == null)
            {
                result = new Coordinates { Latitude = "47.604", Longitude = "-122.329" };
                await new MessageDialog("Could not find address provided.", "Address Not Found").ShowAsync();
            }
            else
            {
                result = coordinates;
            }
        }

        return result;
    }
    ```

    The application tries to find the coordinates for the provided address. If address is not found, a default location is returned and a dialog opens informing the user the address was not found.

1. Call the `GetCoordinatesAsync` method inside the `QueryLocation_Clicked` method using the user provided address as input.

    ```csharp
    var coordinates = await GetCoordinatesAsync(AddressBar.Text);
    ```

1. Then, update the map using the coordinates of the new location. Create a new method called `UpdateMapLocationAsync` below the `GetCoordinatesAsync` method.

    ```csharp
    private async Task UpdateMapLocationAsync(MapControl map, Coordinates coordinates)
    {
        BasicGeoposition newPosition = new BasicGeoposition()
        {
            Latitude = float.Parse(coordinates.Latitude),
            Longitude = float.Parse(coordinates.Longitude)
        };

        await map.TrySetViewAsync(new Geopoint(newPosition));
    }
    ```

1. Call the `UpdateMapLocationAsync` method inside the `QueryLocation_Clicked` by supplying the coordinates of the new location to the `SatelliteMap` control.

    ```csharp
    await UpdateMapLocationAsync(SatelliteMap, coordinates);
    ```

1. The model requires an image as input. When the application updates the map, take a snapshot of the control. Create a new method called `GetMapAsImageAsync` to create an image of the map control below the `UpdateMapLocationAsync` method.

    ```csharp
    private async Task<byte[]> GetMapAsImageAsync()
    {
        RenderTargetBitmap renderBitmap = new RenderTargetBitmap();
        await renderBitmap.RenderAsync(SatelliteMap);
        IBuffer pixelBuffer = await renderBitmap.GetPixelsAsync();

        var softwareBitmap = SoftwareBitmap.CreateCopyFromBuffer(pixelBuffer, BitmapPixelFormat.Bgra8, renderBitmap.PixelWidth, renderBitmap.PixelHeight, BitmapAlphaMode.Ignore);

        byte[] array;
        using(var stream = new InMemoryRandomAccessStream())
        {
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
            encoder.SetSoftwareBitmap(softwareBitmap);
            await encoder.FlushAsync();
            array = new byte[stream.Size];
            await stream.ReadAsync(array.AsBuffer(), (uint)stream.Size, InputStreamOptions.None);
        }

        return array;
    }
    ```

1. Call the `GetMapAsImageAsync` method inside the `QueryLocation_Clicked`.

    ```csharp
    var satelliteImage = await GetMapAsImageAsync();
    ```

1. Now that you have the an satellite image, you can consume the ASP.NET Core Web API to classify it. Create a new method called `ClassifyImageAsync` below the `GetMapAsImageAsync` method.

    ```csharp
    private async Task<string> ClassifyImageAsync(byte[] imageBytes)
    {
        string prediction;
        string base64image = Convert.ToBase64String(imageBytes);
        string content = JsonSerializer.Serialize(
            new Dictionary<string, string>
            {
                { "data", base64image }
            });

        using (var client = new HttpClient(new HttpClientHandler { ServerCertificateCustomValidationCallback = (a,b,c,d) => true}))
        {
            var res = await client.PostAsync("https://localhost:5001/api/classification", new StringContent(content,Encoding.UTF8,"application/json"));
            prediction = await res.Content.ReadAsStringAsync();
        }

        return prediction;
    }
    ```

1. Call the `ClassifyImageAsync` method from the `QueryLocation_Click` method.

    ```csharp
    PredictionText.Text = "Inspecting Image";
    var prediction = await ClassifyImageAsync(satelliteImage);
    ```

1. Finally, display the prediction in the application.

    ```csharp
    PredictionText.Text = $"Prediction: {prediction}";
    ```

1. The complete `QueryLocation_Click` method should look like the code below:

        ```csharp
        private async void QueryLocation_Click(object sender, RoutedEventArgs e)
        {
            // 1. Reverse geocode 
            var coordinates = await GetCoordinatesAsync(AddressBar.Text);
        
            // 2. Update map with new address location
            await UpdateMapLocation(SatelliteMap, coordinates);
        
            // 3. Convert map display into an image
            var satelliteImage = await GetMapAsImageAsync();
        
            // 4. Make a prediction
            PredictionText.Text = "Inspecting Image";
            var prediction = await ClassifyImageAsync(satelliteImage);
        
            // 5. Display prediction
            PredictionText.Text = $"Prediction: {prediction}";
        }
        ```

## Test the application

1. In the toolbar, open the **Debug Target** context menu
1. Choose the **LandUseAPI** debug target.
1. Click the **Debug Target** button to start the web API server.
1. Once the LandUseAPI application is running, in Solution Explorer, right-click **LandUseUWP** and select **Debug > Start New Instance**.
1. When the application launches, replace the default text in the address bar with "11 Times Square".
1. Select the **Query Location** button. The image is inspected and the text "Prediction: Industrial" should appear below the map.

Congratulations! You have now build an application that uses Model Builder to train an image classification model in Azure.

## Next steps

In this tutorial you:

> [!div class="checklist"]
>
> - Create an ASP.NET Core Web API
> - Prepare and understand the data
> - Choose a scenario
> - Load the data
> - Create an experiment in Azure
> - Train the model
> - Evaluate the model
> - Use the model for predictions
> - Consume the model in UWP application

Try one of the other Model Builder scenarios:

- [Predict NYC taxi fares](predict-prices-model-builder.md)
- [Analyze sentiment of website comments in a Razor Pages application](sentiment-analysis-model-builder.md)
- [Categorize the severity of restaurant violations](health-violation-classification-model-builder.md)