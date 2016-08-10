---
title: C# Delegates | A tour of the C# language
description: Learn late binding with C# delegates
keywords: .NET, csharp, delegate, lambda, late binding
author: BillWagner
manager: wpickett
ms.date: 08/10/2016
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 3cc27357-3ac2-43a1-aad0-86a77b88f884
---

# Delegates

A ***delegate type*** represents references to methods with a particular parameter list and return type. Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters. Delegates are similar to the concept of function pointers found in some other languages, but unlike function pointers, delegates are object-oriented and type-safe.

The following example declares and uses a delegate type named Function.

```csharp
using System;
delegate double Function(double x);
class Multiplier
{
	double factor;
	public Multiplier(double factor) 
	{
		this.factor = factor;
	}
	public double Multiply(double x) 
	{
		return x * factor;
	}
}
class DelegateExample
{
	static double Square(double x) 
	{
		return x * x;
	}
	static double[] Apply(double[] a, Function f) 
	{
		double[] result = new double[a.Length];
		for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
		return result;
	}
	static void Main() 
	{
		double[] a = {0.0, 0.5, 1.0};
		double[] squares = Apply(a, Square);
		double[] sines = Apply(a, Math.Sin);
		Multiplier m = new Multiplier(2.0);
		double[] doubles =  Apply(a, m.Multiply);
	}
}
```

An instance of the `Function` delegate type can reference any method that takes a `double` argument and returns a `double` value. The `Apply` method applies a given Function to the elements of a `double[]`, returning a `double[]` with the results. In the `Main` method, `Apply` is used to apply three different functions to a `double[]`.

A delegate can reference either a static method (such as `Square` or `Math.Sin` in the previous example) or an instance method (such as `m.Multiply` in the previous example). A delegate that references an instance method also references a particular object, and when the instance method is invoked through the delegate, that object becomes this in the invocation.

Delegates can also be created using anonymous functions, which are "in-line methods" that are created on the fly. Anonymous functions can see the local variables of the sourrounding methods. Thus, the multiplier example above can be written more easily without using a Multiplier class:

```csharp
double[] doubles =  Apply(a, (double x) => x * 2.0);
```

An interesting and useful property of a delegate is that it does not know or care about the class of the method it references; all that matters is that the referenced method has the same parameters and return type as the delegate.
