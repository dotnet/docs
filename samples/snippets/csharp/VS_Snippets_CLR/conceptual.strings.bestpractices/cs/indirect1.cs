using System;

public class Class1
{
   public static void Main()
   {
   }

   // <Snippet7>
   // Incorrect.
   string []storedNames;

   public void StoreNames(string [] names)
   {
      int index = 0;
      storedNames = new string[names.Length];

      foreach (string name in names)
      {
         this.storedNames[index++] = name;
      }

      Array.Sort(names); // Line A.
   }

   public bool DoesNameExist(string name)
   {
      return (Array.BinarySearch(this.storedNames, name) >= 0);  // Line B.
   }
   // </Snippet7>
}

public class Class8
{
   // <Snippet8>
   // Correct.
   string []storedNames;

   public void StoreNames(string [] names)
   {
      int index = 0;
      storedNames = new string[names.Length];

      foreach (string name in names)
      {
         this.storedNames[index++] = name;
      }

      Array.Sort(names, StringComparer.Ordinal);  // Line A.
   }

   public bool DoesNameExist(string name)
   {
      return (Array.BinarySearch(this.storedNames, name, StringComparer.Ordinal) >= 0);  // Line B.
   }
   // </Snippet8>
}

public class Class9
{
   // <Snippet9>
   // Correct.
   string []storedNames;

   public void StoreNames(string [] names)
   {
      int index = 0;
      storedNames = new string[names.Length];

      foreach (string name in names)
      {
         this.storedNames[index++] = name;
      }

      Array.Sort(names, StringComparer.InvariantCulture);  // Line A.
   }

   public bool DoesNameExist(string name)
   {
      return (Array.BinarySearch(this.storedNames, name, StringComparer.InvariantCulture) >= 0);  // Line B.
   }
   // </Snippet9>
}
