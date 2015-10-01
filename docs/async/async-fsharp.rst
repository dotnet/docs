Async Programming in F#
=======================
By `Phillip Carter`_

Async programming in F# can be accomplished through a language-level programming model designed to be easy to use and look just like any other F# code.

At the center of it all is ``Async<'a>``, a representation of a task performed in an asynchronous context, where ``'a`` is the type returned by the expression when the ``return`` keyword is used.  The code used to represent this is known as an async block: ``async { expression }``.

The key thing to understand here is that an async expression's type is ``Async<'a>``, which is merely a *specification* of work to be done in an async context.  It is not executed until you explicitly start it with one of the starting functions (such as ``Async.RunSynchronously``).  Although this is a different way of thinking about doing work, in practice it ends up being quite simple.

For example, say we wanted to download the HTML from microsoft.com without blocking the main thread.  One way to write it is like this:

.. code-block:: c#

	let fetchHtmlAsync url = async {
	    let uri = new System.Uri(url)
	    let webClient = new System.Net.WebClient()
	    let! html = webClient.AsyncDownloadString(uri)
	    return html
	}

	let html = "http://microsoft.com/" |> fetchHtmlAsync |> Async.RunSynchronously
	printfn "%s" html

And that's it!  Aside from the introduction of ``let!`` and ``return``, this is just normal F# code.

There are a few syntactical elements to know before you can move forward:

* The body of an async expression is wrapped in an ``async{ ... }`` block of code.
* ``let!`` binds the result of an async expression (which runs on another context).
* ``use!`` works just like let, but disposes the resource when it goes out of scope.
* ``do!`` will start an async workflow.  This is used for async jobs with no return value.
* ``return`` simply returns a result from an async expression.
* ``return!`` executes an async workflow and returns its return value as a result.

Normal ``let``, ``use``, and ``do`` keywords can be used alongside the async versions just as they would in a normal function.

How to start Async Code in F#
-----------------------------

As mentioned earlier, async code is really just a specification of work to be done in another context which needs to be explicitly started somewhere.  This can be accomplished a few different ways.

1. ``Async.RunSynchronously`` will start an async job on another thread and await its result.

.. code-block:: c#

	let myFuncion =
	    // Execution of myFunction will pause until fooAsync finishes
	    let result = Async.RunSynchronously (fooAsync x y)

	    // you actually have the result from fooAsync now!
	    printfn "%A" result

2. ``Async.Start`` will start an async job on another thread, and will **not** await its result.

.. code-block:: c#

	// TODO

3. ``Async.StartImmediate`` will start an async job on the **current** thread, and will **not** await its result.

.. code-block:: c#

	// TODO

There are other, less general ways to start an async workflow, which you can find <LINK HERE>.

How to Add Parallelism to Async Code
------------------------------------

Sometimes there is a need to perform multiple non-blocking asynchronous jobs in parallel, collect their results, and interpret them in some way.  ``Async.Parallel`` offers a way to do this without needing to use the Task Parallel Library (which would involve needing to coordinate ``Async<'a>`` and ``Task<T>`` types somehow).

The following example will use ``Async.Parallel`` to download the HTML from four popular sites in parallel, wait for those tasks to complete, and then print the HTML which was downloaded.

.. code-block:: c#

	let urlList = [
	    "http://www.microsoft.com/"
	    "http://www.google.com/"
	    "http://www.amazon.com/"
	    "http://www.facebook.com/" ]

	let fetchHtmlAsync url = async {
	    let uri = new System.Uri(url)
	    let webClient = new System.Net.WebClient()
	    let! html = webClient.AsyncDownloadString(uri)
	    return html
	}

	let htmlList = urlList
	               |> Seq.map fetchHtmlAsync // Build an Async<'a> for each site
	               |> Async.Parallel         // Partition each Async<'a> across different threads
	               |> Async.RunSynchronously // Run each Async<'a> and do a non-blocking wait

	// We now have the downloaded HTML for each site!
	for html in htmlList do
	    printfn "%s" html

Async Example
-------------

TODO - something more complex than above

.. code-block:: c#

	// TODO

Important Info and Advice
-------------------------

* Append "Async" to the end of any functions you'll consume

Although this is just a naming convention, it does make things like API discoverability easier.  Particularly if there are synchronous and asynchronous versions of the same routine, it's a good idea to explicitly state which is asynchronous via the name.

* Listen to the compiler!

F#'s compiler is very strict, making it nearly impossible to mix and match async and synchronous code in nasty ways.  Certain edge cases in truly bizarre code could technically compile and cause bad behavior ... but the compiler always generates a warning.  Sticking with idiomatic F# and listening to the compiler will make it all work seamlessly!

For the C#/VB Programmer Looking Into F#
----------------------------------------

This section assumes you're familiar with the async model in C#/VB.  If you are not, :doc:`async-csharp-vb` is a starting point.

There is a fundamental difference between the C#/VB async model and the F# async model.

When you call a function which returns a ``Task`` or ``Task<T>``, that job has already begun execution.  The handle returned represents an already-running asynchronous job.  In contrast, when you call an async function in F#, the ``Async<'a>`` returned represents a job which will be **generated** at some point.  Understanding this model is powerful, because it allows for asynchronous jobs in F# to be chained together easier, performed conditionally, and be started with a finer grain of control.

There are also quite a few similarities which are worth noting:

TODO THIS SECTION NEEDS A SLIGHT REWRITE

* ``Async.RunSymchronously`` is basically ``await`` when calling async code from a function.

* ``let!``, ``use!``, and ``do!`` are similar to ``await`, but are more specific and can only be called within an ``async { }`` block.

While it is not technically true that they operate the same way, in practice they are used to accomplish their goals in the same way.  F# gives some extra utility with ``use!``.

* Task-based approach to solving async problems.

Although F#'s model uses a completely different type to capture async workflows (``Async<T>`` compared with ``Task<T>``), the conceptual model differs little.

* Data-parallel programming.

``Async.Parallel`` corresponds to ``Task.WhenAll``.  Both methods create a workflow or task which runs multiple operations and does not complete until all sub-operations have completed.

Differences:

* Cancellation support is simple in F# and annoying in C#/VB.

Supporting cancellation of a task midway through its execution in C# requires checking the ``IsCancellationRequested`` property or calling ``ThrowIfCancellationRequested()`` on a ``CancellationToken`` object that's passed into the async method.  F# async workflows are naturally cancellable, requireing only a ``CancellationToken`` be passed into the invocation of ``Async.Start`` to support cancellation.

* Less "async everywhere", meaning async and non-async functions can be composed more easily.

``Async<T>`` is just a specification of work to be done.  This is in contrast with C#/VB, where ``Task<T>`` is an actual computation created and running in the background.  This results in a lot less pollution of ``async`` keywords everywhere.

* Nested ``let!`` is not allowed.

Unlike ``await``, which can be nested indefinitely, ``let!`` cannot and must have its result bound before using it inside of another ``let!`` expression.
