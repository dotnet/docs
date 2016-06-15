# Async Overview

Modern apps are expected to be responsive and modern services are expected to be elastic:

*   Client applications are expected to be always-on and always-connected, but also keep the UI free for the user to interact with.
*   Services are expected to handle spikes in traffic by gracefully scaling up and down.

.NET provides the capability for apps and services to be responsive and elastic with easy-to-use, language-level asynchronous programming models in C#, VB, and F#.

## Why Write Async Code?

If you are developing a system which blocks on I/O in some way, you should be writing async code. If that doesn’t convince you, here are a few more reasons:

*   Almost all modern apps demand elements which block on I/O in some way. Because of this, responsive apps are expected by users, and even slight UX hangups are often punished harshly (via one-star reviews).
*   Modern web services must be able to handle a high load with the number of devices potentially connecting to them. Async programming allows scaling up so that sudden spikes in traffic don’t bring a system to its knees.
*   Many of the newer, better .NET APIs are themselves asynchronous in nature.
*   It’s super easy to write async code in .NET!

Especially in the case of F#, a functional-first language designed to solve problems at scale, asynchronous programming is a necessity for elastic services under a heavy load.

## What’s next?

Pick your language to learn about it:

*   [Async Programming in C#/VB](async-csharp-vb.md)
*   [Async Programming in F#](async-fsharp.md)