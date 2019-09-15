---
title: Designing the microservice application layer and Web API
description: .NET Microservices Architecture for Containerized .NET Applications | A brief mention of the SOLID principles for designing the application layer.
ms.date: 10/08/2018
---

# Design the microservice application layer and Web API

## Use SOLID principles and Dependency Injection

SOLID principles are critical techniques to be used in any modern and mission-critical application, such as developing a microservice with DDD patterns. SOLID is an acronym that groups five fundamental principles:

- Single Responsibility principle

- Open/closed principle

- Liskov substitution principle

- Interface Segregation principle

- Dependency Inversion principle

SOLID is more about how you design your application or microservice internal layers and about decoupling dependencies between them. It is not related to the domain, but to the application’s technical design. The final principle, the Dependency Inversion principle, allows you to decouple the infrastructure layer from the rest of the layers, which allows a better decoupled implementation of the DDD layers.

Dependency Injection (DI) is one way to implement the Dependency Inversion principle. It is a technique for achieving loose coupling between objects and their dependencies. Rather than directly instantiating collaborators, or using static references (that is, using new…), the objects that a class needs in order to perform its actions are provided to (or "injected into") the class. Most often, classes will declare their dependencies via their constructor, allowing them to follow the Explicit Dependencies principle. Dependency Injection is usually based on specific Inversion of Control (IoC) containers. ASP.NET Core provides a simple built-in IoC container, but you can also use your favorite IoC container, like Autofac or Ninject.

By following the SOLID principles, your classes will tend naturally to be small, well-factored, and easily tested. But how can you know if too many dependencies are being injected into your classes? If you use DI through the constructor, it will be easy to detect that by just looking at the number of parameters for your constructor. If there are too many dependencies, this is generally a sign (a [code smell](https://deviq.com/code-smells/)) that your class is trying to do too much, and is probably violating the Single Responsibility principle.

It would take another guide to cover SOLID in detail. Therefore, this guide requires you to have only a minimum knowledge of these topics.

#### Additional resources

- **SOLID: Fundamental OOP Principles** \
  <https://deviq.com/solid/>

- **Inversion of Control Containers and the Dependency Injection pattern** \
  <https://martinfowler.com/articles/injection.html>

- **Steve Smith. New is Glue** \
  <https://ardalis.com/new-is-glue>

> [!div class="step-by-step"]
> [Previous](nosql-database-persistence-infrastructure.md)
> [Next](microservice-application-layer-implementation-web-api.md)
