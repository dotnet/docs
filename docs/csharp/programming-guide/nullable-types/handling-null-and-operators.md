---
title: "Null coalescing and null conditional operators (C# Programming Guide)"
description: "learn to use the ?? and ?. operators to avoid NullReferenceExceptions in your application"
ms.date: 04/04/2018
ms.prod: .net
ms.technology:
	- "devlang-csharp"
ms.topic: "article"
helpviewer_keywords:
	- "?. [C#]"
	- "?? [C#]"
	- "C# language, null conditional, null coalescing"
	- "types [C#], nullable"
author: "jfversluis"
ms.author: "wiwagn"
---
# Null coalescing and null conditional operators

Since version 6.0, C# supports the null coalescing and null conditional operator. WThese shorthands make it easier to write null checks and thus make your code more readable. This page shows how to use these shorthand notations.

## Null coalescing (??)
The null coalescing operator (??), simplifies providing alternative values when an expression evaluates to `null`.

With the null coalescing operator you can check to see if a variable is null and if it is, return a non-`null` value of the same type all in one expression. Actually, one of usages of the `??` operator is to jump from the space of nullable types to the space of the corresponding value types.

Have a look at the sample below to see how this work.

### Sample
In this example we look at a typical scenario for the null coalescing operator. In the sample code we see a property with a backing field in a C# class. The first code block shows you how to handle this scenario without the null coalescing operator.

```
public class NullCoalescingSample1
{
	private string _myStringValue;
	
	public string MyStringValue
	{
		get 
		{
			if (_myStringValue == null)
				return "Default value";
				
			return _myStringValue;
		}
	}
}
```

In the above code you can see that we're checking the backing field for a null value. If it is null we return a different value. When the backing field does contain a value we return the value in it.

Another notation of the above code could be like this:

```
public class NullCoalescingSample2
{
	private string _myStringValue;
	
	public string MyStringValue
	{
		get 
		{
			return _myStringValue == null ? "Default value" : _myStringValue;
		}
	}
}
```

This can be rewritten to a single line with the null coalescing operator and [property expression body definitions](../classes-and-structs/properties.md). Observe the code to do this in the sample code below.

```
public class NullCoalescingSample3
{
	private string _myStringValue;
	
	public string MyStringValue
	{
		get => return _myStringValue ?? "Default value";
	}
}
```

Basically what is happening here is that we return the backing field value, unless it is null then return the static string.

## Null-conditional operator (?.)
The null conditional operator can be used to reduce the number of if-statements and nesting in your code. It works slightly different from the null coalescing operator.

With this operator you can incorporate your null check with another condition. Please have a look at the samples below for more clarification. 

### Sample

```
public class NullOperatorSample1
{	
	public bool HasLengthOfFive(string value)
	{
		if (value == null)
			return false;
			
		return value.Length == 5;
	}
}
```

We can reduce this code to just one line with the null conditional operator. The changed code is shown underneath.

```
public class NullOperatorSample2
{	
	public bool HasLengthOfFive(string value)
	{
		return value?.Length == 5;
	}
}
```

When using the above method, invoked with a `null` value, it will simply return `false`. Because of the null conditional operator on the `value` variable, it will be evaluated for containing a `null` value. If it actually contains `null`, it knows that the rest of the condition will be false.

It can also be used to invoke methods. If the method returns a value and the object which is called upon is `null`, a `null` value will be returned as a result of that method as well. This is known as null-propagation. Sample code can be seen below.

```
public class NullOperatorSample3
{	
	public string GiveMeFive(string value)
	{
		return value?.Substring(0, 5);
	}
}

```

Invoking the above method like this: `GiveMeFive(null)`, will return `null` itself.

Using the null conditional operator on a method that does not return any value, will just not be invoked. A typical example of this is when working with event handlers. Observe a code sample of this below.

```
public class NullOperatorSample4
{
	public event EventHandler<string> OnStringValueChanged;
	
	private int _stringValue;
	
	public int StringValue
	{
		get
    	{
			return _stringValue;
		}
		
		set
		{
			_stringValue = value;
		
			if (OnStringValueChanged != null)
				OnStringValueChanged(this, value);
		}
	}
}
```

The above code shows some code that is typically used to check if there are any subscribers to the `OnStringValueChanged` event and invoke the event whenever there are subscribers. All the code in the setter of this property can now be reduced to a single line, like this: `OnStringValueChanged?.Invoke(this, value);`. The event will now only be invoked whenever `OnStringValueChanged` is not `null`.

### Remarks
The null conditional operator cannot be used with non-nullable, value types. For instance, the next code will produce a compile-time error.

`int length = text?.Length; // Compile Error: Cannot implicitly convert type 'int?' to 'int'`

In this article we have seen how to use the null coalescing and null conditional operator. While these do not introduce any new funtionality to the C# language, it can be used to reduce your code and therefore making it more readable and maintainable.

## See also

[Using Nullable Types](using-nullable-types.md)  
[How to Identify a Nullable Type](how-to-identify-a-nullable-type)  
