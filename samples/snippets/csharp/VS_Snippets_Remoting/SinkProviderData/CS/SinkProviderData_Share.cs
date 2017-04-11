/* The following program is the supporting program for demonstration of
   'System.Runtime.Remoting.Channels.SinkProviderData' class and its 
   properties 'Children', 'Name', 'Properties'.
*/


using System;
public class mySharedStringClass : MarshalByRefObject
{
   // Return the number of letters in the string.
   public int PrintString(String myString)
   {
      Console.WriteLine(myString);
      return myString.Length;
   }
}
