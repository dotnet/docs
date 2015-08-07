Async Programming in F#
==============================

Async programming in F# is accomplished via computation expressions(LINK), a convenient monad syntax to allow for sequenced computations.  While the details can get a bit hairy, the end result is a rather nice syntax known as an "async block".

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

		let sendDirectionsToDriver(user:UserData, driver:DriverData) = async {			
			let! drivingDirections = GetDrivingDirectionsAsync user.Location driver.Location
			JsonConvert.SerializeObject(drivingDirections)
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
			
			sendDirectionsToDriver user driver
		}
		
For the C# Programmer Looking Into F#
-------------------------------------

If you're a C# programmer and aren't familiar with async C# programming, it's worth taking a look at [the C#/VB async programming model](LINK) before reading this.

Similarities:

* ``let!``, ``use!``, and ``do!`` work pretty much the same way as ``await``

While it is not technically true that they operate the same way, in practice they are used to accomplish their goals in the same way.  F# gives some extra utility with ``use!``.

* Task-based approach to solving async problems

Although F#'s model uses a completely different type to capture async workflows (``Async<T>`` compared with ``Task<T>``), the conceptual model differs little.

* Data-parallel programming

``Async.Parallel`` corresponds to ``Task.WhenAll``.  Both methods create a workflow or task which runs multiple operations and does not complete until all sub-operations have completed.

Differences:

* Cancellation support is simple in F# and annoying in C#

Supporting cancellation of a task midway through its execution in C# requires checking the ``IsCancellationRequested`` property or calling ``ThrowIfCancellationRequested()`` on a ``CancellationToken`` object that's passed into the async method.  F# async workflows are naturally cancellable, requireing only a ``CancellationToken`` be passed into the invocation of ``Async.Start`` to support cancellation.

* Less "async everywhere" and better composability

Because ``Async<T>`` is just a specification of work to be done, it allows for async methods to be more easily-composed.  This results in a lot less pollution of ``async`` keywords everywhere.

* Nested ``let!`` is not allowed

Unlike ``await``, which can be nested indefinitely, ``let!`` cannot and must have its result bound before using it inside of another ``let!`` expression.

TODO: MORE DIFFERENCES ON THE WAY
		
Important Info and Advice
-------------------------

* Append "Async" to the end of any functions you'll consume

It's easier to deal with async functions when their name states if they're async or not.

* Listen to the compiler!

F#'s compiler is very strict, making it nearly impossible to mix and match async and synchronous code in nasty ways.  Certain edge cases in truly bizarre code could technically compile and cause bad behavior ... but the compiler always generates a warning.  Sticking with idiomatic F# and listening to the compiler will make it all work seamlessly!