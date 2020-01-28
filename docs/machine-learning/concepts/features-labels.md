---
title: Difference between features and labels
description: Understand how to create features and labels from your raw machine learning training data
ms.date: 01/28/2020
ms.topic: concept
---

# What is the difference between a feature and a label?

Features are the input data to a machine learning algorithm. A label is the output that you are trying to predict.

Features can be as concrete as the size and number of bedrooms of a house, and as complex as thousands of properties derived from the pixels in an image.

Labels are usually simpler: The price of the house; or the type of object identified in an image.
 
A machine learning algorithm uses training data containing example features and labels to generate a model that can be used to make predictions on previously unseen inputs.

Features and labels must be numerical values in order to be processed by a machine learning algorithm

Often the available data is not numbers but rather text, images, and dates, and must be transformed into numbers before being processed by the training algorithm.

## Categorical data

One of the most common types of data is categorical data. Categorical data is that which has a finite number of categories. For example, the states of the USA, or a list of the types of animals found in a set of pictures. Whether these are features or labels, they must be mapped onto a numerical value. There are a number of ways of doing this in ML.NET, depending on the problem you are solving.

### Key value mapping

In ML.NET, a key is an integer value representing a category. Key value mapping is most often used to map string labels into unique integer values for training, then back to their string values when the model is used to make a prediction.

The transforms used to perform key value mapping are [MapValueToKey](xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValueToKey%2A) and [MapKeyToValue](Microsoft.ML.ConversionsExtensionsCatalog.MapKeyToValue%2A).

`MapValueToKey` adds a dictionary of mappings in the model, so that `MapKeyToValue` can perform the reverse transform when making a prediction.

### One hot encoding

### Hashing


