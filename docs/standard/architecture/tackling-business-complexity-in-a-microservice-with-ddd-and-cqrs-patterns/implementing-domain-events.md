---
title: Implementing domain events | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Implementing domain events
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Implementing domain events

In C\#, a domain event is simply a data-holding structure or class, like a DTO, with all the information related to what just happened in the domain, as shown in the following example:

```
  public class OrderStartedDomainEvent : IAsyncNotification
  
  {
  
  public int CardTypeId { get; private set; }
  
  public string CardNumber { get; private set; }
  
  public string CardSecurityNumber { get; private set; }
  
  public string CardHolderName { get; private set; }
  
  public DateTime CardExpiration { get; private set; }
  
  public Order Order { get; private set; }
  
  public OrderStartedDomainEvent(Order order,
  
  int cardTypeId, string cardNumber,
  
  string cardSecurityNumber, string cardHolderName,
  
  DateTime cardExpiration)
  
  {
  
  Order = order;
  
  CardTypeId = cardTypeId;
  
  CardNumber = cardNumber;
  
  CardSecurityNumber = cardSecurityNumber;
  
  CardHolderName = cardHolderName;
  
  CardExpiration = cardExpiration;
  
  }
  
  }
```

This is essentially a class that holds all the data related to the OrderStarted event.

In terms of the ubiquitous language of the domain, since an event is something that happened in the past, the class name of the event should be represented as a past-tense verb, like OrderStartedDomainEvent or OrderShippedDomainEvent. That is how the domain event is implemented in the ordering microservice in eShopOnContainers.

As we have noted, an important characteristic of events is that since an event is something that happened in the past, it should not change. Therefore it must be an immutable class. You can see in the preceding code that the properties are read-only from outside of the object. The only way to update the object is through the constructor when you create the event object.

## Raising domain events

The next question is how to raise a domain event so it reaches its related event handlers. You can use multiple approaches.

