// <Snippet1>
using System;
using System.Collections.Generic;

namespace SportsExample;

public class Sports
{
   private string[] types = [ "Baseball", "Basketball", "Football",
                              "Hockey", "Soccer", "Tennis",
                              "Volleyball" ];

   public string this[int i]
   {
      get => types[i];
      set => types[i] = value;
   }
}
// </Snippet1>

 class Program
 {
   static void Main()
   {
      var s = new Sports();
      Console.WriteLine(s[2]);
      s[1] = "Softball";
      Console.WriteLine(s[1]);
   }
}
