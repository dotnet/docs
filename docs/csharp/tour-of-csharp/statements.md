---
title: Statements | .NET Core
description: Statements
keywords: .NET, csharp
author: BillWagner
manager: wpickett
ms.date: 2016/08/10
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.assetid: 5409c379-5622-4fae-88b5-1654276ea8d4
ms.devlang: csharp
---

# Statements

The actions of a program are expressed using ***statements***. C# supports several different kinds of statements, a number of which are defined in terms of embedded statements.

A ***block*** permits multiple statements to be written in contexts where a single statement is allowed. A block consists of a list of statements written between the delimiters `{` and `}`.

***Declaration statements*** are used to declare local variables and constants.

***Expression statements*** are used to evaluate expressions. Expressions that can be used as statements include method invocations, object allocations using the `new` operator, assignments using `=` and the compound assignment operators, increment and decrement operations using the `++` and `--` operators and `await` expressions.

***Selection statements*** are used to select one of a number of possible statements for execution based on the value of some expression. In this group are the `if` and `switch` statements.

***Iteration statements*** are used to execute repeatedly an embedded statement. In this group are the `while`, `do`, `for`, and `foreach` statements.

***Jump statements*** are used to transfer control. In this group are the `break`, `continue`, `goto`, `throw`, `return`, and `yield` statements.

The `try`...`catch` statement is used to catch exceptions that occur during execution of a block, and the `try`...`finally` statement is used to specify finalization code that is always executed, whether an exception occurred or not.

The `checked` and `unchecked` statements are used to control the overflow-checking context for integral-type arithmetic operations and conversions.

The `lock` statement is used to obtain the mutual-exclusion lock for a given object, execute a statement, and then release the lock.

The `using` statement is used to obtain a resource, execute a statement, and then dispose of that resource.

The following lists the kinds of statements that can be used, and provides an example for each.

***Local variable declaration***

```csharp
static void Main()
{
	int a; 
	int b = 2, c = 3; 
	a = 1;
	Console.WriteLine(a + b + c);
}
```
***Local constant declaration***
```csharp
static void Main()
{
	const float pi = 3.1415927f;
	const int r = 25;
	Console.WriteLine(pi * r * r);
}
```
***Expression statement***
```csharp 
static void Main()
{
	int i;
	i = 123;                // Expression statement
	Console.WriteLine(i);   // Expression statement
	i++;                    // Expression statement
	Console.WriteLine(i);   // Expression statement
}
```
***`if` statement***
```csharp
static void Main(string[] args) 
{
	if (args.Length == 0)
    {
		Console.WriteLine("No arguments");
	}
	else 
    {
		Console.WriteLine("One or more arguments");
	}
}
```
***`switch` statement***
```csharp
static void Main(string[] args) 
{
	int n = args.Length;
	switch (n) 
    {
		case 0:
			Console.WriteLine("No arguments");
			break;
		case 1:
			Console.WriteLine("One argument");
			break;
		default:
			Console.WriteLine($"{n} arguments");
			break;
		}
	}
}
```
***`while` statement***
``` csharp
static void Main(string[] args) 
{
	int i = 0;
	while (i < args.Length) 
    {
		Console.WriteLine(args[i]);
		i++;
	}
}
```
***`do` statement***
```csharp
static void Main() 
{
	string s;
	do 
    {
		s = Console.ReadLine();
		if (s != null) Console.WriteLine(s);
	} while (s != null);
}
```
***`for` statement***
```csharp
static void Main(string[] args) 
{
	for (int i = 0; i < args.Length; i++) {
		Console.WriteLine(args[i]);
	}
}
```
***`foreach` statement***
```csharp
static void Main(string[] args) 
{
	foreach (string s in args) 
    {
		Console.WriteLine(s);
	}
}
```
***`break` statement***
```csharp
static void Main()
{
	while (true) 
    {
		string s = Console.ReadLine();
		if (s == null) 
            break;
		Console.WriteLine(s);
	}
}
```
***`continue` statement***
```csharp
static void Main(string[] args) 
{
	for (int i = 0; i < args.Length; i++) 
    {
		if (args[i].StartsWith("/")) 
            continue;
		Console.WriteLine(args[i]);
	}
}
```
goto statement	static void Main(string[] args) {
	int i = 0;
	goto check;
	loop:
	Console.WriteLine(args[i++]);
	check:
	if (i < args.Length) 
        goto loop;
}
```
***`return` statement***
```csharp
static int Add(int a, int b) 
{
    return a + b;
}
static void Main() 
{
    Console.WriteLine(Add(1, 2));
    return;
}
```
***`yield` statement***
```csharp
static IEnumerable<int> Range(int from, int to) 
{
	for (int i = from; i < to; i++) 
    {
		yield return i;
	}
	yield break;
}
static void Main() 
{
	foreach (int x in Range(-10,10)) 
    {
		Console.WriteLine(x);
	}
}
```
***`throw` statements and `try` statements***
```csharp
static double Divide(double x, double y) 
{
	if (y == 0) 
        throw new DivideByZeroException();
	return x / y;
}
static void Main(string[] args) 
{
	try 
    {
		if (args.Length != 2) 
        {
			throw new Exception("Two numbers required");
		}
		double x = double.Parse(args[0]);
		double y = double.Parse(args[1]);
		Console.WriteLine(Divide(x, y));
	}
	catch (Exception e) 
    {
		Console.WriteLine(e.Message);
	}
	finally 
    {
		Console.WriteLine(“Good bye!”);
	}
}
```
***`checked` and `unchecked` statements***
```csharp
static void Main() 
{
    int x = int.MaxValue;
    checked 
    {
        Console.WriteLine(x + 1);  // Exception
    }     
    unchecked 
    {
       Console.WriteLine(x + 1);  // Overflow
    }
}
```
***`lock` statement***
```csharp
class Account
{
	decimal balance;
	private readonly object sync = new object();
	public void Withdraw(decimal amount) 
    {
		lock (thissync) 
        {
			if (amount > balance) 
            {
				throw new Exception(
					"Insufficient funds");
			}
			balance -= amount;
		}
	}
}
using statement	static void Main() 
{
	using (TextWriter w = File.CreateText("test.txt")) 
    {
		w.WriteLine("Line one");
		w.WriteLine("Line two");
		w.WriteLine("Line three");
	}
}
```
