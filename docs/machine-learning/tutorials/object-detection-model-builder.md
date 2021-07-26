---
title: 'Tutorial: Detect objects in images with Model Builder'
description: This tutorial illustrates how to build an object detection model using ML.NET Model Builder and Azure ML to detect stop signs in images.
author: briacht
ms.author: brachtma
ms.date: 07/25/2021
ms.topic: tutorial
ms.custom: mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to detect stop signs in images using Model Builder.
---

# Tutorial: Detect stop signs in images with Model Builder

Learn how to build an object detection model using ML.NET Model Builder and Azure Machine Learning to detect and locate stop signs in images.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Prepare and understand the data
> - Choose the scenario
> - Choose the training environment
> - Load the data
> - Train the model
> - Evaluate the model
> - Use the model for predictions

> [!NOTE]
> Model Builder is currently in Preview.

## Prerequisites

For a list of prerequisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Model Builder object detection overview

Object detection is a computer vision problem. While closely related to image classification, object detection performs image classification at a more granular scale. Object detection both locates _and_ categorizes entities within images. Object detection models are commonly trained using deep learning and neural networks. See [Deep learning vs machine learning](/azure/machine-learning/concept-deep-learning-vs-machine-learning) for more information.

Use object detection when images contain multiple objects of different types.

![Screenshots showing Image Classification versus Object Classification.](./media/object-detection-onnx/img-classification-obj-detection.png)

Some use cases for object detection include:

- Self-Driving Cars
- Robotics
- Face Detection
- Workplace Safety
- Object Counting
- Activity Recognition

This sample creates a C# .NET Core console application that detects stop signs in images using a machine learning model built with Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main/samples/modelbuilder/ObjectDetection_StopSigns) GitHub repository.

## Prepare and understand the data

