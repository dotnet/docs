---
title: Generate Unit Tests with Copilot
author: sigmade
description: How to generate unit tests and test projects in C# using the xUnit framework with the help of Visual Studio commands and GitHub Copilot
ms.date: 01/12/2025
---

# Generate unit tests with GitHub Copilot

In this article, you explore how to generate unit tests and test projects in C# using the xUnit framework with the help of Visual Studio commands and GitHub Copilot.

## Generate a test project and a stub method

Imagine that there's a `ProductService` class with a `GetProductById` method that depends on the `IProductDataStorage` and `ICacheClient` interfaces.

```csharp
public class ProductService(
    IProductDataStorage productDataStorage,
    ICacheClient cacheClient)
{
    public async Task<Product?> GetProductById(int productId)
    {
        var product = await cacheClient.GetProduct(productId);

        if (product is not null)
        {
            return product;
        }

        product = await productDataStorage.GetProduct(productId);

        if (product is not null)
        {
            await _cacheClient.SetProduct(product);
        }

        return product;
    }
}
```

To generate a test project and a stub method, follow these steps:

- Select the method.
- Right-click and select **Create Unit Tests**.

:::image type="content" source="media/create-unit-test.png" lightbox="media/create-unit-test.png" alt-text="Command Create Unit Tests":::

In the **Create Unit Tests** dialog, select **xUnit** from the **Test Framework** dropdown menu.

> [!NOTE]
> The "Create Unit Tests" command defaults to the MSTest framework. However, since this example uses xUnit, you need to install the Visual Studio extension xUnit.net.TestGenerator2022.

:::image type="content" source="media/create-unit-test-window.png" lightbox="media/create-unit-test-window.png" alt-text="Create Unit Tests window":::

* If you don't have a test project yet, choose "New Test Project" or select an existing one.
* If necessary, specify a template for the namespace, class, and method name, then click OK.

After a few seconds, Visual Studio will pull in the necessary packages, and we will get a generated xUnit project with the required packages, structure, a reference to the project being tested, and with the `ProductServiceTests` class and a stub method.

:::image type="content" source="media/test-mehod-stub.png" lightbox="media/test-mehod-stub.png" alt-text="Generated stub method":::

## Generate the tests themselves:

* Select the method being tested again.
* Right-click - Ask Copilot.
* Enter a simple prompt, such as: <br> `generate unit tests using xunit, nsubstitute and insert the result into ProductServiceTests`</br> You need to select your test class using #. 

> [!TIP]
> For quick search, it's desirable that `ProductServiceTests` is open in a separate tab.

:::image type="content" source="media/test-copilot-prompt.png" lightbox="media/test-copilot-prompt.png" alt-text="Prompt for generate tests":::

Execute the prompt, click **Accept**, and Copilot generates the test code. After that, it remains to install the necessary packages.

When the packages are installed, the tests can be run. This example worked on the first try: Copilot knows very well how to work with NSubstitute, and all dependencies were defined through interfaces. 

:::image type="content" source="media/test-mehod-stub.png" lightbox="media/test-mehod-stub.png" alt-text="Generated tests":::

Thus, using **Visual Studio** in combination with **GitHub Copilot** significantly simplifies the process of generating and writing unit tests. 