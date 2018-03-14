// <Snippet1>
using System;
using System.Collections.Generic;

class StringContainer
{
   // Define a delegate to handle string display. 
   public delegate void CheckAndDisplayDelegate(string str);

   // A generic list object that holds the strings. 
   private List<String> container = new List<String>();

   // A method that adds strings to the collection. 
   public void AddString(string str) 
   {
      container.Add(str);
   }

   // Iterate through the strings and invoke the method(s) that the delegate points to. 
   public void DisplayAllQualified(CheckAndDisplayDelegate displayDelegate) 
   {
      foreach (var str in container) {
         displayDelegate(str);
      }
   }
 }    

// This class defines some methods to display strings. 
class StringExtensions
{
   // Display a string if it starts with a consonant. 
   public static void ConStart(string str) 
   {
      if (!(str[0]=='a'||str[0]=='e'||str[0]=='i'||str[0]=='o'||str[0]=='u'))
          Console.WriteLine(str);
   }

   // Display a string if it starts with a vowel.
   public static void VowelStart(string str) 
   {
      if ((str[0]=='a'||str[0]=='e'||str[0]=='i'||str[0]=='o'||str[0]=='u'))
          Console.WriteLine(str);
   }
}

// Demonstrate the use of delegates, including the Remove and 
// Combine methods to create and modify delegate combinations. 
class Test
{
   static public void Main()
   {
      // Declare the StringContainer class and add some strings
      StringContainer container = new StringContainer();
      container.AddString("This");
      container.AddString("is");
      container.AddString("a");
      container.AddString("multicast");
      container.AddString("delegate");
      container.AddString("example");

      // Create two delegates individually using different methods.
      StringContainer.CheckAndDisplayDelegate conStart = StringExtensions.ConStart;
      StringContainer.CheckAndDisplayDelegate vowelStart = StringExtensions.VowelStart;

      // Get the list of all delegates assigned to this MulticastDelegate instance. 
      Delegate[] delegateList = conStart.GetInvocationList();
      Console.WriteLine("conStart contains {0} delegate(s).", delegateList.Length);
      delegateList = vowelStart.GetInvocationList();
      Console.WriteLine("vowelStart contains {0} delegate(s).\n", delegateList.Length);

      // Determine whether the delegates are System.Multicast delegates. 
      if (conStart is System.MulticastDelegate && vowelStart is System.MulticastDelegate) 
          Console.WriteLine("conStart and vowelStart are derived from MulticastDelegate.\n");

      // Execute the two delegates.
      Console.WriteLine("Executing the conStart delegate:");
      container.DisplayAllQualified(conStart);
      Console.WriteLine();
      Console.WriteLine("Executing the vowelStart delegate:");
      container.DisplayAllQualified(vowelStart);
      Console.WriteLine();
      
      // Create a new MulticastDelegate and call Combine to add two delegates.
      StringContainer.CheckAndDisplayDelegate multipleDelegates = 
            (StringContainer.CheckAndDisplayDelegate) Delegate.Combine(conStart, vowelStart);

      // How many delegates does multipleDelegates contain?
      delegateList = multipleDelegates.GetInvocationList();
      Console.WriteLine("\nmultipleDelegates contains {0} delegates.\n",
                        delegateList.Length);

      // Pass this multicast delegate to DisplayAllQualified.
      Console.WriteLine("Executing the multipleDelegate delegate.");
      container.DisplayAllQualified(multipleDelegates);

      // Call remove and combine to change the contained delegates.
      multipleDelegates = (StringContainer.CheckAndDisplayDelegate) Delegate.Remove(multipleDelegates, vowelStart);
      multipleDelegates = (StringContainer.CheckAndDisplayDelegate) Delegate.Combine(multipleDelegates, conStart);

      // Pass multipleDelegates to DisplayAllQualified again.
      Console.WriteLine("\nExecuting the multipleDelegate delegate with two conStart delegates:");
      container.DisplayAllQualified(multipleDelegates);
   }
}
// The example displays the following output:
//    conStart contains 1 delegate(s).
//    vowelStart contains 1 delegate(s).
//    
//    conStart and vowelStart are derived from MulticastDelegate.
//    
//    Executing the conStart delegate:
//    This
//    multicast
//    delegate
//    
//    Executing the vowelStart delegate:
//    is
//    a
//    example
//    
//    
//    multipleDelegates contains 2 delegates.
//    
//    Executing the multipleDelegate delegate.
//    This
//    is
//    a
//    multicast
//    delegate
//    example
//    
//    Executing the multipleDelegate delegate with two conStart delegates:
//    This
//    This
//    multicast
//    multicast
//    delegate
//    delegate
// </Snippet1>  

