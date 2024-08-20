---
title: Client-side validation (validation in the presentation layers)
description: .NET Microservices Architecture for Containerized .NET Applications | Explore the key concepts of client-side validation.
ms.date: 10/08/2018
---
# Client-side validation (validation in the presentation layers)

[!INCLUDE [download-alert](../includes/download-alert.md)]

Even when the source of truth is the domain model and ultimately you must have validation at the domain model level, validation can still be handled at both the domain model level (server side) and the UI (client side).

Client-side validation is a great convenience for users. It saves time they would otherwise spend waiting for a round trip to the server that might return validation errors. In business terms, even a few fractions of seconds multiplied hundreds of times each day adds up to a lot of time, expense, and frustration. Straightforward and immediate validation enables users to work more efficiently and produce better quality input and output.

Just as the view model and the domain model are different, view model validation and domain model validation might be similar but serve a different purpose. If you are concerned about DRY (the Don't Repeat Yourself principle), consider that in this case code reuse might also mean coupling, and in enterprise applications it is more important not to couple the server side to the client side than to follow the DRY principle.

Even when using client-side validation, you should always validate your commands or input DTOs in server code, because the server APIs are a possible attack vector. Usually, doing both is your best bet because if you have a client application, from a UX perspective, it is best to be proactive and not allow the user to enter invalid information.

Therefore, in client-side code you typically validate the ViewModels. You could also validate the client output DTOs or commands before you send them to the services.

The implementation of client-side validation depends on what kind of client application you are building. It will be different if you are validating data in a web MVC web application with most of the code in .NET, a SPA web application with that validation being coded in JavaScript or TypeScript, or a mobile app coded with Xamarin and C#.

## Additional resources

### Validation in ASP.NET Core apps

- **Rick Anderson. Adding validation** \
  [https://learn.microsoft.com/aspnet/core/tutorials/first-mvc-app/validation](/aspnet/core/tutorials/first-mvc-app/validation)

### Validation in SPA Web apps (Angular 2, TypeScript, JavaScript, Blazor WebAssembly)

- **Form Validation** \
  <https://angular.io/guide/form-validation>

- **Validation.** Breeze documentation. \
  <https://breeze.github.io/doc-js/validation.html>

- **ASP.NET Core Blazor forms and input components** \ </aspnet/core/blazor/forms-and-input-components>

In summary, these are the most important concepts in regards to validation:

- Entities and aggregates should enforce their own consistency and be "always valid". Aggregate roots are responsible for multi-entity consistency within the same aggregate.

- If you think that an entity needs to enter an invalid state, consider using a different object model—for example, using a temporary DTO until you create the final domain entity.

- If you need to create several related objects, such as an aggregate, and they are only valid once all of them have been created, consider using the Factory pattern.

- In most of the cases, having redundant validation in the client side is good, because the application can be proactive.

>[!div class="step-by-step"]
>[Previous](domain-model-layer-validations.md)
>[Next](domain-events-design-implementation.md)
