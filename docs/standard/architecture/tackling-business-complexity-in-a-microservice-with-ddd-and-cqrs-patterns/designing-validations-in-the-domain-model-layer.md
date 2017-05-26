---
title: Designing validations in the domain model layer | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Designing validations in the domain model layer
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Designing validations in the domain model layer

In DDD, validation rules can be thought as invariants. The main responsibility of an aggregate is to enforce invariants across state changes for all the entities within that aggregate.

Domain entities should always be valid entities. There are a certain number of invariants for an object that should always be true. For example, an order item object always has to have a quantity that must be must be a positive integer, plus an article name and price. Therefore, invariants enforcement is the responsibility of the domain entities (especially of the aggregate root) and an entity object should not be able to exist without being valid. Invariant rules are simply expressed as contracts, and exceptions or notifications are raised when they are violated.

The reasoning behind this is that many bugs occur because objects are in a state they should never have been in. The following is a good explanation from Greg Young in an [online discussion](http://jeffreypalermo.com/blog/the-fallacy-of-the-always-valid-entity/):

Let's propose we now have a SendUserCreationEmailService that takes a UserProfile ... how can we rationalize in that service that Name is not null? Do we check it again? Or more likely ... you just don't bother to check and "hope for the best"—you hope that someone bothered to validate it before sending it to you. Of course, using TDD one of the first tests we should be writing is that if I send a customer with a null name that it should raise an error. But once we start writing these kinds of tests over and over again we realize ... "wait if we never allowed name to become null we wouldn't have all of these tests"


>[!div class="step-by-step"]
[Previous] (using-enumeration-classes-instead-of-enum-types.md)
[Next] (implementing-validations-in-the-domain-model-layer.md)
