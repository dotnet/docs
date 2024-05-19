---
title: How to format data for Named Entity Recognition (NER)
description: Learn how to format data for the Named Entity Recognition (NER) scenario in Model Builder
ms.date: 02/23/2024
author: zewditu
ms.author: zehailem
ms.custom: mvc,how-to
ms.topic: how-to
#Customer intent: As a non-developer, I want to be able to format training data for Model Builder to use for training NER scenarios
---

# How to format data for Named Entity Recognition (NER)

NER dataset shapes:

- **Key information file:** The key information file contains a list of entities, which serves as key information for the training data.
- **Training data:** Training data consists of a file (.txt, .tsv) containing columns separated by a Tab character. One of the columns is a sentence column, while the others represent labels for tokens within the sentence column.
