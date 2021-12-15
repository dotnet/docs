---
title: Compare testing options between ASP.NET MVC and ASP.NET Core
description: How does testing differ between ASP.NET MVC apps and ASP.NET Core apps?
author: ardalis
ms.date: 12/10/2021
---

# Compare testing options between ASP.NET MVC and ASP.NET Core

ASP.NET MVC apps support unit testing of controllers, but this approach often omits many MVC features like routing, authorization, model binding, model validation, filters, and more. To test these MVC features in addition to the logic within the controller action itself, frequently the app would need to be deployed and then tested with a tool like Selenium. These tests are substantially more expensive, more brittle, and slower than typical unit tests that can be run without the need for hosting and running the entire app.

[ASP.NET Core controllers can be unit tested](/aspnet/core/mvc/controllers/testing) just like ASP.NET MVC controllers, but with the same limitations. However, [ASP.NET Core supports fast, easy-to-author integration tests](/aspnet/core/test/integration-tests) as well. Integration tests are hosted by a `TestHost` class and are typically configured in a custom `WebApplicationFactory` that can override or replace app dependencies. For instance, frequently during integration tests the app will target a different data source and may replace services that send emails with fake or mock implementations.

ASP.NET MVC and Web API did not support anything like the integration testing scenarios available in ASP.NET Core. In any migration effort, you should allocate time to write some integration tests for your newly migrated system to ensure it's working as expected and continues to do so. Even if you weren't writing tests of your web app logic before the migration, you should strongly consider doing so as you move to ASP.NET Core.

## References

- [Creating Unit Tests for ASP.NET MVC Applications](/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs)
- [Unit test controller logic in ASP.NET Core](/aspnet/core/mvc/controllers/testing)
- [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests)

>[!div class="step-by-step"]
>[Previous](signalr-differences.md)
>[Next](migrate-large-solutions.md)
