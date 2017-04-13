// <Snippet3>
using System;
using System.Collections.Generic;

public class HockeyTeam
{
   private string _name;
   private int _founded;
   
   public HockeyTeam(string name, int year)
   {
      _name = name;
      _founded = year;
   }

   public string Name {
      get { return _name; }
   }

   public int Founded {
      get { return _founded; }
   }
}

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      List<HockeyTeam> teams = new List<HockeyTeam>();
      teams.AddRange( new HockeyTeam[] { new HockeyTeam("Detroit Red Wings", 1926), 
                                         new HockeyTeam("Chicago Blackhawks", 1926),
                                         new HockeyTeam("San Jose Sharks", 1991),
                                         new HockeyTeam("Montreal Canadiens", 1909),
                                         new HockeyTeam("St. Louis Blues", 1967) } );
      int[] years = { 1920, 1930, 1980, 2000 };
      int foundedBeforeYear = years[rnd.Next(0, years.Length)];
      Console.WriteLine("Teams founded before {0}:", foundedBeforeYear);
      foreach (var team in teams.FindAll( x => x.Founded <= foundedBeforeYear))
         Console.WriteLine("{0}: {1}", team.Name, team.Founded);
   }
}
// The example displays output similar to the following:
//       Teams founded before 1930:
//       Detroit Red Wings: 1926
//       Chicago Blackhawks: 1926
//       Montreal Canadiens: 1909
// </Snippet3>
