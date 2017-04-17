// System.Type.GetMembers(BindingFlags)

/*
  This program demonstrates 'GetMembers(BindingFlags)' method of 
  System.Type Class. This will get all the public instance members
  declared or inherited by this type and displays the members to
  the console.
*/

using System;
using System.Reflection;
using System.Security; 

// <Snippet1>

class MyClass
{
   public int myInt = 0;
   public string myString = null;

   public MyClass()
   {
   }
   public void Myfunction()
   {
   }
}

class Type_GetMembers_BindingFlags
{
   public static void Main()
   {
      try
      {
         MyClass MyObject = new MyClass();
         MemberInfo [] myMemberInfo; 

         // Get the type of the class 'MyClass'.
         Type myType = MyObject.GetType(); 
        
         // Get the public instance members of the class 'MyClass'. 
         myMemberInfo = myType.GetMembers(BindingFlags.Public|BindingFlags.Instance);
    
         Console.WriteLine( "\nThe public instance members of class '{0}' are : \n", myType); 
         for (int i =0 ; i < myMemberInfo.Length ; i++)
         {
            // Display name and type of the member of 'MyClass'.
            Console.WriteLine( "'{0}' is a {1}", myMemberInfo[i].Name, myMemberInfo[i].MemberType);
         }

      }
      catch (SecurityException e)
      {
         Console.WriteLine("SecurityException : " + e.Message ); 
      }      

      //Output:
      //The public instance members of class 'MyClass' are :

      //'Myfunction' is a Method
      //'ToString' is a Method
      //'Equals' is a Method
      //'GetHashCode' is a Method
      //'GetType' is a Method
      //'.ctor' is a Constructor
      //'myInt' is a Field
      //'myString' is a Field

   }
}

// </Snippet1>

