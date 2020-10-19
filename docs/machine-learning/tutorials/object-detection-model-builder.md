---
title: 'Tutorial: Detect objects in images with Model Builder'
description: This tutorial illustrates how to build an object detection model using ML.NET Model Builder and Azure ML to detect XX.
author: briacht
ms.author: brachtma
ms.date: 10/16/2020
ms.topic: tutorial
ms.custom: mvc,mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to classify violation severity using Model Builder.
---

# Tutorial: Classify the severity of restaurant health violations with Model Builder

Learn how to build an object detection model using Model Builder and Azure ML to X.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Prepare and understand the data
> - Choose a scenario
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

![Screenshots showing Image Classification versus Object Classification.](./media/object-detection-onnx/img-classification-obj-detection.png)

Some use cases for object detection include:

- Self-Driving Cars
- Robotics
- Face Detection
- Workplace Safety
- Object Counting
- Activity Recognition

This sample creates a C# .NET Core console application that X using a machine learning model built with Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/master/samples/modelbuilder/MulticlassClassification_RestaurantViolations) GitHub repository.

## Create a console application

1. Create a **C# .NET Core console application** called "RestaurantViolations".

## Prepare and understand the data

> The data set used to train and evaluate the machine learning model is originally from the [X](https://www.sfdph.org/dph/EH/Food/score/default.asp). For convenience, the dataset has been condensed to only include the columns relevant to train the model and make predictions. Visit the following website to learn more about the [dataset](https://data.sfgov.org/Health-and-Social-Services/Restaurant-Scores-LIVES-Standard/pyih-qa8i?row_index=0).

[Download the X dataset](https://github.com/luisquintanilla/machinelearning-samples/raw/AB1608219/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantScores.zip) and unzip it.

## Choose a scenario

1. In **Solution Explorer**, right-click the *X* project, and select **Add** > **Machine Learning**. This opens the Model Builder UI.
![Model Builder wizard in Visual Studio](./media/sentiment-analysis-model-builder/model-builder-screen.png)
1. For this sample, the scenario is object detection. In the *Scenario* step of Model Builder, select the **Object Detection** scenario.

    > Note: If you don't see *Object Detection* in the list of scenarios, you may need to [update your version of Model Builder](https://linkhere.com).

## Choose the training environment
Currently, Model Builder supports training object detection models with Azure only, so the Azure training environment is selected by default.

![Azure training environment selection](./media/object-detection-model-builder/obj-det-environment.png)

To train a model using Azure ML, you must create an Azure ML experiment from Model Builder.

An **Azure ML experiment** is a resource that encapsulates the configuration and results for one or more machine learning training runs.

To create an Azure ML experiment, you first need to configure your environment in Azure. An experiment needs the following to run:

- An Azure subscription
- A **workspace**: an Azure ML resource that provides a central place for all Azure ML resources and artifacts created as part of a training run.
- A **compute**: an Azure Machine Learning compute is a cloud-based Linux VM used for training. Learn more about [compute types supported by Model Builder](https://docs.microsoft.com/dotnet/machine-learning/resources/azure-training-concepts-model-builder#what-is-an-azure-machine-learning-compute).

To configure your environment:

1. Select the **Set up workspace** button.
1. In the *Create new experiment* dialog, select your Azure subscription.
1. Select an existing or create a new Azure ML workspace.

    When you create a new workspace, the following resources are provisioned:

    - Azure Machine Learning Enterprise workspace
    - Azure Storage
    - Azure Application Insights
    - Azure Container Registry
    - Azure Key Vault

    As a result, this process may take a few minutes.

1. Choose or create a new Azure ML compute. This process may take a few minutes.
1. Leave the default experiment name and select **Create**.

The first experiment is created and its name is registered in the workspace. Any subsequent runs – if the same experiment name is used – are logged as part of the same experiment. Otherwise, a new experiment is created.

If you’re satisfied with your configuration, select the **Next step** button to move to the Data step.

## Load the data

Model Builder accepts image data from local folders in the following format:
![Model Builder wizard in Visual Studio](./media/sentiment-analysis-model-builder/model-builder-screen.png)

1. In the data step of the Model Builder tool, load your data by selecting the button next to the Select a folder text box and use the File Explorer to find the XX.
1. If your data looks correct in the Data Preview, select **Next step** to move on to the Train step.

## Train the model

The next step is to train your model.

1. In the Model Builder train screen, select the **Start training** button.

    At this point, your data is uploaded to Azure Storage and the training process begins.

    The algorithm used to train these models is a Deep Neural Network based on the ResNet50 architecture.

    The training process takes some time and the amount of time may vary depending on the size of compute selected as well as the amount of data.

    For this sample of X images, training took about X minutes.

    The first time a model is trained in Azure, you can expect a slightly longer training time because resources have to be provisioned. You can track the progress of your runs in the Azure Machine Learning portal by selecting the **Monitor current run in Azure portal** link in Visual Studio.

1. Once training is complete, select the **Next step** button to move to the Evaluate step.

## Evaluate the model

In the evaluate screen, you get an overview of the results from the training process, such as how long the model took to train and the model's accuracy.

Additionally, you can use the *Try your model* experience to quickly check whether your model is performing as expected. All you need to do is provide an image, preferably one that the model did not use as part of training.

The score shown on each detected bounding box indicates the confidence of the detected object. For instance, in the screenshot above, the score on the bounding box around the cat indicates that the model is 77% sure that the detected object is a cat.

The score threshold, which can be increased or decreased with the threshold slider, will add and remove detected objects based on their scores. For instance, if the threshold is .51, then the model will only show objects that have a score / confidence of .51 or above. As you increase the threshold, you will see less detected objects, and as you decrease the threshold, you will see more detected objects.

If you're not satisfied with your accuracy metrics, one easy way to try to improve model accuracy is to use more data. Otherwise, select the **Next step** link to move to the Code step in Model Builder.

## Add the code to make predictions

Two projects are created as a result of the training process.

- RestaurantViolationsML.ConsoleApp: A C# .NET Core Console application that contains the model training and sample consumption code.
- RestaurantViolationsML.Model: A .NET Standard class library containing the data models that define the schema of input and output model data, the saved version of the best performing model during training, and a helper class called `ConsumeModel` to make predictions.

1. In the code step of Model Builder, select **Add Projects** to add the autogenerated projects to the solution.
1. Open the *Program.cs* file in the *RestaurantViolations* project.
1. Add the following using statement to reference the *RestaurantViolationsML.Model* project:

    [!code-csharp [ProgramUsings](~/machinelearning-samples/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantViolations/Program.cs#L2)]

1. To make a prediction on new data using the model, create a new instance of the `ModelInput` class inside the `Main` method of your application. Notice that the risk category is not part of the input. This is because the model generates the prediction for it.

    [!code-csharp [TestData](~/machinelearning-samples/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantViolations/Program.cs#L11-L15)]

1. Use the `Predict` method from the `ConsumeModel` class. The `Predict` method loads the trained model, creates a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) for the model, and uses it to make predictions on new data.

    [!code-csharp [Prediction](~/machinelearning-samples/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantViolations/Program.cs#L17-L24)]

1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    Inspection Type: Complaint
    Violation Description: Inadequate sewage or wastewater disposal
    Risk Category: Moderate Risk
    ```

If you need to reference the generated projects at a later time inside of another solution, you can find them inside the `C:\Users\%USERNAME%\AppData\Local\Temp\MLVSTools` directory.

Congratulations! You've successfully built a machine learning model to X using Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/master/samples/modelbuilder/MulticlassClassification_RestaurantViolations) GitHub repository.

## Additional resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Multiclass Classification](../resources/glossary.md#multiclass-classification)
- [Multiclass Classification Model Metrics](../resources/metrics.md#evaluation-metrics-for-multi-class-classification)
