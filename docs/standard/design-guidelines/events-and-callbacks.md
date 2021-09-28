---
description: "Learn more about: Events and Callbacks"
title: "Events and Callbacks"
ms.date: "10/22/2008"
helpviewer_keywords:
  - "events [.NET Framework], extensibility"
  - "methods [.NET Framework], callback"
  - "callback methods"
  - "callbacks"
ms.assetid: 48b55c60-495f-4089-9396-97f9122bba7c
---
# Events and Callbacks

Callbacks are extensibility points that allow a framework to call back into user code through a delegate. These delegates are usually passed to the framework through a parameter of a method.

 Events are a special case of callbacks that supports convenient and consistent syntax for supplying the delegate (an event handler). In addition, Visual Studio's statement completion and designers provide help in using event-based APIs. (See [Event Design](event.md).)

 ✔️ CONSIDER using callbacks to allow users to provide custom code to be executed by the framework.

 ✔️ CONSIDER using events to allow users to customize the behavior of a framework without the need for understanding object-oriented design.

 ✔️ DO prefer events over plain callbacks, because they are more familiar to a broader range of developers and are integrated with Visual Studio statement completion.

 ❌ AVOID using callbacks in performance-sensitive APIs.

 ✔️ DO use the new `Func<...>`, `Action<...>`, or `Expression<...>` types instead of custom delegates, when defining APIs with callbacks.

 `Func<...>` and `Action<...>` represent generic delegates. `Expression<...>` represents function definitions that can be compiled and subsequently invoked at runtime but can also be serialized and passed to remote processes.

 ✔️ DO measure and understand performance implications of using `Expression<...>`, instead of using `Func<...>` and `Action<...>` delegates.

 `Expression<...>` types are in most cases logically equivalent to `Func<...>` and `Action<...>` delegates. The main difference between them is that the delegates are intended to be used in local process scenarios; expressions are intended for cases where it's beneficial and possible to evaluate the expression in a remote process or machine.

 ✔️ DO understand that by calling a delegate, you are executing arbitrary code and that could have security, correctness, and compatibility repercussions.

 *Portions &copy; 2005, 2009 Microsoft Corporation. All rights reserved.*

 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*

## See also

- [Designing for Extensibility](designing-for-extensibility.md)
- [Framework Design Guidelines](index.md)
