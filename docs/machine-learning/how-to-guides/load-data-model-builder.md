---
title: Set up & load data for Model Builder
description: Learn how to set up and load data for SQL Server or a file for use in one of the Model Builder scenarios for ML.NET.
ms.date: 10/31/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
#Customer intent: As a developer, I want to load data in Model Builder
---

# Load data in Model Builder

Learn how to set up and load your datasets from SQL Server or a file for use in one of the Model Builder scenarios for ML.NET. For each Model Builder scenario, the data must be prepared and ready to use for model training and validation. 

## Data set limitations in Model Builder

Model limits the amount of data you can use for training models:

- Training dataset limit: 1GB
- SQL Server data: 100,000 rows 

Question: Clarify the limits. Is the SQL Server data limit an absolute limit or for training only? The training dataset  -- is this a limit for text or numerical data from files?

## Model Builder scenarios 

Model Builder helps you create models for the following machine learning scenarios:

- Sentiment analysis (binary classification): Classify data into two categories.
- Issue classification (multiclass classification): Classify data into 3 or more categories.
- Price prediction (regression): Predict a numeric value from your data.
- Image classification (deep learning): Categorize images based on characteristics.
- Custom scenario: Build custom scenarios from your data using regression, classification, and other tasks.

This article covers classification and regression scenarios with textual or numerical data, and image classification scenarios. 

## Load textual or numerical data from a file  

You can load comma-delimited or tab-delimited textual or numerical data from a file into Model Builder. It accepts `csv` or `tsv` file formats. 

1. In the data step of the Model Builder tool, select **File** from the data source dropdown.
2. Select the button next to the **Select a file** text box, and use File Explorer to browse and select the data file.
3. Choose a category in the **Column to Predict (Label)** dropdown.
4. Expand the **Input Columns (Features)** dropdown and uncheck the columns you won't use in your model.

You're done setting up your data source file for Model Builder. Select the **Train** link to move to the next step in the Model Builder tool.

## Load data from a SQL Server database

Model Builder supports loading data from local and remote SQL Server databases. 

## Set up image data files

Model Builder expects image data to be in a specific format.

To load images into Model Builder, provide the path to a single top-level directory:

 - This top-level directory contains one subfolder for each of the categories to predict. 
 - Each subfolder contains the image files belonging to its category. 
 
In the folder structure illustrated below, the top-level directory is *flower_photos*. There are five subdirectories corresponding to the categories you want to predict: daisy, dandelion, roses, sunflowers, and tulips. Each of these subdirectories contains images belonging to its respective category. 

```text
\---flower_photos
    +---daisy
    |       100080576_f52e8ee070_n.jpg
    |       102841525_bd6628ae3c.jpg
    |       105806915_a9c13e2106_n.jpg
    |       
    +---dandelion
    |       10443973_aeb97513fc_m.jpg
    |       10683189_bd6e371b97.jpg
    |       10919961_0af657c4e8.jpg
    |       
    +---roses
    |       102501987_3cdb8e5394_n.jpg
    |       110472418_87b6a3aa98_m.jpg
    |       118974357_0faa23cce9_n.jpg
    |       
    +---sunflowers
    |       127192624_afa3d9cb84.jpg
    |       145303599_2627e23815_n.jpg
    |       147804446_ef9244c8ce_m.jpg
    |       
    \---tulips
            100930342_92e8746431_n.jpg
            107693873_86021ac4ea_n.jpg
            10791227_7168491604.jpg  
```

## Next steps
Use Model Builder to build machine learning solutions. Try these tutorials:

multiclass /tutorials/restaurant-violation-classification-model-builder.md
Image class tutorial
Regression tutorial
