Async Programming in F#
=======================
By `Phillip Carter`_ and hopefully David Stephens!

Async programming in F# is accomplished via `computation expressions`_, a convenient monad syntax to allow for sequenced computations.  While the details can get a bit hairy, the end result is a rather nice syntax known as an "async block".

.. _`computation expressions`: https://msdn.microsoft.com/en-us/library/dd233182.aspx

Syntactical Elements to know:

* The body of an async function is wrapped in an ``asyc{ ... }`` block of code.
* ``let!`` starts an async operation and binds its resultant value.
* ``use!`` starts an async operation with a return value and disposes the returned object when the scope of the async workflow completes.
* ``do!`` starts an async operation that doesn't return a value.
* Normal ``let``, ``use``, and ``do`` keywords can be used alongside the new ones just as they would in a normal function.

And that's it!

Simple Async Example:
---------------------

The following is a somewhat "real-world" example: a basic WebApi controller for a ridesharing web service.

.. code-block:: f#

	[<RoutePrefix("directions")>]
	type DirectionsController() = 
		inherit ApiController()

		let getDirectionsAsync(user:UserData, driver:DriverData) = async {			
			let! drivingDirections = GetDrivingDirectionsAsync user.Location driver.Location
			return JsonConvert.SerializeObject(drivingDirections)
		}
		
		[<Route("getandnotify/{userId:int, driverId:int}")>]
		member x.Get(userId:int, driverId:int) = async {
		
			// This suspends x.Get(userId, driverId) and passes control back to
			// DirectionsController()!  Once the user object is ready, control is passed back
			// to x.Get(userId, driverId) and the user object is bound.
			let! user = GetUserAsync userId
			
			// This does the NotifyUserOfPickup workflow without ceding control to it.
			// x.Get(userId, driverId) can continue executing!
			do! NotifyUserOfPickupAsync userId
			
			let! driver = GetDriverAsync driverId
			
			// Note that here the compiler couldn't infer the type, so we had to "force" it to
			// treat getDirectionsAsync as a function.
			let! directions = getDirectionsAsync(user, driver)
			
			return directions
		}
		
For the C#/VB Programmer Looking Into F#
----------------------------------------

This section assumes you're familiar with the async model in C#/VB.  If you are not, :doc:`async-csharp-vb` is a starting point.

Similarities:

* ``let!``, ``use!``, and ``do!`` work pretty much the same way as ``await``.

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
		
Important Info and Advice
-------------------------

* Append "Async" to the end of any functions you'll consume

It's easier to deal with async functions when their name states if they're async or not.

* Listen to the compiler!

F#'s compiler is very strict, making it nearly impossible to mix and match async and synchronous code in nasty ways.  Certain edge cases in truly bizarre code could technically compile and cause bad behavior ... but the compiler always generates a warning.  Sticking with idiomatic F# and listening to the compiler will make it all work seamlessly!