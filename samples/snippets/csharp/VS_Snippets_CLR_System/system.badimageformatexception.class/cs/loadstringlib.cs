// <Snippet3>
using System;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      string title = "a tale of two cities";
//      object[] args = { title}
      // Load assembly containing StateInfo type.
      Assembly assem = Assembly.LoadFrom(@".\StringLib.dll");
      // Get type representing StateInfo class.
      Type stateInfoType = assem.GetType("StringLib");
      // Get Display method.
      MethodInfo mi = stateInfoType.GetMethod("ToProperCase");
      // Call the Display method. 
      string properTitle = (string) mi.Invoke(null, new object[] { title } );
      Console.WriteLine(properTitle);
   }
}
// </Snippet3>
