---
title: Deploy Orleans to Azure App Service
description: Learn how to deploy an Orleans shopping cart app to Azure App Service.
ms.date: 04/18/2022
ms.topic: tutorial
---

# Deploy Orleans to Azure App Service

In this article, you will learn how to deploy an Orleans shopping cart app to Azure App Service. This tutorial will walk you through a sample application that supports the following features:

- **Shopping cart**: A simple shopping cart application that uses Orleans for its cross-platform framework support, and its scalable distributed applications capabilities.

  - **Inventory management**: Edit and/or create product inventory.
  - **Shop inventory**: Explore purchasable products and add them to your cart.
  - **Cart**: View a summary of all the items in your cart, and manage these items; either removing or changing the quantity of each item.

With an understanding of the app and its features, you will then learn how to deploy the app to Azure App Service. Additionally, you'll learn how to configure the virtual network for the app within Azure.

## Run the app locally

The app is built using .NET 6, if you don't already have .NET 6 installed on your machine, you need to [download and install it](https://dotnet.microsoft.com/download/dotnet/6.0).

Next, you need to fork the [Orleans-shopping-cart](https://github.com/IEvangelist/orleans-shopping-cart) repository and clone it to your local machine. If you're using Visual Studio, right-click the **Orleans.ShoppingCart.Silo** project and select **Set As Startup Project**, then run the app. Otherwise you can run the app using the following .NET CLI command:

```dotnetcli
dotnet run --project Silo\Orleans.ShoppingCart.Silo.csproj
```

For more information, see [dotnet run](../../core/tools/dotnet-run.md).

## Inside the shopping cart app

Orleans is a reliable and scalable framework for building distributed applications. For this tutorial, you will deploy a simple shopping cart app built using Orleans to Azure App Service. The app exposes the ability to manage inventory, add and remove items in a cart, and shop available products. The client is built using Blazor with a server hosting model. The app is architected as follows:

:::image type="content" source="media/shopping-cart-app-arch.png" lightbox="media/shopping-cart-app-arch.png" alt-text="Orleans: Shopping Cart sample app architecture.":::

The preceding diagram shows that the client is the server-side Blazor app. It's composed of several services that consume a corresponding Orleans grain. Each service pairs with an Orleans grain as follows:

- `InventoryService`: Consumes the `IInventoryGrain` where inventory is partitioned by product category.
- `ProductService`: Consumes the `IProductGrain` where a single product is tethered to a single grain instance by `Id`.
- `ShoppingCartService`: Consumes the `IShoppingCartGrain`  where a single user only has a single shopping cart instance regardless of consuming clients.

The solution contains three projects:

- `Orleans.ShoppingCart.Abstractions`: A class library that defines the models and the interfaces for the app.
- `Orleans.ShoppingCart.Grains`: A class library that defines the grains that implement the app's business logic.
- `Orleans.ShoppingCart.Silos`: A server-side Blazor app that hosts the Orleans silo.

### The client user experience

The shopping cart client app has several pages, each of which represents a different user experience.

**Home page**

A few simple phrases for the user to understand the app's purpose, and add context to each navigation menu item.

:::image type="content" source="media/home-page.png" lightbox="media/home-page.png" alt-text="Orleans: Shopping Cart sample app, home page.":::

**Shop inventory page**

A page that displays all of the products that are available for purchase. Items can be added to the cart from this page.

:::image type="content" source="media/shop-inventory-page.png" lightbox="media/shop-inventory-page.png" alt-text="Orleans: Shopping Cart sample app, shop inventory page.":::

**Empty cart page**

When you haven't added anything to your cart, the page renders a message that indicates that you have no items in your cart.

:::image type="content" source="media/empty-shopping-cart-page.png" lightbox="media/empty-shopping-cart-page.png" alt-text="Orleans: Shopping Cart sample app, empty cart page.":::

**Items added to cart while on the shop inventory page**

When items are added to your cart while on the shop inventory page, the app displays a message that indicates the item was added to the cart.

:::image type="content" source="media/shop-inventory-items-added-page.png" lightbox="media/shop-inventory-items-added-page.png" alt-text="Orleans: Shopping Cart sample app, items added to cart while on shop inventory page.":::

**Product management page**

A user can manage inventory from this page. Products can be added, edited, and removed from the inventory.

:::image type="content" source="media/product-management-page.png" lightbox="media/product-management-page.png" alt-text="Orleans: Shopping Cart sample app, product management page.":::

**Items in cart page**

When items are in your cart, you can view them and change their quantity, and even remove them from the cart. The user is presented a summary of the items in the cart, and the pretax total cost.

:::image type="content" source="media/items-in-shopping-cart-page.png" lightbox="media/items-in-shopping-cart-page.png" alt-text="Orleans: Shopping Cart sample app, items in cart page.":::

> [!TIP]
> When this app runs locally, in a Development environment, the app will use local host clustering, in-memory storage, and a local silo. It also seeds the inventory with fake data that is automatically generated using the [Bogus NuGet](https://www.nuget.org/packages/bogus) package. This is all intentional to demonstrate the functionality.

## Deploy to Azure App Service

## Configure the virtual network for the app

## See also

- [Quickstart: Deploy an ASP.NET web app](/azure/app-service/quickstart-dotnetcore)
- [Enable virtual network integration in Azure App Service](/azure/app-service/configure-vnet-integration-enable)