The Stop Sign dataset consists of 50 images downloaded from [Unsplash](https://unsplash.com/), each of which contain at least one stop sign.

You can download the dataset [here](https://aka.ms/mlnet-object-detection-tutorial-assets). The download includes of the raw image data files and two JSON files to describe the objects in the images.

- The ***-asset.json files** contain bounding box information for the respective image.
- The **StopSignObjDetection-export.json** file has the references to the image files and bounding box information from asset files. It's an aggregate of all the asset files. This file is used to load the data for training in Model Builder.

## Create a console application

1. In Visual Studio, create a **C# .NET Core console application** called *StopSignDetection*.

## Choose a scenario

1. In **Solution Explorer**, right-click the *StopSignDetection* project, and select **Add** > **Machine Learning** to open the Model Builder UI.
1. For this sample, the scenario is object detection. In the **Scenario** step of Model Builder, select the **Object Detection** scenario.

![Model Builder wizard in Visual Studio](./media/object-detection-model-builder/obj-det-scenario.png)

> If you don't see *Object Detection* in the list of scenarios, you may need to [update your version of Model Builder](https://marketplace.visualstudio.com/items?itemName=MLNET.07).

## Choose the training environment

Currently, Model Builder supports training object detection models with Azure Machine Learning only, so the Azure training environment is selected by default.

![Azure training environment selection](./media/object-detection-model-builder/obj-det-environment.png)

To train a model using Azure ML, you must create an Azure ML experiment from Model Builder.

An **Azure ML experiment** is a resource that encapsulates the configuration and results for one or more machine learning training runs.

To create an Azure ML experiment, you first need to configure your environment in Azure. An experiment needs the following to run:

- An Azure subscription
- A **workspace**: an Azure ML resource that provides a central place for all Azure ML resources and artifacts created as part of a training run.
- A **compute**: an Azure Machine Learning compute is a cloud-based Linux VM used for training. Learn more about [compute types supported by Model Builder](../resources/azure-training-concepts-model-builder.md#what-is-an-azure-machine-learning-compute).

### Set up an Azure ML workspace

To configure your environment:

1. Select the **Set up workspace** button.
1. In the **Create new experiment** dialog, select your Azure subscription.
1. Select an existing workspace or create a new Azure ML workspace.

    When you create a new workspace, the following resources are provisioned:

    - Azure Machine Learning workspace
    - Azure Storage
    - Azure Application Insights
    - Azure Container Registry
    - Azure Key Vault

    As a result, this process may take a few minutes.

1. Select an existing compute or create a new Azure ML compute. This process may take a few minutes.
1. Leave the default experiment name and select **Create**.

    ![Azure Workspace Setup Dialog](./media/object-detection-model-builder/azure-dialog.png)

The first experiment is created, and the experiment name is registered in the workspace. Any subsequent runs (if the same experiment name is used ) are logged as part of the same experiment. Otherwise, a new experiment is created.

If you’re satisfied with your configuration, select the **Next step** button in Model Builder to move to the **Data** step.

## Load the data

In the **Data** step of Model Builder, you will select your training dataset.

>Model Builder currently only accepts the format of JSON generated by VoTT, but the team plans to add support for more formats in the future. If there is a dataset format for object detection that you’d like to see supported in Model Builder, leave your feedback on [GitHub](https://github.com/dotnet/machinelearning-modelbuilder/issues/new?assignees=&labels=&template=data_suggestion.md&title=).

1. Select the button next to the **Select a folder** text box and use the File Explorer to find the `StopSignObjDetection-export.json` which should be located in the *Stop-Signs/vott-json-export* directory.

    ![Model Builder Data Step](./media/object-detection-model-builder/obj-det-data.png)

1. If your data looks correct in the **Data Preview**, select **Next step** to move on to the **Train** step.

## Train the model

The next step is to train your model.

In the Model Builder **Train** screen, select the **Start training** button.

At this point, your data is uploaded to Azure Storage and the training process begins in Azure ML.

>The training process takes some time, and the amount of time may vary depending on the size of compute selected as well as the amount of data. The first time a model is trained in Azure, you can expect a slightly longer training time because resources have to be provisioned. For this sample of 50 images, training took about 16 minutes.

You can track the progress of your runs in the Azure Machine Learning portal by selecting the **Monitor current run in Azure portal** link in Visual Studio.

Once training is complete, select the **Next step** button to move on to the **Evaluate** step.

## Evaluate the model

In the Evaluate screen, you get an overview of the results from the training process, including the model accuracy.

![Model Builder Evaluate Step](./media/object-detection-model-builder/obj-det-evaluate.png)

In this case, the accuracy says 100%, which means that the model is more than likely *overfit* due to too few images in the dataset.

You can use the **Try your model** experience to quickly check whether your model is performing as expected.

Select **Browse an image** and provide a test image, preferably one that the model did not use as part of training.

![Model Builder Try your model](./media/object-detection-model-builder/obj-det-try-model.png)

The score shown on each detected bounding box indicates the **confidence** of the detected object. For instance, in the screenshot above, the score on the bounding box around the stop sign indicates that the model is 99% sure that the detected object is a stop sign.

The **Score threshold**, which can be increased or decreased with the threshold slider, will add and remove detected objects based on their scores. For instance, if the threshold is .51, then the model will only show objects that have a confidence score of .51 or above. As you increase the threshold, you will see less detected objects, and as you decrease the threshold, you will see more detected objects.

If you're not satisfied with your accuracy metrics, one easy way to try to improve model accuracy is to use more data. Otherwise, select the **Next step** link to move on to the **Code** step in Model Builder.

## Add the code to make predictions

Two projects are created as a result of the training process.

- *StopSignDetectionML.ConsoleApp*: A C# .NET Core Console application that contains the model training code and sample consumption code.
- *StopSignDetectionML.Model*: A .NET Standard class library containing the data models that define the schema of input and output model data, the saved version of the best performing model during training, and a helper class called `ConsumeModel` to make predictions.

1. In the code step of Model Builder, select **Add Projects** to add the auto-generated projects to the solution.
1. Open the *Program.cs* file in the *StopSignDetection* project, and add the following using statement at the top of the file to reference the *StopSignDetectionML.Model* project:

    [!code-csharp [ProgramUsings](~/machinelearning-samples/samples/modelbuilder/ObjectDetection_StopSigns/StopSignDetection/Program.cs#L2)]

1. Download the following [test image](~/machinelearning-samples/samples/modelbuilder/ObjectDetection_StopSigns/StopSignDetection/test-image1.jpeg).
1. Create a new instance of the `ModelInput` class with the `ImageSource` property set to the filepath of your test image inside the `Main` method of your application. Replace the "Hello World" statement with the following code:

    [!code-csharp [InputData](~/machinelearning-samples/samples/modelbuilder/ObjectDetection_StopSigns/StopSignDetection/Program.cs#L10-L15)]

1. Use the `Predict` method from the `ConsumeModel` class to load the trained model, create a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) for the model, and make predictions on new data. Add the following code below the `ModelInput` statement:

    [!code-csharp [Prediction](~/machinelearning-samples/samples/modelbuilder/ObjectDetection_StopSigns/StopSignDetection/Program.cs#L15)]

1. Print out the Prediction's output, including the label, coordinates, and score by adding the following code:

    [!code-csharp [PrintResults](~/machinelearning-samples/samples/modelbuilder/ObjectDetection_StopSigns/StopSignDetection/Program.cs#L17-L18)]

1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    Predicted Boxes:

    Top: 89.453415, Left: 481.95343, Right: 724.8073, Bottom: 388.32385, Label: Stop-Sign, Score: 0.99539465
    ```

    > [!NOTE]
    > **(Optional)** The bounding box coordinates are normalized for a width of 800 pixels and a height of 600 pixels. To scale the bounding box coordinates for your image in further post-processing, you need to:
    >
    >    1. Multiply the top and bottom coordinates by the original image height, and multiply the left and right coordinates by the original image width.
    >    1. Divide the top and bottom coordinates by 600, and divide the left and right coordinates by 800.
    >
    >    For example, given the original image dimensions,`actualImageHeight` and `actualImageWidth`, and a `ModelOutput` called `prediction`, the following code snippet shows how to scale the `BoundingBox` coordinates:
    >
    >    ```csharp
    >    var top = originalImageHeight * prediction.Top / 600;
    >    var bottom = originalImageHeight * prediction.Bottom / 600;
    >    var left = originalImageWidth * prediction.Left / 800;
    >    var right = originalImageWidth * prediction.Right / 800;
    >    ```
    >
    > An image may have more than one bounding box, so the same process needs to be applied to each of the bounding boxes in the image.

Congratulations! You've successfully built a machine learning model to detect stop signs in images using Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main/samples/modelbuilder/ObjectDetection_StopSigns) GitHub repository.

## Additional resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Object Detection using ONNX in ML.NET](object-detection-onnx.md)
