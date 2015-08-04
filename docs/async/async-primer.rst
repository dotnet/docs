Asynchronous Programming in .NET
================================
By Phillip Carter

Modern apps and services are expected to be responsive.

* Client applications are expected to be always-on, always-connected, but keep the UI free for the user to interact with.
* Services are expected to be able to still serve data immediately while under a heavy load.

.NET provides the capability for apps and services to be responsive with an easy-to-use, language-level asynchronous programming model.

What is it?
-----------

From the developer's perspective, the async model is some nice syntax that hides complexity and allows you to focus on functionality.

The core of this model of programming is the ``async`` and ``await`` keywords (``Async`` and ``Await`` in VB.NET), which a you sprinkle over otherwise normal methods.

A few important things to know before continuing:

* ``Task<T>`` and ``Task`` are used a lot in async code.  These are abstractions that can be thought of as "something that needs to get done and not on the main thread".
* Marking a method as ``async`` tells the compiler that you're expecting to ``await`` some blocking task.
* When the ``await`` keyword is applied, it suspends the async method and returns control back to its caller until the awaited task is complete.  This is what makes it responsive.
* Unless an async method has an ``await`` inside its body, it will run synchronously, defating the whole point of making it async!
* Return types are either ``Task<T>`` or ``Task``, with the exception of event handlers (these are void).  More on this later.
* ``await`` can only be used inside an async method.  Be wary of "polluting" your app with async method everywhere!  More on this later.

Why Async?
----------

Here are a few reasons:

* Responsiveness in apps and services is expected by users, and punished harshly (one-star reviews) for even slight UX hangups
* Almost all modern apps demand elements which block on I/O in some way
* Modern web services must be able to handle a high load
* It's super easy to write async methods
* Many of the newer, better .NET APIs are themselves asynchronous in nature

In other words, asynchronousity is expected from users, it's easy to write asynchronous code with .NET, and interacting with modern .NET APIs will require it anyways.

Simple Async Example
--------------------

The following example shows somewhat of a "real life" scenario: getting directions to a user for a ridesharing app.

client-app snippet

.. code-block:: c#

	private async void GetDirectionsForPickup_Pressed(object sender, RoutedEventArgs e)
	{
	    var basicUserData = e.Source as BasicUserData;

	    var getDirectionsTask = _directionsClient.GetDrivingDirectionsToLocation(user.LastKnownLocation);
		
	    // This independent work can be done concurrently
		// since it doesn't rely on directions!
	    NotifyUserOfPickup(basicUserData, this.DriverInfo);
	    
	    // The await operator suspends SelectUserForPickup_Pressed, return control to its caller.
		// This is what allows the app to be responsive and not hang on the UI thread.
	    var directionsJson = await getDirectionsTask;
		
	    // Using the JSON.NET library to deserialize data
	    var directionsData = JsonConvert.DeserializeObject<DirectionsData>(directionsJson);
	    		    
	    DrawRouteOnMap(directionsData.Polyline);
	}

web-service snippet

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
	
What Happens in an Async Method
-------------------------------

DIAGRAM.jpg

Explanation of what's going on here, using the sample from above.

Rules and Guidelines
--------------------

STUFF


Important Details
-----------------

IMPORTANT STUFF HERE LIKE YOU CAN TECHNICALLY WRITE SYNCHRONOUS METHODS WITH ASYNC