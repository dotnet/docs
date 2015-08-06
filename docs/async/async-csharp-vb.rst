Asynchronous Programming in C# and VB
=====================================
By `Phillip Carter`_

From a developer's perspective, the C#/VB async model is some nice syntax that hides complexity and allows you to focus on writing methods without worrying about things like thread pools and callbacks.

The core of this are the ``async`` and ``await`` keywords (``Async`` and ``Await`` in VB.NET), which you sprinkle over otherwise normal methods. 

A few important things to know before continuing:

* ``Task<T>`` and ``Task`` are used a lot in async code.  These are abstractions that can be thought of as "something that needs to get done and could be long-running".
* Marking a method as ``async`` tells the compiler that you're expecting to ``await`` some blocking task.
* ``await`` can only be used inside an async method.
* When the ``await`` keyword is applied, it suspends the async method and returns control back to its caller until the awaited task is complete.  This is what makes it responsive.
* Unless an async method has an ``await`` inside its body, it will run synchronously, defeating the whole point of making it async!
* Return types are either ``Task<T>`` or ``Task``, with the exception of event handlers (these are ``void``).  More on this later.

Simple Async Example (C#)
-------------------------

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
	    var directions = await _locationService.GetDirectionsAsync(startPos, endPos);
	    
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
	
Simple Async Example (VB)
-------------------------

These are the VB-equivalent code snippets from above.

Client app snippet:

.. code-block:: vb.net

	Private Async Sub GetDirectionsForPickup_Pressed(sender As Object, e As CustomUserDataEventArgs) Handles GetDirectionsForPickup.Click
		
		Dim b As BasicUserData = e.Source
		
		' _directionsClient is a made-up object that would encapsulate certain complexity,
		' such as getting the location from the device.
		Dim getDirectionsTask As Task(Of String) = _directionsClient.GetDrivingDirectionsToLocation(user.LastKnownLocation)
		
		' This independent work can be done concurrently
		' since it doesn't rely on directions!
		NotifyUserOfPickupAsync(b, this.DriverInfo)
		
		Dim directionsJson As String = Await getDirectionsTask
		
		' Using the JSON.NET library to deserialize data
		Dim d As DirectionsData = JsonConvert.DeserializeObject(Of DirectionsData)(directionsJson)
		
		DrawRouteOnMap(d.Polyline)		
	End Sub

Web Service snippet:

.. code-block:: vb.net

	<HttpGet>
	Public Async Function GetDirections(startPos as GeoPoint, endPos as GeoPoint) As Task(Of String)

		' Suspends GetUser() to allow the caller (the web service) to accept another request,
		' rather than blocking on this one.
		Dim dirs As Directions = Await _locationService.GetDirectionsAsync(startPos, endPost);
		
		Dim json As String = JsonConvert.SerializeObject(dirs);
		
		Return json
	End Function

Important Info and Advice
-------------------------

Although async programming is relatively straightfoward, there are some details to keep in mind which could otherwise result in some nasty behavior.

* Do yourself a favor and append "Async" to the end of every async method you write which could be consumed by another method.

Yes, it's sort of hungarian notation which is so widely hated, but being extra explicit is a lot better than tracking down a race condition.  Note that certain methods which aren't explicity called by you code (such as event handlers or web controller methods) may not necessarily apply.

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
``await Task.Delay``   ``Thread.Sleep``                  Waiting for a period of time
====================== ================================= =======================


More Information
----------------

Link to more info goes here.