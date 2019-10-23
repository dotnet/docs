---
title: Set up & load data for Model Builder
description: Learn how to set up, prepare, and load data for use in one of the Model Builder scenarios for ML.NET.
ms.date: 11/04/2019
ms.custom: mvc,how-to
---

# Set up and load data for Model Builder and ML.NET

Learn how to set up and load your data source for use in one of the Model Builder scenarios for ML.NET. For each Model Builder scenario, the data must be prepared and ready to use for model training and validation. 

## Model Builder scenarios 

Model Builder helps you create models for the following machine learning scenarios:

- Sentiment analysis (binary classification): Classify data into two categories.
- Issue classification (multiclass classification): Classify data into 3 or more categories.
- Price prediction (regression): Predict a numeric value from your data.
- Image classification (algo type????): Deep learning??
- Custom scenario: Build custom scenarios from your data using regression, classification, and other tasks.

This article covers regression and image classification scenarios. 

## Load textual or numerical data for regression or classification model

You can load numerical data or text data for a classification model or load numerical data for a regression model into Model Builder from a SQL database or a local file in `csv` or `tsv` format.

1. In the data step of the Model Builder tool, select **File** from the data source dropdown.
1. Select the button next to the **Select a file** text box, and use File Explorer to browse and select the data file.
1. Choose a category in the **Column to Predict (Label)** dropdown.
1. Expand the **Input Columns (Features)** dropdown and uncheck the columns you won't use in your model.

You're done setting up your data source file for Model Builder. Select the **Train** link to move to the next step in the Model Builder tool.


## Set up and load data for an image classification model



## Next steps
Use Model Builder to build machine learning solutions. Try these tutorials:

multiclass /tutorials/restaurant-violation-classification-model-builder.md
Image class tutorial
Regression tutorial
