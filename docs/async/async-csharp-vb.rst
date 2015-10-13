Async Programming in C#/VB
==========================
By `Phillip Carter`_

Async programming in C# and VB share a language-level asynchronous programming model which allows for easily writing asynchronous code without having to juggle callbacks or conform to a library which supports asynchronicity.

The core of it all are the ``Task`` and ``Task<T>`` objects, which model asynchronous operations.  The async and await keywords provide a natural and synchronous developer experience for interacting with tasks.  The result is the ability to write powerful code which cleanly expresses intent.  There are other ways to approach this than ``async`` and ``await``, outlined in the `Task-based Asynchronous Pattern (TAP) <https://msdn.microsoft.com/en-us/library/hh873175(v=vs.110).aspx>`_, which presents Task-based asynchronocity with options other than the language-level abstractions.  This document will focus on the language-level constructs from this point forward.

For example, say you want to download some data from a web service when a button is pressed, but don't want to hang up the UI thread.  It can be accomplished simply like this:

.. code-block:: c#

	private readonly HttpClient _httpClient = new HttpClient();

	...

	button.Clicked += async (o, e) =>
	{
	    var stringData = await _httpClient.DownloadStringAsync(URL);
	    DoStuff(stringData);
	};

And that's it!  The code expresses the intent (downloading some data asynchronously) without getting bogged down in interacting with Task objects.

For those who are more theoretically-inclined, this is an implementation of the `Future/Promise concurrency model <https://en.wikipedia.org/wiki/Futures_and_promises>`_.

A few important things to know before continuing:

* Async code uses ``Task<T>`` and ``Task``, which are constructs used to model the work being done in an asynchronous context.  `More on Task and Task<T>`_
* When the ``await`` keyword is applied, it suspends the calling method and yields control back to its caller until the awaited task is complete.  This is what allows a UI to be responsive and a service to be elastic.
* ``await`` can only be used inside an async method.
* Unless an async method has an ``await`` inside its body, it will never yield!
* ``async void`` should **only** be used on Event Handlers (where it is required).

