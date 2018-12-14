---
title: [Best practices for handling and using exceptions]
description: [Practical guide to handling and using exceptions.]
author: [sam.wheat@outlook.com]
ms.date: [12/10/2018]
---
# Best practices for handling and using exceptions

@BillWagner For your review 

1.	An approach to using exceptions and exception handling to your advantage.
	1.	Start with reasonable expectations.
		i.	Fault-tolerant is another way of saying that you have found a way to work around errors.
		ii.	Robust recovery code adds significant complexity to your application.
			1.	Adds additional code paths to troubleshoot when debugging
			2.	Is sometimes useless since some exceptions are unrecoverable.
	2.	Catching an exception is not itself a fix.
		i.	A catch block offers you opportunity to gather information and begin recovery.
		ii.	Catching exceptions incorrectly weakens your code.
			1.	An exception often means your business logic is not doing its job.
	3.	Preventing exceptions, not recovering from them, should be your first design objective.  
		i.	Patterns and practices that prevent exceptions make your code stronger:
			1.	Explicit business logic, robust validation, proper use of types, proper use of DBMS schema, DRY, SOLID.
		ii.
			1.  Resilience is your second goal
				i. Use transactions when writing to a database
				ii.  Consider using a resilience or fault-handling library. 
	4.	Blindly running your application after an unhandled exception has occurred is almost always a bad choice.
		i.	Running an application in an invalid or unknown state often leads to incorrect results, data corruption, intermittent errors and errors that are difficult or impossible to trace.
		ii.	The default behavior for your application should be to stop processing when an exception occurs.
			1.	Goals are to minimize collateral damage and preserve forensic data to assist troubleshooting
		iii.	Make a business case for specific scenarios where you think your application should be able recover from an exception.  
			1.	Identify the specific exception you want to handle.
			2.	Make sure you can restore your application to a known state.
			3.	Identify the point from which you want the process to restart.

2.	Guidelines for using try/catch blocks.
	1.	Use a global exception handler.
		i.	Use one or more of the .net event handlers.
			1.	DispatcherUnhandledException
			2.	AppDomain.CurrentDomain.UnhandledException
			3.	System.Threading.Tasks.TaskScheduler.UnobservedTaskException 
			4.	Dispatcher.UnhandledException
		ii.	Execute your main method in a try/catch block.
		iii. Fewer try/catch blocks are preferential to more.  Many small applications need only the global exception handlers.
		iv.	A global handler in a library is usually unnecessary.  Libraries should let unhandled exceptions flow up to the global handler.
	2.	Use try/catch blocks to isolate code that may throw exceptions for reasons beyond your control.
		i.	When isolating a section of code within a try/catch block put as little code as possible in the try block.  A single line is often sufficient.
		ii.	Do not put code in a try block unless you are able to handle one or more of the exceptions that code may raise in the corresponding catch block. 
		iii.	Prefer to catch specific exceptions that you are prepared to handle. If code throws a general exception or a type of exception that you do not expect consider letting the exception flow up to the global exception handler.
		iv.	A try/catch block is not a substitute for proactively preventing exceptions. 
	3.	Investigate thoroughly before catching Exception.  
		i.	Most catch blocks should handle specific exceptions only i.e. IOExceptions.  
		ii.	Prefer to let the global exception handler catch Exception.
	4.	Only catch exceptions you actually handle.
		i.	Logging an exception is not handling it. Logging belongs in the global exception handler.
		ii.	Catching an exception, collecting diagnostic info, and re-throwing is a good practice.
			1.	If you create a new exception object be sure to set the InnerException property to the original exception.  This ensures you preserve the stack trace.
		iii.	Properly handling an exception often involves recovery and/or retry.  Your handling logic should be able to perform these tasks if required.
			1.	Assess the specific type of error you are handling.
			2.	Verify that your environment is in a known state. 
			3.	Attempt to cancel or rollback any data transactions.
		iv.	Handle only the code inside the try block.  If necessary, re-throw the error and let higher level code clean up as required.
	5.	Shutting the application down or returning to the main method or home page after an exception is often the best choice.
		i.	An investment in preventing exceptions is preferred to an investment in handling them.
	6.	Use a finally block to execute code that should run even if an error occurs.		
		i.	Use a finally block to clean up unmanaged resources or set the environment to a state that calling code expects.

3.	Guidelines for throwing exceptions
	1.	Throwing exceptions properly is a good practice.
		i.	Helps identify weaknesses in calling code.
		ii.	Makes errors easier to find.
		iii. Aids in expressing and enforcing explicit business logic.
		iv.	Helps prevent data corruption.
	2.	Throw exceptions immediately in response to events which have already happened which should have been prevented.
		i.	An exception should be thrown immediately if code is passed invalid parameters that should have been validated or the application is allowed to  enter an invalid state.
		ii.	Do not return an error code or null value if business logic has been violated or not enforced when it should have been.  Do not make assumptions on behalf of calling code. Throw an exception immediately.
	3.	Do not throw exceptions to direct program flow.
		i.	Avoid throwing an exception to prevent something from happening or to force something to happen that would otherwise not occur. 
		ii.	Return a null value or error code if code cannot execute as the caller expects but business logic has not been violated.
			1.	This guideline covers cases where a user might supply an invalid value as a parameter.  In this case the program should display an error message and give the user the opportunity to try again.
		iii.	Exceptions are expensive and are a means of last resort.
	4.	Construct a meaningful and helpful error message when throwing an exception.
		i.	Use proper grammar and check your spelling.
		ii.	Include as much diagnostic information as possible in your error message.
		iii. Include instructions on how the caller might prevent the error and/or the location of additional resources to help them resolve it.


4.	Examples	[To-do]
	1.	Global exception handler 
	2.	Try/catch
	3.	Try/catch/finally - examples with transactions, temp files
	3.	Throw
	4.	Task
