---
title: Load data from a text file for machine learning processing - ML.NET
description: Discover how to load data from a text file for use in machine learning model building, training, and scoring with ML.NET
ms.date: 01/29/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to load data from a text file so that I can use it in machine learning model building, training, and scoring with ML.NET.
---

# Load data from a text file for machine learning processing - ML.NET

`TextLoader` is used to load data from text files. You need to specify the data columns, their types, and their location in the text file.

Note that it's perfectly acceptable to read some columns of a file, or read the same column multiple times.

[Example file](https://github.com/dotnet/machinelearning/blob/master/test/data/adult.tiny.with-schema.txt):

```console
Label	Workclass	education	marital-status
0	Private	11th	Never-married
0	Private	HS-grad	Married-civ-spouse
1	Local-gov	Assoc-acdm	Married-civ-spouse
1	Private	Some-college	Married-civ-spouse
```

To load the data from a text file:

```csharp
// Create a new context for ML.NET operations. It can be used for exception tracking and logging, 
// as a catalog of available operations and as the source of randomness.
var mlContext = new MLContext();

// Create the reader: define the data columns and where to find them in the text file.
var reader = mlContext.Data.CreateTextReader(
    columns: new TextLoader.Column[]
    {
        // A boolean column depicting the 'target label'.
        new TextLoader.Column("IsOver50k",DataKind.BL,0),
        // Three text columns.
        new TextLoader.Column("WorkClass",DataKind.TX,1),
        new TextLoader.Column("Education",DataKind.TX,2),
        new TextLoader.Column("MaritalStatus",DataKind.TX,3)
    },
    hasHeader: true
);

// Now read the file (remember though, readers are lazy, so the actual reading will happen when the data is accessed).
var data = reader.Read(dataPath);
```