Example (C#)
------------

The following example shows how to write basic async code for both a client app and a web service.  The code, in both cases, will count the number of times ".NET" appears in the HTML of "dotnetfoundation.org".

Client app snippet (Universal Windows App):

.. code-block:: c#

	private readonly HttpClient _httpClient = new HttpClient();

	private async void SeeTheDotNets_Click(object sender, RoutedEventArgs e)
	{
	    // Capture the task handle here so we can await the background task later.
	    var getDotNetFoundationHtmlTask = _httpClient.GetStringAsync("http://dotnetfoundation.com");

	    // Any other work on the UI thread can be done here, such as enabling a Progress Bar.
	    NetworkProgressBar.IsEnabled = true;
	    NetworkProgressBar.Visibility = Visibility.Visible;

	    // The await operator suspends SeeTheDotNets_Click, returning control to its caller.
	    // This is what allows the app to be responsive and not hang on the UI thread.
	    var html = await getDotNetFoundationHtmlTask;
	    int count = Regex.Matches(html, ".NET").Count;

	    DotNetCountLabel.Text = $"Number of .NETs on dotnetfoundation.com: {count}";

	    NetworkProgressBar.IsEnabled = false;
	    NetworkProgressBar.Visbility = Visibility.Collapsed;
	}

Web service snippet (ASP.NET MVC):

.. code-block:: c#

	private readonly HttpClient _httpClient = new HttpClient();

	[HttpGet]
	[Route("DotNetCount")]
	public async Task<int> GetDotNetCountAsync()
	{
	    // Suspends GetDotNetCountAsync() to allow the caller (the web server) to accept another request,
	    // rather than blocking on this one.
	    var html = await _httpClient.DownloadStringAsync("https://dotnetfoundation.org");

	    return Regex.Matches(html, ".NET").Count;
	}

Example (VB)
------------

These are the VB-equivalent code snippets from above.

Client app snippet (Universal Windows App):

.. code-block:: vb.net

	Private Readonly Dim _httpClient As HttpClient = new HttpClient()

	Private Async Sub SeeTheDotNets_Click(sender As Object, e As RoutedEventArgs)

	    ' Capture the task handle here so we can await it later.
	    Dim getDotNetFoundationHtmlTask As Task(Of String) = _httpClient.GetStringAsync("http://dotnetfoundation.org")

	    ' Any other work on the UI thread can be done here, such as enabling a Progress Bar.
	    NetworkProgressBar.IsEnabled = true
	    NetworkProgressBar.Visibility = Visibility.Visible

	    ' The await operator suspends SeeTheDotNets_Click, returning control to its caller.
	    ' This is what allows the app to be responsive and not hang on the UI thread.
	    Dim html As String = Await getDotNetFoundationHtmlTask
	    Dim count As Integer = Regex.Matches(html, ".NET").Count

	    DotNetCountLabel.Text = $"Number of .NETs on dotnetfoundation.com: {count}"

	    NetworkProgressBar.IsEnabled = false
	    NetworkProgressBar.Visbility = Visibility.Collapsed
	End Sub

Web Service snippet (ASP.NET MVC):

.. code-block:: vb.net

	Private Readonly Dim _httpClient As HttpClient = new HttpClient()

	<HttpGet>
	<Route("MicrosoftCount")>
	Public Async Function GetDotNetCountAsync() As Task(Of String)

	    ' Suspends GetDotNetCountAsync() to allow the caller (the web server) to accept another request,
	    ' rather than blocking on this one.
	    Dim html As String = Await _httpClient.GetStringAsync("https://dotnetfoundation.org");

	    Return Regex.Matches(html, ".NET").Count
	End Function

More on Task and Task<T>
------------------------

As mentioned before, Tasks are constructs used to represent operations which you will need to wait on to complete.

* ``Task`` represents a single operation which does not return a value.
* ``Task<T>`` represents a single operation which returns a value of type ``T``.

It's important to reason about Tasks of abstractions of work happening in the background, and *not* dedicated threads on the thread pool, because in the context of I/O-bound code, they aren't new threads at all!

Here's a short, 10,000 foot view of what happens with a typical async call:

The call (such as ``GetStringAsync`` from ``HttpClient``) makes its way through the .NET libraries until it reaches a system interop call (such as ``P/Invoke`` on Windows).  This eventually makes the proper System API call (such as ``write`` to a socket file descriptor on Linux).  That System API call is then dealt with in the kernel, where the I/O request is sent to the proper subsystem.  Although details about scheduling the work on the appropriate device driver are different for each OS, eventually an "incomplete task" signal will be sent from the device driver, bubbling its way back up to the .NET runtime.  This will be converted into a ``Task`` or ``Task<T>`` by the runtime, sending that handle to the executing method which invoked the task in the first place.

Although many details were glossed over (such as how "borrowing" compute time on a thread pool is coordinated), the important thing to recognize here is that **no thread is 100% dedicated to running the initiated task**.  This allows threads in the thread pool of a system to handle a larger volume of work rather than having to wait for I/O to finish.

Tasks are awaitable, meaning that the use ``await`` will allow your application or service to perform useful work while the task is running by yielding control to its caller until the task is done.  If you're using ``Task<T>``, the ``await`` keyword will additionally "unwrap" the value returned when the Task is complete.

Tasks are also used outside of the async programming model.  They are the foundation of the Task Parallel Library, which supports the parallelization of CPU-bound work via `Data Parallelism <https://msdn.microsoft.com/en-us/library/dd537608(v=vs.110).aspx>`_ and `Task Parallelism <https://msdn.microsoft.com/en-us/library/dd537609(v=vs.110).aspx>`_.

Important Info and Advice
-------------------------

Although async programming is relatively straightforward, there are some details to keep in mind which can prevent unexpected behavior.

* **You should add "Async" as the suffix of every async method name you write.**

This is the convention used in .NET to more-easily differentiate synchronous and asynchronous methods.  Note that certain methods which aren't explicitly called by your code (such as event handlers or web controller methods) don't necessarily apply.  Because these are not explicitly called by your code, being explicit about their naming isn't as important.

* ``async void`` **should only be used for event handlers.**

Why?  It's the only way to allow asynchronous event handlers work because events do not have return types (thus cannot make use of ``Task`` and ``Task<T>``).  Any other use of ``async void``does not follow the Task-based model and will bring about some issues, such as:

    (a) Exceptions thrown in an ``async void`` method can't be caught outside of that method.

    (b) ``async void`` methods are very difficult to test.

    (c) ``async void`` methods can cause bad side effects if the caller isn't expecting them to be async.

* **Tread carefully when using async lambdas in LINQ expressions**

Lambda expressions in LINQ use deferred execution, meaning code could end up executing at a time when you're not expecting it to.  The introduction of blocking tasks into this can easily result in a deadlock if not written correctly.  The nesting of asynchronous code like this can also make it more difficult to reason about the execution of the code.  Async and LINQ are powerful, but if they are abused they can make things difficult.  Clarity is always better than cleverness.

* **Write code that awaits Tasks in a non-blocking manner**

Blocking the current thread as a means to wait for a Task to complete can result in deadlocks, blocked context threads, and significantly more complex error-handling.  The following table should provide some guidance in how to deal with waiting for Tasks in a non-blocking way:

====================== ================================= =======================
Use this...            Instead of this...                When wishing to do this
====================== ================================= =======================
``await``              ``Task.Wait`` or ``Task.Result``  Retrieving the result of a background task
``await Task.WhenAny`` ``Task.WaitAny``                  Waiting for any task to complete
``await Task.WhenAll`` ``Task.WaitAll``                  Waiting for all tasks to complete
``await Task.Delay``   ``Thread.Sleep``                  Waiting for a period of time
====================== ================================= =======================

* **Write less stateful code**

Don't depend on the state of global objects or the execution of certain methods.  Instead, depend only on the return values of methods.  Why?

	(a) Code will be easier to reason about
	(b) Code will be easier to test
	(c) Mixing async and synchronous code is far simpler
	(d) Race conditions can typically be avoided altogether
	(e) Depending on return values makes coordinating async code simple
	(f) (Bonus) it works really well with dependency injection

For a specific goal, aim for complete or near-complete `Referential Transparency <https://en.wikipedia.org/wiki/Referential_transparency_(computer_science)>`_ in your code.  Doing so will result in an extremely predictable, testable, and maintainable codebase.

More Information
----------------
* `Async/Await Reference Docs <https://msdn.microsoft.com/en-us/library/hh191443.aspx>`_
* `Tasks and the Task Parallel Library <https://msdn.microsoft.com/en-us/library/dd460717(v=vs.110).aspx>`_
