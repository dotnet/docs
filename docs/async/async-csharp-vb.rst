Async Programming in C#/VB
==========================
By `Phillip Carter`_

From a developer's perspective, the C#/VB async model is some nice syntax that hides complexity and allows you to focus on writing methods without worrying about things like thread pools and callbacks.

The core of this are the ``async`` and ``await`` keywords (``Async`` and ``Await`` in VB.NET), which you sprinkle over otherwise normal methods. 

A few important things to know before continuing:

* ``Task<T>`` and ``Task`` are used to represent the return types for async code.  These are abstractions that can be thought of as "something that needs to get done and could be long-running".  `More on Task and Task<T>`_.
* Marking a method as ``async`` tells the compiler that you're expecting to ``await`` some blocking task.
* ``await`` can only be used inside an async method.
* When the ``await`` keyword is applied, it suspends the async method and returns control back to its caller until the awaited task is complete.  This is what makes it responsive.
* Unless an async method has an ``await`` inside its body, it will run synchronously!
* Return types for async methods should always be either ``Task<T>`` or ``Task``, with the exception of event handlers (these are ``void``).  More on this later.

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
	    NotifyUserOfPickupAsync(basicUserData.Contact);
	    
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
		NotifyUserOfPickupAsync(b.ContactInfo)
		
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
	
More on Task and Task<T>
------------------------

As mentioned before, Tasks are constructs which represent blocking operations.

* ``Task`` represents a single asynchronous operation which does not return a value.
* ``Task<T>`` represents a single asynchronous operation which returns a value of type ``T``.

It's important to reason about Tasks as abstractions of work to be done rather than threads, largely because they typically aren't threads at all!  Asynchronous .NET library calls essentially delegate work to the operating system, which is naturally asynchronous when I/O is performed.  Let this be made clear once more: when calling an async .NET library method, there is no thread spawned to handle the work.  If you haven't read about THIS ARTICLE WHICH IS TO BE WRITTEN, it is encouraged to fully understand the relationship being task-based asynchronous programming and the system your code runs on.

Tasks are awaitable, meaning that the application of the ``await`` keyword will allow for either:

* "Unwrapping" the return value for a ``Task<T>`` operation after it completes.
* Simply waiting for a ``Task`` operation to finish before moving forward.

The above code samples demonstrate this.

Tasks are also used outside of the async programming model.  They are the foundation of the Task Parallel Library, which allows support for `Data Parallelism <https://msdn.microsoft.com/en-us/library/dd537608(v=vs.110).aspx>`_ and `Task Parallelism <https://msdn.microsoft.com/en-us/library/dd537609(v=vs.110).aspx>`_.  However, from the perspective of writing responsive code with the C#/VB async programming model, ``Task`` and ``Task<T>`` are really just used as a means to an end: coordinating blocking operations and extracting their return values (if they have them), to allow applications to scale up seamlessly.

Important Info and Advice
-------------------------

Although async programming is relatively straightfoward, there are some details to keep in mind which could otherwise result in some nasty behavior.

* Best practice is to add "Async" to the end of every async method you write which could be consumed by another method.

Failure to do so could result in having to track down a race condition later.  It's better to be explicit here!  Note that certain methods which aren't explicity called by your code (such as event handlers or web controller methods) may not necessarily apply.

* ``await`` is what will ultimately make a method asynchronous.

Failing to apply the ``await`` operator to a task will result in the async method running synchronously!  Application of ``await`` is what suspends the async method, giving back control to the method which called it.  Pay attention to compiler warnings about this.

* ``async void`` should only be used for event handlers.

Why?  That's the only reason they were allowed in the first place!  Async programming uses the ``Task`` and ``Task<T>`` objects, which provide flexibility in dealing with any asynchronous work that needs to be done.  Throwing that out of the window with ``async void`` doesn't follow the model very well.  Here's some specific issues:

    (a) Exceptions thrown in an ``async void`` method can't be caught.
	
    (b) ``async void`` methods are very difficult to test.
	
    (c) ``async void`` methods can cause bad side effects if the caller isn't expecting them to be async.
	
That said, ``async void`` is perfect for event handlers where the event involves any blocking task(s).

* Avoid async lambdas + LINQ when combined with other async code

Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you're not expecting it to.  The introduction of blocking tasks into this can easily result in a deadlock.  When in doubt, don't mix LINQ and async methods inside the lambda expression.

* Try to write code that "naturally" awaits blocking results

Although it is certainly easier to call other async code from an async method, not doing so correctly can result in deadlocks, blocked context threads, and significantly more complex error-handling.  The following table should provide some guidance in how to deal with blocking code from an async context:

====================== ================================= =======================
Use this...            Instead of this...                When wishing to do this
====================== ================================= =======================
``await``              ``Task.Wait`` or ``Task.Result``  Retreiving the result of a background task
``await Task.WhenAny`` ``Task.WaitAny``                  Waiting for any task to complete
``await Task.WhenAll`` ``Task.WaitAll``                  Retreiving the results of multiple tasks
``await Task.Delay``   ``Thread.Sleep``                  Waiting for a period of time
====================== ================================= =======================

The good news is that calling async code which has no return value has no caveats.  ``JustDoesAJobAsync()`` does not need to be coordinated unless the calling method depends on its execution.  However, this would warrant a refactor, bringing up the final point...

* Write less stateful code

Depend less on the state of objects and the exeuction of certain methods when writing async code.  Instead, depend on the return values of methods.  Why?

	(a) Easier to reason about
	(b) Easier to test
	(c) Mixing async and synchronous code is far simpler
	(d) Race conditions can typically be avoided altogether
	(e) Depending on return values makes coordinating async code simple
	
Although C# and VB are object-oriented languages, try to think more with a functional mindset and less with an object-oriented mindset when writing async code.

More Information
----------------
* `Async/Await Reference Docs <https://msdn.microsoft.com/en-us/library/hh191443.aspx>`_
* `Tasks and the Task Parallel Library <https://msdn.microsoft.com/en-us/library/dd460717(v=vs.110).aspx>`_