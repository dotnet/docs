---
title: Deploy Orleans to Azure App Service
description: Learn how to deploy an Orleans shopping cart app to Azure App Service.
ms.date: 04/15/2022
ms.topic: tutorial
---

# Deploy Orleans to Azure App Service

In this article, you will learn how to deploy an Orleans shopping cart app to Azure App Service. This tutorial will walk you through a sample application that supports the following features:

- **Shopping cart**: A simple shopping cart application that uses the Orleans distributed-transactional event-sourcing framework.

  - **Inventory management**: Edit and/or create products.
  - **Shop inventory**: Explore purchasable products and add them to your cart.
  - **Cart**: View a summary of all the items in your cart, and manage these items; either removing or changing the quantity of each item.

With an understanding of the app and its features, you will then learn how to deploy the app to Azure App Service. Additionally, you'll learn how to configure the virtual network for the app within Azure.

## The shopping cart app

Orleans is a distributed, reliable, and scalable framework for building distributed applications. For this tutorial, you will deloy a simple shopping cart app built using Orleans to Azure App Service. The app exposes the ability to manage inventory, add and remove items in a cart, and shop available products. The client is built using Blazor with a server hosting model. The app is architected as follows:

:::image type="content" source="media/shopping-cart-app-arch.png" lightbox="media/shopping-cart-app-arch.png" alt-text="Orleans: Shopping Cart Sample App.":::

The preceding diagram shows that the client is the server-side Blazor app. It's composed of services that consume the corresponding Orleans grain. Each service pairs with an Orleans grain in this app:

- `InventoryService`: Consumes the `IInventoryGrain` where inventory is partitioned by product category.
- `ProductService`: Consumes the `IProductGrain` where a single product by its `Id` is tethered to a single grain instance.
- `ShoppingCartService`: Consumes the `IShoppingCartGrain`  where a user only has one cart.

The client is a server-side Blazor app that uses Orleans. It contains three projects:

- `Orleans.ShoppingCart.Abstractions`: A class library that defines the models and the interfaces for the app.
- `Orleans.ShoppingCart.Grains`: A class library that defines the grains that implement the app's business logic.
- `Orleans.ShoppingCart.Silos`: A server-side Blazor app that hosts the Orleans silo.

## See also

- [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore)
- [Enable virtual network integration in Azure App Service](/azure/app-service/configure-vnet-integration-enable)
