using System;

public class Example
{
   public static void Main()
   {
      int caseSwitch = 1;
      // <Snippet1>
      switch (caseSwitch)  
      {  
          // The following switch section causes an error.  
          case 1:  
              Console.WriteLine("Case 1...");  
              break;  
          case 2:  
          case 3:
              Console.WriteLine("... and/or Case 2");  
              break;
          case 4:  
              while (true)  
                 Console.WriteLine("Endless looping. . . ."); 
          default:
              Console.WriteLine("Default value...");
              break;                 
      }  
      // </Snippet1>
   }
}
