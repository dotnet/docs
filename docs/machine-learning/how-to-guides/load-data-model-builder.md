---
title: Load training data for Model Builder
description: Learn how to load training data from a SQL Server database or a file for use in one of the Model Builder scenarios for ML.NET.
ms.date: 09/20/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to, mlnet-tooling
ms.topic: how-to
#Customer intent: As a developer, I want to load data in Model Builder
---

# Load training data into Model Builder

Learn how to load your training datasets from a file or a SQL Server database for use in one of the Model Builder scenarios for ML.NET. Model Builder scenarios can use SQL Server databases, image files, and CSV or TSV file formats as training data.

Model Builder only accepts TSV, CSV, and TXT files with comma, tab, and semi-colon delimiters and PNG and JPG images.

## Model Builder scenarios

Model Builder helps you create models for the following machine learning scenarios:

- Data classification (binary & multiclass classification): Classify text data into two or more categories.
- Value prediction (regression): Predict a numeric value.
- Image classification (deep learning): Classify images into two or more categories.
- Recommendation (recommendation): Produce a list of suggested items for a particular user.
- Object detection (deep learning): Detect and identify object in images. This can find one or more objects and label them accordingly.

This article covers classification and regression with textual or numerical data, image classification, and object detection scenarios.

## Load text or numeric data from a file

You can load text or numeric data from a file into Model Builder. It accepts comma-delimited (CSV) or tab-delimited (TSV) file formats.

1. In the data step of Model Builder, select **File** as the data source type.
1. Select the **Browse** button next to the text box, and use File Explorer to browse and select the data file.
1. Choose a category in the **Column to predict (Label)** dropdown.

    > ![NOTE]
    > **(Optional) data classification scenarios**: If the data type of your label column (the value in the "Column to predict (Label)" dropdown) is set to Boolean (True/False), a binary classification algorithm is used in your model training pipeline. Otherwise, a multiclass classification trainer is used. Use **Advanced data options** to modify the data type for your label column and inform Model Builder which type of trainer it should use for your data.  

1. Update the data in the **Advanced data options** link to set column settings or to update the data formatting.

You're done setting up your data source file for Model Builder. Click the **Next step** button to move to the next step in Model Builder.

### Load data from a SQL Server database

Model Builder supports loading data from local and remote SQL Server databases.

### Local database file

To load data from a SQL Server database file into Model Builder:

1. In the data step of Model Builder, select **SQL Server** as the data source type.
1. Select the **Choose data source** button.
    1. In the **Choose Data Source** dialog, select **Microsoft SQL Server Database File**.
    1. Uncheck the **Always use this selection** checkbox and select **Continue**
    1. In the **Connection Properties** dialog, select **Browse** and select the downloaded .MDF file.
    1. Select **OK**
1. Choose the dataset name from the **Table Name** dropdown.
1. From the **Column to predict (Label)** dropdown, choose the data category on which you want to make a prediction.

    > ![NOTE]
    > **(Optional) data classification scenarios**: If the data type of your label column (the value in the "Column to predict (Label)" dropdown) is set to Boolean (True/False), a binary classification algorithm is used in your model training pipeline. Otherwise, a multiclass classification trainer is used. Use **Advanced data options** to modify the data type for your label column and inform Model Builder which type of trainer it should use for your data.

1. Update the data in the **Advanced data options** link to set column settings or to update the data formatting.

### Remote database

To load data from a SQL Server database connection into Model Builder:

1. In the data step of Model Builder, select **SQL Server** as the data source type.
1. Select the **Choose data source** button.
    1. In the **Choose Data Source** dialog, select **Microsoft SQL Server**.
1. In the **Connection Properties** dialog, input the properties of your Microsoft SQL database.
    1. Provide the server name that has the table that you want to connect to.
    1. Set up the authentication to the server. If **SQL Server Authentication** is selected, input the server's username and password.
    1. Select what database to connect to in the **Select or enter a database name** dropdown. This should auto-populate if the server name and log in information are correct.
    1. Select **OK**
1. Choose the dataset name from the **Table Name** dropdown.
1. From the **Column to predict (Label)** dropdown, choose the data category on which you want to make a prediction.

    > ![NOTE]
    > **(Optional) data classification scenarios**: If the data type of your label column (the value in the "Column to predict (Label)" dropdown) is set to Boolean (True/False), a binary classification algorithm is used in your model training pipeline. Otherwise, a multiclass classification trainer is used. Use **Advanced data options** to modify the data type for your label column and inform Model Builder which type of trainer it should use for your data.

1. Update the data in the **Advanced data options** link to set column settings or to update the data formatting.

You're done setting up your data source file for Model Builder. Click the **Next step** button link to move to the next step in Model Builder.

## Set up image classification data files

Model Builder expects image classification data to be JPG or PNG files organized in folders that correspond to the categories of the classification.

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

## Set up object detection image data files

Model Builder expects object detection image data to be in JSON format generated from [VoTT](https://github.com/Microsoft/VoTT/releases). The JSON file is located in the **vott-json-export** folder in the **Target Location** that is specified in the project settings.

The JSON file consists of the following information generated from VoTT:

- All tags that were created
- The image file locations
- The image bounding box information
- The tag associated with the image

For more information on preparing data for object detection, see [Generate object detection data from VoTT](label-images-for-object-detection-using-vott.md).

## Next steps

Follow these tutorials to build machine learning apps with Model Builder:

- [Generate object detection data from VoTT](./label-images-for-object-detection-using-vott.md)
- [Predict prices using regression](../tutorials/predict-prices-with-model-builder.md)
- [Analyze sentiment in a web application using binary classification](../tutorials/sentiment-analysis-model-builder.md)

If you're training a model using code, [learn how to load data using the ML.NET API](load-data-ml-net.md).
