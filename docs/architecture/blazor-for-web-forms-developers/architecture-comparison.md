---
title: Architecture comparison of ASP.NET Web Forms and Blazor
description: An architectural comparison of ASP.NET Web Forms and Blazor.
author: danroth27
ms.author: daroth
ms.date: 09/11/2019
---

# Architecture comparison of ASP.NET Web Forms and Blazor

While ASP.NET Web Forms and Blazor have many similar concepts, they also have difference in how they work. Here we will take a look at the underlying workings and architecture of ASP.NET Web Forms and Blazor to see how they compare.

## ASP.NET Web Forms

TODO

## Blazor

Blazor is client-side web UI framework similar in nature to JavaScript frontend frameworks like Angular or React. The Blazor framework deals with handling of user interactions and rendering UI updates accordingly. Blazor is *not* based on a request-reply model. User interactions are handled as events that are not in the context of any particular HTTP request.

Blazor apps consist of one or more root components that are rendered on an HTML page.

![Blazor components in HTML](./media/architecture-comparison/blazor-components-in-html.png)

How the user specifies where components should render and how the components are then wired up for user interactions is [hosting model](./hosting-models) specific.

Blazor [components](./components) are .NET classes that represent a reusable piece of UI. Each component maintains its own state and specifies its own rendering logic, which can include rendering other components. Components specify event handlers for specific user interactions to update the component's state.

After a component handles an event, Blazor renders the component and keeps track of what changed in the rendered output. Components don't render directly to the DOM. They instead render to an in-memory representation of the DOM called a `RenderTree` so that Blazor can track the changes. Blazor compares the newly rendered output with the previous output to calculate a UI diff that it then applies efficiently to the DOM.

![Blazor DOM interaction](./media/architecture-comparison/blazor-dom-interaction.png)

Components can also manually indicate that they should be rendered if their state changes outside of a normal UI event.Blazor uses a `SynchronizationContext` to enforce a single logical thread of execution. A component's lifecycle methods and any event callbacks that are raised by Blazor are executed on this `SynchronizationContext`.