Udi Dahan originally proposed (for example, in several related posts, such as [Domain Events – Take 2](http://udidahan.com/2008/08/25/domain-events-take-2/)) using a static class for managing and raising the events. This might include a static class named DomainEvents that would raise domain events immediately when it is called, using syntax like DomainEvents.Raise(Event myEvent). Jimmy Bogard wrote a blog post ([Strengthening your domain: Domain Events](https://lostechies.com/jimmybogard/2010/04/08/strengthening-your-domain-domain-events/)) that recommends a similar approach.

However, when the domain events class is static, it also dispatches to handlers immediately. This makes testing and debugging more difficult, because the event handlers with side-effects logic are executed immediately after the event is raised. When you are testing and debugging, you want to focus on and just what is happening in the current aggregate classes; you do not want to suddenly be redirected to other event handlers for side effects related to other aggregates or application logic. This is why other approaches have evolved, as explained in the next section.

### The deferred approach for raising and dispatching events

Instead of dispatching to a domain event handler immediately, a better approach is to add the domain events to a collection and then to dispatch those domain events *right before* or *right* *after* committing the transaction (as with SaveChanges in EF). (This approach was described by Jimmy Bogard in this post [A better domain events pattern](https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/).)

Deciding if you send the domain events right before or right after committing the transaction is important, since it determines whether you will include the side effects as part of the same transaction or in different transactions. In the latter case, you need to deal with eventual consistency across multiple aggregates. This topic is discussed in the next section.

The deferred approach is what eShopOnContainers uses. First, you add the events happening in your entities into a collection or list of events per entity. That list should be part of the entity object, or even better, part of your base entity class, as shown in the following example:

```
  public abstract class Entity
  
  {
  
  private List<;IAsyncNotification> _domainEvents;
  
  public List<;IAsyncNotification> DomainEvents => _domainEvents;
  
  public void AddDomainEvent(IAsyncNotification eventItem)
  
  {
  
  _domainEvents = _domainEvents ?? new List<;IAsyncNotification>();
  
  _domainEvents.Add(eventItem);
  
  }
  
  public void RemoveDomainEvent(IAsyncNotification eventItem)
  
  {
  
  if (_domainEvents is null) return;
  
  _domainEvents.Remove(eventItem);
  
  }
  
  // ...
  
  }
```

When you want to raise an event, you just add it to the event collection to be placed within an aggregate entity method, as the following code shows:

```
  var orderStartedDomainEvent = new OrderStartedDomainEvent(this, //Order object
  
  cardTypeId,
  
  cardNumber,
  
  cardSecurityNumber,
  
  cardHolderName,
  
  cardExpiration);
  
  this.AddDomainEvent(orderStartedDomainEvent);
```

Notice that the only thing that the AddDomainEvent method is doing is adding an event to the list. No event is raised yet, and no event handler is invoked yet.

You actually want to dispatch the events later on, when you commit the transaction to the database. If you are using Entity Framework Core, that means in the SaveChanges method of your EF DbContext, as in the following code:

```
  // EF Core DbContext
  
  public class OrderingContext : DbContext, IUnitOfWork
  
  {
  
  // ...
  
  public async Task<;int> SaveEntitiesAsync()
  
  {
  
  // Dispatch Domain Events collection.
  
  // Choices:
  
  // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes
  
  // a single transaction including side effects from the domain event
  
  // handlers that are using the same DbContext with Scope lifetime
  
  // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes
  
  // multiple transactions. You will need to handle eventual consistency and
  
  // compensatory actions in case of failures.
  
  await _mediator.DispatchDomainEventsAsync(this);
  
  // After this line runs, all the changes (from the Command Handler and Domain
  
  // event handlers) performed through the DbContext will be commited
  
  var result = await base.SaveChangesAsync();
  
  }
  
  }
```

With this code, you dispatch the entity events to their respective event handlers.

The overall result is that you have decoupled the raising of a domain event (a simple add into a list in memory) from dispatching it to an event handler. In addition, depending on what kind of dispatcher you are using, you could dispatch the events synchronously or asynchronously.

Be aware that transactional boundaries come into significant play here. If your unit of work and transaction can span more than one aggregate (as when using EF Core and a relational database), this can work well. But if the transaction cannot span aggregates, such as when you are using a NoSQL database like Azure DocumentDB, you have to implement additional steps to achieve consistency. This is another reason why persistence ignorance is not universal; it depends on the storage system you use.

## Single transaction across aggregates versus eventual consistency across aggregates

The question of whether to perform a single transaction across aggregates versus relying on eventual consistency across those aggregates is a controversial one. Many DDD authors like Eric Evans and Vaughn Vernon advocate the rule that one transaction = one aggregate and therefore argue for eventual consistency across aggregates. For example, in his book *Domain-Driven Design*, Eric Evans says this:

Any rule that spans Aggregates will not be expected to be up-to-date at all times. Through event processing, batch processing, or other update mechanisms, other dependencies can be resolved within some specific time. (pg. 128)

Vaughn Vernon says the following in [Effective Aggregate Design. Part II: Making Aggregates Work Together](http://dddcommunity.org/wp-content/uploads/files/pdf_articles/Vernon_2011_2.pdf):

Thus, if executing a command on one aggregate instance requires that additional business rules execute on one or more aggregates, use eventual consistency \[...\] There is a practical way to support eventual consistency in a DDD model. An aggregate method publishes a domain event that is in time delivered to one or more asynchronous subscribers.

This rationale is based on embracing fine-grained transactions instead of transactions spanning many aggregates or entities. The idea is that in the second case, the number of database locks will be substantial in large-scale applications with high scalability needs. Embracing the fact that high-scalable applications need not have instant transactional consistency between multiple aggregates helps with accepting the concept of eventual consistency. Atomic changes are often not needed by the business, and it is in any case the responsibility of the domain experts to say whether particular operations need atomic transactions or not. If an operation always needs an atomic transaction between multiple aggregates, you might ask whether your aggregate should be larger or was not correctly designed.

However, other developers and architects like Jimmy Bogard are okay with spanning a single transaction across several aggregates—but only when those additional aggregates are related to side effects for the same original command. For instance, in [A better domain events pattern](https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/), Bogard says this:

Typically, I want the side effects of a domain event to occur within the same logical transaction, but not necessarily in the same scope of raising the domain event \[...\] Just before we commit our transaction, we dispatch our events to their respective handlers.

If you dispatch the domain events right *before* committing the original transaction, it is because you want the side effects of those events to be included in the same transaction. For example, if the EF DbContext SaveChanges method fails, the transaction will roll back all changes, including the result of any side effect operations implemented by the related domain event handlers. This is because the DbContext life scope is by default defined as "scoped." Therefore, the DbContext object is shared across multiple repository objects being instantiated within the same scope or object graph. This coincides with the HttpRequest scope when developing Web API or MVC apps.

In reality, both approaches (single atomic transaction and eventual consistency) can be right. It really depends on your domain or business requirements and what the domain experts tell you. It also depends on how scalable you need the service to be (more granular transactions have less impact with regard to database locks). And it depends on how much investment you are willing to make in your code, since eventual consistency requires more complex code in order to detect possible inconsistencies across aggregates and the need to implement compensatory actions. Take into account that if you commit changes to the original aggregate and afterwards, when the events are being dispatched, there is an issue and the event handlers cannot commit their side effects, you will have inconsistencies between aggregates.

A way to allow compensatory actions would be to store the domain events in additional database tables so they can be part of the original transaction. Afterwards, you could have a batch process that detects inconsistencies and runs compensatory actions by comparing the list of events with the current state of the aggregates. The compensatory actions are part of a complex topic that will require deep analysis from your side, which includes discussing it with the business user and domain experts.

In any case, you can choose the approach you need. But the initial deferred approach—raising the events before committing, so you use a single transaction—is the simplest approach when using EF Core and a relational database. It is easier to implement and valid in many business cases. It is also the approach used in the ordering microservice in eShopOnContainers.

But how do you actually dispatch those events to their respective event handlers? What is the \_mediator object that you see in the previous example? That has to do with the techniques and artifacts you can use to map between events and their event handlers.

## The domain event dispatcher: mapping from events to event handlers

Once you are able to dispatch or publish the events, you need some kind of artifact that will publish the event so that every related handler can get it and process side effects based on that event.

One approach is a real messaging system or even an event bus, possibly based on a service bus as opposed to in-memory events. However, for the first case, real messaging would be overkill for processing domain events, since you just need to process those events within the same process (that is, within the same domain and application layer).

Another way to map events to multiple event handlers is by using types registration in an IoC container so that you can dynamically infer where to dispatch the events. In other words, you need to know what event handlers need to get a specific event. Figure 9-16 shows a simplified approach for that.

![](./media/image17.png)

**Figure 9-16**. Domain event dispatcher using IoC

You can build all the plumbing and artifacts to implement that approach by yourself. However, you can also use available libraries like [MediatR](https://github.com/jbogard/MediatR), which underneath the covers uses your IoT container. You can therefore directly use the predefined interfaces and the mediator object’s publish/dispatch methods.

In code, you first need to register the event handler types in your IoC container, as shown in the following example:

```
  public class MediatorModule : Autofac.Module
  
  {
  
  protected override void Load(ContainerBuilder builder)
  
  {
  
  // Other registrations ...
  
  // Register the DomainEventHandler classes (they implement
  
  // IAsyncNotificationHandler<;>) in assembly holding the Domain Events
  
  builder.RegisterAssemblyTypes(
  
  typeof(ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler).
  
  GetTypeInfo().Assembly)
  
  .Where(t =>
  
  t.IsClosedTypeOf(typeof(IAsyncNotificationHandler<;>)))
  
  .AsImplementedInterfaces();
  
  // Other registrations ...
  
  }
  
  }
```

The code first identifies the assembly that contains the domain event handlers by locating the assembly that holds any of the handlers (using typeof(ValidateOrAddBuyerAggregateWhenXxxx), but you could have chosen any other event handler to locate the assembly). Since all the event handlers implement the IAsyncNotificationHandler interface, the code then just searches for those types and registers all the event handlers.

## How to subscribe to domain events

When you use MediatR, each event handler must use an event type that is provided on the generic parameter of the IAsyncNotificationHandler interface, as you can see in the following code:

```
  public class ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler
  
  : IAsyncNotificationHandler<;OrderStartedDomainEvent>
```

Based on the relationship between event and event handler, which can be considered the subscription, the MediatR artifact can discover all the event handlers for each event and trigger each of those event handlers.

## How to handle domain events

Finally, the event handler usually implements application layer code that uses infrastructure repositories to obtain the required additional aggregates and to execute side-effect domain logic. The following code shows an example.

```
  public class ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler
  
  : IAsyncNotificationHandler<;OrderStartedDomainEvent>
  
  {
  
  private readonly ILoggerFactory _logger;
  
  private readonly IBuyerRepository<;Buyer> _buyerRepository;
  
  private readonly IIdentityService _identityService;
  
  public ValidateOrAddBuyerAggregateWhenOrderStartedDomainEventHandler(
  
  ILoggerFactory logger,
  
  IBuyerRepository<;Buyer> buyerRepository,
  
  IIdentityService identityService)
  
  {
  
  // Parameter validations
  
  //...
  
  }
  
  public async Task Handle(OrderStartedDomainEvent orderStartedEvent)
  
  {
  
  var cardTypeId = (orderStartedEvent.CardTypeId != 0) ?
  
  orderStartedEvent.CardTypeId : 1;
  
  var userGuid = _identityService.GetUserIdentity();
  
  var buyer = await _buyerRepository.FindAsync(userGuid);
  
  bool buyerOriginallyExisted = (buyer == null) ? false : true;
  
  if (!buyerOriginallyExisted)
  
  {
  
  buyer = new Buyer(userGuid);
  
  }
  
  buyer.VerifyOrAddPaymentMethod(cardTypeId,
  
  $"Payment Method on {DateTime.UtcNow}",
  
  orderStartedEvent.CardNumber,
  
  orderStartedEvent.CardSecurityNumber,
  
  orderStartedEvent.CardHolderName,
  
  orderStartedEvent.CardExpiration,
  
  orderStartedEvent.Order.Id);
  
  var buyerUpdated = buyerOriginallyExisted ? _buyerRepository.Update(buyer) :
  
  _buyerRepository.Add(buyer);
  
  await _buyerRepository.UnitOfWork.SaveEntitiesAsync();
  
  // Logging code using buyerUpdated info, etc.
  
  }
  
  }
```

This event handler code is considered application layer code because it uses infrastructure repositories, as explained in the next section on the infrastructure-persistence layer. Event handlers could also use other infrastructure components.

### Domain events can generate integration events to be published outside of the microservice boundaries

Finally, is important to mention that you might sometimes want to propagate events across multiple microservices. That is considered an integration event, and it could be published through an event bus from any specific domain event handler.

## Conclusions on domain events 

As stated, use domain events to explicitly implement side effects of changes within your domain. To use DDD terminology, use domain events to explicitly implement side effects across one or multiple aggregates. Additionally, and for better scalability and less impact on database locks, use eventual consistency between aggregates within the same domain.

#### Additional resources

-   **Greg Young. What is a Domain Event?**
    [*http://codebetter.com/gregyoung/2010/04/11/what-is-a-domain-event/*](http://codebetter.com/gregyoung/2010/04/11/what-is-a-domain-event/)

-   **Jan Stenberg. Domain Events and Eventual Consistency**
    [*https://www.infoq.com/news/2015/09/domain-events-consistency*](https://www.infoq.com/news/2015/09/domain-events-consistency)

-   **Jimmy Bogard. A better domain events pattern**
    [*https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/*](https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/)

-   **Vaughn Vernon. Effective Aggregate Design Part II: Making Aggregates Work Together**
    [*http://dddcommunity.org/wp-content/uploads/files/pdf\_articles/Vernon\_2011\_2.pdf*](http://dddcommunity.org/wp-content/uploads/files/pdf_articles/Vernon_2011_2.pdf)

-   **Jimmy Bogard. Strengthening your domain: Domain Events**
    *<https://lostechies.com/jimmybogard/2010/04/08/strengthening-your-domain-domain-events/> *

-   **Tony Truong. Domain Events Pattern Example**
    [*http://www.tonytruong.net/domain-events-pattern-example/*](http://www.tonytruong.net/domain-events-pattern-example/)

-   **Udi Dahan. How to create fully encapsulated Domain Models**
    [*http://udidahan.com/2008/02/29/how-to-create-fully-encapsulated-domain-models/*](http://udidahan.com/2008/02/29/how-to-create-fully-encapsulated-domain-models/)

-   **Udi Dahan. Domain Events – Take 2**
    [*http://udidahan.com/2008/08/25/domain-events-take-2/*](http://udidahan.com/2008/08/25/domain-events-take-2/%20)

-   **Udi Dahan. Domain Events – Salvation**
    [*http://udidahan.com/2009/06/14/domain-events-salvation/*](http://udidahan.com/2009/06/14/domain-events-salvation/)

-   **Jan Kronquist. Don't publish Domain Events, return them!**
    [*https://blog.jayway.com/2013/06/20/dont-publish-domain-events-return-them/*](https://blog.jayway.com/2013/06/20/dont-publish-domain-events-return-them/)

-   **Cesar de la Torre. Domain Events vs. Integration Events in DDD and microservices architectures**
    [*https://blogs.msdn.microsoft.com/cesardelatorre/2017/02/07/domain-events-vs-integration-events-in-domain-driven-design-and-microservices-architectures/*](https://blogs.msdn.microsoft.com/cesardelatorre/2017/02/07/domain-events-vs-integration-events-in-domain-driven-design-and-microservices-architectures/)


>[!div class="step-by-step"]
[Previous] (domain-events-design-and-implementation.md)
[Next] (designing-the-infrastructure-persistence-layer.md)
