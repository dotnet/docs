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
		
For C# Programmer Looking Into F#
-----------------------------------

If you're a C# programmer and aren't familiar with async C# programming, it's worth taking a look at [the C#/VB async programming model](LINK).

TODO

Similarities:

* the thing
* the other thing

Differences:

* that one thing
* that other one thing
* this one too

			
Important Info and Advice
-------------------------

* Append "Async" to the end of any functions you'll consume

It's easier to deal with async functions when their name states if they're async or not.

* Listen to the compiler!

F#'s compiler is very strict, making it nearly impossible to mix and match async and synchronous code in nasty ways.  Certain edge cases in truly bizarre code could technically compile and cause bad behavior ... but the compiler always generates a warning.  Sticking with idiomatic F# and listening to the compiler will make it all work seamlessly!