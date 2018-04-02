# Null coalescing and operators

## Introduction


### Null coalescing (??)
The null coalescing operator consists of a double question mark "??". With this operator, the null check of a reference variable can be simplified greatly.

With the null coalescing operator you can check to see if a variable is null and if it is, return a different value of the same type all in one line. Have a look at the sample below to see how this work.

#### Sample
In this example we will look at a typical scenario for a null coalescing operator. In the sample code we will see a property with a backing field in a C# class. The first code block shows you how to handle this scenario without the null coalescing operator.

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

This can be rewritten to a single line with the null coalescing operator. Observe the code to do this in the sample code below.

```
public class NullCoalescingSample2
{
	private string _myStringValue;
	
	public string MyStringValue
	{
		get 
		{
			 return _myStringValue ?? "Default value";
		}
	}
}
```

Basically what is happening here is that we return the backing field value, unless it is null then return the static string.

#### Remarks

### Null operator (?.)
The null operator, or null conditional can be used to reduce the number of if-statements and nesting in your code. It works slightly different from the null coalescing operator.

With this operator you can incorporate your null check with another condition. Please have a look at the samples below for more clarification. 

#### Sample

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

We can reduce this code to just one line with the null conditional operator.

#### Remarks


## Conclusion