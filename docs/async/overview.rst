Async Overview
==============

Modern apps and services are expected to be responsive.

* Client applications are expected to be always-on, always-connected, but keep the UI free for the user to interact with.
* Services are expected to be able gracefully handle a heavy load.

.NET provides the capability for apps and services to be responsive with easy-to-use, language-level asynchronous programming models in C#/VB and F#.  Although similar, the nuances of async programming in F# differs from that in C# and VB.

Why Async?
----------

Here are a few reasons:

* Responsiveness in apps and services is expected by users, and even slight UX hangups are often punished harshly (one-star reviews).
* Almost all modern apps demand elements which block on I/O in some way.
* Modern web services must be able to handle a high load with the number of devices potentially connecting to them.
* Many of the newer, better .NET APIs are themselves asynchronous in nature.
* It's super easy to write async methods!

Especially in the case of F#, a functional-first language designed to solve problems at scale, asynchronous programming is a necessity for responsive services under a heavy load.

What's next?
----------

Pick your language to learn how to do it:

* C# or VB ---> link to next page
* F# ---> link to next next page