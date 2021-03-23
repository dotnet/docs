---
title: 'Tutorial: Detect objects in images with Model Builder'
description: This tutorial illustrates how to build an object detection model using ML.NET Model Builder and Azure ML to detect stop signs in images.
author: briacht
ms.author: brachtma
ms.date: 03/12/2021
ms.topic: tutorial
ms.custom: mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to detect stop signs in images using Model Builder.
---

# Tutorial: Detect stop signs in images with Model Builder

Learn how to build an object detection model using ML.NET Model Builder and Azure ML to detect and locate stop signs in images.

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

Object detection is a computer vision problem. While closely related to image classification, object detection performs image classification at a more granular scale. Object detection both locates _and_ categorizes entities within images. Use object detection when images contain multiple objects of different types.

![Screenshots showing Image Classification versus Object Classification.](./media/object-detection-onnx/img-classification-obj-detection.PNG)

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

The first thing you need to do is annotate your images, or draw bounding boxes around the stop signs in each image. In this tutorial, you will annotate your images with a tool called [VoTT](https://github.com/microsoft/VoTT).

> If you want to skip the data labeling steps below, you can [download this version of the dataset](https://aka.ms/mlnet-object-detection-tutorial-assets) and skip to [Create a console application](object-detection-model-builder.md#create-a-console-application).

### Create a new VoTT project

1. [Download the dataset](https://aka.ms/mlnet-object-detection-tutorial-dataset) of 50 stop sign images and unzip.
1. [Download VoTT](https://github.com/Microsoft/VoTT/releases) (Visual Object Tagging Tool).
1. Open VoTT and select **New Project**.

    ![VoTT Home Screen](./media/object-detection-model-builder/vott.png)

1. In **Project Settings**, change the **Display Name** to "StopSignObjDetection".
1. Change the **Security Token** to *Generate New Security Token*.
1. Next to **Source Connection**, select **Add Connection**.
1. In **Connection Settings**, change the **Display Name** for the source connection to "StopSignImages", and select *Local File System* as the **Provider**. For the **Folder Path**, select the *Stop-Signs* folder which contains the 50 training images, and then select **Save Connection**.

    ![VoTT New Connection Dialog](./media/object-detection-model-builder/vott-new-connection.png)

1. In **Project Settings**, change the **Source Connection** to *StopSignImages* (the connection you just created).
1. Change the **Target Connection** to *StopSignImages* as well. Your **Project Settings** should now look similar to this screenshot:

    ![VoTT Project Settings Dialog](./media/object-detection-model-builder/vott-new-project.png)

1. Select **Save Project**.

### Add tag and label images

You should now see a window with preview images of all the training images on the left, a preview of the selected image in the middle, and a **Tags** column on the right. This screen is the **Tags editor**.

1. Select the first (plus-shaped) icon in the **Tags** toolbar to add a new tag.

    ![VoTT New Tag Icon](./media/object-detection-model-builder/vott-new-tag-icon.png)

1. Name the tag "Stop-Sign" and hit <kbd>Enter</kbd> on your keyboard.

    ![VoTT New Tag](./media/object-detection-model-builder/vott-new-tag.png)

1. Click and drag to draw a rectangle around each stop sign in the image. If the cursor does not let you draw a rectangle, try selecting the **Draw Rectangle** tool from the toolbar on the top, or use the keyboard shortcut <kbd>R</kbd>.
1. After drawing your rectangle, select the **Stop-Sign** tag that you created in the previous steps to add the tag to the bounding box.
1. Click on the preview image for the next image in the dataset and repeat this process.
1. Continue steps 3-4 for every stop sign in every image.

    ![VoTT Annotating Images](./media/object-detection-model-builder/vott-annotating.gif)

### Export your VoTT JSON

Once you have labeled all of your training images, you can export the file that will be used by Model Builder for training.

1. Select the fourth icon in the left toolbar (the one with the diagonal arrow in a box) to go to the **Export Settings**.
1. Leave the **Provider** as *VoTT JSON*.
1. Change the **Asset State** to *Only tagged Assets*.
1. Uncheck **Include Images**. If you include the images, then the training images will be copied to the export folder that is generated, which is not necessary.
1. Select **Save Export Settings**.

    ![VoTT Export Settings](./media/object-detection-model-builder/vott-export.png)

1. Go back to the **Tags editor** (the second icon in the left toolbar shaped like a ribbon). In the top toolbar, select the **Export Project** icon (the last icon shaped like an arrow in a box), or use the keyboard shortcut <kbd>Ctrl</kbd>+<kbd>E</kbd>.

    ![VoTT Export Button](./media/object-detection-model-builder/vott-export-button.png)

This export will create a new folder called *vott-json-export* in your *Stop-Sign-Images* folder and will generate a JSON file named *StopSignObjDetection-export* in that new folder. You will use this JSON file in the next steps for training an object detection model in Model Builder.

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

Congratulations! You've successfully built a machine learning model to detect stop signs in images using Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main/samples/modelbuilder/ObjectDetection_StopSigns) GitHub repository.

## Additional resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Object Detection using ONNX in ML.NET](object-detection-onnx.md)
