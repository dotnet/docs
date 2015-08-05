Asynchronous Programming in .NET
================================
By `Phillip Carter`_

Modern apps and services are expected to be responsive.

* Client applications are expected to be always-on, always-connected, but keep the UI free for the user to interact with.
* Services are expected to be able to still serve data immediately while under a heavy load.

.NET provides the capability for apps and services to be responsive with an easy-to-use, language-level asynchronous programming model.

What is it?
-----------

From the developer's perspective, the async model is some nice syntax that hides complexity and allows you to focus on functionality.

The core of this model of programming is the ``async`` and ``await`` keywords (``Async`` and ``Await`` in VB.NET), which you sprinkle over otherwise normal methods.

A few important things to know before continuing:

* ``Task<T>`` and ``Task`` are used a lot in async code.  These are abstractions that can be thought of as "something that needs to get done and not on the main thread".
* Marking a method as ``async`` tells the compiler that you're expecting to ``await`` some blocking task.
* ``await`` can only be used inside an async method.
* When the ``await`` keyword is applied, it suspends the async method and returns control back to its caller until the awaited task is complete.  This is what makes it responsive.
* Unless an async method has an ``await`` inside its body, it will run synchronously, defeating the whole point of making it async!
* Return types are either ``Task<T>`` or ``Task``, with the exception of event handlers (these are ``void``).  More on this later.

Why Async?
----------

Here are a few reasons:

* Responsiveness in apps and services is expected by users, and even slight UX hangups are often punished harshly (one-star reviews).
* Almost all modern apps demand elements which block on I/O in some way.
* Modern web services must be able to handle a high load with the number of devices potentially connecting to them.
* Many of the newer, better .NET APIs are themselves asynchronous in nature.
* It's super easy to write async methods!

In other words, good asynchronousity is expected from users, it's easy to write asynchronous code with .NET, and interacting with modern .NET APIs will require it anyways.

Simple Async Example
--------------------

The following example shows somewhat of a "real life" scenario: getting directions to a user for a ridesharing app.

Client app snippet:

.. code-block:: c#

	private async void GetDirectionsForPickup_Pressed(object sender, CustomUserDataEventArgs e)
	{
	    var basicUserData = e.Source as BasicUserData;

	    // _directionsClient is a made-up object that would encapsulate certain complexity,
	    // such as getting the location from the device.
	    var getDirectionsTask = _directionsClient.GetDrivingDirectionsToLocation(user.LastKnownLocation);
		
	    // This independent work can be done concurrently
	    // since it doesn't rely on directions!
	    NotifyUserOfPickupAsync(basicUserData, this.DriverInfo);
	    
	    // The await operator suspends SelectUserForPickup_Pressed, returning control to its caller.
	    // This is what allows the app to be responsive and not hang on the UI thread.
	    var directionsJson = await getDirectionsTask;
		
	    // Using the JSON.NET library to deserialize data
	    var directionsData = JsonConvert.DeserializeObject<DirectionsData>(directionsJson);
	    		    
	    DrawRouteOnMap(directionsData.Polyline);
	}

Web service snippet:

.. code-block:: c#

	[HttpGet]
	public async Task<string> GetDirections(GeoPoint startPos, GeoPoint endPos)
	{
	    // Suspends GetUser() to allow the caller (the web service) to accept another request,
	    // rather than blocking on this one.
	    var directions = await _locationService.GetDirections(startPos, endPos);
	    
	    // Using the JSON.NET library to serialize data
	    var json = JsonConvert.SerializeObject(directions);
	    
	    return json;
	}
	
Bonus snippet: writing an inline event handler in Xamarin for an android game!

.. code-block:: c#

	fireball.DamageDone += async =>
	{
	   var result = await DoFireballDamageCalculation();
	   ShowDamageOnScreen(result);
	};
	
What Happens in an Async Method
-------------------------------

TODO:

DIAGRAM.jpg

Explanation of what's going on here, using the sample from above.

Important Info and Advice
-------------------------

Although async programming is relatively straightfoward, there are some details to keep in mind which could otherwise result in some nasty behavior.

* ``await`` is what will ultimately make a method asynchronous.

Failing to apply the ``await`` operator to a task will result in the async method running synchronously!  Application of ``await`` is what suspends the async method, giving back control to the method which called it.  Pay attention to compiler warnings about this.

* ``async void`` should only be used for event handlers.

Why?  That's the only reason they were allowed in the first place.  Async programming revolved around the ``Task`` and ``Task<T>`` objects, which provide flexibility in dealing with any asynchronous work that needs to be done.  Throwing that out of the window with ``async void`` doesn't follow the model very well.  Here's some specific issues:

    (a) Exceptions thrown in an ``async void`` method can't be caught.
	
    (b) ``async void`` methods are very difficult to test.
	
    (c) ``async void`` methods can cause bad side effects if the caller isn't expecting them to be async.
	
That being said, ``async void`` is perfect for event handlers, such as the pressing of a button.  If an event involves any blocking tasks, async is a perfect candidate.

* Avoid async lambda expressions when combined with other async code

Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you're not expecting it to.  The introduction of blocking tasks into this can easily result in a deadlock.  It's far better to have clear, deterministic code rather than clever asynchronous lambda expressions which may or may not execute when you expect them to.

* Try to write code that is naturally "Async all the way"

As you may notice when working with ``async`` and ``await``, it's far easier to call async code from other async code.  Conversely, getting async methods involved with synchronous code can turn into a mess.  Mixing async and blocking code can result in deadlocks, blocked context threads, and significantly more complex error-handling.  The following table should provide some guidance.

====================== ================================= =======================
Use this...            Instead of this...                When wishing to do this
====================== ================================= =======================
``await``              ``Task.Wait`` or ``Task.Result``  Retreiving the result of a background task
``await Task.WhenAny`` ``Task.WaitAny``                  Waiting for any task to complete
``await Task.WhenAll`` ``Task.WaitAll``                  Retreiving the results of multiple tasks
``await Task.Delay``   ``Thread.Sleep``                  Wait a period of time
====================== ================================= =======================


More Information
----------------

Link to more info goes here.