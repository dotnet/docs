---
title: "Tutorial: Author GitHub Actions with .NET"
description: Learn how to create a GitHub action with a containerized .NET app.
author: IEvangelist
ms.author: dapine
ms.date: 03/16/2021
ms.topic: tutorial
---

# Tutorial: Author GitHub Actions with .NET

Learn how to create a .NET app that can be used as a GitHub Action. [GitHub Actions](https://github.com/features/actions) enable workflow automation and composition. With GitHub Actions, you can build, test, and deploy source code from GitHub, as well as interact with issues, pull requests, code reviews and branches.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Containerize a .NET app
> - Define action inputs and outputs
> - Compose a consuming workflow
> - Explore workflow composition

## Prerequisites

- A [GitHub account](https://github.com/join)
- B

## Containerize a .NET app

  The idea for the app is to create / update a CODE_METRICS.md at the root of the repo's dir
  The CODE_METRICS.md file would contain data from: Code metrics output

## Define action inputs and outputs

  Differentiate between writing an action, and consuming one
  Touch on Jobs / Steps / Marketplace

## Compose a consuming workflow

Show what can be done from an action
Show passing of parameters / ENV VAR / Docker / Inputs and Output
Discuss repo Secrets and ${{ secrets.GITHUB_TOKEN }}

## Explore workflow composition

Show a consuming GitHub action workflow

## Clean up resources

If you're not going to continue to use this application, delete
<resources> with the following steps:

1. From the left-hand menu...
1. ...click Delete, type...and then click Delete

<!-- 7. Next steps
Required: A single link in the blue box format. Point to the next logical tutorial 
in a series, or, if there are no other tutorials, to some other cool thing the 
customer can do. 
-->

## Next steps

> [!div class="nextstepaction"]
> [.NET GitHub Action sample code](contribute-how-to-mvc-tutorial.md)
