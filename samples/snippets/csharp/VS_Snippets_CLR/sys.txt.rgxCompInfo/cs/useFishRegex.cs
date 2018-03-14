//<snippet2>
// This code example demonstrates the RegexCompilationInfo constructor.
// Execute this code example after executing genFishRegex.exe.
// compile: csc /r:FishRegex.dll useFishRegex.cs

namespace MyApp
  {
  using System;
  using System.Reflection;
  using System.Text.RegularExpressions;

  class UseFishRegEx
    {
    public static void Main()
      {
// Match against the following target string.
      string targetString = "One fish two fish red fish blue fish";
      int matchCount = 0;
      FishRegex f = new FishRegex();

// Display the target string.
      Console.WriteLine("\nInput string = \"" + targetString + "\"");

// Display each match, capture group, capture, and match position.
      foreach (Match m in f.Matches(targetString))
	{
	Console.WriteLine("\nMatch(" + (++matchCount) + ")");
	for (int i = 1; i <= 2; i++)
	  {
	  Group g = m.Groups[i];
	  Console.WriteLine("Group(" + i + ") = \"" + g + "\"");
	  CaptureCollection cc = g.Captures;
	  for (int j = 0; j < cc.Count; j++)
	    {
	    Capture c = cc[j];
	    System.Console.WriteLine(
	      "Capture(" + j + ") = \"" + c + "\", Position = " + c.Index);
	    }
	  }
	}
      }
    }
  }

/*
This code example produces the following results:

Input string = "One fish two fish red fish blue fish"

Match(1)
Group(1) = "One"
Capture(0) = "One", Position = 0
Group(2) = "fish"
Capture(0) = "fish", Position = 4

Match(2)
Group(1) = "two"
Capture(0) = "two", Position = 9
Group(2) = "fish"
Capture(0) = "fish", Position = 13

Match(3)
Group(1) = "red"
Capture(0) = "red", Position = 18
Group(2) = "fish"
Capture(0) = "fish", Position = 22

Match(4)
Group(1) = "blue"
Capture(0) = "blue", Position = 27
Group(2) = "fish"
Capture(0) = "fish", Position = 32

*/
//</snippet2>