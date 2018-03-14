// <Snippet1>
using System;
using System.Reflection;
using System.Collections.Generic;

// A custom attribute to allow two authors per method.
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

   // Use the hash code of the string objects and xor them together.
   public override int GetHashCode() 
   {
      return _authorName1.GetHashCode() ^ _authorName2.GetHashCode();
   }
}

// Provide the author names for each method of the class.
public class TestClass 
{
  [Authors("Immanuel Kant", "Lao Tzu")]
  public void Method1()
  {}

  [Authors("Jean-Paul Sartre", "Friedrich Nietzsche")]
  public void Method2()
  {}

  [Authors("Immanuel Kant", "Lao Tzu")]
  public void Method3()
  {}

  [Authors("Jean-Paul Sartre", "Friedrich Nietzsche")]
  public void Method4()
  {}

  [Authors("Immanuel Kant", "Friedrich Nietzsche")]
  public void Method5()
  {}
}

class Example
{
   static void Main() 
   {
      // Get the class type to access its metadata.
      Type clsType = typeof(TestClass);

      // Store author information in a list of tuples.
      var authorsInfo = new List<Tuple<String, AuthorsAttribute>>(); 

      // Iterate through all the methods of the class.
      foreach(var method in clsType.GetMethods()) 
      {
          // Get the Authors attribute for the method if it exists.
          AuthorsAttribute authAttr = 
              (AuthorsAttribute)Attribute.GetCustomAttribute(
              method, typeof(AuthorsAttribute));
          if (authAttr != null) 
             // Add the information to the author list.
             authorsInfo.Add(Tuple.Create(clsType.Name + "." + method.Name,
                                             authAttr));
      }

      // Iterate through the list
      bool[] listed = new bool[authorsInfo.Count]; 
      Console.WriteLine("Method authors:\n");

      for (int ctr = 0; ctr < authorsInfo.Count; ctr++) {
         var authorInfo = authorsInfo[ctr];
         if (!listed[ctr]) {
             Console.WriteLine("{0} and {1}", authorInfo.Item2.AuthorName1,
                                              authorInfo.Item2.AuthorName2);
             listed[ctr] = true;
             Console.WriteLine("   {0}", authorInfo.Item1);
             for (int ctr2 = ctr + 1; ctr2 < authorsInfo.Count; ctr2++) {
                 if (!listed[ctr2]) 
                    if (authorInfo.Item2.Equals(authorsInfo[ctr2].Item2)) {
                       Console.WriteLine("   {0}", authorsInfo[ctr2].Item1);
                       listed[ctr2] = true;  
                    }
            }  
         }   
      }
   }
}
// The example displays the following output:
//       Method authors:
//       
//       Immanuel Kant and Lao Tzu
//          TestClass.Method1
//          TestClass.Method3
//       Jean-Paul Sartre and Friedrich Nietzsche
//          TestClass.Method2
//          TestClass.Method4
//       Immanuel Kant and Friedrich Nietzsche
//          TestClass.Method5
// </Snippet1>
