Async Programming in F#
=======================
By `Phillip Carter`_

Async programming in F# can be accomplished through a language-level programming model designed to be easy to use and look just like any other F# code.

At the center of it all is ``Async<'a>``, a representation of a task performed in an asynchronous context, where ``'a`` is the type returned by the expression when the ``return`` keyword is used.  The code used to represent this is known as an async block: ``async { expression }``.

The key thing to understand here is that an async expression's type is ``Async<'a>``, which is merely a *specification* of work to be done in an asynchronous context.  It is not executed until you explicitly start it with one of the starting functions (such as ``Async.RunSynchronously``).  Although this is a different way of thinking about doing work, in practice it ends up being quite simple.

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

And that's it!  Aside from the introduction of ``async``, ``let!``, and ``return``, this is just normal F# code.

There are a few syntactical elements to know before you can move forward:

* The body of an async expression is wrapped in an ``async{ ... }`` block of code.
* ``let!`` binds the result of an async expression (which runs on another context).
* ``use!`` works just like let, but disposes the resource when it goes out of scope.
* ``do!`` will await an async workflow which doesn't return anything.
* ``return`` simply returns a result from an async expression.
* ``return!`` executes an async workflow and returns its return value as a result.

Normal ``let``, ``use``, and ``do`` keywords can be used alongside the async versions just as they would in a normal function.

How to start Async Code in F#
-----------------------------

As mentioned earlier, async code is really just a specification of work to be done in another context which needs to be explicitly started somewhere.  These are two primary was to accomplish this:

1. ``Async.RunSynchronously`` will start an async job on another thread and await its result.

.. code-block:: c#

	let myFunction =
	    // Execution of myFunction will pause until fooAsync finishes
	    let result = Async.RunSynchronously (fooAsync x y)

	    // you actually have the result from fooAsync now!
	    printfn "%A" result

2. ``Async.Start`` will start an async job on another thread, and will **not** await its result.

.. code-block:: c#

	let myFunction =
	    // Exeuction of myFunction will continue after calling this
	    Async.Run (barAsync x)

	    printfn "%s" "barAsync is running in the background..."

There are other, less general ways to start an async workflow also available.  They are detailed `in the MSDN reference docs <https://msdn.microsoft.com/en-us/library/ee370232.aspx>`_.

A Note on Threads
^^^^^^^^^^^^^^^^^

The phrase "on another thread" is mentioned above, but it is important to know that **this does not mean that async workflows are run on a newly spun-up thread**.  The workflow actually "jumps" between threads, borrowing them for a small amount of time to do useful work.  When an async workflow is effectively "waiting" (e.g. waiting for a network call to return something), any thread it was borrowing at the time is freed up to go do useful work on something else.  This allows async workflows to utilize the system as effectively as possible, and makes them especially strong for performing significant amounts of I/O.

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

Larger Example
-------------

TODO - something more complex than above

.. code-block:: c#

	// TODO

Important Info and Advice
-------------------------

* Append "Async" to the end of any functions you'll consume

Although this is just a naming convention, it does make things like API discoverability easier.  Particularly if there are synchronous and asynchronous versions of the same routine, it's a good idea to explicitly state which is asynchronous via the name.

* Listen to the compiler!

F#'s compiler is very strict, making it nearly impossible to do something troubling like run "async" code synchronously.  If you come across a warning, that's a sign that the code won't execute how you think it will.  If you can make the compiler happy, your code will mostly likely execute as expected.

For the C#/VB Programmer Looking Into F#
----------------------------------------

This section assumes you're familiar with the async model in C#/VB.  If you are not, :doc:`async-csharp-vb` is a starting point.

There is a fundamental difference between the C#/VB async model and the F# async model.

When you call a function which returns a ``Task`` or ``Task<T>``, that job has already begun execution.  The handle returned represents an already-running asynchronous job.  In contrast, when you call an async function in F#, the ``Async<'a>`` returned represents a job which will be **generated** at some point.  Understanding this model is powerful, because it allows for asynchronous jobs in F# to be chained together easier, performed conditionally, and be started with a finer grain of control.

There are also quite a few similarities and differences worth noting.

Similarities
^^^^^^^^^^^^

* ``Async.RunSymchronously`` is analogous to ``await`` when calling async code from a function.

Although it operates very differently from ``await``, conceptually ``Async.RunSynchronously`` accomplishes a similar goal: waiting for an asynchronous job to finish and collecting its result (after starting that job).

* ``let!``, ``use!``, and ``do!`` are analogous to ``await`` when calling an async job from within an ``async{ }`` block.

The three keywords can only be used within an ``async { }`` block, similar to how ``await`` can only be invoked inside an ``async`` method.  In short, ``let!`` is for when you want to capture and use a result, ``use!`` is the same but for something whose resources should get cleaned after it's used, and ``do!`` is for when you want to wait for an async workflow with no return value to finish before moving on.

* For the purposes of representing async work, F#'s model doesn't differ much conceptually.

Although F#'s model doesn't use a ``Task`` or ``Task<T>``, conceptually its type, ``Async<'a>``, is similar in that it models work being done in an asynchronous context.  The main difference is ``Async<'a>`` is a job which is ready to be started, whereas ``Task`` and ``Task<T>`` are jobs which are already happening.

* F# supports data-parallelism in a similar way.

``Async.Parallel`` corresponds to ``Task.WhenAll`` for the scenario of wanting the results of a set of async jobs when they all complete.

Differences
^^^^^^^^^^^

* Cancellation support is simpler in F# than in C#/VB.

Supporting cancellation of a task midway through its execution in C#/VB requires checking the ``IsCancellationRequested`` property or calling ``ThrowIfCancellationRequested()`` on a ``CancellationToken`` object that's passed into the async method.

In contrast, F# async workflows are naturally cancellable.  Cancellation is a simple three-step process.

1. Create a new ``CancellationTokenSource``.
2. Pass it into a starting function.
3. Call ``Cancel`` on the token.

Example:

.. code-block:: c#

	let token = new CancellationTokenSource()
	Async.Start (barAsync x, token)

	// Immediately cancel barAsync after it's been started.
	token.Cancel()

And that's it!

* Nested ``let!`` is not allowed.

Unlike ``await``, which can be nested indefinitely, ``let!`` cannot and must have its result bound before using it inside of a ``let!``, ``do!``, or ``use!``.

Further resources:
------------------

* `Async Workflows on MSDN <https://msdn.microsoft.com/en-us/library/dd233250.aspx>`_
* `Asynchronous Sequences for F# <http://fsprojects.github.io/FSharp.Control.AsyncSeq/library/AsyncSeq.html>`_
* `F# Data HTTP Utilities <https://fsharp.github.io/FSharp.Data/library/Http.html>`_
