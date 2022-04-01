---
title: 'Tutorial: ML.NET prediction to categorize images from Custom Vision ONNX model'
description: Learn how to categorize images using an ONNX model from the Custom Vision service in ML.NET. 
ms.date: 03/20/2022
ms.topic: tutorial
ms.custom: mvc, title-hack-0612
recommendations: false
#Customer intent: As a developer, I want to use ML.NET to categorize images using an ONNX model trained in the Custom Vision service.
---
# Tutorial: Categorize an image in ML.NET from Custom Vision ONNX model

Learn how to use ML.NET to categorize images using an ONNX model trained in the Microsoft Custom Vision service.

The Microsoft Custom Vision service is an AI service that allows you to upload your own images and it will train a model for you. You can then export the model to ONNX format and use it in ML.NET to make predictions.

In this tutorial, you will learn how to:
> [!div class="checklist"]
>
> * Understand the problem
> * Use the Custom Vision service to create an ONNX model
> * Incorporate the ONNX model into the ML.NET pipeline
> * Train and evaluate the ML.NET model
> * Classify a test image

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/).
* [Download the dataset]() of stop sign or traffic light images and unzip.
* Azure account. If you don't have one, [create a free Azure account](https://aka.ms/AMLFree).

## Select the right machine learning task

### Data

The images we will upload to the Custom Vision service consists of images downloaded from [Unsplash](https://unsplash.com/), each of which contain at least one stop sign or a traffic light. You can download the dataset [here]().

## Create the Model

### Create the Custom Vision Project

Log into the [Microsoft Custom Vision service](https://www.customvision.ai/) and select "New Project".

In the "New Project" dialog, fill out the following required items:

- Set the "Name" of the Custom Vision project as **StopSignClassification**.
- Select the "Resource" you will use. This is an Azure resource that will be created for the Custom Vision project. If none is listed, one can be created by selecting the **Create new** link.
- Set the "Project type" as **Classification**.
- Set the "Classification Types" as **Multiclass** since there will be one class per image.
- Set the "Domain" as **General (compact)**. The compact domain will allow you to download the ONNX model.
- For "Export capabilities" select **Basic platforms** to allow the export of the ONNX model.

Once the above fields are filled out click the **Create project** button.

### Add images

With the project created, click on the **Add images** button to start adding images for the model to train on. Select the stop sign images in the file browser that will display.

A popup will display where you can add tags that to those images. Set the tag as **stop-sign** and click the **Upload** button. Once the images have uploaded click the **Done** button to close the popup.

### Train the model

With the images uploaded and tagged the model can now be trained. Click on the **Train** button. For the "Training type" select **Quick training** and click on the **Train** button.

A popup will display asking what type of training to use. Select **Quick training** and click the **Train** button.

### Download the ONNX model

Once training is completed click on the "Export" button. When the popup displays click on the "ONNX" selection to download the ONNX model.

## Create a project

1. Create a C# **Console Application** called "WeatherRecognition". Click the **Next** button.

1. Choose .NET 6 as the framework to use. Click the **Create** button.

1. Install the **Microsoft.ML NuGet Package**:

    [!INCLUDE [mlnet-current-nuget-version](../../../includes/mlnet-current-nuget-version.md)]

    * In Solution Explorer, right-click on your project and select **Manage NuGet Packages**.
    * Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**.
    * Select the **Install** button.
    * Select the **OK** button on the **Preview Changes** dialog.
    * Select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.
    * Repeat these steps for **Microsoft.ML.ImageAnalytics**, and **Microsoft.Onnx.Transformer**.

## Reference the ONNX model

Unzip the ONNX file from Custom Vision. The folder will contain several files, but the two that we will use in this tutorial are the following:

- **labels.txt** is a text file containing the labels that were defined in the Custom Vision service.
- **model.onnx** is the ONNX model that we will use to make predictions in ML.NET.

