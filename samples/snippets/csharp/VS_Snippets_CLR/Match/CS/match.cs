// <Snippet1>
using System;
using System.Reflection;

// A custom attribute to allow 2 authors per method.
[AttributeUsage(AttributeTargets.Method)]
public class AuthorsAttribute : Attribute 
{
	protected string _authorName1;
	protected string _authorName2;

	public AuthorsAttribute(string name1, string name2) 
    {
		_authorName1 = name1;
		_authorName2 = name2;
	}

	public string AuthorName1 
    {
		get { return _authorName1; }
		set { _authorName1 = value; }
	}

	public string AuthorName2 
    {
		get { return _authorName2; }
		set { _authorName2 = value; }
	}


    public override bool Equals(Object obj)
    {
      AuthorsAttribute auth = obj as AuthorsAttribute;
      if (auth == null) return false;

      return ((_authorName1 == auth.AuthorName1 & 
              _authorName2 == auth.AuthorName2) |
              (_authorName1 == auth.AuthorName2 &
              _authorName2 == auth.AuthorName1));
   }

	// Use the hash code of the string objects and xor them together.
	public override int GetHashCode() 
    {
		return _authorName1.GetHashCode() ^ _authorName2.GetHashCode();
	}

	// Determine if the object is a match to this one.
	public override bool Match(object obj) 
    {
		// Obviously a match.
		if (obj == this)
			return true;

		// Obviously we're not null, so no.
		if (obj == null)
			return false;

		AuthorsAttribute authObj = obj as AuthorsAttribute;
		if (authObj != null)  
            // Check for identical order.
            if ((_authorName1 == authObj._authorName1) &
                (_authorName2 == authObj._authorName2))
                return true;
            // Check for reversed order.
            else if ((_authorName1 == authObj._authorName2) &
                (_authorName2 == authObj._authorName1))
                return true;
            else
                return false;
        else
    		return false;
	}
}

// Add some authors to methods of a class.
public class TestClass1 {
	[Authors("William Shakespeare", "Herman Melville")]
	public void Method1()
	{}

	[Authors("Leo Tolstoy", "John Milton")]
	public void Method2()
	{}
}

// Add authors to a second class's methods.
public class TestClass2 {
	[Authors("William Shakespeare", "Herman Melville")]
	public void Method1()
	{}

	[Authors("Leo Tolstoy", "John Milton")]
	public void Method2()
	{}

	[Authors("William Shakespeare", "John Milton")]
	public void Method3()
	{}

   [Authors("John Milton", "Leo Tolstoy")]
   public void Method4()
   {}
}

class DemoClass {
	static void Main(string[] args) {
		// Get the type for both classes to access their metadata.
		Type clsType1 = typeof(TestClass1);
		Type clsType2 = typeof(TestClass2);

		// Iterate through each method of the first class.
		foreach(var method in clsType1.GetMethods()) {
			// Check each method for the Authors attribute.
			AuthorsAttribute authAttr1 = (AuthorsAttribute)
				Attribute.GetCustomAttribute(method, 
				typeof(AuthorsAttribute));
			if (authAttr1 != null) {
				// Display the authors.
				Console.WriteLine("{0}.{1} was authored by {2} and {3}.", 
                                  clsType1.Name, method.Name, authAttr1.AuthorName1, 
                                  authAttr1.AuthorName2);
				// Iterate through each method of the second class.
				foreach(var method2 in clsType2.GetMethods()) {
					// Check each method for the Authors attribute.
					AuthorsAttribute authAttr2 = (AuthorsAttribute)
						Attribute.GetCustomAttribute(method2, 
						typeof(AuthorsAttribute));
					// Compare with the authors in the first class.
					if (authAttr2 != null && authAttr2.Match(authAttr1))
						Console.WriteLine("{0}.{1} was also authored by the same team.", 
                                       clsType2.Name, method2.Name);
				}
				Console.WriteLine();
			}
		}
	}
}
// The example displays the following output:
//    TestClass1.Method1 was authored by William Shakespeare and Herman Melville.
//    TestClass2.Method1 was also authored by the same team.
//    
//    TestClass1.Method2 was authored by Leo Tolstoy and John Milton.
//    TestClass2.Method2 was also authored by the same team.
//    TestClass2.Method4 was also authored by the same team.
// </Snippet1>

