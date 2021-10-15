---
title: 'Tutorial: Train a recommendation model using Model Builder'
description: Learn how to train a recommendation model to to recommend movies using Model Builder
author: luisquintanilla
ms.author: luquinta
ms.date: 10/15/2021
ms.topic: tutorial
ms.custom: mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically train a model to recommend movies.
---

# Train a recommendation model using Model Builder

Learn how to train a recommendation model using Model Builder to recommend movies.

In this tutorial, you:

> [!div class="checklist"]
>
> - Prepare and understand the data
> - Create a Model Builder config file
> - Choose a scenario
> - Load the data
> - Train the model
> - Evaluate the model
> - Consume the model

> [!NOTE]
> Model Builder is currently in Preview.

## Prerequisites

For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Create a C# Class Library

Create a **C# Class Library** called "MovieRecommender".

## Prepare and understand the data

There are several ways to approach recommendation problems, such as recommending a list of movies or recommending a list of related products, but in this case you will predict what rating (1-5) a user will give to a particular movie and recommend that movie if it's higher than a defined threshold (the higher the rating, the higher the likelihood of a user liking a particular movie).

Right click on [*recommendation-ratings-train.csv*](https://raw.githubusercontent.com/dotnet/machinelearning-samples/main/samples/csharp/getting-started/MatrixFactorization_MovieRecommendation/Data/recommendation-ratings-train.csv) and select "Save Link (or Target) As..."

Each row in the dataset contains information regarding a movie rating.

| 

## Create a Model Builder config file

When first adding Model Builder to the solution it will prompt you to create an `mbconfig` file. The `mbconfig` file keeps track of everything you do in Model Builder to allow you to reopen the session.

1. In Solution Explorer, right-click the **MovieRecommender** project, and select **Add > Machine Learning Model...**.
1. In the dialog, name the Model Builder project **MovieRecommender**, and click **Add**.

## Choose a scenario

![Model Builder Scenarios](../media/model-builder-scenarios.png)

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder.

For this sample, the task is image classification. In the scenario step of the Model Builder tool, select the **Recommendation** scenario.

## Select an enviornment

Model Builder can run the training on different environments depending on the scenario that was selected.

Select **Local** as your environment and click the **Next step** button.

## Load the data

1. In the data step of the Model Builder tool, select the button next to the **Select a folder** text box.
1. Use File Explorer to browse and select the downloaded file - **recommendation-ratings-train.csv**.
1. Select the **Next step** button to move to the next step in the Model Builder tool.
1. Once the data is loaded, in the **Column to predict** dropdown select **Rating**.
1. For the **User column** dropdown select **userId**.
1. For the **Item column** dropdown select **movieId**.

## Train the model

