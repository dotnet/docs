// <Snippet18>
using System;

public class Dog
{
   private string dogBreed;
   private string dogName;
   
   public Dog(string name, string breed)
   {
      this.dogName = name;
      this.dogBreed = breed;
   }
   
   public string Breed {
      get { return this.dogBreed; }
   }
   
   public string Name {
      get { return this.dogName; }
   }
   
   public override string ToString()
   {
      return this.dogName;
   }
}

public class Example
{
   public static void Main()
   {
      Dog dog1 = new Dog("Yiska", "Alaskan Malamute");
      System.Text.StringBuilder sb = new System.Text.StringBuilder();     
      sb.Append(dog1).Append(", Breed: ").Append(dog1.Breed);  
      Console.WriteLine(sb);
   }
}
// The example displays the following output:
//        Yiska, Breed: Alaskan Malamute
// </Snippet18>