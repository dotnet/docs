---
title: Load data with many columns from a CSV file for machine learning processing - ML.NET
description: Learn how to load data data with many columns from a CSV file for use in machine learning model building, training, and scoring with ML.NET
ms.date: 11/07/2018
ms.topic: how-to
ms.custom: mvc
#Customer intent: As a developer, I want to load data with large numbers of columns from a CSV file so that I can use it in machine learning model building, training, and scoring with ML.NET.
---
# Load data with many columns from a CSV file for machine learning processing - ML.NET

`TextLoader` is used to load data from text files. You need to specify the data columns, their types, and their location in the text file.

When the input file contains many columns of the same type and always used together, read them as a *vector column*. This strategy results in a clean data schema and avoids unnecessary performance costs, as shown in the following example:

[Example file](https://github.com/dotnet/machinelearning/tree/master/test/data/generated_regression_dataset.csv):

```console
-2.75,0.77,-0.61,0.14,1.39,0.38,-0.53,-0.50,-2.13,-0.39,0.46,140.66
-0.61,-0.37,-0.12,0.55,-1.00,0.84,-0.02,1.30,-0.24,-0.50,-2.12,148.12
-0.85,-0.91,1.81,0.02,-0.78,-1.41,-1.09,-0.65,0.90,-0.37,-0.22,402.20
0.28,1.05,-0.24,0.30,-0.99,0.19,0.32,-0.95,-1.19,-0.63,0.75,443.51
```

Reading this file using `TextLoader`:

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging, 
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Create the reader: define the data columns and where to find them in the text file.
var reader = mlContext.Data.TextReader(new[] {
        // We read the first 10 values as a single float vector.
        new TextLoader.Column("FeatureVector", DataKind.R4, 0, 9),
        // Separately, read the target variable.
        new TextLoader.Column("Target", DataKind.R4, 10)
    },
    // Default separator is tab, but we need a comma.
    Separator = ",");

// Now read the file (remember though, readers are lazy, so the actual reading will happen when the data is accessed).
var data = reader.Read(dataPath);
```