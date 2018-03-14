// <Snippet8>
using System;

class Program
{
    static void Main()
   {
      object[] items = { new Book("The Tempest"), new Person("John") };
      foreach (var item in items) {
        if (item is var obj)
          Console.WriteLine($"Type: {obj.GetType().Name}, Value: {obj}"); 
      }
   }
}

class Book
{
    public Book(string title) 
    {
       Title = title;    
    }

    public string Title { get; set; }

    public override string ToString()
    {
       return Title;
    }
}

class Person
{
   public Person(string name)
   {
      Name = name;
   }

   public string Name 
   { get; set; }

   public override string ToString()
   {
      return Name;
   }
}
// The example displays the following output:
//       Type: Book, Value: The Tempest
//       Type: Person, Value: John
// </Snippet8>
