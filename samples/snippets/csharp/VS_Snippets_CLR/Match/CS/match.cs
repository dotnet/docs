using System;
using System.Collections.Generic;
using System.Reflection;

// A custom attribute to allow multiple authors per method.
[AttributeUsage(AttributeTargets.Method)]
public class AuthorsAttribute : Attribute 
{
   protected List<string> _authors;

	public AuthorsAttribute(params string[] names) 
   {
      _authors = new List<string>(names);
	}

   public List<string> Authors 
   {
	   get { return _authors; }
   }

	// Determine if the object is a match to this one.
	public override bool Match(object obj) 
   {
      // Return false if obj is null or not an AuthorsAttribute.
      AuthorsAttribute authors2 = obj as AuthorsAttribute;
      if (authors2 == null) return false;
      
		// Return true if obj and this instance are the same object reference.
      if (Object.ReferenceEquals(this, authors2))
         return true;

      // Return false if obj and this instance have different numbers of authors
      if (_authors.Count != authors2._authors.Count)
         return false;
         
      bool matches = false;
      foreach (var author in _authors) 
      { 
         for (int ctr = 0; ctr < authors2._authors.Count; ctr++)
         {
            if (author == authors2._authors[ctr])
            {
               matches = true;
               break;
            }
            if (ctr == authors2._authors.Count)
            {
               matches = false;
            }
         }
      }
      return matches;
   }

   public override string ToString()
   {
      string retval = "";
      for (int ctr = 0; ctr < _authors.Count; ctr++)
      {
         retval += $"{_authors[ctr]}{(ctr < _authors.Count - 1 ? ", " : String.Empty)}";
      }
      if (retval.Trim().Length == 0)
      {
         return "<unknown>";
      }
      return retval;
   }
}

// Add some authors to methods of a class.
public class TestClass {
	[Authors("Leo Tolstoy", "John Milton")]
	public void Method1()
	{}

	[Authors("Anonymous")]
	public void Method2()
	{}

	[Authors("Leo Tolstoy", "John Milton", "Nathaniel Hawthorne")]
	public void Method3()
	{}

	[Authors("John Milton", "Leo Tolstoy")]
	public void Method4()
	{}
}

class Example 
{
	static void Main() 
   {
		// Get the type for TestClass to access its metadata.
		Type clsType = typeof(TestClass);

		// Iterate through each method of the class.
      AuthorsAttribute authors = null;
		foreach(var method in clsType.GetMethods()) 
      {
			// Check each method for the Authors attribute.
			AuthorsAttribute authAttr = (AuthorsAttribute)  Attribute.GetCustomAttribute(method, 
				                         typeof(AuthorsAttribute));
			if (authAttr != null) 
         {
            // Display the authors.
				Console.WriteLine($"{clsType.Name}.{method.Name} was authored by {authAttr}.");

            // Select Method1's authors as the basis for comparison.
            if (method.Name == "Method1")
            {
				   authors = authAttr;
               Console.WriteLine();
               continue;
            }
         
   			// Compare first authors with the authors of this method.
            if (authors.Match(authAttr))
            {
					Console.WriteLine("TestClass.Method1 was also authored by the same team.");
            }

            // Perform an equality comparison of the two attributes.
            Console.WriteLine($"{authors} {(authors.Equals(authAttr) ? "=" : "<>")} {authAttr}");
            Console.WriteLine();
			}
		}
	}
}
// The example displays the following output:
//       TestClass.Method1 was authored by Leo Tolstoy, John Milton.
//       
//       TestClass.Method2 was authored by Anonymous.
//       Leo Tolstoy, John Milton <> Anonymous
//       
//       TestClass.Method3 was authored by Leo Tolstoy, John Milton, Nathaniel Hawthorne.
//       Leo Tolstoy, John Milton <> Leo Tolstoy, John Milton, Nathaniel Hawthorne
//       
//       TestClass.Method4 was authored by John Milton, Leo Tolstoy.
//       TestClass.Method1 was also authored by the same team.
//       Leo Tolstoy, John Milton <> John Milton, Leo Tolstoy
