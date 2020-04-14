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

You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples) repository.

## Prerequisites

- For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](https://docs.microsoft.com/dotnet/machine-learning/how-to-guides/install-model-builder).
- ASP.NET and web development workload.
- Universal Windows Platform development workload.

## Model Builder image classification overview

## Create solution

1. On the menu bar, choose **File > New > Project**.
1. On the **Create a new project** page, type **solution** into the search box.
1. Select the **Blank Solution** template, and then click Next.
1. Enter **Name** and **Location** values for your solution, and then choose Create.

## Create ASP.NET Core Web API

1. Open Visual Studio and select **File > New > Project** from the menu bar.
1. In the New Project dialog, select the **Visual C#** node followed by the Web node.
1. Then select the **ASP.NET Core Web Application** project template.
1. In the **Name** text box, type "LandUseAPI".
1. Make sure P**lace solution and project in the same directory** is unchecked (VS 2019), or **Create directory for solution** is checked (VS 2017).
1. Select the **OK** button.
1. Choose **Web API** in the window that displays the different types of ASP.NET Core Projects, and then select the **OK** button.

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
1. For this sample, the scenario is image classification. In the scenario step of the Model Builder tool, select the Sentiment Analysis scenario.

## Load the data

1. In the data step of the Model Builder tool, select **File** from the data source dropdown.
1. Select the button next to the **Select a file** text box and use File Explorer to browse and select the unzipped directory containing the images.
1. Select the **Train** link to move to the next step in the Model Builder tool.

## Create experiment in Azure

An Azure Machine Learning experiment is a resource that needs to be created before running Model Builder training on Azure.

The experiment encapsulates the configuration and results for one or more machine learning training runs. Experiments belong to a specific workspace. The first time an experiment is created, its name is registered in the workspace. Any subsequent runs - if the same experiment name is used - are logged as part of the same experiment. Otherwise, a new experiment is created.

### Create workspace

A workspace is an Azure Machine Learning resource that provides a central place for all Azure Machine Learning resources and artifacts created as part of training run.

To create an Azure Machine Learning workspace, the following are required:

- Name: A name for your workspace between 3-33 characters. Names may only contain alphanumeric characters and hyphens.
- Region: The geographic location of the data center where your workspace and resources are deployed to. It is recommended that you choose a location close to where you or your customers are.
- Resource group: A container that contains all related resources for an Azure solution.

### Create compute

An Azure Machine Learning compute is a cloud-based Linux VM used for training.

To create an Azure Machine Learning compute, the following are required:

- Name: A name for your workspace between 2-16 characters. Names may only contain alphanumeric characters and hyphens.
- Compute size

    Model Builder can use one of the following GPU-optimized compute types:

    | Size | vCPU | Memory: GiB | Temp storage (SSD) GiB | GPU | GPU memory: GiB | Max data disks | Max NICs |
    |---|---|---|---|---|---|---|---|
    | Standard_NC12   | 12 | 112 | 680  | 2 | 24 | 48 | 2 |
    | Standard_NC24   | 24 | 224 | 1440 | 4 | 48 | 64 | 4 |

    Visit the [NC-series Linux VM documentation](https://docs.microsoft.com/azure/virtual-machines/nc-series?toc=/azure/virtual-machines/linux/toc.json&bc=/azure/virtual-machines/linux/breadcrumb/toc.json) for more details on GPU optimized compute types.

## Train the model

Training on Azure is only available for the Model Builder image classification scenario. The algorithm used to train these models is a Deep Neural Network based on the ResNet50 architecture. The training process takes some time and the amount of time may vary depending on the size of compute selected as well as amount of data. The first time a model is trained, you can expect a slightly longer training time because resources have to be provisioned. You can track the progress of your runs by selecting the "Monitor current run in Azure portal" link in Visual Studio.

The machine learning task used to train the model in this tutorial is image classification. During the model training process, Model Builder trains separate models using ResNet50 algorithm and settings to find the best performing model for your dataset.

The time required for the model to train is proportionate to the amount of data. Model Builder automatically selects a default value for Time to train (seconds) based on the size of your data source.

1. Although Model Builder sets the value of **Time to train (seconds)** to 10 seconds, increase it to 30 seconds. Training for a longer period of time allows Model Builder to explore a larger number of algorithms and combination of parameters in search of the best model.
1. Select **Start Training**.

    Throughout the training process, progress data is displayed in the Progress section of the train step.

    - Status displays the completion status of the training process.
    - Best accuracy displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
    - Best algorithm displays the name of the best performing algorithm performed found by Model Builder so far.
    - Last algorithm displays the name of the algorithm most recently used by Model Builder to train the model.
    - Once training is complete, select the evaluate link to move to the next step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, the output section, will contain the algorithm used by the best performing model in the **Best Model** entry along with metrics in **Best Model Accuracy**. Additionally, a summary table containing top five models and their metrics.

If you're not satisfied with your accuracy metrics, some easy ways to try and improve model accuracy are to increase the amount of time to train the model or use more data. Otherwise, select the code link to move to the final step in the Model Builder tool.

## Add the code to make predictions

Two projects will be created as a result of the training process.

### Reference the trained model

1. In the code step of the Model Builder tool, select **Add Projects** to add the autogenerated projects to the solution.

    Once training is complete, two projects are added to your solution with the following suffixes:

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

### Configure the prediction engine

1. Open the *Startup.cs* file.
1. Add the following using statements to the top of the file.

    ```csharp
    using Microsoft.ML;
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

1. Create a new controller called `ClassificationController`.
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

1. Create a new stream from the `imageBytes`.

    ```csharp
    using(var ms = new MemoryStream(imageBytes))
    {

    }
    ```

1. Inside the using statement, save the image.

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

    Because `PredictionEngine` is not thread safe, make sure to use the `lock` statement to safely make predictions.

1. Finally, return the prediction.

    ```csharp
    return prediction;
    ```

## Consume the model in UWP application

The UWP application is the interface users interact with. When a user searches for an address, a satellite image of the location renders and is categorized by the model hosted in the ASP.NET Core Web API.

### Create UWP Application

1. From the File menu, select **New > Project** to open the New Project dialog.
1. From the list of templates on the left, choose **Installed > Visual C# > Windows Universal** to see the list of UWP project templates.
1. Choose the **Blank App (Universal Windows)** template, and enter "LandUseUWP" as the Name. Select **OK**.
1. The target version/minimum version dialog appears. The default settings are fine for this tutorial, so select **OK** to create the project.

### Design the layout of the main page

This application only contains a single page.

1. Open the *MainPage.xaml* file and replace the contents of the file with the following.

    ```xaml
    <Page
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="using:MappingImageSampleUWP"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:Custom="using:Windows.UI.Xaml.Controls.Maps"
        x:Class="MappingImageSampleUWP.MainPage"
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
                Loaded="MapControl_Loaded"/>
            <TextBlock
                x:Name="PredictionText"
                Text="Prediction: Industrial"
                HorizontalAlignment="Center"
                Grid.Row="2"
                Grid.ColumnSpan="2"
                FontSize="24"/>
        </Grid>
    </Page>
    ```

### Add interactivity to the application

1. Open the *MainPage.xaml.cs* file.
1. Start by defining the initialization logic for the map control. Create a new method called `SatelliteMap_Loaded` inside the `MainPage` class.

    ```csharp
    private async void SatelliteMap_Loaded(object sender, RoutedEventArgs e)
    {

    }
    ```

1. Set the initial position for the map inside the `SatelliteMap_Loaded` method.

    ```csharp
    BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
    Geopoint cityCenter = new Geopoint(cityPosition);

    await (sender as MapControl).TrySetViewAsync(cityCenter);
    ```

1. Under the `SatelliteMap_Loaded` add a new method called `QueryLocation_Click`. This method performs a series of actions when the user clicks the `QueryLocation` button in the application.

    ```csharp
    private async void QueryLocation_Click(object sender, RoutedEventArgs e)
    {

    }
    ```

1. When the `QueryLocation` button is clicked, the first thing that happens is, the address is reverse geo-coded using the Nominatim API to get the latitude and longitude of the location. Inside the UWP project create a new `Coordinates` class.

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

1. Below the `QueryLocation_Click` method, create a new method called `GetCoordinatesAsync` with the following contents.

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
            request.Headers.Add("User-Agent", "MappingImageSampleUWP/1.0");

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

1. Call the `GetCoordinatesAsync` method inside the `QueryLocation_Clicked` method using the user provided address as input.

    ```csharp
    var coordinates = await GetCoordinatesAsync(AddressBar.Text);
    ```

1. Update the map with the coordinates of the new location. Create a new method called `UpdateMapLocationAsync` inside the `MainPage` class.

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
    await UpdateMapLocation(SatelliteMap, coordinates);
    ```

1. The model requires an image as input. When the application updates the map, take a screenshot of the control. Create a new method called `GetMapAsImageAsync` to create an image of the map control inside the `MainPage` class.

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

1. Now that you have the an satellite image, you can use the ASP.NET Core Web API to classify it. Create a new method called `ClassifyImageAsync` inside the `MainPage` class.

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
            var res = await client.PostAsync("https://localhost:44335/api/classification", new StringContent(content,Encoding.UTF8,"application/json"));
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



## Next Steps