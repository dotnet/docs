---
title: Load data from multiple files for machine learning processing - ML.NET
description: Learn how to Load data from multiple files for use in machine learning model building, training, and scoring with ML.NET
ms.date: 11/07/2018
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to load data from multiple files so that I can use it in machine learning model building, training, and scoring with ML.NET.
---
# Load data from multiple files for machine learning processing - ML.NET

Use the `TextLoader`, and specify an array of files to the `Read` method. The files must have the same schema (same number and type of columns):

* [Example file1](https://github.com/dotnet/machinelearning/blob/e3a34ae6ae1b25ac96faa0317308703ce943ff95/test/data/adult.train)
* [Example file2](https://github.com/dotnet/machinelearning/blob/e3a34ae6ae1b25ac96faa0317308703ce943ff95/test/data/adult.test)

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging, 
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Create the reader: define the data columns and where to find them in the text file.
var reader = mlContext.Data.TextReader(new TextLoader.Arguments
{
    Column = new[] {
        // A boolean column depicting the 'label'.
        new TextLoader.Column("IsOver50k", DataKind.BL, 0),
        // Three text columns.
        new TextLoader.Column("Workclass", DataKind.TX, 1),
        new TextLoader.Column("Education", DataKind.TX, 2),
        new TextLoader.Column("MaritalStatus", DataKind.TX, 3)
    },
    // First line of the file is a header, not a data row.
    HasHeader = true
});

var data = reader.Read(exampleFile1, exampleFile2);
```