---
title: Load data in Model Builder
description: Learn how to load data in Model Builder
ms.date: 10/23/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
#Customer intent: As a developer, I want to load data in Model Builder
---

# Load data in Model Builder

Learn how to load your data into Model Builder to train machine learning algorithms.

## Limitations

Training dataset limit is 1GB.
SQL Server has a limit of 100 thousand rows.

## Load data from a file

Model builder supports loading data from a file in comma-delimited and tab-demlimited formats.

## Load data from a database

Model Builder supports loading data from local and remote databases. 

## Load image data

Model Builder expects image data to be in a specific format.

To load images into Model Builder, you need to provide it with the path to a single top-level directory. This top-level directory contains subfolders of a number equal to each of the categories to predict. Each subfolder contains the image files belonging to the respective category.  
In the folder structure illustrated below, the top-level directory is *flower_photos*. There are five subdirectories corresponsing to the categories to predict: daisy, dandelion, roses, sunflowers and tulips. Each of these subdirectories contains images belonging to their respective category. 

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


